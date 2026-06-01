<!-- 260601Cl: 日本語トップページ (旧 docx + yseto.net Web 版マニュアルから移行)。 -->
# PDIndexer マニュアル

**PDIndexer** は、一次元粉末回折パターン（実験室・放射光 X 線、中性子 TOF）を解析する、MIT ライセンスの無償 Windows アプリケーションです。測定プロファイルを表示し、結晶構造から計算した回折線を重ね、プロファイルの処理・補正、ピークフィッティングと最小二乗法による格子定数の精密化、標準物質の状態方程式による圧力推定を行います。

![PDIndexer メインウィンドウ](../assets/cap-ja-auto/FormMain.png)

## 目的から探す

| やりたいこと | まずここ | 次のステップ |
|------|------|------|
| 測定プロファイルを読み込んで表示する | [2. プロファイルデータ](2-pattern-profiles.md) | [1. メインウィンドウ](1-main-window.md)、[ファイル形式](appendix/file-formats.md) |
| 既知結晶を重ねて相同定する | [3. 回折線・結晶情報](3-crystal-parameter.md) | [2. プロファイルデータ](2-pattern-profiles.md) |
| プロファイルを処理・補正する | [4. プロファイル情報](4-profile-parameter.md) | [3. 回折線・結晶情報](3-crystal-parameter.md) |
| ピークをフィットして格子定数を精密化する | [6. ピークフィッティング](6-fitting-diffraction-peaks.md) | [3. 回折線・結晶情報](3-crystal-parameter.md) |
| 標準物質から圧力を推定する | [5. 状態方程式](5-equation-of-states.md) | [6. ピークフィッティング](6-fitting-diffraction-peaks.md) |
| 一連のプロファイルを一括解析する | [7. 連続分析](7-sequential-analysis.md) | [8. マクロ](8-macro.md) |
| スクリプトで作業を自動化する | [8. マクロ](8-macro.md) | [7. 連続分析](7-sequential-analysis.md) |

## 目次

- [0. 概要](0-overview.md) — PDIndexer でできることと主な機能
- [1. メインウィンドウ](1-main-window.md) — 画面構成、メニュー、ツールバー、プロファイル/結晶リスト
- [2. プロファイルデータ](2-pattern-profiles.md) — プロファイルデータ、対応形式、読み込み
- [3. 回折線・結晶情報](3-crystal-parameter.md) — 回折線表示、結晶情報、データベース
- [4. プロファイル情報](4-profile-parameter.md) — プロファイル処理、軸設定、演算
- [5. 状態方程式](5-equation-of-states.md) — 標準物質の EOS による圧力計算
- [6. ピークフィッティング](6-fitting-diffraction-peaks.md) — ピークフィッティングと格子定数精密化
- [7. 連続分析](7-sequential-analysis.md) — プロファイル系列の一括解析
- [8. マクロ](8-macro.md) — IronPython スクリプトと関数リファレンス

### 付録

- [動作環境とインストール](appendix/runtime-and-installation.md)
- [ファイル形式](appendix/file-formats.md)
- [トラブルシューティング](appendix/troubleshooting.md)

## クイックスタート

1. [リリースページ](https://github.com/seto77/PDIndexer/releases/latest) からダウンロードしてインストールし、*PDIndexer* を起動します。
2. 測定プロファイルを開きます（ファイルをドラッグ＆ドロップするか、[IPAnalyzer](https://github.com/seto77/IPAnalyzer) からコピーしたプロファイルを貼り付け）。
3. 内蔵データベースから既知結晶を追加（または CIF/AMC ファイルを読み込み）して、回折線を重ねます。
4. ピークをフィットして格子定数を精密化するか、標準物質の状態方程式から圧力を推定します。

## 動作環境

| 項目 | 必要条件 |
|------|------|
| OS | [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/ja-jp/download/dotnet/10.0)（**.NET Runtime ではない**）が動作する Windows |
| 推奨 | 64bit Windows 10/11、メモリ 16 GB 以上、8 コア以上の CPU |

詳細は [動作環境とインストール](appendix/runtime-and-installation.md) を参照してください。

!!! note
    ソースコード・リリース・不具合報告は [GitHub](https://github.com/seto77/PDIndexer) にあります。PDIndexer は [MIT ライセンス](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md) で配布しています。
