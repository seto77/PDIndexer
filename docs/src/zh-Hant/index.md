<!-- 260601Cl: English landing page for the PDIndexer Pages manual (content migrated from the legacy docx + yseto.net web manual). -->
<!-- 260625Cl: static-i18n folder mode へ移設 (docs/src/index.md → docs/src/en/index.md)。画像は ../assets、内部リンクは en/ 接頭辞を剥がす。 -->
# PDIndexer 使用手冊

**PDIndexer** 是一款免費、採用 MIT 授權的 Windows 應用程式，用於分析一維粉末繞射圖譜（實驗室／同步輻射 X 射線、中子 TOF）。它能顯示測量圖譜、疊加根據晶體結構計算出的繞射線、處理並校正圖譜、以最小二乘法擬合峰以精修晶格常數，並根據標準物質的狀態方程估算壓力。

![PDIndexer 主視窗](../assets/cap-zh-Hant-auto/FormMain.png)

## 依目標查詢

| 目標 | 從這裡開始 | 後續主要步驟 |
|------|------------|-----------------|
| 讀取並顯示測量圖譜 | [2. 繞射圖譜](2-pattern-profiles.md) | [1. 主視窗](1-main-window.md)、[檔案格式](appendix/file-formats.md) |
| 疊加已知晶體以鑑定相 | [3. 晶體參數](3-crystal-parameter.md) | [2. 繞射圖譜](2-pattern-profiles.md) |
| 處理／校正圖譜 | [4. 圖譜參數](4-profile-parameter.md) | [3. 晶體參數](3-crystal-parameter.md) |
| 擬合峰並精修晶格常數 | [6. 繞射峰擬合](6-fitting-diffraction-peaks.md) | [3. 晶體參數](3-crystal-parameter.md) |
| 根據標準物質估算壓力 | [5. 狀態方程](5-equation-of-states.md) | [6. 繞射峰擬合](6-fitting-diffraction-peaks.md) |
| 批次處理一系列圖譜 | [7. 連續分析](7-sequential-analysis.md) | [8. 巨集](8-macro.md) |
| 以腳本自動化作業 | [8. 巨集](8-macro.md) | [7. 連續分析](7-sequential-analysis.md) |

## 目錄

- [0. 概觀](0-overview.md) — PDIndexer 能做什麼，以及主要功能
- [1. 主視窗](1-main-window.md) — 版面配置、選單、工具列、圖譜／晶體清單
- [2. 繞射圖譜](2-pattern-profiles.md) — 圖譜資料、支援格式、讀取方式
- [3. 晶體參數](3-crystal-parameter.md) — 繞射線顯示、晶體資訊、資料庫
- [4. 圖譜參數](4-profile-parameter.md) — 圖譜處理、座標軸設定、運算子
- [5. 狀態方程](5-equation-of-states.md) — 依標準物質狀態方程估算壓力
- [6. 繞射峰擬合](6-fitting-diffraction-peaks.md) — 峰擬合與晶格常數精修
- [7. 連續分析](7-sequential-analysis.md) — 對一系列圖譜進行批次分析
- [8. 巨集](8-macro.md) — IronPython 腳本與函式參考

### 附錄

- [執行環境與安裝](appendix/runtime-and-installation.md)
- [檔案格式](appendix/file-formats.md)
- [疑難排解](appendix/troubleshooting.md)

## 快速上手

1. 從 [Releases](https://github.com/seto77/PDIndexer/releases/latest) 下載並安裝，然後啟動 *PDIndexer*。
2. 開啟測量圖譜（拖放檔案，或貼上從 [IPAnalyzer](https://github.com/seto77/IPAnalyzer) 複製的圖譜）。
3. 從內建資料庫新增已知晶體（或匯入 CIF/AMC 檔案），以疊加其繞射線。
4. 擬合峰以精修晶格常數，或根據標準物質的狀態方程估算壓力。

## 系統需求

| 項目 | 需求 |
|------|-------------|
| 作業系統 | 需搭配 [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0)（**非** .NET Runtime）的 Windows |
| 建議規格 | 64 位元 Windows 10/11、16 GB 以上記憶體、8 核心以上 CPU |

詳情請參閱[執行環境與安裝](appendix/runtime-and-installation.md)。

!!! note
    原始碼、發行版本與問題回報皆位於 [GitHub](https://github.com/seto77/PDIndexer)。PDIndexer 依 [MIT 授權](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md) 發布。
