<!-- 260625Cl: migrated from legacy doc/PDIndexerAlgorithm.pdf (former bundled PDF) -->
# 算法说明

本页概述了 PDIndexer 内部使用的主要数值算法。它是曾经随发行版一同提供的说明性 PDF（`PDIndexerAlgorithm.pdf`）迁移与重新整理后的版本。目标是传达*最小化的是什么、以及如何求解*，而非追求完整的数学严谨性。

本页涵盖以下三个主题：

1. [晶格常数精修](#lattice-refinement) — 线性最小二乘法
2. [峰拟合](#peak-fitting) — 基于 Marquardt 法的非线性最小二乘法，以及各种峰形函数
3. [三次样条曲线的推导](#cubic-spline) — 背景曲线

关于状态方程（EOS）的理论，请参见[状态方程](../5-equation-of-states.md)。

---

## 晶格常数精修 {#lattice-refinement}

### 广义线性最小二乘法

给定 \( n \) 组观测值 \( (X^1_1, X^2_1, \dots, X^m_1, Z_1),\ (X^1_2, X^2_2, \dots, X^m_2, Z_2),\ \dots,\ (X^1_n, X^2_n, \dots, X^m_n, Z_n) \)，对于 \( m \) 个参数 \( (a^1, a^2, \dots, a^m) \) 拟合线性观测方程

$$Z = a^1 X^1 + a^2 X^2 + \dots + a^m X^m$$

可通过最小化残差平方和来实现。用矩阵表示为

$$
\mathbf{a}=\begin{pmatrix}a^1\\ \vdots\\ a^m\end{pmatrix},\quad
X=\begin{pmatrix}X^1_1 & X^2_1 & \cdots & X^m_1\\ X^1_2 & X^2_2 & \cdots & X^m_2\\ \vdots & & & \vdots\\ X^1_n & X^2_n & \cdots & X^m_n\end{pmatrix},\quad
Y=\begin{pmatrix}Y_1\\ \vdots\\ Y_n\end{pmatrix},\quad
W=\begin{pmatrix}W_1 & 0 & \cdots & 0\\ 0 & W_2 & & \\ \vdots & & \ddots & \\ 0 & & & W_n\end{pmatrix}
$$

其中 \( W \) 是以权重为对角元素的对角矩阵。最小化加权平方和

$$\Delta^2 = (X\mathbf{a}-Y)^{\mathsf{T}}\,W\,(X\mathbf{a}-Y)$$

的方法是令其关于 \( \mathbf{a} \) 的导数为零，

$$\delta\Delta^2 = 2\,\delta\mathbf{a}^{\mathsf{T}}\left(X^{\mathsf{T}}W X\,\mathbf{a} - X^{\mathsf{T}}W Y\right) = 0,$$

由此得到解

$$\mathbf{a} = (X^{\mathsf{T}}W X)^{-1}\,X^{\mathsf{T}}W Y.$$

### 拟合倒易度量张量

在晶格常数精修中，观测方程取决于晶系，但在最一般的（三斜）情形下，面间距 \( d \) 与指数 \( (h,k,l) \) 之间的关系

$$\left(\frac{1}{d}\right)^2 = h^2 a^{*2} + k^2 b^{*2} + l^2 c^{*2} + 2kl\,b^*c^*\cos\alpha^* + 2lh\,c^*a^*\cos\beta^* + 2hk\,a^*b^*\cos\gamma^*,$$

可视为一个线性模型：

$$
\mathbf{a}=\begin{pmatrix}a^*a^*\\ b^*b^*\\ c^*c^*\\ 2b^*c^*\cos\alpha^*\\ 2c^*a^*\cos\beta^*\\ 2a^*b^*\cos\gamma^*\end{pmatrix},\quad
X=\begin{pmatrix}h_1h_1 & k_1k_1 & l_1l_1 & k_1l_1 & l_1h_1 & h_1k_1\\ \vdots & & & & & \vdots\\ h_nh_n & k_nk_n & l_nl_n & k_nl_n & l_nh_n & h_nk_n\end{pmatrix},\quad
Y=\begin{pmatrix}(1/d_1)^2\\ \vdots\\ (1/d_n)^2\end{pmatrix}
$$

其中 \( a^*, b^*, \dots \) 是倒易晶格常数。用上述线性最小二乘法求解，即可得到倒易度量张量的各分量，进而求得晶格常数。

### 权重的选取

权重取决于误差。假设误差仅存在于衍射角 \( 2\theta \) 中，则 \( G = (1/d)^2 = 4\sin^2\theta/\lambda^2 \) 对 \( \theta \) 的响应为

$$\frac{\partial G}{\partial\theta} = \frac{4\sin(2\theta)}{\lambda^2},$$

因此变化量 \( \delta\theta \) 会使 \( (1/d)^2 \) 变化 \( \dfrac{4\sin(2\theta)}{\lambda^2}\delta\theta \)。所以 \( 1/\sin^2(2\theta) \)（误差平方的倒数）适合作为 \( (1/d)^2 \) 的权重：

$$
W=\begin{pmatrix}
1/\sin^2(2\theta_1) & 0 & \cdots & 0\\
0 & 1/\sin^2(2\theta_2) & & \\
\vdots & & \ddots & \\
0 & & & 1/\sin^2(2\theta_n)
\end{pmatrix}.
$$

这里的 \( 1/\sin^2(2\theta) \) 只表示各点方差倒数的*比例*，而非其绝对值，但最优解仍然可以求得：在 \( (X^{\mathsf{T}}W X)^{-1} X^{\mathsf{T}}W Y \) 中，因子 \( W \) 出现了两次，绝对尺度会相互抵消。

### 参数误差

\( \mathbf{a} \) 的误差（方差）来自 \( (X^{\mathsf{T}}W X)^{-1} \) 的对角元素，但由于 \( W \) 仅按比例确定，其绝对尺度必须另行求出。利用方差的定义

$$N - P = \sum_{i=1}^{n}\frac{\delta_i^2}{s_i}$$

（\( N \)：数据个数，\( P \)：参数个数，\( \delta_i \)：第 \( i \) 个数据的残差，\( s_i \)：第 \( i \) 个数据的方差），可根据所得参数确定方差的尺度为

$$s = \frac{\sum_{i=1}^{n}(\delta_i^2 w_i)}{N - P},$$

其平方根即为误差。这是倒易晶格常数的误差；若要转换为晶格常数的误差，还需要进一步传播误差，但原理上并不困难。

---

## 峰拟合 {#peak-fitting}

### Marquardt 法

PDIndexer 使用 **Marquardt 法**（Levenberg–Marquardt 法）拟合峰形，这是一种类似于牛顿法的非线性迭代方案。它兼具快速收敛与稳定性，能以足够的精度求得最优解。

设拟合函数为 \( F = F(a_1, a_2, \dots, a_m, X) \)，初始参数 \( \mathbf{a}^0 \) 处的残差为

$$R = \sum_{i=1}^{n}\left[Y_i - F(\mathbf{a}^0, X_i)\right]^2.$$

按如下方式构造 \( m\times m \) 矩阵 \( \alpha \) 与 \( m \) 维向量 \( \beta \)。仅将对角元素乘以 \( (1+\lambda) \) 是 Marquardt 法的关键思想，\( \lambda \) 用于控制稳定性与收敛速度：

$$\alpha_{jk} = \sum_{i=1}^{n} w_i\,\frac{\partial F}{\partial a_j}\frac{\partial F}{\partial a_k}\quad(j\neq k),\qquad
\alpha_{jj} = (1+\lambda)\sum_{i=1}^{n} w_i\left(\frac{\partial F}{\partial a_j}\right)^2,$$

$$\beta_j = \sum_{i=1}^{n} w_i\left[Y_i - F(\mathbf{a}^0, X_i)\right]\frac{\partial F}{\partial a_j}.$$

参数按下式更新：

$$\mathbf{a}' = \mathbf{a}^0 + \alpha^{-1}\boldsymbol{\beta}.$$

计算新的残差 \( R' \)，并且：

- 若 \( R' < R \)，则采用该更新，并缩小 \( \lambda \)（乘以 0.1～0.5 的系数）；
- 若 \( R' > R \)，则舍弃该更新，并放大 \( \lambda \)（乘以 2～10 的系数）。

重复以上过程，直到 \( R \) 的变化足够小为止。当 \( \lambda \to 0 \) 时，该方法趋近于二次收敛的 Gauss–Newton 法；当 \( \lambda \) 较大时，则趋近于沿残差梯度 \( \nabla R \) 的最速下降法。通过 \( \lambda \) 在两者之间连续切换，可获得稳定且快速的收敛。

### 峰形函数

PDIndexer 提供 **Pseudo Voigt 函数**（高斯函数与洛伦兹函数的混合）、**Pearson VII 函数**（一种概率密度函数），以及它们的非对称扩展 **Split Pseudo Voigt** / **Split Pearson VII**。出于速度与收敛稳定性的考虑，默认使用 Symmetric Pseudo Voigt。所有函数均已归一化为面积为 1。

**Symmetric Pseudo Voigt**

$$f(x,\eta,H_k)=\frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4\left(\dfrac{x}{H_k}\right)^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot 2^{-4\left(\frac{x}{H_k}\right)^2}\right)$$

**Split Pseudo Voigt（Toraya 1990，修改版）**

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_h-\eta_l)(Z-1)}{(1+e^{A})(\eta_h+Z(1-\eta_h))}}\left(\eta_l\,\frac{1}{1+(1+e^{-A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_l)Z\cdot 2^{-4(1+e^{-A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x<0)$$

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_l-\eta_h)(Z-1)}{(1+e^{-A})(\eta_h+Z(1-\eta_h))}}\left(\eta_h\,\frac{1}{1+(1+e^{A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_h)Z\cdot 2^{-4(1+e^{A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x>0)$$

**Symmetric Pearson VII**

$$f(x,R,H_k)=\frac{2\sqrt{2^{1/R}-1}\,\Gamma(R)}{\sqrt{\pi}\,\Gamma(R-1/2)\,H_k}\left(1+4(2^{1/R}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R}$$

**Split Pearson VII（Toraya 1990，修改版）**

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{-A})^2(2^{1/R_l}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_l}\quad(x<0)$$

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{A})^2(2^{1/R_h}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_h}\quad(x>0)$$

前两者关于 \( x=0 \) 对称，而 Split 形式则根据 \( x \) 的符号改变形状以表达非对称性（例如低角度侧的拖尾）。一般而言，Pearson VII 往往能给出更好的拟合效果（更小的残差），而 Pseudo Voigt 则往往收敛更稳定。

#### 符号说明

| 符号 | 含义 |
| --- | --- |
| \( H_k \) | 半值全宽（FWHM） |
| \( \pi \) | 圆周率 |
| \( \eta \)（\( \eta_l, \eta_h \)） | 洛伦兹/高斯混合比例（Split 形式为低角度侧／高角度侧） |
| \( \Gamma \) | 伽马函数 |
| \( R \)（\( R_l, R_h \)） | Pearson 指数 |
| \( A \) | 非对称参数 |
| \( Z \) | 归一化常数（\( \sqrt{\pi\ln 2} \)） |

### 含背景的拟合函数

实际计算中，会在峰形函数 \( f \) 的基础上加入线性背景进行扩展：

$$F(\theta,\Theta,B_1,B_2) = I\cdot f(\theta-\Theta) + B_1 + B_2(\theta-\Theta)$$

（\( I \)：积分强度，\( B_1, B_2 \)：线性背景，\( \Theta \)：峰中心，\( \theta \)：观测位置）。在给定范围内，通过 Marquardt 法改变各参数，使 \( R = \sum (Y - F)^2 \) 最小化。

各函数的偏导数较为复杂；Marquardt 法使用这些解析梯度。以下给出具有代表性的表达式，供参考。

??? note "Symmetric Pseudo Voigt 的偏导数"

    记 \( u = \dfrac{\theta-\Theta}{H_k} \)，

    $$\frac{\partial F}{\partial I} = \frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4u^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \eta} = \frac{2I}{H_k\pi}\left(\frac{1}{1+4u^2}-\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial H_k} = -\frac{2I}{\pi}\left(\eta\,\frac{H_k^2-4(\theta-\Theta)^2}{\{H_k^2+4(\theta-\Theta)^2\}^2}+(1-\eta)\frac{\sqrt{\pi\ln 2}}{H_k^2}\,e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \theta} = \frac{16(\theta-\Theta)I}{H_k^3\pi}\left(\eta\,\frac{1}{(1+4u^2)^2}+(1-\eta)\ln 2\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)+B_2$$

    $$\frac{\partial F}{\partial B_1} = 1,\qquad \frac{\partial F}{\partial B_2} = \theta-\Theta$$

??? note "Pearson VII 的偏导数"

    关于强度和背景的简单偏导数（\( \partial F/\partial I,\ \partial F/\partial B_1,\ \partial F/\partial B_2 \)）从略。原始文档中 Pearson 指数同时以 \( R \) 与 \( m \) 表示（为同一物理量）。记 \( u = \dfrac{\theta-\Theta}{H_k} \)，

    $$\frac{\partial F}{\partial \Theta} = \frac{8mI(\theta-\Theta)}{H_k^2}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial H_k} = \frac{8mI(\theta-\Theta)^2}{H_k^3}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial m} = \left(1+4(2^{1/R}-1)u^2\right)^{-R}\left(\frac{4\cdot 2^{1/R}(\theta-\Theta)^2\ln 2}{m\left(H_k^2+4(2^{1/R}-1)(\theta-\Theta)^2\right)} - \ln\!\left(1+4(2^{1/R}-1)u^2\right)\right)$$

---

## 三次样条曲线的推导 {#cubic-spline}

PDIndexer 使用三次样条曲线来绘制背景。真实的背景形状无法精确求解，但软件会自动检测非峰区域，并用样条曲线连接检测到的点以构成背景曲线。样条曲线能够均匀地逼近数据（包括其导数），且数据点越密集，逼近效果越好。

给定 \( n \) 个点 \( (X_1,Y_1), (X_2,Y_2), \dots, (X_{n-1},Y_{n-1}), (X_n,Y_n) \)，我们需要求出一条在每个区间上均为三次函数、且在各点处数值、斜率与曲率都平滑连接的曲线（两端区间 \( \{-\infty, X_1\} \) 与 \( \{X_n, \infty\} \) 取为线性函数）。

设区间 \( \{X_{m-1}, X_m\} \) 上的函数为

$$F_m = a_m X^3 + b_m X^2 + c_m X + d_m.$$

**内部点（\( 2 \le m \le n-1 \)）。** 数值、一阶导数、二阶导数的连续性给出

$$F_m(X_m) = a_m X_m^3 + b_m X_m^2 + c_m X_m + d_m = Y_m$$

$$F_{m+1}(X_m) = a_{m+1} X_m^3 + b_{m+1} X_m^2 + c_{m+1} X_m + d_{m+1} = Y_m$$

$$F_m'(X_m) = 3a_m X_m^2 + 2b_m X_m + c_m = F_{m+1}'(X_m) = 3a_{m+1} X_m^2 + 2b_{m+1} X_m + c_{m+1}$$

$$F_m''(X_m) = 6a_m X_m + 2b_m = F_{m+1}''(X_m) = 6a_{m+1} X_m + 2b_{m+1}$$

——即 **\( 4n-8 \) 个条件**。

**起点（\( m=1 \)，左端区间为线性）：**

$$F_1(X_1) = c_1 X_1 + d_1 = Y_1$$

$$F_2(X_1) = a_2 X_1^3 + b_2 X_1^2 + c_2 X_1 + d_2 = Y_1$$

$$F_1'(X_1) = c_1 = F_2'(X_1) = 3a_2 X_1^2 + 2b_2 X_1 + c_2$$

$$F_1''(X_1) = F_2''(X_1) = 6a_2 X_1 + 2b_2 = 0$$

——**4 个条件**。**终点（\( m=n \)）** 同样给出

$$F_n(X_n) = a_n X_n^3 + b_n X_n^2 + c_n X_n + d_n = Y_n$$

$$F_{n+1}(X_n) = c_{n+1} X_n + d_{n+1} = Y_n$$

$$F_n'(X_n) = 3a_n X_n^2 + 2b_n X_n + c_n = F_{n+1}'(X_n) = c_{n+1}$$

$$F_n''(X_n) = 6a_n X_n + 2b_n = F_{n+1}''(X_n) = 0$$

——另外 **4 个条件**。

总计 \( 4n \) 个条件确定 \( 4n \) 个未知量，问题由此归结为一个联立方程组。将其写成矩阵形式并求逆，即可轻松求解。

---

## 相关页面

- [6. 衍射峰拟合](../6-fitting-diffraction-peaks.md) — 实际操作方法
- [状态方程](../5-equation-of-states.md) — Birch–Murnaghan 方程、Mie–Grüneisen 方程等 EOS 理论
