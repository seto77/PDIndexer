<!-- 260625Cl: migrated from legacy doc/PDIndexerAlgorithm.pdf (former bundled PDF) -->
# Algoritmi

Questa pagina descrive i principali algoritmi numerici utilizzati internamente da PDIndexer. È una versione migrata e riorganizzata del PDF esplicativo (`PDIndexerAlgorithm.pdf`) che un tempo era distribuito insieme al programma. L'obiettivo è trasmettere *cosa viene minimizzato e come viene risolto*, piuttosto che il pieno rigore matematico.

Sono trattati tre argomenti:

1. [Raffinamento del parametro reticolare](#lattice-refinement) — minimi quadrati lineari
2. [Fitting dei picchi](#peak-fitting) — minimi quadrati non lineari con il metodo di Marquardt, e le funzioni di profilo
3. [Derivazione della spline cubica](#cubic-spline) — curva del fondo

Per la teoria delle equazioni di stato (EOS), si veda [Equazioni di stato](../5-equation-of-states.md).

---

## Raffinamento del parametro reticolare {#lattice-refinement}

### Minimi quadrati lineari generalizzati

Dati \( n \) insiemi di osservazioni \( (X^1_1, X^2_1, \dots, X^m_1, Z_1),\ (X^1_2, X^2_2, \dots, X^m_2, Z_2),\ \dots,\ (X^1_n, X^2_n, \dots, X^m_n, Z_n) \), il fitting dell'equazione di osservazione lineare

$$Z = a^1 X^1 + a^2 X^2 + \dots + a^m X^m$$

sui \( m \) parametri \( (a^1, a^2, \dots, a^m) \) si ottiene minimizzando la somma dei quadrati dei residui. In forma matriciale,

$$
\mathbf{a}=\begin{pmatrix}a^1\\ \vdots\\ a^m\end{pmatrix},\quad
X=\begin{pmatrix}X^1_1 & X^2_1 & \cdots & X^m_1\\ X^1_2 & X^2_2 & \cdots & X^m_2\\ \vdots & & & \vdots\\ X^1_n & X^2_n & \cdots & X^m_n\end{pmatrix},\quad
Y=\begin{pmatrix}Y_1\\ \vdots\\ Y_n\end{pmatrix},\quad
W=\begin{pmatrix}W_1 & 0 & \cdots & 0\\ 0 & W_2 & & \\ \vdots & & \ddots & \\ 0 & & & W_n\end{pmatrix}
$$

dove \( W \) è una matrice diagonale di pesi. Minimizzando la somma pesata dei quadrati

$$\Delta^2 = (X\mathbf{a}-Y)^{\mathsf{T}}\,W\,(X\mathbf{a}-Y)$$

annullando la sua derivata rispetto ad \( \mathbf{a} \),

$$\delta\Delta^2 = 2\,\delta\mathbf{a}^{\mathsf{T}}\left(X^{\mathsf{T}}W X\,\mathbf{a} - X^{\mathsf{T}}W Y\right) = 0,$$

si ottiene la soluzione

$$\mathbf{a} = (X^{\mathsf{T}}W X)^{-1}\,X^{\mathsf{T}}W Y.$$

### Adattamento del tensore metrico reciproco

Per il raffinamento del parametro reticolare l'equazione di osservazione dipende dal sistema cristallino, ma nel caso più generale (triclino) la relazione tra la distanza interplanare \( d \) e gli indici \( (h,k,l) \),

$$\left(\frac{1}{d}\right)^2 = h^2 a^{*2} + k^2 b^{*2} + l^2 c^{*2} + 2kl\,b^*c^*\cos\alpha^* + 2lh\,c^*a^*\cos\beta^* + 2hk\,a^*b^*\cos\gamma^*,$$

è trattata come un modello lineare:

$$
\mathbf{a}=\begin{pmatrix}a^*a^*\\ b^*b^*\\ c^*c^*\\ 2b^*c^*\cos\alpha^*\\ 2c^*a^*\cos\beta^*\\ 2a^*b^*\cos\gamma^*\end{pmatrix},\quad
X=\begin{pmatrix}h_1h_1 & k_1k_1 & l_1l_1 & k_1l_1 & l_1h_1 & h_1k_1\\ \vdots & & & & & \vdots\\ h_nh_n & k_nk_n & l_nl_n & k_nl_n & l_nh_n & h_nk_n\end{pmatrix},\quad
Y=\begin{pmatrix}(1/d_1)^2\\ \vdots\\ (1/d_n)^2\end{pmatrix}
$$

dove \( a^*, b^*, \dots \) sono i parametri reticolari reciproci. Risolvendo questo sistema con i minimi quadrati lineari sopra descritti si ottengono le componenti del tensore metrico reciproco, dalle quali derivano i parametri reticolari.

### Scelta dei pesi

Il peso dipende dall'errore. Assumendo che l'errore risieda solo nell'angolo di diffrazione \( 2\theta \), la risposta di \( G = (1/d)^2 = 4\sin^2\theta/\lambda^2 \) rispetto a \( \theta \) è

$$\frac{\partial G}{\partial\theta} = \frac{4\sin(2\theta)}{\lambda^2},$$

quindi una variazione \( \delta\theta \) sposta \( (1/d)^2 \) di \( \dfrac{4\sin(2\theta)}{\lambda^2}\delta\theta \). Pertanto \( 1/\sin^2(2\theta) \) (l'inverso dell'errore quadratico) è un peso appropriato per \( (1/d)^2 \):

$$
W=\begin{pmatrix}
1/\sin^2(2\theta_1) & 0 & \cdots & 0\\
0 & 1/\sin^2(2\theta_2) & & \\
\vdots & & \ddots & \\
0 & & & 1/\sin^2(2\theta_n)
\end{pmatrix}.
$$

Qui \( 1/\sin^2(2\theta) \) rappresenta solo il *rapporto* tra le varianze inverse dei punti, non il loro valore assoluto, eppure l'ottimo viene comunque recuperato: in \( (X^{\mathsf{T}}W X)^{-1} X^{\mathsf{T}}W Y \) il fattore \( W \) compare due volte, per cui la scala assoluta si elide.

### Errori dei parametri

Gli errori (varianze) di \( \mathbf{a} \) provengono dalla diagonale di \( (X^{\mathsf{T}}W X)^{-1} \), ma poiché \( W \) è stato fissato solo a meno di un rapporto, la scala assoluta deve essere determinata separatamente. Usando la definizione di varianza,

$$N - P = \sum_{i=1}^{n}\frac{\delta_i^2}{s_i}$$

(\( N \): numero di dati, \( P \): numero di parametri, \( \delta_i \): residuo dell'\( i \)-esimo dato, \( s_i \): varianza dell'\( i \)-esimo dato), la scala della varianza viene fissata dai parametri ottenuti come

$$s = \frac{\sum_{i=1}^{n}(\delta_i^2 w_i)}{N - P},$$

e la sua radice quadrata è l'errore. Questo è l'errore dei parametri reticolari reciproci; convertirlo nell'errore dei parametri reticolari richiede di propagare ulteriormente l'errore, cosa che in linea di principio è immediata.

---

## Fitting dei picchi {#peak-fitting}

### Metodo di Marquardt

PDIndexer esegue il fitting dei picchi con il **metodo di Marquardt** (Levenberg–Marquardt), uno schema iterativo non lineare simile al metodo di Newton. Combina una rapida convergenza con la stabilità e trova l'ottimo con accuratezza sufficiente.

Sia la funzione di fitting \( F = F(a_1, a_2, \dots, a_m, X) \) e il residuo ai parametri iniziali \( \mathbf{a}^0 \) sia

$$R = \sum_{i=1}^{n}\left[Y_i - F(\mathbf{a}^0, X_i)\right]^2.$$

Si costruiscono la matrice \( m\times m \) \( \alpha \) e il vettore \( m \)-dimensionale \( \beta \) come segue. Moltiplicare solo la diagonale per \( (1+\lambda) \) è l'idea chiave del metodo di Marquardt, con \( \lambda \) che controlla la stabilità e la velocità di convergenza:

$$\alpha_{jk} = \sum_{i=1}^{n} w_i\,\frac{\partial F}{\partial a_j}\frac{\partial F}{\partial a_k}\quad(j\neq k),\qquad
\alpha_{jj} = (1+\lambda)\sum_{i=1}^{n} w_i\left(\frac{\partial F}{\partial a_j}\right)^2,$$

$$\beta_j = \sum_{i=1}^{n} w_i\left[Y_i - F(\mathbf{a}^0, X_i)\right]\frac{\partial F}{\partial a_j}.$$

I parametri vengono aggiornati mediante

$$\mathbf{a}' = \mathbf{a}^0 + \alpha^{-1}\boldsymbol{\beta}.$$

Si calcola il nuovo residuo \( R' \) e:

- se \( R' < R \), si accetta l'aggiornamento e si riduce \( \lambda \) (di un fattore 0.1–0.5);
- se \( R' > R \), si rifiuta l'aggiornamento e si aumenta \( \lambda \) (di un fattore 2–10).

Si ripete finché la variazione di \( R \) è sufficientemente piccola. Per \( \lambda \to 0 \) il metodo si avvicina al metodo di Gauss–Newton, a convergenza quadratica; per \( \lambda \) grande si avvicina alla discesa più ripida lungo il gradiente del residuo \( \nabla R \). Passando con continuità tra i due tramite \( \lambda \) si ottiene una convergenza stabile e veloce.

### Funzioni di profilo

PDIndexer offre la **funzione Pseudo Voigt** (una miscela di gaussiana e lorentziana), la **funzione Pearson VII** (una funzione di densità di probabilità), e le loro estensioni asimmetriche **Split Pseudo Voigt** / **Split Pearson VII**. Per velocità e stabilità di convergenza, Symmetric Pseudo Voigt è quella predefinita. Tutte le funzioni sono normalizzate ad area unitaria.

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

Le prime due sono simmetriche rispetto a \( x=0 \), mentre le forme split cambiano forma a seconda del segno di \( x \) per esprimere l'asimmetria (come una coda dal lato dei bassi angoli). In generale, Pearson VII tende a fornire il fit migliore (residuo più piccolo), mentre Pseudo Voigt tende a convergere in modo più stabile.

#### Simboli

| Simbolo | Significato |
| --- | --- |
| \( H_k \) | larghezza a metà altezza (FWHM) |
| \( \pi \) | la costante del cerchio |
| \( \eta \) (\( \eta_l, \eta_h \)) | rapporto di miscelazione lorentziana/gaussiana (lato bassi angoli / alti angoli per le forme split) |
| \( \Gamma \) | funzione gamma |
| \( R \) (\( R_l, R_h \)) | esponente di Pearson |
| \( A \) | parametro di asimmetria |
| \( Z \) | costante di normalizzazione (\( \sqrt{\pi\ln 2} \)) |

### Funzione di fitting con il fondo

In pratica la funzione di profilo \( f \) viene estesa con un fondo lineare:

$$F(\theta,\Theta,B_1,B_2) = I\cdot f(\theta-\Theta) + B_1 + B_2(\theta-\Theta)$$

(\( I \): intensità integrata, \( B_1, B_2 \): fondo lineare, \( \Theta \): centro del picco, \( \theta \): posizione osservata). Entro un intervallo assegnato, i parametri vengono variati con il metodo di Marquardt in modo da minimizzare \( R = \sum (Y - F)^2 \).

Le derivate parziali di ciascuna funzione sono complesse; il metodo di Marquardt utilizza questi gradienti analitici. Di seguito sono riportate, come riferimento, alcune espressioni rappresentative.

??? note "Derivate parziali di Symmetric Pseudo Voigt"

    Ponendo \( u = \dfrac{\theta-\Theta}{H_k} \),

    $$\frac{\partial F}{\partial I} = \frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4u^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \eta} = \frac{2I}{H_k\pi}\left(\frac{1}{1+4u^2}-\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial H_k} = -\frac{2I}{\pi}\left(\eta\,\frac{H_k^2-4(\theta-\Theta)^2}{\{H_k^2+4(\theta-\Theta)^2\}^2}+(1-\eta)\frac{\sqrt{\pi\ln 2}}{H_k^2}\,e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \theta} = \frac{16(\theta-\Theta)I}{H_k^3\pi}\left(\eta\,\frac{1}{(1+4u^2)^2}+(1-\eta)\ln 2\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)+B_2$$

    $$\frac{\partial F}{\partial B_1} = 1,\qquad \frac{\partial F}{\partial B_2} = \theta-\Theta$$

??? note "Derivate parziali di Pearson VII"

    Le derivate semplici rispetto all'intensità e al fondo (\( \partial F/\partial I,\ \partial F/\partial B_1,\ \partial F/\partial B_2 \)) sono omesse. Il documento originale indica l'esponente di Pearson sia con \( R \) sia con \( m \) (la stessa quantità). Ponendo \( u = \dfrac{\theta-\Theta}{H_k} \),

    $$\frac{\partial F}{\partial \Theta} = \frac{8mI(\theta-\Theta)}{H_k^2}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial H_k} = \frac{8mI(\theta-\Theta)^2}{H_k^3}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial m} = \left(1+4(2^{1/R}-1)u^2\right)^{-R}\left(\frac{4\cdot 2^{1/R}(\theta-\Theta)^2\ln 2}{m\left(H_k^2+4(2^{1/R}-1)(\theta-\Theta)^2\right)} - \ln\!\left(1+4(2^{1/R}-1)u^2\right)\right)$$

---

## Derivazione della spline cubica {#cubic-spline}

PDIndexer utilizza una curva spline cubica per tracciare il fondo. La vera forma del fondo non può essere risolta esattamente, ma il programma rileva automaticamente le regioni prive di picchi e collega i punti rilevati con una spline per formare la curva del fondo. Una spline approssima i dati in modo uniforme, incluse le loro derivate, e l'approssimazione migliora man mano che i punti dati vengono resi più fitti.

Dati \( n \) punti \( (X_1,Y_1), (X_2,Y_2), \dots, (X_{n-1},Y_{n-1}), (X_n,Y_n) \), si cerca una curva che sia cubica su ciascun intervallo e si congiunga in modo regolare così che valore, pendenza e curvatura coincidano in ogni punto (i due intervalli terminali \( \{-\infty, X_1\} \) e \( \{X_n, \infty\} \) sono assunti lineari).

Sia la funzione sull'intervallo \( \{X_{m-1}, X_m\} \)

$$F_m = a_m X^3 + b_m X^2 + c_m X + d_m.$$

**Punti interni (\( 2 \le m \le n-1 \)).** La continuità di valore, prima derivata e seconda derivata dà

$$F_m(X_m) = a_m X_m^3 + b_m X_m^2 + c_m X_m + d_m = Y_m$$

$$F_{m+1}(X_m) = a_{m+1} X_m^3 + b_{m+1} X_m^2 + c_{m+1} X_m + d_{m+1} = Y_m$$

$$F_m'(X_m) = 3a_m X_m^2 + 2b_m X_m + c_m = F_{m+1}'(X_m) = 3a_{m+1} X_m^2 + 2b_{m+1} X_m + c_{m+1}$$

$$F_m''(X_m) = 6a_m X_m + 2b_m = F_{m+1}''(X_m) = 6a_{m+1} X_m + 2b_{m+1}$$

— cioè **\( 4n-8 \) condizioni**.

**Inizio (\( m=1 \), l'intervallo terminale sinistro è lineare):**

$$F_1(X_1) = c_1 X_1 + d_1 = Y_1$$

$$F_2(X_1) = a_2 X_1^3 + b_2 X_1^2 + c_2 X_1 + d_2 = Y_1$$

$$F_1'(X_1) = c_1 = F_2'(X_1) = 3a_2 X_1^2 + 2b_2 X_1 + c_2$$

$$F_1''(X_1) = F_2''(X_1) = 6a_2 X_1 + 2b_2 = 0$$

— **4 condizioni**. La **fine (\( m=n \))** dà analogamente

$$F_n(X_n) = a_n X_n^3 + b_n X_n^2 + c_n X_n + d_n = Y_n$$

$$F_{n+1}(X_n) = c_{n+1} X_n + d_{n+1} = Y_n$$

$$F_n'(X_n) = 3a_n X_n^2 + 2b_n X_n + c_n = F_{n+1}'(X_n) = c_{n+1}$$

$$F_n''(X_n) = 6a_n X_n + 2b_n = F_{n+1}''(X_n) = 0$$

— altre **4 condizioni**.

In totale, \( 4n \) condizioni determinano \( 4n \) incognite, riducendo il problema a un sistema di equazioni simultanee. Scrivendolo come una matrice e invertendola lo si risolve facilmente.

---

## Pagine correlate

- [6. Fitting dei picchi di diffrazione](../6-fitting-diffraction-peaks.md) — come usarlo in pratica
- [Equazioni di stato](../5-equation-of-states.md) — teoria EOS come le equazioni di Birch–Murnaghan e Mie–Grüneisen
