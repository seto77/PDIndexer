<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# 概述

![PDIndexer 主窗口](../assets/cap-zh-Hans-auto/FormMain.png)

PDIndexer 是一款用于分析一维粉末 X 射线衍射谱图的软件。它可以显示和分析来自粉末 X 射线衍射仪、以德拜-谢乐 (Debye-Scherrer) 透射光学系统测量的同步辐射 X 射线，以及中子飞行时间 (TOF) 测量得到的衍射谱图。

它提供了一整套用于粉末衍射分析的工具，包括多个谱图的叠加显示、与已知晶体衍射线的比较、基于标准物质的温度和压力校准、谱图拟合，以及晶格参数的最小二乘法精修。

!!! note "关于本手册"
    本页仅为概述。有关各功能的详细操作说明，请参阅相应的专题页面。

## 主要功能

PDIndexer 提供以下功能。

| 功能 | 说明 |
| --- | --- |
| 谱图的显示与比较 | 叠加显示并比较多个衍射谱图。横轴 (\(2\theta\) / \(d\) / \(q\)) 与纵轴的比例尺可灵活切换。 |
| 与已知晶体比较 | 计算已知晶体的衍射线，并叠加在观测谱图上以进行鉴定。详情请参阅 [晶体参数](3-crystal-parameter.md)。 |
| 使用标准物质校准 | 利用 NaCl EOS、Pt EOS 等状态方程 (EOS)，根据标准物质的晶胞体积估算温度和压力。详情请参阅 [状态方程 (EOS)](5-equation-of-states.md)。 |
| 峰拟合 | 拟合衍射峰的位置、半高全宽 (FWHM) 和强度。详情请参阅 [衍射峰拟合](6-fitting-diffraction-peaks.md)。 |
| 晶格参数精修 | 通过最小二乘法从峰位置精修晶格常数。**晶胞查找器** 也可以从峰位置搜索晶格常数。 |
| 连续分析 | 使用 **连续分析** 功能批量处理一系列文件。详情请参阅 [连续分析](7-sequential-analysis.md)。 |
| 导入/导出 | 支持从 CIF 和 AMC 文件导入晶体结构，并导出为 CSV、TSV 和 GSAS (Rietveld) 格式。 |
| 自动读取 | 监视剪贴板或文件夹，自动读取从其他应用程序 (如 IPAnalyzer) 复制的谱图/晶体，或新创建的文件。 |

!!! tip "支持的数据"
    可处理来自粉末 X 射线衍射仪、同步辐射 X 射线 (德拜-谢乐透射光学系统) 和中子飞行时间 (TOF) 测量等多种谱图。

## 许可证

本软件依据 **MIT 许可证** ([LICENSE.md](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md)) 发布。只要接受以下条件，任何人均可免费自由使用本软件。

- 您可以自由复制、分发、修改、重新分发修改后的版本、用于商业用途、有偿销售，或以任何其他方式使用本软件。
- 重新分发时，请在源代码中或随源代码附带的单独许可证文件中，附上本软件的版权声明和本许可证的全文。
- 本软件不附带任何形式的保证。因使用本软件而产生的任何问题，作者概不负责。

## 反馈

如有意见和需求，请通过 GitHub 的 [Issues](https://github.com/seto77/PDIndexer/issues) 告知我们。源代码发布于 [github.com/seto77/PDIndexer](https://github.com/seto77/PDIndexer)。

## 安装与系统要求

PDIndexer 需要能够运行 **.NET Desktop Runtime 6.0 或更高版本** 的 Windows 操作系统。部分功能需要较大的计算资源，为提高速度，本软件使用了多线程和 GPU 加速。为获得流畅的使用体验，建议使用配备 16 GB 以上内存、8 核或更高性能 CPU 的 64 位 Windows 10/11 系统。

有关详细的安装步骤和系统要求，请参阅 [运行环境与安装](appendix/runtime-and-installation.md)。
