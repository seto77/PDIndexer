# project-guidance 運用方針（共通）

- 作成: 2026-06-01 (260601Ch)
- 適用範囲: ReciPro / PDIndexer / CSManager / IPAnalyzer
- 目的: 4 リポジトリで共有すべき開発知見と、各アプリ固有の監査・作業ログを分け、エージェントごとの追記で方針が乖離するのを防ぐ。

> このファイルは 4 リポジトリ共通方針です。更新した場合は、同名ファイルを ReciPro / PDIndexer / CSManager / IPAnalyzer の全 `.project-guidance` に同内容で反映してください。

---

## 1. 基本構造

`.project-guidance` は次の 2 層で運用する。

- **共通方針ファイル**: ファイル名に `(共通)` を含め、4 リポジトリで内容を一致させる。WinForms や MkDocs など、どのアプリにも当てはまる判断を置く。
- **アプリ固有ファイル**: `ReciPro_...md` / `PDIndexer_...md` / `CSManager_...md` / `IPAnalyzer_...md` のようにアプリ名を付ける。公開 URL、旧資産、フォーム別監査、未対応箇所など、そのリポジトリだけの事情を置く。

共通ファイルには「原則・落とし穴・横展開すべき知見」を書き、個別ファイルには「適用状況・例外・TODO」を書く。共通ファイルに巨大なフォーム別台帳や一時作業ログを入れない。

## 2. 共通ファイル一覧

初期セットは以下を正本とする。

- `project-guidance運用方針(共通).md`
- `github pages編集方針(共通).md`
- `ツールチップ編集方針(共通).md`
- `WinForms UI編集方針(共通).md`
- `ローカライズ・用語方針(共通).md`
- `共有ライブラリ編集方針(共通).md`

ツールチップ方針の正本は `ツールチップ編集方針(共通).md`。旧名 `WinForms_ToolTip_共通注意点.md`（互換スタブ）は 260601Cl にユーザー判断で廃止し、4 リポジトリから削除した（sync ツールの `$removedCommonFiles` が削除を伝播・検出する）。

## 3. 知見の置き場所

| 知見の種類 | 置き場所 |
|---|---|
| WinForms `ToolTip` の仕様、遅延、折返し、バルーン表示の罠 | `ツールチップ編集方針(共通).md` |
| あるフォームの tooltip 文案、配線漏れ、監査結果 | `<App>_ツールチップ監査*.md` |
| MkDocs / GitHub Pages の共通構成、EN/JA、画像、redirect の罠 | `github pages編集方針(共通).md` |
| 公開 URL、旧マニュアル資産、アプリ別 Pages TODO | `<App>_Pages編集方針.md` |
| GUI ラベル、メニュー、フォーム設計、Designer 差分の扱い | `WinForms UI編集方針(共通).md` |
| resx、EN/JA 同期、結晶学用語、単位、GUI 表記優先 | `ローカライズ・用語方針(共通).md` |
| Crystallography / Crystallography.Controls / Native の横断変更 | `共有ライブラリ編集方針(共通).md` |
| ユーザー獲得、ソフト固有の機能戦略 | 原則としてアプリ固有ファイル |
| 調査ログ、仮説、環境依存の再現手順 | まずアプリ固有。4 アプリへ効く結論だけ共通方針へ要約 |

迷った場合は、まず個別ファイルへ書き、4 アプリに効くと確定した時点で共通ファイルへ要約する。

## 4. 更新手順

共通方針を更新するときは、次の順に行う。

1. 変更が共通知見か、アプリ固有知見かを分類する。
2. 共通知見なら、任意の 1 リポジトリで `(共通).md` を更新する。
3. `.project-guidance/tools/sync-common-guidance.ps1 -Apply` で他 3 リポジトリへ同期する。
4. `.project-guidance/tools/sync-common-guidance.ps1` を実行し、共通ファイルのハッシュ一致を確認する。
5. 必要なら個別ファイルの先頭に「共通方針を参照」と短く追記する。

PowerShell 実行例:

```powershell
.\.project-guidance\tools\sync-common-guidance.ps1 -Apply
.\.project-guidance\tools\sync-common-guidance.ps1
```

## 5. エージェント向け注意

- コード変更の規約はルートの `Agents.md` / `CLAUDE.md` も参照する。Codex が追記する場合は `260601Ch` のように `YYMMDDCh` を付ける。
- 共通ファイルには、別アプリにもそのまま通用する表現を使う。特定アプリ名の詳細は必要最小限にする。
- 大きな監査表や自動抽出一覧は個別ファイルに置く。共通ファイルには判明したルールだけを要約する。
- 共有ライブラリや Pages テンプレートの実ファイルは、必ずしも完全一致させない。共通ファイルで一致させるのは「判断基準」と「避けるべき罠」。
- 既存のユーザー・別エージェント変更を巻き戻さない。共通化作業では、原則として `.project-guidance` 配下だけを触る。
- **コミットメッセージ先頭への `@` 混入を防ぐ（260601Cl・どのリポでも頻発）**: 複数行のコミットメッセージは、PowerShell の here-string `@'…'@` を**そのまま git に渡す前提で書きがち**だが、**Bash ツール（bash）で `git commit -m @'…'@` とすると `@` がメッセージの先頭（と末尾）にリテラルとして連結され、件名が `@` で始まる壊れたコミットになる**（bash は `@'…'@` を「`@` ＋ 単一引用文字列 ＋ `@`」と解釈するため）。
  - Bash ツールで書く場合: `git commit -F -` にヒアドキュメント（`<<'EOF' … EOF`）で渡すか、単純な `-m "..."` を使う。`@'…'@` は **PowerShell ツールでのみ**使う（あの記法は PowerShell の here-string 専用）。
  - 混入してしまったら、push 前に `git commit --amend -F -`（ヒアドキュメント）で件名を正す。

