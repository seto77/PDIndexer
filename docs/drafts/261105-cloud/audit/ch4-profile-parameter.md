<!-- 261105Cl: docs/drafts/261105-cloud — 既存マニュアルとコードの突き合わせ結果 (監査)。docs/src には未統合。 -->
# 第4章 Profile parameter（プロファイル情報）監査

> 本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象マニュアル: `docs/src/ja/4-profile-parameter.md` / `docs/src/en/4-profile-parameter.md`（ja/en は同一構成・同内容。両者間に実質的な差異は見当たらない）
対象コード: `PDIndexer/FormProfileSetting.cs` / `.Designer.cs` / `.resx` / `.ja.resx`、`Crystallography/Profile.cs`（`DiffractionProfile2`、`Profile`）、`Crystallography/Smoothing.cs`、`Crystallography/Mathematics/Spline.cs`、`Crystallography/Mathematics/Fourier.cs`、`PDIndexer/FormTwoThetaCalibration.cs`、`PDIndexer/FormMain.cs`（マウス操作部）、`Crystallography.Controls/Wave/HorizontalAxisUserControl.*`

略記: FPS = `PDIndexer/FormProfileSetting.cs`, FPS.D = `.Designer.cs`, P = `Crystallography/Profile.cs`, FM = `PDIndexer/FormMain.cs`

---

## 1. 食い違い（マニュアル記述 vs コード）

| # | マニュアル箇所 (file:見出し/行) | マニュアルの記述 | コードの実際 (file:method/line) | 深刻度 |
|---|---|---|---|---|
| 1 | ja/en: 冒頭「各処理は…上から順に適用されます」、`#profile-processing`「有効にしたものが番号順に適用されます」 | 処理 1〜7 は番号順に適用 | 実際の順序は 軸変換(+CPS/対数) → 横軸 Shift → 1.2θオフセット → 2.マスク補間 → 3.スムージング → 4.バンドパス → 5.Kα2除去 → **7.ノーマライズ → 6.バックグラウンド減算**。ノーマライズはバックグラウンド減算より**前**（P `SetConvertedProfile` L751-794 → `SetMaskingProfile` L797 → `SetSmoothingProfile` L834 → `SetKalpha2RemovedProfile` L893 → `SetBackGroundProfile` L929: L938 `Normarize()` の後に L947 以降 BG 減算） | 高 |
| 2 | `#smoothing` 本文 | 注目点から「± `Point No.` 分のデータ」で多項式フィット | `Point No.` は**片側ではなく窓の総点数**。`SavitzkyGolaySimple` は `pointNum` 点（オフセット `j - pointNum/2`, j=0..pointNum-1）、`SavitzkyGolayAccuracy` も最近傍 `pointNum` 点に絞る（`Smoothing.cs` L33-35, L71-74）。ツールチップ「window half-width (points on each side)」も同じ誤り | 高 |
| 3 | `#smoothing`（既定値の扱い） | 記述なし（スムージングが効く前提） | 既定値 Point No.=3, Order=3（FPS.D L848, L862; P L616）。`if (pointNum < order + 1) order = pointNum - 1` で次数 2 に下げられ、3 点を 2 次で厳密に通るので**既定値では平滑化されない（恒等変換）**（`Smoothing.cs` L11-12） | 高 |
| 4 | `#smoothing` note | `Order`=1 のとき単純移動平均と一致 | 等間隔データ（`SavitzkyGolaySimple`）かつ Point No. が奇数のときのみ成立。Point No. 偶数では窓が非対称（`j - pointNum/2`）になり不一致。非等間隔データ（`SavitzkyGolayAccuracy`）では窓が中心対称とは限らない。また `Order`=0 は移動平均ではなく**処理なし**（`if (order <= 0) return copy` `Smoothing.cs` L13）。Point No.<2 も処理なし（L11） | 中 |
| 5 | `#mask` 表 `Save Masking Ranges` / `Read Masking Ranges` | マスク範囲をファイルに保存・読み込み | 両ハンドラの本体は全てコメントアウトされており**何もしない**。Read はファイルダイアログ(*.mas)を開くだけ、`.mas` のドラッグ&ドロップも `readMaskingRanges` が空のため無効（FPS `toolStripMenuItemSaveMaskingRange_Click` L793-819, `readMaskingRanges` L827-853）。なおこの 2 項目はボタンではなくマスク範囲リストの右クリックメニュー（FPS.D L775, L786） | 高 |
| 6 | `#mask` 表 `Set Masking range` | マスクする横軸範囲を指定 | 数値入力欄ではなく**チェックボックス**（`checkBoxShowMaskedRange`、既定 Checked=true, FPS.D L730）。ON の間、メイン画面上の左ドラッグで範囲を作成・境界移動、幅 0 の範囲はマウスアップで削除、範囲描画も ON 時のみ（FM `pictureBoxMain_MouseDown` L2225-2238, `MouseUp` L2280-2289, `DrawMaskedRange` L1524） | 中 |
| 7 | `#mask` 表 `Polynomial order` / `Point No.` | 次数・点数を指定（既定値の記載なし） | UI 既定は 3/3（FPS.D L747, L761）だが、プロファイル選択時に `DiffractionProfile2` の値で上書き表示され、その初期値は **次数 2・点数 20**（P L514, L528; FPS `bindingSource_CurrentChanged` L365-366）。また UI 最小値は 0 だが、setter が `value > 0` のときだけ代入するため **0 は無視され直前値のまま**（P L516-540） | 中 |
| 8 | `#bandpass` 表 | `Cut high-freq. over`: 指定値より高周波を除去 / `Cut low-freq. under`: 指定値より低周波を除去 | ソフトカット。ローパス(Cut high-freq. over, 値 f_L)は f_L〜2f_L で 1→0 の線形テーパ、2f_L 超で 0。ハイパス(Cut low-freq. under, 値 f_H)は f_H/2 未満で 0、f_H/2〜f_H で 0→1 の線形テーパ（P `SetSmoothingProfile` L857-875）。「指定値で急峻にカット」ではない。また各サブ項目は個別チェックボックス（`checkBoxLowPassFilter`/`checkBoxHighPassFilter`）で ON にする必要がある | 中 |
| 9 | `#remove-ka2` warning | 横軸の単位や入射線の種類は軸変換タブで確認・設定 | 軸変換タブの `Change` は `SrcProperty` のうち **AxisMode・EnergyTakeoffAngle・WaveLength と ExposureTime だけ**をコピーし、WaveSource・XrayElementNumber・XrayLine は更新しない（FPS `buttonChangeSouceXAxis_Click` L325-337）。Kα2 除去の判定は `SrcProperty.WaveSource==Xray && XrayElementNumber!=0 && XrayLine==Ka1`（P L902）なので、軸変換タブで線源を Kα1 に変えても判定条件は変わらない | 中 |
| 10 | `#remove-ka2` | Kα2 由来強度を除去（方法・比率の記載なし） | 強度比 Kα2/Kα1 = **0.5 固定**、波長は `AtomStatic.CharacteristicXrayWavelength`（Bearden 1967）。カスタム波長（元素番号 0）では無効（P L902-923）。詳細は §5 | 低 |
| 11 | `#background` B-Spline | `Auto Detect` を押すと自動的にバックグラウンドを計算して減算 | Auto Detect は制御点 `BgPoints` を決めるだけで、減算はチェックボックス 6 が ON かつ B-Spline 選択時に再計算チェーンで行われる（FPS `buttonAutoDetectBG_Click` L167-177）。見つかった点が 3 点未満なら既存の制御点は**変更されない**（P `getBgPointsAuto` L1071-1072） | 低 |
| 12 | `#background` B-Spline | 「B スプライン曲線」 | 実装は B スプラインではなく、制御点を**必ず通る 3 次補間スプライン（C2 連続、端点 2 階微分 0 = 自然スプライン相当、範囲外は線形外挿）**（`Spline.cs` `GetSpline(PointD[], Profile)` L167-261）。UI ラベルは `B-Spline curve` のまま | 中 |
| 13 | `#background` B-Spline | 丸い制御点をマウスでドラッグして曲線を作成 | 制御点の表示・編集は `Show background profile` が ON のときのみ（FM L1661-1662, L2100）。左ダブルクリックで点追加、左クリック+ドラッグで移動、右クリックで削除（FM `pictureBoxMain_MouseDown` L2100-2130）。マニュアルは追加・削除と前提条件に触れていない | 中 |
| 14 | `#background` Reference | `Show background profile` は Reference の項で説明 | `checkBoxShowBackgroundProfile` は B-Spline/Reference 共通（`flowLayoutPanelBackgroundSubtraction` 直下, FPS.D L967）。また `2. Mask` を ON にすると自動で OFF になる（FPS L117-118）。ラジオボタンの実ラベルは `Refference`（resx `radioButtonBackgroundReferrence.Text`）で、マニュアルの `Reference` と不一致。倍率 `×`（`numericBoxBackgroundReferrenceScale`）の記載なし | 低 |
| 15 | `#apply-all` | 処理 1〜7 のうち 6 を除く設定を全プロファイルに適用 | 適用されるのは マスク(ON/OFF・次数・点数のみ。**マスク範囲自体はコピーされない**)、ノーマライズ、スムージング、2θ オフセット、バンドパス、横軸 Shift。**5. Kα2 除去も適用されない**（FPS `buttonApplyAllProfiles_Click` L213-227） | 中 |
| 16 | `#normalize` 表 | ラベル `Average` / `Maximum`、`intensity between`、`to` | 実ラベル(en)は `Set the` [`average`/`maximum`] `intensity` / `in the range` [下限] `~` [上限] `to` [目標値]（resx `label1.Text`, `radioButtonNormarizeAverage.Text`, `label2.Text`, `numericBoxNormarizeRangeLow.HeaderText`, `numericBoxNormarizeRangeHigh.HeaderText`, `numericBoxNormarizeIntensity.HeaderText`）。`intensity between` は存在しない | 低 |
| 17 | `#normalize` | 範囲内の平均/最大が指定強度になるよう規格化 | 範囲は両端を含まない開区間（`X > Start && X < End`, P `Normarize` L977-979）。倍率は Err にも掛かる（L995-997）。ノーマライズは BG 減算**前**の強度に対して行われる（#1 参照） | 中 |
| 18 | `#axis-setting` 表 | `Horizontal axis setting` で横軸の現在の単位（`horizontal unit`）を変更 | `horizontal unit` は `Shift` 量入力欄のフッタ（単位表示）であり単位選択ではない（resx `numericBoxShiftHorizontalAxis.FooterText`）。横軸種別・単位・線源は埋め込みの `HorizontalAxisUserControl` で設定し、**`Change`（ja: `変更`）ボタンを押すまで反映されない**（FPS L325-337）。Change ボタンはマニュアル未記載 | 高 |
| 19 | `#axis-setting` 表 | `Vertical axis setting` は縦軸に関する設定 / Exposure Time は別項目 | `Vertical axis setting`（`groupBox2`）の中身は `Exposure Time` だけ（FPS.D L537-544）。露出時間もShift と異なり `Change` 押下時にのみ反映（FPS L333） | 低 |
| 20 | `#axis-setting` 冒頭 | 入射線の種類、入射線のエネルギーなどを変更 | #9 のとおり Change で更新されるのは AxisMode・取り出し角・波長のみ。線種(X線/電子線/中性子)・単色/白色・特性X線元素/線・TOF 距離/角度・単位は `SrcProperty` に反映されない（FPS L330-333） | 中 |
| 21 | `#profile-operator` 表 | `Two profiles`: 算術演算（加算など）、`Profile and value`: スカラーとの演算 | Two profiles は +, −, ×, ÷。Profile and value は **+ と × のみ**（−・÷ ボタンは非表示, FPS `radioButtonAverage_CheckedChanged` L510-519）。× と ÷ のボタンは記号フォントの私用領域文字（``, ``）で、ツールチップにも「記号は表示されない」とある | 低 |
| 22 | `#profile-operator` | 演算結果が新しいプロファイルとして追加 | 演算対象は各プロファイルの**処理後プロファイル `dp.Profile`**（スムージング・BG 減算・ノーマライズ等適用後、かつ表示軸座標）。結果の `SrcProperty` は現在のメイン画面の横軸設定（FPS L683-700） | 中 |
| 23 | `#two-theta-offset` | 角度分散型データに対して補正 | 条件は「**表示側の**横軸が角度（`DstProperty.AxisMode == Angle`）」（P L772）。X を度とみなして `tan(X/360·π)` を計算するため表示単位が rad/mrad/centi-deg のときの扱いは要確認（§4）。横軸 Shift が先に加算される（P L764-770） | 低 |
| 24 | `#two-theta-offset` 較正 | 観測ピークと理論ピークを対応付けて係数をフィッティング | `Calibrate` ボタンは Fitting ウィンドウ（`formFitting`）が表示中のときのみ有効（`FormTwoThetaCalibration_MouseMove` L45-48）。Fitting で ✓ した面の XObs/XCalc を用い、次数 1〜3（既定 3）、8 回反復・各回係数増分 ×0.9 の減衰付き。`Revert` で較正前に戻せる（`FormTwoThetaCalibration.cs` L60-131）。マニュアルは Fitting ウィンドウ必須・Revert・次数指定に触れていない | 中 |
| 25 | ja `#normalize` ほか（ja UI 表示） | ja マニュアルは `平均値`/`最大値` 等の ja ラベルを前提 | ja UI ではノーマライズ欄の `label1`/`label2` が `露出時間` / `線の色` と表示される（`FormProfileSetting.ja.resx` L125, L149）。古い ja 訳が残った不具合と思われる（§3-1） | 中 |

---

## 2. マニュアル未記載の機能・設定

| # | 機能/コントロール (UI 英/日ラベル) | 実装箇所 | 概要 (既定値・単位を含む) |
|---|---|---|---|
| 1 | `Shift` / `横軸シフト` + 数値（フッタ `horizontal unit`） | FPS.D L515-532; FPS `setShiftOption` L284-291; P L764-770 | 軸変換タブ。ON で表示軸座標の X に一定量を加算。範囲 −100000〜100000、小数 3 桁、増分 0.01、既定 0。Change 不要で即時反映。Apply for all の対象 |
| 2 | `Change` / `変更` | FPS.D L477-480; FPS `buttonChangeSouceXAxis_Click` L325-337 | 軸変換タブの横軸/線源設定と露出時間を選択プロファイルの `SrcProperty` に反映するボタン（反映項目は §1-#9,#20） |
| 3 | 横軸/線源設定 UI（`Horizontal axis`/`横軸`: `2θ (Angle)`/`2θ (角度)`, `d-spacing`/`d値`, `q (wavenumber)`/`波数`, `Energy`/`エネルギー`, `Neutron TOF`/`中性子TOF`; `Source`/`線種`: `X-ray`/`X線`, `Electron`/`電子線`, `Neutron`/`中性子線`; `Color mode`/`単色/白色`: `Monochromatic`/`単色`, `Flat White`/`白色`, `Custom white`/`カスタム色`; `Unit options`/`単位`; TOF `2θ`[°], `L`[m]） | `Crystallography.Controls/Wave/HorizontalAxisUserControl.resx` / `.ja.resx` | EDX（エネルギー分散, 取り出し角）、TOF（2θ, 飛行距離 L）を含む横軸設定。ただし Change で `SrcProperty` に入るのは AxisMode/取り出し角/波長のみ |
| 4 | `Exposure Time` + `sec. (for CPS mode)` | FPS.D L549-556; P `convertSrcToDest` L1158-1159 | メイン画面で `Count per Step (CPS)` / `カウント/秒 (CPS)` 選択時、強度 y を `y / ExposureTime` に換算（ExposureTime>0 のとき）。プロファイル既定 1 秒（P L651） |
| 5 | マスク範囲リスト `listBoxMaskRanges` | FPS.D L774-782; P `MaskingRange.ToString` L469-470 | 範囲を「小 - 大」(g8 書式) で一覧表示。選択でメイン画面上の範囲が濃いピンク＋太線で強調（FM L1532-1534） |
| 6 | バンドパス周期表示ラベル `labelLowPath` / `labelHighPass` | FPS `checkBoxBandPassFilter_CheckedChanged` L96-106 | `= 1/値` を小数 4 桁で表示（周期, 単位 Angle "°", d "Å", EnergyXray "eV", NeutronTOF "ms"） |
| 7 | バンドパス閾値の範囲自動設定 | FPS `bindingSource_CurrentChanged` L389-413 | 最大 = 1/(x₁−x₀)、最小 = 1/(x_N−x₀)（`dp.Profile` 基準）。未設定(NaN)時の初期値: ハイパス=最小、ローパス=最大 → 既定では実質無効。Designer 初期: 0〜10, 小数 2, 増分 0.01（FPS.D L906-948） |
| 8 | 参照 BG の倍率 `×` | FPS.D L1004-1015; P L960 | 参照プロファイル値に掛ける倍率。0.0001〜100、小数 4 桁、既定 1 |
| 9 | 参照 BG のプロファイル選択コンボ | FPS `setBackgroundOption` L277-280 | 自分自身を選ぶと参照なし(null)扱い |
| 10 | B-Spline 制御点のマウス操作 | FM `pictureBoxMain_MouseDown` L2100-2130 | `Show background profile` ON 時: 左ダブルクリック=追加、左クリック=選択（ドラッグ移動）、右クリック=削除。画面上部に "Background Control Points Select Mode" 表示（FM L1662-1668） |
| 11 | `Point No`（BG 点数） | FPS.D L985-991 | 範囲 3〜50、既定 15（P L662 も 15）。Auto Detect 押下時のみ読み取られる |
| 12 | 線の幅 `Line width` | FPS.D L395-404 | 0〜100、小数 1、既定 1、単位 pt（フッタ `pt`）。※ja resx にこのコントロールの ja 訳はなく英語表示（`label7.Text`=`線の幅` は存在しないコントロール向け） |
| 13 | プロファイル一覧の列 `Check` / `Color` / `Profile` | FPS.D L236-281; resx HeaderText | チェックで表示/非表示、色見本、名前。`Delete all` は確認ダイアログあり（FPS L74） |
| 14 | `Revert`, `Order`（2θ 較正ダイアログ） | `FormTwoThetaCalibration.cs` L50-58, L123-131; `.Designer.cs` L94-110 | 次数 1〜3（既定 3）。シフト関数表示 `Δ(2θ) = a1 + a2 tan(θ) + a3 tan^2(θ)`。Revert で較正前の係数に戻す |
| 15 | 2θ オフセット係数欄 `Δ(2θ)=` [c0] `+` [c1] `tan(θ)+` [c2] `tan^2(θ)` | FPS.D L643-678; resx | 小数 5 桁、単位は度（ツールチップ）、既定 0 |
| 16 | 出力名の連番自動増加 | FPS `buttonCalculate_Click` L705-706 | 出力名の末尾 2 文字が整数なら計算後に +1（2 桁ゼロ埋め） |
| 17 | 平均化の誤差伝播 | FPS L581-597 | σ = √(Σσᵢ²)/n（n は誤差≠0 のプロファイル数） |

---

## 3. 実装上の疑問点

1. **ja resx のラベル誤訳（古い訳の残骸）**: `FormProfileSetting.ja.resx` の `label1.Text`=`露出時間`(L149)、`label2.Text`=`線の色`(L125) が、現在ノーマライズ欄（`flowLayoutPanel17`, FPS.D L1036-1050）にある `label1`/`label2`（en: `Set the` / `intensity`）に適用される。ja UI では「露出時間 ○平均値 ○最大値 線の色」と表示されるはず。また `label7`, `label12` は Designer に存在しないコントロール向けの孤立エントリ。
2. **ノーマライズと BG の順序/スケール不整合**: `SetBackGroundProfile` で `Normarize()` 後に BG を減算（P L938, L947-965）。B-Spline BG は `ConvertedProfile`（正規化前）由来の制御点、参照 BG も正規化前の値なので、ノーマライズ ON 時は「正規化後強度 − 未正規化 BG」になる。
3. **Auto Detect の配列範囲外**: `getBgPointsAuto` で最近傍 index k が 1〜4 のとき `for (l = k - 5; ...)` で負の index を参照し例外（P L1093-1097）。また範囲末尾で 11 点未満でも ÷11 しており過小評価。コメント「周り5ポイント」と実装（11 点）も不一致。変数 `minimum` は未使用（L1102-1105）。
4. **Auto Detect 内の SG(3,3) が恒等変換**: `Smoothing.SavitzkyGolay(..., 3, 3)` は次数が 2 に下げられ 3 点厳密補間となり平滑化しない（P L1007, L1013, L1020; `Smoothing.cs` L12）。微分前の平滑化を意図していたとすれば機能していない。
5. **Auto Detect の range=0 時の重複**: `range = (int)(p1.Count/3.0/BgPointsNumber)` が 0 になると（点数が少ない場合）除外判定 `Math.Abs(i - xindex) < 0` が常に偽で同一点が繰り返し採用され、スプライン行列が特異になり得る（P L1037-1052）。
6. **バンドパス後の絶対値化**: 逆 FFT 後に `src[i].Magnitude` を強度とする（P L886）。負値になる成分は符号が反転（整流）される。さらにループが `i = 1` から始まり**先頭点は未フィルタのまま**（L883）。N 偶数時のナイキスト bin（i = N/2）はどちらのフィルタループ（`i < center`）でも処理されず、共役コピー（`i ≥ center+1`）でも上書きされない。
7. **Kα2 除去が表示軸を確認していない**: 条件は Src の線源のみ（P L902）で、X を 2θ（度）とみなして `sin(X/360·π)` を計算。表示軸が d 値・エネルギー等でも処理が走る可能性。2θ オフセットも同様に度を仮定（P L776）。フィールド `Kalpha1`, `Kalpha2`（P L629）は未使用。
8. **乗算・除算の誤差伝播式**: `err1 = p.Err[j].Y / p.Err[j].Y`（常に 1 または NaN）となっており相対誤差になっていない。かつ `p.Pt[j]` を先に上書きしてから誤差を計算（FPS L636, L652）。
9. **除算で 0 除算点を削除する際の index ずれ**: `p.Pt.RemoveAt(j)` の後 `j--` がないため直後の点が除算されずに残る（FPS L643-647）。
10. **2 プロファイル演算・参照 BG の補間が「近傍 2 点平均」**: `GetValue(x, 1, 0)` は `GetValues` 内で pointNum=2, order=0 となり、最も近い 2 点の単純平均（0 次フィット）を返す（P `GetValues` L205-208, L237-245）。線形補間ではない。X が一致しても `Pt[0]` 一致時は (y₀+y₁)/2 になる。平均化モードは `GetValue(x, 2, 1)`（線形補間・**範囲外は線形外挿**）で、幅の狭いプロファイルの外側に外挿値が足し込まれる（FPS L579, P L168-186）。
11. **マスク補間の無限ループの可能性**: `GetValues(..., eachside: true)` は `while (pt.Count < pointNum)` で両端を越えると追加できる点がなくなり抜けられない（P L227-237）。残存点数 < 2×`Point No.` のとき発生し得る。
12. **2θ 較正の目的変数**: `Y = Math.Tan(twoThetaCalc - twoThetaObs)`（度の差をラジアンとして tan）（`FormTwoThetaCalibration.cs` L97）。小さな差では ≈ 差なので実用上は近似的に動くが、意図は単なる差分と思われる。
13. **`Change` が SrcProperty の一部しか更新しない**（FPS L330-333）。線源/元素/線種/単位/TOF パラメータが反映されない。
14. **デッドコード**: `buttonSetDefaultProfile_Click`（FPS L295-305）はどのコントロールにも結線されていない（Designer に該当ボタンなし）。`CopyParameter` 呼び出しもコメントアウト（FM L3471）。
15. **SG 端点**: 等間隔時（`SavitzkyGolaySimple`）は先頭・末尾 `pointNum/2` 点が未平滑のまま（`Smoothing.cs` L46）。
16. **スプラインの条件数**: 制御点 X をそのまま X³ で行列化（`Spline.cs` L192-217）。エネルギー（eV 単位で ~10⁴〜10⁵）等では X³ が 10¹⁵ 程度となり数値的に不安定になり得る（未検証）。逆行列失敗時は空 Profile を返し、`SetBackGroundProfile` の index 参照で例外の可能性（P L951-953）。
17. **表示単位ラベル**: バンドパスの周期表示で NeutronTOF を "ms" と固定（FPS L101）だが、`HorizontalAxisProperty.TofTimeUnit` 既定は µs（P L1305）。Angle/d も単位設定（rad, nm 等）を無視して "°"/"Å" 固定。

---

## 4. 要確認事項

1. メイン画面の表示 2θ 単位が rad/mrad/centi-deg のとき、2θ オフセット・Kα2 除去（いずれも X を度と仮定）が正しく動くか。`HorizontalAxisProperty.TwoThetaUnit` の既定は Radian（P L1264）だが、FormMain での実際の既定値は未確認。
2. 実機の ja UI でノーマライズ欄が `露出時間`/`線の色` と表示されるか（§3-1）。
3. メイン画面の `Count per Step (CPS)`（en）と `カウント/秒 (CPS)`（ja）の意味の不一致（FormMain.resx / FormMain.ja.resx `radioButtonCountsPerStep.Text`）。コードは露出時間[秒]で割る（P L1158-1159）ので「秒あたり」が実態。第1章側の担当と調整要。
4. プロファイル演算結果（処理済み・表示座標の `dp.Profile` を `SourceProfile` にする）を、対数表示モードや CPS モードで作った場合に二重変換にならないか（新規 DiffractionProfile2 は `IsCPS=true`, `ExposureTime=1` 既定; FormMain 側で上書きされるかは未確認）。
5. Kα2 除去のマニュアル warning の「Kα1 を選択している場合」の設定経路は、ファイル読み込み時の線源指定のみか（`Change` では XrayLine が更新されないため）。
6. `numericBoxExposureTime` の Designer 上の初期値・範囲は resx 側にも明示がなく NumericBox 既定に依存（未確認）。プロファイル選択時に `dp.ExposureTime`（既定 1）で上書きされる。

---

## 5. 補足: 下書き用素材（methods 章向け・実装どおりの記述）

### 5.0 処理チェーン（`DiffractionProfile2`, P L748-967）
`SetCurrentProfile`（FPS L191-212）がUI値を `dp` に書き込み、`dp.SetConvertedProfile(formMain.HorizontalAxisProperty)` で以下を順に実行する。各段は前段の結果を入力にする。

1. **軸変換** `ConvertSrcToDest`（P L1151-1191）: `HorizontalAxisConverter.Convert` で Src→Dst の X 変換。Y は `IsCPS && ExposureTime>0` なら `Y/ExposureTime`、`IsLogIntensity` なら `log10(Y)`。X または Y が NaN/∞ の点は除外。
2. **横軸シフト**（L764-770）: `IsShiftX` なら `X += ShiftX`（Pt と Err の X 両方）。
3. **2θ オフセット**（L772-784）: `DoesTwoThetaOffset && DstProperty.AxisMode == Angle` のとき、各点で `t = tan(X·π/360)`（= tan θ, X を 2θ[度]とみなす）、`X ← X + c0 + c1·t + c2·t²`。その後 X で昇順ソート → `ConvertedProfile`。
4. **マスク補間** → `InterpolatedProfile`（5.2）
5. **Savitzky–Golay 平滑化** → **バンドパス** → `SmoothedProfile`（5.3, 5.4）
6. **Kα2 除去** → `Kalpha2RemovedProfile`（5.5）
7. **ノーマライズ**（5.6）→ **バックグラウンド減算**（5.7）→ 最終 `Profile`

誤差 `Err` は X の変換・シフト・オフセットとノーマライズ（倍率）のみ受け、平滑化・バンドパス・Kα2・BG では変更されない。

### 5.1 2θ オフセット較正（`FormTwoThetaCalibration.buttonCalibrate_Click` L60-121）
- 前提: Fitting ウィンドウが表示中（ボタン有効化条件）。Fitting で ✓ された面（`IsFittingChecked`）のうち XObs, XCalc が NaN でないものを使用。
- 8 回反復。各回: `formFitting.Fitting()` → 行列 `X[i,j] = tan(θcalc,i)^j`（j = 0..order−1, θ = XCalc/2 [度→rad 変換 `XCalc/360·π`]）、`Y[i] = tan(XCalc_i − XObs_i)`（引数は度の差をそのまま rad として使用）→ 最小二乗 `A = (XᵀX)⁻¹XᵀY` → `c_k += 0.9·A_k`（order 未満の係数は 0 にリセット）。
- order = min(UI 次数(1〜3, 既定 3), 使用面数)。

### 5.2 マスクと補間（`SetMaskingProfile` P L797-831）
- `DoesMaskAndInterpolate && maskingRanges.Count>0` のとき、各範囲について `Minimum < X < Maximum`（開区間）の点を削除し、その X を保持。
- 全範囲の削除後、各範囲の X 群に対し `GetValues(x, 2·InterpolationPoints, InterpolationOrder, eachside: true, shareSameFunction: true)`（P L205-307）:
  - 最初の X の直前点 index を position とし、`Pt[position], Pt[position+1], Pt[position−1], Pt[position+2], …` と両側から交互に計 `2·InterpolationPoints` 点を採用（片側 `InterpolationPoints` 点）。
  - X を `X' = c1·x + c2`（c1 = 1/(x_last−x_first) of 採用点列, c2 = 1 − x_first·c1）でスケーリングし、`InterpolationOrder` 次多項式を正規方程式で最小二乗フィット。order は `pointNum−1` を上限にクリップ。
  - 同一の多項式で範囲内全 X の値を計算（shareSameFunction）。
- 補間点を戻して X ソート。
- 既定（プロファイル側）: 次数 2、片側点数 20（P L514, L528）。UI 範囲: 次数 0〜5、点数 0〜100（0 は setter で無視）。
- マスク範囲は表示軸（Dst）座標で保持・判定。

### 5.3 Savitzky–Golay 平滑化（`Smoothing.SavitzkyGolay(profile, pointNum=M, order=N)`）
- UI: `Point No.` = M（0〜100, 既定 3）、`Order` = N（0〜5, 既定 3）。
- 前処理（`Smoothing.cs` L11-14）: M<2 → 処理なし。M<N+1 → N=M−1。N≤0 → 処理なし。点数<3 → 処理なし。
- 等間隔判定: `|(x_N−x_{N−1})/(x_1−x_0) − 1| < 1e−9` なら Simple、そうでなければ Accuracy。
- **Simple**（L27-56）: 設計行列 `A[j,i] = (j − ⌊M/2⌋)^i`（j=0..M−1, i=0..N）、`H = (AᵀA)⁻¹Aᵀ` の第 0 行を係数 a_j とし、`n = ⌊M/2⌋ … L−1−⌊M/2⌋` について `y'_n = Σ_j a_j · y_{n−⌊M/2⌋+j}`。端の ⌊M/2⌋ 点は元値のまま。M 偶数では窓が非対称（左 M/2 点・右 M/2−1 点）。
- **Accuracy**（L63-101）: 各点 n について [n−M, n+M] から n に近い M 点を選び（遠い端から除去）、X を `c1·x + c2`（c1=1/(x_last−x_first), c2=1−x_first·c1）でスケールして N 次最小二乗フィットし、点 n の X で評価。逆行列失敗時は元値。
- 既定 (M=3, N=3) は N→2 となり 3 点 2 次の厳密補間＝恒等変換。

### 5.4 バンドパス（FFT）（`SetSmoothingProfile` P L847-888）
- 条件: `DoesBandpassFilter && 点数>2`。
- `src_k = y_k + 0i`（k=0..L−1）、`F = FFT_forward(src)`。FFT は任意長、順・逆とも 1/√L で正規化（`Fourier.FFT` L280-288）。
- `center = L/2`（実数）、`Δx = x_1 − x_0`（等間隔仮定）。bin i の周波数 = i/(L·Δx) [1/横軸単位]。
- **Cut low-freq. under**（ハイパス, `DoesHighPath && HighPathLimit>0`）: `ℓ = f_H·L·Δx`。i = 1 … ⌈center⌉−1 について、i < ℓ/2 → F_i = 0；ℓ/2 ≤ i < ℓ → F_i ×= (i − ℓ/2)/(ℓ/2)。DC (i=0) は保持。
- **Cut high-freq. over**（ローパス, `DoesLowPath && LowPathLimit>0`）: `ℓ = f_L·L·Δx`。i = 0 … について、i > 2ℓ → 0；ℓ < i ≤ 2ℓ → ×(1 − (i−ℓ)/ℓ)。
- i = ⌊center⌋+1 … L−1 を `F_i = conj(F_{L−i})` で置換（実信号の対称性を強制）→ 逆 FFT → `y_i = |result_i|`（i ≥ 1。i=0 は元値のまま）。
- UI: 値は周波数 [1/横軸単位]、右に周期 `= 1/f` を表示。範囲は [1/(x_N−x_0), 1/Δx] に自動設定、初期値はハイパス=下限・ローパス=上限（実質無効）。

### 5.5 Kα2 除去（`SetKalpha2RemovedProfile` P L893-926）
- 条件: `DoesRemoveKalpha2 && Src.WaveSource == Xray && Src.XrayElementNumber != 0 && Src.XrayLine == Ka1`。
- λ₁ = `CharacteristicXrayWavelength(Z, Ka1)`, λ₂ = `…(Z, Ka2)`（Å, Bearden 1967 系; `AtomStatic.cs` L5611 付近）。
- 各点 i（X_i = 2θ_i [度]）について `d = λ₂ / (2 sin(X_i·π/360))`、`2θ'_i = 2·asin(λ₁/(2d))·(180/π)`（＝同じ d で Kα1 が回折する 2θ）。
- `startY = y_0·2/3`。i を昇順に処理し（配列をその場で更新＝逐次型 Rachinger 法）、
  - `2θ'_i < X_0` なら `y_i ← y_i − 0.5·startY`
  - それ以外は `y_i ← y_i − 0.5·I(2θ'_i)`、I は更新途中の同プロファイルを `GetValue(x, 2, 1)`（2 点線形補間）で評価。
- 強度比 I(Kα2)/I(Kα1) = 0.5 固定（UI 設定なし）。

### 5.6 強度ノーマライズ（`Normarize` P L971-999）
- 対象は Kα2 除去後・BG 減算前のプロファイル。
- 範囲 `Start < X < End`（開区間, 既定 0〜180, UI 小数 1 桁, 0〜1,000,000）内で、Average なら S = Σy, n = 点数 → `factor = Target / (S/n)`；Maximum なら M = max y → `factor = Target / M`。Target 既定 1000（1〜100000, 小数 3 桁）。
- 範囲内に点がない場合は何もしない。全点の y と Err に factor を乗じる。

### 5.7 バックグラウンド減算（`SetBackGroundProfile` P L929-967）
- **B-Spline curve**（実体は 3 次補間スプライン）: `BackgroundProfile = Spline.GetSpline(ConvertSrcToDest(BgPoints), ConvertedProfile)` を `ConvertedProfile` の X で評価し、`y_i ← y_i − bg_i`（index 対応）。
  - `Spline.GetSpline`（`Spline.cs` L167-261）: 制御点 n（<3 なら bg=0）を X ソート。区間数 n+1、各区間 `a x³ + b x² + c x + d`。条件: 各制御点で左右区間が点を通る（2n 式）、1 階・2 階微分連続（2n 式）、左端区間 a=b=0・右端区間 a=b=0（4 式）→ 範囲外は線形外挿、端点で 2 階微分 0（自然スプライン相当）。(4n+4)² 行列を直接逆行列化。
  - 制御点 `BgPoints` は Src 座標・Src 強度（CPS なら ×ExposureTime、対数なら 10^y）で保持（`ConvertDestToSrc` P L1198-1222）。
- **Refference**: `bg_i = Ref.GetValue(x_i, 1, 0) × Scale`（近傍 2 点平均, §3-10）、`y_i ← y_i − bg_i`。Ref は他プロファイルの最終 `Profile`。Scale 既定 1（0.0001〜100）。
- **Auto Detect**（`getBgPointsAuto` P L1004-1109; 入力は `SmoothedProfile` ＝平滑化・バンドパス後、Kα2/正規化前）:
  1. p0 = SG(SmoothedProfile, 3, 3)（実質恒等）。
  2. p1: 隣接点の中点に 1 階差分 `(y_{i+1}−y_i)/(x_{i+1}−x_i)`、SG(3,3)。p2: 同様に 2 階差分、SG(3,3)。
  3. `y_k = p2_k / σ`（σ = 標本標準偏差 `Statistics.Deviation`）。
  4. `range = ⌊p1.Count / 3 / BgPointsNumber⌋`。
  5. 反復: i = 0 … p2.Count−31 で、既採用 index から `range` 未満の位置はスキップし、`T_i = Σ_{j=0}^{29} |y_{i+j}|` が最小かつ < 2 の i を探し、`i+15` を採用。見つからなくなるか採用数が `BgPointsNumber` に達するまで繰り返す。
  6. 採用数 < 3 なら終了（BgPoints 変更なし）。
  7. 採用 X をソートし、各々 p0 の最近傍 index k（k≠0）について `Y = Σ_{l=k−5}^{min(k+5, N−1)} p0_l / 11` を BG 点 (p0_k.X, Y) とする。
  8. `BgPoints = ConvertDestToSrc(bg 点)`。
- BG 点数 UI: 3〜50、既定 15。

### 5.8 プロファイル演算（`buttonCalculate_Click` FPS L548-707）
- 入力はすべて処理後 `dp.Profile`（表示軸座標）。
- **Average**（1 本以上選択）: X 範囲（x_last−x_first）が最大のプロファイルの X 格子を基準に、各プロファイルを `GetValue(x, 2, 1)`（2 点線形補間/範囲外線形外挿）で評価して平均。誤差 `σ = √(Σσ_i²)/n`（n = GetErr≠0 の本数; GetErr は区間内では両端誤差の平均）。
- **Two profiles**（第 1≠第 2）: 第 1 の X 格子上で第 2 を `GetValue(x,1,0)`（近傍 2 点平均）で評価し +, −, ×, ÷。+/− の誤差 √(σ₁²+σ₂²)。×/÷ は §3-8 の式。÷ は |分母| < 1e−9 の点を削除。
- **Profile and value**: + （誤差不変）、×（誤差も ×値）。
- 結果: 新規 `DiffractionProfile2`（`SourceProfile` = 結果, 名前 = 出力名, ランダム色, `SrcProperty` = 現在のメイン画面横軸設定）を一覧に追加。出力名末尾 2 桁の数字を +1。

### 5.9 Apply for all profiles（FPS L213-227）
全プロファイルに対し: マスク（ON/OFF・次数・点数）、ノーマライズ（全項目）、スムージング（全項目）、2θ オフセット（ON/OFF・係数）、バンドパス（全項目）、横軸 Shift を設定し再計算。Kα2 除去・バックグラウンド・マスク範囲・コメントは対象外。
