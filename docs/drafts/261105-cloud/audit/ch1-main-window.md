<!-- 261105Cl: docs/drafts/261105-cloud — 既存マニュアルとコードの突き合わせ結果 (監査)。docs/src には未統合。 -->
# 第1章 メインウィンドウ（docs/src/ja/1-main-window.md / docs/src/en/1-main-window.md）監査

> 本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象コード: `PDIndexer/FormMain.cs`, `FormMain.Designer.cs`, `FormMain.resx`, `FormMain.ja.resx`, 小フォーム群（FormAboutMe, FormPrintOption, FormLimitChanger, FormTwoThetaCalibration, FormExportGSAS, UserControlIonicRadius, FormLPO, Settings.cs, Program.cs）、共有 `Crystallography.Controls/Wave/HorizontalAxisUserControl.*`, `Crystallography/Localization/SupportedCultures.cs` ほか。
行番号は監査時点（2026-11-05）のもの。略記: `FM.cs`=PDIndexer/FormMain.cs, `FM.D`=PDIndexer/FormMain.Designer.cs, `FM.resx`/`FM.ja`=FormMain.resx / FormMain.ja.resx, `HAU`=Crystallography.Controls/Wave/HorizontalAxisUserControl。

---

## 1. 食い違い（マニュアル記述 vs コード）

| # | マニュアル箇所 (file:見出し/行) | マニュアルの記述 | コードの実際 (file:method/line) | 深刻度 |
|---|---|---|---|---|
| 1 | ja/en 1-main-window.md: Language (L89-91) | 英語 `English (need restart)` と日本語 `Japanese (need restart)` の 2 言語。切替後は再起動が必要。 | Designer の固定 2 項目は起動時に破棄され、`PopulateLanguageMenu()` (FM.cs L3888-3900) が `SupportedCultures.All` の `Released=true` 全言語を **自言語名 (NativeName)** で動的生成する。現状 11 言語: `English`, `日本語`, `Deutsch`, `Français`, `Español`, `Português`, `Italiano`, `Русский`, `简体中文`, `繁體中文`, `한국어` (Crystallography/Localization/SupportedCultures.cs L54-67)。選択すると確認ダイアログ（en: "Switching the display language to "…" requires restarting PDIndexer. Unsaved work will be lost. Restart now?" / ja: 「表示言語を「…」に切り替えるには PDIndexer の再起動が必要です。保存していない作業は失われます。今すぐ再起動しますか？」）を出し、Yes で `Application.Restart()` により**自動再起動**（FM.cs `languageToolStripMenuItem_Click` L3849-3876）。"(need restart)" という表記は表示されない。 | 高 |
| 2 | ja/en: プロファイル描画エリア (L21) | 描画範囲は `2θ:`、`d:`、`Int.:`、`q:` などのラベルの数値ボックスに直接入力して変更する。 | `labelTwoTheta`/`labelD`/`labelQ`/`labelIntensity` は**マウスカーソル位置の読み取り表示**（`pictureBoxMain_MouseMove` FM.cs L2390-2416: `"2θ: …"`, `"d: … Å"`, `"q: … Å⁻¹"`, `"Int: …"`）。範囲入力は `numericBoxLowerX`/`numericBoxUpperX`（ラベル `labelX` = 軸モードに応じ `2θ (deg): ` 等, FM.cs `horizontalAxisUserControl_AxisPropertyChanged` L4267-4275）と `numericBoxLowerY`/`numericBoxUpperY`（ラベル `label9` en "Intensity" / ja「強度」）。X 側は右クリックメニューで上下限を変更可（`NumericBoxWithMenu`, ToolTip FM.resx `numericBoxUpperX.ToolTip`）。 | 高 |
| 3 | ja/en: 結晶リスト (L150) | `すべてチェック/解除` で**結晶リスト**を一括チェック/解除。 | `checkBoxAll` は **プロファイルリスト (groupBox1)** に配置（FM.D L1115-1116）。処理は `dataSet.DataTableProfile.AllChecked/AllUnchecked`（FM.cs `checkBoxAll_CheckedChanged` L4620-4630）。ToolTip も "Check or uncheck all profiles at once" / 「全プロファイルのチェックを一括でオン / オフ」。結晶リストには一括チェックボックスなし。 | 高 |
| 4 | ja/en: ファイル > コピー (L62) | ビットマップまたはメタファイルとしてクリップボードにコピー。 | サブメニュー `BitmapToolStripMenuItem`（en "as Bitmap data" / ja "as Bitmap"）には **Click ハンドラが無く何も起きない**（FM.D L1541-1544）。動作するのは `copyAsMetafileToolStripMenuItem`（"as Metafile data"、ja 訳なし）のみ（FM.cs `copyAsMetafileToolStripMenuItem_Click` L4099）。 | 高 |
| 5 | ja/en: 縦軸 (L134) | ja「毎ステップあたりのカウント（`カウント/秒 (CPS)`）」/ en "counts per step (`Count per Step (CPS)`)" | 実装は `y /= ExposureTime`（**露出時間で割る** = counts per second）（Crystallography/Profile.cs `convertSrcToDest` L1158-1159、`IsCPS` は FM.cs `radioButtonRawCounts_CheckedChanged` L4343 で設定）。en ラベル "Count per Step (CPS)" と ToolTip（"CPS = counts / step width" / 「CPS = カウント / ステップ幅」）も実装と食い違い、ja ラベル「カウント/秒 (CPS)」のみ実装と整合。対数は `Math.Log10(y)`。既定は CPS・リニア（FM.D L689, L657）。 | 中 |
| 6 | ja/en: 結晶リスト (L144) | 初期状態で約 80 種類の結晶。 | 同梱 `PDIndexer/default.xml` は Flexible Crystal を含め **67 件**（うち Reserved=true が 11 件 = Flexible + EOS 用 10 件）。 | 中 |
| 7 | ja/en: 結晶リスト「特別な行」(L148) | 桃色の行は `NaCl EOS`・`Pt EOS` など。 | 予約結晶の名前は `Au`, `Pt`, `NaCl (B1-type)`, `NaCl (B2-type)`, `MgO (periclase)`, `Al2O3 (cor.)`, `Ar`, `Re`, `Mo`, `Pb`（default.xml）。"NaCl EOS"/"Pt EOS" は親コントロールに追加されていない未使用ボタン `button2`/`button3` の Text（FM.resx）に過ぎず UI に出ない。着色は `cellStyle1 = LightBlue`（行0）, `cellStyle2 = LightPink`（Reserved 行）（FM.cs L921-922, L3755-3759）で記述は整合。 | 中 |
| 8 | ja/en: マウス操作 (L14-19) | 左ドラッグ=回折線移動、右ドラッグ=拡大、右クリック=縮小、中ドラッグ=パン。 | 概ね一致。ただし (a) 左ドラッグは回折線上（カーソルが VSplit）でのみ回折線移動、**空白部の左ドラッグは中ドラッグと同じくパン**（FM.cs `pictureBoxMain_MouseDown` L2242-2248 `Middle || Left` → `MouseMovingMode`）。(b) 回折線移動は a,b,c を同一倍率で拡縮（軸角不変）（L2481-2482）。(c) 回折線移動には結晶が**選択**されている必要（`SelectedCrystalIndex > 0`, L2136）。(d) 右クリック縮小は表示幅を 2 倍（両側に 0.5 幅ずつ）、全範囲表示中に 200 ms 以内の右クリック連打 (>4 回) で `MaximalX *= 1.2`（L2296-2323）。(e) 右ドラッグは 10 px 未満だと無視（L2329-2333）。 | 低 |
| 9 | ja/en: プロファイルリスト (L138) | `単一プロファイルのみ表示` モードのときは無効。 | 無効化コードはコメントアウト済み（FM.cs `radioButtonMultiProfileMode_CheckChanged` L4311-4312）。他に `dataGridViewProfiles.Enabled` を変更する箇所なし。単一モードでは読み込み時に既存行を全削除するだけ（`AddProfileToCheckedListBox` L3516-3517）。 | 中 |
| 10 | ja/en: 横軸タブ表 (L97-103) | 項目 "2θ (degree)" / "Energy (eV)" / "d-spacing (Å)" / "q"。X-ray / Electron の 2 択。 | 実 UI（HAU.resx/ja.resx）は 5 グループ: `Source`/「線種」(`X-ray`/「X線」, `Electron`/「電子線」, `Neutron`/「中性子線」)、`Color mode`/「単色/白色」(`Monochromatic`/「単色」, `Flat White`/「白色」, `Custom white`/「カスタム色」)、`Wavelength`/「波長」(WaveLengthControl)、`Horizontal axis`/「横軸」(`2θ (Angle)`/「2θ (角度)」, `d-spacing`/「d値」, `q (wavenumber)`/「波数」, `Energy`/「エネルギー」, `Neutron TOF`/「中性子TOF」)、`Unit options`/「単位」。**中性子線・中性子 TOF・単色/白色の切替・単位選択がマニュアルに無い**。Energy は白色モードでのみ、2θ は単色モードでのみ選択可、TOF は中性子+白色のみ（HAU.cs `radioButtonMonochro_CheckedChanged` L557-586）。単位の既定: 度, Å, Å⁻¹, eV, μs（HAU.Designer L355, 397, 423, 451, 500）。 | 高 |
| 11 | ja/en: 横軸タブ Energy 行 (L101) | 単位 eV、取り出し角を設定。 | 単位は eV / KeV / MeV から選択（`radioButtonEnergyUnitEv/Kev/Mev`）。取り出し角は `numericBoxTwoTheta`（ヘッダ "2θ"、単位 °、ToolTip "take-off angle"）。 | 中 |
| 12 | ja/en: ファイル > 結晶リストを読込 (現在のリストを消去) (L53) | 現在の結晶リストは破棄される。 | (a) 読込前に**選択ダイアログ** `FormCrystalSelection`（en "Select load / save items" / ja「読み込み / 保存項目を選択」）が開き、チェックした結晶のみ読込（FM.cs `readCrystal` L3691-3702）。(b) 破棄されるのは **Reserved 以外**の結晶のみ。Reserved 結晶は残り、ファイル中に同名・同 Journal のものがあれば差し替え（L3704-3743）。「追加」版も同じ選択ダイアログを表示（L3659-3665）。 | 中 |
| 13 | ja/en: ファイル > 結晶リストを保存 (L55) | 現在の結晶リストを xml に保存。 | 保存前に `FormCrystalSelection`（LoadMode=false）で保存する結晶を選択させる（FM.cs `menuItemSaveCrystalData_Click` L3603-3626）。 | 低 |
| 14 | ja/en: プロファイルをエクスポート (L52) | 選択中のプロファイルを CSV/TSV/GSAS 出力。 | CSV/TSV は**チェックされた**プロファイル全部（`DataTableProfile.CheckedItems`）を対象、保存後に「1 ファイルに結合しますか?」(Yes/No/Cancel, `PdiText.MergeProfiles`) を尋ねる。No のときは `<入力名から拡張子4文字除去> + <Profile名>.csv` の個別ファイル（FM.cs `toolStripMenuItemExportCSVFile_Click` L4150-4196）。GSAS は**現在選択中の 1 本**のみ（`bindingSourceProfile.Current`, L4199-4258）。サブメニュー名は en/ja とも英語 `as CSV (comma separated values) file` / `as TSV (tab separated values) file` / `as GSAS file`（ja 訳なし）。 | 中 |
| 15 | ja/en: ヘルプ > ヒント (L86) | 使い方のヒント（非推奨）。 | `initialDialog`（CommonDialog）を Hint モードで表示（FM.cs `hintToolStripMenuItem_Click` L4055-4059）。コード上に非推奨表示・扱いなし。表示内容は `Version.HintEn`（1 件のみ, Version.cs）。 | 低 |
| 16 | ja/en: オプション > レジストリを消去 (L73) / appendix/troubleshooting.md L22 | 終了時にレジストリ保存設定を消去。troubleshooting は「ウィンドウ位置・**色設定**・各種オプションなどはレジストリに保存」。 | 消去は `FormMain_FormClosed` で `ClearRegistry()`（キー `HKCU\Software\Crystallography\PDIndexer` ごと削除, FM.cs L1019-1035）。**マクロ (`Macro` 値, L1083-1088) も消える**点の記載なし。色 (`colorControlBack/ScaleLine/ScaleText`) は `Registry()` (L1040-1212) に含まれず**保存されない**（troubleshooting の記述と不一致）。 | 中 |
| 17 | ja/en: オプション > 終了時に結晶リストを自動保存する (L74) | チェックすると終了時に自動保存し次回起動時に読み込む。 | 既定 **ON**（FM.D L1622-1624）、状態はレジストリ保存（FM.cs L1072）。保存先は `<UserAppDataPath>\default.xml`（L995-1003）。**OFF の場合、起動時は `initial.xml`（＝インストール時の default.xml のコピー）を読むため、毎回初期リストに戻る**（L875-887, L855-857）。 | 低 |
| 18 | ja/en: ヘルプ > ヘルプ (web) (L87) | このマニュアルを表示。 | 既定ブラウザでオンラインマニュアル `https://seto77.github.io/PDIndexer/`（ja は `/ja/`、en/ja 以外の UI 言語は英語版）を開く（FM.cs `helpwebToolStripMenuItem_Click` L4017-4036, `HelpCulture()` L4007-4011）。記述は整合だが ToolTip が旧仕様の "Open the PDIndexer manual (PDF)." / 「マニュアル（PDF）を開きます」のまま（FM.resx/ja）。 | 低 |
| 19 | ja/en: ヘルプ > アップデートをチェック (L85) | オンライン確認しダウンロード/インストール。 | Portable ZIP 版（実行フォルダに `README-PORTABLE.txt` がある場合）は**このメニュー自体が非表示**（FM.cs L772-775）。arm64 プロセスは `PDIndexer-setup_arm64.msi`、それ以外は `PDIndexer-setup.msi` を取得（L4643）。 | 低 |
| 20 | ja/en: 色設定タブ (L119) | `背景色`・`目盛り線`・`目盛文字色` など。 | ラベル一致（ja: `背景色`/`目盛り線`/`目盛文字色`, en: `Back Color`/`Scale Line`/`Scale Text`）。既定色: 背景 白(255,255,255)、目盛り線 (211,211,211)、目盛文字 黒（FM.D L779, 789, 799）。`目盛り線を表示`/`エラーバーを表示` の既定は OFF。 | 低（補足） |
| 21 | ja/en: ツールバー注記 (L42) | ショートカット `Ctrl+Shift+C/E/F/D` のみ。 | 実装はさらに `Ctrl+Shift+S`（連続分析ウィンドウ表示切替）、`Ctrl+Shift+Space`（選択結晶のチェック反転）、`Ctrl+Alt+Space`（Fitting 画面の選択面チェック反転）、`Ctrl+Shift+V`（クリップボード文字列をプロファイルとして読込）、`Ctrl+C`（描画エリアにフォーカス時、メタファイルとしてコピー）（FM.cs `FormMain_KeyDown` L4768-4818）。`Ctrl+Shift+D` は「非表示 → 表示(強度計算なし) → 表示(強度計算あり)」の 3 状態循環（L4781-4790）。 | 中 |
| 22 | ja/en 0-overview.md L45 | 動作要件 .NET Desktop Runtime 6.0 以上。 | `PDIndexer.csproj` L5 `net10.0-windows`。index.md・appendix/runtime-and-installation.md は 10.0 と正しく記載しており章間で矛盾。 | 中（他章） |
| 23 | ja appendix/troubleshooting.md L18 | 言語選択しても表示がすぐ変わらないのは正常、終了・再起動せよ。 | 現行は確認後に自動再起動（#1 参照）。 | 中（他章） |
| 24 | en 1-main-window.md (L99, L130) | `After reading profile, change horizontal axis` / `Change automatically color` | 実ラベルは綴り誤りを含む `After reading profile, change horizontanl axis` / `Change automaticaly color`（FM.resx）。マニュアルは正しい綴りで記載（UI 側の typo）。 | 低 |
| 25 | ja/en: 結晶リスト (L150) | ja: `回折線/結晶情報` チェックボックス / en: `Crystal Parameter (C)` | 実ラベル ja `回折線/結晶情報 (C)`, en `Crystal Parameter (C)`（FM.ja/FM.resx `checkBoxCrystalParameter.Text`）。ja 側だけ "(C)" 欠落（軽微な ja/en 差）。 | 低 |

---

## 2. マニュアル未記載の機能・設定

| # | 機能/コントロール (UI 英/日ラベル) | 実装箇所 | 概要 (既定値・単位を含む) |
|---|---|---|---|
| 1 | ドラッグ＆ドロップ読込 | FM.cs `FormMain_DragDrop` L4733-4758 | 1 ファイルで拡張子 `xml` → 結晶リストとして**追加**読込（選択ダイアログ付き）、`cif`/`amc` → Crystal Parameter を開いてそちらへ渡す、それ以外/複数ファイル → プロファイル読込。ch2 にプロファイル D&D の記述はあるが xml/cif の分岐は未記載。 |
| 2 | 追加ショートカット | FM.cs `FormMain_KeyDown` L4768-4818 | 表1 #21 参照。`Ctrl+Shift+V` は作業ディレクトリに一時ファイル `clipbord.txt` を作って読み、削除する。 |
| 3 | 結晶の点滅モード | FM.cs `dataGridViewCrystals_CellMouseClick` L4513-4525, `timerBlinkDiffraction_Tick` L4551 | 結晶リストの行を**右ダブルクリック**で、その結晶の回折線を点滅表示（再度で解除）。ToolTip "Right double clicks eneble/unable blinking mode."（en のみ、ja ToolTip には記載なし）。Version ver4.293。 |
| 4 | 結晶/プロファイルリストのキーボード操作 | FM.cs `dataGridViewCrystals_KeyDown` L4481, `dataGridViewProfiles_KeyDown` L4573 | ↑↓で選択移動、Space/Enter でチェック反転。選択中の行の名前を再クリックでもチェック反転。 |
| 5 | Flexible Crystal の線の追加・削除 | FM.cs `pictureBoxMain_MouseDown` L2153-2216 | 行0 (Flexible Crystal) を選択・チェック中、描画エリアの何もない所を**左ダブルクリックで回折線を追加**（強度1, PseudoVoigt）、線上で**右クリックで削除**、左ドラッグで d を変更。 |
| 6 | Unrolled Image タブ (`Unrolled Image`、ja 訳なし) | FM.D tabPage3 他, FM.cs `setFrequencyProfile` L4357-4393 | IPAnalyzer から画像配列付きプロファイルを受信した時のみ表示されるタブ。`Show unrolled image`(既定ON)、`Min.Int.`/`Max.Int.`、`Scale 1`(`Log Scale`/`Liner Scale`, 既定 Liner)、`Scale 2`(`Gray scale`/`Cold-Warm scale`, 既定 Gray)、`Gradient`(`Positive Film`/`Negative Film`, 既定 Negative)、強度頻度グラフ。既定 index は FM.cs L963-965。 |
| 7 | プロファイル間の差の指数入力 | FM.D L708-725, FM.cs `numericUpDownIncreasingPixels_ValueChanged` L4318-4334 | `プロファイル間の差`/`Increasing intensity by a profile` は数値ボックス（既定 **1024**、単位ラベル `counts`/`カウント`）と隣の上下ボタン（n=0〜24, 既定 10 → 値 = 2^n）。値はレジストリ保存（FM.cs L1071）。 |
| 8 | `横軸を最後に読み込んだプロファイルのものにそろえる` の既定・対象 | FM.D L621, FM.cs L3472-3501 | 既定 ON。線源・単色/白色・軸モード・波長・特性X線・取り出し角・TOF角/長さ・各単位を読み込んだプロファイルの値へ切替。 |
| 9 | 横軸単位: センチ度・ミリラジアン等 | HAU.resx `radioButtonAngleUnitCentiDegree` 等 | 2θ: `Degree`/「度」, `Centi-degree`/「センチ度」, `Radian`/「ラディアン」, `Milliradian`/「ミリラジアン」。d: Å / nm。q: Å⁻¹ / nm⁻¹。Energy: eV / KeV / MeV。TOF: μs / ns。（Version ver4.457 の追加機能） |
| 10 | 中性子 TOF 軸のパラメータ | HAU.Designer L522-542, HAU.resx ToolTip | `numericBoxTofAngle`（ヘッダ "2θ", 既定 90°）、`numericBoxTofLength`（ヘッダ "L", 単位 m, 既定 42）。 |
| 11 | 印刷オプションダイアログ (`Print Option` / `印刷オプション`) | FM.cs `DrawPrint` L1348-1409, FormPrintOption.Designer.cs, PDIndexerLocalizationData.cs L142 | 印刷（およびプレビューのページ生成）時に毎回表示。`Print Profile`/「プロファイルを印刷」(既定ON)、`Print Profile Name`/「プロファイル名を印刷」(既定ON)、位置 `Upper Left`/「左上」, `Upper Right`/「右上」(既定), `Lower Left`/「左下」, `Lower Right`/「右下」、`Print Diffraction Peak`/「回折ピークを印刷」(既定ON)。 |
| 12 | ファイル監視の詳細 | FM.cs `watcher_Created` L687-706, L928, `setDirectoryToTheWatchToolStripMenuItem_Click` L3944 | サブメニュー `Set Directory to the watch`（ja 訳なし）とパス入力欄。**サブフォルダも監視**（IncludeSubdirectories=true）。拡張子が `pdi` で終わるファイルのみ（`.pdi2` は対象外）。監視パスはレジストリ非保存。既定 OFF。 |
| 13 | クリップボード監視の既定・受信内容 | FM.D L1587-1589, FM.cs `WndProc` L571-683 | 既定 ON（非保存、起動時に常に接続 L949）。受信対象: DiffractionProfile2 配列（名前が `whole` で終わる場合は単一→複数モードを経て一括追加）、Crystal2（Crystal Parameter 表示中のみ）、IPAnalyzer からの MacroTrigger（`Target=="PDI"` のマクロ実行）。 |
| 14 | ツールチップの既定 | FM.D L1578-1580 | 既定 ON（非保存）。 |
| 15 | ステータスバー | FM.D L542, FM.cs L977, L2926 | プログレスバー、初回読み込み時間（"Initial loading time: {0} ms." / 「初回読み込み時間: {0} ms。」）、プロファイル読込時間（"Time taken to read profiles: … sec."、英語固定）、ショートカット一覧。 |
| 16 | 起動時ダイアログ（Initialize） | FM.cs `FormMain_Load` L777-792, L966-972 | 起動時に CommonDialog を表示して初期化進捗を表示。`AutomaticallyClose` 設定時は終了後自動で閉じる（レジストリ保存 L1059）。 |
| 17 | 複数ファイル読込時の設定共有確認 | FM.cs `readProfile(string[])` L2896-2929 | 複数ファイル（pdi 以外）読込時、10 件ごとに「この設定を以降のプロファイルにも使用しますか?」(`PdiText.MultiProfileSetting`) を確認。Yes で以降 Data Converter を省略。 |
| 18 | GSAS 出力の書式 | FM.cs `exportGSASFormatToolStripMenuItem_Click` L4199-4258 | 拡張子 `.gsa`。2 行目 `BANK 1 n n CONST start step 0 0 FXYE`。X は TOF 以外は ×100（centidegree 想定）、誤差列はプロファイルの誤差、無ければ √Y。 |
| 19 | F1 キーでオンラインヘルプ | FM.cs ctor L733-749 (`FormBase.HelpUrlResolver`)、各フォームの `HelpPage` | 各ウィンドウで F1 を押すと該当章のオンラインマニュアルを開く（FormMain→`1-main-window`、FormLPO→`1-main-window`、FormAboutMe→`appendix/runtime-and-installation`、FormPrintOption→`appendix/file-formats` 等）。ch1 では未記載（ch8 にのみ言及）。 |
| 20 | 起動時のレジストリ自動初期化 | FM.cs ctor L717-725 | 保存されている `Version` が 4440 未満なら起動時にレジストリを全消去（Version.cs ver4.440）。 |
| 21 | レジストリ保存項目 | FM.cs `Registry` L1040-1212 | UI 言語、メイン/EOS/Crystal/Fitting/Profile 各ウィンドウ位置、初期ダイアログ自動クローズ、横軸設定、プロファイル間の差、結晶自動保存、最後に開いたフォルダ・ファイルフィルタ、FormCrystal の表示系チェック 5 項目と下部ピーク高さ、マクロ、ファイル形式別設定、EOS の a0/V0/温度。**色・ツールチップ・クリップボード監視・ファイル監視は非保存**。 |
| 22 | 回折線/プロファイル情報チェックボックス | FM.D L1209, L1314 | プロファイルリスト下 `プロファイル情報`/`Profile Parameter`、結晶リスト下 `回折線/結晶情報 (C)`/`Crystal Parameter (C)`。ツールバーボタンと連動。 |
| 23 | 起動引数（開発者向け） | Program.cs L9-115 | `--capture`, `--capture-form`, `--diagnose`, `--smoke`。ユーザー向けではないので記載不要と思われる（要判断）。 |

---

## 3. 実装上の疑問点

1. **`as Bitmap data` コピーが無動作**: `BitmapToolStripMenuItem` に Click ハンドラ未接続（FM.D L1541-1544）。FM.cs 内に対応処理も無い。
2. **ファイル形式既定値の整数除算**: `Registry()` の XBM/RPT/NPD 初期値 `new HorizontalAxisProperty(WaveSource.Xray, 5 / 180 * Math.PI, EnergyUnitEnum.KeV)`（FM.cs L1149, L1156, L1164）は `5 / 180` が int 除算で 0 → 取り出し角 0 rad になる。NXS は `4.95 / 180`（double）で正しい（L1132）。意図は 5° と思われる。
3. **`SetDrawRangeLimit` の判定対象**: `if (double.IsInfinity(MinimalX)) return;`（FM.cs L1241）はローカル変数 `minimalX` ではなくプロパティ `MinimalX` を見ている。全プロファイルの点数が 2 以下だと `minimalX=+∞` のまま `MinimalX` に代入されうる。
4. **CPS の意味の不一致**: en ラベル "Count per Step (CPS)"・en/ja ToolTip「CPS = カウント / ステップ幅」に対し、実装は露出時間除算（Profile.cs L1158）。ja ラベル「カウント/秒」が実装に合致。どちらに揃えるか作者判断が必要。
5. **GSAS 出力の単位前提**: `div = 100`（TOF 以外, FM.cs L4210）で X を常に ×100。表示単位がセンチ度/ラジアン、または横軸が d・エネルギーの場合にも ×100 され、GSAS の CONST（centidegree）として不正な値になりうる。`FormExportGSAS`（"Export GSAS file -option-"）は定義のみでどこからも開かれていない（grep で参照なし）。
6. **CSV 個別出力のファイル名**: `$"{dlg.FileName[0..^4]} + {d.Name}..."`（L4189）。拡張子 4 文字前提＆リテラル " + " を挟む。プロファイル名にパス不正文字が含まれると例外（try なし）。
7. **`Ctrl+Shift+S` とツールバーの非同期**: `formSequentialAnalysis.Visible` を直接反転（L4792）し `toolStripButtonSequentialAnalysis.Checked` を更新しない。
8. **ヒントの存在しないショートカット**: `Version.HintEn/HintJa` に "Ctrl + Shift + P : Profile Setting" とあるが `FormMain_KeyDown` に `Keys.P` 処理なし。
9. **`numericUpDownIncreasingPixels` の負値分岐が到達不能**: switch の -1〜-5（0.5, 0.1, 0.05, 0.01, 0）分岐（L4320-4328）があるが Minimum 未設定（既定0）のため到達しない。
10. **ウィンドウタイトルの未整備**: FormFitting のタイトルが `FormFitting`（FormFitting.resx `$this.Text`、ja 訳なし）、FormLPO が `FormLPO`（Designer L274）。FormEOS / Cell Finder / Atomic Position Finder / Sequential Analysis / Data Converter / Macro はいずれも ja 訳なし（英語表示）。
11. **Help (web) の ToolTip が PDF のまま**（FM.resx/ja `helpwebToolStripMenuItem.ToolTipText`）。
12. **未使用コントロール/フォーム**: `button2`("NaCl EOS"), `button3`("Pt EOS"), `buttonAu` は親未追加（FM.D L1691-1704）。`FormLimitChanger` は参照なし（PDIndexerLocalizationData 以外）。
13. **About ダイアログの著作権年**: `label1.Text = "Copyright (C) 2005-2022"`（FormAboutMe.resx）。また About に表示される `Version.Condition` は「如何なる商用目的の販売…」等の旧使用条件で、appendix の「MIT ライセンス」記述と内容が異なる（要整合確認）。
14. **色設定が保存されない**: ver3.61 履歴「背景色などを記憶するようにした」に反し、現行 `Registry()` は色を読み書きしない。

---

## 4. 要確認事項

1. ヘルプ > ヒント を「非推奨」と書く根拠がコードに無い。作者方針として残すか削除するか。
2. `Custom white`/「カスタム色」選択時、`radioButtonMonochro_CheckedChanged`（HAU.cs L557-586）はどちらの分岐にも入らず軸の有効/無効を更新しない。白色カスタムスペクトル時の挙動はマニュアル化前に作者確認が必要。
3. 予約（EOS 用）結晶の数: default.xml では 10 件（Au, Pt, NaCl B1, NaCl B2, MgO, Al2O3, Ar, Re, Mo, Pb）。ユーザー保存リスト側で変わりうるかは未確認。
4. `Watch File` が `.pdi2` を対象外としているのは意図か（EndsWith("pdi")）。保存形式が pdi2 に移行（ver4.437）した後も IPAnalyzer 側が `.pdi` を書く前提か。
5. 起動引数（Program.cs）をマニュアルに載せるか。
6. Hint の内容（`HintEn` は 1 件、`HintJa` は 11 件だがコードは常に `HintEn` を使用, FM.cs L782）。ja UI で ja ヒントが出ないのは意図か。
7. クリップボード受信プロファイル名が `whole` で終わる場合の挙動（単一→複数モード切替）が ch7（応力解析モード）以外で説明不要か。

---

## (a) 全フォーム一覧

タイトルは `$this.Text`（resx / Designer / PDIndexerLocalizationData / Crystallography LocalizationData / コード中 Loc）。「ja 訳なし」= ja UI でも英語表示。

| フォーム | タイトル en / ja | 開き方 (ja / en) | 機能概要 | 対応章 |
|---|---|---|---|---|
| FormMain | `PDIndexer   ver4.465 (2026/10/26)`（実行時 FM.cs L847） | 起動時 | メインウィンドウ | 1 |
| FormCrystal | `Crystal Parameter` / `回折線/結晶情報` | ツールバー `回折線/結晶情報 (C)` / `Crystal Parameter (C)`、結晶リスト下チェック、Ctrl+Shift+C | 結晶の格子定数・対称性・原子・回折線表示設定、結晶 DB | 3 |
| FormProfileSetting | `Profile Parameter` / `プロファイル情報` | ツールバー `プロファイル情報 (P)` / `Profile Parameter (P)`、プロファイルリスト下チェック | プロファイル処理（平滑化・BG・マスク・2θオフセット等） | 4 |
| FormEOS | `Equation of States`（ja 訳なし） | ツールバー `状態方程式 (E)` / `Equation of State (E)`、Ctrl+Shift+E | 標準物質の体積から圧力計算 | 5 |
| FormFitting | `FormFitting`（ja 訳なし） | ツールバー `ピークフィッティング (F)` / `Fitting Diffraction Peaks (F)`、Ctrl+Shift+F | 回折ピークフィッティング、格子定数精密化 | 6 |
| FormCellFinder | `Cell Finder`（ja 訳なし） | ツールバー `Cell Finder` | ピーク位置から格子定数探索 | 1 で一行のみ（専用章なし） |
| FormSequentialAnalysis | `Sequential Analysis`（ja 訳なし） | ツールバー `連続分析` / `Sequential Analysis`、Ctrl+Shift+S | 多数プロファイルの連続フィッティング・応力解析 | 7 |
| FormAtomicPositionFinder | `Atomic Position Finder`（ja 訳なし） | ツールバー `Atomic Position Finder` | 回折強度から原子座標探索（UserControlIonicRadius を内包） | 1 で一行のみ（専用章なし） |
| FormLPO | `FormLPO`（ja 訳なし） | ツールバー `LPO Analysis` | 格子選択配向解析（`Get  peak intensities`/「ピーク強度を取得」, `Analyze LPO`/「LPO を解析」, Resolution, HWHM） | 1 で一行のみ（F1 も ch1 へ） |
| FormTwoThetaCalibration | `2θ Calibration` / `2θ 較正` | プロファイル情報ウィンドウの `Calibration using an internal standard` ボタン | 内部標準による 2θ シフト関数 Δ(2θ)=a1+a2 tanθ+a3 tan²θ の決定 | 4 |
| FormDataConverter | `Data Converter`（ja 訳なし） | pdi/pdi2 以外のプロファイル読込時 | 読込データの横軸種別・露出時間・EDX 校正の指定 | 2, appendix/file-formats |
| FormCrystalSelection (Controls) | `Select load / save items` / `読み込み / 保存項目を選択` | ファイル > 結晶リストを読込/追加/保存、xml の D&D | 読込・保存する結晶の選択 | **未記載** |
| FormPrintOption | `Print Option` / `印刷オプション` | ファイル > 印刷 / 印刷プレビュー（ページ生成時） | 印刷内容・プロファイル名位置の選択 | **未記載** |
| FormAboutMe | `About Me`（ja 訳なし） | ヘルプ > `PDIndexerについて` / `About Me` | バージョン、作者、連絡先、使用条件、履歴 | 1, appendix/runtime |
| CommonDialog (Controls) | 初期化中は "Now Loading..." 等（resx 既定 `Calculating...`） | 起動時 / ヘルプ > `ヒント` / `Hint` | 初期化進捗・ヒント表示 | 1（ヒントのみ） |
| FormMacro (Controls) | `Macro`（ja 訳なし） | マクロ > `編集` / `Editor`（登録マクロはマクロメニュー下に列挙, FM.cs `SetMacroToMenu` L3804） | IronPython マクロ編集・実行 | 8 |
| FormChemicalComposition (Controls) | `Details of the chemical composition` / `化学組成の詳細` | 回折線/結晶情報ウィンドウの結晶コントロール右クリック > `化学組成の詳細` / `Details of the chemical composition` | 化学組成の詳細（酸化物/ハロゲン化物/硫化物換算、価数）| **未記載** |
| FormBeamInteraction (Controls) | `Beam Interaction` / `ビーム相互作用` | 結晶コントロール右クリック > `ビーム相互作用` / ボタン `Beam interaction` | X線/電子/中性子との相互作用（散乱因子等） | **未記載** |
| FormSymmetryInformation (Controls) | `Symmetry Information`（ja 訳なし） | 結晶コントロール右クリック > `対称性詳細` / `Symmetry Information`、ボタン `対称性詳細`/`Symmetry info.` | 空間群情報（幾何計算・ワイコフ位置・反射条件・対称操作…） | **未記載** |
| FormSuperStructure (Controls) | `Set superstructure size`（ja 訳なし） | 結晶コントロール右クリック > `超構造に変換` / `Convert to a superstructure` | 超構造セルへの変換 | **未記載** |
| FormAnotherSpaceGroup (Controls) | `Convert to another spacegroup` / `別の空間群へ変換` | 結晶コントロール右クリック > `異なる軸・原点セッティングの空間群に変換` / `Change the axes/origin setting` | 軸・原点セッティング変更 | **未記載** |
| FormStrain (Controls) | `Strain Control` / `格子ひずみ (invisible)` | 結晶コントロール右クリック > `格子ひずみ (invisible)` / `Strain Control` | 弾性定数に基づく格子ひずみ（ja 表記に "(invisible)" が残る） | **未記載** |
| FormNumericUpdownControl (Controls) | `NumericUpdown Control` / `NumericUpdown コントロール` | 回折線/結晶情報ウィンドウのしきい値 NumericUpDown を右クリック（FormCrystal.cs L244-250） | 増分等の設定 | 未記載 |
| FormExportGSAS | `Export GSAS file -option-` / `GSAS ファイルのエクスポート -オプション-` | **どこからも開かれない**（未使用） | GSAS EXP 作成オプション | — |
| FormLimitChanger | `FormLimitChanger` | **どこからも開かれない**（未使用） | X/Y 上下限変更 | — |
| UserControlIonicRadius | （UserControl） | Atomic Position Finder 内 | 元素ごとのイオン半径入力（Å） | — |

※結晶コントロール右クリックメニューには他に `P1に変換`/`Convert to P1 Space Group`、`アプリ起動時の格子定数に戻す`/`Revert cell constants`（ch3 L124 に記載あり）、`CIFファイル又はAMCファイルから読み込み`、`CIFファイルとして出力`、`Send this crystal to other software`（CrystalControl.Designer.cs L1088）。

---

## (b) Version.cs 履歴（ver4.384〜4.465）とマニュアル反映状況

docs/src/ja・en 全ページを grep して確認。

| 版 | 内容 (Version.cs) | マニュアル反映 |
|---|---|---|
| 4.465 | 結晶右クリックに化学組成ウィンドウ（酸化物/ハロゲン化物/硫化物換算、価数）、原子量を CIAAW 2024 に更新 | **未反映**（「化学組成」「CIAAW」「原子量」いずれもヒットなし） |
| 4.464 | arm64 配布パッケージ | 反映（appendix/runtime-and-installation L12-14, L36） |
| 4.463 | インストーラを WiX へ移行 | 反映（MSI 資産名 `PDIndexer-setup.msi`/`_arm64.msi`） |
| 4.462 | ツールチップ更新、portable ZIP | ZIP は反映（appendix）。**ZIP 版で「アップデートをチェック」が非表示になる点は未記載**（FM.cs L772-775） |
| 4.461 | マクロ API を FormMain の public プロパティ経由に変更 | ch8 担当で要確認（本監査では未精査） |
| 4.457 | 横軸単位にセンチ度・ミリラジアン追加 | **未反映**（ch1 横軸タブに単位選択の記述自体がない） |
| 4.453 | NaCl B1 EOS (Skelton 1984)、.NET Desktop Runtime 10.0 | Skelton は ch5 に反映。.NET 10 は index・appendix に反映だが **0-overview.md (ja/en L45) が「6.0 以上」のまま** |
| 4.447/4.448 | .NET 9、小数点記号（カンマ区切りロケール）不具合修正 | ランタイムは上書き済み。小数点記号の注意はトラブルシューティング未記載（任意） |
| 4.443 / 4.413 / 4.405 / 4.399 | .NET 8 / 7 / 6 / 5 | 旧情報（0-overview の 6.0 記述が名残） |
| 4.440 | レジストリ読み書き改善、本版初回起動でレジストリ消去 | **未記載**（FM.cs L721 で Version<4440 なら消去） |
| 4.437 | プロファイル形式を `*.pdi2` に変更、横軸単位変更不具合修正 | pdi2 は反映（ch1, ch2, appendix） |
| 4.418 | 'Sequential Analysis'（旧 'Stress Analysis'） | ch7 で応力解析は説明あり。旧名称からの改名は未記載（任意） |
| 4.412 | Pb EOS (Strässle 2014) | 反映（ch5） |
| 4.410 | `*.xy` 対応 | 反映（appendix/file-formats L27） |
| 4.408 | CIF の D（重水素）対応、Wyckoff 表示修正 | **未記載**（重水素/deuterium ヒットなし。ch3 担当で要判断） |
| 4.399 | Fratanduono 2021 EOS | 反映（ch5） |
| 4.395 | 複数 EDX 読込改善、Mo EOS | Mo は反映（ch5）。複数 EDX は明示記載なし |
| 4.394 | オプション 'Save the crystal list when closing' | 反映（ch1 L74）。ただし既定 ON・OFF 時は初期リストで起動する点は未記載 |
| 4.392 | 3次 Vinet | ch5 に Vinet 記載あり（次数の確認は ch5 担当） |
| 4.388 | 4th BM, AP2, Keane | 反映（ch5 で BM4/AP2/Keane ヒット） |
| 4.387 | Re の EOS 3 種 (Sakai) | ch5 で Re は `Zha et al. (04)` ほかと記載。Sakai 由来 Re 式の明記は ch5 担当で要確認 |
| 4.384 | Crystal Parameter に AMCSD 結晶データベース | 反映（ch3, appendix） |
| 4.375 | nxs 形式 | 反映（ch2, appendix） |
| 4.293 (参考, 旧) | 結晶リスト右ダブルクリックで点滅モード | **未記載** |
| 4.321 / 4.322 (参考, 旧) | Ctrl+Shift+Space / Ctrl+Alt+Space | **未記載** |
| 3.67 (参考, 旧) | Ctrl+Shift+S（Stress→Sequential） | **未記載** |

その他コード上の新しめの変更で未記載: 多言語メニュー（11 言語・自動再起動, 260625Cl）、F1 オンラインヘルプ（260604Cl）、Help(web) の PDF→オンライン化（260625Cl）。

---

## 5. 補足: 下書き用素材

### メニュー構成（実ラベル ja / en, FM.D L1420-1689, FM.resx / FM.ja.resx）
- `ファイル` / `File`
  - `プロファイルを読込` / `Read profile(s)` — ファイルフィルタ "Powder Pattern File (WinPIP[*.csv]; Fit2D[*.chi]; PDI[*.pdi,pdi2], EDX profile[*.rpt, *.npd, *.nxs])" と "Any format(Auto[*.*])"（FM.cs L2881-2882）、複数選択可、前回フォルダ記憶。
  - `プロファイルを書き込み` / `Save profile(s)` — 全プロファイルを `.pdi2`。
  - `プロファイルをエクスポート(csv)` / `Export the selected profile(s)` ▸ `as CSV (comma separated values) file` / `as TSV (tab separated values) file` / `as GSAS file`（サブ項目 ja 訳なし）
  - `結晶リストを読込 (現在のリストを消去)` / `Load crystals (as a new list)`
  - `結晶リストを読込 (現在のリストに追加)` / `Load crystals (and add to the present list)`
  - `結晶リストを保存` / `Save crystals`
  - `結晶情報をCIF, AMC ファイルから読込` / `Import CIF, AMC...`
  - `選択結晶をCIF フォーマットで出力` / `Export the selected crystal to CIF`
  - `結晶リストをインストール直後の状態に戻す` / `Revert crystals to the initial state`（インストールフォルダの default.xml を確認なしで読込）
  - `ページ設定` / `Page Setup`、`印刷プレビュー` / `Print Preview`、`印刷` / `Print`
  - `コピー` / `Copy to Clipboard` ▸ `as Bitmap`(ja) / `as Bitmap data`(en)（無動作）、`as Metafile data`（ja 訳なし, EMF+Dual）
  - `メタファイルとして保存` / `Save as Metafile`（`.emf`）
  - `閉じる` / `Close`
- `オプション` / `Option`: `ツールチップ` / `Tool Tip`(既定ON)、`クリップボードを監視` / `Watch Clipboard`(既定ON)、`ファイルを監視` / `Watch File`(既定OFF) ▸ `Set Directory to the watch` + パス欄、`レジストリを消去 (チェックして再起動)` / `Clear Registry (check and restart)`(既定OFF)、`終了時に結晶リストを自動保存する` / `Save the crystal list when closing`(既定ON)
- `マクロ` / `Macro`: `編集` / `Editor`（＋登録マクロ名の一覧）
- `ヘルプ` / `Help`: `PDIndexerについて` / `About Me`、`アップデートをチェック` / `Program Updates`（ZIP 版では非表示）、`ヒント` / `Hint`、`ヘルプ (web)` / `Help (web)`
- `Language`（ja 訳なし）: `English` / `日本語` / `Deutsch` / `Français` / `Español` / `Português` / `Italiano` / `Русский` / `简体中文` / `繁體中文` / `한국어`

### 色設定 + 複数プロファイル表示設定タブ（`Appearance & Single/Multi Profile`）既定値
- `目盛り線を表示`/`Scale Line`: OFF、`エラーバーを表示`/`Error bar`: OFF
- 色設定 (`色設定`/`Color`): `背景色`/`Back Color` 白、`目盛り線`/`Scale Line` RGB(211,211,211)、`目盛文字色`/`Scale Text` 黒（非保存）
- 単/複数プロファイル設定 (`単/複数プロファイル設定`/`Single/Multi Profile`): `複数プロファイルを表示`/`Multi Profiles` が既定、`色を自動で変更`/`Change automaticaly color` ON（複数モード時、新規プロファイルにランダム色。OFF または単一モードでは青）、`プロファイル間の差`/`Increasing intensity by a profile` 1024 `カウント`/`counts`（上下ボタンは 2^n, n=0–24）
- 縦軸 (`縦軸`/`Vertical Axis`): `カウント`/`Raw Counts` または `カウント/秒 (CPS)`/`Count per Step (CPS)`（既定 CPS、実装は露出時間で除算）；`リニアスケール`/`Linearity`（既定）または `対数スケール`/`Logarithm`（log10）

### 横軸タブ（`横軸` / `Horizontal Axis`）素材
- `横軸を最後に読み込んだプロファイルのものにそろえる` / `After reading profile, change horizontanl axis`（既定 ON）
- `線種`/`Source`: `X線`/`X-ray`(既定), `電子線`/`Electron`, `中性子線`/`Neutron`
- `単色/白色`/`Color mode`: `単色`/`Monochromatic`(既定), `白色`/`Flat White`, `カスタム色`/`Custom white`
- `波長`/`Wavelength`: 波長直接入力・電子線加速電圧・特性X線（元素＋線種）（ToolTip `waveLengthControl.ToolTip`）
- `横軸`/`Horizontal axis`: `2θ (角度)`/`2θ (Angle)`(単色のみ), `d値`/`d-spacing`, `波数`/`q (wavenumber)`（q = 4π·sinθ/λ）, `エネルギー`/`Energy`(白色のみ), `中性子TOF`/`Neutron TOF`(中性子＋白色のみ)
- `単位`/`Unit options`: 2θ: `度`/`Degree`, `センチ度`/`Centi-degree`, `ラディアン`/`Radian`, `ミリラジアン`/`Milliradian`；d: Å, nm；q: Å⁻¹, nm⁻¹；Energy: eV, KeV, MeV（＋取り出し角 2θ [°]）；TOF: μs, ns（＋ 2θ 既定 90°, L 既定 42 m）

### マウス操作（実装準拠の表案）
| 操作 | 動作 |
|---|---|
| 回折線上で左ドラッグ | 選択中の結晶の格子定数 a,b,c を同率で変更（回折線移動） |
| 空白部で左ドラッグ／中ドラッグ | 表示範囲を平行移動 |
| 右ドラッグ（10 px 以上の矩形） | 矩形範囲に拡大 |
| 右クリック | 表示幅を 2 倍に縮小（全範囲表示中に素早く連打すると横軸上限を 1.2 倍に拡張） |
| Flexible Crystal 選択時: 左ダブルクリック / 線上で右クリック | 回折線の追加 / 削除 |
| 結晶リスト行の右ダブルクリック | 点滅モードの切替 |
| ファイルをドロップ | xml → 結晶リストに追加、cif/amc → 回折線/結晶情報へ取り込み、その他 → プロファイル読込 |

（BG 点モード・マスク範囲モード時のマウス操作は FormProfileSetting 側の状態に依存。FM.cs L2100-2132, L2252-2266 — ch4 で扱うべき内容）
