<!-- 261105Cl: docs/drafts/261105-cloud — 既存マニュアルとコードの突き合わせ結果 (監査)。docs/src には未統合。 -->
# 第6章 ピークフィッティング / 第7章 連続分析 / 第8章 マクロ — マニュアル監査

> 本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象マニュアル: `docs/src/ja/6-fitting-diffraction-peaks.md`, `7-sequential-analysis.md`, `8-macro.md`（および同名の `en/`）
対象コード: `PDIndexer/FormFitting.cs` (+ `.Designer.cs`, `.resx`, `.ja.resx`)、`PDIndexer/FormSequentialAnalysis.cs` (+ 同)、`PDIndexer/Macro.cs`、`PDIndexer/FormMain.cs`（マクロ用公開 API 491–527 行）、`Crystallography.Controls/Macro/{Macro.cs,FormMacro.cs,FormMacro*.resx}`
ja/en マニュアルは 3 章とも見出し・表の構成が一致している（行数も同じ）。以下で特記しない限り、食い違いは ja/en 共通。

---

## 1. 食い違い（マニュアル記述 vs コード）

### 第6章 ピークフィッティング

| # | マニュアル箇所 | マニュアルの記述 | コードの実際 | 深刻度 |
|---|---|---|---|---|
| 6-1 | 6章「結晶リスト」L21 の画像 `FormFitting.groupBox1.png` | 結晶リストのキャプチャとして掲載 | `groupBox1` は **Optimized cell constants（最適化した格子定数）** パネル（FormFitting.resx `groupBox1.Text`='Optimized cell constants'、ja='最適化した格子定数'）。画像の中身も格子定数パネル。結晶リスト（`dataGridViewCrystals`）は groupBox ではなくキャプチャが存在しない | 中 |
| 6-2 | 6章「回折線リスト」L27 の画像 `FormFitting.groupBox5.png` | 回折線リストのキャプチャ | `groupBox5` は **Send d-values** グループ（resx `groupBox5.Text`='Send d-values'）。画像も Send d-values ボタンのみ | 中 |
| 6-3 | 6章「Optimized cell constants」L101 の画像 `FormFitting.groupBox4.png` | 最適化した格子定数パネル | `groupBox4` は **Remove peaks**（resx `groupBox4.Text`='Remove peaks'）。正しい画像は `groupBox1.png` | 中 |
| 6-4 | 6章「Search Range / Initial FWHM」L60 の画像 `FormFitting.groupBox3.groupBox2.png` | Search Range と Initial FWHM | `groupBox2` は **Peak function（ピーク関数）** のラジオボタン群（resx `groupBox2.Text`='Peak function'/ja 'ピーク関数'）。Search Range/Initial FWHM は groupBox3 直下（FormFitting.Designer.cs 496–505 行） | 中 |
| 6-5 | 6章「回折線リスト」L31–44 の列表 | 回折線リストに `Check`/`PeakColor`/`Crystal`/HKL/…/R の列がある | `Check`・`PeakColor`・`Crystal` は **結晶リスト**（`dataGridViewCrystals`）の列（Designer.cs 674 行）。回折線リスト `dataGridViewPlaneList` の列は 見出しなしチェック列, `HKL`, `Calc X`, `Func`, `X`, `X Err`, `FWHM`, `Intensity`, `Weight`, `R`（Designer.cs 738 行、resx HeaderText） | 中 |
| 6-6 | 6章 L48 `Copy to clipborad` | リスト下部のボタン。表の内容をクリップボードへ | `Copy to clipborad`（綴りもこのまま）は回折線リストの**右クリックメニュー項目** `copyToClipboradToolStripMenuItem` で、**選択中の 1 行のみ**コピー（FormFitting.cs `copyToClipboradToolStripMenuItem_Click` L138, `generateTableText(bindingSourcePlanes.Position)`）。表全体をコピーするボタンは `buttonCopyTableToClipboard`：英 `Copy to Clipboard` / 日 `クリップボードにコピー`（L150 `buttonCopyToClipboard_Click`） | 中 |
| 6-7 | 6章 L49 `Save as CSV` … `Effective digit`（小数点以下桁数）で有効桁数を指定 | Effective digit が CSV の桁数を決める（en: "number of decimal places"） | `numericBoxEffectiveDigit` は**グリッド表示書式のみ**変更（`DefaultCellStyle.Format = "g{n}"` = 有効数字。L1379 `NumericBoxEffectiveDigit_ValueChanged`）。CSV/クリップボード出力は `generateTableText` が生の double をそのまま書く（L132）ので影響しない。既定 5、範囲 1–16（Designer.cs 927–933）。ja UI ラベル '小数点以下桁数' 自体も g 書式（有効数字）と不一致 | 中 |
| 6-8 | 6章 L50 `Clear peaks` | フィッティング結果をクリア | `buttonClearPeaks` は**flexible モードの結晶のときだけ表示**（resx `buttonClearPeaks.Visible`=False、`ChangeCrystalFromMainForm` L95/`FormFitting_VisibleChanged` で `TargetCrystal.FlexibleMode` に応じ表示）。動作は `TargetCrystal.Plane.Clear()` で**ピーク（面）自体を全削除**（L1486–1494） | 中 |
| 6-9 | 6章 L62–65 Search Range / Initial FWHM / Apply to all | `Apply to all` 1 個で現在の設定を一括適用 | `Apply to all`（ja '全てのピークに適用'）ボタンは **3 個**あり別々に動作：範囲用 `buttonApplyRangeToAll`（L1315, SerchRange のみ）、初期半値幅用 `buttonApplyFWHMToAll`（L1322）、ピーク関数用 `buttonApplyFunctionToAll`（L1329）。また `Initial FWHM` はチェックボックス（`checkBoxUseInitialFWHM`、既定 OFF・`panelFWHM.Enabled`=False）。OFF 時は範囲変更時に初期 FWHM = Search Range/2 が自動設定（L1304–1307） | 中 |
| 6-10 | 6章 L94–97 Pattern Decomposition の `in each crystal` / `between crystals` | 結晶ごと／全結晶にまたがってピーク分解 | ラジオボタンの状態は `Fitting()` のどこでも参照されない。`radioButtonEachCrystal_CheckedChanged` は単に `Fitting()` を呼ぶだけ（L1353）。分解は常に「チェックされた全結晶」の対象ピークを X±range の重なりでグループ化（L281–301）→ 実質常に between crystals 相当（実装上の疑問点 Q1） | 高 |
| 6-11 | 6章 L110 `Reset take off angle` | テイクオフ角をリセットするボタン | `buttonResetTakeoffAngle.Visible`=False（FormFitting.resx L166）で、コード中で Visible にする箇所なし → UI に出ない。ハンドラも EnergyXray モード時に `horizontalAxisUserControl_AxisPropertyChanged()` を呼ぶだけ（L1382–1390, 取得した `dp` は未使用） | 中 |
| 6-12 | 6章 L73 Simple Search | 計算位置 ±Search Range の範囲で最大強度点 | Simple は `FitPeakAsSimple(p.XCalc, p.SerchRange, ptArray)`（L267）で、**画面値 = SerchRange×SerchRangeFactor ではなく内部値 SerchRange** を使う。他の関数は `range = p.SerchRange * SerchRangeFactor`（L249）。SerchRangeFactor ≠ 1 の軸設定では表示値と実際の探索幅が異なる（Q2） | 中 |
| 6-13 | 6章 L103–106 / NA 注記 | 自由度不足で `NA` | 概ね一致（誤差初期値 −1 → `SetTextBox` で `>-1` でなければ "NA"、L1241–1262；誤差計算は `p.Count - パラメータ数 > 0` のときのみ）。ただし最小二乗が解けない場合（a==0）は**格子定数を一律スケールした値**を表示する（L1038–1047, 2020/10/16 追加）ことが未記載 → 2 節 | 低 |
| 6-14 | 6章 L108 `Apply to the crystal` | 格子定数を結晶へ反映 | 反映に加え、**最適化格子定数をクリップボードへもコピー**する（`buttonConfirm_Click` → `Confirm(true)` → `CopyClipboard()`、L1056–1080）。反映後 `formMain.ChangeCrystalFromFitting()` → `SetFormEOS()` で EOS ウィンドウにも伝播（FormMain.cs L2640–2648） | 低 |
| 6-15 | 6章 L118 Send d-values | 「フィッティングで得られた d 値」を送る | 送るのは `TargetCrystal.Plane[i].d * 10`（L1436）= **計算 d 値**（観測値は `dObs`）。条件式も `IsFittingChecked && Simple || observedIntensity > 0` で、未チェック面でも observedIntensity>0 なら送られる（Q3） | 中 |
| 6-16 | 6章（ja）L114 `New profile name`（新しいプロファイル名）、`Remove fitted peaks`（ピーク除去）、L110 `Reset take off angle` 等 | 日本語ラベルを括弧で併記 | FormFitting.ja.resx に `label4`/`buttonRemovePeaks`/`groupBox4`/`buttonSendToCellFinder`/`buttonClearPeaks`/`buttonResetTakeoffAngle` の訳は**ない**（日本語 UI でも英語表示）。括弧内の日本語は実 UI ラベルではない | 低 |
| 6-17 | 6章 L4「メインウィンドウのツールバーから起動」 | ツール名 `Fitting diffraction peaks` | ツールバーボタン：英 `Fitting Diffraction\n Peaks (F)` / 日 `ピーク\nフィッティング (F)`（FormMain.resx L3438, FormMain.ja.resx L420）。ショートカット Ctrl+Shift+F（FormMain.cs L4777）。ウィンドウタイトルは `$this.Text`='FormFitting' のまま（ja なし） | 低 |

### 第7章 連続分析

| # | マニュアル箇所 | マニュアルの記述 | コードの実際 | 深刻度 |
|---|---|---|---|---|
| 7-1 | 7章「結果の取り出し」L95 `コピー` | タブ内容を **CSV（カンマ区切り）** でクリップボードへ | `buttonCopy_Click` → `GetText(false)` で **タブ区切り**のまま（FormSequentialAnalysis.cs L534–537）。ToolTip も "tab-separated"/"タブ区切り"。CSV 変換は `保存` と自動保存・マクロ GetCSV のみ | 中 |
| 7-2 | 7章 L74「圧力」 | `Equation of State` ウィンドウで Gold…Pb の圧力標準が**選択されている場合**に研究者ごとの列 | 判定は **メイン結晶リストで選択中の結晶の位置** `formMain.bindingSourceCrystal.Position` が 1–10（Au, Pt, NaCl B1, NaCl B2, MgO, Corundum, Ar, Re, Mo, Pb の固定スロット）かどうか（L94–107）。EOS ウィンドウでの選択ではない。該当時は EOS ウィンドウを自動で開く（`toolStripButtonEquationOfState.Checked = true`, L118）。それ以外は `crystal.EOSCondition.GetPressure(V)`（L237） | 中 |
| 7-3 | 7章 L11 note「準備されていない状態で実行するとメッセージ」 | 結晶・ピーク未準備でもメッセージ | メッセージ（`PdiText.OpenFittingForm`）は **Fitting ウィンドウが非表示のときのみ**（L47–51）。プロファイル数 < 4 のときは**無言で return**（L52–53）。ピーク未チェックは検査せず、そのまま空列で実行 | 低 |
| 7-4 | 7章 L83 Singh の適用条件 | プロファイル名が `...-whole` で終わる | 判定は **先頭プロファイル（Rows[0]）の名前**が `"whole"` で終わるか（`EndsWith("whole")`, L58）。応力モードでは先頭プロファイル（index 0）を解析対象から除外（L128–129）、各行ラベルは名前の最後の `-` 以降（L186–192）、1列目見出しは "Degree"（L72, L92） | 低 |
| 7-5 | 7章 L21 進行表示 | `... % completed. Elapsed time: ... sec` | 文言一致。ただし % は `100.0 * i / total`（i はプロファイル番号, L256）なので、開始番号／ループ使用時は単調増加しない。完了時は `100 % Completed!  Elapsed time: …`（L295） | 低 |
| 7-6 | 7章 L18「読み込まれている各プロファイルを順番に」 | （正しい）| 一致。補足：実行中は全プロファイルのチェックを一旦外し対象 1 本だけチェック→終了後に元のチェック状態を復元（L133–137, L254, L260–261）。メインウィンドウは無効化（L139/L264） | — |
| 7-7 | 7章 L32 開始番号「最初はゼロ」 | 0 から指定可能と読める | `numericBoxStartNumber.Minimum = 1`、既定値 1（Designer.cs L338/344）。0 を指定したい場合はチェックを外す（ToolTip も「整数、最小 1」） | 低 |
| 7-8 | 7章（ja）全体と 8章（ja） | 7章は「連続分析」、8章は「逐次解析」 | 用語不統一。UI：ツールバー ja '連続分析'（FormMain.ja.resx L425）、ツールバー ToolTip ja '連続解析ウィンドウ…'（L612）、ウィンドウタイトル `$this.Text`='Sequential Analysis'（ja.resx に訳なし）。マクロ Help は英語のみ | 低 |

### 第8章 マクロ

| # | マニュアル箇所 | マニュアルの記述 | コードの実際 | 深刻度 |
|---|---|---|---|---|
| 8-1 | 8章 PDI.Sequential 表 L214 `Execute` | 「チェックされた全プロファイルに対して」 | `[Help("Run the sequential analysis on all checked profiles.")]`（Macro.cs `SequentialClass.Execute`）と同文だが、実装 `FormSequentialAnalysis.buttonExecute_Click` は**チェック状態に関係なく全プロファイル（開始番号以降＋ループ）**を処理（L121–129, チェックは一旦全解除 L137）。Help 属性・マニュアルとも誤り | 高 |
| 8-2 | 8章「マクロの例」L234–245 および 組み込みサンプル 09（Macro.cs `_sampleMacros` 09） | `CheckAll` → `Sequential.Open` → `Execute` → GetCSV で保存 | Fitting ウィンドウを開いていないと `Execute` は MessageBox を出して即 return（FormSequentialAnalysis.cs L47–51）。例には `PDI.Fitting.Open()` やピークのチェック手順がなく、そのままでは結果が空。`CheckAll()` は 8-1 のとおり無意味。プロファイル 4 本未満でも何も起きない | 中 |
| 8-3 | 8章 PDI.Fitting 表 L198 `Apply` | 「フィッティングウィンドウの `Confirm` ボタンと同等」 | 現 UI のボタンは英 `Apply to the crystal` / 日 `選択中の結晶に適用`（FormFitting.resx `buttonConfirm.Text`）。`Confirm` はコントロール名・旧ラベル。Help 属性（Macro.cs `FittingClass.Apply`）とサンプル 08 のコメントも 'Confirm'。また `main.ConfirmFitting(true)` → `Confirm(true)` で**クリップボードにもコピー**される（未記載） | 低 |
| 8-4 | 8章 サンプル一覧 L71 「08. フィッティング操作」/ サンプル 08 コメント "run fitting" | フィッティングを実行 | フィッティング実行 API はない。`Range()` → `FittingSearchRange` → `numericBoxSearchRange.Value` の ValueChanged 経由で間接的に `Fitting()` が走る（FormMain.cs L498–502, FormFitting.cs L1298–1313）。値が変わらなければ再計算されない | 低 |
| 8-5 | 8章 PDI.Fitting 表 L199 `Check` | 格子面のチェック状態を変更 | `SetFittingPlaneChecked`（FormMain.cs L504–510）は `Plane.IsFittingChecked` と表の Row[0] を更新し `dataGridViewPlaneList_SelectionChanged` を呼ぶのみで **`Fitting()` を呼ばない**。UI クリック（`dataGridViewPlanes_CellContentClick` L1182–1199）は `Fitting()` を呼ぶので挙動差がある（要確認 R3） | 中 |
| 8-6 | 8章 L84「web マニュアルの 6 章」 | 同じ一覧が web 6 章にもある | 本リポジトリ内では確認不能（要確認 R5） | 低 |

**Macro API 照合結果（Macro.cs の public メンバー + [Help] vs 8-macro.md の表）**
`PDI`(Sleep, Obj) / `File`(9) / `Drawing`(9) / `Crystal`(10) / `CrystalList`(9) / `Profile`(2) / `ProfileOperator`(5) / `ProfileList`(12) / `Fitting`(8) / `Sequential`(18) — **全メンバーが過不足なく一致**し、シグネチャ欄も `[Help]` の第2引数と一致、説明文も Help の和訳として妥当（ver4.461 のリファクタ後の状態に既に追随済み）。食い違いは上表 8-1・8-3 の Help 文言そのものの誤り／旧称のみ。
細部：マニュアルは `ReadProfiles(string filename)` 等を既定値なしで表記しているが実装は `= ""` の既定引数あり（Macro.cs FileClass）。説明文で「省略すると…」と書いているので実害なし。エディタ内の関数表は `GenerateHelpText` がプロパティ→メソッドの順に列挙するため、マニュアルの表の並びとは一致しない（Crystallography.Controls/Macro/Macro.cs `HelpAttribute.GenerateHelpText`）。

**マクロエディタ部分**：ボタン英ラベル `Add`/`Replace`/`Delete`/`↑`/`↓`/`Show samples`/`Run macro`/`Step by step`/`Next step (F10)`/`Stop`（FormMacro.resx）、ja は `checkBoxSamples` のみ 'Samples'（FormMacro.ja.resx）で他は英語のまま — ja マニュアルの `Samples`、en の `Show samples` とも正しい。メニュー `Macro`→`Editor`／`マクロ`→`編集`（FormMain.resx L3854/3860, ja L496/499）一致。`import math` 事前実行（FormMacro.cs L85–86）、`.mcr` D&D（L458–470）、Ctrl+S は名前欄が選択マクロ名と一致するときのみ上書き（L764–770）、F10（L773）、Stop はステップ実行中のみ表示・有効（L278–308）— いずれも記述と一致。

---

## 2. マニュアル未記載の機能・設定

| # | 機能/コントロール (UI 英/日) | 実装箇所 | 概要（既定値・単位を含む） |
|---|---|---|---|
| A1 | Initial FWHM チェック（`Initial FWHM` / `初期半値幅`） | FormFitting.cs `checkBoxUseInitialFWHM_CheckedChanged` L1355, `numericUpDownSearchRange_ValueChanged` L1298–1313 | 既定 OFF。OFF のとき範囲を変えると初期 FWHM = Search Range/2。ON のとき右の数値（`numericBoxInitialFWHM`）を使用 |
| A2 | 面ごとの設定の保持 | `dataGridViewPlaneList_SelectionChanged` L1203–1232；Crystallography/Crystal/Plane.cs L10–13；Crystal.cs L1110–1129 | Search Range・初期 FWHM・ピーク関数は**選択中の面ごと**に保持され、行選択で表示が切り替わる。新規面の既定：内部 SerchRange=0.10, FWHM=0.10, 関数=Symmetric Pseudo Voigt。画面値 = 内部値 × SerchRangeFactor |
| A3 | SerchRangeFactor（横軸単位による換算） | `ChangeHorizontalAxis` L1394–1420 | d=1.00 nm と 1.06 nm の X 値差 ×8 を 1 桁に丸めた係数。表示桁数もこれに応じて変化。field コメント「Angle:1, Energy:500, d:0.2」は旧仕様。単位ラベル `label1`/`label18` は 'unit' 固定文字列（実単位を表示しない） |
| A4 | 重み（Weight 列） | `Fitting()` L336–343 | 角度モード：1/sin²θ（2θ=XObs）。それ以外の横軸モード：1 |
| A5 | Intensity 列の定義 | L331 | 積分値 `GetIntegral()` をプロファイルのステップ幅（Pt[1].X−Pt[0].X）で割った値。Simple 関数では 0 のまま |
| A6 | R 列 / CSV の `Rwp (%)` | DataSet.cs `Add/Replace`（r.R = Residual）、FormFitting.cs L132 | グリッドの R は `peakFunction.Residual`（比）、コピー/CSV では ×100 して見出し `Rwp (%)` |
| A7 | 表のコピー/CSV の書式 | `generateTableText` L108–134, `ButtonSaveTableAsCSV_Click` L161–170 | 見出し `Checked, hkl, Calculated X, Function, Observed X, Observed X err (1sigma), Observed FWHM, Observed Intensity, Rwp (%)`。全面（未チェック含む）出力。関数名略号 Simple/Sym PV/Sym Pea/Spl PV/Spl Pea |
| A8 | CSV のドラッグ&ドロップ読込 | `FormFitting_DragDrop` L180–222（`AllowDrop = true` Designer L956） | `Checked,hkl` で始まる CSV（上記 Save as CSV 形式）をウィンドウへドロップすると、行順に各面のチェック状態とピーク関数を復元（表の値も上書き） |
| A9 | 右クリック `Copy to clipborad`（綴りママ） | L138–143, Designer L739/853 | 選択中 1 行のみ（見出し付き）コピー |
| A10 | Ctrl+Alt+Space で選択面のチェック切替 | FormMain.cs `FormMain_KeyDown` L4798–4802（ver4.322） | Fitting ウィンドウ表示中のみ。表の Row[0] を反転（Fitting() 呼出しの有無は要確認 R3） |
| A11 | 格子定数の解けないときのフォールバック | `FittingDiffraction` L1038–1047 | 最小二乗が解けない（a==0）とき、Σ(w·d·dObs)/Σ(w·d²) を係数として現在の格子定数を等方スケールした値を表示（誤差は NA）。`Apply to the crystal`/コピーは `temp_crystal.A > 0` で有効化（L1264–1269）されるのでこの値も適用可能 |
| A12 | 最適化格子定数の表示書式とコピー形式 | `SetTextBox` L1241–1262, `CopyClipboard` L1088–1105 | a,b,c: Å 小数6桁、α,β,γ: ° 小数5桁、V: Å³ 小数6桁。コピーは見出しなし 1 行タブ区切り「a, a_err, b, b_err, c, c_err, α, α_err, β, β_err, γ, γ_err, V, V_err」（a が "0.000000" の時は何もしない） |
| A13 | 格子定数精密化の対象 | `FittingDiffraction` L371–373 | 対象結晶の「チェックされ、かつ (Simple または observedIntensity>0)」の面のみ。晶系別に 1/d² の重み付き線形最小二乗（cubic/tetragonal/hexagonal/trigonal(六方設定)/orthorhombic/monoclinic(a,b,c 主軸)/triclinic は `CrystalGeometry.GetErrorTriclinic`）。ピークフィット自体は**チェックされた全結晶**の面に対して行う（L236–262） |
| A14 | FormEOS との連動 | `Confirm` L1058–1080 → FormMain.cs `ChangeCrystalFromFitting` L2640 → `SetFormEOS` L2795– | `Apply to the crystal` 後、EOS ウィンドウが開いていれば、結晶リスト 1–10 番の圧力標準（チェックされたもの）の格子定数が EOS ウィンドウへ転記され圧力が更新される |
| A15 | Remove peaks の仕様 | `buttonRemovePeaks_Click` L1446–1478; FormProfileSetting.cs L446 | 対象結晶のチェック済み・Simple 以外の面について、XCalc±range 内だけピーク関数値を差し引く。出力名の既定値は「選択プロファイル名 + `_new`」。新プロファイルはランダム色で追加 |
| A16 | 数値コア呼び出し箇所（他担当向けメモ） | FormFitting.cs L267, L278–280, L298–301 | `FittingPeak.FitPeakAsSimple`（Crystallography/PeakSearch.cs L379）、`FittingPeak.FitPeakThread`（L394, BackgroundFitting=true, RemoveBadSN=0, 面ごと Parallel.ForEach）、`FittingPeak.FitMultiPeaksThread`（L408, パターン分解時グループごと Parallel.For）、`PeakFunction.GetIntegral()`、`HorizontalAxisConverter.ConvertFromD/ConvertToD`、`CrystalGeometry.GetErrorTriclinic` |
| B1 | 連続分析：格子定数の引き継ぎ | FormSequentialAnalysis.cs L151–177, L286–291 | 各プロファイルで 2 回フィット、各回で（許容範囲内なら）`Confirm(false)` により格子定数を結晶へ反映 → 次プロファイルの初期値になる。終了後、結晶の格子定数は開始時の値に戻される |
| B2 | 連続分析：flexible 結晶 | L157–164, L277–284 | flexible 結晶では格子定数精密化をせず、各面の XCalc を XObs に追従させて次へ。終了時に元の XCalc に戻す |
| B3 | 連続分析：オプション既定値 | Designer.cs L321–367, resx `checkBoxLoop.Enabled`=False | 開始番号 OFF・値 1（最小 1）；ループ ON（ただし開始番号 OFF の間は無効）；許容係数 OFF・値 10（%、0–100）。許容判定は「最適化体積 / 開始時体積」が 1±0.01×値 の外なら NaN |
| B4 | 連続分析：各タブの書式 | L207–237 | 2θ: f10、d: f10（Å, λ×10/(2 sinθ)）、FWHM: f8（`peakFunction.Hk`）、Intensity: g10（`GetIntegral()` 生値）、格子定数 V f8 / a–c f10 / 角度 g10。1列目見出し "Profile Name | Index"（応力モード "Degree | Index"） |
| B5 | 連続分析：終了時クリップボード | L267–272 | 見出し行 `2theta`/`d-spacing`/`FWHM`/`Intensity` 付きで 4 表をタブ区切りで連結（マニュアル L21 の記述と一致） |
| B6 | Singh の出力書式・グラフ | `RefineSinghEquation` L370–486 | 各反射 1 行 `hkl\td0:\t<Å>\tΨmax:\t<deg>\t t/6Ghkl:\t<α>`。初期値 α=−0.5、ψmax と d0 はデータ前半の最小/最大 d から。LM 風反復（最大 300 回、λ 初期 1、×0.2/×5）。グラフは ψ=0–359° の d(ψ)（Å） |
| B7 | 連続分析：自動保存ファイル名 | `AutoSave` L300–357 | 全プロファイル名（空白除去）の共通接頭辞から末尾 1 文字を落とし、さらに末尾が `-` か `#` ならもう 1 文字落とす |
| B8 | ショートカット Ctrl+Shift+S | FormMain.cs L4791–4792 | 連続分析ウィンドウの表示切替（ツールバーボタンの状態は更新しない） |
| B9 | 改版履歴 | Version.cs L57 | ver4.418 で 'Stress Analysis' から 'Sequential Analysis' に改称・改良（マニュアル未記載） |

---

## 3. 実装上の疑問点

- **Q1 パターン分解の `in each crystal` / `between crystals` が無効**：`radioButtonEachCrystal`/`radioButtonBetweenCrystals` の Checked はどこからも参照されない（FormFitting.cs 全体 grep、L1353 は `Fitting()` 呼出しのみ）。L284–301 は常に全チェック結晶のピークを混ぜてグルーピング。
- **Q2 Simple Search の探索幅に SerchRangeFactor が掛かっていない**：L267 `FitPeakAsSimple(p.XCalc, p.SerchRange, …)` に対し、他関数は L249 `range = p.SerchRange * SerchRangeFactor`、Remove peaks も L1458–1459 で ×Factor。
- **Q3 Send d-values が計算 d を送る／条件の演算子優先順位**：L1434 `IsFittingChecked && SerchOption == Simple || observedIntensity > 0`（`&&` が先に評価）、L1436/1437 `Plane[i].d * 10`（観測値は `dObs`）。
- **Q4 体積誤差 V_err の誤差伝播式が次元的に不正**：cubic `V_err = Math.Sqrt(3) * a * a_err`（L432。V=a³ なら 3a²σa）、tetragonal/hexagonal/trigonal `Math.Sqrt(2*a*c*a_err*a_err + a*a*c_err*c_err)`（L475/519/564。正しくは √((2acσa)²+(a²σc)²)）、orthorhombic `Math.Sqrt(b*c*a_err*a_err + …)`（L611）、monoclinic の V_err も同型。表示の V の ± 値、連続分析の `V_err` 列に影響。
- **Q5 単斜晶の a/b/c 誤差式**：`1 / Math.Sin(alfa) * Math.Sin(alfa) / C³ …`（L669/674/725/732/782/787）は演算子優先で sin が相殺され 1 になる。さらに主軸 b, c のケース（L725–735, L782–790）は β/γ ではなく `alfa`（=π/2 に設定済み）を使用しており `Math.Tan(alfa)` が発散 → 第2項がほぼ 0。また `1/4` 係数がない（他晶系の a_err 式と不整合）。
- **Q6 連続分析の応力モードで角度パース失敗時に `return`**：FormSequentialAnalysis.cs L189–190。この時点で `formMain.Enabled = false`（L139）、`formFitting.SkipFitting = true`、プロファイルのチェック状態は全解除のまま、結晶格子定数も未復元 → メインウィンドウが操作不能のまま残る。
- **Q7 許容係数で棄却した行の圧力列**：L251 は `\tNaN` を 1 個だけ出力。EOS 標準（研究者列が複数）選択時は列数がヘッダと合わない。
- **Q8 圧力 EOS の判定に別の結晶参照**：L94 は `formMain.bindingSourceCrystal.Position`（メイン側の選択）、解析対象は `formFitting.TargetCrystal`（FormFitting 側 `bindingSourceCrystals.Current`）。両者が常に同期しているかは未確認（R4）。
- **Q9 2θ/d タブは横軸が角度であることを前提**：2θ 列は `peakFunction.X`（現在の横軸単位のまま）、d は `WaveLength*10/2/sin(X/2)`（L207–208）。エネルギー分散・TOF・d 軸モードでは見出し「2θ (°)」「d (Å)」と値が一致しない。
- **Q10 Intensity の定義が FormFitting と連続分析で異なる**：FormFitting は `GetIntegral()/ステップ幅`（L331）、連続分析は `GetIntegral()` 生値（FormSequentialAnalysis.cs L209）。
- **Q11 AutoSave のファイル名処理**：共通接頭辞ループがbreakせず終わった場合も末尾 1 文字を削る（L330）。プロファイル名が空の行があると `minLength = 0` → `name[..^1]` で例外（L323–330）。共通接頭辞が無いと `_2theta.csv` のような名前になる。
- **Q12 `generateTableText` で XObs が NaN の行は改行が付かない**（L131–132、`if (!double.IsNaN(p.XObs))` の else 側に `\r\n` なし）。XObs の既定値は 0（Plane.cs L38）なので通常は顕在化しないが、Simple の結果等で NaN になれば次行と連結される。
- **Q13 UI 文言**：FormMacro.resx `label2.Text`='Use basic Python syntax and the built-in functions provided by **ReciPro**'（PDIndexer でもそのまま表示）。FormFitting のウィンドウタイトルが 'FormFitting'（resx `$this.Text`）。'Copy to clipborad' の綴り。
- **Q14 Sequential.Execute の実装**：`RunSequentialAnalysis()` は `buttonExecute.PerformClick()`（FormMain.cs L518）。ウィンドウ非表示時に PerformClick が発火しない可能性（R2）。

---

## 4. 要確認事項

- **R1** 6-1〜6-4 の画像：キャプチャ自動生成スクリプトのコントロール名対応表（groupBox1/4/5, groupBox3.groupBox2）が意図と異なるのか、マニュアル側で参照名を誤ったのか。結晶リスト・回折線リスト（DataGridView）用の画像は現状存在しない（`docs/src/assets/cap-ja-auto/` に該当ファイルなし）。
- **R2** マクロ `PDI.Sequential.Execute()` を連続分析ウィンドウを開かずに呼んだ場合の動作（`Button.PerformClick` は WinForms 側で選択可能状態を要求するとされるが、本リポジトリ内では未検証）。マニュアルに「Open() を先に呼ぶこと」を書くべきか。
- **R3** `PDI.Fitting.Check()` / Ctrl+Alt+Space でチェックを変更したとき、DataTable の Row[0] 変更から `Fitting()` が再実行されるイベント経路があるか（FormFitting.cs 内に RowChanged/ColumnChanged ハンドラは見当たらない）。無ければマクロでチェック後に `Range()` 等で再計算を誘発する必要がある。
- **R4** メイン `bindingSourceCrystal` と FormFitting `bindingSourceCrystals` の Position が常に同期しているか（Q8）。
- **R5** 8章 L84 の「web マニュアルの 6 章（https://yseto.net/soft/pdi/pdi_06）」が現行 API 一覧と一致しているか。
- **R6** 8章 L15「マクロ一覧は終了時に自動保存・次回起動時に復元」は本監査では未検証（FormMain 側の保存処理を確認していない）。
- **R7** Search Range の画面値の単位（A3）：角度モードでも SerchRangeFactor が 1 になるとは限らない（波長依存）。マニュアルに「X 軸と同じ単位」と書いてよいか（マクロ Help `Range` はそう記述）、作者確認が望ましい。
- **R8** 6章 L106 の NA 注記「ピーク数に対して自由度が等しい」— 実装はパラメータ数 ≥ 使用ピーク数で NA（例 cubic: 1 本で NA）。文意は合っているが表現の確認。

---

## 5. 補足: 下書き用素材

**6章 回折線リスト列（正）**：（チェック） / `HKL` / `Calc X`（計算位置, 横軸単位） / `Func`（Simple, Sym PV, Sym Pea, Spl PV, Spl Pea） / `X`（観測位置） / `X Err` / `FWHM` / `Intensity`（積分強度÷ステップ幅） / `Weight`（角度モード 1/sin²θ） / `R`（残差, 比）。
結晶リスト列：`Check` / `PeakColor` / `Crystal`。

**6章 ボタン（正）**
- 表の上：`Effective digit`/`小数点以下桁数`（表示の有効数字, 既定 5）、`Save as CSV`/`CSV形式で保存`、`Copy to Clipboard`/`クリップボードにコピー`（全行）、`Clear peaks`（flexible 結晶のみ、全ピーク削除）。
- 右クリック：`Copy to clipborad`（選択行のみ）。
- Fitting option/フィッティング条件：`Search Range`/`範囲` ±値 + `Apply to all`/`全てのピークに適用`；`Initial FWHM`/`初期半値幅`（チェック）+ `Apply to all`；`Peak function`/`ピーク関数` + `Apply to all`；`Pattern Decomposition`/`パターン分解`（既定 OFF）+ `in each crystal`/`個々の結晶に対して`（既定）・`between crystals`/`全ての結晶に対して`（現状無効 Q1）。
- `Optimized cell constants`/`最適化した格子定数`：`Apply to the crystal`/`選択中の結晶に適用`（反映＋クリップボードコピー）、`Copy to Clipboard`/`クリップボードにコピー`。
- `Remove peaks`：`New profile name`（既定「プロファイル名_new」）、`Remove fitted peaks`。
- `Send d-values`：`Send d-values to CellFinder && AtomicPositionFinder`。

**7章 処理フロー（正）**
1. Fitting ウィンドウ非表示 → メッセージ（PdiText.OpenFittingForm）で中止。プロファイル < 4 → 無言で中止。
2. 先頭プロファイル名が "whole" で終わる → 応力（Singh）モード（先頭は除外、名前末尾の `-` 以降を方位角[°]として解釈）。
3. 対象リスト：開始番号（既定 0、指定時は値≥1）〜末尾、ループ ON なら 0〜開始番号−1 を追加。
4. 各プロファイルを単独チェック・選択 → `Fitting()` を 2 回、各回で許容判定→`Confirm(false)`（格子定数を次に引き継ぐ）。
5. 各タブに 1 行追加（許容外は NaN 行）。
6. 終了：チェック状態・格子定数・選択位置を復元、4 表をクリップボードへ、応力モードなら Singh 精密化、自動保存。

**8章 修正案**
- `Execute`：「読み込まれた全プロファイル（チェック状態は無関係）に対して連続分析を実行します。事前にピークフィッティングウィンドウを開き、対象ピークをチェックしておく必要があります。」（Help 属性側の修正も要検討）
- 例・サンプル 09：先頭に `PDI.Fitting.Open()` を追加し、`CheckAll()` は不要である旨を注記。
- `Apply`：`Confirm` → `Apply to the crystal`（選択中の結晶に適用）。クリップボードにもコピーされる旨を追記。
