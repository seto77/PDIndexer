<!-- 260625Cl: migrated from legacy doc/PDIndexerAlgorithm.pdf (former bundled PDF) -->
# Algoritmos

Esta página describe los principales algoritmos numéricos que PDIndexer utiliza internamente. Es una versión migrada y reorganizada del PDF explicativo (`PDIndexerAlgorithm.pdf`) que solía incluirse con la distribución. El objetivo es transmitir *qué se minimiza y cómo se resuelve* más que un rigor matemático completo.

Se cubren tres temas:

1. [Refinamiento del parámetro de red](#lattice-refinement) — mínimos cuadrados lineales
2. [Ajuste de picos](#peak-fitting) — mínimos cuadrados no lineales por el método de Marquardt, y las funciones de perfil
3. [Derivación del spline cúbico](#cubic-spline) — curva de fondo

Para la teoría de las ecuaciones de estado (EOS), véase [Ecuaciones de estado](../5-equation-of-states.md).

---

## Refinamiento del parámetro de red {#lattice-refinement}

### Mínimos cuadrados lineales generalizados

Dados \( n \) conjuntos de observaciones \( (X^1_1, X^2_1, \dots, X^m_1, Z_1),\ (X^1_2, X^2_2, \dots, X^m_2, Z_2),\ \dots,\ (X^1_n, X^2_n, \dots, X^m_n, Z_n) \), el ajuste de la ecuación de observación lineal

$$Z = a^1 X^1 + a^2 X^2 + \dots + a^m X^m$$

sobre los \( m \) parámetros \( (a^1, a^2, \dots, a^m) \) se consigue minimizando la suma de los cuadrados de los residuos. En forma matricial,

$$
\mathbf{a}=\begin{pmatrix}a^1\\ \vdots\\ a^m\end{pmatrix},\quad
X=\begin{pmatrix}X^1_1 & X^2_1 & \cdots & X^m_1\\ X^1_2 & X^2_2 & \cdots & X^m_2\\ \vdots & & & \vdots\\ X^1_n & X^2_n & \cdots & X^m_n\end{pmatrix},\quad
Y=\begin{pmatrix}Y_1\\ \vdots\\ Y_n\end{pmatrix},\quad
W=\begin{pmatrix}W_1 & 0 & \cdots & 0\\ 0 & W_2 & & \\ \vdots & & \ddots & \\ 0 & & & W_n\end{pmatrix}
$$

donde \( W \) es una matriz diagonal de pesos. Minimizando la suma ponderada de cuadrados

$$\Delta^2 = (X\mathbf{a}-Y)^{\mathsf{T}}\,W\,(X\mathbf{a}-Y)$$

igualando a cero su derivada respecto de \( \mathbf{a} \),

$$\delta\Delta^2 = 2\,\delta\mathbf{a}^{\mathsf{T}}\left(X^{\mathsf{T}}W X\,\mathbf{a} - X^{\mathsf{T}}W Y\right) = 0,$$

se obtiene la solución

$$\mathbf{a} = (X^{\mathsf{T}}W X)^{-1}\,X^{\mathsf{T}}W Y.$$

### Ajuste del tensor métrico recíproco

Para el refinamiento del parámetro de red la ecuación de observación depende del sistema cristalino, pero en el caso más general (triclínico) la relación entre el espaciado interplanar \( d \) y los índices \( (h,k,l) \),

$$\left(\frac{1}{d}\right)^2 = h^2 a^{*2} + k^2 b^{*2} + l^2 c^{*2} + 2kl\,b^*c^*\cos\alpha^* + 2lh\,c^*a^*\cos\beta^* + 2hk\,a^*b^*\cos\gamma^*,$$

se trata como un modelo lineal:

$$
\mathbf{a}=\begin{pmatrix}a^*a^*\\ b^*b^*\\ c^*c^*\\ 2b^*c^*\cos\alpha^*\\ 2c^*a^*\cos\beta^*\\ 2a^*b^*\cos\gamma^*\end{pmatrix},\quad
X=\begin{pmatrix}h_1h_1 & k_1k_1 & l_1l_1 & k_1l_1 & l_1h_1 & h_1k_1\\ \vdots & & & & & \vdots\\ h_nh_n & k_nk_n & l_nl_n & k_nl_n & l_nh_n & h_nk_n\end{pmatrix},\quad
Y=\begin{pmatrix}(1/d_1)^2\\ \vdots\\ (1/d_n)^2\end{pmatrix}
$$

donde \( a^*, b^*, \dots \) son los parámetros de red recíprocos. Resolviendo esto con los mínimos cuadrados lineales anteriores se obtienen las componentes del tensor métrico recíproco, de las cuales se derivan los parámetros de red.

### Elección de los pesos

El peso depende del error. Suponiendo que el error reside únicamente en el ángulo de difracción \( 2\theta \), la respuesta de \( G = (1/d)^2 = 4\sin^2\theta/\lambda^2 \) frente a \( \theta \) es

$$\frac{\partial G}{\partial\theta} = \frac{4\sin(2\theta)}{\lambda^2},$$

de modo que un cambio \( \delta\theta \) desplaza \( (1/d)^2 \) en \( \dfrac{4\sin(2\theta)}{\lambda^2}\delta\theta \). Por lo tanto, \( 1/\sin^2(2\theta) \) (el inverso del error al cuadrado) es un peso apropiado para \( (1/d)^2 \):

$$
W=\begin{pmatrix}
1/\sin^2(2\theta_1) & 0 & \cdots & 0\\
0 & 1/\sin^2(2\theta_2) & & \\
\vdots & & \ddots & \\
0 & & & 1/\sin^2(2\theta_n)
\end{pmatrix}.
$$

Aquí \( 1/\sin^2(2\theta) \) representa solo la *proporción* de las inversas de las varianzas de los puntos, no su valor absoluto, y aun así se recupera el óptimo: en \( (X^{\mathsf{T}}W X)^{-1} X^{\mathsf{T}}W Y \) el factor \( W \) aparece dos veces, por lo que la escala absoluta se cancela.

### Errores de los parámetros

Los errores (varianzas) de \( \mathbf{a} \) provienen de la diagonal de \( (X^{\mathsf{T}}W X)^{-1} \), pero como \( W \) se fijó solo hasta una proporción, la escala absoluta debe determinarse por separado. Usando la definición de varianza,

$$N - P = \sum_{i=1}^{n}\frac{\delta_i^2}{s_i}$$

(\( N \): número de datos, \( P \): número de parámetros, \( \delta_i \): residuo del \( i \)-ésimo dato, \( s_i \): varianza del \( i \)-ésimo dato), la escala de la varianza se fija a partir de los parámetros obtenidos como

$$s = \frac{\sum_{i=1}^{n}(\delta_i^2 w_i)}{N - P},$$

y su raíz cuadrada es el error. Este es el error de los parámetros de red recíprocos; convertirlo en el error de los parámetros de red requiere propagar el error más allá, lo cual es sencillo en principio.

---

## Ajuste de picos {#peak-fitting}

### Método de Marquardt

PDIndexer ajusta los picos con el **método de Marquardt** (Levenberg–Marquardt), un esquema iterativo no lineal similar al método de Newton. Combina convergencia rápida con estabilidad y encuentra el óptimo con suficiente precisión.

Sea la función de ajuste \( F = F(a_1, a_2, \dots, a_m, X) \) y el residuo en los parámetros iniciales \( \mathbf{a}^0 \)

$$R = \sum_{i=1}^{n}\left[Y_i - F(\mathbf{a}^0, X_i)\right]^2.$$

Se construyen la matriz \( m\times m \) \( \alpha \) y el vector \( m \)-dimensional \( \beta \) como sigue. Multiplicar solo la diagonal por \( (1+\lambda) \) es la idea clave del método de Marquardt, con \( \lambda \) controlando la estabilidad y la velocidad de convergencia:

$$\alpha_{jk} = \sum_{i=1}^{n} w_i\,\frac{\partial F}{\partial a_j}\frac{\partial F}{\partial a_k}\quad(j\neq k),\qquad
\alpha_{jj} = (1+\lambda)\sum_{i=1}^{n} w_i\left(\frac{\partial F}{\partial a_j}\right)^2,$$

$$\beta_j = \sum_{i=1}^{n} w_i\left[Y_i - F(\mathbf{a}^0, X_i)\right]\frac{\partial F}{\partial a_j}.$$

Los parámetros se actualizan mediante

$$\mathbf{a}' = \mathbf{a}^0 + \alpha^{-1}\boldsymbol{\beta}.$$

Se calcula el nuevo residuo \( R' \) y:

- si \( R' < R \), se acepta la actualización y se reduce \( \lambda \) (por un factor de 0.1–0.5);
- si \( R' > R \), se rechaza la actualización y se aumenta \( \lambda \) (por un factor de 2–10).

Se repite hasta que el cambio en \( R \) sea suficientemente pequeño. Cuando \( \lambda \to 0 \) el método se aproxima al método de Gauss–Newton, de convergencia cuadrática; para \( \lambda \) grande se aproxima al descenso más pronunciado a lo largo del gradiente del residuo \( \nabla R \). Alternando continuamente entre ambos mediante \( \lambda \) se logra una convergencia estable y rápida.

### Funciones de perfil

PDIndexer ofrece la **función Pseudo Voigt** (una mezcla de gaussiana y lorentziana), la **función Pearson VII** (una función de densidad de probabilidad) y sus extensiones asimétricas **Split Pseudo Voigt** / **Split Pearson VII**. Por velocidad y estabilidad de convergencia, Symmetric Pseudo Voigt es la opción por defecto. Todas las funciones están normalizadas a área unidad.

**Symmetric Pseudo Voigt**

$$f(x,\eta,H_k)=\frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4\left(\dfrac{x}{H_k}\right)^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot 2^{-4\left(\frac{x}{H_k}\right)^2}\right)$$

**Split Pseudo Voigt (Toraya 1990, modificada)**

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_h-\eta_l)(Z-1)}{(1+e^{A})(\eta_h+Z(1-\eta_h))}}\left(\eta_l\,\frac{1}{1+(1+e^{-A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_l)Z\cdot 2^{-4(1+e^{-A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x<0)$$

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_l-\eta_h)(Z-1)}{(1+e^{-A})(\eta_h+Z(1-\eta_h))}}\left(\eta_h\,\frac{1}{1+(1+e^{A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_h)Z\cdot 2^{-4(1+e^{A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x>0)$$

**Symmetric Pearson VII**

$$f(x,R,H_k)=\frac{2\sqrt{2^{1/R}-1}\,\Gamma(R)}{\sqrt{\pi}\,\Gamma(R-1/2)\,H_k}\left(1+4(2^{1/R}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R}$$

**Split Pearson VII (Toraya 1990, modificada)**

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{-A})^2(2^{1/R_l}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_l}\quad(x<0)$$

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{A})^2(2^{1/R_h}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_h}\quad(x>0)$$

Las dos primeras son simétricas respecto de \( x=0 \), mientras que las formas split cambian de forma según el signo de \( x \) para expresar asimetría (como una cola hacia ángulos bajos). En general, Pearson VII tiende a dar el mejor ajuste (residuo menor), mientras que Pseudo Voigt tiende a converger de forma más estable.

#### Símbolos

| Símbolo | Significado |
| --- | --- |
| \( H_k \) | anchura total a media altura (FWHM) |
| \( \pi \) | la constante del círculo |
| \( \eta \) (\( \eta_l, \eta_h \)) | razón de mezcla lorentziana/gaussiana (lado de ángulo bajo / ángulo alto para las formas split) |
| \( \Gamma \) | función gamma |
| \( R \) (\( R_l, R_h \)) | exponente de Pearson |
| \( A \) | parámetro de asimetría |
| \( Z \) | constante de normalización (\( \sqrt{\pi\ln 2} \)) |

### Función de ajuste con fondo

En la práctica, la función de perfil \( f \) se extiende con un fondo lineal:

$$F(\theta,\Theta,B_1,B_2) = I\cdot f(\theta-\Theta) + B_1 + B_2(\theta-\Theta)$$

(\( I \): intensidad integrada, \( B_1, B_2 \): fondo lineal, \( \Theta \): centro del pico, \( \theta \): posición observada). Dentro de un rango dado, los parámetros se varían por el método de Marquardt de modo que \( R = \sum (Y - F)^2 \) se minimice.

Las derivadas parciales de cada función son complejas; el método de Marquardt utiliza estos gradientes analíticos. A continuación se dan expresiones representativas como referencia.

??? note "Derivadas parciales de Symmetric Pseudo Voigt"

    Escribiendo \( u = \dfrac{\theta-\Theta}{H_k} \),

    $$\frac{\partial F}{\partial I} = \frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4u^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \eta} = \frac{2I}{H_k\pi}\left(\frac{1}{1+4u^2}-\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial H_k} = -\frac{2I}{\pi}\left(\eta\,\frac{H_k^2-4(\theta-\Theta)^2}{\{H_k^2+4(\theta-\Theta)^2\}^2}+(1-\eta)\frac{\sqrt{\pi\ln 2}}{H_k^2}\,e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \theta} = \frac{16(\theta-\Theta)I}{H_k^3\pi}\left(\eta\,\frac{1}{(1+4u^2)^2}+(1-\eta)\ln 2\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)+B_2$$

    $$\frac{\partial F}{\partial B_1} = 1,\qquad \frac{\partial F}{\partial B_2} = \theta-\Theta$$

??? note "Derivadas parciales de Pearson VII"

    Se omiten las derivadas simples respecto de la intensidad y el fondo (\( \partial F/\partial I,\ \partial F/\partial B_1,\ \partial F/\partial B_2 \)). El documento original denota el exponente de Pearson tanto por \( R \) como por \( m \) (la misma magnitud). Escribiendo \( u = \dfrac{\theta-\Theta}{H_k} \),

    $$\frac{\partial F}{\partial \Theta} = \frac{8mI(\theta-\Theta)}{H_k^2}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial H_k} = \frac{8mI(\theta-\Theta)^2}{H_k^3}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial m} = \left(1+4(2^{1/R}-1)u^2\right)^{-R}\left(\frac{4\cdot 2^{1/R}(\theta-\Theta)^2\ln 2}{m\left(H_k^2+4(2^{1/R}-1)(\theta-\Theta)^2\right)} - \ln\!\left(1+4(2^{1/R}-1)u^2\right)\right)$$

---

## Derivación del spline cúbico {#cubic-spline}

PDIndexer usa una curva spline cúbica para trazar el fondo. La forma verdadera del fondo no puede resolverse de manera exacta, pero el software detecta automáticamente las regiones sin picos y conecta los puntos detectados con un spline para formar la curva de fondo. Un spline aproxima los datos de forma uniforme, incluidas sus derivadas, y la aproximación mejora a medida que los puntos de datos se hacen más densos.

Dados \( n \) puntos \( (X_1,Y_1), (X_2,Y_2), \dots, (X_{n-1},Y_{n-1}), (X_n,Y_n) \), se busca una curva que sea cúbica en cada intervalo y se una suavemente de modo que el valor, la pendiente y la curvatura coincidan en cada punto (los dos intervalos extremos \( \{-\infty, X_1\} \) y \( \{X_n, \infty\} \) se toman lineales).

Sea la función en el intervalo \( \{X_{m-1}, X_m\} \)

$$F_m = a_m X^3 + b_m X^2 + c_m X + d_m.$$

**Puntos interiores (\( 2 \le m \le n-1 \)).** La continuidad del valor, la primera derivada y la segunda derivada da

$$F_m(X_m) = a_m X_m^3 + b_m X_m^2 + c_m X_m + d_m = Y_m$$

$$F_{m+1}(X_m) = a_{m+1} X_m^3 + b_{m+1} X_m^2 + c_{m+1} X_m + d_{m+1} = Y_m$$

$$F_m'(X_m) = 3a_m X_m^2 + 2b_m X_m + c_m = F_{m+1}'(X_m) = 3a_{m+1} X_m^2 + 2b_{m+1} X_m + c_{m+1}$$

$$F_m''(X_m) = 6a_m X_m + 2b_m = F_{m+1}''(X_m) = 6a_{m+1} X_m + 2b_{m+1}$$

— es decir, **\( 4n-8 \) condiciones**.

**Inicio (\( m=1 \), el intervalo extremo izquierdo es lineal):**

$$F_1(X_1) = c_1 X_1 + d_1 = Y_1$$

$$F_2(X_1) = a_2 X_1^3 + b_2 X_1^2 + c_2 X_1 + d_2 = Y_1$$

$$F_1'(X_1) = c_1 = F_2'(X_1) = 3a_2 X_1^2 + 2b_2 X_1 + c_2$$

$$F_1''(X_1) = F_2''(X_1) = 6a_2 X_1 + 2b_2 = 0$$

— **4 condiciones**. El **final (\( m=n \))** da igualmente

$$F_n(X_n) = a_n X_n^3 + b_n X_n^2 + c_n X_n + d_n = Y_n$$

$$F_{n+1}(X_n) = c_{n+1} X_n + d_{n+1} = Y_n$$

$$F_n'(X_n) = 3a_n X_n^2 + 2b_n X_n + c_n = F_{n+1}'(X_n) = c_{n+1}$$

$$F_n''(X_n) = 6a_n X_n + 2b_n = F_{n+1}''(X_n) = 0$$

— otras **4 condiciones**.

En total, \( 4n \) condiciones determinan \( 4n \) incógnitas, reduciendo el problema a un sistema de ecuaciones simultáneas. Escribiéndolo como una matriz e invirtiéndola se resuelve fácilmente.

---

## Páginas relacionadas

- [6. Ajuste de picos de difracción](../6-fitting-diffraction-peaks.md) — cómo usarlo en la práctica
- [Ecuaciones de estado](../5-equation-of-states.md) — teoría de EOS como las ecuaciones de Birch–Murnaghan y Mie–Grüneisen
