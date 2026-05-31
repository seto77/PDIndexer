# PDIndexer ツールチップ監査（全体統合・adequacy 基準）

> 260601Ch: 4 アプリ共通の ToolTip 実装・文案原則は `ツールチップ編集方針(共通).md` に分離。この文書は PDIndexer 固有の監査結果、配線状況、残課題を扱う。

- 作成: 2026-05-31 (260531Cl)
- 範囲: **PDIndexer 本体の全フォーム＋ユーザーコントロール（17 UI Designer）**を 1 ファイルに統合した**調査台帳**。
- 目的: 未設定・間違い・**内容不足(THIN)**・ラベル共有・EN/JA 欠落を網羅し、EN/JA 文案まで添える。
- 参考: ReciPro の同種監査 [`C:\Users\seto\source\repos\ReciPro\.project-guidance\ReciPro_ツールチップ監査_全体統合.md`] の方法論・adequacy 基準・文体をそのまま踏襲。
- **実装は適用済み**（260531Cl〜・コード変更解禁後）。各フォームへの provider/配線・EN/JA 文案・55 カラム折返しを適用しビルド 0/0 を確認。詳細は下記「適用ログ」。共通の表示方式は [ツールチップ編集方針(共通).md](ツールチップ編集方針(共通).md) を参照。

## 目次
- 監査方法 / adequacy 基準
- 配線方針（PDIndexer 固有）と ファイル別状態
- 共有 Crystallography.Controls の扱い
- 数字（対応要 概算）
- 進め方（優先順）
- Part A — 既存ツールチップのあるフォーム（FormMain / FormFitting）
- Part B — ほぼ未設定のフォーム（FormEOS, FormProfileSetting, FormAtomicPositionFinder, FormCellFinder, FormSequentialAnalysis ほか）
- 引き継ぎ ToDo / 検証コマンド

## 監査方法
決定論抽出（全 Designer→コントロール↔既存tip↔ToolTip 配線インフラ）→ フォーム単位の並列 LLM 監査（各コントロールの実機能を `.cs`/`.Designer.cs` で確認しコード根拠を明記）→ WRONG/不一致は実機能と照合。ReciPro と同じく「ツールチップが有る」だけでなく「**内容が機能を十分表現できているか**」(adequacy) で評価する。

## adequacy（内容充足）基準
満たさない既存 tip は **THIN** として作り直す:

1. **機能**（何をする/何を設定するか） 2. **単位・範囲**（数値: NumericBox の HeaderText/FooterText/Min/Max を根拠に） 3. **効果**（結果に何が変わるか） 4. 似たコントロールとの**区別**
5. **略語の展開**（EOS→Equation Of State、FWHM→Full Width at Half Maximum、CPS→Counts Per Step、GSAS、EDX→Energy-Dispersive X-ray、TOF→Time-Of-Flight、Kα2、LPO→Lattice-Preferred Orientation 等）
6. **難概念の平易な説明**（K0'＝体積弾性率の圧力微分、Grüneisen 定数、Debye 温度、熱圧力、構造因子、Singh の式、パターン分解、Savitzky–Golay 平滑化、自動指数付け 等）

## 配線方針（PDIndexer 固有 — ReciPro と状況が大きく異なる）

ReciPro は多くのフォームに既に `ToolTip` provider と文案があり「resx 追加のみ」で済むケースが多かった。**PDIndexer は対照的に、ほぼ全フォームでツールチップ自体が未整備**。実機での表示可否は以下の 3 段階で決まる:

- **(a) resx 追加 / 文案改善のみ**: `ToolTip` provider があり、対象コントロールに既に `toolTip.SetToolTip(...)` 配線がある。resx 文案を入れ替える/追記するだけ。→ FormMain・FormFitting の既存配線済みコントロール。
- **(b) SetToolTip 行追加が必要**: `ToolTip` provider はフォームにあるが、対象コントロールへの `toolTip.SetToolTip(control, resources.GetString("control.ToolTip"))` 行が無い。Designer に 1 行ずつ配線を足す。→ FormMain・FormFitting の新規分、FormProfileSetting・FormLPO・FormCrystal。
- **(c) ToolTip 部品追加が必要（Designer 手術）**: フォームに `ToolTip` provider 自体が無い。`components`（`IContainer`）が既にあるフォームは `toolTip = new ToolTip(components);` を 1 つ足す。`components` も無いフォーム（**FormEOS / FormAboutMe**）は `components = new System.ComponentModel.Container();` の用意から必要（`Dispose` の `components?.Dispose()` も要確認）。

> **重要**: NumericBox / ColorControl などの独自コントロールは ReciPro 監査で「独自 `ToolTip` プロパティを持ち `ApplyResources` で表示される」挙動が指摘されている（[[project_crystallography_controls_junction]] 系）。PDIndexer でも `FormEOS` などは `Crystallography.Controls.NumericBox` を多用するため、**標準 `toolTip.SetToolTip(...)` で表示するか、独自プロパティ経由かを、適用前に実機で要確認**。新規は ReciPro 方針に合わせ標準 `SetToolTip` に寄せる。

### ファイル別状態（決定論抽出 260531Cl）

`主要` はユーザー操作可能コントロールのフィールド宣言数（Button/CheckBox/RadioButton/ComboBox/TextBox/NumericBox(WithMenu)/NumericUpDown/ColorControl/DataGridView/ListBox/CheckedListBox/ToolStripButton/ToolStripMenuItem/ToolStripTextBox/TabPage の概算）。`setTip` は Designer 内の `SetToolTip` 行数、`resxTip` は resx の非空 `.ToolTip(Text)` キー数。

| ファイル | 主要 | provider | components | setTip | resxTip(EN) | ja.resx | 適用方式 |
|---|--:|:--:|:--:|--:|--:|:--:|---|
| `FormMain` | 83 | ○ | ○ | 25 | 30 | ○ | (a)/(b) 既存配線＋新規SetToolTip |
| `FormProfileSetting` | 67 | ○ | ○ | 3 | 3 | ○ | (b) SetToolTip行追加 |
| `FormEOS` | 67 | × | × | 0 | 0 | ○ | (c) 部品+container 生成 |
| `FormFitting` | 41 | ○ | ○ | 10 | 10 | ○ | (a)/(b) |
| `FormAtomicPositionFinder` | 35 | × | ○ | 0 | 0 | × | (c) 部品追加・ja.resx 新設 |
| `FormSequentialAnalysis` | 31 | × | ○ | 0 | 0 | ○ | (c) 部品追加 |
| `FormCellFinder` | 25 | × | ○ | 0 | 0 | × | (c) 部品追加・ja.resx 新設 |
| `FormCrystal` | 22 | ○ | ○ | 2 | 2 | ○ | (b) ※主体は CrystalControl(別リポ) |
| `FormExportGSAS` | 11 | × | ○ | 0 | 0 | × | (c) 部品追加・ja.resx 新設 |
| `FormPrintOption` | 9 | × | ○ | 0 | 0 | × | (c) 部品追加・ja.resx 新設 |
| `FormLimitChanger` | 6 | × | ○ | 0 | 0 | × | (c) 部品追加・ja.resx 新設 |
| `DataConverter\FormDataConverter` | 6 | × | ○ | 0 | 0 | ○ | (c) 部品追加 |
| `FormLPO` | 5 | ○ | ○ | 1 | 0 | × | (b) ※既存 tip は SetToolTip 直書き |
| `DataConverter\EDXControl` | 4 | × | ○ | 0 | 0 | × | (c) 部品追加・ja.resx 新設 |
| `FormTwoThetaCalibration` | 3 | × | ○ | 0 | 0 | × | (c) 部品追加・ja.resx 新設 |
| `FormAboutMe` | 1 | × | × | 0 | 0 | ○ | (c) 部品+container（リンク2件のみ） |
| `UserControlIonicRadius` | 1 | × | ○ | 0 | 0 | × | (c) 部品追加（1件のみ） |

要点:
- **有効ツールチップを持つのは実質 FormMain（30件, JAは大半欠落）と FormFitting（10件, JA全欠落）のみ。** 残り 15 ファイルはほぼ全件 MISSING。
- **provider 未追加が 12 ファイル**。うち `FormEOS` / `FormAboutMe` は `components` 自体も無い。
- FormMain の `colorControl*` は Designer が `.ToolTip1` キーを `SetToolTip` に渡している（`.ToolTip` 無印は未使用）。文案を直す際は **`.ToolTip1` 側**を編集する点に注意。
- FormFitting の `numericBoxEffectiveDigit` は resx に `.ToolTip` と `.ToolTip1` の**重複キー**あり（整理対象）。

## 共有 Crystallography.Controls の扱い

PDIndexer は ReciPro と同じ Crystallography.Controls / Crystallography をジャンクションで共有する（[[project_crystallography_controls_junction]]）。`FormCrystal` の実体（結晶パラメータ編集）は Crystallography.Controls の `CrystalControl` ほかが担い、**これらは ReciPro 監査の Part B で既に網羅・一部適用済み**。したがって本監査は **PDIndexer 固有フォームに集中**し、共有コントロールは ReciPro 側の台帳を正本とする（重複監査しない）。CC 側を修正する場合のコミット先は CC リポジトリ。

## 数字（対応要 概算 — 機械抽出候補。最終適用時に人手で除外判断）

| フォーム | WRONG | THIN | MISSING(操作系) | JA欠落 | LABEL_SHARE |
|---|--:|--:|--:|--:|--:|
| FormMain | 1(+3※) | ~21 | ~50 | ~18 | ~12 |
| FormFitting | 1 | 5 | ~18 | 10 | 数件 |
| FormEOS | 0 | 0 | 22(入力)+11(表示切替)〔+~43 表示専用〕 | 全件 | 4 |
| FormProfileSetting | 0 | 3 | ~58 | 3 | ~17 |
| FormAtomicPositionFinder | 0 | 0 | ~33 | 全件 | ~20 |
| FormSequentialAnalysis | 0 | 0 | ~24 | 全件 | 数件 |
| FormCellFinder | 0 | 0 | ~25 | 全件 | ~12 |
| FormExportGSAS | 0 | 0 | 11 | 全件 | - |
| FormPrintOption | 0 | 0 | 9 | 全件 | - |
| FormLimitChanger | 0 | 0 | 6 | 全件 | - |
| FormDataConverter | 0 | 0 | 6 | 全件 | - |
| FormLPO | 1 | 0 | 3 | 全件 | - |
| EDXControl | 0 | 0 | 4 | 全件 | - |
| FormTwoThetaCalibration | 0 | 0 | 3 | 全件 | - |
| FormAboutMe | 0 | 0 | 2(リンク) | - | - |
| UserControlIonicRadius | 0 | 0 | 1 | 全件 | - |

※ FormMain の WRONG「+3」は `colorControl*` の表示キー(`.ToolTip1`)に JA が無く EN のみのケース（文面は妥当、JA 追加で解消）。

## 進め方（推奨順）
1. **WRONG**（誤情報・検証済）→ 即修正対象。FormMain `checkBoxChangeHorizontalAppearance`（EN 欄に日本語混入）、FormFitting `buttonClearPeaks`（CSV 保存文のコピペ誤り）、FormLPO `buttonGetPeakIntensities`（"below button" 誤誘導＋現状 no-op）。
2. **有効 tip 0 の大面積フォームへ「無→有」付与**（限界価値が最大）: FormEOS, FormProfileSetting, FormAtomicPositionFinder, FormSequentialAnalysis, FormCellFinder。provider 追加（特に FormEOS は container も）を伴う。
3. **既存 tip の THIN 改善＋JA 欠落補完**: FormMain（JA 大半欠落）、FormFitting（JA 全欠落、Apply 系 3 ボタンの区別）。
4. **LABEL_SHARE / 中小フォーム**: 入力欄の見出しラベルは隣接入力と同文案を共有。中小ダイアログ（GSAS/Print/Limit/2θ較正/DataConverter/EDX/IonicRadius/AboutMe）。

## 注意
- 文案中の数値範囲・単位は NumericBox の Header/Footer/Min/Max を根拠にした。`要確認` 付きは適用前にコード再確認が必要。
- 一部「機能未実装/死蔵」コントロールを検出（下記各節に明記）。tooltip 付与より先に実装意図の確認が要るものは付与対象から外す判断もあり得る。
- `.project-guidance/` はリポジトリ管理外（`.git/info/exclude`）想定。本メモ更新は `git status` に出ない。

---

# Part A — 既存ツールチップのあるフォーム

## A-1. FormMain

### FormMain — 概要
FormMain は粉末回折プロファイルのメインビューア。ユーザー操作可能コントロールは約 55 個（タブ内ラジオ/チェック/数値/色/コンボ、PictureBox、2 つの DataGridView、ToolStrip ボタン 8 個、メニュー項目約 30 個）。有効 EN tip 約 29 個に対し JA tip は 9 個のみで **JA 欠落が最大のリスク**。`checkBoxChangeHorizontalAppearance` は EN スロットに日本語が混入（WRONG 確定）。メニュー項目・ToolStrip 後半（Cell Finder / Sequential / Atomic Position / LPO）・unrolled image タブ・描画範囲 NumericBox 群は tip が薄いか皆無。`button2`(NaCl EOS)/`button3`(Pt EOS)/`buttonAu` はどのコンテナにも追加されず Click 未配線の**死蔵コントロール**のため対象外。

### FormMain — WRONG
| コントロール | 領域 | 現EN | 現JA | 実機能(コード根拠) | 修正案EN | 修正案JA |
|---|---|---|---|---|---|---|
| `checkBoxChangeHorizontalAppearance` | tabPage1 (Horizontal Axis) | `プロファイルを読み込み後、横軸モードを変更します。`(EN欄に日本語) | 同左(日本語) | チェック時、プロファイル読込時にそのファイルの WaveColor/WaveSource/波長/AxisMode を横軸へ自動適用 (FormMain.cs:3253,3317 `AddProfileToCheckedListBox`内) | When loading a profile, automatically switch the horizontal-axis settings (radiation source, wavelength, axis mode) to match the loaded file. | プロファイル読み込み時に、横軸の設定（線源・波長・軸モード）をそのファイルに合わせて自動的に切り替えます。 |
| `colorControlScaleText` (.ToolTip1 がアクティブキー) | tabPage2 groupBox2 | `Choose the scale-text's color` | (JA無) | 軸目盛りの数値文字色 (ColorChanged→Draw) | Color of the scale (axis tick) labels. | 軸目盛りの数値文字の色を設定します。 |
| `colorControlScaleLine` (.ToolTip1) | tabPage2 groupBox2 | `Choose the scale-line's color` | (JA無) | 目盛り線・グリッド線の色 (ColorChanged→Draw) | Color of the scale / grid lines. | 目盛り線・グリッド線の色を設定します。 |
| `colorControlBack` (.ToolTip1) | tabPage2 groupBox2 | `Choose the background color` | (JA無) | プロファイル描画の背景色 (Draw で gMain.Clear(colorControlBack.Color)) | Background color of the profile viewer. | プロファイル描画領域の背景色を設定します。 |

注: `colorControl*` は Designer が `.ToolTip1` キーを SetToolTip に渡す (FormMain.Designer.cs:800,817,834)。`.ToolTip`(無印)キーは未使用。WRONG 扱いは「正しい表示キーに JA が無く EN のみ」点。文面自体は妥当なので JA 追加で解消。

### FormMain — THIN
| コントロール | 領域 | 現EN | 現JA | 改善EN | 改善JA | 不足点 |
|---|---|---|---|---|---|---|
| `radioButtonLinearity` | tabPage2 groupBox4 | `Intensity are linealy plotted` | (JA無) | Plot intensity on a linear vertical scale. | 強度を縦軸リニア（線形）スケールで表示します。 | 縦軸の明示・対概念(Log)対比・誤記(linealy) |
| `radioButtonLogarithm` | tabPage2 groupBox4 | `Intensity are logarithmically plotted` | (JA無) | Plot intensity on a logarithmic vertical scale (emphasizes weak peaks). | 強度を縦軸対数スケールで表示します（微弱なピークが見やすくなります）。 | 効果・JA欠落 |
| `radioButtonRawCounts` | tabPage2 groupBox4(flow1) | `Raw count mode` | (JA無) | Show raw integrated counts (no division by step width). | 各点の生のカウント値（ステップ幅で割らない）を表示します。 | CPS との区別・効果・JA欠落 (IsCPS=false; FormMain.cs:4028) |
| `radioButtonCountsPerStep` | tabPage2 groupBox4(flow1) | `Count per step mode` | (JA無) | Show counts normalized per step (CPS = counts / step width). | 1 ステップあたりのカウント（CPS = カウント/ステップ幅）に正規化して表示します。 | CPS 略語展開・JA欠落 (IsCPS=true) |
| `groupBox4` | tabPage2 | `Choose vertical axis mode. ` | (JA無) | (ラベル枠) — 下記 LABEL_SHARE 参照 | 縦軸（強度軸）の表示モードを選びます。 | JA欠落・"vertical axis"の語明示 |
| `checkBoxChangeColor` | tabPage2 groupBox3 | `Check this if you want to change the color of  the next profile automatically` | (JA無) | In Multi-Profile mode, assign a random color to each newly added profile. | マルチプロファイル表示時に、新しく追加するプロファイルへ自動的に色を割り当てます。 | Multi 限定条件(FormMain.cs:3288)・JA欠落・二重空白 |
| `checkBoxErrorBar` | tabPage2 | `Show error bar (if profiles have it)` | (JA無) | Show error bars on data points when the profile contains error values. | プロファイルが誤差値を持つ場合に、各データ点へエラーバーを表示します。 | JA欠落 (FormMain.cs:1428 SourceProfile.Err) |
| `checkBoxShowScaleLine` | tabPage2 | `Show scale line` | (JA無) | Show grid (scale) lines on the profile viewer. | プロファイル表示領域に目盛り（グリッド）線を表示します。 | JA欠落 (FormMain.cs:1741) |
| `checkBoxProfileParameter` | groupBox1 | `Detailed profile parameter` | `プロファイルの詳しい情報を表示/設定します。` | Open the Profile Parameter window for detailed settings of the selected profile. | (現JA可)選択中プロファイルの詳細設定ウィンドウを開きます。 | EN が動作(窓を開く)を示さない (FormMain.cs:2444) |
| `checkBoxCrystalParameter` | groupBoxCrystalData | `Detailed crystal information` | `結晶の詳しい情報を表示/設定します。 ` | Open the Crystal Parameter window for detailed settings of the selected crystal. | (現JA可)選択中の結晶の詳細設定ウィンドウを開きます。 | EN が窓を開く動作を示さない (FormMain.cs:2458) |
| `checkBoxAll` | groupBox1 | `Check/Uncheck all profiles` | (JA無) | Check or uncheck all profiles at once (show/hide all). | 全プロファイルのチェックを一括でオン/オフします（全表示/全非表示）。 | JA欠落 (FormMain.cs:4305) |
| `numericBoxUpperX` | tableLayoutPanel2 | `Maximum value of horizontal axis. You can set the limit value in right-click menu.` | (JA無) | Upper bound of the displayed horizontal-axis range (2θ / d / energy etc.). Set the axis limit via right-click. | 横軸（2θ／d／エネルギー等）の表示範囲の上限値です。右クリックで軸の限界値を設定できます。 | 単位が軸モード依存・JA欠落 |
| `numericBoxLowerX` | tableLayoutPanel2 | `Minimum value of horizontal axis. ...right-click menu.` | (JA無) | Lower bound of the displayed horizontal-axis range. Set the axis limit via right-click. | 横軸の表示範囲の下限値です。右クリックで軸の限界値を設定できます。 | JA欠落 |
| `numericBoxUpperY` | tableLayoutPanel2 | `Maximum value of verticall axis. ...` | (JA無) | Upper bound of the displayed intensity (vertical) axis. | 縦軸（強度）の表示範囲の上限値です。 | 誤記(verticall)・JA欠落・Y は右クリックメニュー無し |
| `numericBoxLowerY` | tableLayoutPanel2 | `Minimum value of verticall axis. ...` | (JA無) | Lower bound of the displayed intensity (vertical) axis. | 縦軸（強度）の表示範囲の下限値です。 | 誤記(verticall)・JA欠落 |
| `dataGridViewProfiles` | groupBox1 | `Profile list. ...Multiple Profiles...` | `プロファイルのリストを表示します。...｢Multi Profile」モードをON...` | (現EN概ね可) Profile list. Checked profiles are drawn; click a row to select, Space/Enter toggles its check. | (現JA可)プロファイルの一覧です。チェックした行が描画され、行クリックで選択、Space/Enter でチェックを切り替えます。 | キーボード操作未記載 (FormMain.cs:4258) |
| `toolStripButtonProfileParameter` | toolStrip2 | `Display the detailde profile parameters ` | `プロファイルの詳しい情報を表示/設定します。` | Toggle the Profile Parameter window. | (現JA可)プロファイルの詳細設定ウィンドウを開閉します。 | 誤記(detailde)・トグル動作 |
| `toolStripButtonCrystalParameter` | toolStrip2 | `Display the detailed crystal information` | `結晶の詳しい情報を表示/設定します` | Toggle the Crystal Parameter window. | (現JA可)結晶の詳細設定ウィンドウを開閉します。 | トグル動作明示 |
| `toolStripButtonEquationOfState` | toolStrip2 | `Calculate the pressure using equation of state` | `状態方程式から圧力を算出します` | Toggle the Equation of State window to estimate pressure from cell volume of a standard. | (現JA可)状態方程式ウィンドウを開閉し、標準物質の格子体積から圧力を算出します。 | トグル/窓である旨 |
| `toolStripButtonFittingParameter` | toolStrip2 | `Fit the diffraction peaks` | (JA無) | Toggle the Peak Fitting window to fit diffraction peaks (position, FWHM, intensity). | ピークフィッティングウィンドウを開閉し、回折ピーク（位置・半値全幅・強度）をフィットします。 | JA欠落・FWHM等の対象明示 |
| `toolStripMenuItemExportCIF` | File menu | `The selected crrystal will be saved as CIF format` | (JA無) | Export the selected crystal as a CIF file. | 選択中の結晶を CIF 形式で保存します。 | 誤記(crrystal)・JA欠落 |
| `pictureBoxMain` | splitContainer1.Panel1 | `Main profile viewer ...Left/Right/Middle drag...` | `プロファイルを表示します 左ドラッグ:...` | (現EN概ね可) | (現JA可) | EN/JA とも概ね妥当。背景点/マスクモード時の挙動は未記載 |

### FormMain — MISSING（操作系の主なもの）
| コントロール | 型 | 領域 | 機能(コード根拠) | 提案EN | 提案JA |
|---|---|---|---|---|---|
| `radioButtonMultiProfileMode` | RadioButton | tabPage2 groupBox3 | 複数プロファイルを縦オフセットで重ね描画 (FormMain.cs:3986) | Stack multiple checked profiles with a vertical offset between them. | チェックした複数のプロファイルを縦方向にずらして重ねて表示します。 |
| `radioButtonSingleProfileMode` | RadioButton | tabPage2 groupBox3 | 単一表示（オフセット無し） | Show profiles overlaid without vertical offset (single-profile view). | プロファイルを縦オフセットなしで重ねて表示します（単一表示）。 |
| `numeriBoxIncreasingPixels` | NumericBox | tabPage2 groupBox3 | プロファイル間の縦オフセット量(counts) (ValueChanged→IntervalOfProfiles) | Vertical offset (in counts) added between stacked profiles in Multi-Profile mode. | マルチプロファイル表示で各プロファイル間に加える縦オフセット量（カウント単位）を設定します。 |
| `numericUpDownIncreasingPixels` | NumericUpDown | tabPage2 groupBox3 | 2^n 倍でオフセット増減（負はプリセット）(FormMain.cs:4001) | Adjust the stacking offset in powers of two; negative steps select preset fractions. | スタック時のオフセット量を 2 のべき乗で増減します（負の値は 0.5/0.1/0.05/0.01/0 のプリセット）。 |
| `checkBoxShowUnrolledImage` | CheckBox | tabPage3 | 2D 画像由来 unrolled(2θ-方位角)像描画 (FormMain.cs:4136) | Show the unrolled 2D (2θ vs azimuth) image alongside the profile. | 2D 画像から作られたプロファイルの unrolled 像（2θ対方位角）を併せて表示します。 |
| `numericUpDownMaxInt` / `numericUpDownMinInt` | NumericUpDown | tabPage3 | unrolled 像の表示強度上限/下限 (FormMain.cs:4096/4081) | Upper / lower intensity limit for the unrolled image color scale. | unrolled 像のカラースケールの強度上限/下限値を設定します。 |
| `comboBoxScale1` | ComboBox | tabPage3 | Log/Linear (FormMain.cs:4119) | Color-mapping scale for the unrolled image: Log or Linear. | unrolled 像の色割り当てスケール（対数／リニア）を選びます。 |
| `comboBoxScale2` | ComboBox | tabPage3 | Gray/Color (FormMain.cs:4121) | Color palette for the unrolled image: gray scale or cold-warm color. | unrolled 像の配色（グレースケール／寒暖色）を選びます。 |
| `comboBoxGradient` | ComboBox | tabPage3 | Positive/Negative film (FormMain.cs:1312) | Image gradient: Positive Film or Negative Film (inverts tone). | 像の階調（ポジ／ネガ反転）を選びます。 |
| `graphControlFrequency` | GraphControl | tabPage3 | 強度ヒストグラム＋縦線で Max/Min Int 設定 (FormMain.cs:4140) | Intensity histogram; drag the two vertical lines to set the display Min/Max intensity. | 強度ヒストグラムです。2 本の縦線をドラッグして表示強度の最小/最大を設定できます。 |
| `dataGridViewCrystals` | DataGridView | groupBoxCrystalData | 結晶リスト。チェックで回折線表示・右ダブルクリックで点滅・行選択で詳細連動 (FormMain.cs:4189)。EN tip 欠落 | Crystal list. Checked crystals' diffraction lines are drawn; right double-click toggles blinking; select a row to edit it in Crystal Parameter. | (現JA流用) |
| `toolStripButtonCellFinder` | ToolStripButton | toolStrip2 | Cell Finder 窓トグル (FormMain.cs:2523) | Toggle the Cell Finder window to search lattice constants from peak positions. | セルファインダーウィンドウを開閉し、ピーク位置から格子定数を探索します。 |
| `toolStripButtonSequentialAnalysis` | ToolStripButton | toolStrip2 | Sequential Analysis 窓トグル (FormMain.cs:2470) | Toggle the Sequential Analysis window for batch processing of a file series. | 連続解析ウィンドウを開閉し、複数ファイルを一括処理します。 |
| `toolStripButtonAtomicPositonFinder` | ToolStripButton | toolStrip2(既定非表示) | Atomic Position Finder 窓トグル (FormMain.cs:2540) | Toggle the Atomic Position Finder window. | 原子位置探索ウィンドウを開閉します。 |
| `toolStripButtonLPO` | ToolStripButton | toolStrip2(既定非表示) | LPO Analysis 窓トグル (FormMain.cs:2507) | Toggle the LPO (lattice-preferred orientation) Analysis window. | LPO（格子選択配向）解析ウィンドウを開閉します。 |
| `readPatternProfileToolStripMenuItem` | MenuItem | File | プロファイル読込ダイアログ | Open and read diffraction profile file(s) as a new list. | 回折プロファイルファイルを新規リストとして読み込みます。 |
| `savePatternProfileToolStripMenuItem` | MenuItem | File | 全プロファイルを .pdi2 で保存 (FormMain.cs:3683) | Save all loaded profiles to a .pdi2 file. | 読み込み済みの全プロファイルを .pdi2 形式で保存します。 |
| `asCSVcommaSeperatedFileToolStripMenuItem` / `asTSVtabSeparatedValuesFileToolStripMenuItem` / `asGSASFileToolStripMenuItem` | MenuItem | File>Export | CSV/TSV/GSAS 書出し | Export the profile(s) as a CSV / TSV / GSAS (Rietveld) file. | プロファイルを CSV／TSV／GSAS（リートベルト解析）形式で書き出します。 |
| `readCrystalDataToolStripMenuItem` / `readAndAddToolStripMenuItem` | MenuItem | File | 結晶 XML 新規読込 / 追加読込 (FormMain.cs:3438) | Load crystals from an XML file as a new list / add them to the current list. | 結晶データ（XML）を新規読み込み／現在のリストへ追加します。 |
| `saveCrystalDataToolStripMenuItem` | MenuItem | File | 結晶リスト保存 | Save the current crystal list to a file. | 現在の結晶リストをファイルに保存します。 |
| `toolStripMenuItemImport` | MenuItem | File | CIF/AMC 取り込み (FormMain.cs:3725) | Import a crystal structure from a CIF or AMC file. | CIF／AMC ファイルから結晶構造を取り込みます。 |
| `resetInitialCrystalDataToolStripMenuItem` | MenuItem | File | default.xml から初期化 (FormMain.cs:3679) | Revert the crystal list to the initial (default) state. | 結晶リストを初期（既定）状態に戻します。 |
| `toolStripMenuItemPageSetup` / `toolStripMenuItemPrintPreview` / `printToolStripMenuItem` | MenuItem | File | ページ設定/プレビュー/印刷 | Open page setup / show print preview / print the profile viewer. | 印刷のページ設定／プレビュー／印刷を行います。 |
| `copyAsMetafileToolStripMenuItem` / `BitmapToolStripMenuItem` | MenuItem | File>Copy | メタファイル/ビットマップでコピー (FormMain.cs:3783) | Copy the viewer to the clipboard as a metafile (vector) / bitmap. | 表示内容をメタファイル（ベクター）／ビットマップとしてコピーします。 |
| `toolStripMenuItemSaveMetafile` | MenuItem | File | EMF 保存 (FormMain.cs:3746) | Save the viewer as an EMF metafile. | 表示内容を EMF メタファイルとして保存します。 |
| `closeToolStripMenuItem` | MenuItem | File | アプリ終了 (FormMain.cs:3674) | Close PDIndexer. | PDIndexer を終了します。 |
| `toolTipToolStripMenuItem` | MenuItem(check) | Option | ツールチップ表示の有効/無効 (FormMain.cs:3671 `toolTip.Active = Checked`)。**`toolTip` は FormMain 専用インスタンスのため、効くのは FormMain 上のチップのみ**（`ToolTip.Active` はインスタンス単位。他フォームは別インスタンスで制御外）。→ §バルーン §10 参照。文案は実態に合わせ「このウィンドウ」に訂正（"throughout the application" は不正確）。 | Enable or disable the tooltips on the main window. | このウィンドウ（メイン画面）のツールチップ表示を有効／無効にします。 |
| `watchReadClipboardToolStripMenuItem` | MenuItem(check) | Option | クリップボード監視 (FormMain.cs:3625) | Watch the clipboard and auto-read profiles/crystals copied from other apps (e.g. IPAnalyzer). | クリップボードを監視し、他アプリ（IPAnalyzer 等）からコピーされたプロファイル／結晶を自動取込します。 |
| `watchReadANewProfileToolStripMenuItem` / `setDirectoryToTheWatchToolStripMenuItem` / `toolStripTextBoxDirectoryToWatch` | MenuItem/TextBox | Option>Watch File | 監視フォルダの .pdi 自動読込・フォルダ選択・パス入力 (FormMain.cs:3653/3658/3644) | Watch a folder for new .pdi files / choose the folder / edit the watched path. | 指定フォルダを監視し新規 .pdi を自動読込／監視フォルダ選択／監視パス入力。 |
| `clearRegistryToolStripMenuItem` | MenuItem(check) | Option | 終了時にレジストリ設定消去 (FormMain.cs:892) | When checked, clear all saved settings from the registry on exit (restart to reset). | チェックすると、終了時にレジストリの保存設定をすべて消去します（再起動で初期化）。 |
| `automaticallySaveTheCrystalListToolStripMenuItem` | MenuItem(check) | Option | 終了時に結晶リスト自動保存 (FormMain.cs:878) | When checked, automatically save the crystal list on exit and reload it on startup. | チェックすると、終了時に結晶リストを自動保存し、次回起動時に読み込みます。 |
| `editorToolStripMenuItem` / `macroToolStripMenuItem` | MenuItem | Macro | マクロエディタ/登録マクロ実行 (FormMain.cs:3574/3577) | Open the macro editor / run a registered macro. | マクロエディタを開く／登録済みマクロを実行します。 |
| `aboutMeToolStripMenuItem` / `programUpdatesToolStripMenuItem` / `hintToolStripMenuItem` / `helpwebToolStripMenuItem` | MenuItem | Help | バージョン情報/更新確認/ヒント/PDF マニュアル (FormMain.cs:3676/4319/3740/3712) | Show version info / check for updates / show hints / open the PDF manual. | バージョン情報／最新版確認／ヒント／マニュアル(PDF) を表示します。 |
| `englishToolStripMenuItem` / `japaneseToolStripMenuItem` | MenuItem(check) | Language | UI 言語切替（再起動要） | Switch the UI language to English / Japanese (requires restart). | UI 言語を英語／日本語に切り替えます（再起動が必要）。 |

### FormMain — JA欠落（EN有/JA無、上の改善案を JA 側へ）
`radioButtonLinearity` `radioButtonLogarithm` `radioButtonRawCounts` `radioButtonCountsPerStep` `groupBox4` `checkBoxChangeColor` `colorControlScaleText(.ToolTip1)` `colorControlScaleLine(.ToolTip1)` `colorControlBack(.ToolTip1)` `checkBoxErrorBar` `checkBoxShowScaleLine` `checkBoxAll` `numericBoxUpperX/LowerX/UpperY/LowerY` `toolStripButtonFittingParameter` `toolStripMenuItemExportCIF`（計18件。文案は上表 改善JA を使用）

### FormMain — LABEL_SHARE
| ラベル | 共有先入力 | 共有tip(EN/JA) |
|---|---|---|
| `label5`("Scale Text") | colorControlScaleText | Color of the scale (tick) labels. / 軸目盛りの数値文字の色を設定します。 |
| `label2`("Scale Line") | colorControlScaleLine | Color of the scale / grid lines. / 目盛り線・グリッド線の色を設定します。 |
| `label4`("Background") | colorControlBack | Background color of the viewer. / 背景色を設定します。 |
| `label1`/`label6`("counts") | numeriBoxIncreasingPixels | マルチ表示で各プロファイル間に加える縦オフセット量（カウント）を設定します。 |
| `label24`("Gradient") | comboBoxGradient | 像の階調（ポジ／ネガ）を選びます。 |
| `label23`("Scale 1") / `label22`("Scale 2") | comboBoxScale1 / comboBoxScale2 | unrolled 像の色割り当てスケール／配色を選びます。 |
| `label7`("Min.Int.") / `label21`("Max.Int.") | numericUpDownMinInt / MaxInt | unrolled 像の表示強度下限/上限を設定します。 |

(出力専用の座標読み出しラベル labelD/labelTwoTheta/labelQ/labelIntensity 等は対象外。)

> 実装注意(文案外): `colorControl*` は `.ToolTip1` キーが表示根拠（無印は未使用）。`numericBoxUpperX/LowerX` は `NumericBoxWithMenu`(右クリック限界設定メニューあり)、Y 側は通常 `NumericBox`(右クリック無し)なので EN/JA とも Y からは "right-click" 記述を外す。

---

## A-2. FormFitting

### FormFitting — 概要
回折プロファイル上で各 hkl ピークを 5 種のピーク形状関数でフィットし、観測 d 値から最小二乗で格子定数 (a,b,c,α,β,γ)・体積 V とその誤差を精密化するフォーム。左にピーク形状/探索範囲/初期 FWHM/パターン分解の設定、右に hkl 一覧テーブル、上部に結果セルと各種コピー・保存・転送ボタン。既存 tip は EN のみ 10 件で **JA は全欠落**、うち `buttonClearPeaks` は文言コピペ誤り、Apply 系 3 ボタンは "Apply to all" のみで区別不能。

### FormFitting — WRONG
| コントロール | 領域 | 現EN | 現JA | 実機能(コード根拠) | 修正案EN | 修正案JA |
|---|---|---|---|---|---|---|
| `buttonClearPeaks` | フォーム直下(Flexible モード時のみ表示) | `Save below table data as CSV file format.` | (無) | `buttonClearPeaks_Click`: Flexible モードのとき TargetCrystal.Plane.Clear() で全ピーク削除し再描画。`buttonSaveTableAsCSV` の文言を誤流用 | Clear all manually added peaks of the selected crystal (Flexible mode only). | 選択中の結晶（フレキシブルモード時のみ表示）に手動追加した全ピークを削除します。 |

### FormFitting — THIN
| コントロール | 領域 | 現EN | 現JA | 改善EN | 改善JA | 不足点 |
|---|---|---|---|---|---|---|
| `buttonApplyFunctionToAll` | groupBox2 ピーク関数 | `Apply to all` | (無) | Apply the peak shape function selected above to all peaks of this crystal. | 上で選択したピーク形状関数を、この結晶の全ピークに適用します。 | 何を適用か不明。`_Click`が全Planeの`SerchOption`設定 |
| `buttonApplyFWHMToAll` | groupBox3>panelFWHM | `Apply to all` | (無) | Apply the initial FWHM value above to all peaks as their starting peak width. | 上の初期半値全幅(FWHM)を全ピークの初期ピーク幅として適用します。 | 何を適用か不明。全Planeの`FWHM`設定 |
| `buttonApplyRangeToAll` | groupBox3 探索範囲 | `Apply to all` | (無) | Apply the search range (fitting window half-width) above to all peaks. | 上の探索範囲(フィッティング窓の半幅)を全ピークに適用します。 | 何を適用か不明。全Planeの`SerchRange`設定 |
| `buttonRemovePeaks` | groupBox4 ピーク除去 | `Remove fitted peaks of the selected crystal from the current profiles, and generate the new profile` | (無) | Subtract the fitted peak profiles of the selected crystal from the current profile and create a new profile (named below). Simple-search peaks are excluded. | 選択中の結晶のフィットしたピーク形状を現在のプロファイルから差し引き、新しいプロファイル(下で命名)を作成します。Simple探索のピークは除外されます。 | 「差し引き」「新規名は下のTextBox」「Simple除外」未記載 |
| `numericBoxEffectiveDigit` | テーブル下 | `Set effective digit` | (無) | Number of significant digits shown in the peak table (1-16). Display only; does not affect fitting. | ピーク一覧テーブルの表示有効桁数(1〜16)を設定します。表示のみで、フィッティング結果には影響しません。 | 範囲(1-16)・対象(表示書式)・計算非影響が未記載。resx に `.ToolTip`/`.ToolTip1` 重複キーあり(整理対象) |

### FormFitting — MISSING
| コントロール | 型 | 領域 | 機能(コード根拠) | 提案EN | 提案JA |
|---|---|---|---|---|---|
| `radioButtonSimple` | RadioButton | groupBox2 | 単純ピークサーチ(`PeakFunctionForm.Simple`)。曲線フィットせず探索範囲内のピーク頂点検出 | Simple peak search: find the peak top within the search range without curve fitting (no FWHM/intensity refinement). | 単純ピークサーチ。曲線フィットせず探索範囲内のピーク頂点を検出します（半値幅・強度は精密化しません）。 |
| `radioButtonPseudoVoigt` | RadioButton | groupBox2 | 対称擬フォークト(既定) | Fit with a symmetric pseudo-Voigt function (Gaussian-Lorentzian mix); default shape. | 対称な擬フォークト関数（ガウス・ローレンツ混合）でフィットします。既定の形状です。 |
| `radioButtonSymmetricPearson` | RadioButton | groupBox2 | 対称 Pearson VII | Fit with a symmetric Pearson VII function. | 対称な Pearson VII 関数でフィットします。 |
| `radioButtonSplitPseudoVoigt` | RadioButton | groupBox2 | 分割型擬フォークト(左右非対称) | Fit with a split (asymmetric) pseudo-Voigt: left and right halves have independent widths. | 分割型（非対称）擬フォークト関数でフィットします。ピークの左右で幅を独立に扱います。 |
| `radioButtonSplitPearson` | RadioButton | groupBox2 | 分割型 Pearson VII(左右非対称) | Fit with a split (asymmetric) Pearson VII: left and right halves have independent shapes. | 分割型（非対称）Pearson VII 関数でフィットします。ピークの左右で形状を独立に扱います。 |
| `numericBoxSearchRange` | NumericBox | groupBox3 | 探索範囲(`SerchRange`)。中心 XCalc の±この幅。単位は横軸モード依存、Min=0 | Half-width of the fitting window around the calculated peak position. Units follow the horizontal axis (2θ/energy/d). | 選択ピークの計算位置を中心とするフィッティング窓の半幅を設定します。単位は横軸モード（2θ／エネルギー／d）に従います。 |
| `numericBoxInitialFWHM` | NumericBox | groupBox3>panelFWHM | 初期 FWHM(`FWHM`)。checkBoxUseInitialFWHM 有効時のみ。単位は横軸モード依存、Min=0 | Initial FWHM (peak width starting guess); used only when "Initial FWHM" is checked. Units follow the horizontal axis. | 選択ピークの初期半値全幅（フィットの初期ピーク幅）を設定します。「初期半値幅」がオンのときのみ有効です。単位は横軸モードに従います。 |
| `checkBoxUseInitialFWHM` | CheckBox | groupBox3 | ON で panelFWHM 有効化し各ピークに値適用。OFF では探索範囲の1/2 | Use a user-specified initial FWHM as the fitting start width. When off, half the search range is used. | 指定した初期半値全幅をフィットの初期ピーク幅として使用します。オフのときは探索範囲の1/2が使われます。 |
| `checkBoxPatternDecomposition` | CheckBox | groupBox3 | ON で重なりピークを同時フィット(パターン分解)、分解単位選択を有効化 | Pattern decomposition: fit overlapping peaks simultaneously instead of one at a time. | パターン分解。重なり合うピークを個別ではなく同時にフィットします。 |
| `radioButtonEachCrystal` / `radioButtonBetweenCrystals` | RadioButton | groupBox3>flow(分解時) | 分解グループ化を結晶ごと(既定)/全結晶間 | During pattern decomposition, group overlapping peaks within each crystal / across all crystals. | パターン分解の際、重なりピークを結晶ごと／全結晶間にまたがってグループ化します。 |
| `buttonSendToCellFinder` | Button | groupBox5 | フィット済みピークの観測 d 値(×10,Å)と強度を CellFinder/AtomicPositionFinder へ転送 | Send the observed d-spacings and intensities of the fitted peaks to the CellFinder and atomic-position-finder tools. | フィット済みピークの観測 d 値（面間隔）と強度を、CellFinder と原子位置探索ツールへ転送します。 |
| `buttonResetTakeoffAngle` | Button | groupBox1(既定非表示, Energy モード) | エネルギー分散時に横軸プロパティ再計算しテイクオフ角リセット | Recalculate and reset the takeoff angle (energy-dispersive X-ray mode only). | テイクオフ角を再計算してリセットします（エネルギー分散X線モード時のみ）。 |
| `textBoxRemovedProfileName` | TextBox | groupBox4 | buttonRemovePeaks で生成する新規プロファイル名 | Name for the new profile created by "Remove fitted peaks". | 「フィットピークの除去」で作成する新しいプロファイルの名前を入力します。 |
| `dataGridViewPlaneList` | DataGridView | フォーム右 | hkl 一覧。チェックでフィット対象、行選択で関数/範囲/FWHM 編集、CSV ドラッグ&ドロップ可 | Peak list: check a row to include that hkl in the fit; select a row to edit its function/range/FWHM. Drag-and-drop a CSV to load values. | ピーク一覧。チェックでその hkl をフィット対象に含め、行選択でその関数／範囲／半値幅を編集します。CSV をドラッグ＆ドロップして一括読込できます。 |
| `dataGridViewCrystals` | DataGridView | フォーム左上 | フィット対象結晶を選択(メインと連動) | Select the crystal whose peaks are fitted; mirrors the crystal list of the main window. | ピークをフィットする結晶を選択します。メインウィンドウの結晶一覧と連動します。 |
| `copyToClipboradToolStripMenuItem` | ContextMenu | dataGridViewPlaneList 右クリック | 選択 1 ピーク行をタブ区切りでコピー | Copy the currently selected peak row to the clipboard (tab-separated). | 選択中のピーク行のデータをタブ区切りでクリップボードにコピーします。 |

### FormFitting — JA欠落（EN有/JA無）
`buttonCopyCellConstantsToClipboard`(精密化した格子定数をクリップボードにコピーします。Excelに直接貼り付けられます。) / `buttonConfirm`(精密化した格子定数を、選択中の結晶の格子定数として適用します。) / `buttonCopyTableToClipboard`(下のテーブルのデータをクリップボードにコピーします。Excelに直接貼り付けられます。) / `buttonSaveTableAsCSV`(下のテーブルのデータをCSV形式で保存します。) ＋ 上記 THIN/WRONG の 6 件。計 10 件すべて JA 欠落。

### FormFitting — LABEL_SHARE
| ラベル | 共有先入力 | 共有tip |
|---|---|---|
| `label2`/`label18`(Search Range, unit) | numericBoxSearchRange | フィッティング窓の半幅。単位は横軸モード(2θ/エネルギー/d)に従います。 |
| `label1`(unit, panelFWHM) | numericBoxInitialFWHM | 選択ピークの初期半値全幅を設定します（初期半値幅オン時のみ）。 |
| `label4`(New profile name) | textBoxRemovedProfileName | 「フィットピークの除去」で作成する新しいプロファイルの名前。 |

> 結果表示の textBoxA〜V/誤差欄(±/Å/°/Å³ ラベル付随)は読み取り専用。共有 tip 例「最小二乗法で精密化された格子定数（と1σ誤差）です（読み取り専用）。」

# Part B — ほぼ未設定のフォーム

## B-1. FormEOS

### FormEOS — 概要
圧力標準物質（Au, Pt, NaCl(B1/B2), MgO, Al2O3, Ar, Re, Mo, Pb）の測定格子定数・格子体積を入力すると、各種状態方程式(EOS)で発生圧力 P (GPa) を逆算するツール（`CalculatePressure`→`Gold()`/`Pt()` 等が各 `EOS.*` を呼ぶ）。レイアウトは標準物質ごとに GroupBox 1 つ、上部に表示切替 CheckBox 群、フォーム共通の温度 T(`numericBoxTemperature`)・参照温度 T0(`numericBoxTemperature0`)。各 GroupBox は「測定値入力(a または V)」「参照値入力(a0/V0)」＋「研究者名ごとの計算結果(P, 表示専用)」。**ユーザー直接入力は 22 個（測定値10・参照値10・温度2）、表示専用の計算結果 約43個、表示切替 CheckBox 11個（hBN は機能未実装）。tip は EN/JA とも 0 件**。NumericBox に Min/Max 設定は resx に無く範囲は「要確認」。`ja.resx` は存在し JA 案はそのまま使用可。**provider・components とも無し→ (c) 部品+container 生成が必要**。

### FormEOS — MISSING（入力コントロール）
| コントロール | 型 | 領域 | 機能(コード根拠) | 提案EN | 提案JA |
|---|---|---|---|---|---|
| `numericBoxTemperature` | NumericBox | 共通(Header `Temperature`,Footer `K`) | 全 EOS の温度 t。各関数に渡り熱圧力項を決める | Sample temperature T (K) at which the cell was measured. Shared by all standards; raising T adds thermal pressure, lowering the computed P. | 測定時の試料温度 T (K) を設定します。全標準物質で共通に使われ、温度を上げると熱圧力が加わり算出圧力 P は下がります。 |
| `numericBoxTemperature0` | NumericBox | 共通(Header `T0`,Footer `K`) | 参照温度 t0。Pt(Matsui)/Pb で使用 | Reference temperature T0 (K) of the V0/a0 reference values; used by the Pt Matsui and Pb models. Usually 300 K. | 参照値(a0/V0)の基準温度 T0 (K)。Pt(Matsui) と Pb で参照格子を温度 T に補正する際に使われます。通常 300 K。測定温度 T とは別です。 |
| `numericalTextBoxGoldA` | NumericBox | Gold(`a`,`Å`) | 測定 Au 格子定数 a。`v=a³` | Measured lattice parameter a (Å) of the gold (Au) marker. Drives V=a³ fed to all Au equations of state to compute P. | 金(Au)標準の測定格子定数 a (Å)。V=a³ として各 Au 状態方程式に渡り圧力 P を算出します。 |
| `numericBoxGoldA0` | NumericBox | Gold(`a0`,`Å`) | 常圧基準 a0（既定 4.07825, `v0=a0³`） | Zero-pressure reference lattice parameter a0 (Å) of Au (default 4.07825). P depends on the V/V0 ratio. | 金(Au)の常圧基準格子定数 a0 (Å)（既定 4.07825）。圧力は V/V0 比から計算されます。 |
| `numericalTextBoxPtA` / `numericBoxPtA0` | NumericBox | Platinum(`a`/`a0`,`Å`) | 測定/基準 Pt 格子定数（a0 既定 3.9231） | Measured / zero-pressure reference lattice parameter a (Å) of platinum (Pt). | 白金(Pt)の測定／常圧基準格子定数 a (Å)（a0 既定 3.9231）。 |
| `numericalTextBoxNaClB1A` / `numericBoxNaClB1A0` | NumericBox | NaCl(B1)(`a`/`a0`,`Å`) | 測定/基準 NaCl-B1 格子定数（a0 既定 5.639） | Measured / reference lattice parameter a (Å) of the B1 (rock-salt) phase of NaCl. | NaCl B1(岩塩型)相の測定／常圧基準格子定数 a (Å)（a0 既定 5.639）。 |
| `numericalTextBoxNaClB2A` | NumericBox | NaCl(B2)(`a`,`Å`) | 測定 NaCl-B2(CsCl型)格子定数。Sata/Ueda/Sakai は a を直接使用 | Measured lattice parameter a (Å) of the B2 (CsCl-type) high-pressure phase of NaCl. | NaCl の高圧 B2(CsCl型)相の測定格子定数 a (Å)。B1 相とは別相の入力です。 |
| `numericalTextBoxNaClB2A0` | NumericBox | NaCl(B2)(`a0`,`Å`) | **ReadOnly=true**。B2 各式は未使用（参照表示） | Reference lattice parameter a0 (Å) for NaCl B2 (read-only; the B2 models compute P directly from a). | NaCl B2 の基準格子定数 a0 (Å)（読み取り専用。B2 各式は a から直接 P を計算）。 |
| `numericalTextBoxMgOA` / `numericBoxMgOA0` | NumericBox | Periclase(`a`/`a0`,`Å`) | 測定/基準 MgO 格子定数（既定 4.2112） | Measured / reference lattice parameter a (Å) of MgO (periclase) (default 4.2112). | MgO(ペリクレース)の測定／常圧基準格子定数 a (Å)（既定 4.2112）。 |
| `numericalTextBoxColundumV` / `numericBoxColundumV0` | NumericBox | Corundum(`V`/`V0`,`Å³`) | 測定/基準 Al2O3 体積（V0 既定 255.89472）。**体積を直接入力** | Measured / reference unit-cell volume V (Å³) of Al2O3 (corundum). This standard takes volume directly, not a. | Al2O3(コランダム)の測定／常圧基準格子体積 V (Å³)（V0 既定 255.89472）。格子定数 a でなく体積を直接入力します。 |
| `numericalTextBoxArA` | NumericBox | Ar(`a`,`Å`) | 測定 固体 Ar 格子定数。Ar 各式は a を直接使用（a0 不使用） | Measured lattice parameter a (Å) of solid argon (Ar). The Ar models use a directly (no a0). | 固体アルゴン(Ar)の測定格子定数 a (Å)。Ar の各式は a0 を使わず a から直接 P を計算します。 |
| `numericBoxArA0` | NumericBox | Ar(`a0`,`Å`) | Ross/Jephcoat 計算では**未使用**（参照表示） | Reference lattice parameter a0 (Å) of Ar (reference display only; the Ross/Jephcoat models do not use it). | Ar の基準格子定数 a0 (Å)（参照表示用。Ross/Jephcoat の計算には使われません）。 |
| `numericBoxReV` / `numerictBoxReV0` | NumericBox | Re(`V`/`V0`,`Å³`) | 測定/基準 Re 体積（V0 既定 29.42795, Zha で使用） | Measured / reference unit-cell volume V (Å³) of rhenium (Re) (V0 default 29.42795; used by the Zha model). | レニウム(Re)の測定／常圧基準格子体積 V (Å³)（V0 既定 29.42795。Zha 式で使用、Anz/Sakai/Dub は内蔵 V0）。 |
| `numericBoxMoV` / `numericBoxMoV0` | NumericBox | Mo(`V`/`V0`,`Å³`) | 測定/基準 Mo 体積（既定 31.14; Huang/Zhao で使用） | Measured / reference unit-cell volume V (Å³) of molybdenum (Mo) (default 31.14; Huang(MGD) & Zhao(BM4+thermal)). | モリブデン(Mo)の測定／常圧基準格子体積 V (Å³)（既定 31.14。Huang(MGD)・Zhao(BM4+熱圧力)式で使用）。 |
| `numericBoxPbA` / `numericBoxPbA0` | NumericBox | Pb(`a`/`a0`,`Å`) | 測定/基準 Pb 格子定数（a0 既定 4.95059）。Strässle 式は a/a0(T) を Vinet 形式 | Measured / reference lattice parameter a (Å) of lead (Pb) (a0 default 4.95059); the Strässle model uses a/a0(T). | 鉛(Pb)の測定／常圧基準格子定数 a (Å)（a0 既定 4.95059）。Strässle 式は a/a0(T) を Vinet 形式で使います。 |

### FormEOS — MISSING（表示切替 CheckBox）
`checkBoxGold`/`Platinum`/`NaClB1`/`NaClB2`/`Periclase`/`Corundum`/`Ar`/`Re`/`Mo`/`Pb`: 対応 GroupBox の Visible を切替（`checkBoxGold_CheckedChanged`）。EN「Show/hide the <material> pressure-standard panel.」/ JA「<物質>圧力標準のパネル表示/非表示を切り替えます。」 — `checkBoxHBN` は対応パネルが無く**機能未実装**（要確認。tip でその旨明示推奨）。

### FormEOS — 表示専用の計算結果（参照用、tip 付与は任意）
研究者名ボックス群（GoldJamieson/Anderson/Sim/Tsuchiya/Yokoo/Fratanduono、Pt Jamieson/Holmes/Matsui/Yokoo/Fratanduono、NaClB1 Brown/Matsui/Skelton、NaClB2 SataPt/SataMgO/Ueda/SakaiBM/SakaiVinet、MgO Jackson/Dewaele/Aizawa/TangeVinet/TangeBM、Corundum Dubrovinsky、Ar Ross/Jephcoat、Re Zha/Anz/Sakai/Dub、Mo Huang/Zhao、Pb Strässle）は **ValueChanged 無し＝表示専用**。共通文案: 「該当論文の状態方程式で計算した圧力 P (GPa) を表示します（入力欄ではなく計算結果）。」各論文の手法（BM3+Mie-Grüneisen / Vinet / BM4 / MGD 等）は個別 tip で 1 句補える。

### FormEOS — LABEL_SHARE（単位ベースの共有）
| 対象 | 共有tip |
|---|---|
| `Å`(a/a0)欄 | Cubic lattice parameter (Å); the EOS uses V = a³. / 立方晶の格子定数(Å)。状態方程式では V = a³ として使われます。 |
| `Å³`(V/V0)欄 | Unit-cell volume (Å³), entered directly (non-cubic / volume-based standards). / 格子体積(Å³)を直接入力します（非立方晶または体積基準の標準）。 |
| `GPa`(結果)欄 | Computed pressure (GPa); read-only result. / 計算された圧力(GPa)。表示専用の計算結果です。 |
| `K`(T/T0)欄 | Temperature (K): T=sample, T0=reference of a0/V0. / 温度(K)。T は試料測定温度、T0 は a0/V0 の基準温度。 |

> 要確認: `Crystallography.Controls.NumericBox` の tip 表示方式（標準 SetToolTip か独自プロパティか）。`checkBoxHBN`・`numericBoxArA0`・`numericalTextBoxNaClB2A0` は表示されるが計算で実質未使用。

---

## B-2. FormProfileSetting

### FormProfileSetting — 概要
選択中プロファイルの表示パラメータと各種処理を設定。左に DataGridView(一覧)、右に「Basic property」(名前/色/線幅/コメント)、下に 3 タブ: tabPage2「Profile processing」(処理を 1〜7 番号付きで縦並べ: 2θオフセット/マスク+補間/平滑化/バンドパス/Kα2除去/バックグラウンド/強度規格化)、tabPage3「Axis setting」(線源/波長/取り出し角・露光時間・横軸シフト)、tabPage1「Profile Operator」(プロファイル間/値の四則演算・平均)。操作系 約67個。**既存 tip は EN resx に 3 件のみ**（`numericUpDownInterpolationPoints.ToolTip`/`label20`/`label21` が全て同一文「Interpolate from # points adjacent to the masked range」で THIN）。**ja.resx に tip は 0 件**。provider・components 有→ (b)。

### FormProfileSetting — WRONG/THIN
| コントロール | 領域 | 現EN | 実機能(コード根拠) | 改善EN | 改善JA |
|---|---|---|---|---|---|
| `numericUpDownInterpolationPoints` | tabPage2/panelMaskingMode | Interpolate from # points adjacent to the masked range | `setMaskingOption`: `dp.InterpolationPoints`。マスク範囲の左右両側それぞれこの点数で多項式補間 | Number of data points taken from EACH side of the masked range to fit the interpolation (used with polynomial order). | マスク範囲の左右それぞれから補間に使うデータ点数を設定します。多項式次数と組み合わせ、点数を増やすほど広い範囲を参照します。 |
| `label20`("(eath sides)") / `label21`("Point No.") | 同上 | (同文) | 補助/見出しラベル | → LABEL_SHARE | → LABEL_SHARE |

### FormProfileSetting — MISSING（主なもの）
| コントロール | 型 | 領域 | 機能(コード根拠) | 提案EN | 提案JA |
|---|---|---|---|---|---|
| `dataGridViewProfile` | DataGridView | Panel1 | プロファイル一覧。行選択で編集対象、チェックで表示、色見本 | List of loaded profiles. Select a row to edit it below; the checkbox toggles its plot, the swatch shows its line color. | 読み込み済みプロファイルの一覧です。行を選ぶと下の各設定で編集でき、チェックで表示/非表示、色見本で線色を示します。 |
| `textBoxProfileName` | TextBox | groupBox3 | `dp.Name` 更新 | Display name of the selected profile (shown in lists and legends). | 選択中プロファイルの表示名を設定します。一覧や凡例に表示されます。 |
| `textBoxComment` | TextBox | groupBox3 | `dp.Comment`。処理に非影響 | Free-text comment stored with the selected profile; does not affect processing. | 選択中プロファイルに付ける任意のコメントを設定します。処理には影響しません。 |
| `colorControlLineColor` | ColorControl | groupBox3 | `dp.ColorARGB` 更新し再描画 | Sets the line/plot color of the selected profile. | 選択中プロファイルの線(プロット)の色を設定します。 |
| `numericUpDownLineWidth` | NumericUpDown | groupBox3 | `dp.LineWidth`(pt, 0.5刻み) | Sets the plot line width of the selected profile, in points (pt). | 選択中プロファイルのプロット線の太さを pt 単位で設定します。 |
| `buttonDeleteProfile` / `button1`(Delete all) | Button | 下部 | 現在行削除 / 全削除(確認あり) | Delete the selected profile / Delete ALL loaded profiles (confirms). | 選択中／すべてのプロファイルを削除します(全削除は確認あり)。 |
| `buttonUpper` / `buttonLower` | Button | 下部 | 一覧で現在行を上/下へ移動 | Move the selected profile up / down one position in the list. | 選択中プロファイルを一覧で1つ上／下へ移動します。 |
| `checkBoxTwoThetaOffset` | CheckBox | tabPage2 | `dp.DoesTwoThetaOffset`。Δ(2θ)=c0+c1·tan(θ)+c2·tan²(θ) 補正 | Step 1: Applies a 2θ-angle offset Δ(2θ)=c0+c1·tan(θ)+c2·tan²(θ) (angle-dispersive data only). | 手順1: 角度分散測定の回折角に Δ(2θ)=c0+c1·tan(θ)+c2·tan²(θ) のオフセット補正を適用します。 |
| `numericBoxTwhoThetaOffsetCoeff0/1/2` | NumericBox | panelTwoThetaOffset | `dp.TwoThetaOffsetCoeff0/1/2`。c0(定数)/c1(tanθ)/c2(tan²θ)、度 | Constant c0 / tan(θ) coefficient c1 / tan²(θ) coefficient c2 of the 2θ offset, in degrees. | 2θオフセット式の定数項 c0／tan(θ)項 c1／tan²(θ)項 c2（度）を設定します。 |
| `buttonTwoThetaOffsetReset` / `buttonTwoThetaCalibration` | Button | panelTwoThetaOffset | c0=c1=c2=0 / 校正フォーム表示切替 | Reset all three 2θ offset coefficients to zero / Open the calibration window (2θ offset from an internal standard). | 2θオフセット3係数を0に戻す／内部標準で2θオフセットを求める校正ウィンドウを開閉します。 |
| `checkBoxMaskingMode` | CheckBox | tabPage2 | `dp.DoesMaskAndInterpolate`。範囲をマスクし多項式補間で置換 | Step 2: Masks selected x-ranges and replaces them by polynomial interpolation. | 手順2: 指定した範囲をマスクし、多項式補間で置き換えます(アーティファクト除去等)。 |
| `checkBoxShowMaskedRange` | CheckBox | panelMaskingMode | グラフ上でマスク範囲設定モード | Enables setting/showing masking ranges directly on the graph by mouse. | グラフ上でマウス操作によりマスク範囲を設定・表示するモードを有効にします。 |
| `numericUpDownInterpolationOrder` | NumericUpDown | panelMaskingMode | `dp.InterpolationOrder`(0-5) | Polynomial order used to interpolate across masked ranges (0-5). Higher = more flexible. | マスク範囲を補間する多項式の次数(0〜5)。大きいほど曲線が柔軟になります。 |
| `listBoxMaskRanges` | ListBox | panelMaskingMode | マスク範囲一覧。.mas ドロップ読込 | List of masking ranges; select one to highlight, drop a .mas file to load. | マスク範囲(横軸の開始〜終了)の一覧。選択で強調、.masファイルをドロップで読込。 |
| `buttonDeleteMask` / `buttonDeleteAllMask` | Button | panelMaskingMode | 選択 1 件削除 / 全削除 | Delete the selected / all masking range(s). | マスク範囲を1件／すべて削除します。 |
| `toolStripMenuItemSaveMaskingRange` | MenuItem | contextMenu | .mas 保存（**本体コメントアウトで未実装/要確認**） | Save the current masking ranges to a .mas file. (要確認: disabled) | 現在のマスク範囲を .mas に保存します。(要確認: 実装無効) |
| `toolStripMenuItemReadMaskingRange` | MenuItem | contextMenu | .mas 読込 | Loads masking ranges from a .mas file. | .mas ファイルからマスク範囲を読み込みます。 |
| `checkBoxSmoothing` | CheckBox | tabPage2 | `dp.DoesSmoothing`。Savitzky-Golay 平滑化 | Step 3: Smooths the profile using a Savitzky-Golay filter. | 手順3: Savitzky-Golay フィルタでプロファイルを平滑化します。 |
| `numericUpDownSmoothingSavitzkyAndGolayM` | NumericUpDown | panelSmoothing | `dp.SazitkyGorayM`。窓幅(片側点数) | Savitzky-Golay window half-width (points each side). Larger = stronger smoothing. | Savitzky-Golay 平滑化の窓幅(片側点数)。大きいほど強く平滑化します。 |
| `numericUpDownSmoothingSavitzkyAndGolayN` | NumericUpDown | panelSmoothing | `dp.SazitkyGorayN`(0-5) | Savitzky-Golay polynomial order (0-5). Higher preserves peaks but smooths less. | Savitzky-Golay 平滑化の多項式次数(0〜5)。大きいほどピーク形状を保ちますが平滑化は弱まります。 |
| `checkBoxBandPassFilter` | CheckBox | tabPage2 | `dp.DoesBandpassFilter`。FFT 帯域通過 | Step 4: Applies an FFT bandpass filter to suppress unwanted frequency components. | 手順4: FFT によるバンドパスフィルタで不要な周波数成分を抑制します。 |
| `checkBoxHighPassFilter` | CheckBox | panelBandPassFilter | `dp.DoesHighPath`。低周波(長周期)除去 | Enables a high-pass filter: removes low-frequency (long-period) components below the threshold. | ハイパスフィルタを有効にし、しきい値より低い周波数(長周期)成分を除去します。 |
| `numericUpDownHighPass` | NumericUpDown | panelBandPassFilter | `dp.HighPathLimit`(横軸単位の逆数=周波数, データから動的) | High-pass cutoff frequency (1/[horizontal-axis unit]); components below it are removed. | ハイパスのしきい値(横軸単位の逆数=周波数)。これより低周波の成分を除去(範囲は自動)。 |
| `checkBoxLowPassFilter` | CheckBox | panelBandPassFilter | `dp.DoesLowPath`。高周波(短周期ノイズ)除去 | Enables a low-pass filter: removes high-frequency (short-period noise) components above the threshold. | ローパスフィルタを有効にし、しきい値より高い周波数(短周期ノイズ)成分を除去します。 |
| `numericUpDownLowPass` | NumericUpDown | panelBandPassFilter | `dp.LowPathLimit`(同上) | Low-pass cutoff frequency (1/[horizontal-axis unit]); components above it are removed. | ローパスのしきい値(横軸単位の逆数=周波数)。これより高周波の成分を除去(範囲は自動)。 |
| `checkBoxRemoveKalpha2` | CheckBox | tabPage2 | `dp.DoesRemoveKalpha2`。X線 Kα1 線源時のみ Kα2 除去 | Step 5: Strips the Kα2 contribution (only when the source is an X-ray Kα1 line). | 手順5: プロファイルから Kα2 成分を除去します(線源がX線 Kα1 の場合のみ)。 |
| `checkBoxBackgroundSubtraction` | CheckBox | tabPage2 | `dp.SubtractBackground` | Step 6: Subtracts a background curve from the profile. | 手順6: プロファイルからバックグラウンド曲線を差し引きます。 |
| `radioButtonBagkgroundBSpline` / `radioButtonBackgroundReferrence` | RadioButton | panelBackgroundSubtraction | B-スプライン点を通る曲線 / 別プロファイルを BG に | Define background as a B-spline through placed points / use another profile as reference background. | バックグラウンドを B-スプライン曲線／別プロファイル参照として定義します。 |
| `buttonBackgroundAutoDetectBG` | Button | panelBackgroundBSpline | `dp.BgPointsNumber` 個で BG 点自動検出 | Automatically place the specified number of background points along the profile. | 指定した点数でバックグラウンド点を自動配置します。 |
| `numericUpDownBgPointsNumber` | NumericUpDown | panelBackgroundBSpline | `dp.BgPointsNumber`(3-50) | Number of background points (3-50) for auto-detection / B-spline fitting. | 自動検出・B-スプライン用のバックグラウンド点の数(3〜50)を設定します。 |
| `comboBoxBackgroundReferrence` | ComboBox | panelBackgroundReferrence | `dp.BackgroundReferrenceProfile` | Selects which loaded profile is used as the reference background. | 参照バックグラウンドとして差し引くプロファイルを選択します。 |
| `numericUpDownBackgroundReferrenceScale` | NumericUpDown | panelBackgroundReferrence | `dp.BackgroundReferrenceScale`(倍率) | Scale factor multiplied to the reference background before subtraction. | 参照バックグラウンドに掛ける倍率を設定します。 |
| `checkBoxShowBackgroundProfile` | CheckBox | panelBackgroundSubtraction | BG 曲線をグラフ表示 | Shows/hides the background curve on the graph (subtraction must be on). | バックグラウンド曲線をグラフに表示/非表示します。 |
| `checkBoxNormarizeIntensity` | CheckBox | tabPage2 | `dp.DoesNormarizeIntensity` | Step 7: Normalizes the intensity within a chosen x-range to a target value. | 手順7: 指定範囲内の強度を目標値に規格化します。 |
| `radioButtonNormarizeAverage` / `radioButtonNormarizeMaximum` | RadioButton | panelNormarizeIntensity | 範囲内の平均 / 最大 を基準に規格化 | Normalize so the AVERAGE / MAXIMUM intensity in the range equals the target. | 範囲内の平均／最大強度が目標値になるよう規格化します。 |
| `numericUpDownNormarizeRangeLow/High` | NumericUpDown | panelNormarizeIntensity | `dp.NormarizeRangeStart/End`(横軸単位) | Lower / upper bound (horizontal-axis units) of the normalization range. | 規格化の基準とする横軸範囲の下端／上端を設定します。 |
| `numericUpDownNormarizeIntensity` | NumericUpDown | panelNormarizeIntensity | `dp.NormarizeIntensity`(1-100000) | Target intensity (1-100000) the range's average/maximum is scaled to. | 範囲の平均/最大強度を合わせる目標強度値(1〜100000)を設定します。 |
| `buttonApplyAllProfiles` | Button | tabPage2 | 現在の処理設定を全プロファイルへ(BG除く) | Applies the current processing settings to ALL profiles (background settings excluded). | 現在の各処理設定を、バックグラウンド設定を除き全プロファイルに適用します。 |
| `xAxisUserControl` | HorizontalAxisUserControl | tabPage3 | `dp.SrcProperty`(AxisMode/線源/波長/取り出し角) | Edits the source horizontal-axis settings (axis type 2θ/d/energy/TOF, source, wavelength, takeoff angle). Apply with "Change". | 線源の横軸設定(横軸種別 2θ/d/エネルギー/TOF、線源、波長、取り出し角)を編集します。「Change」で確定。 |
| `buttonChangeSourceXAxis` | Button | tabPage3 | 上記設定と露光時間を反映 | Applies the edited horizontal-axis source settings (and exposure time) to the profile. | 編集した横軸の線源設定(と露光時間)を反映します。 |
| `checkBoxShiftHorizontalAxis` / `numericUpDownShiftHorizontalAxis` | CheckBox/NumericUpDown | tabPage3 | `dp.IsShiftX`/`dp.ShiftX`。横軸平行移動 | Shift the entire profile along the horizontal axis by a fixed amount (horizontal-axis units). | プロファイル全体を横軸方向に一定量だけ平行移動します(横軸単位)。 |
| `numericalTextBoxExposureTime` | NumericBox | tabPage3 groupBox2 | `dp.ExposureTime`(秒, CPS換算用) | Exposure time in seconds, used to convert intensity to counts-per-second (CPS). | 縦軸を CPS(毎秒カウント)表示に換算する際の露光時間(秒)を設定します。 |
| `radioButtonAverage` / `radioButtonProfileAndValue` / `radioButtonTwoProfiles` | RadioButton | tabPage1 | 平均(誤差伝播) / プロファイル±定数 / 2プロファイル四則 | Operator mode: average multiple profiles / combine one profile with a constant / +,-,×,÷ between two profiles. | 演算モード: 複数プロファイルの平均／1プロファイルと定数値の演算／2プロファイル間の四則演算。 |
| `radioButtonAddition/Subtraction/Mutiplication/Division` | RadioButton | flowLayoutPanelFourCalculator | 加減乗除を選択(Text 空のものは要確認) | Selects addition / subtraction / multiplication / division. | 演算として加算／減算／乗算／除算を選びます。 |
| `numericalTextBoxTargetValue` | NumericBox | flow | "Profile and value" の定数値 | Constant value combined with the profile in "Profile and value" mode. | 「Profile and value」モードで演算する定数値を設定します。 |
| `listBoxTwoProfiles1` / `listBoxTwoProfiles2` | ListBox | panel1 | 第1(主)/第2 プロファイル選択 | Selects the first (primary, multi-select in Average mode) / second profile for the operation. | 演算の第1(主、平均は複数可)／第2プロファイルを選択します。 |
| `textBoxOutputFilename` | TextBox | tabPage1 | 生成プロファイル名(末尾連番自動++) | Name of the result profile (trailing number auto-increments). | 演算結果として生成するプロファイル名(計算ごとに末尾連番が増加)。 |
| `buttonCalculate` | Button | tabPage1 | 選択モードで新規プロファイル生成 | Performs the selected operation and adds the result as a new profile. | 選択した演算を実行し、結果を新しいプロファイルとして追加します。 |

### FormProfileSetting — LABEL_SHARE（抜粋）
見出しラベルは対応入力と同文案を共有: `label21`/`label20`→InterpolationPoints、`label17`/`label10`→SavitzkyGolayM、`label5`→SavitzkyGolayN、`label19`→InterpolationOrder、`label11`→BgPointsNumber、`label2`→LineColor、`label7`/`label9`(pt)→LineWidth、`label22`→Comment、`label8`→ProfileName、`label13`/`label16`/`label3`→NormarizeRange、`label25`(Δ(2θ)=)→OffsetCoeff、`label1`/`label6`/`label24`→ExposureTime、`label12`→ShiftX、`label4`(×)→ReferrenceScale、`label18`→OutputFilename。

> 要確認: High/Low pass の変数名が直感と逆（`checkBoxLowPassFilter`「Cut high-freq. over」が `DoesLowPath`、`checkBoxHighPassFilter`「Cut low-freq. under」が `DoesHighPath`）。文案はラベル文言基準。`toolStripMenuItemSaveMaskingRange` は本体未実装。`radioButtonMutiplication`/`Division` は Text 空（要確認）。

## B-3. FormAtomicPositionFinder

### FormAtomicPositionFinder — 概要
観測粉末回折強度から、化学組成・単位格子・空間群候補を制約に、原子座標(分率 x,y,z)をモンテカルロ＋遺伝的アルゴリズムで探索・精密化し、信頼度因子 R(`GetResidualValue`)の小さい構造候補を提示。3 タブ(Symmetry/Chemistry/Diffraction Data)で入力、下段でアルゴリズム比率・イオン半径制約・スレッド数を設定し Find/Resume 実行、R 収束グラフと候補一覧(`dataGridView2`)を表示。File メニューで条件一式を XML 保存/読込。操作系 約35個(112元素入力群を1グループ換算)。**tip 皆無・ja.resx 未作成→ (c) 部品追加・ja.resx 新設**。

### FormAtomicPositionFinder — MISSING（主なもの）
| コントロール | 型 | 領域 | 機能(コード根拠) | 提案EN | 提案JA |
|---|---|---|---|---|---|
| `comboBoxCrystalSystem` | ComboBox | tabPage1 | 結晶系選択。格子定数の編集可否を制約し空間群候補を列挙 | Crystal system (triclinic to cubic). Constrains the editable cell parameters and lists the matching space groups. | 結晶系(triclinic〜cubic)を選択します。編集できる格子定数が制限され、空間群候補一覧が更新されます。 |
| `numericBoxA/B/C` | NumericBox | groupBox4(`Å`) | 単位格子 a/b/c 軸長。高対称系で連動/固定(`setnumericTextBoxState`) | Unit-cell edge length a/b/c (Å). For high-symmetry systems b/c are auto-linked to a or fixed. | 単位格子の a/b/c 軸長(Å)。対称性の高い結晶系では a に連動/固定されます。 |
| `numericBoxAlpha/Beta/Gamma` | NumericBox | groupBox4(`°`) | 格子角 α/β/γ。結晶系で 90°/120° 等に自動固定 | Unit-cell angle alpha/beta/gamma (deg). Auto-fixed (90/120 deg) per crystal system. | 格子角 α/β/γ(度)。結晶系に応じ 90°/120° 等に自動固定されます。 |
| `listBoxSpaceGroupCandidate` | ListBox(MultiSimple) | tabPage1 | 探索対象空間群候補を複数選択(Hermann-Mauguin 記号) | Candidate space groups (number.sub: Hermann-Mauguin). Select one or more; each is searched. Multi-select. | 探索対象の空間群候補(番号.副番号: Hermann-Mauguin 記号)。複数選択でき、各候補で構造探索します。 |
| `textBoxInputFormula` | TextBox | tabPage2 | 化学式入力→各元素原子数と Z を自動算出 | Chemical formula (e.g. "Ti O2"). Parsed to fill per-element atom counts and the formula-unit count Z. | 化学式(例: Ti O2)を入力します。各元素の原子数欄と式単位数 Z が自動計算されます。 |
| `numericUpDownZ` | NumericUpDown | tabPage2 | 式単位数 Z(最小1) | Number of formula units per unit cell, Z (min 1). Multiplies the formula to give total atoms. | 単位格子あたりの式単位数 Z(最小1)。組成式に掛けて単位格子内の全原子数を決めます。 |
| `textBoxFormula` | TextBox(ReadOnly) | tabPage2 | 単位格子内全原子組成(表示) | Read-only: total composition in the unit cell (formula × Z); updates automatically. | 単位格子内の全原子組成(組成式×Z、読み取り専用)。自動更新されます。 |
| `numericTexBox[1..111]` | NumericBox×111 | tabPage2 | 周期表配置の各元素原子数入力→組成式/Z 逆算 | Atom count of this element in the unit cell (periodic-table layout). Editing recomputes the formula and Z. | この元素の単位格子内の原子数(周期表配置)。値を変えると組成式と Z が再計算されます。 |
| `waveLengthControl1` | WaveLengthControl | groupBox1 | 波源・波長(d→2θ 変換と回折強度計算に使用) | X-ray wave source and wavelength used to convert d-spacings to angles and to compute intensities. | 波源(X線等)と波長。面間隔から回折角への変換と回折強度計算に使われます。 |
| `numericalTextBoxDspacing` | NumericBox | tabPage3(`Å`) | 追加ピークの d 値(内部 ×0.1 nm) | d-spacing (Å) of a peak to add to the table via Add Peak. | 表に追加するピークの面間隔 d(Å)。Add Peak で追加します。 |
| `numericalTextBoxIntensity` | NumericBox | tabPage3 | 追加ピークの相対強度(rel%)。R 計算で最大値規格化 | Relative diffraction intensity (rel %) of the peak. Normalized to the strongest peak for the R-factor. | 追加ピークの相対回折強度(rel %)。R 因子計算時は最強ピークで規格化されます。 |
| `buttonAddPeak` | Button | tabPage3 | d/強度を表に1行追加し再指数付け | Add the entered d-spacing and intensity as a new row in the peak table. | 入力した d 値と強度を回折ピーク表に追加します。 |
| `buttonReindexPeaks` | Button | tabPage3 | 現格子定数・空間群で全 hkl 再計算 | Recompute hkl (Miller) indices for all peaks from the current cell and space group. | 現在の格子定数と空間群で全ピークの hkl 指数を再計算します。 |
| `buttonTest` | Button | tabPage3 | (開発用)クリップボード TSV から表再構築 | (Debug) Import peaks from clipboard tab-separated text (col0=d, col4=intensity). | (デバッグ用)クリップボードのタブ区切り(0列=d,4列=強度)から表を置換します。 |
| `dataGridViewDiffractionPeaks` | DataGridView | tabPage3 | 観測ピーク一覧(Check/d/Intensity/Delete/Index) | Observed peaks. Check to include in the search, Delete to remove; Index shows the assigned hkl. | 観測回折ピーク一覧。Check で探索対象、Delete で削除、Index に割当 hkl を表示。 |
| `radioButtonAngleThreshold` / `numericUpDownAngleThreshold` | RadioButton/NumericUpDown | groupBox2(`°`,0-2) | 角度しきい値で近接反射を併合(既定) | Merge reflections whose 2θ differ by less than the angle threshold (deg, 0-2). | 回折角の差がしきい値(度,0〜2)未満の反射を1本に併合します。 |
| `radioButtonEnergyThreshold` / `numericUpDownEnergyThreshold` | RadioButton/NumericUpDown | groupBox2(`eV`,0-10) | エネルギーしきい値で併合（**現コードは Angle 分岐のみ有効・要確認**） | Merge by an energy threshold (eV, 0-10) instead (note: energy branch may be inactive). | エネルギーしきい値(eV,0〜10)で併合します（現コードでは無効の可能性・要確認）。 |
| `numericUpDownRandomization` | NumericUpDown | groupBox6(`%`,既定95) | ランダム原子配置生成確率。3確率は合計100%に自動正規化 | Probability (%) of generating a new random arrangement each step. The three probabilities auto-normalize to 100%. | 原子配置を新規ランダム生成する確率(%,既定95)。3確率は合計100%に自動調整。 |
| `numericUpDownHybridization` | NumericUpDown | groupBox6(`%`,既定2) | 既存候補2つの交叉(遺伝的)確率 | Probability (%) of genetic-algorithm crossover hybridizing two existing candidates. | 既存候補2つを掛け合わせる遺伝的交叉の確率(%,既定2)。 |
| `numericUpDownShaking` | NumericUpDown | groupBox6(`%`,既定3) | 既存候補の座標を微小変位させる確率 | Probability (%) of "shaking" (slightly perturbing the atomic positions of a candidate). | 既存候補の原子座標をわずかに揺らす確率(%,既定3)。 |
| `numericUpDownIonRadiusThreshold` | NumericUpDown | groupBox3(`%`,既定70) | 原子重なり判定の許容係数(イオン半径和×係数) | Allowance (%) on the sum of ionic radii to reject overlapping atoms. Lower rejects more. | 原子の重なり判定に用いるイオン半径和の許容係数(%,既定70)。小さいほど近接配置を強く棄却。 |
| `flowLayoutPanelIonicRadius`(UserControlIonicRadius 群) | UserControl | groupBox3 | 各元素のイオン半径(nm)入力。重なり判定に使用 | Ionic radius (nm) of each element in the composition, used with the allowance to detect overlaps. | 組成中の各元素のイオン半径(nm)。上の許容係数と組み合わせ重なりを判定します。 |
| `buttonStart` | Button | 下段 | 探索を新規開始(候補クリア)。実行中は "Stop!" | Start a new search from scratch (clears candidates). Shows "Stop!" while running. | 構造探索を新規開始します(候補クリア)。実行中は "Stop!" で中断。 |
| `buttonResume` | Button | 下段 | 現候補を初期集団に探索再開 | Resume using the current candidate list as the starting population. | 現在の候補一覧を初期集団として探索を再開します。 |
| `numericUpDownThreadTotal` | NumericUpDown | 下段(1-16,既定2) | 並列探索スレッド数 | Number of parallel worker threads (1-16). Higher uses more CPU cores. | 探索に使う並列スレッド数(1〜16,既定2)。 |
| `dataGridView2` | DataGridView | 下段 | 候補一覧(Residual=R, Info=空間群/ワイコフ/座標)。行クリックで FormCrystal 転送＋コピー | Found candidates sorted by R. Residual=R; Info lists space group, Wyckoff sites and coordinates. Click a row to send it to the Crystal form and copy it. | 探索結果の構造候補(R昇順)。Residual=R、Info=空間群・ワイコフ位置・座標。行クリックで Crystal フォームへ送りコピーします。 |
| `readFileToolStripMenuItem` / `saveFileToolStripMenuItem` | MenuItem | File | 探索条件一式を XML 読込/保存 | Load / save a session (composition, symmetry, peaks, candidates, ionic radii, settings) as XML. | セッション一式(組成・対称性・ピーク・候補・イオン半径・設定)を XML で読込／保存します。 |

LABEL_SHARE: `label19`→CrystalSystem、`label23/18`→A、…各軸/角ラベル→対応 NumericBox、`label1`→Formula、`label2`→Z、`label3`→textBoxFormula、`label14/13`→Dspacing、`label15`→Intensity、`label31`→ThreadTotal 等。
> 要確認: Energy しきい値分岐が無効の可能性。groupBox6 のラベルが二重定義(label6〜11 と label17/20/21/22/29/30)で配置実態は要確認。

---

## B-4. FormCellFinder

### FormCellFinder — 概要
観測 d 値リストから格子定数(a,b,c,α,β,γ)を自動指数付け(auto-indexing)で総当たり探索。波源(波長)・晶系・格子定数の探索範囲を指定し Find! でモンテカルロ的に候補セルを生成、評価指標 R / ΣdQ の小さい順に最良 300 件を表示。**ja.resx 無し→ (c) 部品追加・ja.resx 新設**。内部では長さ nm 換算(入力 Å ÷10)、角度ラジアン。

### FormCellFinder — MISSING
| コントロール | 型 | 領域 | 機能(コード根拠) | 提案EN | 提案JA |
|---|---|---|---|---|---|
| `loadToolStripMenuItem` | MenuItem | File | テキストの 4 行目以降を d 値として読込(先頭3行はヘッダ) | Load a text file of observed d-spacings (one per line; first 3 lines skipped as header). | 観測 d 値のテキストファイルを読み込みます(1行1値、先頭3行はヘッダ)。 |
| `comboBoxCrystalSystem` | ComboBox | 上部 | 晶系で未知数(triclinic=6…cubic=1)を決定 | Crystal system to search. Sets the number of free parameters (triclinic=6 … cubic=1). | 探索する晶系を選びます。未知数(triclinic=6〜cubic=1)が決まり、高対称ほど高速・拘束強。 |
| `numericUpDownMinA/MaxA`(B,C 同様) | NumericUpDown | groupBox1(`Å`,既定2.0-20.0) | a/b/c 軸長の探索下限/上限。範囲外を棄却 | Lower / upper bound of axis length a/b/c (Å). Out-of-range candidates are rejected. | 探索する軸長 a/b/c の下限/上限(Å)。範囲外の候補は棄却します。 |
| `numericUpDownMinAlpha/MaxAlpha`(β,γ 同様) | NumericUpDown | groupBox1(`°`,既定60-150) | 軸間角の探索下限/上限(上限180) | Lower / upper bound of interaxial angle α/β/γ (deg, max 180). | 探索する軸間角 α/β/γ の下限/上限(度,上限180)。 |
| `waveLengthControl1` | WaveLengthControl | groupBox3 | 波源・波長(既定 Cu Kα1 0.15418nm) | Radiation source and wavelength for d-spacing conversion (default Cu Kα1, 0.15418 nm). | 観測 d 値の換算に用いる波源・波長(既定 Cu Kα1, 0.15418 nm)。 |
| `numericalTextBox1` | NumericBox | groupBox2(`Å`) | 追加ピークの観測 d 値 | Observed d-spacing (Å) of the peak to add below. | 一覧に追加するピークの観測 d 値(Å)。 |
| `comboBoxReliability` | ComboBox | groupBox2 | 信頼度(High/Medium/Low)→最小二乗の重み(1/0.5/0.1) | Reliability of the peak (High/Medium/Low); weights the fit (1 / 0.5 / 0.1). | 追加ピークの信頼度(High/Medium/Low)。最小二乗の重み(1/0.5/0.1)に反映。 |
| `buttonAddPeak` | Button | groupBox2 | d 値・信頼度を一覧に追加 | Add the entered d-spacing and reliability to the peak list. | 入力した d 値と信頼度を一覧に追加します。 |
| `dataGridView1` | DataGridView | groupBox2 | 入力ピーク表(Use for Calc./Reliability/d_obs 編集, Delete)。探索後 hkl/d_calc/diff | Editable peak list (Use for Calc., reliability, d_obs; Delete). After a search, hkl/d_calc/diff appear. | 観測ピークの編集一覧(Use for Calc.・信頼度・d_obs、Delete)。探索後に hkl・d_calc・diff を表示。 |
| `buttonFind` | Button | 左下 | 探索 開始/停止トグル | Start the auto-indexing search; click again ("Stop!") to cancel. | 自動指数付け探索を開始/停止します(実行中は "Stop!")。 |
| `button1`("Resume!") | Button | 左下 | 既存候補保持で再開(同ハンドラ) | Resume the search keeping current candidates (shares the Find! handler). | 候補をクリアせず探索を再開します。 |
| `buttonSendToAtomicPositionFinder` | Button | 結果上 | 選択セルを APF へ送る想定だが**ハンドラ空・要確認** | Send the selected candidate cell to the Atomic Position Finder. (Handler currently empty — 要確認) | 選択候補セルを Atomic Position Finder へ送ります(現状未実装・要確認)。 |
| `dataGridViewResult` | DataGridView | 右上 | 候補セル一覧(a..γ,Volume,ΣdQ,R)。行選択で hkl 反映・分布図強調 | Candidate cells (best 300) sorted by R; click a row to apply its hkl and highlight on the map. ΣdQ/R are figures of merit (smaller better). | 候補セル一覧(R昇順,最良300)。行クリックで入力表に hkl 反映・分布図強調。ΣdQ・R は評価指標(小さいほど良)。 |
| `comboBoxX` / `comboBoxY` | ComboBox | 右下 | 分布図の X/Y 軸パラメータ(a..γ)選択 | Lattice parameter (a..γ) plotted on the map's X / Y axis. | 分布図の X／Y 軸に表示する格子定数(a..γ)を選びます。 |
| `distributionGraphControl1` | DistributionGraphControl | 右下 | 候補セルの(X,Y)分布を R で色付け | Scatter map of candidates in X–Y parameter space, colored by R. | 選択 X–Y 空間での候補セルの散布図(R で色付け)。 |

LABEL_SHARE: `label19`→CrystalSystem、`groupBox1`→Min/Max 群、各軸/角・単位ラベル→対応入力、`label8`→Reliability、`label10/11`→comboBoxY/X、`groupBox3`→waveLengthControl1。

---

## B-5. FormSequentialAnalysis

### FormSequentialAnalysis — 概要
FormMain に読み込んだ一連の回折プロファイルを 1 件ずつ自動フィットし、2θ・d・FWHM・積分強度・格子定数・圧力・Singh の式パラメータをファイル順に並べて出力する一括(連続)解析フォーム(`buttonExecute_Click`)。実行には Fitting フォームでピークをチェック済みである必要あり。応力解析(ファイル名末尾角度を読む)では Singh の式も最適化。結果は各タブテキストに蓄積し Copy/Save/自動保存で CSV 出力。**ja.resx 有り→ (c) 部品追加**。

### FormSequentialAnalysis — MISSING
| コントロール | 型 | 領域 | 機能(コード根拠) | 提案EN | 提案JA |
|---|---|---|---|---|---|
| `buttonExecute` | Button | panel1 | 連続解析実行。Fitting 未表示なら警告中止、全プロファイル順次フィット | Run the sequential analysis: fit every loaded profile and tabulate 2θ, d, FWHM, intensity, cell constants and pressure. Requires the Fitting form open with peaks checked. | 連続解析を実行します。全プロファイルを順にフィットし 2θ・d・FWHM・強度・格子定数・圧力を出力します。Fitting でピークをチェックしておく必要があります。 |
| `buttonCopy` / `buttonSave` | Button | panel1 | アクティブタブをタブ区切りでコピー / CSV 保存 | Copy the active tab's table (tab-separated) / Save it to a CSV file. | 表示中タブの表をクリップボードにコピー／CSV に保存します。 |
| `checkBoxStartNumber` / `numericBoxStartNumber` | CheckBox/NumericBox | panel1 | 指定番号(先頭=0,最小1)から解析開始 | Start from the profile number set at right (first profile = 0); the box is enabled only when checked. | 解析を右で指定した番号(先頭0,最小1)から開始します。チェック時のみ入力可。 |
| `checkBoxLoop` | CheckBox | panel1 | 末尾到達後に飛ばした先頭側(0〜開始-1)も処理 | When starting from a number, also process the skipped earlier profiles after reaching the end (wrap around). | 開始番号指定時、末尾まで処理後に飛ばした先頭側(0〜開始-1)も続けて処理します。 |
| `checkBoxToleranceFactor` / `numericBoxToleranceFactor` | CheckBox/NumericBox | panel1(`%`,0-100) | 体積変化が許容係数超で結果を NaN 棄却 | Reject a fit (output NaN) when the refined cell volume changes by more than the tolerance (%, 0-100). | フィット後の体積が初期から許容係数(%,0〜100)を超えて変化したら結果を NaN として棄却します。 |
| `checkBoxAutoSaveTwoTheta/D/FWHM/Int/Cell/Pressure/Singh` | CheckBox | 各タブ | 解析後に各結果を `*_2theta.csv` 等で自動保存 | Automatically save the corresponding results to "*_<kind>.csv" after analysis. | 解析後に該当結果を "*_<種別>.csv" として自動保存します。 |
| `buttonSetDirectory` / `textBoxDirectory` | Button/TextBox | panel1 | 自動保存先フォルダ選択 / パス表示(ReadOnly) | Choose / show the destination folder for auto-saved CSV files. | 自動保存先フォルダを選択／パスを表示します(読み取り専用)。 |
| `textBox2theta/Dspacing/FWHM/Intensity/CellConstants/Pressure/Singh` | TextBox | 各タブ | プロファイルごとの結果を蓄積表示 | Per-profile results: 2θ(°) / d(Å) / FWHM(°) / integrated intensity / cell constants & errors / pressure(GPa) / Singh parameters. | プロファイルごとの 2θ(°)／d(Å)／FWHM(°)／積分強度／格子定数と誤差／圧力(GPa)／Singh パラメータを表示します。 |
| `graphControl1` | GraphControl | tabPageSingh | Singh の式の d–Ψ(0〜360°)曲線描画 | Plot of the fitted Singh's-equation d-spacing vs. azimuth Ψ (0-360°). | フィットした Singh の式の d 値–方位角 Ψ(0〜360°)曲線を表示します。 |
| `tabControl` | TabControl | 中央 | 結果カテゴリ切替(Copy/Save はアクティブタブ対象) | Switch result categories; Copy/Save act on the selected tab. | 結果の種類を切り替えます。コピー/保存は表示中タブが対象です。 |

> 注: Auto save 群はラベル文言が同一なので tip で各出力サフィックスを明記し区別する。`buttonSendToAtomicPositionFinder`(CellFinder) や出力専用列/ステータスラベルは tip 不要。

## B-6. 中小フォーム

### FormExportGSAS（ja.resx: 無）
プロファイルを GSAS(Rietveld 解析データ)形式で書き出すダイアログ。`.gsa` 本体プレビュー＋任意で `.exp` テンプレ。**注意: `buttonOK` に Click ハンドラが無く `.exp` 書出しロジックは未実装**(`atmdat` 空)。チェックボックス群は現状 UI のみ・実効未接続のため機能根拠は「ラベル＋仕様」推定（要確認）。

| コントロール | 型 | 機能 | 提案EN | 提案JA |
|---|---|---|---|---|
| `checkBox7`(Create Exp file) | CheckBox | `.exp` も生成するか | If checked, also generate a GSAS .exp experiment file alongside the .gsa data file. | チェックすると .gsa データに加えて GSAS の .exp 実験ファイルも生成します。 |
| `checkBox2`(Use template file) | CheckBox | 既存 .exp をテンプレに | Base the new .exp file on an existing template .exp specified below. | 下で指定する既存の .exp をテンプレートとして使用します。 |
| `textBoxExpFilePath` | TextBox | テンプレ .exp パス(内容プレビュー) | Path to the template .exp file; its contents are previewed below. | テンプレートとする .exp のパス。内容が下にプレビュー表示されます。 |
| `buttonOpen` | Button | .exp 参照 | Browse for a template .exp file. | テンプレートの .exp を参照して選択します。 |
| `checkBox1`(Overwrite…) | CheckBox | 同名相を下記項目で上書き | If the crystal phase already exists in the template, overwrite it with the items below. | テンプレに同じ結晶相がある場合、下で選んだ項目で上書きします。 |
| `checkBox3/4/5/6` | CheckBox | 格子定数/座標/占有率/変位パラメータU を書出 | Write the cell constants / atomic coordinates / site occupancies / displacement parameters U into the .exp file. | 格子定数／原子座標／占有率／変位パラメータU(温度因子) を .exp に書き出します。 |
| `buttonOK` / `buttonCancel` | Button | 確定/取消 | Confirm and export the GSAS file(s) / Cancel without exporting. | GSAS ファイルを書き出す／書き出さず閉じます。 |

### FormPrintOption（ja.resx: 無）
印刷項目とプロファイル名位置を選ぶダイアログ。`checkBoxPrintProfileName` OFF で位置選択(flowLayoutPanel)を無効化。
| コントロール | 機能 | 提案EN | 提案JA |
|---|---|---|---|
| `checkBoxPrintProfile` | プロファイル曲線を印刷 | Include the diffraction profile curve in the printout. | 回折プロファイル曲線を印刷に含めます。 |
| `checkBoxPrintProfileName` | 名前を印刷(位置は下のボタン) | Print the profile name label; its position is set by the buttons below. | プロファイル名を印刷します。位置は下のボタンで指定します。 |
| `checkBoxPrintDiffractionPeak` | 回折ピーク(指数線)を印刷 | Include the marked diffraction peaks (index lines) in the printout. | 回折ピーク(指数線)を印刷に含めます。 |
| `radioButtonUpperLeft/UpperRight/LowerLeft/LowerRight` | 名前を四隅に配置(既定 UpperRight) | Place the profile name in the upper-left / upper-right (default) / lower-left / lower-right corner. | プロファイル名を左上／右上(既定)／左下／右下に配置します。 |
| `button1`(OK) / `button2`(Cancel) | 適用/取消 | Apply these print options / Cancel without changing them. | 印刷オプションを適用／変更せず取消します。 |

### FormLimitChanger（ja.resx: 無）
グラフ X/Y 軸の表示範囲(最小・最大)を数値入力する小ダイアログ。`.cs` は空、4 NumericUpDown は public で呼出側が読む。**注: Designer は全 Min=1/Max=180(X軸=度向け)。Y軸には不自然で呼出側上書きの可能性・要確認**。
| コントロール | 機能 | 提案EN | 提案JA |
|---|---|---|---|
| `numericUpDownMinX` / `numericUpDownMaxX` | X軸表示範囲 下限/上限 | Lower / upper limit of the horizontal-axis (X) display range. | 横軸(X)表示範囲の下限／上限を設定します。 |
| `numericUpDownMinY` / `numericUpDownMaxY` | Y軸(強度)表示範囲 下限/上限 | Lower / upper limit of the vertical-axis (Y, intensity) display range. | 縦軸(Y,強度)表示範囲の下限／上限を設定します。 |
| `buttonOK` / `buttonCancel` | 適用/取消 | Apply the new axis limits / Cancel without changing them. | 新しい軸範囲を適用／変更せず取消します。 |

### FormTwoThetaCalibration（ja.resx: 無）
標準物質ピークの観測 2θ と計算 2θ の差から 2θ シフト関数係数を最小二乗で求め、プロファイルの 2θ オフセットを較正。`buttonCalibrate_Click` が 8 回反復、`buttonRevert_Click` が較正前に戻す。Fitting 表示時のみ有効。
| コントロール | 機能 | 提案EN | 提案JA |
|---|---|---|---|
| `numericUpDownOrder` | Δ(2θ)=a1+a2·tanθ+a3·tan²θ の項数(1-3) | Number of terms (1-3) in the shift function Δ(2θ)=a1+a2·tanθ+a3·tan²θ. 1=zero-offset only; higher fits angle-dependent shift. | シフト関数 Δ(2θ)=a1+a2·tanθ+a3·tan²θ の項数(1〜3)。1はゼロ点のみ、上げると角度依存ずれも補正します。 |
| `buttonCalibrate` | 反復フィットで係数更新(Fitting 要表示) | Iteratively fit observed vs. calculated 2θ of the standard and update the 2θ offset coefficients (requires the Fitting window open). | 標準物質の観測/計算 2θ 差を反復フィットし 2θ オフセット係数を更新します(Fitting 窓が必要)。 |
| `buttonRevert` | 較正前係数に戻す | Restore the 2θ offset coefficients to the values before the last calibration. | 2θ オフセット係数を直前の較正前の値に戻します。 |

### FormLPO（ja.resx: 無）
複数方位のピーク強度から格子選択配向(LPO,集合組織)を逆解析し a/b/c 軸の極点図を描く。**`buttonGetPeakIntensities_Click` は本体が全コメントアウト(現状 no-op)**、`buttonAnalyze_Click` が反復推定。
| 分類 | コントロール | 機能 | 提案/改善EN | 提案/改善JA |
|---|---|---|---|---|
| WRONG/THIN | `buttonGetPeakIntensities` | 現EN "Before push below button…" は本ボタン自身を指し誤誘導＋現状 no-op | Before pressing this button, select/check the target crystal and set the fitting parameters of its diffraction peaks; this collects the peak intensities at each measured orientation. | このボタンを押す前に対象結晶を選択・チェックし、回折ピークのフィッティング条件を設定してください。各測定方位でのピーク強度を取得します。 |
| MISSING | `buttonAnalyze` | 強度比から方位分布を反復推定し極点図描画 | Run the lattice-preferred-orientation (texture) inversion and draw the pole figures for the a, b, c axes. | 取得した強度から格子選択配向(集合組織)を逆解析し、a・b・c 軸の極点図を描画します。 |
| MISSING | `numericUpDownResolution` | 方位空間グリッド一辺分割数(総セル=値³,既定80) | Orientation-grid resolution per axis; total cells = value³ (default 80). Higher = finer but slower. | 方位空間グリッドの一辺の分割数(総セル数=値³,既定80)。大きいほど高精細だが低速。 |
| MISSING | `numericUpDownHWHM` | 配向ガウス分布の半値半幅(度,0-30,既定5) | Half-width at half-maximum (deg, 0-30) of the Gaussian orientation spread used in the inversion. | 逆解析で用いる配向ガウス分布の半値半幅 HWHM を度単位(0〜30,既定5)で指定します。 |

### FormDataConverter（ja.resx: 有・部分訳）
読み込んだデータの横軸種別・波長/エネルギー・露出時間を設定して変換するダイアログ。EDX 用グループ(低エネルギーカット＋検出器ごとの EDXControl 群)あり。
| コントロール | 機能 | 提案EN | 提案JA |
|---|---|---|---|
| `numericalTextBox1`(Exposure time) | 1ステップの露出時間(秒,≤0は1) | Exposure (measurement) time per data step, in seconds. Values ≤0 are treated as 1. | データ1ステップあたりの露出(測定)時間を秒で設定します。0以下は1として扱われます。 |
| `checkBoxLowEnergyCutoff` | EDX 低エネルギー側カット有効化 | Enable cutting off the low-energy side of the EDX spectrum below the threshold at right. | EDX スペクトルの低エネルギー側を右の閾値以下で切り捨てます。 |
| `numericBoxLowEnergyCutoff`(`eV`,既定10000) | カット閾値 | Energy threshold (eV) below which the EDX spectrum is discarded. | この値(eV)未満の EDX スペクトルを切り捨てます。 |
| `horizontalAxisUserControl` | 横軸種別と線源パラメータ設定 | Set the data's horizontal-axis type and source parameters (wavelength/energy, 2θ, TOF length/angle). | データの横軸種別と関連パラメータ(波長/エネルギー・2θ・TOF 距離/角度)を設定します。 |
| `buttonOK` / `buttonCancel` | 変換実行/取消 | Apply the settings and convert the data / Cancel the conversion. | 設定を適用してデータを変換／変換を取消します。 |

### EDXControl（ja.resx: 無）
EDX(エネルギー分散X線)で 1 検出器分のエネルギー較正係数を入力する UserControl。較正式 `E = a₀ + a₁·n + a₂·n²`(E:eV, n:チャンネル番号)。FormDataConverter に検出器数だけ並ぶ。
| コントロール | 機能 | 提案EN | 提案JA |
|---|---|---|---|
| `checkBox1`(検出器名 例"#0") | この検出器を使用するか(`Valid`) | Enable this EDX detector; its label shows the detector number. | この EDX 検出器を使用します。ラベルは検出器番号を示します。 |
| `numericBoxEGC0`(a₀) | 較正式の定数項(eV,オフセット) | Constant term a₀ (eV offset) of the energy calibration E = a₀ + a₁·n + a₂·n² (n = channel number). | エネルギー較正式 E=a₀+a₁·n+a₂·n²(n:チャンネル番号)の定数項 a₀(eV,オフセット)を設定します。 |
| `numericBoxEGC1`(a₁) | 1次(ゲイン)項(eV/channel) | Linear gain term a₁ (eV per channel) of the energy calibration. | 較正式の1次(ゲイン)項 a₁(eV/チャンネル)を設定します。 |
| `numericBoxEGC2`(a₂) | 2次(非線形)項(eV/channel²) | Quadratic (nonlinearity) term a₂ (eV per channel²) of the energy calibration. | 較正式の2次(非線形)項 a₂(eV/チャンネル²)を設定します。 |

### UserControlIonicRadius（ja.resx: 無）
1 元素分のイオン半径を表示・設定する UserControl(NumericUpDown 1個)。**注: `Radius` get/set が `Value/10` 換算、表示スケール(Å か nm か)要確認**。
| コントロール | 機能 | 提案EN | 提案JA |
|---|---|---|---|
| `numericUpDownRadius` | 元素のイオン半径(単位ラベル Å,3桁,0.001刻み) | Ionic radius of this element, in ångström (Å). | この元素のイオン半径をオングストローム(Å)単位で設定します。 |

### FormAboutMe（ja.resx: 有）
バージョン情報ダイアログ。表示が主目的で tip は基本不要。リンクラベル 2 つのみ操作可。
| コントロール | 機能 | 提案EN | 提案JA |
|---|---|---|---|
| `linkLabelMail` | mailto: でメーラ起動 | Click to open your e-mail client addressed to the author. | クリックすると表示中のアドレス宛にメールソフトを開きます。 |
| `linkLabelHomePage` | URL をブラウザで開く | Click to open the project homepage in your browser. | クリックするとプロジェクトのホームページをブラウザで開きます。 |

### FormCrystal（ja.resx: 有・実体は CrystalControl）
PDIndexer 側の `FormCrystal` は Crystallography.Controls の `CrystalControl` 等をホストするだけ(setTip=2)。**結晶パラメータ編集系のツールチップは ReciPro 監査 Part B（Crystallography.Controls）を正本とする**。PDIndexer 側固有の追加監査は不要（CC を修正する場合は CC リポジトリへ）。

---

# 検証結果（260531Cl・第2次／多エージェント検証）

> 第1次の調査台帳（Part A/B）を、18 エージェントで**コード根拠まで再検証**した結果。すべてコード（`.cs`/`.Designer.cs`/`.resx`）に当たって確認済み。**コードは変更していない**。

## 1. NumericBox/ColorControl の tip 表示方式（要点）

複合コントロールの relay 機構（host の `SetToolTip` が内部子へ配布・二重抑止・遅延/バルーン伝播）の一般仕様は [ツールチップ編集方針(共通).md](ツールチップ編集方針(共通).md) §6 を参照。PDIndexer 固有の確認結果のみ:

- 新規は host 側標準 `SetToolTip` で配線（CC の `RelayHostToolTip` で内部子へ配布されることをコードで確認）。
- FormMain の colorControl*/numericBox 軸は**表示キーが `.ToolTip1`**（`.ToolTip` 無印ではない。文案編集時は `.ToolTip1` を更新）。
- **FormEOS は `components` 未生成**だったため container＋ToolTip を新設して配線（実機 JA/バルーンは要確認）。

## 2. WRONG 3件 → **全て confirmed**

| コントロール | 判定 | コードで確認した実機能 |
|---|---|---|
| `checkBoxChangeHorizontalAppearance`(FormMain) | ✅confirmed | `FormMain.resx` の `.ToolTip` 値が日本語（EN/JA 取り違え）。実機能は `AddProfileToCheckedListBox`(FormMain.cs:3253-3325) でプロファイルの SrcProperty(WaveColor/WaveSource/AxisMode/WaveLength/X線元素・線/Takeoff・TOF 角度長/単位) を横軸へ適用。Concentric は全コピー、Radial は AxisMode=None で一部コピー。 |
| `buttonClearPeaks`(FormFitting) | ✅confirmed | tip が `buttonSaveTableAsCSV` の文言コピペ。実機能は `buttonClearPeaks_Click`(FormFitting.cs:1484-1492): FlexibleMode のとき `TargetCrystal.Plane.Clear(); SetPlanes(false); formMain.Draw()`。**なお resx で Visible=False**（通常非表示）。 |
| `buttonGetPeakIntensities`(FormLPO) | ✅confirmed | `buttonGetPeakIntensities_Click`(FormLPO.cs:41-136) は **本体 43〜135 行が `/* */` で全コメントアウト＝no-op**。tip も自ボタンを "below button" と誤称（自己言及の誤り）。 |

## 3. 『要確認』の解決一覧【全件 resolved】

| フォーム | 項目 | 結論（コード根拠） |
|---|---|---|
| FormEOS | NumericBox の Min/Max | **全 NumericBox に Min/Max 設定なし＝実効 -∞〜+∞**（Designer に `Minimum=/Maximum=` 行なし、resx に範囲エントリ 0、NumericBox 既定が ±∞）。負値・0 も入力可で範囲ガード無し。tip には「単位」は書けるが「範囲」は書けない。 |
| FormEOS | `checkBoxHBN` | **死蔵**。どのコンテナにも Add されず（flowLayoutPanel2 は10個のみ）、`checkBoxGold_CheckedChanged` に HBN 行なし、`groupBoxHBN` も `HBN()` も存在しない。→ tip 付与対象外。 |
| FormProfileSetting | High/Low pass 命名 | **逆転を確認**。`checkBoxLowPassFilter.Text="Cut high-freq. over"` が `DoesLowPath`、`checkBoxHighPassFilter.Text="Cut low-freq. under"` が `DoesHighPath`(`setBandPassOption` cs:263-266)。tip は表示 Text 基準（高/低周波カット）で書く。 |
| FormProfileSetting | SaveMaskingRange / readMaskingRanges | **両者とも本体コメントアウトで no-op**(cs:792-818, 826-852)。`toolStripMenuItemReadMaskingRange_Click`/DragDrop は動くが最終的に空メソッドを呼ぶため読込は実行されない。→ 実装確認まで tip 付与は保留可。 |
| FormProfileSetting | `radioButtonMutiplication`/`Division` の Text | **両方とも Text 空**（resx で空文字、ja.resx にエントリ無し）。×/÷ 記号が**画面に表示されない UI 欠陥**。機能は Calculate 内で正しく分岐(cs:629/638)。tip 付与より先に Text 設定が必要（要実装確認）。 |
| FormAtomicPositionFinder | Energy しきい値分岐 | **Angle のみ有効**。`getFindingCondition`(cs:724-734) でラジオ分岐の if 自体がコメントアウト、SetPlanes は無条件に Angle を使用。`radioButtonEnergyThreshold`/`numericUpDownEnergyThreshold` はファイル保存/復元のみで探索に**寄与しない死蔵**。 |
| FormAtomicPositionFinder | groupBox6 ラベル重複 | **二重定義＋同座標重ね置き**。label6-11 と label17/20/21/22/29/30 の計12個が同一文言・同一座標で groupBox6 に Add(Designer:1365-1379)。実機能 NumericUpDown は Randomization/Hybridization/Shaking の1組のみ。LABEL_SHARE はどちらか片方に付ければ足りる。 |
| FormCellFinder | `buttonSendToAtomicPositionFinder` | **空ハンドラ（死蔵）**(cs:935-938)。配線済みだが押下で何も起きない。→ tip 付与対象外（または「未実装」明記）。 |
| FormCellFinder | Min/Max 実値 | 全12個 DecimalPlaces=1。**長さ(a,b,c) Min/Max は Designer 未指定→既定 0〜100**（Value: Min側=2, Max側=20）。**角度 Min側は Maximum 未指定で既定100°、Max側は Maximum=180 明示**（Min はいずれも既定0、Value: Min側=60, Max側=150）。第1次台帳の「既定2.0-20.0/60-150」は**Value（既定値）であり Min/Max 範囲ではない**点を訂正。Min角の上限が100°止まりなのは潜在バグ。 |
| FormExportGSAS | buttonOK / .exp / checkBox群 | **buttonOK に Click ハンドラ無し・DialogResult 未設定→押下で None**（AcceptButton だが DialogResult を返さない）。`.exp` 書出しロジック**未実装**(`atmdat=""` 未参照)。`checkBox1-7` は CheckedChanged 無く値も読まれず**全て死蔵**。実装済みは GSA(FXYE) プレビュー生成・.exp 読込表示・Open のみ。GSA のファイル保存は本フォーム内に無し（呼び出し側依存・要確認）。→ **このフォームは実装が未完成。tip 整備より先に実装意図の確認が必要。** |
| FormLimitChanger | Min/Max・利用状況 | 4 NumericUpDown とも **Min=1/Max=180/Value=1/DecimalPlaces=0**。**呼び出し側での上書き無し**。`new FormLimitChanger(` は自身の ctor 以外に出現せず、**フォーム全体が未使用（死蔵）の可能性大**。→ tip 整備対象から外す判断もあり（要確認）。 |
| FormLPO | no-op / 範囲 | `buttonGetPeakIntensities_Click` 全コメントアウト確認。`numericUpDownResolution`: Max=1000/Increment=2/Value=80/Min既定0。`numericUpDownHWHM`: Max=30/Value=5/Increment既定1/Min既定0。 |
| UserControlIonicRadius | スケール | **表示単位 Å（NumericUpDown 0〜3 Å, 0.001刻み, 隣ラベル "Å"）、`Radius` プロパティは nm 保持**（getter=Value/10, setter=value×10）。Max=3 Å=0.3 nm が入力上限。tip は「Å 単位で入力」と明示。 |

## 4. 新規に判明した「未実装/死蔵」コントロール【tip 付与の前に実装確認が要るもの】

第2次検証で、tip を付ける前に実装意図の確認が必要なものが多数確定した。これらは**安易に tip を付けると「動くように見えるのに動かない」誤誘導**になるため要注意:

- **FormExportGSAS**: `buttonOK` 未配線（DialogResult None）、`checkBox1-7` 全死蔵、`.exp` 書出し未実装。フォームの export ワークフロー自体が未完成。
- **FormLimitChanger**: フォーム全体が未使用の可能性大（生成箇所が無い）。
- **FormProfileSetting**: `toolStripMenuItemSaveMaskingRange`/`readMaskingRanges` no-op、`radioButtonMutiplication`/`Division` の Text 空（記号非表示）。
- **FormAtomicPositionFinder**: Energy しきい値系（`radioButtonEnergyThreshold`/`numericUpDownEnergyThreshold`）死蔵、groupBox6 ラベル12個が重複配置。
- **FormCellFinder**: `buttonSendToAtomicPositionFinder` 空ハンドラ。
- **FormLPO**: `buttonGetPeakIntensities` no-op（既存 tip が誤誘導）。
- **FormEOS**: `checkBoxHBN` 死蔵。
- **FormMain**（第1次でも指摘）: `button2`/`button3`/`buttonAu`(EOS) 死蔵。

## 5. 数値範囲・単位の確定（第1次の「要確認」を更新）

- **FormEOS**: 入力 NumericBox は範囲制約なし（-∞〜+∞）。tip には単位（Å / Å³ / K / GPa）のみ記載し、範囲は書かない。
- **FormCellFinder**: 長さ既定範囲 0〜100 Å（既定 Value 2/20）、角度 Min側 0〜100°・Max側 0〜180°（既定 Value 60/150）、DecimalPlaces=1。
- **FormLimitChanger**: 1〜180、整数（DecimalPlaces=0）。
- **FormLPO**: Resolution 0〜1000（既定80, 2刻み）、HWHM 0〜30°（既定5）。
- **UserControlIonicRadius**: 0〜3 Å（0.001刻み）、プロパティは nm。

## 6. 網羅性チェック結果【監査はほぼ全件網羅】

inventory(全16フォームの userFacing コントロール) と本台帳を機械突合した結果、**実質的な網羅漏れはほぼ無し**。フラグされた差分の内訳:

- **偽陽性（グループ表記）**: `checkBoxGold/Platinum/...`、`numericUpDownMinA/MaxA(B,C同様)`、`checkBoxAutoSaveTwoTheta/D/FWHM/...`、`checkBox3/4/5/6`、`radioButtonUpperLeft/...`、`numericBoxA/B/C`、`numericBoxAlpha/Beta/Gamma`、`OffsetCoeff0/1/2` 等は圧縮記載のため個別名が部分一致せず検出されたが、**台帳でカバー済み**。
- **tip 不要として妥当**: 親メニューヘッダ（`optionToolStripMenuItem`/`helpToolStripMenuItem`/`languageToolStripMenuItem`/`コピーToolStripMenuItem`/`toolStripMenuItemExportExcelFile` の親）、`tabControl1`（タブ切替ナビ）、`DataGridView*Column`（列オブジェクト。grid 本体の tip でカバー）、`FormAboutMe.textBoxReadMe`（readonly 本文表示）。これらは個別 tip を付けない方針で問題なし。
- **結論**: ユーザーが操作する実コントロールは Part A/B でカバーできている。追加すべき実質的取りこぼしは無い（上記 tip 不要群を明記したことで完了）。

---

# ツールチップ表示方式（PDIndexer 固有メモ）

> 共通の WinForms ToolTip 方針（バルーン `IsBalloon`、遅延 `AutoPopDelay=10000` ほか #13800 / `AutomaticDelay` の罠、55 カラム折返し、`ToolTip.Active` のスコープ、複合コントロールの relay、新設 provider チェックリスト、adequacy 基準）は **[ツールチップ編集方針(共通).md](ツールチップ編集方針(共通).md)** を正本とする。本節は PDIndexer 固有の差分のみ。

- **FormMain の表示キーは `.ToolTip1`**: `colorControlBack/ScaleLine/ScaleText` と `numericBox{Upper,Lower}{X,Y}` は Designer が `.ToolTip1` を `SetToolTip` に渡す（`.ToolTip` 無印ではない）。本整備で両キー同値化済み。
- **メニュー**: `MenuStrip` は既定 `ShowItemToolTips=false` のためメニュー項目では tooltip が出ない。FormMain は `menuStrip.ShowItemToolTips = true`（`(260531Cl)`）を設定し、File/Option/Macro/Help/Language のドロップダウンに表示（トップレベルヘッダには付与しない）。ツールバー(`ToolStrip`)は既定で表示。
- **動的生成**: FormAtomicPositionFinder の周期表 111 元素入力箱は `.cs` 生成ループで共有 tip（resx キー `numericTexBox.SharedToolTip`）を `SetToolTip`。イオン半径UC は内部子被覆のため未対応。
- **provider/container 生成**: components 未生成だった FormEOS / FormCellFinder / FormAboutMe 等に `components = new Container()` ＋ `toolTip = new ToolTip(components)` を追加。非ローカライズの FormPrintOption / EDXControl は `ComponentResourceManager` を新設。
- 折返し・適用に使った PDIndexer 側スクリプトと各フォームの適用状況は下記「適用ログ」を参照。

---

# Claude 作業ログ / 引き継ぎ

## これまでの作業（260531Cl）

- ユーザー指示で **ReciPro のツールチップ監査を参考に PDIndexer 版を新規作成**。`PDIndexer\.project-guidance\` フォルダを作成し本ファイルを起こした。
- **コードは一切変更していない**（ユーザー指示: 「検証だけでよい、コード変更はしない」）。本ファイルは適用前の調査台帳。
- 決定論抽出で **PDIndexer 固有 17 UI Designer** のコントロール数・ToolTip provider/components 有無・既存 `SetToolTip`/`resxTip` 件数・ja.resx 有無を確定（→「ファイル別状態」表）。
- フォーム単位の並列調査で、**全 16 フォーム＋1 UserControl** をコード(`.cs`)根拠付きで監査し、WRONG/THIN/MISSING/JA欠落/LABEL_SHARE を EN/JA 文案つきで Part A / Part B に記録。
- 共有 Crystallography.Controls は ReciPro 監査 Part B が正本のため重複監査せず、`FormCrystal` は対象外と整理。
- **第2次検証（260531Cl・18エージェント）完了** → 「# 検証結果」セクション参照。WRONG 3件 全 confirmed、全『要確認』を コード根拠付きで resolved、NumericBox の tip 配線方式を確定、網羅性を機械突合で確認（実質漏れ無し）、未実装/死蔵コントロールを多数特定。

### 確定した全体像
- **有効 tip があるのは実質 FormMain(30件,JA大半欠落) と FormFitting(10件,JA全欠落) のみ。** 残りはほぼ全件 MISSING。
- **ToolTip provider 未追加が 12 フォーム**。うち **FormEOS / FormAboutMe は components(IContainer) も無い**（部品＋container 生成が必要）。それ以外 10 フォームは components 有→ ToolTip 部品 1 つ追加で足りる。
- **確定した WRONG（要修正・コード照合済）**:
  - FormMain `checkBoxChangeHorizontalAppearance` … EN リソース欄に日本語が入っている。
  - FormFitting `buttonClearPeaks` … tip が "Save … as CSV"（`buttonSaveTableAsCSV` からのコピペ誤り。実機能はピーク全削除）。
  - FormLPO `buttonGetPeakIntensities` … "below button" が自ボタンを指す誤誘導＋ハンドラ本体が現状 no-op。
- **要確認（実装意図・配線の確認待ち）**: FormExportGSAS の `.exp` 書出し(OK 未配線)、FormProfileSetting の High/Low pass 変数名逆転・`toolStripMenuItemSaveMaskingRange` 未実装・`radioButtonMutiplication/Division` の Text 空、FormCellFinder `buttonSendToAtomicPositionFinder` 空ハンドラ、FormAtomicPositionFinder の Energy しきい値分岐無効・groupBox6 ラベル二重定義、FormLimitChanger の Min/Max 既定、UserControlIonicRadius の Å/nm スケール、`Crystallography.Controls.NumericBox` の tip 表示方式(標準 SetToolTip か独自プロパティか)。

## 適用ログ（実装・260531Cl〜）

> resx 文案変更はインライン日付コメント不可のため、本ログを変更台帳とする（Designer.cs を触る場合のみ `(YYMMDDCl)` タグ）。コミットは未実施（working tree のみ）。

### 第1バッチ: FormMain / FormFitting（既存配線あり・resx中心）— 適用済

- **ベースライン**: `dotnet build PDIndexer.sln` = エラー0 を確認後に着手。
- **FormMain（30 キー）**: `checkBoxChangeHorizontalAppearance` の **WRONG（EN欄に日本語）を英語へ訂正**＋JA改善。THIN改善（radioButton/Linearity·Logarithm·RawCounts·CountsPerStep、checkBox 群、numericBox 軸範囲、groupBox4、colorControl×3＋色ラベル label2/4/5、toolStripButton×4、toolStripMenuItemExportCIF）。**JA 欠落 24 件を追加**（既存 JA 6 件は更新）。colorControl は表示キー `.ToolTip1` と `.ToolTip` の両方へ同値設定。Designer は既存 provider（IsBalloon=true / AutoPopDelay=10000）を流用、変更なし。
- **FormFitting（11 キー）**: `buttonClearPeaks` の **WRONG（buttonSaveTableAsCSV からのコピペ誤り）を訂正**。Apply 系 3 ボタンを区別。`numericBoxEffectiveDigit` は `.ToolTip`/`.ToolTip1` 両方。**JA 11 件を新規追加**（従来 JA tooltip 0 件）。Designer に **`IsBalloon=true / AutoPopDelay=10000 / InitialDelay=500 / ReshowDelay=100`** を追加（`(260531Cl)` タグ・`AutomaticDelay` 不使用・5000ちょうど回避）。
- **折返し**: `c:\tmp\pdi_wrap_tooltips.py`（ReciPro `wrap_tooltips3.py` の ROOTS を PDIndexer に変更したもの）で 55 カラム折返しを適用。**40 値 / 4 ファイル**に CRLF 埋込（英単語・FWHM・Excel・Simple・数値+単位を割らず句読点/かな優先）。既存の手動改行値（pictureBoxMain 等）は冪等によりスキップ。
- **検証**: `dotnet build` = エラー0（適用後・折返し後とも）。CRLF 維持（CR 行数=総行数、HEAD との差は折返し追加分のみ＝全行反転なし）。`git diff --check` 実エラーなし（LF→CRLF 情報警告のみ＝ReciPro と同じ良性）。WRONG 2 件はスポット確認で訂正反映を確認。
- **スクリプト**: `c:\tmp\pdi_apply_tooltips.py`（文案適用・update-or-add・BOM/CRLF保持）/ `c:\tmp\pdi_wrap_tooltips.py`（55カラム折返し）。再実行は冪等。

### 第2バッチ: 大面積フォーム5件（Designer 手術）— 適用済（ビルド各0/0）

provider/配線を新設し、全 MISSING に文案を付与。各フォームで「Designer 編集 → `pdi_apply_tooltips.py <Form> --write` → `pdi_wrap_tooltips.py --write` → `dotnet build`(0/0)」を実施。Designer 追加行には `(260531Cl)` タグ。

| フォーム | provider | 配線数 | resx(EN/JA) | 備考 |
|---|---|--:|---|---|
| `FormSequentialAnalysis` | 既存 components に ToolTip 追加 | 26 | 26/26 新規 | 全 MISSING。IsBalloon+遅延4値。 |
| `FormEOS` | **components+ToolTip を生成**(従来 null) | 66 | 66/66 新規 | 入力22・表示切替10・算出結果(表示専用)34。著者/手法/GPa を明示。 |
| `FormProfileSetting` | 既存 provider に IsBalloon+遅延 追加 | 62 | 62新規+3更新 / 65新規 | 7処理(2θ offset〜規格化)・軸設定・Operator。乗除ラジオは Text 空のため tip で補足。 |
| `FormAtomicPositionFinder` | ToolTip 追加 + **ja.resx 新設** | 31 | 31/31 新規 | 静的コントロールのみ。動的 111 元素箱・イオン半径UC は別途(下記)。Energy しきい値は無効の可能性を tip に明記。 |
| `FormCellFinder` | **components+ToolTip 生成** + **ja.resx 新設** | 24 | 24/24 新規 | 自動指数付け。dead な `buttonSendToAtomicPositionFinder`・loadメニューは除外。 |

- **ja.resx 新設**(FormAtomicPositionFinder / FormCellFinder): `pdi_make_ja_resx.py` で .resx ヘッダから空 ja.resx を生成 → apply で JA キー追加。**csproj は SDK 形式で自動グロブ**のため追加設定不要。ビルドで **ja satellite (`bin/Debug/ja/PDIndexer.resources.dll`) 生成を確認**。実機での JA 表示は要確認。
- 折返し: 各適用後に `pdi_wrap_tooltips.py`（冪等）。累計で FormSeq37 / EOS105 / ProfileSetting92 / APF59 / CellFinder24 値を 55 カラム折返し。

### 既存の未コミット変更（私の変更ではない・混在注意）

working tree には**本作業前から**の未コミット変更が混在している（CC の `NumericBox.ThonsandsSeparator`→`ThousandsSeparator` 改名の PDIndexer 側波及、`FormEOS.cs` 等の cp932→UTF-8 再エンコード 等）。対象: `FormEOS.cs` / `FormFitting.cs` / `FormLPO.cs` / `FormLPO.resx` / `FormMain.Designer.cs` / `FormPrintOption.resx` / `FormProfileSetting.cs` / `Macro.cs` / `Settings.cs` / `UserControlIonicRadius.resx`。**これらはツールチップ作業とは無関係**。ベースラインビルドにも含まれており 0/0。コミット時は分離を検討。

### 第3バッチ: FormMain メニュー＋中小フォーム＋動的＋取りこぼし修正 — 適用済（ビルド各0/0）

- **FormMain メニュー/ツールバー（36件）**: `menuStrip.ShowItemToolTips = true`（`(260531Cl)`）を設定し、File/Option/Macro/Help/Language のドロップダウン項目とツールバー4ボタン（CellFinder/Sequential/AtomicPosition/LPO）に `.ToolTipText` を付与。各項目は `resources.ApplyResources(item,…)` 経由で適用されるため per-item の Designer 変更は不要。トップレベルメニューヘッダには付与せず。
- **小フォーム5件**: `FormTwoThetaCalibration`(3) / `FormDataConverter`(6) / `FormAboutMe`(2) / `FormPrintOption`(9) / `EDXControl`(4) に provider＋IsBalloon+遅延＋配線。**非ローカライズの `FormPrintOption` / `EDXControl` には `ComponentResourceManager` を新規追加**。ja.resx 新設: TwoThetaCalibration / PrintOption / EDXControl。
- **動的（FormAtomicPositionFinder）**: 周期表 111 元素入力箱は `.cs` 生成ループで `toolTip.SetToolTip(numericTexBox[i], elemTip)` を配線、共通文案を resx キー `numericTexBox.SharedToolTip` から取得。イオン半径UC は内部子被覆のため未対応（注記）。
- **取りこぼし修正（網羅性チェックで検出）**: FormMain の `numericBox{Upper,Lower}{X,Y}` は Designer が表示キー `.ToolTip1` を読むのに第1バッチで `.ToolTip` に入れていた誤りを修正（`.ToolTip1` に EN/JA を設定）。FormCrystal の既存 EN tip 2件（`checkBoxVariableRatioOfIntensity`/`checkBoxCalculateIntensity`）に JA を補完。
- **検証**: `pdi_check_ja.py` で **EN 有 JA 無 = 0 件**（全 EN tip に JA あり）。`dotnet build` 各0/0。
- **現状一覧を生成**: [PDIndexer_ツールチップ一覧_現状.md](PDIndexer_ツールチップ一覧_現状.md)（13 フォーム・EN/JA 各 約322件）＋ PDIndexer 固有の ToolTip 方針記述。`pdi_extract_tooltips_md.py` で再生成可。

### 据え置き（実装確認待ち・ツールチップ未付与）

- `FormExportGSAS`: export 機能が未完成（`buttonOK` 未配線・checkbox 群死蔵・`.exp` 未実装）。
- `FormLimitChanger`: 呼び出し元が無く未使用の可能性大。
- `FormLPO`: `buttonGetPeakIntensities` が no-op。機能コントロール（`buttonAnalyze`/`numericUpDownResolution`/`numericUpDownHWHM`）への付与は実装方針確認後。
- `UserControlIonicRadius`（動的インスタンス）: 内部 NumericUpDown が外枠を覆い tip が出にくいため未対応。

### 残作業（任意・次回以降）

- **provider 追加が必要な大面積フォーム**（Designer 手術＋MISSING 付与）: FormEOS（components+ToolTip 生成）、FormProfileSetting、FormAtomicPositionFinder（+ja.resx 新設）、FormSequentialAnalysis、FormCellFinder（+ja.resx 新設）。各 provider に §13 テンプレ（IsBalloon+遅延4値）を適用。
- **FormMain の MISSING**（メニュー/ToolStrip 約50件）: Designer に `SetToolTip` 行追加が必要（今回は既存キーの値改善のみ）。
- **中小フォーム**: GSAS/Print/Limit/2θ較正/DataConverter/EDX/IonicRadius/AboutMe。死蔵/未実装（§検証結果4）は付与しない。
- 各バッチ後に `pdi_wrap_tooltips.py`（冪等）→ build。

## 今後の ToDo（優先順）

1. **WRONG 3 件の修正**（コード変更解禁後）。FormMain の EN/JA 混在、FormFitting のコピペ誤り、FormLPO の誤誘導文。最小差分で対応。
2. **有効 tip 0 の大面積フォームへ「無→有」付与**（限界価値が最大）:
   - まず **FormEOS**（provider＋components 生成が必要。NumericBox の tip 表示方式を実機確認 → 入力22＋表示切替11 を優先、表示専用43は後回し可）。
   - 次に **FormProfileSetting**（provider 有。SetToolTip 行を約60件追加）、**FormAtomicPositionFinder**（部品追加＋ja.resx 新設）、**FormSequentialAnalysis**、**FormCellFinder**（ja.resx 新設）。
3. **FormMain / FormFitting の THIN 改善＋JA 欠落補完**（既存配線を活かせる＝低コスト）。FormMain は `colorControl*` が `.ToolTip1` キー表示である点、Y軸 NumericBox に右クリックメニューが無い点に注意。FormFitting は Apply 系3ボタンの区別と `numericBoxEffectiveDigit` の `.ToolTip`/`.ToolTip1` 重複整理。
4. **中小フォーム**（GSAS/Print/Limit/2θ較正/DataConverter/EDX/IonicRadius/AboutMe）。多くは部品追加＋ja.resx 新設を伴うが件数は少ない。`.exp` 等「機能未実装」のものは実装確認後に付与。
5. **LABEL_SHARE 整備**: 入力欄の見出しラベルへ隣接入力と同文案を共有。
6. **検証は小分け**: フォーム/まとまりごとに `dotnet build` と差分確認。resx 文案変更はインライン日付コメント不可なので本ログを変更台帳とし、Designer.cs を触る場合のみ `(YYMMDDCl)` タグを付与（CLAUDE.md 準拠）。

### 第2次検証で更新された留意点（適用前に必読）

- **NumericBox/ColorControl/SizeControl は host 側標準 `toolTip.SetToolTip(...)` でよい**（§検証結果1 で確定）。`RelayHostToolTip` が内部子へ配布する。独自 `ToolTip` プロパティ経路は新規採用しない。
- **tip を付ける前に実装確認が要る「未実装/死蔵」**（§検証結果4）: FormExportGSAS（buttonOK 未配線・checkBox群死蔵・.exp 未実装＝export 自体未完成）、FormLimitChanger（フォーム未使用の可能性大）、FormProfileSetting（SaveMaskingRange/readMaskingRanges no-op、乗除ラジオの Text 空＝記号非表示）、FormAtomicPositionFinder（Energy しきい値死蔵・groupBox6 ラベル重複）、FormCellFinder `buttonSendToAtomicPositionFinder`（空）、FormLPO `buttonGetPeakIntensities`（no-op）、FormEOS `checkBoxHBN`（死蔵）。**これらは「動くように見えて動かない」誤誘導を避けるため、tip 付与より先に実装意図を確認する**（優先度2の対象から一旦外す or 「未実装」と明記する判断）。
- **数値範囲（§検証結果5）**: FormEOS は範囲制約なし（tip に範囲は書かない）。FormCellFinder/LimitChanger/LPO/IonicRadius の実 Min/Max は §検証結果5 の値を使う。第1次台帳が Value を範囲と誤記していた箇所（CellFinder）は §検証結果5 で訂正済み。
- **網羅性（§検証結果6）**: 親メニューヘッダ・TabControl・DataGridView 列・readonly 表示には個別 tip を付けない。

## 適用時の方針メモ
- 新規配線は ReciPro 方針に合わせ **標準 `toolTip.SetToolTip(control, resources.GetString("control.ToolTip"))`** に寄せる。NumericBox/ColorControl の独自 `ToolTip` プロパティ依存は増やさない。
- `.ToolTip1` 等の派生キーは増やさず、表示キーと文案キーを一致させる（FormMain `colorControl*` は現状 `.ToolTip1` が表示キー）。
- 英語専用フォーム（ja.resx 無し: AtomicPositionFinder/CellFinder/ExportGSAS/PrintOption/LimitChanger/TwoThetaCalibration/LPO/EDXControl/UserControlIonicRadius）の JA 反映には **ja.resx の新設**が必要。文案は本ファイルに記録済み。

## 再スキャン用コマンド（PowerShell, PDIndexer ルートで実行）

```powershell
# UI Designer ごとの ToolTip provider/components/SetToolTip 状態
$root="PDIndexer"; Get-ChildItem $root -Recurse -Filter *.Designer.cs | Where-Object { $_.FullName -notmatch '\\obj\\|\\bin\\' -and $_.Name -notmatch '^(DataSet|Resources|Settings)\.Designer\.cs$' } | ForEach-Object { $t=[IO.File]::ReadAllText($_.FullName); $b=$_.Name -replace '\.Designer\.cs$',''; $p=[bool]($t -match 'new\s+(System\.Windows\.Forms\.)?ToolTip\s*\('); $c=[bool]($t -match 'IContainer\s+components'); $s=([regex]::Matches($t,'\.SetToolTip\(')).Count; "{0,-26} provider={1} components={2} setTip={3}" -f $b,($p?'Y':'-'),($c?'Y':'-'),$s }

# resx の非空 .ToolTip(Text) キー件数と ja.resx 有無
$root="PDIndexer"; Get-ChildItem $root -Recurse -Filter *.resx | Where-Object { $_.FullName -notmatch '\\obj\\|\\bin\\' -and $_.Name -notmatch '\.ja\.resx$' } | ForEach-Object { [xml]$x=Get-Content -LiteralPath $_.FullName; $n=($x.root.data | Where-Object { $_.name -match '\.ToolTip(Text)?$' -and -not [string]::IsNullOrWhiteSpace($_.value) }).Count; $ja=Test-Path ($_.FullName -replace '\.resx$','.ja.resx'); "{0,-34} resxTip={1,3} ja={2}" -f $_.Name,$n,($ja?'Y':'-') }
```
