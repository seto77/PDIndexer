<!-- 261105Cl: docs/drafts/261105-cloud — 監査結果の総括。docs/src には未統合。 -->
# 既存マニュアルと現行コードの突き合わせ（総括）

> 本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

対象は `docs/src/ja/*.md` と `docs/src/en/*.md`（master `d743fd1`）、コードは PDIndexer 本体とサブモジュール `Crystallography` (`c28490a`)・`Crystallography.Controls` (`63eeae3`)。ja と en は全章で構成・内容が対応しており、以下の食い違いは特記なき限り両言語に共通です。各章ファイルの表には、マニュアル箇所・コード箇所（ファイル名・メソッド・行）・深刻度が付いています。

| ファイル | 対象章 | 食い違い | うち「高」 | 未記載機能 | 実装上の疑問点 | 要確認 |
| --- | --- | ---: | ---: | ---: | ---: | ---: |
| [ch1-main-window.md](ch1-main-window.md) | 1 章、全フォーム一覧、Version.cs 履歴 | 25 | 5 | 23 | 15 | 8 |
| [ch2-profiles-fileformats.md](ch2-profiles-fileformats.md) | 2 章、付録（ファイル形式・動作環境・トラブルシューティング） | 22 | 3 | 13 | 17 | 9 |
| [ch3-crystal.md](ch3-crystal.md) | 3 章 | 18 | 2 | 17 | 14 | 9 |
| [ch4-profile-parameter.md](ch4-profile-parameter.md) | 4 章 | 25 | 5 | 17 | 18 | 7 |
| [ch5-eos.md](ch5-eos.md) | 5 章 | 18 | 6 | 15 | 12 | 9 |
| [ch6-8-fitting-seq-macro.md](ch6-8-fitting-seq-macro.md) | 6・7・8 章 | 31 | 2 | 25 | 15 | 9 |
| [../ja/methods.md](../ja/methods.md) §6–8 | 付録「アルゴリズム解説」 | 8 | — | — | 9 | 9 |
| 計 | | 約 147 | 23+ | 約 110 | 約 100 | 約 60 |

件数は表の行数から機械的に数えた概数です（章をまたいで同じ事柄を挙げているものがあります）。

## 1. 優先度の高い食い違い（代表例）

| 章 | 内容 | 根拠 |
| --- | --- | --- |
| 0 / 付録 | 0-overview が「.NET Desktop Runtime 6.0 以上」のまま（index と付録は 10.0） | `PDIndexer.csproj` `net10.0-windows` |
| 1 / 付録 | Language メニューが「English / Japanese (need restart)」の 2 言語・手動再起動と記述。実際は 11 言語を自言語名で生成し、確認後に自動再起動 | `FormMain.PopulateLanguageMenu`, `languageToolStripMenuItem_Click` |
| 1 | `2θ:` `d:` `Int.:` `q:` 欄に入力して範囲を変えるとあるが、これらはマウス位置の読み取り表示 | `FormMain.Designer.cs` `labelTwoTheta` 等 |
| 1 | `すべてチェック/解除` は結晶リストではなくプロファイルリスト用 | `FormMain.Designer.cs` `checkBoxAll` |
| 2 / 付録 | GSAS 出力で確認画面が出るとあるが、`FormExportGSAS` は生成されず直接書き出す | `new FormExportGSAS` が存在しない |
| 3 | 予約行は「1〜6 行目が EOS 用」ではなく `Reserved` フラグ（既定 11 行: Flexible Crystal と Au〜Pb） | `default.xml`, `Crystal.Reserved` |
| 3 | 結晶リストの共有先は「Profile チェックリスト」ではなく結晶リスト（`DataTableCrystal`） | `FormMain.cs` l.892-895 |
| 4 | 処理順序は「番号順（…背景 6 → 正規化 7）」ではなく **正規化 → 背景** | `DiffractionProfile2.SetBackGroundProfile` |
| 4 | `Point No.` は ±点数ではなく窓の総点数。既定（3 点・3 次）では次数が 2 に下がり平滑化が実質無効 | `Smoothing.SavitzkyGolay` |
| 4 | `Save/Read Masking Ranges` はハンドラ本体がコメントアウトされ何もしない | `FormProfileSetting` |
| 4 | 軸設定タブは `Change` ボタンを押すまで反映されず、線源・元素・線は更新されない（Kα2 除去の設定手順が成立しない） | `FormProfileSetting` |
| 5 | 出典リストの誤り: Au に Pt の出典（Matsui 09 / Holmes 89）、NaCl-B1 に B2 の Sakai+、Al2O3 に Sata 02、Ar に Dubrovinsky 98。NaCl-B1 の Skelton 84 が抜けている | `FormEOS.resx` ラベル、`EOS.cs` |
| 5 | hBN は選択できない（`checkBoxHBN` はフォームに追加されていない） | `FormEOS.Designer.cs` |
| 5 | 「Sakai+(11) Vinet/BM は Mie–Grüneisen」とあるが等温式。T0 欄を使うのは Pt (Matsui) と Pb のみ | `EOS.cs` `NaClB2_SakaiBM` 等 |
| 6 | 図の取り違え 4 件（`groupBox1` = 格子定数パネルを結晶リストとして掲載、など） | `FormFitting.resx` `groupBoxN.Text` |
| 6 | `in each crystal` / `between crystals` の選択はコードから参照されず効果がない | `FormFitting.Fitting()` |
| 7 / 8 | 連続分析は「チェックされたプロファイル」ではなく全プロファイルを処理（マクロの `[Help]` も同じ誤り） | `FormSequentialAnalysis`, `Macro.cs` |
| 付録 | 全関数が積分 1 に規格化とあるが、面積規格化は Pseudo-Voigt のみ。格子精密化の重みは $1/\sin^2 2\theta$ ではなく $1/\sin^2\theta$ | `PeakFunction`, `FormFitting.Fitting()` |

## 2. マニュアル未記載の主な機能（Version.cs 履歴から）

- ver4.465 化学組成ウィンドウ（酸化物 / ハロゲン化物 / 硫化物換算）、原子量 CIAAW 2024
- ver4.457 横軸単位 centi-degree / milli-radian（1 章の横軸タブ自体が旧構成で、中性子・TOF・単色/白色・単位選択の記述がない）
- ver4.440 初回起動時のレジストリ初期化
- ver4.408 CIF の D（重水素）対応
- ver4.462 ZIP 版では更新チェックのメニューが非表示
- 中性子 TOF の MPLOT 形式、形式ごとの Data Converter 設定のレジストリ保存、MSI のユーザー単位インストール
- 結晶データベースで COD も選べること、EOS タブの `3rd Vinet`
- Cell Finder / Atomic Position Finder / LPO に専用章がない（後二者はツールバーボタンが非表示）

## 3. 実装上の疑問点（代表例・コード未修正）

`PDIndexer` 本体:

- **体積誤差 `V_err` の式が全晶系で次元不一致**（係数が 2 乗されていない）。立方晶 NaCl で 1 次伝播の約 1/9.8。`FormFitting.FittingDiffraction()`（methods I-4、6 章監査でも独立に指摘）
- 単斜晶の $\sigma_b,\sigma_c$ の演算子優先順位（`1 / Math.Sin(alfa) * Math.Sin(alfa)`）（I-7）
- 菱面体設定の三方晶を六方晶の式で精密化（I-5）
- 角度単位 c° / mrad で格子精密化の重みが壊れる（I-6）
- Simple モードの探索窓に `SerchRangeFactor` が掛からない（I-8）
- `Send d-values` が観測 d ではなく計算 d を送る（6 章監査）
- 連続分析で方位角を解釈できないと早期 return し、メイン画面が無効のまま残る（`FormSequentialAnalysis.cs` l.189）
- XBM / RPT / NPD の既定取り出し角 `5 / 180 * Math.PI` が整数除算で 0（1・2 章監査）
- pdi / pdi2 を読み込むとファイルを書き換える（`Replace("pt","Pt")` を全行に適用）（2 章監査）
- ns 単位の TOF が 1/1000 を 2 回受けている疑い（2 章監査）
- `as Bitmap` コピーにハンドラが接続されていない（1 章監査）

`Crystallography`（共通ライブラリ）:

- Pseudo-Voigt の $\partial f/\partial H_k$ ガウス項が π 倍（I-1、収束点への影響は小さいことを模擬データで確認）
- Split Pearson VII の `GetIntegral()` が $e^{A}$ でなく $A$（I-2）
- `X Err` が標準誤差でない（I-3）
- `EOS.GetPressure` の温度依存分岐に Vinet3 の case がなく 0 を返す（5 章監査）
- `getBgPointsAuto` の配列下限外読み出し、マスク補間の無限ループの可能性、バンドパスで逆 FFT 後に絶対値を取る（4 章監査）

`Crystallography.Controls`:

- 結晶 DB の格子定数検索で、入力（Å・°）を nm・rad の値と比較している（d 値は ÷10 しているが格子定数は無変換）。`SearchCrystalControl.cs` `backgroundWorkerSearch_DoWork`（3 章監査、本総括の作成時に再確認）
- 非中心対称の点群で Friedel 対が別の線として出て高さが半分になる（3 章監査）

## 4. 要確認事項（代表例）

- 格子精密化の重みの意図（$1/\sin^2\theta$ と $1/\sin^2 2\theta$）（methods T-1）
- Kα2 除去・2θ オフセットが 2θ [度] 以外の軸で有効化されたときの扱い（methods T-8、4 章監査）
- 異方性温度因子の係数の定義（非対角項に cos、B 型が無変換）（3 章監査）
- Pt (Matsui) の電子熱圧の「300 K で約 0.04 GPa」（多項式は 300 K で ≈0）（5 章監査）
- `FormExportGSAS` / `FormLimitChanger` を残すか（forms）
