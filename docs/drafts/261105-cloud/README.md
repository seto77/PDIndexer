<!-- 261105Cl: docs/drafts/261105-cloud の目次。 -->
# PDIndexer マニュアル整備の下書き（2026-11-05）

> 本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

既存マニュアル（`docs/src/<lang>/`, MkDocs）は 9 章＋付録で整っているため、章立てを作り直さず、(1) 既存マニュアルと現行コードの突き合わせ、(2) 不足している「全フォーム一覧」と「計算手法（実装準拠）」の下書き、の 2 点を用意しました。

このフォルダは `docs/mkdocs.yml` の `docs_dir: src` の外にあるので、サイトのビルドと公開には影響しません。査読後、必要な部分を `docs/src/ja/` と `docs/src/en/` に移し、`mkdocs.yml` の `nav` に追加してください（例: `methods.md` を `appendix/algorithms.md` の改訂として統合）。

## 内容

| ファイル | 言語 | 内容 |
| --- | --- | --- |
| [audit/README.md](audit/README.md) | ja | **突き合わせの総括**（食い違い・未記載機能・実装上の疑問点・要確認事項の代表例と件数） |
| [audit/ch1-main-window.md](audit/ch1-main-window.md) ほか 6 ファイル | ja | 章ごとの詳細（マニュアル箇所・コード箇所・深刻度つきの表、下書き用素材） |
| [ja/forms.md](ja/forms.md) / [en/forms.md](en/forms.md) | ja / en | 全ウィンドウの一覧（タイトル・開き方・機能・対応章） |
| [ja/methods.md](ja/methods.md) / [en/methods.md](en/methods.md) | ja / en | 計算手法: 横軸換算、プロファイル処理、プロファイル関数、Marquardt 法、格子定数の最小二乗精密化 |

監査（`audit/`）は著者向けの作業資料なので日本語のみです。`forms.md` と `methods.md` は同名ファイルで日英の内容を対応させています。

## 約束事

- UI ラベルは `<Form>.resx`（英語）・`<Form>.ja.resx`（日本語）の実際の文字列を使用。
- 機能・既定値・式には実装箇所（ファイル名とメソッド名）を併記。
- 数式は GitHub Markdown の `$...$` / `$$...$$`。
- スクリーンショットは撮っていない（Linux 環境）。必要箇所は `<!-- screenshot: ... -->` で示した。
- コードは一切変更していない。疑わしい実装は「実装上の疑問点」に根拠つきで記載。
