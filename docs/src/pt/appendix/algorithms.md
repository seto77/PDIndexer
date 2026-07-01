<!-- 260625Cl: migrated from legacy doc/PDIndexerAlgorithm.pdf (former bundled PDF) -->
# Algoritmos

Esta página descreve os principais algoritmos numéricos usados internamente pelo PDIndexer. É uma versão migrada e reorganizada do PDF explicativo (`PDIndexerAlgorithm.pdf`) que costumava ser distribuído junto com o programa. O objetivo é transmitir *o que é minimizado e como é resolvido*, em vez de todo o rigor matemático.

Três tópicos são abordados:

1. [Refinamento do parâmetro de rede](#lattice-refinement) — mínimos quadrados lineares
2. [Ajuste de picos](#peak-fitting) — mínimos quadrados não lineares pelo método de Marquardt e as funções de perfil
3. [Derivação da spline cúbica](#cubic-spline) — curva de fundo

Para a teoria das equações de estado (EOS), consulte [Equações de estado](../5-equation-of-states.md).

---

## Refinamento do parâmetro de rede {#lattice-refinement}

### Mínimos quadrados lineares generalizados

Dados \( n \) conjuntos de observações \( (X^1_1, X^2_1, \dots, X^m_1, Z_1),\ (X^1_2, X^2_2, \dots, X^m_2, Z_2),\ \dots,\ (X^1_n, X^2_n, \dots, X^m_n, Z_n) \), o ajuste da equação de observação linear

$$Z = a^1 X^1 + a^2 X^2 + \dots + a^m X^m$$

sobre os \( m \) parâmetros \( (a^1, a^2, \dots, a^m) \) é obtido minimizando a soma dos quadrados dos resíduos. Em forma matricial,

$$
\mathbf{a}=\begin{pmatrix}a^1\\ \vdots\\ a^m\end{pmatrix},\quad
X=\begin{pmatrix}X^1_1 & X^2_1 & \cdots & X^m_1\\ X^1_2 & X^2_2 & \cdots & X^m_2\\ \vdots & & & \vdots\\ X^1_n & X^2_n & \cdots & X^m_n\end{pmatrix},\quad
Y=\begin{pmatrix}Y_1\\ \vdots\\ Y_n\end{pmatrix},\quad
W=\begin{pmatrix}W_1 & 0 & \cdots & 0\\ 0 & W_2 & & \\ \vdots & & \ddots & \\ 0 & & & W_n\end{pmatrix}
$$

onde \( W \) é uma matriz diagonal de pesos. Minimizar a soma ponderada dos quadrados

$$\Delta^2 = (X\mathbf{a}-Y)^{\mathsf{T}}\,W\,(X\mathbf{a}-Y)$$

igualando a zero sua derivada em relação a \( \mathbf{a} \),

$$\delta\Delta^2 = 2\,\delta\mathbf{a}^{\mathsf{T}}\left(X^{\mathsf{T}}W X\,\mathbf{a} - X^{\mathsf{T}}W Y\right) = 0,$$

fornece a solução

$$\mathbf{a} = (X^{\mathsf{T}}W X)^{-1}\,X^{\mathsf{T}}W Y.$$

### Ajuste do tensor métrico recíproco

No refinamento do parâmetro de rede, a equação de observação depende do sistema cristalino, mas no caso mais geral (triclínico) a relação entre o espaçamento interplanar \( d \) e os índices \( (h,k,l) \),

$$\left(\frac{1}{d}\right)^2 = h^2 a^{*2} + k^2 b^{*2} + l^2 c^{*2} + 2kl\,b^*c^*\cos\alpha^* + 2lh\,c^*a^*\cos\beta^* + 2hk\,a^*b^*\cos\gamma^*,$$

é tratada como um modelo linear:

$$
\mathbf{a}=\begin{pmatrix}a^*a^*\\ b^*b^*\\ c^*c^*\\ 2b^*c^*\cos\alpha^*\\ 2c^*a^*\cos\beta^*\\ 2a^*b^*\cos\gamma^*\end{pmatrix},\quad
X=\begin{pmatrix}h_1h_1 & k_1k_1 & l_1l_1 & k_1l_1 & l_1h_1 & h_1k_1\\ \vdots & & & & & \vdots\\ h_nh_n & k_nk_n & l_nl_n & k_nl_n & l_nh_n & h_nk_n\end{pmatrix},\quad
Y=\begin{pmatrix}(1/d_1)^2\\ \vdots\\ (1/d_n)^2\end{pmatrix}
$$

onde \( a^*, b^*, \dots \) são os parâmetros de rede recíprocos. Resolver isso com os mínimos quadrados lineares acima fornece as componentes do tensor métrico recíproco, a partir das quais os parâmetros de rede seguem.

### Escolha dos pesos

O peso depende do erro. Supondo que o erro esteja apenas no ângulo de difração \( 2\theta \), a resposta de \( G = (1/d)^2 = 4\sin^2\theta/\lambda^2 \) a \( \theta \) é

$$\frac{\partial G}{\partial\theta} = \frac{4\sin(2\theta)}{\lambda^2},$$

de modo que uma variação \( \delta\theta \) desloca \( (1/d)^2 \) em \( \dfrac{4\sin(2\theta)}{\lambda^2}\delta\theta \). Portanto \( 1/\sin^2(2\theta) \) (o inverso do erro ao quadrado) é um peso apropriado para \( (1/d)^2 \):

$$
W=\begin{pmatrix}
1/\sin^2(2\theta_1) & 0 & \cdots & 0\\
0 & 1/\sin^2(2\theta_2) & & \\
\vdots & & \ddots & \\
0 & & & 1/\sin^2(2\theta_n)
\end{pmatrix}.
$$

Aqui \( 1/\sin^2(2\theta) \) representa apenas a *razão* entre os inversos das variâncias dos pontos, não seu valor absoluto, e mesmo assim o ótimo é recuperado: em \( (X^{\mathsf{T}}W X)^{-1} X^{\mathsf{T}}W Y \) o fator \( W \) aparece duas vezes, de modo que a escala absoluta se cancela.

### Erros dos parâmetros

Os erros (variâncias) de \( \mathbf{a} \) vêm da diagonal de \( (X^{\mathsf{T}}W X)^{-1} \), mas como \( W \) foi fixado apenas até uma razão, a escala absoluta deve ser determinada separadamente. Usando a definição de variância,

$$N - P = \sum_{i=1}^{n}\frac{\delta_i^2}{s_i}$$

(\( N \): número de dados, \( P \): número de parâmetros, \( \delta_i \): resíduo do \( i \)-ésimo dado, \( s_i \): variância do \( i \)-ésimo dado), a escala da variância é fixada a partir dos parâmetros obtidos como

$$s = \frac{\sum_{i=1}^{n}(\delta_i^2 w_i)}{N - P},$$

e sua raiz quadrada é o erro. Este é o erro dos parâmetros de rede recíprocos; convertê-lo no erro dos parâmetros de rede requer propagar o erro adicionalmente, o que em princípio é simples.

---

## Ajuste de picos {#peak-fitting}

### Método de Marquardt

O PDIndexer ajusta os picos com o **método de Marquardt** (Levenberg–Marquardt), um esquema iterativo não linear semelhante ao método de Newton. Ele combina convergência rápida com estabilidade e encontra o ótimo com precisão suficiente.

Seja a função de ajuste \( F = F(a_1, a_2, \dots, a_m, X) \) e o resíduo nos parâmetros iniciais \( \mathbf{a}^0 \)

$$R = \sum_{i=1}^{n}\left[Y_i - F(\mathbf{a}^0, X_i)\right]^2.$$

Construa a matriz \( m\times m \) \( \alpha \) e o vetor \( m \)-dimensional \( \beta \) da seguinte forma. Multiplicar apenas a diagonal por \( (1+\lambda) \) é a ideia central do método de Marquardt, com \( \lambda \) controlando a estabilidade e a velocidade de convergência:

$$\alpha_{jk} = \sum_{i=1}^{n} w_i\,\frac{\partial F}{\partial a_j}\frac{\partial F}{\partial a_k}\quad(j\neq k),\qquad
\alpha_{jj} = (1+\lambda)\sum_{i=1}^{n} w_i\left(\frac{\partial F}{\partial a_j}\right)^2,$$

$$\beta_j = \sum_{i=1}^{n} w_i\left[Y_i - F(\mathbf{a}^0, X_i)\right]\frac{\partial F}{\partial a_j}.$$

Os parâmetros são atualizados por

$$\mathbf{a}' = \mathbf{a}^0 + \alpha^{-1}\boldsymbol{\beta}.$$

Calcule o novo resíduo \( R' \) e:

- se \( R' < R \), aceite a atualização e reduza \( \lambda \) (por um fator de 0,1–0,5);
- se \( R' > R \), rejeite a atualização e aumente \( \lambda \) (por um fator de 2–10).

Repita até que a variação de \( R \) seja suficientemente pequena. Quando \( \lambda \to 0 \) o método se aproxima do método de Gauss–Newton, com convergência quadrática; para \( \lambda \) grande ele se aproxima da descida mais íngreme ao longo do gradiente do resíduo \( \nabla R \). Alternar continuamente entre os dois via \( \lambda \) produz convergência estável e rápida.

### Funções de perfil

O PDIndexer oferece a **função Pseudo Voigt** (uma mistura de Gaussiana e Lorentziana), a **função Pearson VII** (uma função de densidade de probabilidade) e suas extensões assimétricas **Split Pseudo Voigt** / **Split Pearson VII**. Por velocidade e estabilidade de convergência, a Symmetric Pseudo Voigt é o padrão. Todas as funções são normalizadas para área unitária.

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

As duas primeiras são simétricas em torno de \( x=0 \), enquanto as formas split mudam de forma dependendo do sinal de \( x \) para expressar a assimetria (como uma cauda no lado de baixo ângulo). Em geral, a Pearson VII tende a dar o melhor ajuste (resíduo menor), enquanto a Pseudo Voigt tende a convergir de forma mais estável.

#### Símbolos

| Símbolo | Significado |
| --- | --- |
| \( H_k \) | largura total à meia altura (FWHM) |
| \( \pi \) | a constante do círculo |
| \( \eta \) (\( \eta_l, \eta_h \)) | razão de mistura Lorentziana/Gaussiana (lado de baixo ângulo / alto ângulo para as formas split) |
| \( \Gamma \) | função gama |
| \( R \) (\( R_l, R_h \)) | expoente de Pearson |
| \( A \) | parâmetro de assimetria |
| \( Z \) | constante de normalização (\( \sqrt{\pi\ln 2} \)) |

### Função de ajuste com fundo

Na prática, a função de perfil \( f \) é estendida com um fundo linear:

$$F(\theta,\Theta,B_1,B_2) = I\cdot f(\theta-\Theta) + B_1 + B_2(\theta-\Theta)$$

(\( I \): intensidade integrada, \( B_1, B_2 \): fundo linear, \( \Theta \): centro do pico, \( \theta \): posição observada). Dentro de um intervalo dado, os parâmetros são variados pelo método de Marquardt de modo que \( R = \sum (Y - F)^2 \) seja minimizado.

As derivadas parciais de cada função são complexas; o método de Marquardt usa esses gradientes analíticos. Expressões representativas são dadas a seguir para referência.

??? note "Derivadas parciais da Symmetric Pseudo Voigt"

    Escrevendo \( u = \dfrac{\theta-\Theta}{H_k} \),

    $$\frac{\partial F}{\partial I} = \frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4u^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \eta} = \frac{2I}{H_k\pi}\left(\frac{1}{1+4u^2}-\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial H_k} = -\frac{2I}{\pi}\left(\eta\,\frac{H_k^2-4(\theta-\Theta)^2}{\{H_k^2+4(\theta-\Theta)^2\}^2}+(1-\eta)\frac{\sqrt{\pi\ln 2}}{H_k^2}\,e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \theta} = \frac{16(\theta-\Theta)I}{H_k^3\pi}\left(\eta\,\frac{1}{(1+4u^2)^2}+(1-\eta)\ln 2\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)+B_2$$

    $$\frac{\partial F}{\partial B_1} = 1,\qquad \frac{\partial F}{\partial B_2} = \theta-\Theta$$

??? note "Derivadas parciais da Pearson VII"

    As derivadas simples em relação à intensidade e ao fundo (\( \partial F/\partial I,\ \partial F/\partial B_1,\ \partial F/\partial B_2 \)) são omitidas. O documento original denota o expoente de Pearson tanto por \( R \) quanto por \( m \) (a mesma grandeza). Escrevendo \( u = \dfrac{\theta-\Theta}{H_k} \),

    $$\frac{\partial F}{\partial \Theta} = \frac{8mI(\theta-\Theta)}{H_k^2}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial H_k} = \frac{8mI(\theta-\Theta)^2}{H_k^3}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial m} = \left(1+4(2^{1/R}-1)u^2\right)^{-R}\left(\frac{4\cdot 2^{1/R}(\theta-\Theta)^2\ln 2}{m\left(H_k^2+4(2^{1/R}-1)(\theta-\Theta)^2\right)} - \ln\!\left(1+4(2^{1/R}-1)u^2\right)\right)$$

---

## Derivação da spline cúbica {#cubic-spline}

O PDIndexer usa uma curva spline cúbica para traçar o fundo. A forma verdadeira do fundo não pode ser resolvida exatamente, mas o programa detecta automaticamente as regiões sem pico e conecta os pontos detectados com uma spline para formar a curva de fundo. Uma spline aproxima os dados de forma uniforme, incluindo suas derivadas, e a aproximação melhora à medida que os pontos de dados são tornados mais densos.

Dados \( n \) pontos \( (X_1,Y_1), (X_2,Y_2), \dots, (X_{n-1},Y_{n-1}), (X_n,Y_n) \), procuramos uma curva que seja cúbica em cada intervalo e se una suavemente de modo que valor, inclinação e curvatura coincidam em cada ponto (os dois intervalos das extremidades \( \{-\infty, X_1\} \) e \( \{X_n, \infty\} \) são considerados lineares).

Seja a função no intervalo \( \{X_{m-1}, X_m\} \)

$$F_m = a_m X^3 + b_m X^2 + c_m X + d_m.$$

**Pontos interiores (\( 2 \le m \le n-1 \)).** A continuidade de valor, primeira derivada e segunda derivada fornece

$$F_m(X_m) = a_m X_m^3 + b_m X_m^2 + c_m X_m + d_m = Y_m$$

$$F_{m+1}(X_m) = a_{m+1} X_m^3 + b_{m+1} X_m^2 + c_{m+1} X_m + d_{m+1} = Y_m$$

$$F_m'(X_m) = 3a_m X_m^2 + 2b_m X_m + c_m = F_{m+1}'(X_m) = 3a_{m+1} X_m^2 + 2b_{m+1} X_m + c_{m+1}$$

$$F_m''(X_m) = 6a_m X_m + 2b_m = F_{m+1}''(X_m) = 6a_{m+1} X_m + 2b_{m+1}$$

— ou seja, **\( 4n-8 \) condições**.

**Início (\( m=1 \), o intervalo da extremidade esquerda é linear):**

$$F_1(X_1) = c_1 X_1 + d_1 = Y_1$$

$$F_2(X_1) = a_2 X_1^3 + b_2 X_1^2 + c_2 X_1 + d_2 = Y_1$$

$$F_1'(X_1) = c_1 = F_2'(X_1) = 3a_2 X_1^2 + 2b_2 X_1 + c_2$$

$$F_1''(X_1) = F_2''(X_1) = 6a_2 X_1 + 2b_2 = 0$$

— **4 condições**. O **fim (\( m=n \))** fornece da mesma forma

$$F_n(X_n) = a_n X_n^3 + b_n X_n^2 + c_n X_n + d_n = Y_n$$

$$F_{n+1}(X_n) = c_{n+1} X_n + d_{n+1} = Y_n$$

$$F_n'(X_n) = 3a_n X_n^2 + 2b_n X_n + c_n = F_{n+1}'(X_n) = c_{n+1}$$

$$F_n''(X_n) = 6a_n X_n + 2b_n = F_{n+1}''(X_n) = 0$$

— outras **4 condições**.

No total, \( 4n \) condições determinam \( 4n \) incógnitas, reduzindo o problema a um sistema de equações simultâneas. Escrevê-lo como uma matriz e invertê-la resolve o problema facilmente.

---

## Páginas relacionadas

- [6. Ajuste de picos de difração](../6-fitting-diffraction-peaks.md) — como usá-lo na prática
- [Equações de estado](../5-equation-of-states.md) — teoria de EOS como as equações de Birch–Murnaghan e Mie–Grüneisen
