# GitHub Pages 編集方針（共通）

- 作成: 2026-06-01 (260601Ch)
- 適用範囲: ReciPro / PDIndexer / CSManager / IPAnalyzer
- 目的: 4 アプリの GitHub Pages / MkDocs Material マニュアルを同じ思想で保守する。

> このファイルは 4 リポジトリ共通方針です。公開 URL、旧マニュアル資産、アプリ固有 TODO は各 `<App>_Pages編集方針.md` に書いてください。

---

## 1. 正本

- マニュアル本文の正本は `docs/src/` 配下の Markdown とする。
- 旧 Wiki、旧 `doc/`、Word、PDF、HTML は移行元・参照元として扱い、新規の本文編集先にはしない。
- 画像の正本は原則として `docs/src/assets/` に置く。
- `docs/site/` はビルド出力であり、手編集しない。

ReciPro のように Wiki から移行したプロジェクトでは、初期移行スクリプトを再実行すると `docs/src` の手編集や新規キャプチャを失うことがある。移行スクリプトは記録用とし、通常の編集フローでは使わない。

## 2. 標準ディレクトリ

```text
docs/
  mkdocs.yml
  requirements.txt
  includes/
    abbreviations.md
  tools/
  src/
    index.md
    en/
    ja/
    assets/
      cap-en-auto/
      cap-ja-auto/
      cap-en-manual/
      cap-ja-manual/
      references/
      javascripts/
      stylesheets/
  site/
```

- EN/JA は同じ番号・同じ slug を基本にする。
- 下位ページを持つセクションは `docs/src/<lang>/<slug>/index.md` を概要ページにし、下位ページを同じフォルダに置く。
- 単独ページは `docs/src/<lang>/<slug>.md` でよい。

## 3. 本文編集

- ページ冒頭は H1 から始める。概要ページで frontmatter が必要な場合は、frontmatter の後に H1 を置く。
- 前/次/Home の手書きナビ行は本文に置かない。Material の `navigation.footer` を使う。
- 言語切替リンクは本文に置かない。ヘッダーの言語セレクタを使う。
- ページ間リンクと画像参照は MkDocs が解決できる相対パスで書く。
- Wiki 記法、raw.githubusercontent.com 直リンク、旧 HTML のフレーム依存リンクは使わない。
- 数式は MathJax (`\( ... \)` / `$$ ... $$`) を使う。
- UI 要素名は GUI の `*.resx` / `*.ja.resx` を正とする。詳細は `ローカライズ・用語方針(共通).md` を参照。

## 4. EN/JA 同期

- 手書きコンテンツのリード言語は原則として日本語とする。
- 日本語を編集したら英語にも内容を反映する。
- 英語だけが先行している場合は、日本語への反映を提案する。
- 両言語が同時に手編集されて内容が食い違う場合は、ページ単位でどちらを正にするか確認する。
- UI 要素名は翻訳で推測せず、対象言語の resx ラベルを使う。

## 5. 画像とスクリーンショット

- 自動キャプチャ: `docs/src/assets/cap-en-auto` / `docs/src/assets/cap-ja-auto`
- 手動キャプチャ: `docs/src/assets/cap-en-manual` / `docs/src/assets/cap-ja-manual`
- 参照図版: `docs/src/assets/references`
- 自動キャプチャが読みにくい場合は manual 側に同名または説明的な PNG を置き、本文の参照先を manual 側へ明示的に切り替える。
- `CopyFromScreen` 系のキャプチャは物理画面・RDP 状態・最小化に影響される。前面表示、DPI、言語、テーマを確認して撮り直す。
- 公開に必要な画像がローカル ignore に引っかかる場合は、個別リポの方針に従って明示的に git 管理する。

## 6. 言語切替とナビゲーション

- `docs/mkdocs.yml` の `extra.alternate` で English / 日本語を定義する。
- `language_switch.js` を使う場合は、現在ページの slug から相手言語ページへ移動できるよう EN/JA の slug を合わせる。
- 左ナビの番号とファイル名先頭番号は一致させる。
- `navigation.indexes` を使うセクション概要は `index.md` にする。MkDocs は `index.md` 以外を section index と認識しない。
- ページを移動・リネームして公開済み URL が変わる場合は、`mkdocs-redirects` の `redirect_maps` を追加する。
- `foo.md` を `foo/index.md` にするだけのフォルダ化では redirect を張らない。`use_directory_urls: true` では同一 URL になり、自己リダイレクトを起こす。

## 7. ビルドと公開

ローカル検証の基本形:

```powershell
python -m pip install -r docs\requirements.txt --target docs\.mkdocs-pkgs
$env:PYTHONPATH = (Resolve-Path docs\.mkdocs-pkgs)
python -m mkdocs build -f docs\mkdocs.yml --strict
```

- `mkdocs build --strict` を通す。リンク切れ、画像参照切れ、nav の参照漏れを CI と同じ基準で検出する。
- `docs/.mkdocs-pkgs` や仮想環境、`docs/site/` は通常 git 管理しない。
- 公開は `.github/workflows/pages.yml` が担当する。`docs/**` または workflow 自身の push で GitHub Actions が走る構成を基本にする。

## 8. 共通テンプレートと個別差分

MkDocs の思想や罠は共通化するが、次の実ファイルはアプリ事情により差が出てよい。

- `docs/mkdocs.yml`
- `.github/workflows/pages.yml`
- `language_switch.js`
- `extra.css`
- `docs/src` のページ構成

共通化したい変更を見つけた場合は、先にこのファイルへ判断基準を追記し、その後に必要なリポジトリだけ実ファイルへ反映する。

