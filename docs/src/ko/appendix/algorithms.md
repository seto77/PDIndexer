<!-- 260625Cl: migrated from legacy doc/PDIndexerAlgorithm.pdf (former bundled PDF) -->
# 알고리즘 해설

이 페이지는 PDIndexer가 내부적으로 사용하는 주요 계산 알고리즘의 개요입니다. 예전에 배포판에 동봉되어 있던 해설 PDF(`PDIndexerAlgorithm.pdf`)의 내용을 이전·재구성한 것입니다. 수학적인 엄밀함보다는 *무엇을 최소화하고 어떻게 풀고 있는가* 라는 흐름을 전달하는 것을 목표로 합니다.

다루는 내용은 다음 3가지입니다.

1. [격자 상수의 정밀화](#lattice-refinement) — 선형 최소제곱법
2. [피크 피팅](#peak-fitting) — Marquardt법에 의한 비선형 최소제곱과 프로파일 함수
3. [3차 스플라인 함수의 도출](#cubic-spline) — 배경 곡선

상태 방정식(EOS) 이론에 대해서는 [상태 방정식](../5-equation-of-states.md)을 참조하십시오.

---

## 격자 상수의 정밀화 {#lattice-refinement}

### 일반화된 선형 최소제곱법

일반적으로 \( n \)개의 관측값 조 \( (X^1_1, X^2_1, \dots, X^m_1, Z_1),\ (X^1_2, X^2_2, \dots, X^m_2, Z_2),\ \dots,\ (X^1_n, X^2_n, \dots, X^m_n, Z_n) \)가 주어졌을 때, \( m \)개의 파라미터 \( (a^1, a^2, \dots, a^m) \)에 대한 선형 관측 방정식

$$Z = a^1 X^1 + a^2 X^2 + \dots + a^m X^m$$

에 피팅시키는 것은 잔차 제곱합을 최소화함으로써 이루어집니다. 행렬로 나타내면,

$$
\mathbf{a}=\begin{pmatrix}a^1\\ \vdots\\ a^m\end{pmatrix},\quad
X=\begin{pmatrix}X^1_1 & X^2_1 & \cdots & X^m_1\\ X^1_2 & X^2_2 & \cdots & X^m_2\\ \vdots & & & \vdots\\ X^1_n & X^2_n & \cdots & X^m_n\end{pmatrix},\quad
Y=\begin{pmatrix}Y_1\\ \vdots\\ Y_n\end{pmatrix},\quad
W=\begin{pmatrix}W_1 & 0 & \cdots & 0\\ 0 & W_2 & & \\ \vdots & & \ddots & \\ 0 & & & W_n\end{pmatrix}
$$

여기서 \( W \)는 가중치를 대각 성분으로 갖는 대각 행렬입니다. 가중 제곱합

$$\Delta^2 = (X\mathbf{a}-Y)^{\mathsf{T}}\,W\,(X\mathbf{a}-Y)$$

을 최소화하기 위해 \( \mathbf{a} \)에 대한 미분을 0으로 놓으면,

$$\delta\Delta^2 = 2\,\delta\mathbf{a}^{\mathsf{T}}\left(X^{\mathsf{T}}W X\,\mathbf{a} - X^{\mathsf{T}}W Y\right) = 0,$$

다음과 같은 해를 얻습니다.

$$\mathbf{a} = (X^{\mathsf{T}}W X)^{-1}\,X^{\mathsf{T}}W Y.$$

### 역격자 계량 텐서에 대한 적용

격자 상수의 정밀화에서는 관측 방정식이 결정계에 따라 달라지지만, 가장 일반적인(삼사정계) 경우에서 면간거리(d값) \( d \)와 지수 \( (h,k,l) \)의 관계

$$\left(\frac{1}{d}\right)^2 = h^2 a^{*2} + k^2 b^{*2} + l^2 c^{*2} + 2kl\,b^*c^*\cos\alpha^* + 2lh\,c^*a^*\cos\beta^* + 2hk\,a^*b^*\cos\gamma^*,$$

는 선형 모델로 다룰 수 있습니다.

$$
\mathbf{a}=\begin{pmatrix}a^*a^*\\ b^*b^*\\ c^*c^*\\ 2b^*c^*\cos\alpha^*\\ 2c^*a^*\cos\beta^*\\ 2a^*b^*\cos\gamma^*\end{pmatrix},\quad
X=\begin{pmatrix}h_1h_1 & k_1k_1 & l_1l_1 & k_1l_1 & l_1h_1 & h_1k_1\\ \vdots & & & & & \vdots\\ h_nh_n & k_nk_n & l_nl_n & k_nl_n & l_nh_n & h_nk_n\end{pmatrix},\quad
Y=\begin{pmatrix}(1/d_1)^2\\ \vdots\\ (1/d_n)^2\end{pmatrix}
$$

여기서 \( a^*, b^*, \dots \)는 역격자 상수입니다. 이를 앞서 설명한 선형 최소제곱법으로 풀면 역격자 계량 텐서의 성분을 구할 수 있으며, 여기서부터 격자 상수를 얻을 수 있습니다.

### 가중치의 선택

가중치는 오차에 따라 달라집니다. 오차가 회절각 \( 2\theta \)에만 있다고 가정하면, \( G = (1/d)^2 = 4\sin^2\theta/\lambda^2 \)의 \( \theta \)에 대한 응답은

$$\frac{\partial G}{\partial\theta} = \frac{4\sin(2\theta)}{\lambda^2},$$

이므로, 변화 \( \delta\theta \)는 \( (1/d)^2 \)를 \( \dfrac{4\sin(2\theta)}{\lambda^2}\delta\theta \)만큼 변화시킵니다. 따라서 \( 1/\sin^2(2\theta) \)(오차 제곱의 역수)가 \( (1/d)^2 \)에 대한 적절한 가중치가 됩니다.

$$
W=\begin{pmatrix}
1/\sin^2(2\theta_1) & 0 & \cdots & 0\\
0 & 1/\sin^2(2\theta_2) & & \\
\vdots & & \ddots & \\
0 & & & 1/\sin^2(2\theta_n)
\end{pmatrix}.
$$

여기서 \( 1/\sin^2(2\theta) \)는 각 점의 분산의 역수의 *절댓값이 아니라 비율*만을 나타내지만, 그럼에도 최적해는 여전히 구할 수 있습니다. \( (X^{\mathsf{T}}W X)^{-1} X^{\mathsf{T}}W Y \)에서 \( W \)가 두 번 나타나므로, 절대 스케일은 상쇄되기 때문입니다.

### 파라미터의 오차

\( \mathbf{a} \)의 오차(분산)는 \( (X^{\mathsf{T}}W X)^{-1} \)의 대각 성분에서 얻어지지만, \( W \)는 비율까지만 정해져 있었으므로 절대 스케일은 별도로 구해야 합니다. 분산의 정의

$$N - P = \sum_{i=1}^{n}\frac{\delta_i^2}{s_i}$$

(\( N \): 데이터 개수, \( P \): 파라미터 개수, \( \delta_i \): \( i \)번째 데이터의 잔차, \( s_i \): \( i \)번째 데이터의 분산)를 사용하면, 얻어진 파라미터로부터 분산의 스케일이

$$s = \frac{\sum_{i=1}^{n}(\delta_i^2 w_i)}{N - P},$$

로 정해지고, 그 제곱근이 오차가 됩니다. 이는 역격자 상수의 오차이므로, 격자 상수의 오차로 변환하려면 오차를 추가로 전파시켜야 하는데, 원리적으로는 어렵지 않습니다.

---

## 피크 피팅 {#peak-fitting}

### Marquardt법

PDIndexer는 뉴턴법과 유사한 **Marquardt법**(Levenberg–Marquardt법)으로 피크를 비선형 피팅합니다. 빠른 수렴 속도와 안정성을 겸비하고 있어 충분한 정확도로 최적값을 구할 수 있습니다.

피팅 함수를 \( F = F(a_1, a_2, \dots, a_m, X) \)라 하고, 초기 파라미터 \( \mathbf{a}^0 \)에서의 잔차를

$$R = \sum_{i=1}^{n}\left[Y_i - F(\mathbf{a}^0, X_i)\right]^2.$$

라 합니다. 다음과 같이 \( m\times m \) 행렬 \( \alpha \)와 \( m \)차원 벡터 \( \beta \)를 구성합니다. 대각 성분에만 \( (1+\lambda) \)를 곱하는 것이 Marquardt법의 핵심 아이디어이며, \( \lambda \)가 안정성과 수렴 속도를 제어합니다.

$$\alpha_{jk} = \sum_{i=1}^{n} w_i\,\frac{\partial F}{\partial a_j}\frac{\partial F}{\partial a_k}\quad(j\neq k),\qquad
\alpha_{jj} = (1+\lambda)\sum_{i=1}^{n} w_i\left(\frac{\partial F}{\partial a_j}\right)^2,$$

$$\beta_j = \sum_{i=1}^{n} w_i\left[Y_i - F(\mathbf{a}^0, X_i)\right]\frac{\partial F}{\partial a_j}.$$

파라미터는 다음과 같이 갱신됩니다.

$$\mathbf{a}' = \mathbf{a}^0 + \alpha^{-1}\boldsymbol{\beta}.$$

새로운 잔차 \( R' \)을 계산하여,

- \( R' < R \)이면 갱신을 채택하고 \( \lambda \)를 (0.1~0.5배로) 줄인다.
- \( R' > R \)이면 갱신을 기각하고 \( \lambda \)를 (2~10배로) 늘린다.

이를 \( R \)의 변화가 충분히 작아질 때까지 반복합니다. \( \lambda \to 0 \)이 되면 2차 수렴하는 가우스-뉴턴법에 가까워지고, \( \lambda \)가 클 때는 잔차의 기울기 \( \nabla R \)을 따라가는 최급강하법에 가까워집니다. 이 둘을 \( \lambda \)에 의해 연속적으로 전환함으로써 안정적이고 빠른 수렴을 얻습니다.

### 프로파일 함수

PDIndexer는 가우스 함수와 로렌츠 함수의 혼합인 **Pseudo Voigt 함수**, 확률 밀도 함수의 하나인 **Pearson VII 함수**, 그리고 이들을 비대칭으로 확장한 **Split Pseudo Voigt** / **Split Pearson VII**를 제공합니다. 계산 속도와 수렴 안정성 면에서 Symmetric Pseudo Voigt가 기본값입니다. 모든 함수는 적분값이 1이 되도록 정규화되어 있습니다.

**Symmetric Pseudo Voigt**

$$f(x,\eta,H_k)=\frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4\left(\dfrac{x}{H_k}\right)^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot 2^{-4\left(\frac{x}{H_k}\right)^2}\right)$$

**Split Pseudo Voigt(Toraya 1990, 수정판)**

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_h-\eta_l)(Z-1)}{(1+e^{A})(\eta_h+Z(1-\eta_h))}}\left(\eta_l\,\frac{1}{1+(1+e^{-A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_l)Z\cdot 2^{-4(1+e^{-A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x<0)$$

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_l-\eta_h)(Z-1)}{(1+e^{-A})(\eta_h+Z(1-\eta_h))}}\left(\eta_h\,\frac{1}{1+(1+e^{A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_h)Z\cdot 2^{-4(1+e^{A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x>0)$$

**Symmetric Pearson VII**

$$f(x,R,H_k)=\frac{2\sqrt{2^{1/R}-1}\,\Gamma(R)}{\sqrt{\pi}\,\Gamma(R-1/2)\,H_k}\left(1+4(2^{1/R}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R}$$

**Split Pearson VII(Toraya 1990, 수정판)**

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{-A})^2(2^{1/R_l}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_l}\quad(x<0)$$

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{A})^2(2^{1/R_h}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_h}\quad(x>0)$$

앞의 두 함수는 \( x=0 \)에 대해 대칭이지만, Split 형태는 \( x \)의 부호에 따라 형태가 달라져 비대칭성(저각측 꼬리 등)을 표현합니다. 일반적으로 Pearson VII가 더 좋은 피팅(작은 잔차)을 주는 경향이 있고, Pseudo Voigt는 더 안정적으로 수렴하는 경향이 있습니다.

#### 기호

| 기호 | 의미 |
| --- | --- |
| \( H_k \) | 반치전폭(FWHM) |
| \( \pi \) | 원주율 |
| \( \eta \) (\( \eta_l, \eta_h \)) | 로렌츠/가우스 혼합비 (Split 형태에서는 저각측/고각측) |
| \( \Gamma \) | 감마 함수 |
| \( R \) (\( R_l, R_h \)) | Pearson 지수 |
| \( A \) | 비대칭 파라미터 |
| \( Z \) | 정규화 상수 (\( \sqrt{\pi\ln 2} \)) |

### 배경을 포함한 피팅 함수

실제로는 프로파일 함수 \( f \)에 선형 배경을 더하여 확장합니다.

$$F(\theta,\Theta,B_1,B_2) = I\cdot f(\theta-\Theta) + B_1 + B_2(\theta-\Theta)$$

(\( I \): 적분 강도, \( B_1, B_2 \): 선형 배경, \( \Theta \): 피크 중심, \( \theta \): 관측 위치). 주어진 범위 내에서, \( R = \sum (Y - F)^2 \)이 최소가 되도록 Marquardt법으로 파라미터를 변화시킵니다.

각 함수의 편미분은 복잡하지만, Marquardt법은 이러한 해석적 기울기를 사용합니다. 참고를 위해 대표적인 식을 아래에 제시합니다.

??? note "Symmetric Pseudo Voigt의 편미분"

    \( u = \dfrac{\theta-\Theta}{H_k} \)로 놓으면,

    $$\frac{\partial F}{\partial I} = \frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4u^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \eta} = \frac{2I}{H_k\pi}\left(\frac{1}{1+4u^2}-\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial H_k} = -\frac{2I}{\pi}\left(\eta\,\frac{H_k^2-4(\theta-\Theta)^2}{\{H_k^2+4(\theta-\Theta)^2\}^2}+(1-\eta)\frac{\sqrt{\pi\ln 2}}{H_k^2}\,e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \theta} = \frac{16(\theta-\Theta)I}{H_k^3\pi}\left(\eta\,\frac{1}{(1+4u^2)^2}+(1-\eta)\ln 2\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)+B_2$$

    $$\frac{\partial F}{\partial B_1} = 1,\qquad \frac{\partial F}{\partial B_2} = \theta-\Theta$$

??? note "Pearson VII의 편미분"

    강도와 배경에 대한 단순한 편미분(\( \partial F/\partial I,\ \partial F/\partial B_1,\ \partial F/\partial B_2 \))은 생략합니다. 원 문서에서는 Pearson 지수를 \( R \)과 \( m \) 양쪽으로 표기하고 있습니다(같은 양입니다). \( u = \dfrac{\theta-\Theta}{H_k} \)로 놓으면,

    $$\frac{\partial F}{\partial \Theta} = \frac{8mI(\theta-\Theta)}{H_k^2}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial H_k} = \frac{8mI(\theta-\Theta)^2}{H_k^3}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial m} = \left(1+4(2^{1/R}-1)u^2\right)^{-R}\left(\frac{4\cdot 2^{1/R}(\theta-\Theta)^2\ln 2}{m\left(H_k^2+4(2^{1/R}-1)(\theta-\Theta)^2\right)} - \ln\!\left(1+4(2^{1/R}-1)u^2\right)\right)$$

---

## 3차 스플라인 함수의 도출 {#cubic-spline}

PDIndexer는 배경을 그리기 위해 3차 스플라인 곡선을 사용합니다. 실제 배경의 형태는 엄밀하게 풀 수 없지만, 소프트웨어가 피크가 아닌 영역을 자동으로 검출하고, 검출한 점들을 스플라인으로 연결하여 배경 곡선을 만듭니다. 스플라인은 도함수까지 포함하여 데이터를 균일하게 근사하며, 데이터 점을 촘촘하게 할수록 근사가 향상됩니다.

\( n \)개의 점 \( (X_1,Y_1), (X_2,Y_2), \dots, (X_{n-1},Y_{n-1}), (X_n,Y_n) \)가 주어졌을 때, 각 구간에서 3차 함수로 표현되고, 모든 점에서 값·기울기·곡률이 일치하도록 매끄럽게 이어지는 곡선을 구합니다(양 끝 구간 \( \{-\infty, X_1\} \)와 \( \{X_n, \infty\} \)는 1차 함수로 취급합니다).

구간 \( \{X_{m-1}, X_m\} \)에서의 함수를

$$F_m = a_m X^3 + b_m X^2 + c_m X + d_m.$$

라 합니다.

**내부 점 (\( 2 \le m \le n-1 \)).** 값, 1계 도함수, 2계 도함수의 연속성으로부터

$$F_m(X_m) = a_m X_m^3 + b_m X_m^2 + c_m X_m + d_m = Y_m$$

$$F_{m+1}(X_m) = a_{m+1} X_m^3 + b_{m+1} X_m^2 + c_{m+1} X_m + d_{m+1} = Y_m$$

$$F_m'(X_m) = 3a_m X_m^2 + 2b_m X_m + c_m = F_{m+1}'(X_m) = 3a_{m+1} X_m^2 + 2b_{m+1} X_m + c_{m+1}$$

$$F_m''(X_m) = 6a_m X_m + 2b_m = F_{m+1}''(X_m) = 6a_{m+1} X_m + 2b_{m+1}$$

— 즉, **\( 4n-8 \)개의 조건**이 얻어집니다.

**시작점 (\( m=1 \), 왼쪽 끝 구간은 1차 함수):**

$$F_1(X_1) = c_1 X_1 + d_1 = Y_1$$

$$F_2(X_1) = a_2 X_1^3 + b_2 X_1^2 + c_2 X_1 + d_2 = Y_1$$

$$F_1'(X_1) = c_1 = F_2'(X_1) = 3a_2 X_1^2 + 2b_2 X_1 + c_2$$

$$F_1''(X_1) = F_2''(X_1) = 6a_2 X_1 + 2b_2 = 0$$

— **4개의 조건**. **끝점 (\( m=n \))**에서도 마찬가지로

$$F_n(X_n) = a_n X_n^3 + b_n X_n^2 + c_n X_n + d_n = Y_n$$

$$F_{n+1}(X_n) = c_{n+1} X_n + d_{n+1} = Y_n$$

$$F_n'(X_n) = 3a_n X_n^2 + 2b_n X_n + c_n = F_{n+1}'(X_n) = c_{n+1}$$

$$F_n''(X_n) = 6a_n X_n + 2b_n = F_{n+1}''(X_n) = 0$$

— 또 다른 **4개의 조건**이 얻어집니다.

결국, 합계 \( 4n \)개의 조건이 \( 4n \)개의 미지수를 결정하며, 문제는 연립방정식으로 귀결됩니다. 이를 행렬로 표현하여 역행렬을 구하면 쉽게 풀 수 있습니다.

---

## 관련 페이지

- [6. 회절 피크 피팅](../6-fitting-diffraction-peaks.md) — 실제 사용 방법
- [상태 방정식](../5-equation-of-states.md) — Birch–Murnaghan식, Mie–Grüneisen식 등의 EOS 이론
