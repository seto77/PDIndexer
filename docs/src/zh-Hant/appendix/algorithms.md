<!-- 260625Cl: migrated from legacy doc/PDIndexerAlgorithm.pdf (former bundled PDF) -->
# 演算法解說

本頁概述 PDIndexer 內部使用的主要數值演算法，是從舊版隨附說明 PDF（`PDIndexerAlgorithm.pdf`）移植並重新整理而成。目的在於傳達「最小化的是什麼、又是如何求解的」，而非提供完整的數學嚴謹性。

本頁涵蓋以下 3 個主題：

1. [晶格常數精修](#lattice-refinement) — 線性最小二乘法
2. [峰擬合](#peak-fitting) — 以 Marquardt 法進行非線性最小二乘，以及各種圖譜函數
3. [三次雲形線（spline）之推導](#cubic-spline) — 背景曲線

關於狀態方程（EOS）的理論，請參閱[狀態方程](../5-equation-of-states.md)。

---

## 晶格常數精修 {#lattice-refinement}

### 廣義線性最小二乘法

給定 \( n \) 組觀測值 \( (X^1_1, X^2_1, \dots, X^m_1, Z_1),\ (X^1_2, X^2_2, \dots, X^m_2, Z_2),\ \dots,\ (X^1_n, X^2_n, \dots, X^m_n, Z_n) \)，欲對 \( m \) 個參數 \( (a^1, a^2, \dots, a^m) \) 擬合線性觀測方程式

$$Z = a^1 X^1 + a^2 X^2 + \dots + a^m X^m$$

只需最小化殘差平方和即可達成。以矩陣表示，

$$
\mathbf{a}=\begin{pmatrix}a^1\\ \vdots\\ a^m\end{pmatrix},\quad
X=\begin{pmatrix}X^1_1 & X^2_1 & \cdots & X^m_1\\ X^1_2 & X^2_2 & \cdots & X^m_2\\ \vdots & & & \vdots\\ X^1_n & X^2_n & \cdots & X^m_n\end{pmatrix},\quad
Y=\begin{pmatrix}Y_1\\ \vdots\\ Y_n\end{pmatrix},\quad
W=\begin{pmatrix}W_1 & 0 & \cdots & 0\\ 0 & W_2 & & \\ \vdots & & \ddots & \\ 0 & & & W_n\end{pmatrix}
$$

其中 \( W \) 為以權重為對角成分的對角矩陣。最小化加權平方和

$$\Delta^2 = (X\mathbf{a}-Y)^{\mathsf{T}}\,W\,(X\mathbf{a}-Y)$$

將其對 \( \mathbf{a} \) 的導數設為零，

$$\delta\Delta^2 = 2\,\delta\mathbf{a}^{\mathsf{T}}\left(X^{\mathsf{T}}W X\,\mathbf{a} - X^{\mathsf{T}}W Y\right) = 0,$$

即得解

$$\mathbf{a} = (X^{\mathsf{T}}W X)^{-1}\,X^{\mathsf{T}}W Y.$$

### 對倒易度規張量的擬合

在晶格常數精修中，觀測方程式依結晶系而異，但在最一般的（三斜晶系）情形下，晶面間距(d值) \( d \) 與指數 \( (h,k,l) \) 之間的關係

$$\left(\frac{1}{d}\right)^2 = h^2 a^{*2} + k^2 b^{*2} + l^2 c^{*2} + 2kl\,b^*c^*\cos\alpha^* + 2lh\,c^*a^*\cos\beta^* + 2hk\,a^*b^*\cos\gamma^*,$$

可視為一個線性模型：

$$
\mathbf{a}=\begin{pmatrix}a^*a^*\\ b^*b^*\\ c^*c^*\\ 2b^*c^*\cos\alpha^*\\ 2c^*a^*\cos\beta^*\\ 2a^*b^*\cos\gamma^*\end{pmatrix},\quad
X=\begin{pmatrix}h_1h_1 & k_1k_1 & l_1l_1 & k_1l_1 & l_1h_1 & h_1k_1\\ \vdots & & & & & \vdots\\ h_nh_n & k_nk_n & l_nl_n & k_nl_n & l_nh_n & h_nk_n\end{pmatrix},\quad
Y=\begin{pmatrix}(1/d_1)^2\\ \vdots\\ (1/d_n)^2\end{pmatrix}
$$

其中 \( a^*, b^*, \dots \) 為倒易晶格常數。以上述線性最小二乘法求解此式，即可得到倒易度規張量的各分量，進而求出晶格常數。

### 權重的選取

權重取決於誤差。假設誤差僅存在於繞射角 \( 2\theta \) 中，則 \( G = (1/d)^2 = 4\sin^2\theta/\lambda^2 \) 對 \( \theta \) 的響應為

$$\frac{\partial G}{\partial\theta} = \frac{4\sin(2\theta)}{\lambda^2},$$

因此變化量 \( \delta\theta \) 會使 \( (1/d)^2 \) 產生 \( \dfrac{4\sin(2\theta)}{\lambda^2}\delta\theta \) 的偏移。故 \( 1/\sin^2(2\theta) \)（誤差平方的倒數）可作為 \( (1/d)^2 \) 的合適權重：

$$
W=\begin{pmatrix}
1/\sin^2(2\theta_1) & 0 & \cdots & 0\\
0 & 1/\sin^2(2\theta_2) & & \\
\vdots & & \ddots & \\
0 & & & 1/\sin^2(2\theta_n)
\end{pmatrix}.
$$

此處 \( 1/\sin^2(2\theta) \) 僅代表各點變異數倒數的*比率*，而非其絕對值，但仍能求得最佳解：這是因為在 \( (X^{\mathsf{T}}W X)^{-1} X^{\mathsf{T}}W Y \) 中 \( W \) 出現兩次，絕對尺度會相互抵消。

### 參數誤差

\( \mathbf{a} \) 的誤差（變異數）來自 \( (X^{\mathsf{T}}W X)^{-1} \) 的對角成分，但由於 \( W \) 僅以比率的方式固定，絕對尺度須另行求出。利用變異數的定義，

$$N - P = \sum_{i=1}^{n}\frac{\delta_i^2}{s_i}$$

（\( N \)：資料個數，\( P \)：參數個數，\( \delta_i \)：第 \( i \) 個資料的殘差，\( s_i \)：第 \( i \) 個資料的變異數），變異數尺度可由所得參數定為

$$s = \frac{\sum_{i=1}^{n}(\delta_i^2 w_i)}{N - P},$$

其平方根即為誤差。這是倒易晶格常數的誤差；若要換算為晶格常數的誤差，須進一步進行誤差傳播計算，但原理上並不困難。

---

## 峰擬合 {#peak-fitting}

### Marquardt 法

PDIndexer 以 **Marquardt 法**（Levenberg–Marquardt 法）擬合峰，這是一種類似牛頓法的非線性迭代方案，兼具快速收斂與穩定性，能以足夠的精度求得最佳值。

設擬合函數為 \( F = F(a_1, a_2, \dots, a_m, X) \)，在初始參數 \( \mathbf{a}^0 \) 處的殘差為

$$R = \sum_{i=1}^{n}\left[Y_i - F(\mathbf{a}^0, X_i)\right]^2.$$

依下式建立 \( m\times m \) 矩陣 \( \alpha \) 與 \( m \) 維向量 \( \beta \)。僅將對角成分乘以 \( (1+\lambda) \) 是 Marquardt 法的關鍵所在，\( \lambda \) 用以控制穩定性與收斂速度：

$$\alpha_{jk} = \sum_{i=1}^{n} w_i\,\frac{\partial F}{\partial a_j}\frac{\partial F}{\partial a_k}\quad(j\neq k),\qquad
\alpha_{jj} = (1+\lambda)\sum_{i=1}^{n} w_i\left(\frac{\partial F}{\partial a_j}\right)^2,$$

$$\beta_j = \sum_{i=1}^{n} w_i\left[Y_i - F(\mathbf{a}^0, X_i)\right]\frac{\partial F}{\partial a_j}.$$

參數依下式更新：

$$\mathbf{a}' = \mathbf{a}^0 + \alpha^{-1}\boldsymbol{\beta}.$$

計算新的殘差 \( R' \)：

- 若 \( R' < R \)，則採用此次更新，並將 \( \lambda \) 縮小（乘以 0.1～0.5 倍）；
- 若 \( R' > R \)，則捨棄此次更新，並將 \( \lambda \) 放大（乘以 2～10 倍）。

重複上述步驟，直到 \( R \) 的變化量足夠小為止。當 \( \lambda \to 0 \) 時，此方法趨近於二次收斂的高斯－牛頓法；當 \( \lambda \) 較大時，則趨近於沿殘差梯度 \( \nabla R \) 方向的最陡下降法。藉由 \( \lambda \) 在兩者間連續切換，即可達成穩定且快速的收斂。

### 圖譜函數

PDIndexer 提供 **Pseudo Voigt 函數**（高斯函數與勞侖茲函數的混合）、**Pearson VII 函數**（一種機率密度函數），以及其非對稱擴充形式 **Split Pseudo Voigt** / **Split Pearson VII**。就運算速度與收斂穩定性而言，預設值為 Symmetric Pseudo Voigt。所有函數皆已正規化為面積為 1。

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

前兩者以 \( x=0 \) 為中心對稱，而 split 形式則依 \( x \) 的正負改變形狀，用以表現非對稱性（例如低角側的拖尾）。一般而言，Pearson VII 較能給出較佳的擬合結果（殘差較小），而 Pseudo Voigt 的收斂則較為穩定。

#### 符號

| 符號 | 意義 |
| --- | --- |
| \( H_k \) | 半高全寬（FWHM） |
| \( \pi \) | 圓周率 |
| \( \eta \)（\( \eta_l, \eta_h \)） | 勞侖茲/高斯混合比（split 形式為低角側／高角側） |
| \( \Gamma \) | 伽瑪函數 |
| \( R \)（\( R_l, R_h \)） | Pearson 指數 |
| \( A \) | 非對稱參數 |
| \( Z \) | 正規化常數（\( \sqrt{\pi\ln 2} \)） |

### 含背景之擬合函數

實際上，圖譜函數 \( f \) 會加上線性背景加以擴充：

$$F(\theta,\Theta,B_1,B_2) = I\cdot f(\theta-\Theta) + B_1 + B_2(\theta-\Theta)$$

（\( I \)：積分強度，\( B_1, B_2 \)：線性背景，\( \Theta \)：峰中心，\( \theta \)：觀測位置）。在指定範圍內，以 Marquardt 法變化各參數，使 \( R = \sum (Y - F)^2 \) 最小化。

各函數的偏微分相當複雜；Marquardt 法會用到這些解析梯度。以下列出代表性的算式以供參考。

??? note "Symmetric Pseudo Voigt 的偏微分"

    設 \( u = \dfrac{\theta-\Theta}{H_k} \)，則

    $$\frac{\partial F}{\partial I} = \frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4u^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \eta} = \frac{2I}{H_k\pi}\left(\frac{1}{1+4u^2}-\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial H_k} = -\frac{2I}{\pi}\left(\eta\,\frac{H_k^2-4(\theta-\Theta)^2}{\{H_k^2+4(\theta-\Theta)^2\}^2}+(1-\eta)\frac{\sqrt{\pi\ln 2}}{H_k^2}\,e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \theta} = \frac{16(\theta-\Theta)I}{H_k^3\pi}\left(\eta\,\frac{1}{(1+4u^2)^2}+(1-\eta)\ln 2\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)+B_2$$

    $$\frac{\partial F}{\partial B_1} = 1,\qquad \frac{\partial F}{\partial B_2} = \theta-\Theta$$

??? note "Pearson VII 的偏微分"

    此處省略對強度與背景的簡單偏微分（\( \partial F/\partial I,\ \partial F/\partial B_1,\ \partial F/\partial B_2 \)）。原始文件中，Pearson 指數同時以 \( R \) 與 \( m \) 表示（為同一量）。設 \( u = \dfrac{\theta-\Theta}{H_k} \)，則

    $$\frac{\partial F}{\partial \Theta} = \frac{8mI(\theta-\Theta)}{H_k^2}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial H_k} = \frac{8mI(\theta-\Theta)^2}{H_k^3}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial m} = \left(1+4(2^{1/R}-1)u^2\right)^{-R}\left(\frac{4\cdot 2^{1/R}(\theta-\Theta)^2\ln 2}{m\left(H_k^2+4(2^{1/R}-1)(\theta-\Theta)^2\right)} - \ln\!\left(1+4(2^{1/R}-1)u^2\right)\right)$$

---

## 三次雲形線（spline）之推導 {#cubic-spline}

PDIndexer 使用三次雲形線（spline）曲線來繪製背景。真正的背景形狀無法精確求解，但軟體會自動偵測非峰區域，並以雲形線連接這些偵測點以形成背景曲線。雲形線能均勻地逼近資料（包含其導數在內），且資料點越密集，逼近效果越好。

給定 \( n \) 個點 \( (X_1,Y_1), (X_2,Y_2), \dots, (X_{n-1},Y_{n-1}), (X_n,Y_n) \)，我們要求一條在每個區間皆為三次函數、且在各點平滑連接（使數值、斜率、曲率皆相符）的曲線（兩端區間 \( \{-\infty, X_1\} \) 與 \( \{X_n, \infty\} \) 視為線性）。

設區間 \( \{X_{m-1}, X_m\} \) 上的函數為

$$F_m = a_m X^3 + b_m X^2 + c_m X + d_m.$$

**內部點（\( 2 \le m \le n-1 \)）。** 數值、一階導數、二階導數的連續性給出

$$F_m(X_m) = a_m X_m^3 + b_m X_m^2 + c_m X_m + d_m = Y_m$$

$$F_{m+1}(X_m) = a_{m+1} X_m^3 + b_{m+1} X_m^2 + c_{m+1} X_m + d_{m+1} = Y_m$$

$$F_m'(X_m) = 3a_m X_m^2 + 2b_m X_m + c_m = F_{m+1}'(X_m) = 3a_{m+1} X_m^2 + 2b_{m+1} X_m + c_{m+1}$$

$$F_m''(X_m) = 6a_m X_m + 2b_m = F_{m+1}''(X_m) = 6a_{m+1} X_m + 2b_{m+1}$$

—— 即 **\( 4n-8 \) 個條件**。

**起點（\( m=1 \)，左端區間為線性）：**

$$F_1(X_1) = c_1 X_1 + d_1 = Y_1$$

$$F_2(X_1) = a_2 X_1^3 + b_2 X_1^2 + c_2 X_1 + d_2 = Y_1$$

$$F_1'(X_1) = c_1 = F_2'(X_1) = 3a_2 X_1^2 + 2b_2 X_1 + c_2$$

$$F_1''(X_1) = F_2''(X_1) = 6a_2 X_1 + 2b_2 = 0$$

—— **4 個條件**。**終點（\( m=n \)）** 同樣給出

$$F_n(X_n) = a_n X_n^3 + b_n X_n^2 + c_n X_n + d_n = Y_n$$

$$F_{n+1}(X_n) = c_{n+1} X_n + d_{n+1} = Y_n$$

$$F_n'(X_n) = 3a_n X_n^2 + 2b_n X_n + c_n = F_{n+1}'(X_n) = c_{n+1}$$

$$F_n''(X_n) = 6a_n X_n + 2b_n = F_{n+1}''(X_n) = 0$$

—— 另外 **4 個條件**。

總計 \( 4n \) 個條件用以求出 \( 4n \) 個未知數，問題因而化為一組聯立方程式。將其寫成矩陣形式並求反矩陣即可輕易求解。

---

## 相關頁面

- [6. 繞射峰擬合](../6-fitting-diffraction-peaks.md) — 實際操作方式
- [狀態方程](../5-equation-of-states.md) — Birch–Murnaghan 式、Mie–Grüneisen 式等 EOS 理論
