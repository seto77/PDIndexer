<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Ajustement des pics de diffraction

L'outil `Ajustement des pics de diffraction (F)` ajuste les pics d'un profil de diffraction avec une fonction appropriée, déduit la distance interréticulaire (valeur d) à partir de la position 2θ de chaque pic, puis affine les paramètres de maille par moindres carrés. Il se lance depuis la barre d'outils de la fenêtre principale.

![Fenêtre complète de l'ajustement des pics](../assets/cap-fr-auto/FormFitting.png)

## Déroulement de base

1. Sélectionnez le cristal cible dans la liste des cristaux (en mode multi-profils, sélectionnez aussi le profil sur lequel vous voulez travailler).
2. Dans la fenêtre principale, faites glisser les raies de diffraction avec la souris pour qu'elles recouvrent les pics mesurés aussi précisément que possible.
3. Choisissez les indices des raies de diffraction que vous souhaitez ajuster dans la liste des pics de diffraction (une liste à cases à cocher).
4. Dès qu'un nombre suffisant d'indices indépendants est choisi pour que le calcul par moindres carrés soit résoluble, les paramètres de maille les plus probables apparaissent, avec leurs erreurs, dans le panneau `Paramètres de maille optimisés` en bas à droite.
5. Appuyez sur `Appliquer au cristal` pour répercuter les paramètres de maille affinés sur le cristal dans le programme principal.

!!! note "Vérification et sélection d'un cristal"
    La liste des cristaux reflète celle de la fenêtre principale. Pour que l'ajustement prenne effet, le cristal cible doit être à la fois coché et sélectionné.

## Liste des cristaux

![Liste des cristaux](../assets/cap-fr-auto/FormFitting.groupBox1.png)

La liste des cristaux en haut à gauche contient les mêmes cristaux que la fenêtre principale. Le cristal que vous cochez et sélectionnez ici devient la cible de l'ajustement. Voir [Paramètres du cristal](3-crystal-parameter.md) pour plus de détails.

## Liste des pics de diffraction

![Liste des pics de diffraction](../assets/cap-fr-auto/FormFitting.groupBox5.png)

Les raies de diffraction du cristal sélectionné sont listées ici. Cocher la case d'une ligne fait de cette raie de diffraction une cible d'ajustement. La liste contient les colonnes suivantes.

| Colonne | Contenu |
| --- | --- |
| `Sélection` | Inclure ou non la raie dans l'ajustement |
| `Couleur du pic` | Couleur d'affichage |
| `Cristal` | Nom du cristal |
| `HKL` | Indices de réflexion |
| `X calc.` | Position calculée de la raie de diffraction |
| `Fonct.` | Fonction de pic utilisée |
| `X` | Position du pic obtenue par ajustement |
| `Err. X` | Erreur de la position du pic |
| `FWHM` | Largeur à mi-hauteur |
| `Intensité` | Intensité du pic |
| `Poids` | Poids dans l'ajustement par moindres carrés |
| `R` | Indice de résidu de l'ajustement |

Les boutons situés sous la liste exportent les résultats.

- `Copier dans le presse-papiers`: Copie le tableau dans le presse-papiers. Il peut être collé directement dans Excel et les applications similaires.
- `Enregistrer en CSV`: Enregistre le tableau sous forme de fichier `.csv`. `Chiffres signif.` règle le nombre de chiffres significatifs affichés dans le tableau.
- `Effacer les pics`: Supprime tous les pics ajoutés manuellement au Flexible Crystal.

## Fitting option (options d'ajustement)

![Options d'ajustement](../assets/cap-fr-auto/FormFitting.groupBox3.png)

Vous effectuez ici les réglages détaillés utilisés lors de l'ajustement des profils de pic.

### Search Range / Initial FWHM

![Search Range et Initial FWHM](../assets/cap-fr-auto/FormFitting.groupBox3.groupBox2.png)

- `Plage de recherche`: Définit la plage sur laquelle l'ajustement est effectué. Autrement dit, la région située dans ±`Plage de recherche` autour de la position calculée de la raie de diffraction est prise comme cible d'ajustement pour ce pic.
- `FWHM initiale`: Spécifie la largeur à mi-hauteur initiale de la fonction de profil. Elle sert de valeur de départ pour la convergence des moindres carrés.

Appuyer sur `Appliquer à tous` applique les réglages actuels à toutes les raies de diffraction en une seule fois.

### Peak function (fonction de pic)

Sélectionne la fonction de pic utilisée pour l'ajustement.

| Fonction de pic | Contenu |
| --- | --- |
| `Recherche simple` | N'effectue aucun ajustement de fonction ; reconnaît le point le plus intense dans ±`Plage de recherche` autour de la position calculée de la raie de diffraction comme la position du pic. |
| `Pseudo-Voigt symétrique` | Ajuste avec une fonction pseudo-Voigt symétrique gauche-droite. |
| `Pearson VII symétrique` | Ajuste avec une fonction Pearson VII symétrique gauche-droite. |
| `Pseudo-Voigt asymétrique` | Ajuste avec une fonction pseudo-Voigt asymétrique (split) gauche-droite. |
| `Pearson VII asymétrique` | Ajuste avec une fonction Pearson VII asymétrique (split) gauche-droite. |

!!! tip "Fonction recommandée"
    Sauf raison particulière, `Pseudo-Voigt symétrique` est recommandée en raison de sa stabilité supérieure.

La fonction pseudo-Voigt est une combinaison linéaire d'une gaussienne \(G(x)\) et d'une lorentzienne \(L(x)\) avec un paramètre de mélange \(\eta\), donnée par :

$$
\mathrm{pV}(x) = \eta\, L(x) + (1-\eta)\, G(x), \qquad 0 \le \eta \le 1
$$

où \(\eta\) est la fraction de la composante lorentzienne. La forme split représente un profil asymétrique en prenant des paramètres tels que la FWHM indépendamment à gauche et à droite de la position du pic.

### Pattern Decomposition (décomposition du diagramme)

![Décomposition du diagramme](../assets/cap-fr-auto/FormFitting.groupBox3.flowLayoutPanelPatternDecomposition.png)

Lorsque les `Plage de recherche` de deux raies de diffraction sélectionnées ou plus se chevauchent, cette option choisit s'il faut effectuer une décomposition du diagramme (ajustement simultané des pics qui se chevauchent).

- `pour chaque cristal`: Effectue la décomposition du diagramme indépendamment pour chaque cristal.
- `entre les cristaux`: Effectue la décomposition du diagramme sur l'ensemble des cristaux.

## Optimized cell constants (paramètres de maille optimisés)

![Panneau des paramètres de maille optimisés](../assets/cap-fr-auto/FormFitting.groupBox4.png)

Dès qu'un nombre suffisant d'indices indépendants est choisi pour que le calcul par moindres carrés devienne résoluble, ce panneau affiche les paramètres de maille les plus probables \(a, b, c, \alpha, \beta, \gamma\) et le volume \(V\), chacun avec son erreur (`±`).

!!! note "À propos de l'affichage NA"
    Lorsque le nombre de réflexions ajustées est égal au nombre de paramètres de maille indépendants, les résidus ne permettent pas d'obtenir les erreurs types, et `NA` est affiché dans les champs d'erreur. Lorsqu'il y a trop peu de réflexions indépendantes pour déterminer les paramètres de maille, le programme conserve la forme initiale de la maille et ne modifie que son échelle globale, et les erreurs sont affichées comme `NA`. Choisir suffisamment de réflexions indépendantes permet de calculer les erreurs.

- `Appliquer au cristal`: Répercute les paramètres de maille affinés sur le cristal sélectionné dans le programme principal.
- `Copier dans le presse-papiers`: Copie les paramètres de maille optimisés dans le presse-papiers.

## Remove fitted peaks (suppression des pics ajustés)

Ceci soustrait les pics ajustés du profil et produit le profil résiduel sous forme de nouveau profil. Saisissez le nom de destination dans `Nom du nouveau profil` et appuyez sur `Supprimer les pics ajustés` pour effectuer la soustraction. C'est utile pour vérifier le fond continu ou la séparation des pics qui se chevauchent.

## Outils associés (Send d-values)

Appuyer sur `Envoyer les valeurs d vers CellFinder && AtomicPositionFinder` envoie à `Cell Finder` les valeurs d obtenues par l'ajustement des réflexions cochées. Ouvrez `Cell Finder` depuis la barre d'outils. <!-- 261124Cl changed (author decision): the Atomic Position Finder, not available in the current version, is no longer described -->

### Cell Finder

![Cell Finder](../assets/cap-fr-auto/FormCellFinder.png)

`Cell Finder` recherche des paramètres de maille candidats qui expliquent un ensemble de positions de pics mesurées (une liste de valeurs d). Il sert à indexer des échantillons inconnus.

!!! tip "Identification d'un échantillon inconnu"
    Après avoir déterminé les paramètres de maille avec `Cell Finder`, enregistrez ce cristal dans la liste des cristaux, et vous pourrez affiner davantage les paramètres de maille avec l'ajustement par moindres carrés de cet outil.
