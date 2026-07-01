<!-- 260625Cl: migrated from legacy doc/PDIndexerAlgorithm.pdf (former bundled PDF) -->
# Algorithmes

Cette page présente les principaux algorithmes numériques utilisés en interne par PDIndexer. Il s'agit d'une version migrée et réorganisée du PDF explicatif (`PDIndexerAlgorithm.pdf`) qui était autrefois fourni avec la distribution. L'objectif est de transmettre *ce qui est minimisé et comment cela est résolu* plutôt qu'une rigueur mathématique complète.

Trois sujets sont abordés :

1. [Affinement des paramètres de maille](#lattice-refinement) — moindres carrés linéaires
2. [Ajustement des pics](#peak-fitting) — moindres carrés non linéaires par la méthode de Marquardt, et les fonctions de profil
3. [Dérivation de la spline cubique](#cubic-spline) — courbe de fond continu

Pour la théorie des équations d'état (EOS), voir [Équations d'état](../5-equation-of-states.md).

---

## Affinement des paramètres de maille {#lattice-refinement}

### Moindres carrés linéaires généralisés

Étant donné \( n \) jeux d'observations \( (X^1_1, X^2_1, \dots, X^m_1, Z_1),\ (X^1_2, X^2_2, \dots, X^m_2, Z_2),\ \dots,\ (X^1_n, X^2_n, \dots, X^m_n, Z_n) \), l'ajustement de l'équation d'observation linéaire

$$Z = a^1 X^1 + a^2 X^2 + \dots + a^m X^m$$

sur les \( m \) paramètres \( (a^1, a^2, \dots, a^m) \) s'obtient en minimisant la somme des carrés des résidus. Sous forme matricielle,

$$
\mathbf{a}=\begin{pmatrix}a^1\\ \vdots\\ a^m\end{pmatrix},\quad
X=\begin{pmatrix}X^1_1 & X^2_1 & \cdots & X^m_1\\ X^1_2 & X^2_2 & \cdots & X^m_2\\ \vdots & & & \vdots\\ X^1_n & X^2_n & \cdots & X^m_n\end{pmatrix},\quad
Y=\begin{pmatrix}Y_1\\ \vdots\\ Y_n\end{pmatrix},\quad
W=\begin{pmatrix}W_1 & 0 & \cdots & 0\\ 0 & W_2 & & \\ \vdots & & \ddots & \\ 0 & & & W_n\end{pmatrix}
$$

où \( W \) est une matrice diagonale de poids. La minimisation de la somme pondérée des carrés

$$\Delta^2 = (X\mathbf{a}-Y)^{\mathsf{T}}\,W\,(X\mathbf{a}-Y)$$

en annulant sa dérivée par rapport à \( \mathbf{a} \),

$$\delta\Delta^2 = 2\,\delta\mathbf{a}^{\mathsf{T}}\left(X^{\mathsf{T}}W X\,\mathbf{a} - X^{\mathsf{T}}W Y\right) = 0,$$

donne la solution

$$\mathbf{a} = (X^{\mathsf{T}}W X)^{-1}\,X^{\mathsf{T}}W Y.$$

### Ajustement du tenseur métrique réciproque

Pour l'affinement des paramètres de maille, l'équation d'observation dépend du système cristallin, mais dans le cas le plus général (triclinique), la relation entre la distance interréticulaire \( d \) et les indices \( (h,k,l) \),

$$\left(\frac{1}{d}\right)^2 = h^2 a^{*2} + k^2 b^{*2} + l^2 c^{*2} + 2kl\,b^*c^*\cos\alpha^* + 2lh\,c^*a^*\cos\beta^* + 2hk\,a^*b^*\cos\gamma^*,$$

est traitée comme un modèle linéaire :

$$
\mathbf{a}=\begin{pmatrix}a^*a^*\\ b^*b^*\\ c^*c^*\\ 2b^*c^*\cos\alpha^*\\ 2c^*a^*\cos\beta^*\\ 2a^*b^*\cos\gamma^*\end{pmatrix},\quad
X=\begin{pmatrix}h_1h_1 & k_1k_1 & l_1l_1 & k_1l_1 & l_1h_1 & h_1k_1\\ \vdots & & & & & \vdots\\ h_nh_n & k_nk_n & l_nl_n & k_nl_n & l_nh_n & h_nk_n\end{pmatrix},\quad
Y=\begin{pmatrix}(1/d_1)^2\\ \vdots\\ (1/d_n)^2\end{pmatrix}
$$

où \( a^*, b^*, \dots \) sont les paramètres de maille réciproques. La résolution par les moindres carrés linéaires ci-dessus fournit les composantes du tenseur métrique réciproque, d'où découlent les paramètres de maille.

### Choix des poids

Le poids dépend de l'erreur. En supposant que l'erreur ne porte que sur l'angle de diffraction \( 2\theta \), la réponse de \( G = (1/d)^2 = 4\sin^2\theta/\lambda^2 \) à \( \theta \) est

$$\frac{\partial G}{\partial\theta} = \frac{4\sin(2\theta)}{\lambda^2},$$

de sorte qu'une variation \( \delta\theta \) déplace \( (1/d)^2 \) de \( \dfrac{4\sin(2\theta)}{\lambda^2}\delta\theta \). Par conséquent, \( 1/\sin^2(2\theta) \) (l'inverse de l'erreur au carré) est un poids approprié pour \( (1/d)^2 \) :

$$
W=\begin{pmatrix}
1/\sin^2(2\theta_1) & 0 & \cdots & 0\\
0 & 1/\sin^2(2\theta_2) & & \\
\vdots & & \ddots & \\
0 & & & 1/\sin^2(2\theta_n)
\end{pmatrix}.
$$

Ici, \( 1/\sin^2(2\theta) \) ne représente que le *rapport* des inverses des variances des points, et non leur valeur absolue, mais l'optimum est tout de même retrouvé : dans \( (X^{\mathsf{T}}W X)^{-1} X^{\mathsf{T}}W Y \), le facteur \( W \) apparaît deux fois, de sorte que l'échelle absolue s'annule.

### Erreurs des paramètres

Les erreurs (variances) de \( \mathbf{a} \) proviennent de la diagonale de \( (X^{\mathsf{T}}W X)^{-1} \), mais comme \( W \) n'a été fixé qu'à un rapport près, l'échelle absolue doit être déterminée séparément. À l'aide de la définition de la variance,

$$N - P = \sum_{i=1}^{n}\frac{\delta_i^2}{s_i}$$

(\( N \) : nombre de données, \( P \) : nombre de paramètres, \( \delta_i \) : résidu de la \( i \)-ème donnée, \( s_i \) : variance de la \( i \)-ème donnée), l'échelle de la variance est fixée à partir des paramètres obtenus par

$$s = \frac{\sum_{i=1}^{n}(\delta_i^2 w_i)}{N - P},$$

et sa racine carrée donne l'erreur. Il s'agit de l'erreur des paramètres de maille réciproques ; la convertir en erreur des paramètres de maille nécessite de propager l'erreur plus loin, ce qui est simple en principe.

---

## Ajustement des pics {#peak-fitting}

### Méthode de Marquardt

PDIndexer ajuste les pics avec la **méthode de Marquardt** (Levenberg–Marquardt), un schéma itératif non linéaire semblable à la méthode de Newton. Elle allie convergence rapide et stabilité et trouve l'optimum avec une précision suffisante.

Soit la fonction d'ajustement \( F = F(a_1, a_2, \dots, a_m, X) \) et le résidu aux paramètres initiaux \( \mathbf{a}^0 \)

$$R = \sum_{i=1}^{n}\left[Y_i - F(\mathbf{a}^0, X_i)\right]^2.$$

On construit la matrice \( m\times m \) \( \alpha \) et le vecteur de dimension \( m \) \( \beta \) comme suit. Multiplier uniquement la diagonale par \( (1+\lambda) \) est l'idée clé de la méthode de Marquardt, \( \lambda \) contrôlant la stabilité et la vitesse de convergence :

$$\alpha_{jk} = \sum_{i=1}^{n} w_i\,\frac{\partial F}{\partial a_j}\frac{\partial F}{\partial a_k}\quad(j\neq k),\qquad
\alpha_{jj} = (1+\lambda)\sum_{i=1}^{n} w_i\left(\frac{\partial F}{\partial a_j}\right)^2,$$

$$\beta_j = \sum_{i=1}^{n} w_i\left[Y_i - F(\mathbf{a}^0, X_i)\right]\frac{\partial F}{\partial a_j}.$$

Les paramètres sont mis à jour par

$$\mathbf{a}' = \mathbf{a}^0 + \alpha^{-1}\boldsymbol{\beta}.$$

On calcule le nouveau résidu \( R' \) et :

- si \( R' < R \), on accepte la mise à jour et on réduit \( \lambda \) (d'un facteur 0,1 à 0,5) ;
- si \( R' > R \), on rejette la mise à jour et on augmente \( \lambda \) (d'un facteur 2 à 10).

On répète jusqu'à ce que la variation de \( R \) soit suffisamment faible. Lorsque \( \lambda \to 0 \), la méthode se rapproche de la méthode de Gauss–Newton à convergence quadratique ; pour de grandes valeurs de \( \lambda \), elle se rapproche de la descente la plus raide le long du gradient des résidus \( \nabla R \). En basculant continûment entre les deux via \( \lambda \), on obtient une convergence stable et rapide.

### Fonctions de profil

PDIndexer propose la **fonction Pseudo Voigt** (un mélange de gaussienne et de lorentzienne), la **fonction Pearson VII** (une fonction de densité de probabilité), et leurs extensions asymétriques **Split Pseudo Voigt** / **Split Pearson VII**. Pour la rapidité et la stabilité de convergence, Symmetric Pseudo Voigt est la fonction par défaut. Toutes les fonctions sont normalisées à une aire unité.

**Symmetric Pseudo Voigt**

$$f(x,\eta,H_k)=\frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4\left(\dfrac{x}{H_k}\right)^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot 2^{-4\left(\frac{x}{H_k}\right)^2}\right)$$

**Split Pseudo Voigt (Toraya 1990, modifié)**

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_h-\eta_l)(Z-1)}{(1+e^{A})(\eta_h+Z(1-\eta_h))}}\left(\eta_l\,\frac{1}{1+(1+e^{-A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_l)Z\cdot 2^{-4(1+e^{-A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x<0)$$

$$f(x,\eta_l,\eta_h,A,H_k)=\frac{2}{H_k\pi+\dfrac{H_k\pi(\eta_l-\eta_h)(Z-1)}{(1+e^{-A})(\eta_h+Z(1-\eta_h))}}\left(\eta_h\,\frac{1}{1+(1+e^{A})\left(\dfrac{x}{H_k}\right)^2}+(1-\eta_h)Z\cdot 2^{-4(1+e^{A})\left(\frac{x}{H_k}\right)^2}\right)\quad(x>0)$$

**Symmetric Pearson VII**

$$f(x,R,H_k)=\frac{2\sqrt{2^{1/R}-1}\,\Gamma(R)}{\sqrt{\pi}\,\Gamma(R-1/2)\,H_k}\left(1+4(2^{1/R}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R}$$

**Split Pearson VII (Toraya 1990, modifié)**

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{-A})^2(2^{1/R_l}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_l}\quad(x<0)$$

$$f(x,R_l,R_h,A,H_k)=\frac{2(1+e^{A})}{H_k\sqrt{\pi}}\left(e^{A}\frac{\Gamma(R_l-1/2)}{\Gamma(R_l)\sqrt{2^{1/R_l}-1}}+\frac{\Gamma(R_h-1/2)}{\Gamma(R_h)\sqrt{2^{1/R_h}-1}}\right)^{-1}\left(1+(1+e^{A})^2(2^{1/R_h}-1)\left(\frac{x}{H_k}\right)^2\right)^{-R_h}\quad(x>0)$$

Les deux premières sont symétriques par rapport à \( x=0 \), tandis que les formes split changent de forme selon le signe de \( x \) pour exprimer l'asymétrie (telle qu'une traîne du côté des bas angles). En général, Pearson VII tend à donner le meilleur ajustement (résidu plus faible), tandis que Pseudo Voigt tend à converger plus stablement.

#### Symboles

| Symbole | Signification |
| --- | --- |
| \( H_k \) | largeur à mi-hauteur (FWHM) |
| \( \pi \) | la constante du cercle |
| \( \eta \) (\( \eta_l, \eta_h \)) | rapport de mélange lorentzien/gaussien (côté bas angle / haut angle pour les formes split) |
| \( \Gamma \) | fonction gamma |
| \( R \) (\( R_l, R_h \)) | exposant de Pearson |
| \( A \) | paramètre d'asymétrie |
| \( Z \) | constante de normalisation (\( \sqrt{\pi\ln 2} \)) |

### Fonction d'ajustement avec fond continu

En pratique, la fonction de profil \( f \) est étendue avec un fond continu linéaire :

$$F(\theta,\Theta,B_1,B_2) = I\cdot f(\theta-\Theta) + B_1 + B_2(\theta-\Theta)$$

(\( I \) : intensité intégrée, \( B_1, B_2 \) : fond continu linéaire, \( \Theta \) : centre du pic, \( \theta \) : position observée). Dans une plage donnée, les paramètres sont variés par la méthode de Marquardt de manière à minimiser \( R = \sum (Y - F)^2 \).

Les dérivées partielles de chaque fonction sont complexes ; la méthode de Marquardt utilise ces gradients analytiques. Des expressions représentatives sont données ci-dessous à titre de référence.

??? note "Dérivées partielles de Symmetric Pseudo Voigt"

    En posant \( u = \dfrac{\theta-\Theta}{H_k} \),

    $$\frac{\partial F}{\partial I} = \frac{2}{H_k\pi}\left(\eta\,\frac{1}{1+4u^2}+(1-\eta)\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \eta} = \frac{2I}{H_k\pi}\left(\frac{1}{1+4u^2}-\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial H_k} = -\frac{2I}{\pi}\left(\eta\,\frac{H_k^2-4(\theta-\Theta)^2}{\{H_k^2+4(\theta-\Theta)^2\}^2}+(1-\eta)\frac{\sqrt{\pi\ln 2}}{H_k^2}\,e^{-4\ln 2\,u^2}\right)$$

    $$\frac{\partial F}{\partial \theta} = \frac{16(\theta-\Theta)I}{H_k^3\pi}\left(\eta\,\frac{1}{(1+4u^2)^2}+(1-\eta)\ln 2\sqrt{\pi\ln 2}\cdot e^{-4\ln 2\,u^2}\right)+B_2$$

    $$\frac{\partial F}{\partial B_1} = 1,\qquad \frac{\partial F}{\partial B_2} = \theta-\Theta$$

??? note "Dérivées partielles de Pearson VII"

    Les dérivées simples par rapport à l'intensité et au fond continu (\( \partial F/\partial I,\ \partial F/\partial B_1,\ \partial F/\partial B_2 \)) sont omises. Le document original désigne l'exposant de Pearson à la fois par \( R \) et par \( m \) (la même quantité). En posant \( u = \dfrac{\theta-\Theta}{H_k} \),

    $$\frac{\partial F}{\partial \Theta} = \frac{8mI(\theta-\Theta)}{H_k^2}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial H_k} = \frac{8mI(\theta-\Theta)^2}{H_k^3}(2^{1/R}-1)\left(1+4(2^{1/R}-1)u^2\right)^{-1-R}$$

    $$\frac{\partial F}{\partial m} = \left(1+4(2^{1/R}-1)u^2\right)^{-R}\left(\frac{4\cdot 2^{1/R}(\theta-\Theta)^2\ln 2}{m\left(H_k^2+4(2^{1/R}-1)(\theta-\Theta)^2\right)} - \ln\!\left(1+4(2^{1/R}-1)u^2\right)\right)$$

---

## Dérivation de la spline cubique {#cubic-spline}

PDIndexer utilise une courbe spline cubique pour tracer le fond continu. La forme réelle du fond continu ne peut pas être résolue exactement, mais le logiciel détecte automatiquement les régions sans pic et relie les points détectés par une spline pour former la courbe de fond continu. Une spline approche les données de manière uniforme, y compris leurs dérivées, et l'approximation s'améliore à mesure que les points de données sont rendus plus denses.

Étant donné \( n \) points \( (X_1,Y_1), (X_2,Y_2), \dots, (X_{n-1},Y_{n-1}), (X_n,Y_n) \), on cherche une courbe qui est cubique sur chaque intervalle et se raccorde de façon lisse, de sorte que valeur, pente et courbure coïncident en chaque point (les deux intervalles d'extrémité \( \{-\infty, X_1\} \) et \( \{X_n, \infty\} \) étant pris linéaires).

Soit la fonction sur l'intervalle \( \{X_{m-1}, X_m\} \)

$$F_m = a_m X^3 + b_m X^2 + c_m X + d_m.$$

**Points intérieurs (\( 2 \le m \le n-1 \)).** La continuité de la valeur, de la dérivée première et de la dérivée seconde donne

$$F_m(X_m) = a_m X_m^3 + b_m X_m^2 + c_m X_m + d_m = Y_m$$

$$F_{m+1}(X_m) = a_{m+1} X_m^3 + b_{m+1} X_m^2 + c_{m+1} X_m + d_{m+1} = Y_m$$

$$F_m'(X_m) = 3a_m X_m^2 + 2b_m X_m + c_m = F_{m+1}'(X_m) = 3a_{m+1} X_m^2 + 2b_{m+1} X_m + c_{m+1}$$

$$F_m''(X_m) = 6a_m X_m + 2b_m = F_{m+1}''(X_m) = 6a_{m+1} X_m + 2b_{m+1}$$

— soit **\( 4n-8 \) conditions**.

**Début (\( m=1 \), l'intervalle d'extrémité gauche est linéaire) :**

$$F_1(X_1) = c_1 X_1 + d_1 = Y_1$$

$$F_2(X_1) = a_2 X_1^3 + b_2 X_1^2 + c_2 X_1 + d_2 = Y_1$$

$$F_1'(X_1) = c_1 = F_2'(X_1) = 3a_2 X_1^2 + 2b_2 X_1 + c_2$$

$$F_1''(X_1) = F_2''(X_1) = 6a_2 X_1 + 2b_2 = 0$$

— **4 conditions**. La **fin (\( m=n \))** donne de même

$$F_n(X_n) = a_n X_n^3 + b_n X_n^2 + c_n X_n + d_n = Y_n$$

$$F_{n+1}(X_n) = c_{n+1} X_n + d_{n+1} = Y_n$$

$$F_n'(X_n) = 3a_n X_n^2 + 2b_n X_n + c_n = F_{n+1}'(X_n) = c_{n+1}$$

$$F_n''(X_n) = 6a_n X_n + 2b_n = F_{n+1}''(X_n) = 0$$

— **4 conditions** supplémentaires.

Au total, \( 4n \) conditions déterminent \( 4n \) inconnues, ce qui ramène le problème à un système d'équations simultanées. En l'écrivant sous forme matricielle et en l'inversant, on le résout aisément.

---

## Pages associées

- [6. Ajustement des pics de diffraction](../6-fitting-diffraction-peaks.md) — utilisation pratique
- [Équations d'état](../5-equation-of-states.md) — théorie EOS telle que les équations de Birch–Murnaghan et de Mie–Grüneisen
