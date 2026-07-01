<!-- 260625Cl: migrated from legacy doc/PDIndexerAlgorithm.pdf (former bundled PDF) -->
# Algorithmen

Diese Seite skizziert die wichtigsten numerischen Algorithmen, die PDIndexer intern verwendet. Sie ist eine migrierte und neu strukturierte Fassung des erläuternden PDF (`PDIndexerAlgorithm.pdf`), das früher der Distribution beigelegt war. Ziel ist es, zu vermitteln, *was minimiert wird und wie es gelöst wird*, anstatt vollständige mathematische Strenge zu bieten.

Drei Themen werden behandelt:

1. [Verfeinerung der Gitterkonstanten](#lattice-refinement) — lineare Methode der kleinsten Quadrate
2. [Peak-Anpassung](#peak-fitting) — nichtlineare Methode der kleinsten Quadrate nach dem Marquardt-Verfahren sowie die Profilfunktionen
3. [Herleitung des kubischen Splines](#cubic-spline) — Untergrundkurve

Zur Theorie der Zustandsgleichungen (EOS) siehe [Zustandsgleichungen](../5-equation-of-states.md).

---

## Verfeinerung der Gitterkonstanten {#lattice-refinement}

### Verallgemeinerte lineare Methode der kleinsten Quadrate

Gegeben \( n \) Sätze von Beobachtungen \( (X^1_1, X^2_1, \dots, X^m_1, Z_1),\ (X^1_2, X^2_2, \dots, X^m_2, Z_2),\ \dots,\ (X^1_n, X^2_n, \dots, X^m_n, Z_n) \), wird die Anpassung der linearen Beobachtungsgleichung

$$Z = a^1 X^1 + a^2 X^2 + \dots + a^m X^m$$

über die \( m \) Parameter \( (a^1, a^2, \dots, a^m) \) durch Minimierung der Summe der quadrierten Residuen erreicht. In Matrixform,

$$
\mathbf{a}=\begin{pmatrix}a^1\\ \vdots\\ a^m\end{pmatrix},\quad
X=\begin{pmatrix}X^1_1 & X^2_1 & \cdots & X^m_1\\ X^1_2 & X^2_2 & \cdots & X^m_2\\ \vdots & & & \vdots\\ X^1_n & X^2_n & \cdots & X^m_n\end{pmatrix},\quad
Y=\begin{pmatrix}Y_1\\ \vdots\\ Y_n\end{pmatrix},\quad
W=\begin{pmatrix}W_1 & 0 & \cdots & 0\\ 0 & W_2 & & \\ \vdots & & \ddots & \\ 0 & & & W_n\end{pmatrix}
$$

wobei \( W \) eine Diagonalmatrix der Gewichte ist. Die Minimierung der gewichteten Quadratsumme

$$\Delta^2 = (X\mathbf{a}-Y)^{\mathsf{T}}\,W\,(X\mathbf{a}-Y)$$

durch Nullsetzen ihrer Ableitung nach \( \mathbf{a} \),

$$\delta\Delta^2 = 2\,\delta\mathbf{a}^{\mathsf{T}}\left(X^{\mathsf{T}}W X\,\mathbf{a} - X^{\mathsf{T}}W Y\right) = 0,$$

ergibt die Lösung

$$\mathbf{a} = (X^{\mathsf{T}}W X)^{-1}\,X^{\mathsf{T}}W Y.$$

### Anpassung des reziproken metrischen Tensors

Bei der Verfeinerung der Gitterkonstanten hängt die Beobachtungsgleichung vom Kristallsystem ab, doch im allgemeinsten (triklinen) Fall wird die Beziehung zwischen dem Netzebenenabstand \( d \) und den Indizes \( (h,k,l) \),

$$\left(\frac{1}{d}\right)^2 = h^2 a^{*2} + k^2 b^{*2} + l^2 c^{*2} + 2kl\,b^*c^*\cos\alpha^* + 2lh\,c^*a^*\cos\beta^* + 2hk\,a^*b^*\cos\gamma^*,$$

als lineares Modell behandelt:

$$
\mathbf{a}=\begin{pmatrix}a^*a^*\\ b^*b^*\\ c^*c^*\\ 2b^*c^*\cos\alpha^*\\ 2c^*a^*\cos\beta^*\\ 2a^*b^*\cos\gamma^*\end{pmatrix},\quad
X=\begin{pmatrix}h_1h_1 & k_1k_1 & l_1l_1 & k_1l_1 & l_1h_1 & h_1k_1\\ \vdots & & & & & \vdots\\ h_nh_n & k_nk_n & l_nl_n & k_nl_n & l_nh_n & h_nk_n\end{pmatrix},\quad
Y=\begin{pmatrix}(1/d_1)^2\\ \vdots\\ (1/d_n)^2\end{pmatrix}
$$

wobei \( a^*, b^*, \dots \) die reziproken Gitterkonstanten sind. Löst man dies mit der obigen linearen Methode der kleinsten Quadrate, erhält man die Komponenten des reziproken metrischen Tensors, aus denen die Gitterkonstanten folgen.

### Wahl der Gewichte

Das Gewicht hängt vom Fehler ab. Unter der Annahme, dass der Fehler nur im Beugungswinkel \( 2\theta \) liegt, ist die Antwort von \( G = (1/d)^2 = 4\sin^2\theta/\lambda^2 \) auf \( \theta \)

$$\frac{\partial G}{\partial\theta} = \frac{4\sin(2\theta)}{\lambda^2},$$

sodass eine Änderung \( \delta\theta \) den Wert \( (1/d)^2 \) um \( \dfrac{4\sin(2\theta)}{\lambda^2}\delta\theta \) verschiebt. Daher ist \( 1/\sin^2(2\theta) \) (der Kehrwert des quadrierten Fehlers) ein geeignetes Gewicht für \( (1/d)^2 \):

$$
W=\begin{pmatrix}
1/\sin^2(2\theta_1) & 0 & \cdots & 0\\
0 & 1/\sin^2(2\theta_2) & & \\
\vdots & & \ddots & \\
0 & & & 1/\sin^2(2\theta_n)
\end{pmatrix}.
$$

Hier stellt \( 1/\sin^2(2\theta) \) nur das *Verhältnis* der inversen Varianzen der Punkte dar, nicht deren absoluten Wert, dennoch wird das Optimum weiterhin gefunden: In \( (X^{\mathsf{T}}W X)^{-1} X^{\mathsf{T}}W Y \) tritt der Faktor \( W \) zweimal auf, sodass sich die absolute Skala herauskürzt.

### Parameterfehler

Die Fehler (Varianzen) von \( \mathbf{a} \) ergeben sich aus der Diagonale von \( (X^{\mathsf{T}}W X)^{-1} \), doch da \( W \) nur bis auf ein Verhältnis festgelegt wurde, muss die absolute Skala separat bestimmt werden. Unter Verwendung der Definition der Varianz,

$$N - P = \sum_{i=1}^{n}\frac{\delta_i^2}{s_i}$$

(\( N \): Anzahl der Daten, \( P \): Anzahl der Parameter, \( \delta_i \): Residuum des \( i \)-ten Datenpunkts, \( s_i \): Varianz des \( i \)-ten Datenpunkts), wird die Varianzskala aus den erhaltenen Parametern festgelegt als

$$s = \frac{\sum_{i=1}^{n}(\delta_i^2 w_i)}{N - P},$$

und ihre Quadratwurzel ist der Fehler. Dies ist der Fehler der reziproken Gitterkonstanten; um ihn in den Fehler der Gitterkonstanten umzurechnen, ist eine weitere Fehlerfortpflanzung erforderlich, die im Prinzip unkompliziert ist.

---

## Peak-Anpassung {#peak-fitting}

### Marquardt-Verfahren

PDIndexer passt Peaks mit dem **Marquardt-Verfahren** (Levenberg–Marquardt) an, einem nichtlinearen iterativen Schema ähnlich dem Newton-Verfahren. Es verbindet schnelle Konvergenz mit Stabilität und findet das Optimum mit ausreichender Genauigkeit.

Sei die Anpassungsfunktion \( F = F(a_1, a_2, \dots, a_m, X) \) und das Residuum bei den Anfangsparametern \( \mathbf{a}^0 \)

$$R = \sum_{i=1}^{n}\left[Y_i - F(\mathbf{a}^0, X_i)\right]^2.$$

Bilde die \( m\times m \)-Matrix \( \alpha \) und den \( m \)-Vektor \( \beta \) wie folgt. Nur die Diagonale mit \( (1+\lambda) \) zu multiplizieren ist die Kernidee des Marquardt-Verfahrens, wobei \( \lambda \) Stabilität und Konvergenzgeschwindigkeit steuert:

$$\alpha_{jk} = \sum_{i=1}^{n} w_i\,\frac{\partial F}{\partial a_j}\frac{\partial F}{\partial a_k}\quad(j\neq k),\qquad
\alpha_{jj} = (1+\lambda)\sum_{i=1}^{n} w_i\left(\frac{\partial F}{\partial a_j}\right)^2,$$

$$\beta_j = \sum_{i=1}^{n} w_i\left[Y_i - F(\mathbf{a}^0, X_i)\right]\frac{\partial F}{\partial a_j}.$$

Die Parameter werden aktualisiert durch

$$\mathbf{a}' = \mathbf{a}^0 + \alpha^{-1}\boldsymbol{\beta}.$$

Berechne das neue Residuum \( R' \) und:

- wenn \( R' < R \), übernimm die Aktualisierung und verkleinere \( \lambda \) (um einen Faktor von 0,1–0,5);
- wenn \( R' > R \), verwirf die Aktualisierung und vergrößere \( \lambda \) (um einen Faktor von 2–10).

Wiederhole, bis die Änderung von \( R \) hinreichend klein ist. Für \( \lambda \to 0 \) nähert sich das Verfahren dem quadratisch konvergenten Gauss–Newton-Verfahren an; für großes \( \lambda \) nähert es sich dem steilsten Abstieg entlang des Residuengradienten \( \nabla R \) an. Der kontinuierliche Wechsel zwischen beiden über \( \lambda \) ergibt eine stabile, schnelle Konvergenz.

### Profilfunktionen

PDIndexer bietet die **Pseudo-Voigt-Funktion** (eine Mischung aus Gauss- und Lorentz-Funktion), die **Pearson-VII-Funktion** (eine Wahrscheinlichkeitsdichtefunktion) sowie deren asymmetrische Erweiterungen **Split Pseudo Voigt** / **Split Pearson VII**. Im Hinblick auf Geschwindigkeit und Konvergenzstabilität ist Symmetric Pseudo Voigt die Voreinstellung. Alle Funktionen sind auf die Fläche eins normiert.

**Symmetric Pseudo Voigt**

$$f(x,\eta,H_k)=\frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4\left(\dfrac{x}{H_k}\right)^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot 2^{-4\left(\frac{x}{H_k}\right)^2}\right)$$

**Split Pseudo Voigt (Toraya 1990, modifiziert)**

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_h-\eta_l)(Z-1)}{(1+e^{A})(\eta_h+Z(1-\eta_h))}}\left(\eta_l\,\frac{1}{1+(1+e^{-A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_l)Z\cdot 2^{-4(1+e^{-A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x<0)$$

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_l-\eta_h)(Z-1)}{(1+e^{-A})(\eta_h+Z(1-\eta_h))}}\left(\eta_h\,\frac{1}{1+(1+e^{A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_h)Z\cdot 2^{-4(1+e^{A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x>0)$$

**Symmetric Pearson VII**

$$f(x,R,H_k)=\frac{2\sqrt{2^{1/R}-1}\,\Gamma(R)}{\sqrt{\pi}\,\Gamma(R-1/2)\,H_k}\left(1+4(2^{1/R}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R}$$

**Split Pearson VII (Toraya 1990, modifiziert)**

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{-A})^2(2^{1/R_l}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_l}\quad(x<0)$$

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{A})^2(2^{1/R_h}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_h}\quad(x>0)$$

Die ersten beiden sind symmetrisch um \( x=0 \), während die Split-Formen ihre Gestalt je nach Vorzeichen von \( x \) ändern, um Asymmetrie (etwa einen niederwinkligen Ausläufer) auszudrücken. Im Allgemeinen liefert Pearson VII tendenziell die bessere Anpassung (kleineres Residuum), während Pseudo Voigt tendenziell stabiler konvergiert.

#### Symbole

| Symbol | Bedeutung |
| --- | --- |
| \( H_k \) | Halbwertsbreite (FWHM) |
| \( \pi \) | die Kreiszahl |
| \( \eta \) (\( \eta_l, \eta_h \)) | Lorentz-/Gauss-Mischungsverhältnis (niederwinklige / hochwinklige Seite bei Split-Formen) |
| \( \Gamma \) | Gammafunktion |
| \( R \) (\( R_l, R_h \)) | Pearson-Exponent |
| \( A \) | Asymmetrieparameter |
| \( Z \) | Normierungskonstante (\( \sqrt{\pi\ln 2} \)) |

### Anpassungsfunktion mit Untergrund

In der Praxis wird die Profilfunktion \( f \) um einen linearen Untergrund erweitert:

$$F(\theta,\Theta,B_1,B_2) = I\cdot f(\theta-\Theta) + B_1 + B_2(\theta-\Theta)$$

(\( I \): integrierte Intensität, \( B_1, B_2 \): linearer Untergrund, \( \Theta \): Peak-Zentrum, \( \theta \): beobachtete Position). Innerhalb eines gegebenen Bereichs werden die Parameter mit dem Marquardt-Verfahren so variiert, dass \( R = \sum (Y - F)^2 \) minimiert wird.

Die partiellen Ableitungen jeder Funktion sind komplex; das Marquardt-Verfahren verwendet diese analytischen Gradienten. Repräsentative Ausdrücke sind im Folgenden zur Referenz angegeben.

??? note "Partielle Ableitungen von Symmetric Pseudo Voigt"

    Mit \( u = \dfrac{\theta-\Theta}{H_k} \),

    $$\frac{\partial F}{\partial I} = \frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4u^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \eta} = \frac{2I}{H_k\pi}\left(\frac{1}{1+4u^2}-\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial H_k} = -\frac{2I}{\pi}\left(\eta\,\frac{H_k^2-4(\theta-\Theta)^2}{\{H_k^2+4(\theta-\Theta)^2\}^2}+(1-\eta)\frac{\sqrt{\pi\ln 2}}{H_k^2}\,e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \theta} = \frac{16(\theta-\Theta)I}{H_k^3\pi}\left(\eta\,\frac{1}{(1+4u^2)^2}+(1-\eta)\ln 2\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)+B_2$$

    $$\frac{\partial F}{\partial B_1} = 1,\qquad \frac{\partial F}{\partial B_2} = \theta-\Theta$$

??? note "Partielle Ableitungen von Pearson VII"

    Die einfachen Ableitungen nach Intensität und Untergrund (\( \partial F/\partial I,\ \partial F/\partial B_1,\ \partial F/\partial B_2 \)) werden weggelassen. Das Originaldokument bezeichnet den Pearson-Exponenten sowohl mit \( R \) als auch mit \( m \) (dieselbe Größe). Mit \( u = \dfrac{\theta-\Theta}{H_k} \),

    $$\frac{\partial F}{\partial \Theta} = \frac{8mI(\theta-\Theta)}{H_k^2}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial H_k} = \frac{8mI(\theta-\Theta)^2}{H_k^3}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial m} = \left(1+4(2^{1/R}-1)u^2\right)^{-R}\left(\frac{4\cdot 2^{1/R}(\theta-\Theta)^2\ln 2}{m\left(H_k^2+4(2^{1/R}-1)(\theta-\Theta)^2\right)} - \ln\!\left(1+4(2^{1/R}-1)u^2\right)\right)$$

---

## Herleitung des kubischen Splines {#cubic-spline}

PDIndexer verwendet eine kubische Spline-Kurve, um den Untergrund zu zeichnen. Die wahre Form des Untergrunds lässt sich nicht exakt lösen, doch die Software erkennt automatisch die peakfreien Bereiche und verbindet die erkannten Punkte mit einem Spline zur Untergrundkurve. Ein Spline approximiert die Daten gleichmäßig, einschließlich ihrer Ableitungen, und die Approximation verbessert sich, je dichter die Datenpunkte gewählt werden.

Gegeben \( n \) Punkte \( (X_1,Y_1), (X_2,Y_2), \dots, (X_{n-1},Y_{n-1}), (X_n,Y_n) \), suchen wir eine Kurve, die auf jedem Intervall kubisch ist und so glatt anschließt, dass Wert, Steigung und Krümmung an jedem Punkt übereinstimmen (die beiden Endintervalle \( \{-\infty, X_1\} \) und \( \{X_n, \infty\} \) werden als linear angenommen).

Sei die Funktion auf dem Intervall \( \{X_{m-1}, X_m\} \)

$$F_m = a_m X^3 + b_m X^2 + c_m X + d_m.$$

**Innere Punkte (\( 2 \le m \le n-1 \)).** Die Stetigkeit von Wert, erster Ableitung und zweiter Ableitung ergibt

$$F_m(X_m) = a_m X_m^3 + b_m X_m^2 + c_m X_m + d_m = Y_m$$

$$F_{m+1}(X_m) = a_{m+1} X_m^3 + b_{m+1} X_m^2 + c_{m+1} X_m + d_{m+1} = Y_m$$

$$F_m'(X_m) = 3a_m X_m^2 + 2b_m X_m + c_m = F_{m+1}'(X_m) = 3a_{m+1} X_m^2 + 2b_{m+1} X_m + c_{m+1}$$

$$F_m''(X_m) = 6a_m X_m + 2b_m = F_{m+1}''(X_m) = 6a_{m+1} X_m + 2b_{m+1}$$

— das heißt, **\( 4n-8 \) Bedingungen**.

**Anfang (\( m=1 \), linkes Endintervall ist linear):**

$$F_1(X_1) = c_1 X_1 + d_1 = Y_1$$

$$F_2(X_1) = a_2 X_1^3 + b_2 X_1^2 + c_2 X_1 + d_2 = Y_1$$

$$F_1'(X_1) = c_1 = F_2'(X_1) = 3a_2 X_1^2 + 2b_2 X_1 + c_2$$

$$F_1''(X_1) = F_2''(X_1) = 6a_2 X_1 + 2b_2 = 0$$

— **4 Bedingungen**. Das **Ende (\( m=n \))** ergibt ebenso

$$F_n(X_n) = a_n X_n^3 + b_n X_n^2 + c_n X_n + d_n = Y_n$$

$$F_{n+1}(X_n) = c_{n+1} X_n + d_{n+1} = Y_n$$

$$F_n'(X_n) = 3a_n X_n^2 + 2b_n X_n + c_n = F_{n+1}'(X_n) = c_{n+1}$$

$$F_n''(X_n) = 6a_n X_n + 2b_n = F_{n+1}''(X_n) = 0$$

— weitere **4 Bedingungen**.

Insgesamt bestimmen \( 4n \) Bedingungen \( 4n \) Unbekannte, wodurch sich das Problem auf ein System simultaner Gleichungen reduziert. Schreibt man es als Matrix aus und invertiert sie, lässt es sich leicht lösen.

---

## Verwandte Seiten

- [6. Beugungspeak-Anpassung](../6-fitting-diffraction-peaks.md) — wie man es in der Praxis verwendet
- [Zustandsgleichungen](../5-equation-of-states.md) — EOS-Theorie wie die Birch–Murnaghan- und Mie–Grüneisen-Gleichungen
