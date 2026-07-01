<!-- 260625Cl: migrated from legacy doc/PDIndexerAlgorithm.pdf (旧 同梱解説PDF) -->
# アルゴリズム解説

このページは、PDIndexer が内部で用いている主要な計算アルゴリズムの概説です。かつて配布物に同梱していた解説 PDF（`PDIndexerAlgorithm.pdf`）の内容を移植・再構成したものです。数学的な詳細よりも「何を最小化し、どう解いているか」という流れの把握を目的としています。

扱うのは次の 3 つです。

1. [格子定数の精密化](#lattice-refinement) — 線形最小二乗法
2. [ピークのフィッティング](#peak-fitting) — Marquardt 法による非線形最小二乗とプロファイル関数
3. [3 次スプライン関数の導出](#cubic-spline) — バックグラウンド曲線

状態方程式（EOS）の理論については [状態方程式](../5-equation-of-states.md) を参照してください。

---

## 格子定数の精密化 {#lattice-refinement}

### 一般化した線形最小二乗法

一般に \( n \) 個の観測値の組 \( (X^1_1, X^2_1, \dots, X^m_1, Z_1),\ (X^1_2, X^2_2, \dots, X^m_2, Z_2),\ \dots,\ (X^1_n, X^2_n, \dots, X^m_n, Z_n) \) が与えられたとき、\( m \) 個のパラメータ \( (a^1, a^2, \dots, a^m) \) について線形の観測方程式

$$Z = a^1 X^1 + a^2 X^2 + \dots + a^m X^m$$

にフィッティングさせるには、二乗残差を最小にすればよいことが知られています。行列で表すと、

$$
\mathbf{a}=\begin{pmatrix}a^1\\ \vdots\\ a^m\end{pmatrix},\quad
X=\begin{pmatrix}X^1_1 & X^2_1 & \cdots & X^m_1\\ X^1_2 & X^2_2 & \cdots & X^m_2\\ \vdots & & & \vdots\\ X^1_n & X^2_n & \cdots & X^m_n\end{pmatrix},\quad
Y=\begin{pmatrix}Y_1\\ \vdots\\ Y_n\end{pmatrix},\quad
W=\begin{pmatrix}W_1 & 0 & \cdots & 0\\ 0 & W_2 & & \\ \vdots & & \ddots & \\ 0 & & & W_n\end{pmatrix}
$$

とおきます（\( W \) は重みを対角成分に持つ対角行列）。重み付き二乗残差

$$\Delta^2 = (X\mathbf{a}-Y)^{\mathsf{T}}\,W\,(X\mathbf{a}-Y)$$

を最小にするので、\( \mathbf{a} \) による微分を 0 とおくと

$$\delta\Delta^2 = 2\,\delta\mathbf{a}^{\mathsf{T}}\left(X^{\mathsf{T}}W X\,\mathbf{a} - X^{\mathsf{T}}W Y\right) = 0$$

より、解は

$$\mathbf{a} = (X^{\mathsf{T}}W X)^{-1}\,X^{\mathsf{T}}W Y$$

となります。

### 逆格子計量テンソルへの当てはめ

格子定数の精密化では、観測方程式は結晶系によって変わりますが、最も一般的な三斜晶系では、面間隔 \( d \) と指数 \( (h,k,l) \) の関係

$$\left(\frac{1}{d}\right)^2 = h^2 a^{*2} + k^2 b^{*2} + l^2 c^{*2} + 2kl\,b^*c^*\cos\alpha^* + 2lh\,c^*a^*\cos\beta^* + 2hk\,a^*b^*\cos\gamma^*$$

を線形モデルとみなします。すなわち

$$
\mathbf{a}=\begin{pmatrix}a^*a^*\\ b^*b^*\\ c^*c^*\\ 2b^*c^*\cos\alpha^*\\ 2c^*a^*\cos\beta^*\\ 2a^*b^*\cos\gamma^*\end{pmatrix},\quad
X=\begin{pmatrix}h_1h_1 & k_1k_1 & l_1l_1 & k_1l_1 & l_1h_1 & h_1k_1\\ \vdots & & & & & \vdots\\ h_nh_n & k_nk_n & l_nl_n & k_nl_n & l_nh_n & h_nk_n\end{pmatrix},\quad
Y=\begin{pmatrix}(1/d_1)^2\\ \vdots\\ (1/d_n)^2\end{pmatrix}
$$

とおきます（\( a^*, b^*, \dots \) は逆格子定数）。これを前節の線形最小二乗で解けば、逆格子計量テンソルの成分が求まり、そこから格子定数が得られます。

### 重みの取り方

重みは誤差に依存します。回折角 \( 2\theta \) にのみ誤差が生じると考えると、\( G = (1/d)^2 = 4\sin^2\theta/\lambda^2 \) の \( \theta \) に対する応答は

$$\frac{\partial G}{\partial\theta} = \frac{4\sin(2\theta)}{\lambda^2}$$

であり、\( \theta \) が \( \delta\theta \) だけ変化すると \( (1/d)^2 \) は \( \dfrac{4\sin(2\theta)}{\lambda^2}\delta\theta \) だけ変化します。したがって \( (1/d)^2 \) に対する重み（誤差の二乗の逆数）として \( 1/\sin^2(2\theta) \) が適切と考えられます。

$$
W=\begin{pmatrix}
1/\sin^2(2\theta_1) & 0 & \cdots & 0\\
0 & 1/\sin^2(2\theta_2) & & \\
\vdots & & \ddots & \\
0 & & & 1/\sin^2(2\theta_n)
\end{pmatrix}
$$

ここで \( 1/\sin^2(2\theta) \) は各点の分散の逆数の **絶対値ではなく比率** を表しています。それでも最適値は求められます。これは \( (X^{\mathsf{T}}W X)^{-1} X^{\mathsf{T}}W Y \) のように \( W \) が 2 回現れて、絶対的なスケールがキャンセルアウトするためです。

### パラメータの誤差

パラメータ \( \mathbf{a} \) の誤差（分散）は \( (X^{\mathsf{T}}W X)^{-1} \) の対角成分から得られますが、上記のとおり \( W \) は比率でしか決めていないため、分散の絶対値は別途求める必要があります。分散の定義

$$N - P = \sum_{i=1}^{n}\frac{\delta_i^2}{s_i}$$

（\( N \): データ個数、\( P \): パラメータ数、\( \delta_i \): \( i \) 番目のデータの偏差（残差）、\( s_i \): \( i \) 番目のデータの分散）を用いると、求めたパラメータから

$$s = \frac{\sum_{i=1}^{n}(\delta_i^2 w_i)}{N - P}$$

として分散のスケールが定まり、その平方根が誤差になります。これは逆格子定数の誤差なので、格子定数の誤差にするにはさらに誤差の伝播を解く必要がありますが、原理的には可能です。

---

## ピークのフィッティング {#peak-fitting}

### Marquardt 法

PDIndexer は、ニュートン法に似た **マルカール（Marquardt）法**（Levenberg–Marquardt 法）でピークを非線形フィッティングします。高速な収束速度と安定性を兼ね備えており、十分な精度で最適値を求められます。

フィッティング関数を \( F = F(a_1, a_2, \dots, a_m, X) \) とし、初期パラメータ \( \mathbf{a}^0 \) における残差を

$$R = \sum_{i=1}^{n}\left[Y_i - F(\mathbf{a}^0, X_i)\right]^2$$

とします。次のように \( m\times m \) 行列 \( \alpha \) と \( m \) 次ベクトル \( \beta \) を組み立てます。対角成分だけを \( (1+\lambda) \) 倍するのが Marquardt 法の要点で、\( \lambda \) が安定性と収束速度を制御します。

$$\alpha_{jk} = \sum_{i=1}^{n} w_i\,\frac{\partial F}{\partial a_j}\frac{\partial F}{\partial a_k}\quad(j\neq k),\qquad
\alpha_{jj} = (1+\lambda)\sum_{i=1}^{n} w_i\left(\frac{\partial F}{\partial a_j}\right)^2$$

$$\beta_j = \sum_{i=1}^{n} w_i\left[Y_i - F(\mathbf{a}^0, X_i)\right]\frac{\partial F}{\partial a_j}$$

新しいパラメータは

$$\mathbf{a}' = \mathbf{a}^0 + \alpha^{-1}\boldsymbol{\beta}$$

で更新します。新しい残差 \( R' \) を計算し、

- \( R' < R \) なら更新を採用し、\( \lambda \) を 0.1〜0.5 倍して小さくする
- \( R' > R \) なら更新を破棄し、\( \lambda \) を 2〜10 倍して大きくする

ことを繰り返し、\( R \) の変化が十分小さくなったところで終了します。\( \lambda \to 0 \) では非線形の 2 次収束（ガウス・ニュートン法）に、\( \lambda \) が大きいときは残差の勾配 \( \nabla R \) に沿ってパラメータを動かす最急降下法に近づきます。両者を \( \lambda \) で連続的に切り替えることで、安定かつ高速に収束します。

### プロファイル関数

PDIndexer は、ガウス関数とローレンツ関数の混合である **Pseudo Voigt 関数**、確率密度分布関数のひとつである **Pearson VII 関数**、およびそれらを非対称に拡張した **Split Pseudo Voigt** / **Split Pearson VII** を利用できます。計算速度と収束安定性の点からは Symmetric Pseudo Voigt が既定です。いずれの関数も積分値が 1 に規格化してあります。

**Symmetric Pseudo Voigt**

$$f(x,\eta,H_k)=\frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4\left(\dfrac{x}{H_k}\right)^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot 2^{-4\left(\frac{x}{H_k}\right)^2}\right)$$

**Split Pseudo Voigt（Toraya 1990 改）**

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_h-\eta_l)(Z-1)}{(1+e^{A})(\eta_h+Z(1-\eta_h))}}\left(\eta_l\,\frac{1}{1+(1+e^{-A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_l)Z\cdot 2^{-4(1+e^{-A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x<0)$$

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_l-\eta_h)(Z-1)}{(1+e^{-A})(\eta_h+Z(1-\eta_h))}}\left(\eta_h\,\frac{1}{1+(1+e^{A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_h)Z\cdot 2^{-4(1+e^{A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x>0)$$

**Symmetric Pearson VII**

$$f(x,R,H_k)=\frac{2\sqrt{2^{1/R}-1}\,\Gamma(R)}{\sqrt{\pi}\,\Gamma(R-1/2)\,H_k}\left(1+4(2^{1/R}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R}$$

**Split Pearson VII（Toraya 1990 改）**

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{-A})^2(2^{1/R_l}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_l}\quad(x<0)$$

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{A})^2(2^{1/R_h}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_h}\quad(x>0)$$

前半の 2 つは \( x=0 \) を中心に対称ですが、Split 型は \( x \) の符号で形を変え、非対称性（低角側に引く裾など）を表現します。一般に、フィッティングの良さ（残差の小ささ）は Pearson VII が優れ、収束の安定度は Pseudo Voigt が優れる傾向があります。

#### 記号

| 記号 | 意味 |
| --- | --- |
| \( H_k \) | 半値全幅（FWHM） |
| \( \pi \) | 円周率 |
| \( \eta \)（\( \eta_l, \eta_h \)） | ローレンツ関数とガウス関数の混合比（Split 型は低角側・高角側） |
| \( \Gamma \) | ガンマ関数 |
| \( R \)（\( R_l, R_h \)） | Pearson 関数の指数部 |
| \( A \) | 非対称パラメータ |
| \( Z \) | 規格化定数（\( \sqrt{\pi\ln 2} \)） |

### 背景を含むフィッティング関数

実際の計算では、上記のプロファイル関数 \( f \) にバックグラウンドを加えて

$$F(\theta,\Theta,B_1,B_2) = I\cdot f(\theta-\Theta) + B_1 + B_2(\theta-\Theta)$$

と拡張します（\( I \): 積分強度、\( B_1, B_2 \): バックグラウンドの一次関数、\( \Theta \): ピークの中心位置、\( \theta \): 観測値）。与えられた範囲内で \( R = \sum (Y - F)^2 \) が最小になるよう、各パラメータを Marquardt 法で変化させます。

各関数の偏微分は複雑ですが、Marquardt 法ではこれらの解析的な勾配を用います。参考のため、代表的な式を以下に示します。

??? note "Symmetric Pseudo Voigt の偏微分"

    \( u = \dfrac{\theta-\Theta}{H_k} \) とおくと、

    $$\frac{\partial F}{\partial I} = \frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4u^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \eta} = \frac{2I}{H_k\pi}\left(\frac{1}{1+4u^2}-\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial H_k} = -\frac{2I}{\pi}\left(\eta\,\frac{H_k^2-4(\theta-\Theta)^2}{\{H_k^2+4(\theta-\Theta)^2\}^2}+(1-\eta)\frac{\sqrt{\pi\ln 2}}{H_k^2}\,e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \theta} = \frac{16(\theta-\Theta)I}{H_k^3\pi}\left(\eta\,\frac{1}{(1+4u^2)^2}+(1-\eta)\ln 2\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)+B_2$$

    $$\frac{\partial F}{\partial B_1} = 1,\qquad \frac{\partial F}{\partial B_2} = \theta-\Theta$$

??? note "Pearson VII の偏微分"

    積分強度や背景に対する単純な偏微分（\( \partial F/\partial I,\ \partial F/\partial B_1,\ \partial F/\partial B_2 \)）は省略します。原典では Pearson 関数の指数部を \( R \) と \( m \) の双方で表記しています（同一量）。\( u = \dfrac{\theta-\Theta}{H_k} \) とおくと、

    $$\frac{\partial F}{\partial \Theta} = \frac{8mI(\theta-\Theta)}{H_k^2}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial H_k} = \frac{8mI(\theta-\Theta)^2}{H_k^3}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial m} = \left(1+4(2^{1/R}-1)u^2\right)^{-R}\left(\frac{4\cdot 2^{1/R}(\theta-\Theta)^2\ln 2}{m\left(H_k^2+4(2^{1/R}-1)(\theta-\Theta)^2\right)} - \ln\!\left(1+4(2^{1/R}-1)u^2\right)\right)$$

---

## 3 次スプライン関数の導出 {#cubic-spline}

PDIndexer は、バックグラウンド曲線を引くために 3 次スプライン曲線を利用しています。本当のバックグラウンドの形は厳密には解けませんが、ピークでない部分を自動で検出し、検出した点をスプラインで結んでバックグラウンド曲線とします。スプラインは、その導関数も含めて一様に近似し、データ点を密にすれば近似は上がることが知られています。

\( n \) 個の点 \( (X_1,Y_1), (X_2,Y_2), \dots, (X_{n-1},Y_{n-1}), (X_n,Y_n) \) が与えられたとき、区間ごとに 3 次関数で表し、各点で値・傾き・曲率が等しくなめらかにつながる曲線を求めます（両端の区間 \( \{-\infty, X_1\} \) と \( \{X_n, \infty\} \) は 1 次関数とします）。

区間 \( \{X_{m-1}, X_m\} \) の関数を

$$F_m = a_m X^3 + b_m X^2 + c_m X + d_m$$

とします。

**内部の点（\( 2 \le m \le n-1 \)）** では、値・1 階微分・2 階微分の連続性から

$$F_m(X_m) = a_m X_m^3 + b_m X_m^2 + c_m X_m + d_m = Y_m$$

$$F_{m+1}(X_m) = a_{m+1} X_m^3 + b_{m+1} X_m^2 + c_{m+1} X_m + d_{m+1} = Y_m$$

$$F_m'(X_m) = 3a_m X_m^2 + 2b_m X_m + c_m = F_{m+1}'(X_m) = 3a_{m+1} X_m^2 + 2b_{m+1} X_m + c_{m+1}$$

$$F_m''(X_m) = 6a_m X_m + 2b_m = F_{m+1}''(X_m) = 6a_{m+1} X_m + 2b_{m+1}$$

の **\( 4n-8 \) 個の条件** が得られます。

**始端（\( m=1 \)、左端の区間は 1 次関数）** では

$$F_1(X_1) = c_1 X_1 + d_1 = Y_1$$

$$F_2(X_1) = a_2 X_1^3 + b_2 X_1^2 + c_2 X_1 + d_2 = Y_1$$

$$F_1'(X_1) = c_1 = F_2'(X_1) = 3a_2 X_1^2 + 2b_2 X_1 + c_2$$

$$F_1''(X_1) = F_2''(X_1) = 6a_2 X_1 + 2b_2 = 0$$

の **4 個の条件**、**終端（\( m=n \)）** でも同様に

$$F_n(X_n) = a_n X_n^3 + b_n X_n^2 + c_n X_n + d_n = Y_n$$

$$F_{n+1}(X_n) = c_{n+1} X_n + d_{n+1} = Y_n$$

$$F_n'(X_n) = 3a_n X_n^2 + 2b_n X_n + c_n = F_{n+1}'(X_n) = c_{n+1}$$

$$F_n''(X_n) = 6a_n X_n + 2b_n = F_{n+1}''(X_n) = 0$$

の **4 個の条件** が得られます。

結局、合計 \( 4n \) 個の条件を使って \( 4n \) 個の変数を求める連立方程式に帰結します。行列で書き下して逆行列問題にすれば、簡単に解くことができます。

---

## 関連ページ

- [6. 回折ピークのフィッティング](../6-fitting-diffraction-peaks.md) — 実際の操作方法
- [状態方程式](../5-equation-of-states.md) — Birch–Murnaghan 式・Mie–Grüneisen 式などの EOS 理論
