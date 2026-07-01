<!-- 260625Cl: migrated from legacy doc/PDIndexerAlgorithm.pdf (former bundled PDF) -->
# Algorithms

This page outlines the main numerical algorithms used internally by PDIndexer. It is a migrated and reorganized version of the explanatory PDF (`PDIndexerAlgorithm.pdf`) that used to be bundled with the distribution. The goal is to convey *what is minimized and how it is solved* rather than full mathematical rigor.

Three topics are covered:

1. [Lattice-constant refinement](#lattice-refinement) — linear least squares
2. [Peak fitting](#peak-fitting) — nonlinear least squares by the Marquardt method, and the profile functions
3. [Cubic spline derivation](#cubic-spline) — background curve

For the theory of equations of state (EOS), see [Equation of States](../5-equation-of-states.md).

---

## Lattice-constant refinement {#lattice-refinement}

### Generalized linear least squares

Given \( n \) sets of observations \( (X^1_1, X^2_1, \dots, X^m_1, Z_1),\ (X^1_2, X^2_2, \dots, X^m_2, Z_2),\ \dots,\ (X^1_n, X^2_n, \dots, X^m_n, Z_n) \), fitting the linear observation equation

$$Z = a^1 X^1 + a^2 X^2 + \dots + a^m X^m$$

over the \( m \) parameters \( (a^1, a^2, \dots, a^m) \) is achieved by minimizing the sum of squared residuals. In matrix form,

$$
\mathbf{a}=\begin{pmatrix}a^1\\ \vdots\\ a^m\end{pmatrix},\quad
X=\begin{pmatrix}X^1_1 & X^2_1 & \cdots & X^m_1\\ X^1_2 & X^2_2 & \cdots & X^m_2\\ \vdots & & & \vdots\\ X^1_n & X^2_n & \cdots & X^m_n\end{pmatrix},\quad
Y=\begin{pmatrix}Y_1\\ \vdots\\ Y_n\end{pmatrix},\quad
W=\begin{pmatrix}W_1 & 0 & \cdots & 0\\ 0 & W_2 & & \\ \vdots & & \ddots & \\ 0 & & & W_n\end{pmatrix}
$$

where \( W \) is a diagonal matrix of weights. Minimizing the weighted sum of squares

$$\Delta^2 = (X\mathbf{a}-Y)^{\mathsf{T}}\,W\,(X\mathbf{a}-Y)$$

by setting its derivative with respect to \( \mathbf{a} \) to zero,

$$\delta\Delta^2 = 2\,\delta\mathbf{a}^{\mathsf{T}}\left(X^{\mathsf{T}}W X\,\mathbf{a} - X^{\mathsf{T}}W Y\right) = 0,$$

gives the solution

$$\mathbf{a} = (X^{\mathsf{T}}W X)^{-1}\,X^{\mathsf{T}}W Y.$$

### Fitting the reciprocal metric tensor

For lattice-constant refinement the observation equation depends on the crystal system, but in the most general (triclinic) case the relation between the interplanar spacing \( d \) and the indices \( (h,k,l) \),

$$\left(\frac{1}{d}\right)^2 = h^2 a^{*2} + k^2 b^{*2} + l^2 c^{*2} + 2kl\,b^*c^*\cos\alpha^* + 2lh\,c^*a^*\cos\beta^* + 2hk\,a^*b^*\cos\gamma^*,$$

is treated as a linear model:

$$
\mathbf{a}=\begin{pmatrix}a^*a^*\\ b^*b^*\\ c^*c^*\\ 2b^*c^*\cos\alpha^*\\ 2c^*a^*\cos\beta^*\\ 2a^*b^*\cos\gamma^*\end{pmatrix},\quad
X=\begin{pmatrix}h_1h_1 & k_1k_1 & l_1l_1 & k_1l_1 & l_1h_1 & h_1k_1\\ \vdots & & & & & \vdots\\ h_nh_n & k_nk_n & l_nl_n & k_nl_n & l_nh_n & h_nk_n\end{pmatrix},\quad
Y=\begin{pmatrix}(1/d_1)^2\\ \vdots\\ (1/d_n)^2\end{pmatrix}
$$

where \( a^*, b^*, \dots \) are the reciprocal lattice constants. Solving this with the linear least squares above yields the components of the reciprocal metric tensor, from which the lattice constants follow.

### Choice of weights

The weight depends on the error. Assuming the error lies only in the diffraction angle \( 2\theta \), the response of \( G = (1/d)^2 = 4\sin^2\theta/\lambda^2 \) to \( \theta \) is

$$\frac{\partial G}{\partial\theta} = \frac{4\sin(2\theta)}{\lambda^2},$$

so a change \( \delta\theta \) shifts \( (1/d)^2 \) by \( \dfrac{4\sin(2\theta)}{\lambda^2}\delta\theta \). Therefore \( 1/\sin^2(2\theta) \) (the inverse of the squared error) is an appropriate weight for \( (1/d)^2 \):

$$
W=\begin{pmatrix}
1/\sin^2(2\theta_1) & 0 & \cdots & 0\\
0 & 1/\sin^2(2\theta_2) & & \\
\vdots & & \ddots & \\
0 & & & 1/\sin^2(2\theta_n)
\end{pmatrix}.
$$

Here \( 1/\sin^2(2\theta) \) represents only the *ratio* of the inverse variances of the points, not their absolute value, yet the optimum is still recovered: in \( (X^{\mathsf{T}}W X)^{-1} X^{\mathsf{T}}W Y \) the factor \( W \) appears twice, so the absolute scale cancels out.

### Parameter errors

The errors (variances) of \( \mathbf{a} \) come from the diagonal of \( (X^{\mathsf{T}}W X)^{-1} \), but since \( W \) was fixed only up to a ratio, the absolute scale must be determined separately. Using the definition of variance,

$$N - P = \sum_{i=1}^{n}\frac{\delta_i^2}{s_i}$$

(\( N \): number of data, \( P \): number of parameters, \( \delta_i \): residual of the \( i \)-th datum, \( s_i \): variance of the \( i \)-th datum), the variance scale is fixed from the obtained parameters as

$$s = \frac{\sum_{i=1}^{n}(\delta_i^2 w_i)}{N - P},$$

and its square root is the error. This is the error of the reciprocal lattice constants; converting it to the error of the lattice constants requires propagating the error further, which is straightforward in principle.

---

## Peak fitting {#peak-fitting}

### Marquardt method

PDIndexer fits peaks with the **Marquardt method** (Levenberg–Marquardt), a nonlinear iterative scheme similar to Newton's method. It combines fast convergence with stability and finds the optimum with sufficient accuracy.

Let the fitting function be \( F = F(a_1, a_2, \dots, a_m, X) \) and the residual at the initial parameters \( \mathbf{a}^0 \) be

$$R = \sum_{i=1}^{n}\left[Y_i - F(\mathbf{a}^0, X_i)\right]^2.$$

Build the \( m\times m \) matrix \( \alpha \) and the \( m \)-vector \( \beta \) as follows. Multiplying only the diagonal by \( (1+\lambda) \) is the key idea of the Marquardt method, with \( \lambda \) controlling stability and convergence speed:

$$\alpha_{jk} = \sum_{i=1}^{n} w_i\,\frac{\partial F}{\partial a_j}\frac{\partial F}{\partial a_k}\quad(j\neq k),\qquad
\alpha_{jj} = (1+\lambda)\sum_{i=1}^{n} w_i\left(\frac{\partial F}{\partial a_j}\right)^2,$$

$$\beta_j = \sum_{i=1}^{n} w_i\left[Y_i - F(\mathbf{a}^0, X_i)\right]\frac{\partial F}{\partial a_j}.$$

The parameters are updated by

$$\mathbf{a}' = \mathbf{a}^0 + \alpha^{-1}\boldsymbol{\beta}.$$

Compute the new residual \( R' \) and:

- if \( R' < R \), accept the update and shrink \( \lambda \) (by a factor of 0.1–0.5);
- if \( R' > R \), reject the update and grow \( \lambda \) (by a factor of 2–10).

Repeat until the change in \( R \) is sufficiently small. As \( \lambda \to 0 \) the method approaches the quadratically convergent Gauss–Newton method; for large \( \lambda \) it approaches steepest descent along the residual gradient \( \nabla R \). Switching continuously between the two via \( \lambda \) yields stable, fast convergence.

### Profile functions

PDIndexer offers the **Pseudo Voigt function** (a mixture of Gaussian and Lorentzian), the **Pearson VII function** (a probability density function), and their asymmetric extensions **Split Pseudo Voigt** / **Split Pearson VII**. For speed and convergence stability, Symmetric Pseudo Voigt is the default. All functions are normalized to unit area.

**Symmetric Pseudo Voigt**

$$f(x,\eta,H_k)=\frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4\left(\dfrac{x}{H_k}\right)^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot 2^{-4\left(\frac{x}{H_k}\right)^2}\right)$$

**Split Pseudo Voigt (Toraya 1990, modified)**

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_h-\eta_l)(Z-1)}{(1+e^{A})(\eta_h+Z(1-\eta_h))}}\left(\eta_l\,\frac{1}{1+(1+e^{-A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_l)Z\cdot 2^{-4(1+e^{-A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x<0)$$

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_l-\eta_h)(Z-1)}{(1+e^{-A})(\eta_h+Z(1-\eta_h))}}\left(\eta_h\,\frac{1}{1+(1+e^{A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_h)Z\cdot 2^{-4(1+e^{A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x>0)$$

**Symmetric Pearson VII**

$$f(x,R,H_k)=\frac{2\sqrt{2^{1/R}-1}\,\Gamma(R)}{\sqrt{\pi}\,\Gamma(R-1/2)\,H_k}\left(1+4(2^{1/R}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R}$$

**Split Pearson VII (Toraya 1990, modified)**

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{-A})^2(2^{1/R_l}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_l}\quad(x<0)$$

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{A})^2(2^{1/R_h}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_h}\quad(x>0)$$

The first two are symmetric about \( x=0 \), while the split forms change shape depending on the sign of \( x \) to express asymmetry (such as a low-angle tail). In general, Pearson VII tends to give the better fit (smaller residual), while Pseudo Voigt tends to converge more stably.

#### Symbols

| Symbol | Meaning |
| --- | --- |
| \( H_k \) | full width at half maximum (FWHM) |
| \( \pi \) | the circle constant |
| \( \eta \) (\( \eta_l, \eta_h \)) | Lorentzian/Gaussian mixing ratio (low-angle / high-angle side for split forms) |
| \( \Gamma \) | gamma function |
| \( R \) (\( R_l, R_h \)) | Pearson exponent |
| \( A \) | asymmetry parameter |
| \( Z \) | normalization constant (\( \sqrt{\pi\ln 2} \)) |

### Fitting function with background

In practice the profile function \( f \) is extended with a linear background:

$$F(\theta,\Theta,B_1,B_2) = I\cdot f(\theta-\Theta) + B_1 + B_2(\theta-\Theta)$$

(\( I \): integrated intensity, \( B_1, B_2 \): linear background, \( \Theta \): peak center, \( \theta \): observed position). Within a given range, the parameters are varied by the Marquardt method so that \( R = \sum (Y - F)^2 \) is minimized.

The partial derivatives of each function are complex; the Marquardt method uses these analytic gradients. Representative expressions are given below for reference.

??? note "Partial derivatives of Symmetric Pseudo Voigt"

    Writing \( u = \dfrac{\theta-\Theta}{H_k} \),

    $$\frac{\partial F}{\partial I} = \frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4u^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \eta} = \frac{2I}{H_k\pi}\left(\frac{1}{1+4u^2}-\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial H_k} = -\frac{2I}{\pi}\left(\eta\,\frac{H_k^2-4(\theta-\Theta)^2}{\{H_k^2+4(\theta-\Theta)^2\}^2}+(1-\eta)\frac{\sqrt{\pi\ln 2}}{H_k^2}\,e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \theta} = \frac{16(\theta-\Theta)I}{H_k^3\pi}\left(\eta\,\frac{1}{(1+4u^2)^2}+(1-\eta)\ln 2\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)+B_2$$

    $$\frac{\partial F}{\partial B_1} = 1,\qquad \frac{\partial F}{\partial B_2} = \theta-\Theta$$

??? note "Partial derivatives of Pearson VII"

    The simple derivatives with respect to intensity and background (\( \partial F/\partial I,\ \partial F/\partial B_1,\ \partial F/\partial B_2 \)) are omitted. The original document denotes the Pearson exponent by both \( R \) and \( m \) (the same quantity). Writing \( u = \dfrac{\theta-\Theta}{H_k} \),

    $$\frac{\partial F}{\partial \Theta} = \frac{8mI(\theta-\Theta)}{H_k^2}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial H_k} = \frac{8mI(\theta-\Theta)^2}{H_k^3}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial m} = \left(1+4(2^{1/R}-1)u^2\right)^{-R}\left(\frac{4\cdot 2^{1/R}(\theta-\Theta)^2\ln 2}{m\left(H_k^2+4(2^{1/R}-1)(\theta-\Theta)^2\right)} - \ln\!\left(1+4(2^{1/R}-1)u^2\right)\right)$$

---

## Cubic spline derivation {#cubic-spline}

PDIndexer uses a cubic spline curve to draw the background. The true background shape cannot be solved exactly, but the software automatically detects the non-peak regions and connects the detected points with a spline to form the background curve. A spline approximates the data uniformly, including its derivatives, and the approximation improves as the data points are made denser.

Given \( n \) points \( (X_1,Y_1), (X_2,Y_2), \dots, (X_{n-1},Y_{n-1}), (X_n,Y_n) \), we seek a curve that is cubic on each interval and joins smoothly so that value, slope, and curvature match at every point (the two end intervals \( \{-\infty, X_1\} \) and \( \{X_n, \infty\} \) are taken to be linear).

Let the function on interval \( \{X_{m-1}, X_m\} \) be

$$F_m = a_m X^3 + b_m X^2 + c_m X + d_m.$$

**Interior points (\( 2 \le m \le n-1 \)).** Continuity of value, first derivative, and second derivative gives

$$F_m(X_m) = a_m X_m^3 + b_m X_m^2 + c_m X_m + d_m = Y_m$$

$$F_{m+1}(X_m) = a_{m+1} X_m^3 + b_{m+1} X_m^2 + c_{m+1} X_m + d_{m+1} = Y_m$$

$$F_m'(X_m) = 3a_m X_m^2 + 2b_m X_m + c_m = F_{m+1}'(X_m) = 3a_{m+1} X_m^2 + 2b_{m+1} X_m + c_{m+1}$$

$$F_m''(X_m) = 6a_m X_m + 2b_m = F_{m+1}''(X_m) = 6a_{m+1} X_m + 2b_{m+1}$$

— that is, **\( 4n-8 \) conditions**.

**Start (\( m=1 \), left end interval is linear):**

$$F_1(X_1) = c_1 X_1 + d_1 = Y_1$$

$$F_2(X_1) = a_2 X_1^3 + b_2 X_1^2 + c_2 X_1 + d_2 = Y_1$$

$$F_1'(X_1) = c_1 = F_2'(X_1) = 3a_2 X_1^2 + 2b_2 X_1 + c_2$$

$$F_1''(X_1) = F_2''(X_1) = 6a_2 X_1 + 2b_2 = 0$$

— **4 conditions**. The **end (\( m=n \))** likewise gives

$$F_n(X_n) = a_n X_n^3 + b_n X_n^2 + c_n X_n + d_n = Y_n$$

$$F_{n+1}(X_n) = c_{n+1} X_n + d_{n+1} = Y_n$$

$$F_n'(X_n) = 3a_n X_n^2 + 2b_n X_n + c_n = F_{n+1}'(X_n) = c_{n+1}$$

$$F_n''(X_n) = 6a_n X_n + 2b_n = F_{n+1}''(X_n) = 0$$

— another **4 conditions**.

In total, \( 4n \) conditions determine \( 4n \) unknowns, reducing the problem to a system of simultaneous equations. Writing it out as a matrix and inverting solves it easily.

---

## Related pages

- [6. Fitting diffraction peaks](../6-fitting-diffraction-peaks.md) — how to use it in practice
- [Equation of States](../5-equation-of-states.md) — EOS theory such as the Birch–Murnaghan and Mie–Grüneisen equations
