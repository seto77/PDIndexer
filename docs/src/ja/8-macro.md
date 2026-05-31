<!-- 260531Ch: Initial Japanese macro page skeleton. -->
# Macro

PDIndexer には、プロファイル、結晶、フィッティング、Sequential Analysis を自動操作するためのマクロ API があります。

## 参照元

マクロの説明は `PDIndexer/Macro.cs`、特に公開メンバーに付与された `Help` 属性を参照して作成します。

## 扱う項目

- 現在の表示範囲と軸操作。
- 結晶リストの選択、チェック、格子定数アクセス。
- プロファイルリストの選択、チェック、プロファイル演算。
- フィッティングウィンドウ操作とフィッティングパラメータ。
- Sequential Analysis の実行と自動保存設定。

## 表記ルール

マクロ名と GUI 表記が違う場合、コード例ではマクロ API の綴りを保持し、操作説明では現行 GUI ラベルを使います。
