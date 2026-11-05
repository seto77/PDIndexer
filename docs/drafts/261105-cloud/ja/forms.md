<!-- 261105Cl: docs/drafts/261105-cloud — 全フォーム一覧の下書き。docs/src には未統合。 -->
# ウィンドウ（フォーム）一覧

> 本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

PDIndexer が開くウィンドウを、マニュアルの章立てに対応づけて一覧にしたものです。タイトルは各フォームの `$this.Text`（`<Form>.resx` / `<Form>.ja.resx`、一部は実行時にコードで設定）から、メニュー名は `FormMain.Designer.cs` と `FormMain.ja.resx` から取りました。「ja 訳なし」は日本語 UI でも英語のタイトルのまま表示されるものです。`(Controls)` は共通ライブラリ `Crystallography.Controls` のフォームです。

## 1. PDIndexer 本体のフォーム

| フォーム（クラス） | タイトル（ja UI） | 開き方 | 機能 | 対応章 |
| --- | --- | --- | --- | --- |
| `FormMain` | `PDIndexer   ver4.465 (2026/10/26)`（実行時に設定） | 起動時 | プロファイル描画、プロファイルリスト、結晶リスト、メニュー・ツールバー | [1](../../../src/ja/1-main-window.md) |
| `FormCrystal` | `回折線/結晶情報` | ツールバー `回折線/結晶情報 (C)`、Ctrl+Shift+C | 格子定数・対称性・原子・回折線表示条件、結晶データベース | [3](../../../src/ja/3-crystal-parameter.md) |
| `FormProfileSetting` | `プロファイル情報` | ツールバー `プロファイル情報 (P)` | マスク・平滑化・バンドパス・Kα2 除去・正規化・背景・2θ オフセット・軸設定・プロファイル演算 | [4](../../../src/ja/4-profile-parameter.md) |
| `FormTwoThetaCalibration` | `2θ 較正` | プロファイル情報の `Calibration using an internal standard`（Fitting ウィンドウ表示中のみ有効） | 内部標準による 2θ オフセット係数 $c_0,c_1,c_2$ の決定 | 4 |
| `FormEOS` | `Equation of States`（ja 訳なし） | ツールバー `状態方程式 (E)`、Ctrl+Shift+E | 予約結晶（結晶リスト 1〜10 行目）の格子定数から圧力を計算 | [5](../../../src/ja/5-equation-of-states.md) |
| `FormFitting` | `FormFitting`（タイトル未設定、クラス名のまま） | ツールバー `ピークフィッティング (F)`、Ctrl+Shift+F | ピークフィッティングと格子定数の最小二乗精密化 | [6](../../../src/ja/6-fitting-diffraction-peaks.md) |
| `FormSequentialAnalysis` | `Sequential Analysis`（ja 訳なし） | ツールバー `連続分析`、Ctrl+Shift+S | 全プロファイルの連続フィッティング・格子定数・圧力・応力解析 | [7](../../../src/ja/7-sequential-analysis.md) |
| `FormCellFinder` | `Cell Finder`（ja 訳なし） | ツールバー `Cell Finder`、Fitting の `Send d-values` | d 値から格子定数を探索（指数付け） | 1 に一行のみ（**専用章なし**） |
| `FormAtomicPositionFinder` | `Atomic Position Finder`（ja 訳なし） | ツールバー `Atomic Position Finder`（**ボタンは非表示**: `FormMain.resx` `toolStripButtonAtomicPositonFinder.Visible=False`） | 観測強度から原子座標を探索（`UserControlIonicRadius` を内包） | 1 に一行のみ（**専用章なし**） |
| `FormLPO` | `FormLPO`（クラス名のまま） | ツールバー `LPO Analysis`（**ボタンは非表示**: `toolStripButtonLPO.Visible=False`） | 格子選択配向（LPO）解析 | 1 に一行のみ（**専用章なし**） |
| `FormDataConverter` | `Data Converter`（ja 訳なし） | pdi / pdi2 以外のプロファイル読込時 | 横軸の種類・露出時間・EDX 校正などを指定して読み込む | [2](../../../src/ja/2-pattern-profiles.md)、[ファイル形式](../../../src/ja/appendix/file-formats.md) |
| `FormPrintOption` | `印刷オプション` | ファイル > 印刷 / 印刷プレビュー | 印刷内容・プロファイル名の位置 | **未記載** |
| `FormAboutMe` | `About Me`（ja 訳なし） | ヘルプ > `PDIndexerについて` | バージョン・作者・使用条件・履歴 | 1 |
| `FormExportGSAS` | `GSAS ファイルのエクスポート -オプション-` | **どこからも開かれない**（GSAS 出力はダイアログなしで直接書き出す） | — | （2 章・付録の記述と食い違い） |
| `FormLimitChanger` | `FormLimitChanger` | **どこからも開かれない** | — | — |

## 2. 共通ライブラリ（Crystallography.Controls）のフォーム

| フォーム | タイトル（ja UI） | 開き方 | 機能 | 対応章 |
| --- | --- | --- | --- | --- |
| `FormMacro` | `Macro`（ja 訳なし） | マクロ > `編集` | IronPython マクロの編集・実行 | [8](../../../src/ja/8-macro.md) |
| `CommonDialog` | 初期化中のメッセージ | 起動時、ヘルプ > `ヒント` | 初期化の進捗・ヒント | 1（ヒントのみ） |
| `FormCrystalSelection` | `読み込み / 保存項目を選択` | ファイル > 結晶リストの読込 / 追加 / 保存、xml の D&D | 読み書きする結晶の選択 | **未記載** |
| `FormChemicalComposition` | `化学組成の詳細` | 回折線/結晶情報の結晶コントロールを右クリック > `化学組成の詳細`（ver4.465） | 酸化物 / ハロゲン化物 / 硫化物換算、価数 | **未記載** |
| `FormBeamInteraction` | `ビーム相互作用` | 結晶コントロール右クリック > `ビーム相互作用` | X 線・電子・中性子との相互作用（散乱因子など） | **未記載** |
| `FormSymmetryInformation` | `Symmetry Information`（ja 訳なし） | 結晶コントロール右クリック > `対称性詳細` | 空間群の情報（ワイコフ位置・反射条件・対称操作など） | **未記載** |
| `FormSuperStructure` | `Set superstructure size`（ja 訳なし） | 結晶コントロール右クリック > `超構造に変換` | 超構造セルへの変換 | **未記載** |
| `FormAnotherSpaceGroup` | `別の空間群へ変換` | 結晶コントロール右クリック > `異なる軸・原点セッティングの空間群に変換` | 軸・原点セッティングの変更 | **未記載** |
| `FormStrain` | `格子ひずみ (invisible)` | 結晶コントロール右クリック > `格子ひずみ (invisible)` | 弾性定数に基づく格子ひずみ（ja 表記に "(invisible)" が残っている） | **未記載** |
| `FormNumericUpdownControl` | `NumericUpdown コントロール` | 回折線/結晶情報のしきい値ボックスを右クリック | 増分などの設定 | **未記載** |

結晶コントロールの右クリックメニューには、このほか `P1に変換`、`アプリ起動時の格子定数に戻す`、`CIFファイル又はAMCファイルから読み込み`、`CIFファイルとして出力`、`Send this crystal to other software` があります（`Crystallography.Controls/Crystal/CrystalControl.Designer.cs`）。

## 3. マニュアル章立てへの提案

- Cell Finder は 1 章で一行触れているだけで、操作説明の章がありません。Atomic Position Finder と LPO Analysis はツールバーボタン自体が非表示なので、マニュアルの一行記述（1 章）を残すか削るかも含めて判断が必要です（3 章監査によれば Atomic Position Finder は .NET 10 で動作しない可能性あり）。3 章の付節か独立章（例「9. Cell Finder」「10. Atomic Position Finder」「11. LPO 解析」）の追加を検討してください。
- 結晶コントロールの右クリックメニューから開くフォーム群（化学組成・ビーム相互作用・対称性詳細・超構造・別の空間群・格子ひずみ）は、3 章に「結晶コントロールの右クリックメニュー」節を設けてまとめるのが自然です（ReciPro と共通のコントロールなので、ReciPro 側マニュアルへのリンクで済ませる案もあります）。
- 計算手法は [methods.md](methods.md) を付録「アルゴリズム解説」の改訂版として統合する想定です。

<!-- screenshot: 結晶コントロール（回折線/結晶情報ウィンドウ）の右クリックメニューを開いた状態 -->

## 要確認事項

- `FormFitting` と `FormLPO` のタイトルが未設定（クラス名のまま）なのは意図どおりか。
- `FormExportGSAS` / `FormLimitChanger` は削除予定か、再接続予定か（マニュアルの GSAS 出力の記述をどちらに合わせるか）。
- `FormStrain` の ja タイトル「格子ひずみ (invisible)」の "(invisible)" は消し忘れか。
- Cell Finder / Atomic Position Finder / LPO の章を新設するか。
