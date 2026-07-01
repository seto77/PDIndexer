<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# 概覽

![PDIndexer 主視窗](../assets/cap-zh-Hant-auto/FormMain.png)

PDIndexer 是一款用於分析一維粉末 X 光繞射圖譜的軟體。它可以顯示並分析粉末 X 光繞射儀所得的繞射圖譜，以及以德拜-謝樂 (Debye-Scherrer) 穿透式光學系統測得的同步輻射 X 光，還有中子飛行時間 (TOF) 測量所得的繞射圖譜。

它提供一整套粉末繞射分析所需的工具，包括多重圖譜的疊加顯示、與已知結晶的繞射線比對、以標準物質校正溫度與壓力、圖譜擬合，以及以最小二乘法精修晶格常數。

!!! note "關於本手冊"
    本頁僅為概覽。各功能的詳細操作方法，請參閱各自的專用頁面。

## 主要功能

PDIndexer 提供以下功能。

| 功能 | 說明 |
| --- | --- |
| 圖譜的顯示與比較 | 疊加並比較多個繞射圖譜。橫軸 (\(2\theta\) / \(d\) / \(q\)) 與縱軸的刻度可靈活切換。 |
| 與已知結晶比較 | 計算已知結晶的繞射線，並疊加於觀測圖譜上以進行鑑定。詳情請參閱 [晶體參數](3-crystal-parameter.md)。 |
| 以標準物質校正 | 使用 NaCl EOS、Pt EOS 等狀態方程 (EOS)，由標準物質的晶胞體積估算溫度與壓力。詳情請參閱 [狀態方程 (EOS)](5-equation-of-states.md)。 |
| 峰擬合 | 擬合繞射峰的位置、半高全寬 (FWHM) 與強度。詳情請參閱 [繞射峰擬合](6-fitting-diffraction-peaks.md)。 |
| 晶格常數精修 | 以最小二乘法由峰位置精修晶格常數。**晶胞搜尋器** 也可由峰位置搜尋晶格常數。 |
| 連續分析 | 以 **連續分析** 功能批次處理一系列檔案。詳情請參閱 [連續分析](7-sequential-analysis.md)。 |
| 匯入／匯出 | 可由 CIF、AMC 檔匯入結晶結構，並匯出為 CSV、TSV、GSAS (Rietveld) 格式。 |
| 自動載入 | 監看剪貼簿或資料夾，自動讀取由其他應用程式 (如 IPAnalyzer) 複製而來，或新建立的圖譜／結晶檔案。 |

!!! tip "支援的資料"
    可處理範圍廣泛的圖譜，包括粉末 X 光繞射儀、同步輻射 X 光 (德拜-謝樂穿透式光學系統)，以及中子飛行時間 (TOF) 測量所得的資料。

## 授權條款

本軟體以 **MIT 授權條款** 發布 ([LICENSE.md](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md))。只要接受以下條件，任何人皆可免費自由使用本軟體。

- 您可以自由複製、散布、修改、重新散布修改版本、商業使用、有償販售，或以任何其他方式使用本軟體。
- 重新散布時，請於原始碼中，或於隨附原始碼一併發布的獨立授權檔案中，附上本軟體的著作權聲明及本授權條款的完整內容。
- 本軟體不提供任何保證。因使用本軟體而產生的任何問題，作者概不負責。

## 意見回饋

歡迎透過 GitHub [Issues](https://github.com/seto77/PDIndexer/issues) 提供您的意見與需求。原始碼公開於 [github.com/seto77/PDIndexer](https://github.com/seto77/PDIndexer)。

## 安裝與系統需求

PDIndexer 需要能執行 **.NET Desktop Runtime 6.0 以上版本** 的 Windows 作業系統。部分功能需要較大的運算資源，並採用多執行緒與 GPU 加速以提升速度。為求順暢使用，建議採用具備 16 GB 以上記憶體、8 核心以上 CPU 的 64 位元 Windows 10/11。

詳細的安裝步驟與系統需求，請參閱 [執行環境與安裝](appendix/runtime-and-installation.md)。
