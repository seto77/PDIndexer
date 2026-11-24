<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# 故障排除

使用 PDIndexer 时如遇到问题，请先确认以下各项。多数问题可通过安装运行时或检查设置来解决。

## 应用程序无法启动

以下要求适用于由此源代码构建的 .NET 11 版本。对于已发布的版本，请遵循该版本注明的运行时要求。

通过 MSI 安装的 PDIndexer 需要该版本指定的 **.NET Desktop Runtime**（由此源代码构建的版本以 .NET 11 为目标）。免安装 ZIP 包自带运行时。如果 MSI 安装时未安装该运行时，启动时可能会出现错误，或程序无任何反应即退出。

!!! warning "解决方法"
    请按照 [运行环境与安装](runtime-and-installation.md) 中的步骤，安装所用版本要求的、与应用程序体系结构（x64 或 Arm64）一致的 **.NET Desktop Runtime**，然后重新启动 PDIndexer。

## 界面语言无法切换

<!-- 261124Cl changed: the old text described an English/Japanese choice and a manual restart; now there are 11 languages and PDIndexer restarts itself after a confirmation dialog -->
可在菜单栏右端的 `语言` 中选择显示语言（共 11 种语言，各以该语言自身的名称显示）。切换语言需要重启：在确认对话框中选择 **是**，PDIndexer 会以所选语言自动重启。

!!! note
    重启会丢弃未保存的工作（已加载的谱图和正在进行的编辑），请在切换前保存所需内容。如果选择 **否**，语言不会更改。

## 重置损坏的设置

窗口位置、颜色设置及各种选项均保存在注册表中。如果设置损坏导致程序行为异常，可清除注册表以恢复初始状态。

1. 在菜单中勾选 `选项` ▸ `清除注册表（勾选并重启）`。
2. 关闭 PDIndexer。所有已保存的设置将在退出时被清除。
3. 再次启动 PDIndexer，程序将以初始（默认）状态运行。

!!! warning
    此操作会清除包括窗口布局和选项在内的所有已保存设置。在重启并完成重置之前，此操作无法撤销。

## 无法从 IPAnalyzer / CSManager 剪贴板导入

在 [IPAnalyzer](https://github.com/seto77/IPAnalyzer) 和 [CSManager](https://github.com/seto77/CSManager) 等姊妹应用中复制的谱图和晶体，可通过剪贴板自动导入 PDIndexer。如果无法导入，可能是剪贴板监视功能已被禁用。

- 请检查菜单中的 `选项` ▸ `监视剪贴板` 是否已启用。
- 启用后，从其他应用复制的谱图/晶体会被自动读取。

!!! tip
    如果希望自动读取特定文件夹中新创建的 `.pdi` 文件，请使用 `选项` ▸ `监视文件`。

## 强度比未被计算

要计算理论衍射强度，晶体结构中必须包含 **原子位置（原子坐标）**。如果未输入原子位置，峰位置（\(d\) 值）仍可计算，但不会计算强度比。

!!! note "解决方法"
    在 [晶体参数](../3-crystal-parameter.md) 中输入每个原子的元素、坐标和占有率。输入原子位置后，将根据结构因子计算强度比。

## 拟合报告的晶格常数为 NA（不可用）

在通过峰拟合精修晶格常数时，如果独立反射数量不足，晶格常数将无法确定。此时程序会保持原有的晶胞形状、仅改变其整体比例，误差栏显示 NA（不可用）。当反射数等于独立晶格常数的个数时，无法由残差求得标准误差，误差栏同样显示 NA。

- 根据晶系不同，必须提供足够数量的反射，以确定相应数目的独立晶格常数（例如立方晶系仅需 \(a\)，而三斜晶系则需要 \(a, b, c, \alpha, \beta, \gamma\) 六个值）。
- 如果反射线性相关（偏向同一方向），某些晶格常数将无法确定。请包含不同取向的反射。

!!! note "解决方法"
    参见 [衍射峰拟合](../6-fitting-diffraction-peaks.md)，确保拟合中包含足够数量的独立反射。

## 仍未解决

若以上步骤仍无法解决问题，或您发现可重现的缺陷、有功能建议，请在 GitHub 的 Issue 跟踪器中反馈。如可能，请附上重现步骤、所使用的文件以及屏幕截图。

- Issue 跟踪器：<https://github.com/seto77/PDIndexer/issues>
