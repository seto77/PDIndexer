# PDIndexer GitHub Pages 編集方針

> 260601Ch: 4 アプリ共通の Pages 原則は `github pages編集方針(共通).md` に分離。この文書は PDIndexer 固有の公開 URL、旧 doc 資産、初期移行状況、残課題を扱う。

作成日: 2026-05-31

PDIndexer のマニュアルは、ReciPro の `ReciPro_Pages編集方針.md` を参考に、**MkDocs Material + MathJax** による GitHub Pages へ移行する。本文は本体リポジトリ内の `docs/` 配下で管理する。

- 公開先: <https://seto77.github.io/PDIndexer/> (英語) / <https://seto77.github.io/PDIndexer/ja/> (日本語)
- 本体リポジトリ: `C:\Users\seto\source\repos\PDIndexer`
- 旧マニュアル資産: `PDIndexer/doc/` 配下の HTML / PDF / DOCX
- 初期構築: 2026-05-31 に `docs/src/`、MkDocs 設定、初期 Markdown、Pages workflow を作成。

この文書は、PDIndexer の **Pages 編集方針・正本の所在・ディレクトリ構成・画像運用・ナビゲーション/言語切替・ビルドと公開フロー** をまとめる。

---

## 0. 基本方針: Pages を新しい正本にする

- **今後のマニュアル本文の編集対象は `docs/src/` 配下の Markdown とする。**
- 旧 `PDIndexer/doc/` は、移行元・参照元として残す。新規の本文編集は旧 Word/HTML/PDF ではなく `docs/src/` に行う。
- 2026-05-31 時点では、Pages は初期構成のみ。旧マニュアル本文とスクリーンショットの完全移行は後続作業とする。
- アプリ内 Help メニューや README からのリンク切替は、Pages の本文と公開フローが安定してから行う。

---

## 1. ディレクトリ構成

```text
PDIndexer/
  docs/
    mkdocs.yml              # 260531Ch: MkDocs Material 設定
    requirements.txt        # Pages ビルド用 Python 依存
    includes/
      abbreviations.md      # 略語ツールチップ定義
    tools/                  # 移行・検証スクリプト置き場
    src/                    # ★本文の正本★
      index.md              # 英語トップ
      en/*.md               # 英語ページ
      en/appendix/*.md      # 英語付録
      ja/index.md           # 日本語トップ
      ja/*.md               # 日本語ページ
      ja/appendix/*.md      # 日本語付録
      assets/
        cap-en-auto/        # 英語・自動キャプチャ
        cap-ja-auto/        # 日本語・自動キャプチャ
        cap-en-manual/      # 英語・手動キャプチャ
        cap-ja-manual/      # 日本語・手動キャプチャ
        references/         # 本文で参照する図版
        javascripts/
          language_switch.js
          mathjax.js
        stylesheets/
          extra.css
    site/                   # ビルド出力。git 管理外
```

- 1 ページ = `docs/src/{en|ja}/<slug>.md`。
- EN/JA は同じ番号・同じ slug にする。言語切替 JS が現在ページの相手言語版へ移動するため。
- セクションが大きくなり下位ページを持つ場合は、ReciPro と同様に `docs/src/<lang>/<slug>/index.md` を概要ページにして、下位ページを同フォルダへ置く。

---

## 2. 本文編集ルール

- **編集対象は `docs/src/` の Markdown。**
- ページ冒頭は H1 から始める。
- ページ内の前/次/Home ナビ行は書かない。Material の `navigation.footer` が本文下部に前/次リンクを自動表示する。
- 言語切替リンクは本文に書かない。ヘッダー右上の言語セレクタを使う。
- ページ間リンクと画像参照は相対パスで書く。
- 数式は MathJax (`\( ... \)` / `$$ ... $$`) を使う。
- 表、admonition、コードブロック、タブなどは `docs/mkdocs.yml` の Markdown 拡張を使う。

### EN/JA の同期

- 人間が主に日本語ページを確認する想定なので、手書きコンテンツのリード言語は日本語とする。
- 日本語を更新したら、英語にも内容を反映する。
- 英語が先行しているページは、英語から日本語への逆反映を提案する。
- 両言語が同時に手編集されて内容が食い違う場合は、ページ単位でどちらを真実にするか確認する。

### GUI 表記の優先

PDIndexer は GUI 操作マニュアルなので、UI 要素名は実際の GUI 表示に合わせる。

- 英語本文では既定 `*.resx` のラベルを優先する。
- 日本語本文では `*.ja.resx` のラベルを優先する。
- 旧マニュアルの表記と現行 GUI がずれている場合は、現行 GUI を正として本文を直す。
- 内容を翻訳するときも、UI 要素名は翻訳文から推測せず、対象言語の resx ラベルを使う。

---

## 3. 画像とスクリーンショット

### 置き場

- 自動キャプチャ: `docs/src/assets/cap-en-auto` / `docs/src/assets/cap-ja-auto`
- 手動キャプチャ: `docs/src/assets/cap-en-manual` / `docs/src/assets/cap-ja-manual`
- 参照図版: `docs/src/assets/references`

本文からは相対パスで参照する。

```markdown
![Main window](../assets/cap-en-manual/FormMain.png)
```

### manual 優先

自動キャプチャの品質が悪いフォームや、説明上トリミング・注釈が必要な画像は、手動画像を `cap-*-manual` に置き、本文から明示的に参照する。

### 自動キャプチャ機構（260601Cl 実装）

ReciPro と同じ思想・同じ呼び出し方の GUI 一括キャプチャを PDIndexer に実装した。

- `PDIndexer/GuiCapture.cs`: 全フォームを画面内 (0,0) に最前面表示し `CopyFromScreen` で撮る開発者ツール（PDIndexer は OpenGL 不使用のため GL 描画待ちは除去）。`FormMain` ＋ `FormMain` が配線して保持する子ウィンドウ（Crystal/Profile/EOS/Fitting/Sequential など＋ `FormMacro`）＋ parameterless な単独フォームを撮る。
- `PDIndexer/Program.cs`: `--capture [出力ディレクトリ] [en|ja]` または `--capture [en|ja]`（出力先省略時は `docs/src/assets/cap-{en|ja}-auto`）。通常起動には影響しない。
- `PDIndexer/GuiCaptureTargets.cs`: Designer (.Designer.cs) を改変せず partial クラスのフィールド `CaptureExtender` ＋ `SetCapture` でコントロール単位クロップ対象を指定（`FormProfileSetting` の処理ステップ、`FormEOS` の物質、`FormFitting` の各 groupBox、`FormSequentialAnalysis` の各出力タブ）。`Crystallography.Controls` 側の共有コントロール（crystalControl 等）は既存タグでクロップされる。
- `FormMain.PrepareCaptureRepresentativeState()` / `EnumerateCaptureDependentForms()`: 代表結晶（Au/MgO/Si）をチェックして回折線を描いた代表状態にし、配線済み子フォームを GuiCapture へ渡す。
- 出力: 粒度は ReciPro と同程度（フォーム全体 + groupBox/panel/tabPage 単位クロップ + メニュー展開クロップ）。命名は ReciPro と同じ `form.Name` 起点のドット連結。

実行（リポルートで）:

```powershell
dotnet build PDIndexer\PDIndexer.csproj -c Debug -p:Platform=x64
.\PDIndexer\bin\Debug\PDIndexer.exe --capture ja   # → docs\src\assets\cap-ja-auto
.\PDIndexer\bin\Debug\PDIndexer.exe --capture en   # → docs\src\assets\cap-en-auto
```

2026-06-01 時点で両言語とも 49 枚を生成済み（cap-ja-auto は日本語 GUI、cap-en-auto は英語 GUI）。本文は `../assets/cap-{ja,en}-auto/<stem>.png`（付録は `../../assets/...`）で参照する。

!!! warning "撮影は前面・フォーカスのある実画面で"
    `CopyFromScreen` は物理画面を読むため、`--capture` は画面を前面・表示のまま実行すること（Run 冒頭の CAUTION 参照）。ヘッドレス/非フォアグラウンドのセッションでは、特に `FormMain` のメニュー＋左端ツールバーが描画されずグレーになる（他フォームは問題なし）。きれいな `FormMain.png` を得るには、ユーザーの実デスクトップを前面にしたまま `--capture` を流して撮り直す。

---

## 4. リンクと画像参照

- すべて MkDocs 解決可能な相対パスにする。
- `mkdocs build --strict` がリンク切れ・画像参照切れを検出する。
- 旧 Word HTML のフレームやアンカー、Wiki 記法は使わない。
- ページをリネーム/移動し、すでに公開済み URL が変わる場合は、`docs/mkdocs.yml` の `redirects.redirect_maps` に旧パスから新パスへの対応を追記する。
- フラットページを同じ slug の `index.md` に変える場合は、`foo.md` → `foo/index.md` の redirect を張らない。`use_directory_urls: true` では同一 URL になり、自己リダイレクトを起こすため。

---

## 5. 言語切替とナビゲーション

- `docs/mkdocs.yml` の `extra.alternate` で English / 日本語を定義する。
- `docs/src/assets/javascripts/language_switch.js` が、ヘッダーの言語セレクタを現在ページの相手言語版へ向け直す。
- EN と JA の slug は一致させる。例:

```text
docs/src/en/1-main-window.md
docs/src/ja/1-main-window.md
```

- 左ナビの番号とファイル名先頭番号を一致させる。
- 下位ページを持つセクションは、ReciPro と同様に `navigation.indexes` 用の `index.md` を使う。

---

## 6. ビルド・ローカル確認・公開

### ローカルビルド

依存を一時ディレクトリに入れて検証する例:

```powershell
python -m pip install -r docs\requirements.txt --target C:\tmp\pdindexer-mkdocs-pkgs
$env:PYTHONPATH='C:\tmp\pdindexer-mkdocs-pkgs'
python -m mkdocs build -f docs\mkdocs.yml --strict
```

ローカル確認:

```powershell
python -m mkdocs serve -f docs\mkdocs.yml -a 127.0.0.1:8020
```

URL:

```text
http://127.0.0.1:8020/PDIndexer/
http://127.0.0.1:8020/PDIndexer/ja/
```

### 公開

- ワークフロー: `.github/workflows/pages.yml`
- `master` への push で `docs/**` または workflow 自身が変わったときに発火する。
- 処理: `python -m pip install -r docs/requirements.txt` → `mkdocs build -f docs/mkdocs.yml --strict` → `docs/site` を Pages artifact としてデプロイ。
- repository settings の Pages source は GitHub Actions にする。

---

## 7. 進捗と後続 TODO

### 完了（260601Cl）

- 旧 `PDIndexer/doc/*` の HTML/DOCX と現行 Web 版マニュアル（<https://yseto.net/soft/pdi/>）から、全ページ（0〜8 ＋付録3 ＋ index）を EN/JA で本文移行。`mkdocs build --strict` がクリーンに通る。
- PDIndexer 用の自動キャプチャ機構を実装し、保存先を `docs/src/assets/cap-{en|ja}-auto` に合わせた（§3 参照）。両言語 49 枚を生成。
- Macro API ページ（`8-macro`）を `PDIndexer/Macro.cs` の `Help` 属性から生成。
- UI 要素名は `*.resx`（EN）/`*.ja.resx`（JA）の実ラベルに合わせた。

### 後続 TODO

- `FormMain.png` をユーザーの実デスクトップ前面で撮り直し、メニュー＋ツールバーまで完全描画した版に差し替える（§3 の warning 参照）。
- 旧 `PDIndexer/doc/*`（PDF/DOCX/HTML）は移行元として残置。本文の正本は `docs/src/`。
- Help メニューと README のリンクを Pages へ切り替える（Pages の公開フローが安定してから）。
- `Cell Finder` / `Atomic Position Finder` / `LPO`（応力）など、現状は関連ページ内で簡単に触れているツールに、必要なら独立ページを追加する。
- `dotnet build` ＋ `--capture en/ja` ＋ `mkdocs build --strict` を組み合わせた検証・更新手順を `/pages` 相当の自動フローにまとめる。
- cap-*-auto の PNG を公開のため git 管理に含める（個別リポ方針に従う。`.gitignore` で除外されている場合は明示追加）。
