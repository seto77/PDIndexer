<!-- 261105Cl: docs/drafts/261105-cloud — 既存マニュアルとコードの突き合わせ結果 (監査)。docs/src には未統合。 -->
# 第3章「回折線・結晶情報 (Crystal parameter)」監査結果

> 本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象マニュアル: `docs/src/ja/3-crystal-parameter.md` / `docs/src/en/3-crystal-parameter.md`（両者は同一構成・同一内容。ja/en 間の差異は §1 末尾に記載）
主な対象コード: `PDIndexer/FormCrystal.*`, `PDIndexer/FormMain.cs`（`InitializeCrystalPlane`, `DrawProfile_diffraction`, `SetFormEOS`, `readCrystal`）, `PDIndexer/FormCellFinder.*`, `PDIndexer/FormAtomicPositionFinder.*`, `Crystallography/Crystal/Crystal.cs`, `Crystallography/Symmetry/*.cs`, `Crystallography/Atom/Atoms.cs`, `Crystallography.Controls/Crystal/CrystalControl.*`, `Crystallography.Controls/Crystal/FormChemicalComposition.*`, `Crystallography.Controls/CrystalDatabase/*`

---

## 1. 食い違い（マニュアル記述 vs コード）

| # | マニュアル箇所 (file:見出し/行) | マニュアルの記述 | コードの実際 (file:method/line) | 深刻度 |
|---|---|---|---|---|
| 1 | ja/en 3-crystal-parameter.md: 冒頭 (l.4) | 「メイン画面の**ツールバー**から `回折線/結晶情報` **アイコン**をクリック」 | ツールバーのアイコンではなく、メイン画面の結晶データ欄 (`groupBoxCrystalData`) 下端に Dock されたチェックボックス `checkBoxCrystalParameter`。ラベル en `Crystal Parameter (C)` / ja `回折線/結晶情報 (C)`（FormMain.resx / FormMain.ja.resx `checkBoxCrystalParameter.Text`、FormMain.Designer.cs l.1224）。ウィンドウ題名は en `Crystal Parameter` / ja `回折線/結晶情報`（FormCrystal.resx/ja.resx `$this.Text`）。ja マニュアル H1「回折線・結晶情報」は「・」で UI の「/」と不一致 | 中 |
| 2 | 結晶リスト (l.84 付近) | 「メイン画面の **Profile** チェックリストと同一の情報を表示」 | 共有しているのは**結晶**リスト。`FormMain` コンストラクタで `formCrystal.dataSet = this.dataSet; formCrystal.bindingSource = this.bindingSourceCrystal; DataMember = "DataTableCrystal"`（FormMain.cs l.892-895）。Profile リストではない | 高 |
| 3 | 結晶リスト > 上下矢印 note | 「**1〜6 個目**の行は EOS のために予約されており、順番を変更できません」 | 予約は行番号ではなく `Crystal.Reserved` フラグで判定（FormCrystal.cs `buttonUpper_Click` l.217-223 / `buttonLower_Click` l.225-231）。既定リスト `PDIndexer/default.xml` では **0 行目 `Flexible Crystal` + 1〜10 行目（Au, Pt, NaCl (B1-type), NaCl (B2-type), MgO (periclase), Al2O3 (cor.), Ar, Re, Mo, Pb）の計 11 行**が `Reserved=true`。EOS 側も行 1〜10 を参照（FormMain.cs `SetFormEOS` l.2803-2840）。また予約行は**削除・更新も不可**（Ctrl 押下時のみ可、FormCrystal.cs `buttonChangeCrystal_Click` l.78 / `buttonDeleteCrystal_Click` l.135） | 高 |
| 4 | 結晶リスト > 全削除 | 「すべての結晶をリストから削除します」 | 確認ダイアログ (`PdiText.ClearCrystals` en "Do you want to clear all crystals?" / ja "すべての結晶をクリアしますか?") の後、`Reserved == false` の結晶のみ削除。予約結晶は残る（FormCrystal.cs `buttonAllClear_Click` l.145-151） | 中 |
| 5 | 結晶リスト > 追加 | 結晶情報で設定した結晶を「リストに新規追加」 | 追加時に `SaveInitialCellConstants()` で初期格子定数を保存し（FormCrystal.cs l.71）、追加行は `dataGridViewCrystals_CellMouseClick(列0)` 経由でチェック状態が反転＝**チェックされた状態**で追加・選択される（FormCrystal.cs `AddCrystal` l.92-95, FormMain.cs l.4507-4511）。記述漏れ | 低 |
| 6 | 回折線オプション > 近接するピークを結合 > tip | 「現行版では**横軸の種類に応じて**角度（°）またはエネルギー（eV）で指定」 | 横軸の種類で自動選択されるのではなく、ユーザーがラジオボタン `Angle Threshold`/`角度閾値` か `Energy threshold`/`エネルギー閾値` を選ぶ（FormMain.cs `InitializeCrystalPlane` l.2024-2029）。角度閾値は**現在の波長で換算した 2θ の差**、エネルギー閾値は**取り出し角 (TakeoffAngle) で換算した X 線エネルギーの差**で判定（Crystal.cs `SetPlanes` l.1072-1076）。横軸が d・TOF 等でもどちらかの方式で判定される | 中 |
| 7 | 回折線オプション > 近接するピークを結合 | 「強度をまとめて表示」 | 結合は「隣接ペアで差が最小のものを閾値未満なら併合」を繰り返す方式（閾値は **未満** `<`、閾値 0 では結合しない）。併合後の d は **2 本の単純平均**（強度加重ではない）、指数ラベルは `"h k l + h k l"`、強度は各成分の強度の和（Crystal.cs `SetPlanes` l.1080-1112, `SetPeakIntensity` l.1689-1736）。記述は概ね正しいが位置の扱いが未記載 | 低 |
| 8 | 回折線を下に表示 > 「ピーク高さ（Peak height）」 | UI に「ピーク高さ (Peak height)」というラベルがあるかのような見出し | 該当ラベル文字列は存在しない。数値欄 `numericBoxHeightOfBottomPeak` は FooterText `pixel` のみ（FormCrystal.resx）。既定 5、範囲 0〜100（FormCrystal.Designer.cs l.378-386）。各チェック結晶ごとに `(高さ+4)` px の帯を下部に確保（FormCrystal.cs l.188-189） | 低 |
| 9 | 弱いピークを非表示 | 「最強線と比べて低すぎるピークを消去」 | 比較対象の相対強度 `Plane.Intensity` は、**現在の表示範囲ではなく、読み込んだプロファイルの横軸全範囲 (MinimalX〜MaximalX) 内で生成した反射**の最大値で規格化（FormMain.cs `InitializeCrystalPlane` l.2011-2018, Crystal.cs `SetPeakIntensity` l.1740-1746）。判定は `閾値×0.01 < Intensity`（FormMain.cs l.1745）。既定は OFF、閾値 1.0 rel.%（範囲 0〜100、小数1桁） | 低 |
| 10 | 強度比を計算 / 強度を変更可 | 各チェックの独立した説明 | `強度比を計算` は `回折線を重ねて表示` が ON のときのみ有効、`強度を変更可` は `強度比を計算` が ON かつ有効なときのみ有効（FormCrystal.cs l.163-176）。依存関係が未記載 | 低 |
| 11 | 格子/対称性タブ > tip | 「**格子定数の入力欄を右クリック**すると…アプリ起動時（**またはデータベースから取り込んだ時点**）の値に回復するメニュー」 | メニュー項目は CrystalControl 全体の右クリックメニュー (`CrystalControl.ContextMenuStrip = contextMenuStrip`, CrystalControl.Designer.cs l.1237) の `Revert cell constants` / `アプリ起動時の格子定数に戻す`（CrystalControl.resx/ja.resx）。初期値の保存は (a) 結晶リスト xml 読込時（ConvertCrystalData.cs l.158-161）と (b) `追加` ボタン押下時（FormCrystal.cs l.71）のみ。**データベースで選択した時点では保存されない**。`更新 (Replace)` では保存しない | 中 |
| 12 | 状態方程式タブ 表 | `T0` / `Temperature`、等温式 `BM3`/`BM4`/`Vinet`/`AP2`/`Keane` | UI ラベルは `T₀` / `T`（HeaderText）、等温式ラジオは `3rd BM`（既定）/`4th BM`/`Vinet`/`AP2`/`Keane`/**`3rd Vinet`**（EOSControl.Designer.cs l.282-357、enum `IsothermalPressure { BM3, BM4, Vinet, Vinet3, AP2, Keane }` EOS.cs l.11-14）。`3rd Vinet`（パラメータ η, β, ψ）が漏れている。熱圧力は `Mie-Grüneisen`（既定）/ `T-dependence K₀ && V₀`（表示は `T-dependence K₀ & V₀`）。グループ名 `Isothermal pressure at T₀` / `Thermal pressure`。EOSControl は ja.resx に訳が無く英語表示 | 中 |
| 13 | 結晶データベース 冒頭 | 「AMCSD に基づいています」のみ | `crystalDatabaseControl.DatabaseSelection = true`（FormCrystal.Designer.cs l.526）で `AMCSD` / `COD` の選択チェックボックスが表示される。COD はローカルに無ければ Web からダウンロード（CrystalDatabaseControl.resx `checkBoxCOD.ToolTip`）。起動時は `AMCSD_Checked = true`（FormCrystal.cs `FormCrystal_Load`）。COD の記載なし | 中 |
| 14 | 検索オプション > 元素 > tip | 「`散乱因子を無視` をチェックすると、散乱因子を考慮せずに検索」を**元素**の節に記載 | `checkBoxIgnoreScatteringFactor` は **d 値検索**用。ON のとき DB 保存の「強度上位8本の d 値」(`CrystalMinimum.d`, CrystalMinimum.cs l.45) ではなく、格子定数から幾何学的に全 d 値を計算して照合（SearchCrystalControl.cs `backgroundWorkerSearch_DoWork` l.238-246、tooltip も同旨）。記載位置・説明が誤り | 中 |
| 15 | 検索オプション > d 値 | 「強度の強い結晶面の d 値と、許容する誤差」 | d 値は最大 3 個 (`checkBoxD1`〜`D3`) 個別に有効化でき、許容誤差は **±%**（既定 3%）。照合対象は DB に格納された強度上位 8 本の d 値（CrystalMinimum.cs l.45, SearchCrystalControl.cs l.248-253） | 低 |
| 16 | 検索オプション > 格子定数 / 密度 | 「許容する誤差を入力」 | 軸長誤差は ±%、角度誤差は ±°（既定いずれも 3、SearchCrystalControl.Designer.cs l.199-225）。各値 0 で条件無視。密度単位 FooterText `g/cc`、誤差 ±%（既定 3）。※格子定数検索には単位不一致の疑いあり（§3-1） | 低 |
| 17 | ja 3-crystal-parameter.md 内部リンク | `[原子情報タブ](#_8)`、`[結晶情報](#_5)`、`[強度比を計算](#calculate-intensity-ratio)` | ja 版の見出しには `{#calculate-intensity-ratio}` 等の明示 ID が無く（en 版は `{#calculate-intensity-ratio}`, `{#atom-info-tab}`, `{#crystal-information}` を付与）、`#_8`/`#_5` は自動採番依存。ja 側リンク切れの可能性（ドキュメント内の不整合、コードとは無関係） | 低 |
| 18 | 結晶リスト 列 | 「チェックボックス（`Check`）、描画色（`PeakColor`）、結晶名（`Crystal`）」 | FormCrystal 側の `dataGridViewCrystal.ColumnHeadersVisible = false`（FormCrystal.Designer.cs l.213）で列見出しは非表示。見出し文字列は内部名（`Crystal.HeaderText` は resx 上 `'Crysal'` と誤字）| 低 |

ja/en 間: 本章の ja と en は段落単位で対応しており、内容上の差異は #17（アンカー ID の有無）のみ。

---

## 2. マニュアル未記載の機能・設定

| # | 機能/コントロール (UI 英/日ラベル) | 実装箇所 | 概要 (既定値・単位を含む) |
|---|---|---|---|
| 1 | 各オプションの既定値 | FormCrystal.Designer.cs l.346-504, FormCrystal.resx | `Show peaks over profiles`/`回折線を重ねて表示` ON、`Calculate intensity ratio`/`強度比を計算` ON、`Scalable intensity`/`強度を変更可` OFF、`Show peaks under profile`/`回折線を下に表示` OFF（高さ 5 px）、`Hide peaks below`/`弱いピークを非表示` OFF（1.0 rel.%）、`Combine adjacent peaks:`/`近接するピークを結合:` OFF（`Angle Threshold` 0.010°（0〜2, 小数3桁）/ `Energy threshold` 5.0 eV（0〜1000））、`Show peak indices`/`ピーク指数を表示` ON（`all checked crystals`） |
| 2 | 設定の保存 | FormMain.cs `Registry` l.1077-1082 | 重ねて表示・強度比計算・強度変更可・下に表示・`all checked crystals`・ピーク高さはレジストリに保存。弱ピーク閾値・結合閾値・指数表示は保存されない |
| 3 | 指数ラベルの抑制条件 | FormMain.cs `DrawProfile_diffraction` l.1772 | リストで **0 行目 (Flexible Crystal) が選択されているときは、全結晶の指数ラベルが描かれない**。ラベルが重なる場合は 40 px ずつ下にずらす |
| 4 | 選択結晶・選択面の強調 | FormMain.cs l.1726-1738 | 選択中の結晶は線幅 3、選択面は線幅 5、その他は 1 |
| 5 | 回折線のドラッグ (格子定数スケーリング) | FormMain.cs l.2477-2492 | 通常結晶で面を選択して左ドラッグすると、ドラッグ位置の d と面の d の比で a,b,c を一様に拡大縮小。`強度を変更可` ON なら縦方向ドラッグ比で `DiffractionPeakIntensity` も変更。Flexible Crystal では面の d 自体を移動 |
| 6 | 結晶の点滅 | FormMain.cs `dataGridViewCrystals_CellMouseClick` l.4514-4526, `timerBlinkDiffraction_Tick` | 結晶行を**右ダブルクリック**で、その結晶の回折線を点滅表示（再度で解除） |
| 7 | CrystalControl 右クリックメニュー | CrystalControl.Designer.cs l.1088, CrystalControl.resx/ja.resx | `Details of the chemical composition`/`化学組成の詳細`、`Beam Interaction`/`ビーム相互作用`、`Symmetry Information`/`対称性詳細`、`Import from CIF or AMC...`/`CIFファイル又はAMCファイルから読み込み`、`Export to CIF`/`CIFファイルとして出力`、`Revert cell constants`/`アプリ起動時の格子定数に戻す`、`Convert to P1 Space Group`/`P1に変換`、`Convert to a superstructure`/`超構造に変換`、`Change the axes/origin setting`/`異なる軸・原点セッティングの空間群に変換`（`Send this crystal to other software` と `Strain Control` は resx で `Visible=False`） |
| 8 | 化学組成の詳細ウィンドウ (ver4.465) | Crystallography.Controls/Crystal/FormChemicalComposition.cs, Crystallography/Chemistry/CompositionConverter.cs, PDIndexer/Version.cs l.15 | CrystalControl 右クリック→`化学組成の詳細` で非モーダル表示（閉じても破棄せず非表示）。表示モード `Elements`/`元素`・`Oxides`/`酸化物`・`Halides`/`ハロゲン化物`・`Sulfides`/`硫化物`（後二者は O を含まない結晶用。使えないモードは Elements に戻る）、並び順 `Input order`/`登録順`・`Atomic number`/`原子番号順`。組成表は `wt%`/`重量%`・`at%`/`原子%`・`Atoms (normalized)`/`原子数 (規格化)`。価数表は `Element`・`Atoms/Cell`(`原子数/単位胞`)・`Valence`(`価数`、分数可、手入力値は `Crystal.ElementValences` に保存)・`Σ=0` ボタン・規格化原子数（列の欄をクリックして基準元素を指定。既定は組成式 1 単位あたり）、`Default`/`既定に戻す`、単位胞あたりの電荷合計。換算は価数による形式的換算（CompositionConverter.cs 冒頭コメント）。原子量は CIAAW 2024 に更新（Version.cs l.15）。UI 文字列は resx ではなくコード側 `Loc()` で多言語化 |
| 9 | 基本情報タブの派生量 | CrystalControl.resx/ja.resx | `Cell Volume`/`単位胞体積` (Å³)、`Cell Mass`/`単位胞質量` (×10⁻²⁴ g)、`Molar Volume`/`モル体積` (cm³/mol)、`Molar Mass`/`モル質量` (g/mol)、`Density`/`密度` (g/cm³)、`Mean Z (number)`/`平均Z (個数)`、`Mean Z (mass)`/`平均Z (質量)`、`Mean A`/`平均A`、`Atom density`/`原子数密度` (Å⁻³)、`Electron density`/`電子数密度` (Å⁻³)、`Formula`/`化学組成`、`Z`/`Z数`、`Name`/`結晶名`、`Color`/`描画色`、ボタン `Beam interaction`/`ビーム相互作用`、`Symmetry info.`/`対称性詳細`、`Change axes/origin setting` |
| 10 | 原子情報タブの右クリック | CrystalControl.Designer.cs l.509-516 | `Set Debye-Waller Factors to Zero`/`デバイワラー因子をゼロにする`（全原子の Dsf を B 型・等方・0 に） |
| 11 | 表示タブの構成 | FormCrystal.Designer.cs l.157-158, CrystalControl.cs l.42-87 | PDIndexer では `Basic Info.`・`Atom Info.`・`Ref.`・`EOS` の 4 タブのみ（Bonds & Polyhedra / Elasticity は明示的に非表示、Strain/Stress・Polycrystalline・Bounds・Lattice Plane は既定非表示）。`Ref.` タブは `Title`/`タイトル`、`Authors`/`著者`、`Journal`/`雑誌名`、`Note` |
| 12 | 強度計算の線源依存 | FormMain.cs `InitializeCrystalPlane` l.2033 | 強度はメイン画面の線源設定（`WaveSource`: X線/電子線/中性子、`WaveColor`: 単色/白色、波長）で計算（式は §5）。マニュアルに記載なし |
| 13 | 生成反射の範囲・上限 | FormMain.cs l.2000-2012, Crystal.cs `SetPlanes` l.975-976 | d 範囲 = 読み込んだプロファイル横軸全範囲を d 換算（dMin 下限 0.01 nm = 0.1 Å）。最大 8000 面（`_maxNum` 既定） |
| 14 | DB 検索の詳細 | SearchCrystalControl.cs l.115-253 | 名前・文献は部分一致・大小無視（文献は雑誌名/著者/セクション）。Enter キーで検索。結晶系に `Unknown` 項目あり（選ぶと無条件） |
| 15 | Cell Finder（ツールバー `Cell Finder`、ja ラベルは訳なし） | FormCellFinder.* | §5 にアルゴリズム。入力: d (Å)・信頼度 `High`/`Medium`/`Low`（重み 1/0.5/0.1）・`Use for Calc.`。制約 `Restrictions of cell parameters`（a,b,c 既定 2〜20 Å、α,β,γ 既定 60〜150°）、`Crystal System`（triclinic〜cubic、既定 triclinic）、`Wave Source`。`Find!`/`Stop!`、`Resume!`、結果 `Candidates (best 300)`、分布図 `X-Axis`/`Y-Axis`（既定 a / b）。`File > Load` は 4 行目以降を d 値（High）として読込。HelpPage は第 6 章 |
| 16 | Atomic Position Finder | FormAtomicPositionFinder.*, FormMain.resx `toolStripButtonAtomicPositonFinder.Visible = False` | ツールバーボタンが**非表示**のため通常 UI から起動不可。タブ `Symmetry`/`Chemistry`/`Diffraction Data`、`Balance of algorithm`（`Randomization` 95%、`Hybridization` 2%、`Shaking` 3%）、`Ion Radius`（閾値 70 %）、スレッド数 既定 2（1〜16）、`Combine adjacent peaks`（Angle 0.001°、Energy 0.1 eV だが Energy は未使用） |
| 17 | LPO Analysis | FormLPO.cs, FormMain.resx `toolStripButtonLPO.Visible = False` | ボタン非表示・処理本体 (`buttonGetPeakIntensities_Click`) はコメントアウト。実質未実装 |

---

## 3. 実装上の疑問点

1. **DB の格子定数検索で単位不一致**（高）: `SearchCrystalControl.cs` l.126-129 でユーザー入力 `numericBoxCellA.Value` 等（tooltip 上 Å・°）と `angleErr: numericBoxCellAngleErr.Value`（°）をそのまま渡し、l.211-225 で `cry.CellOnlyValue_nm_radian`（nm・rad、CrystalMinimum.cs l.118-126）と比較している。d 値は `/10` で nm 換算しているのに格子定数・角度は未換算。0 以外を入れた条件はほぼ必ず不一致になるはず。
2. **Atomic Position Finder の探索が .NET 10 で動作しない疑い**（高、ただし UI ボタン自体が非表示）: `FormAtomicPositionFinder.cs` `backgroundWorker_DoWork` で `generateCrystal[thread].BeginInvoke(...)`/`EndInvoke` を使用。.NET Core 以降 (TargetFramework `net10.0-windows`, PDIndexer.csproj l.5) ではデリゲートの `BeginInvoke` は `PlatformNotSupportedException`。`backgroundWorker_RunWorkerCompleted` (l.1111) は `e.Error` を見ないため無言で終了する。
3. **Cell Finder で共有 `Random` を並列使用**（中）: `FormCellFinder.cs` `backgroundWorker_DoWork` l.244-249 で `Parallel.For` 内から同一 `Random r` の `r.Next()` を呼ぶ。`System.Random` はスレッドセーフでなく、内部状態破損で 0 が連続し得る（シードの重複→同一試行）。
4. **Cell Finder の `Resume!` が実際は再開しない**（中）: `button1.Click += buttonFind_Click`（FormCellFinder.Designer.cs l.1123）で、`buttonFind_Click` は先頭で `Candidates.Clear()` / 結果表クリアを行う。tooltip「候補をクリアせず継続」(FormCellFinder.resx/ja.resx `button1.ToolTip`) と矛盾。
5. **Cell Finder の指数上限が選択ピークと対応していない疑い**（低〜中）: `FindCellParameter` l.316-338 で指数上限に `condition.DtoSortedD[j]`（j はループ番号）を使用。選んだピーク `targetPeak[j]` の順位ではない。コメント「上限はピークの順番に6を足したもの」と実装 (+3/+4) も不一致。
6. **Cell Finder の trigonal 指数ループのみ `<`**（低）: `GetResidualValue` case 4 (trigonal) は `h < hMax` 等で上限を含まず、hexagonal (case 5) は `<=`。
7. **非中心対称点群で Friedel 対が別の線として列挙される**（中）: `SetPlanes` の等価面判定 `SymmetryStatic.IsRootPlane(..., addInversion=false)`（SymmetryStatic.cs l.876、例: 点群 23 の生成 l.`case 28` は -h-k-l を含まない）。そのため一般反射では (hkl) 族と (−h−k−l) 族が同じ d の 2 本の線になり、多重度も各半分になる。`近接するピークを結合` OFF（既定）では、同じ位置の線の高さが合計の半分で描かれ、特殊反射（例: h00）との相対強度がずれる。
8. **原子の無い結晶で `弱いピークを非表示` を ON にすると線が全部消える**（中）: 原子が無いと `SetPeakIntensity` は即 return（Crystal.cs l.1682）し、`Intensity = -1` のまま（`SetPlanes` l.1123）。描画条件 `閾値×0.01 < Intensity`（FormMain.cs l.1745）が常に偽になる。また `強度比を計算` OFF で線を全高で描く場合でも、非表示判定は計算済み強度で行う。
9. **`Scalable intensity` の CheckedChanged が未配線**（低）: `checkBoxVariableRatioOfIntensity_CheckedChanged`（FormCrystal.cs l.178）は存在するが Designer で `+=` されていない（FormCrystal.Designer.cs l.364-369）。切替直後に再計算・再描画されない。
10. **`全削除` 後に再計算・再描画しない**（低）: `buttonAllClear_Click`（FormCrystal.cs l.145-151）は `InitializeCrystalPlane`/`Draw`/`SetFormFitting`/`SetFormEOS` を呼ばない（`削除` では呼ぶ）。
11. **異方性温度因子の係数**（中、要専門確認）: `Atoms.cs` l.597-602 で `coeff12 = 2π²·a*·b*·cosγ*` など非対角項に cos を掛けている。一般的な β_ij = 2π² a*_i a*_j U_ij（cos は入らない）と異なる。また B 型の異方性 (`OriginalType == Type.B`) は `B11 = Aniso11` と無変換で β として扱う（l.463-473）。一般的には β_ij = ¼ a*_i a*_j B_ij。
12. **未使用の UI/コード**（低）: FormCrystal の `contextMenuStrip1`（`Increment && Decimal Places`）はどのコントロールにも割り当てられておらず、`numericUpDownThreshold_MouseDown` も未配線。FormAtomicPositionFinder の `numericUpDownShaking` 値 (`shakingProb`) は計算に使われない（Shaking は 1−Randomization−Hybridization の残り）。Energy threshold ラジオも無効（l.646-656 コメントアウト）。`buttonSendToAtomicPositionFinder_Click` は空。
13. **併合ピークの強度計算の近似**（低）: 併合後は各成分の |F|² を**平均 d**の s² と LP 因子で計算（Crystal.cs l.1689-1709）。閾値が小さければ実害は小さい。

---

## 4. 要確認事項

1. **LP 因子・強度式の教科書形との違い**（§5 の式参照）:
   - X 線単色: `(1+cos²2θ)/(sin2θ·sinθ)` は Debye–Scherrer の LP `(1+cos²2θ)/(sin²θ·cosθ)` の 1/2 倍で、比を取るので等価。ただし **入射線は無偏光と仮定**（モノクロメータ補正 cos²2θ_M なし、放射光の直線偏光なし）。吸収・選択配向・消衰・表面粗さの補正なし。
   - 電子線・中性子単色: `1/(sin2θ·sinθ)`（偏光項なし）。電子線は白色/単色の区別なし。
   - X 線白色 (エネルギー分散): `|F|²·m·d²/V²`。中性子白色 (TOF): `|F|²·m·d⁴/V²`。入射スペクトル `whiteProfile` 引数は受け取るが未使用（FormMain から `null` を渡す）。
   - X 線の異常分散 (f′, f″) は `SetPeakIntensity` に実装済みだが、FormMain は `xrayEnergyKeV` を渡さないため PDIndexer の表示では無効（Crystal.cs l.1680, l.1494; FormMain.cs l.2033）。
   - これらをマニュアルに記載するか、記載するならどの近似として書くか、作者確認を推奨。
2. 消滅則は格子心と映進・らせんによる一般消滅則のみ（`Symmetry.SetExtinctionFunc`, Symmetry.cs l.140〜）。原子の特殊位置による消滅は除外されず、構造因子 0 の線（強度 0）として残る。`強度比を計算` OFF では全高で描かれる。マニュアルでの説明方針を要確認。
3. 格子定数右クリックで復元メニューが出るかどうか: メニューは CrystalControl 全体の ContextMenuStrip。TextBox 上の右クリックは通常 Windows 標準の編集メニューが出るため、「格子定数の入力欄を右クリック」で実際に出るかは実機確認が必要（コードからは判断できない）。
4. 「2 万件以上」（AMCSD）の件数: `PDIndexer/AMCSD.cdb3` の件数はコードから確認していない。
5. Cell Finder の波長既定値: tooltip は「既定 Cu Kα1、0.15418 nm」と書くが、0.15418 nm は Cu Kα の加重平均値に近く、Kα1 (≈0.15406 nm) とは異なる。`waveLengthControl1` の実既定値は未確認。
6. Cell Finder / Atomic Position Finder の説明は第 6 章（`HelpPage = "6-fitting-diffraction-peaks"`）にあり、第 3 章には無い。Atomic Position Finder と LPO はボタン非表示のため、第 1 章・第 6 章の記載（`docs/src/ja/1-main-window.md` l.36-39、`6-fitting-diffraction-peaks.md` l.126-133）を残すか要確認。
7. EOS タブの詳細は第 5 章の担当と重複するため、第 3 章でどこまで書くか（#1-12 の `3rd Vinet` 追記など）要調整。
8. `Show peak indices` の対象が `only selected crystal` のときでも、0 行目 (Flexible Crystal) 選択時はラベルが一切出ない仕様（§2-3）が意図どおりか。

---

## 5. 補足: 下書き用素材

### 5.1 回折線（反射リスト）の生成 — `Crystal.SetPlanes`（Crystallography/Crystal/Crystal.cs l.975-1135）
- 呼出: `FormMain.InitializeCrystalPlane`（FormMain.cs l.2000-2036）がチェック済み結晶（行 1 以降。0 行目 Flexible Crystal は除く）ごとに
  `SetPlanes(dMax, dMin, excludeEquivalentPlane=true, excludeForbiddenPlane=true, excludeSameDistance=false, combineAdjacentPeak=<チェック>, Angle|EnergyXray, 閾値, 波長|取り出し角)` を呼び、続けて `SetPeakIntensity(WaveSource, WaveColor, WaveLength, null)`。
- d 範囲: 読み込んだプロファイルの横軸全範囲 (`MinimalX`, `MaximalX`) を d に換算。`dMin = max(min, 0.01 nm)`、`dMax < 0` なら 1000 nm。
- 面間隔: 逆格子ベクトル g = h a* + k b* + l c* の長さから **d = 1/|g|**（`A_Star` 等は `SetAxis` で計算）。原点から ±1 ステップで外側へ広げる探索で `1/dMax < |g| < 1/dMin` の (hkl) を最大 8000 個集める。
- 反射の選別: `IsRootPlane`（点群の操作で生成した等価面の代表のみ。反転は付加しない）かつ `Symmetry.HasExtinction(h,k,l) == false`（格子心 A/B/C/I/F/R(六方設定) + 映進・らせんの一般消滅則）。
- 多重度: `Multi = 等価面数`（点群による。Friedel 対は含めない → §3-7）。
- 並び: d の降順にソート（`listPlane.Sort()`）。
- 結合: §1-7 のとおり。

### 5.2 強度計算 — `Crystal.SetPeakIntensity`（Crystal.cs l.1680-1747）と構造因子 `GetStructureFactor`（l.1580-1666）
構造因子（s² = (sinθ/λ)² = 1/(4d²)、単位 nm⁻²）:

$$F(hkl)=\sum_{\text{site}}\sum_{j\in\text{site}} f_{\text{site}}(s)\,T_j\,\exp[-2\pi i(hx_j+ky_j+lz_j)]$$

- 原子散乱因子 `f`（占有率 Occ を掛けた値, Atoms.cs l.351-370）:
  - X 線: **Waasmaier–Kirfel** 係数 `AtomStatic.XrayScatteringWK[Z][sub].Factor(s2) × Occ`
  - 電子線: **Peng** 係数 `AtomStatic.ElectronScatteringPeng[Z][sub].Factor(s2) × Occ`
  - 中性子: 干渉性散乱長 `NeutronCoherentScattering`（同位体存在比 `Isotope` を指定した場合は加重平均）× Occ
- 温度因子: 等方 `T = exp(−B_iso·s²)`（`B_iso = 8π²U` は `DiffuseScatteringFactor.Biso`, Atoms.cs l.448）。異方性 `T = exp(−(β11H²+β22K²+β33L²+2β12HK+2β23KL+2β31LH))`、(H,K,L) は各等価原子の対称操作で変換した指数（`atom.Operation.ConvertPlaneIndex`）。係数は §3-11 参照。NaN の場合 T=1。
- 位相の符号規約 exp(−2πi g·r)（Crystal.cs l.1471-1485）。

1 本の線（併合された場合は成分 j ごと）の強度 `eachIntensity[j]`（V = 単位胞体積、m = 多重度、θ はその線の d と波長 λ から `sinθ = λ/(2d)`）:

| 線源 (WaveSource) | 単色/白色 (WaveColor) | 実装式 |
|---|---|---|
| Xray | Monochrome | \( I = \dfrac{|F|^2 m}{V^2}\cdot\dfrac{1+\cos^2 2\theta}{\sin 2\theta\,\sin\theta} \) |
| Xray | FlatWhite | \( I = \dfrac{|F|^2 m}{V^2}\, d^2 \) |
| Electron | （区別なし） | \( I = \dfrac{|F|^2 m}{V^2}\cdot\dfrac{1}{\sin 2\theta\,\sin\theta} \) |
| Neutron | Monochrome | \( I = \dfrac{|F|^2 m}{V^2}\cdot\dfrac{1}{\sin 2\theta\,\sin\theta} \) |
| Neutron | それ以外（白色/TOF） | \( I = \dfrac{|F|^2 m}{V^2}\, d^4 \) |

- `RawIntensity = Σ_j eachIntensity[j]`、`Intensity = RawIntensity / max(RawIntensity)`（生成した全反射内の最大で規格化、0〜1）。
- X 線単色の LP は無偏光入射の Lorentz–polarization 因子（教科書形 \((1+\cos^2 2\theta)/(\sin^2\theta\cos\theta)\) と定数倍 2 の違いのみ）。偏光・モノクロメータ・吸収補正なし（§4-1）。

### 5.3 線の高さの描画 — `FormMain.DrawProfile_diffraction`（FormMain.cs l.1706-1812）
- 横位置: `XCalc = HorizontalAxisConverter.ConvertFromD(d, 横軸設定)`。表示範囲外は描かない。
- 下端 `zero` = 描画域下端（`回折線を下に表示` ON なら チェック結晶数×(高さ+4) px だけ上）。
- 上端 `top`:
  - Flexible Crystal: 縦軸上限 `UpperY` まで。
  - `強度比を計算` ON かつ強度 ≥ 0: `強度を変更可` OFF → `top = (1 − Intensity)·zero`（**最強線が描画域の最上端 (y=0 px) に届く画素比例**。縦軸目盛とは無関係）。ON → データ座標で `Intensity × DiffractionPeakIntensity`（初期値は `UpperY`、縦ドラッグで変更、ズーム時は OFF なら `UpperY` に再設定 l.2311-2312, l.2348-2349）。
  - それ以外（計算 OFF・原子なし）: `UpperY` まで（全高）。
- 下部帯: n 番目のチェック結晶ごとに `(高さ+4)` px 幅の帯に短い縦線を描く（強度・弱ピーク判定に依存しない）。

### 5.4 Cell Finder アルゴリズム — `FormCellFinder.cs`
- 入力 d (Å→nm)、信頼度重み High=1 / Medium=0.5 / Low=0.1、各ピークの統計重み `1/(2θ)²`（2θ は入力波長で換算、rad）。全重み和 `TotalWeight = Σ(1/(2θ)²)`（`FindCondition` コンストラクタ l.51-64）。
- 未知数: triclinic 6, monoclinic 4, orthorhombic 3, tetragonal/trigonal/hexagonal 2, cubic 1（l.186-194）。
- 1 試行（`FindCellParameter` l.282-385）: (1) 未知数と同数のピークを（d の大きい側に偏った）乱数で選ぶ、(2) 各ピークに乱数の指数を与える、(3) 逆格子計量（例: triclinic は h²,k²,l²,kl,lh,hk の 6 係数、hexagonal/trigonal は 4/3(h²+k²+hk), l²）への**重み付き線形最小二乗**で格子定数を解く（`RefineCellParameter`, `C = (QᵀWQ)⁻¹QᵀWA`, A=1/d²）、(4) orthorhombic は a≥b≥c に並べ替え、monoclinic は β≥90° で最小の β の格子に変換し a≥c、(5) 制約範囲外は棄却。
- 評価（`GetResidualValue` l.387-532）: 候補格子で h,k,l ≤ min(軸長/(0.9·d_min), 30) の全 d を計算・重複除去し、各観測 d に最も近い計算 d を割り当て。いずれかの |Δd|² > 0.0004 nm²（|Δd| > 0.2 Å）なら棄却。割当の重複は乱数で隣へずらして解消（最大 20 回）。全観測 d で再精密化し、
  \( R = \sqrt{\Sigma w\,(1/d_{obs}^2 - 1/d_{calc}^2)^2 / \text{TotalWeight}} \times N_{calc}/N_{obs} \)
  （`SigmaDQ` = 重み付き残差二乗和、N_calc = 範囲内の計算反射数）。R < 1000 を保持。
- ループ: 32 並列 × 10000 試行を繰り返し、R 昇順に並べて重複除去、上位 300 件を表示。行クリックでピーク表に hkl・d_calc・diff を表示。分布図は R で色付け。

### 5.5 Atomic Position Finder アルゴリズム — `FormAtomicPositionFinder.cs`（参考。UI 非表示）
- 入力: 格子定数、候補空間群（複数選択可）、化学組成（周期表で単位胞あたり原子数）、各元素のイオン半径、観測ピーク (d, 相対強度)。
- `getFindingCondition` (l.589-768): 各空間群で `SetPlanes(∞, d_min×0.8, …, combine=true, Angle, 閾値)` → 各観測ピークに最近接の反射を対応づけ、本数が一致しない空間群を除外 → `GenerateWyckoff` で原子数を満たす Wyckoff 位置の組合せを列挙し、テンプレート結晶を作る。
- 探索（`backgroundWorker_DoWork` l.849-990）: 遺伝的アルゴリズム風。確率 Randomization で Wyckoff を保ったまま原子座標を乱数化、Hybridization で 2 候補の元素ごとの原子を交叉、残りで Shaking（1 原子を ±最大 0.3 程度ずらす）。原子間距離が (イオン半径和 × 閾値%) 未満なら棄却（`checkAtomicPosition`）。強度は **X 線・単色固定**の `SetPeakIntensity`。
- 残差: 最適スケール \(A=\Sigma I_o I_c/\Sigma I_c^2\) として \( R = 1000\cdot\frac{1}{N}\Sigma (A I_c - I_o)^2 \)（`GetResidualValue` l.1118-1130）。上位 1000 件を保持。

### 5.6 予約結晶（既定 `default.xml`）
| 行 | 名前 | 用途 |
|---|---|---|
| 0 | Flexible Crystal | `FlexibleMode = true`（FormMain.cs l.3729）。d を直接ドラッグ移動可 |
| 1〜10 | Au, Pt, NaCl (B1-type), NaCl (B2-type), MgO (periclase), Al2O3 (cor.), Ar, Re, Mo, Pb | 圧力計 (FormEOS)。`SetFormEOS` が行番号 1〜10 で参照（FormMain.cs l.2803-2840） |
| 11〜 | Si, Be, C (Graphite), … | 一般結晶（予約なし） |
