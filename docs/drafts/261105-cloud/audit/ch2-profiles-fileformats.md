<!-- 261105Cl: docs/drafts/261105-cloud — 既存マニュアルとコードの突き合わせ結果 (監査)。docs/src には未統合。 -->
# 第2章 プロファイルデータ ＋ 付録（ファイル形式／動作環境とインストール／トラブルシューティング）監査

> 本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象マニュアル: `docs/src/ja/2-pattern-profiles.md`, `docs/src/ja/appendix/file-formats.md`, `docs/src/ja/appendix/runtime-and-installation.md`, `docs/src/ja/appendix/troubleshooting.md`（および `docs/src/en/` 同名ページ、`0-overview.md` / `index.md` のランタイム記述）

主な参照コード:
- `PDIndexer/FormMain.cs` — `menuItemFileRead_Click` (L2876), `readProfile(string[])` (L2896), `readProfile(string,...)` (L2931–3451), `FileType` enum (L51), FileProperty 既定値 (L1093–1190), クリップボード `WndProc` (L571), `watcher_Created` (L687), `FormMain_DragDrop` (L4733), `savePatternProfileToolStripMenuItem_Click`/`SaveProfile` (L3975), `toolStripMenuItemExportCSVFile_Click` (L4150), `exportGSASFormatToolStripMenuItem_Click` (L4199)
- `Crystallography/IO/PdiFile.cs` — `XYFile.ReadPdi2File` / `ReadRasFile` / `ReadCSVFile` / `ConvertUnknownFileToProfileData` / `SavePdi2File`
- `PDIndexer/DataConverter/FormDataConverter.*`, `EDXControl.*`
- `Crystallography/Profile.cs` — `HorizontalAxisProperty` (L1232), `HorizontalAxisConverter` (L1422〜), `UniversalConstants.cs` `Convert` クラス
- `Crystallography.Controls/Wave/HorizontalAxisUserControl.resx / .ja.resx`
- `PDIndexer/PDIndexer.csproj`, `PDIndexerSetup.Wix/*`, `README-PORTABLE.txt`, `.github/workflows/release.yml`, `build-arm64-portable.yml`

---

## 1. 食い違い（マニュアル記述 vs コード）

| # | マニュアル箇所 (file:見出し/行) | マニュアルの記述 | コードの実際 (file:method/line) | 深刻度 |
|---|---|---|---|---|
| 1 | `ja/0-overview.md` L45（en 同 L45） | 「.NET Desktop Runtime 6.0 以上」 | `PDIndexer.csproj` L5 `<TargetFramework>net10.0-windows</TargetFramework>`。release.yml も「Setup .NET 10」、MSI スモークは `Microsoft.WindowsDesktop.App 10.` を確認 (release.yml L374)。**現行は 10.0**。index.md / runtime-and-installation.md の 10.0 が正しい | 高 |
| 2 | `appendix/file-formats.md`「GSAS 形式での出力」/ `2-pattern-profiles.md`「プロファイルの書き出し」 | GSAS を選ぶと「書き出される内容を確認するエクスポート画面が表示されます」（FormExportGSAS のスクショ付き） | `FormMain.cs` `exportGSASFormatToolStripMenuItem_Click` (L4199–4255) は SaveFileDialog（`*.gsa`）を出して**直接ファイルへ書き込む**。`FormExportGSAS` はソリューション内で一度も `new` されていない（grep で生成箇所なし）。確認画面は現行 UI では表示されない | 高 |
| 3 | `troubleshooting.md`「表示言語が切り替わらない」 | 「オプション ▸ 言語 から English (need restart) / Japanese (need restart) を選択」「すぐに変わらないのは正常。いったん終了し、もう一度起動」 | `FormMain.cs` `PopulateLanguageMenu` (L3888) が `SupportedCultures.All` のうち Released=true の 11 言語（English, 日本語, Deutsch, Français, Español, Português, Italiano, Русский, 简体中文, 繁體中文, 한국어; `Crystallography/Localization/SupportedCultures.cs` L54–67）を **NativeName** で動的生成。`languageToolStripMenuItem_Click` (L3849) は「再起動が必要です…今すぐ再起動しますか？」の確認後 `Application.Restart()` で**自動再起動**する。resx の "English (need restart)" 項目は PopulateLanguageMenu で Clear されるため表示されない | 高 |
| 4 | `file-formats.md` 表 `npd` 行 | 「ヘッダの EGC0/1/2・2Theta・Live time などを読み取り、チャンネル番号をエネルギーへ変換します」 | `FormMain.cs` L3231–3281: EGC0/1/2・2Theta・Live time は読み取って**ダイアログに表示するだけ**。データは `Data length` 行の 2 行後から各行の 2 列目を `×1000`（keV→eV）して X、3 列目を Y とする（L3268–3270）。**EGC はエネルギー変換に使われない**。また `EnergyUnit = eV` を強制設定 (L3238) | 中 |
| 5 | `file-formats.md` 表 `rpt` 行 | 「取り出し角・露出時間・EGC をヘッダから読み取ります」 | `FormMain.cs` L3193–3228: ファイル**末尾**行から読む（取り出し角 = `strList[^4]` の第1トークン、露出時間 = `strList[^5]` 第2トークン、EGC = `strList[^1]` の a0, a1 のみ）。**a2 は読まず、変換式も `E = (a0 + a1·n)×1000`（2次項なし）** (L3219)。データ行は 2 行目〜末尾 6 行手前 | 中 |
| 6 | `2-pattern-profiles.md`「Data Converter ダイアログ」/ `file-formats.md`「SSD データ…2 次の校正式」 | `E = a₀ + a₁n + a₂n²`（E: eV）でチャンネル→エネルギー変換（UI ラベルも `E: energy in eV`） | 形式ごとに実装がばらばら: **xbm** `x = (a0 + a1 n + a2 n²)×1000` (L3181, n=1 から), **rpt** `x = (a0 + a1 n)×1000` (L3219, n=1 から), **nxs** `x = a0 + a1 n + a2 n²`（×1000 なし, n=0 から, L3029）, **npd** 変換なし（#4）。`FileProperty.EGC` の doc コメントは「E = (a₀ + a₁ n + a₂ n²) * 10³」(FormMain.cs L40)。つまり xbm/rpt では係数は keV 単位、nxs では eV 単位として扱われ、UI ラベル（eV）と一致しないケースがある | 中 |
| 7 | `file-formats.md`「Low energy cutoff」/ `2-pattern-profiles.md` 同 | 「チェックすると、指定値より低エネルギー側のデータ点を除外」「右の閾値（eV）以下で切り捨て」 | 既定値 10000 eV（`FormDataConverter.Designer.cs` L83, FooterText `eV`）。xbm/rpt/npd: `x > LowEnergyCutoffValue / 1000` の点だけ残す (L3183, L3221, L3272) — x は eV、閾値は /1000 されており単位が不整合（実質 1/1000 の閾値）。nxs: `pts.Where(p => p.X < LowEnergyCutoffValue)` (L3032) で**閾値未満を残す＝逆向き**。マニュアルの記述通りに動くのはどの形式でもない可能性（§3-2） | 中 |
| 8 | `file-formats.md`「書き込み・エクスポート」/ `2-pattern-profiles.md` | Export は「選択中のプロファイル」を CSV「カンマ区切り（角度, 強度）」等で書き出す | CSV/TSV: `toolStripMenuItemExportCSVFile_Click` (L4150) は**チェックされている全プロファイル** (`DataTableProfile.CheckedItems`) を対象とし、`MergeProfiles` メッセージ (Yes=1ファイルに結合 / No=個別 / Cancel) を出す。結合時: 1行目 `名前,,,`、2行目 `X,Y,,`、以降 `x,y,,` の繰り返し。個別時: ファイル名 `"<保存名から拡張子4文字除去> + <プロファイル名>.csv"`、1行目 `X,Y`。値は**現在の横軸表示単位に変換済みの `Profile`**（角度とは限らない）。GSAS: **現在行（`bindingSourceProfile.Current`）の1本のみ** | 中 |
| 9 | `2-pattern-profiles.md` 表 `csv` 行 / `file-formats.md` `csv` 行 | 「WinPIP の出力（カンマ区切り：角度,強度）」 | `XYFile.ReadCSVFile` (PdiFile.cs L220) の doc は「複数のプロファイルを含むCSV形式(**PDI独自形式**)」。2行目が `X,Y,` で始まり、1行目タイトル数×2 = 2行目列数の場合のみ多プロファイル CSV として読む（=PDIndexer 自身の CSV 結合エクスポート形式, #8）。それ以外の csv は汎用テキスト解析 (`ConvertUnknownFileToProfileData`) にフォールバック。なおファイルダイアログのフィルタ文字列は `WinPIP[*.csv]` のまま (FormMain.cs L2881) | 中 |
| 10 | `file-formats.md`「複数ファイルの一括読み込み」 | 「最初のファイルで設定を確定した後に、同じ設定を以降にも使うか確認」 | `readProfile(string[])` L2896–2928: ファイル名を **OrdinalIgnoreCase でソート**してから読む。確認は `i % 10 == 0`（1, 11, 21 …本目の後）で、`No` を選ぶと 10 本ごとに再度確認される。判定条件 `!fileNames[i].EndsWith(".pdi")` のため **.pdi2 でも確認が出る**（大文字 .PDI も対象外にならない） | 低 |
| 11 | `file-formats.md`「データ変換ダイアログ」第1段落 | 対象に `xy`, `gsa` を含め全非 pdi で開く | 概ね一致。ただし `xy` は 1 行目が `# == pyFAI calibration ==` の場合のみ pyFAI 形式として処理 (L3338)。それ以外の `.xy` は汎用テキスト扱い。pyFAI 処理では波長 = 16 行目第3トークン [m] ×1e9 → nm、データは 24 行目以降の 2 列 | 低 |
| 12 | `2-pattern-profiles.md`「その他テキスト」「角度（または d 値）－強度の **2 列**テキスト」 | 2列テキスト | `ConvertUnknownFileToProfileData` は多列可: X 列＝等間隔増加列を自動検出、Y＝その**右隣の列**（なければ左隣）(PdiFile.cs L370–377)。区切りは `,`→空白→TAB→`,` の順に試行（小数点がカンマの環境では最初の `,` を飛ばす, FormMain.cs L3404–3412） | 低 |
| 13 | `2-pattern-profiles.md` 表 `npd / xbm / rpt（rpf）` | `rpf` も対象拡張子のような記述 | コードが扱うのは `rpt` のみ (FormMain.cs L2947 `"rpt" => FileType.RPT`)。`rpf` は `groupBoxEDX.Text = "For SSD data (*.rpf, *.npd, *.xbm, *.nxs)"`（FormDataConverter.resx）の UI ラベル上の表記（typo の疑い）にすぎない | 低 |
| 14 | `2-pattern-profiles.md`/`file-formats.md`「ファイル監視」 | 「新しく作成された `pdi` ファイルを自動読み込み」 | `watcher_Created` (L689) は `e.FullPath.EndsWith("pdi")` 判定のため **`.pdi2` は監視対象外**。`FileSystemWatcher { IncludeSubdirectories = true }` (L928) で**サブフォルダも監視**。`Created` イベントのみ（上書き更新は対象外）。ファイルがロック解除されるまで 100 ms 間隔で待機 | 低 |
| 15 | `2-pattern-profiles.md`「クリップボード監視」/ troubleshooting | 「他アプリからコピーされたプロファイル／結晶を自動で取り込みます」 | `WndProc` WM_DRAWCLIPBOARD (L571〜): byte[] 先頭バイトが `DiffractionProfile2.ID` ならプロファイル配列、`Crystal2.ID` なら結晶だが**結晶は `formCrystal.Visible` のときのみ**取り込む (L622)。名前が "whole" で終わる場合はマルチモードで先頭のみチェック。`MacroTrigger`（Target=="PDI"）を受けてマクロ実行する機能もある（未記載） | 低 |
| 16 | `file-formats.md`「GSAS 形式での出力」注記 | 「中性子 TOF データの場合はスケールせず」 | `div = AxisMode == HorizontalAxis.NeutronTOF ? 1 : 100` (L4210) — 判定はプロファイル自身ではなく**メイン画面の現在の横軸モード**。出力値も現在の表示軸に変換済み `dp.Profile` を使う。ヘッダの start/step は `f2`（小数2桁）、各値は 11 桁に切詰め右詰め | 低 |
| 17 | `file-formats.md` `xbm` 行 | 「メタ情報をコメントとして取り込みます」 | コメント化に加え、取り出し角 (0x05B2)、露出時間 = Live time (0x05F4)、EGC (0x59A/0x5A2/0x5AA) を**ダイアログへ自動設定**し EDX 設定を表示 (L3157–3168)。データ点数 = Int16 @0x814、データ UInt32 列 @0x816 | 低 |
| 18 | `file-formats.md` `ras` 行 | 「機器情報を含むテキスト形式」 | `ReadRasFile` は `*RAS_INT_START`〜`*RAS_INT_END` 間の第1・2列のみ読み、ヘッダの機器情報（波長等）は**使わない**。複数ブロックは `-0`, `-1`…付きの複数プロファイル。線源はダイアログ／既定値（Cu Kα1、度; FormMain.cs L1111–1117） | 低 |
| 19 | `troubleshooting.md`「起動しない」対処 | 「.NET Desktop Runtime 10.0（x64）をインストール」 | Arm64 版 MSI (`PDIndexer-setup_arm64.msi`) 利用者は Arm64 版ランタイムが必要（runtime-and-installation.md 本文はそう書いている）。portable ZIP は self-contained でランタイム不要。トラブルシューティング側が x64 のみ・MSI 前提になっている | 低 |
| 20 | `runtime-and-installation.md`「アップデート」 | 「ヘルプ ▸ アップデートをチェック をときどき実行して」 | portable ZIP 版では実行フォルダに `README-PORTABLE.txt` があると `programUpdatesToolStripMenuItem.Visible = false` (FormMain.cs L774–775)。**ZIP 版にはこのメニューが無い**。また更新時に取得するのは `RuntimeInformation.ProcessArchitecture` に応じ `PDIndexer-setup_arm64.msi` / `PDIndexer-setup.msi` (L4641) | 中 |
| 21 | ja `2-pattern-profiles.md`/`file-formats.md` の UI 名 | 「データ変換 (Data Converter)」「プロファイルをエクスポート」 | `FormDataConverter.ja.resx` に `$this.Text` が無く、日本語 UI でもタイトルは `Data Converter`。`groupBoxEDX`・`checkBoxLowEnergyCutoff`・`label2` も ja 未訳（英語表示）。エクスポートの ja ラベルは `プロファイルをエクスポート(csv)`（FormMain.ja.resx `toolStripMenuItemExportExcelFile.Text`）。サブ項目 `as CSV…`/`as TSV…`/`as GSAS file` は ja 未訳 | 低 |
| 22 | en `2-pattern-profiles.md` | `After reading profile, change horizontal axis` / `Change automatically color` | 実ラベルは typo 入り: `After reading profile, change horizontanl axis`、`Change automaticaly color`（FormMain.resx）。マニュアル側を直すか resx を直すかは要判断 | 低 |

ja/en 間の差異: 本スコープ 4 ページでは構成・内容とも実質同一で、内容上の食い違いは見当たらない（いずれも上記の誤りを両言語で共有）。

---

## 2. マニュアル未記載の機能・設定

| # | 機能/コントロール (UI 英/日ラベル) | 実装箇所 | 概要 (既定値・単位を含む) |
|---|---|---|---|
| 1 | 中性子 TOF「MPLOT」テキスト形式（拡張子不問） | FormMain.cs L3286–3335 | 1行目が `**  MPLOT FILE **` で始まるファイルを自動判別。線源=中性子・白色・横軸=Neutron TOF を自動設定。`-----…`（47 個のハイフン）行の次から最終行の手前まで `TOF 強度 誤差` の3列を読み、誤差も保持。`"""` で囲まれたブロックをコメントに格納。既定 TOF パラメータ: 2θ=90°, L=26.5 m, μs (L1168–1173) |
| 2 | ファイル種別ごとの Data Converter 設定の記憶 | `FileProperties` (FormMain.cs L84, `Reg.RW(... FileProperties)` L1093) | 形式（CSV, RAS, NXS, CHI, XBM, RPT, NPD, TOF, XY, OTHERS, GSA）ごとに横軸設定・露出時間・EGC をレジストリに保存し、次回同形式の読み込み時に初期値として使う。初回既定値: RAS=Cu Kα1・度、CSV/CHI/その他=X線 λ=0.4 nm・度、GSA=X線 λ=0.4 nm・**センチ度**、NXS=白色X線 取り出し角4.95°・keV・EGC `[[0,0,66.6,0.0]]`、XBM/RPT/NPD=白色X線・keV（取り出し角は §3-4 参照）、TOF=90°/26.5 m/μs |
| 3 | ファイルを開くダイアログのフィルタ | FormMain.cs L2881–2882 | 1番目: `Powder Pattern File (WinPIP[*.csv]; Fit2D[*.chi]; PDI[*.pdi,pdi2], EDX profile[*.rpt, *.npd, *.nxs])`（csv/chi/pdi/pdi2/rpt/npd/nxs）、2番目: `Any format(Auto[*.*])`。**ras / xbm / xy / gsa / tsv は 2 番目を選ばないと表示されない**。選択したフィルタ番号は `FilterIndex` としてレジストリ保存 (L1073) |
| 4 | ドラッグ＆ドロップでの結晶読み込み | `FormMain_DragDrop` L4733–4755 | 1ファイルのみドロップ時: `*.xml` → 結晶リスト読込 (`readCrystal(…, true, false)`)、`*.cif`/`*.amc` → 結晶情報ウィンドウを開いて取り込み。それ以外・複数ファイルはプロファイルとして読む |
| 5 | pdi/pdi2 読み込み時の自動処理 | FormMain.cs L2961–2980 | `SubtractBackground=false` に強制、先頭・末尾の強度 0 の点を削除。X 線で `WaveLength > 1` の場合は旧形式とみなし `EnergyToXrayWaveLength(WaveLength×10000)` で波長へ変換 |
| 6 | pdi 旧テキスト形式の読み込み | `ReadPdi2File` catch 節 (PdiFile.cs L120–170) | XML として読めない場合、1行目 `Wave Length (nm)` / `(0.1nm)`、5行目 `Mode:Angle / d-spacing / Energy`、6行目以降 `x,y` の旧形式として読む |
| 7 | pdi / pdi2 の実体 | `SavePdi2File`/`ReadPdi2File` | いずれも XmlSerializer の XML。pdi2 = `DiffractionProfile2[]`、pdi = 旧 `DiffractionProfile[]`（読み込み時に `ConvertToDiffractionProfile2`）。保存は常に pdi2（拡張子が無ければ付加, L3993） |
| 8 | NXS（NeXus/HDF5）の具体的処理 | FormMain.cs L2984–3044 | パスに `/histogram` を含むデータセット数 = 検出器数として EDXControl を生成（各 `#0`, `#1`…のチェックで有効/無効）。各 `int[,]` を第1次元で合算し、`E = a0 + a1·n + a2·n²`（n=0 起点）、E>0 の点のみ、最後の1点を削除 |
| 9 | GSAS (`.gsa`) 読み込みの詳細 | FormMain.cs L3370–3393 | `BANK` で始まる最初の行の次から、空白区切りでちょうど3トークンの行を `x, y, err` として読む（ヘッダの CONST/start/step は使わない）。既定横軸はセンチ度 |
| 10 | 横軸単位の選択肢（Data Converter 内 HorizontalAxisUserControl） | `Crystallography.Controls/Wave/HorizontalAxisUserControl.resx` / `.ja.resx` | 横軸: `2θ (Angle)`/`2θ (角度)`, `d-spacing`/`d値`, `q (wavenumber)`/`波数`, `Energy`/`エネルギー`, `Neutron TOF`/`中性子TOF`。単位: 角度 `Degree/Radian/Centi-degree/Milliradian`（度/ラディアン/センチ度/ミリラディアン）、d `Å/nm`、q `Å⁻¹/nm⁻¹`、エネルギー `eV/KeV/MeV`、TOF `μs/ns`。TOF 距離 `L` [m]、TOF 角 `2θ` [°] |
| 11 | MSI のインストール先・権限 | `PDIndexerSetup.Wix/Package.wxs` L8–41 | `Scope="perUser"`、インストール先 `%LocalAppData%\Crystallography Software\PDIndexer`（管理者権限不要）。デスクトップ／スタートメニュー（Crystallography Software）にショートカット、完了画面に `Launch PDIndexer`（既定 ON）。ダウングレードはブロック、x64⇔arm64 の同版クロスグレード可 |
| 12 | 旧名 MSI `PDIndexerSetup.msi` | release.yml L156–163, L478 | `PDIndexer-setup.msi` と同一バイトのコピーを旧クライアント自動更新互換のためリリースに併置 |
| 13 | クリップボード経由のマクロ起動 | `WndProc` L639–653 | IPAnalyzer 等からの `MacroTrigger`（Target=="PDI"）を受けるとマクロウィンドウを開き、指定マクロ名（または現在のマクロ）を実行 |

---

## 3. 実装上の疑問点

1. **pdi/pdi2 を読むだけでファイルを書き換える**: `ReadPdi2File` (PdiFile.cs L36–56) は読み込み前に全行で `OriginalFormatType→SrcAxisMode` 等に加え `tempstr.Replace("pt", "Pt")` を行い、**元ファイルへ上書き保存**する。名前・コメント中の "pt"（例: "script", "except", "Opt"）も "Pt" に変わり得るし、読み取り専用／監視フォルダのファイルを変更する。catch 節でも末尾 `\0` 除去後に上書き。
2. **Low energy cutoff の単位・向きの不整合**: xbm/rpt/npd は X[eV] と `LowEnergyCutoffValue/1000` を比較（FormMain.cs L3183/3221/3272）、nxs は `p.X < cutoff` の点を**残す**（L3032、逆向き）。UI 既定 10000 eV。
3. **TOF ns データの二重変換**: 読み込み末尾 (L3441–3445) で `TofTimeUnit == NanoSecond` のとき X を /1000（ns→μs）するが、`SrcProperty.TofTimeUnit` は NanoSecond のまま。`HorizontalAxisConverter.ConvertToD` (Profile.cs L1561–1565) でも NanoSecond なら再度 /1000 されるため、d 換算が 1000 倍ずれる可能性。
4. **EDX 既定取り出し角が 0**: XBM/RPT/NPD の既定 `new HorizontalAxisProperty(WaveSource.Xray, 5 / 180 * Math.PI, EnergyUnitEnum.KeV)` (L1149/1156/1164) は整数除算で `5/180 = 0` → 0 rad。xbm/rpt/npd ではファイルから上書きされるので実害は限定的だが意図（5°）と異なる。NXS は `4.95 / 180` で問題なし。
5. **NXS 既定 EGC が4要素**: `EGC = [[0, 0, 66.6, 0.0]]` (L1133)。`EDXControl.EGC` setter は `value.Length == 3` のときのみ反映するため無視される。
6. **pyFAI `.xy` が既定状態で読めない可能性**: `FileType.XY` は既定値初期化ブロック (L1108–1190) に含まれない。`FileProperties` は `record struct` の配列で既定 (default) 要素は `EGC = null`。`SetProperty` → `EGC = null` → `EGC` setter の `value.Length` で NullReferenceException → xy 分岐の `catch { return; }` (L3366) で**無言で読み込み中止**になるとコード上は読める（レジストリに XY の有効値が保存される経路も無い）。実機確認推奨。
7. **CSV でダイアログが2回出る**: ext=="csv" はまず RAS/CSV/NXS ブロックでダイアログ (L3001) を出し、`ReadCSVFile` が多プロファイル CSV でないと空を返す → 汎用ブロック (L3396–3417) で再度ダイアログ（OTHERS 設定）が出る。
8. **XBM/RPT と既定エネルギー単位の不整合**: xbm/rpt は X を eV（×1000）で作るが、既定 FileProperty の EnergyUnit は KeV（L1149/1156）。ユーザーが eV に変えない限り軸が 1000 倍ずれる恐れ（npd は eV を強制 L3238）。また コメントアウトされた「keV なら eV に変換」処理 (L3429–3436) が残っている。
9. **NXS プロファイル名**: `Name = $"{…} - {data}"` (L3022) は `int[,]` を文字列化するため "System.Int32[,]" になる（データセット名やインデックスの意図か）。
10. **GSAS 確認フォーム（未使用）のエラー判定が逆**: `FormExportGSAS.setGsasFileContents` は `Err[i].IsNaN && Err[i].Y != 0` で validErr=true としており論理が逆。FormMain 側実装は正しい（NaN があれば無効）。現状フォーム未使用。
11. **中性子エネルギー換算の単位**: `WaveLengthToNeutronEnergy(λ[nm])` = 6.62606896²/1.674927351/λ²/2/1.602176565×1e5 (UniversalConstants.cs L203) は λ=1 nm で 8.18×10⁵ を返す。doc コメントは eV だが、物理値 0.818 meV = 8.18×10⁵ **neV** に相当し、eV としては 10⁹ 倍。横軸 EnergyNeutron 使用時に影響（`DToNeutronEnergy`/`NeutronEnergyToD`）。`EnergyToNeutronWaveLength` の doc は「keV」とあり、コメント同士も不一致。
12. **定数の CODATA 年版混在**: X 線 E–λ 換算で h=6.62606896（CODATA 2006）と e=1.60217733（CODATA 1986）を混用 (UniversalConstants.cs L199, L211)。hc = 1239.8412 eV·nm（現行推奨値 1239.84198）で差は 6×10⁻⁷ 相対。実害は小。
13. **README-PORTABLE.txt の記述**: 「self-contained for Windows x64」とあるが、同ファイルが arm64 ZIP にもコピーされる (build-arm64-portable.yml L156)。検証例 `PDIndexer-*-win-x64-portable.zip` は実アセット名 `PDIndexer-v.<ver>.zip` と不一致、`SHA256SUMS.txt` は release.yml で生成されていない（.github 内に SHA256 の記述なし）。
14. CPS ツールチップ `Count per Step (CPS)`: 「CPS = counts / step width」（FormMain.resx）だが、実装は `y /= ExposureTime`（Profile.cs L1158 `convertSrcToDest`）。マニュアル第2章の「露出時間…CPS 換算に使われ」はコードと一致。ツールチップ側の誤り疑い。
15. 一括読み込みの Invoke 分岐 `readProfile(fileName, showFormDataConverter, isChecked, isDrawn)` (L2935) は `changePos` を渡していない（既定 true になる）。軽微。
16. `.chi` 読み込みは「空白区切りでちょうど4トークンの行」のみ受理し、それ以外の行で break (L3094–3110)。2列の .chi だと 0 点になり無言で終了する。マニュアル記述（4列の 2・4 列目）とは一致しているが、想定 Fit2D 形式の妥当性は要確認（§4）。

---

## 4. 要確認事項

1. `.chi` の想定形式（4 列で 2・4 列目を採用）が実際の Fit2D 出力と合っているか（一般的な Fit2D .chi は 2 列のはずだが、ここは一般知識なので作者確認が必要）。
2. `csv` を「WinPIP の出力」とする説明を残すか。コード上の専用パーサは PDIndexer 自身の結合 CSV（`X,Y,` ヘッダ）であり、WinPIP csv は汎用テキストとして読まれていると思われる。WinPIP の csv 形式との対応は作者確認。
3. xbm/rpt の EGC 係数の単位（keV/ch 前提で ×1000）と、UI ラベル「E: energy in eV」のどちらに合わせてマニュアルを書くか。
4. §3-6（pyFAI xy が初期状態で読めない）は実機での再現確認が望ましい。
5. GSAS エクスポートの確認画面 (FormExportGSAS) を復活させる予定があるか。無ければマニュアルのスクショと説明を削除すべき。
6. `0-overview.md` は 6.0 → 10.0 に修正で良いか（csproj/CI/MSI スモークとも 10）。
7. `SupportedOSPlatformVersion` が 7.0 (csproj L20) だが、推奨環境「Windows 10 以降」との関係（.NET 10 自体の対応 OS）はマニュアル上どう書くか。
8. Watch File を `.pdi2` にも対応させる意図があるか（現状 `EndsWith("pdi")`）。マニュアルは現状「pdi のみ」と明記した方が安全。

---

## 5. 補足: 下書き用素材

### 5.1 対応拡張子と判定（`readProfile`, FormMain.cs L2940–3417）

| 判定 | 処理 | ダイアログ | 取得するメタデータ |
|---|---|---|---|
| `pdi` / `pdi2` | XML デシリアライズ (`ReadPdi2File`) | なし | 全プロパティ（SrcProperty, 露出時間等） |
| `ras` | `*RAS_INT_START/END` 間 2列 | あり (RAS) | なし |
| `csv` | 多プロファイル CSV（2行目 `X,Y,`）→ 失敗時汎用 | あり（失敗時は2回） | プロファイル名（1行目） |
| `nxs` | HDF5 `/histogram` データセット | あり (NXS)＋検出器ごと EGC | 検出器数 |
| `chi` | 5行目以降、4トークン行の [1],[3] | あり (CHI) | なし |
| `xbm` | バイナリ | あり＋EDX | 取り出し角, Live time, EGC(3), コメント多数 |
| `rpt` | テキスト（末尾にパラメータ） | あり＋EDX | 取り出し角, 露出時間, EGC(a0,a1) |
| `npd` | テキスト（`EGC0/1/2`,`2Theta`,`Live time`,`Data length`） | あり | 取り出し角, Live time, EGC（表示のみ） |
| 1行目 `**  MPLOT FILE **` | TOF 3列 | あり（TOF 自動設定） | 誤差, コメント |
| `xy` かつ1行目 `# == pyFAI calibration ==` | 24行目以降 2列 | あり | 波長（16行目, m→nm） |
| `gsa` | `BANK` 以降 3列 | あり (GSA, 既定センチ度) | 誤差 |
| その他（tsv, 非 pyFAI xy 等） | `ConvertUnknownFileToProfileData` | あり (OTHERS) | なし |

汎用テキスト解析アルゴリズム (PdiFile.cs L287–381): ①区切り文字で全行分割し有限数値のみ抽出 ②「数値2個以上・同じ個数」の行が**10行以上**連続する最長ブロックを採用 ③各列で「差分 > 0.00001 で一定（許容 |Δ| < 10）」が10点以上続く列を X 列とする ④Y 列 = X 列の右隣（無ければ左隣）。

### 5.2 横軸変換（`HorizontalAxisConverter`, Crystallography/Profile.cs L1422〜）

内部基準は **d [nm]**。`Convert(x, src, dst)` は同一軸・同一条件なら単位換算のみ、それ以外は `ConvertToD` → `ConvertFromD`。

- 2θ → d: `d = λ / (2 sin(θ))`、θ = 2θ/2。単位: 度 `2θ/180·π`、センチ度 `2θ/100/180·π`、ミリラジアン `2θ/1000`（`TwoThetaIn*ToD`）。逆: `2θ = 2 asin(λ / 2d)`（×180/π, ×100, ×1000）。λ は nm (`HorizontalAxisProperty.WaveLength` doc「nm単位」)。
- 同一2θ軸の単位換算: 度→センチ度 ×100、度→rad ×π/180、度→mrad ×π/180×1000 等 (L1433–1458)。**同一軸ショートカットは波長が等しいときのみ**。
- d: Å→nm ×0.1、nm→Å ×10。Å/nm 以外の単位では空配列を返す。
- q（波数, `WaveNumber`）: `q = 2π/d`（`DToWaveNumber`）。nm⁻¹ が基準、Å⁻¹ は `/10`（d→q）・`×10`（q→d 入力時）。
- エネルギー（X線, `XrayEnergyToD`）: `d = λ(E) / (2 sin(Θ_takeoff/2))`、`λ[nm] = 1239.8412 / E[eV]`（`EnergyToXrayWaveLength` = 6.62606896/1.60217733×2.99792458/E×100）。すなわち **E[keV]·d[Å] = 12.398412 / (2 sin(2θ_takeoff/2))** 相当。入力単位 keV は ×1000、MeV は ×10⁶ して eV に。`EnergyTakeoffAngle` は rad（既定 5°）。
- エネルギー（電子線）: `ElectronEnergyToD` → `EnergyToElectronWaveLength(E/1000 [keV])` = 1.22642628621 / sqrt(V·(1 + 0.97847537×10⁻³·V_kV)) with V = kV×1000（相対論補正）。
- エネルギー（中性子）: `EnergyToNeutronWaveLength` (§3-11 の単位疑義あり)。
- 中性子 TOF → d: `d = λ / (2 sin(2θ_TOF/2))`、`λ[nm] = h/m_n / v × 10³`、`v[m/μs] = L[m] / TOF[μs]`（`NeutronTofToD`, `NeutronVelocityToWavelength`）。h = 6.62606896×10⁻³⁴, m_n = 1.674927351×10⁻²⁷ → `λ[nm] = 3.9560336×10⁻⁴ · TOF[μs] / L[m]`。ns 入力は /1000（§3-3 の二重変換疑義）。逆 `DToTOF = L / v(2 d sin(θ))`。TOF 角 `TofAngle` は rad（UI は ° 表示）、距離 `TofLength` は **m**（UI FooterText `m`; ただし `FormDataConverter.TofLength` の doc コメントは「mm単位」と誤記）。

### 5.3 EDX チャンネル→エネルギー（実装どおり）

| 形式 | 式 | n の起点 | 出力単位 |
|---|---|---|---|
| xbm | `(a0 + a1 n + a2 n²) × 1000` | 1 | eV（係数 keV 前提） |
| rpt | `(a0 + a1 n) × 1000` | 1（全データ行を通し番号） | eV |
| nxs | `a0 + a1 n + a2 n²` | 0 | 係数の単位のまま |
| npd | ファイルの第2列 × 1000（EGC 不使用） | — | eV |

### 5.4 ランタイム・配布（確認済み事実）

- TargetFramework `net10.0-windows`、RuntimeIdentifiers `win-x64;win-arm64`（PDIndexer.csproj L5, L15）。
- MSI: WiX v7 (`WixToolset.Sdk/7.0.0`)、framework-dependent（release.yml L130 `--self-contained false`）、per-user、出力 `PDIndexer-setup.msi` / `PDIndexer-setup_arm64.msi`（wixproj OutputName）＋旧名 `PDIndexerSetup.msi`。
- portable ZIP: self-contained（release.yml L175–176, build-arm64-portable.yml L108–110）、`PDIndexer-v.<ver>.zip` / `PDIndexer-v.<ver>_arm64.zip`、LICENSE.md と README-PORTABLE.txt を同梱、glfw3*.dll 除外。README-PORTABLE.txt があると更新メニュー非表示。
- 設定保存先: `HKCU\Software\Crystallography\PDIndexer`（FormMain.cs L718, L1042）。Clear Registry は終了時 (`FormMain_FormClosed` L1019) に `DeleteSubKey` で丸ごと削除し、書き込みをスキップ — troubleshooting の手順と一致。
