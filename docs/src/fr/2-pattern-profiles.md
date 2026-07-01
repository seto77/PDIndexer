<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Profils de diffraction

Cette page décrit les « données de profil » elles-mêmes (le jeu de données mesuré) que gère PDIndexer, ainsi que leur chargement, leur affichage et leur exportation. Les traitements appliqués après le chargement — lissage, soustraction du fond continu, etc. — se font dans la fenêtre [Paramètres du profil](4-profile-parameter.md). Pour la liste complète des extensions de fichier prises en charge, voir [Formats de fichier](appendix/file-formats.md).

![Fenêtre principale de PDIndexer avec un profil au centre et les listes de profils et de cristaux à gauche.](../assets/cap-fr-auto/FormMain.png)

## Qu'est-ce qu'un profil

Un profil est un jeu de données unidimensionnel « axe horizontal vs intensité » obtenu à partir d'une mesure de diffraction de poudre. L'axe horizontal est exprimé de l'une des manières suivantes, selon la géométrie de mesure :

- \( 2\theta \) (angle de diffraction) pour la diffraction à dispersion angulaire (diffraction de rayons X ordinaire)
- L'énergie pour les mesures à dispersion d'énergie (rayons X blancs, détection SSD)
- Le temps de vol pour la méthode neutrons à temps de vol (TOF)
- Dans tous les cas, les données peuvent aussi être traitées en interne après conversion en distance interréticulaire \( d \) ou en vecteur de diffusion \( q \)

L'axe vertical est l'intensité de diffraction, qui peut être affichée en coups bruts (`Raw Counts`) ou en coups par pas (`Count per Step (CPS)`), sur une échelle linéaire ou logarithmique (voir `Vertical Axis` (Axe vertical) sur la page [Fenêtre principale](1-main-window.md)).

## Formats d'entrée pris en charge

`File ▸ Read profile(s)` (Fichier ▸ Lire le(s) profil(s)) charge le format propre à PDIndexer ainsi que les sorties d'autres programmes et des formats texte génériques.

| Extension | Contenu |
| --- | --- |
| `pdi` / `pdi2` | Format de profil natif de PDIndexer (inclut les réglages d'axe et les informations de traitement) |
| `csv` | Sortie WinPIP (séparée par des virgules) |
| `chi` | Sortie Fit2D |
| `tsv` | Texte séparé par des tabulations |
| `ras` | Format Rigaku (RAS) |
| `nxs` | Format NeXus |
| `npd` / `xbm` / `rpt` (`rpf`) | Données brutes SSD (détecteur à semi-conducteur) |
| Autre texte | Tout texte à deux colonnes angle (ou valeur d)–intensité est généralement lisible |

!!! note "Lecture de texte générique"
    Les fichiers stockés sous forme de texte angle–intensité peuvent généralement être lus même s'ils ne correspondent à aucun des formats standard ci-dessus. Si le type d'axe horizontal ou la longueur d'onde/énergie ne peut pas être déterminé, indiquez-les dans la boîte de dialogue `Data Converter` (Convertisseur de données) décrite ci-dessous.

La spécification détaillée de chaque format est rassemblée dans [Formats de fichier](appendix/file-formats.md).

## Comment charger

Les profils peuvent être chargés de plusieurs façons.

- **Menu** — `File ▸ Read profile(s)` (Fichier ▸ Lire le(s) profil(s)). Plusieurs fichiers peuvent être sélectionnés à la fois.
- **Glisser-déposer** — Déposez des fichiers depuis l'Explorateur sur la fenêtre principale.
- **Surveiller le presse-papiers** — Lorsque `Option ▸ Watch Clipboard` (Options ▸ Surveiller le presse-papiers) est activé, les profils/cristaux copiés depuis d'autres applications (par ex. IPAnalyzer ou CSManager) sont importés automatiquement.
- **Surveiller le fichier** — Lorsque `Option ▸ Watch File` (Options ▸ Surveiller le fichier) est activé et qu'un dossier est choisi avec `Set Directory to the watch` (Définir le répertoire à surveiller), les nouveaux fichiers de profil `pdi` créés dans ce dossier sont lus automatiquement. Ceci est pratique pour l'affichage en temps réel lors d'une mesure en continu.

!!! tip "Aligner automatiquement l'axe horizontal"
    Cocher `After reading profile, change horizontal axis` (Après lecture du profil, changer l'axe horizontal) fait basculer l'affichage de l'axe horizontal pour correspondre au profil nouvellement chargé immédiatement après sa lecture.

## Mode Profil unique et mode Profils multiples

Changez de mode d'affichage avec `Single/Multi Profile` (Profil unique/multiple) sur le côté droit de la fenêtre principale.

- **`Single Profile` (Profil unique)** — Le chargement d'un nouveau profil remplace les données précédentes ; un seul profil est affiché à la fois.
- **`Multi Profiles` (Profils multiples)** — Les profils chargés sont superposés. Utilisez `Increasing intensity by a profile` (Décalage d'intensité par profil) pour décaler légèrement l'intensité de chaque profil afin de mieux distinguer les multiples courbes. L'activation de `Change automatically color` (Changer la couleur automatiquement) attribue automatiquement une couleur de tracé à chaque profil.

## Liste de contrôle des profils

La liste `Profile` (Profil) sur le côté gauche de la fenêtre principale affiche tous les profils chargés.

- Seuls les profils cochés sont tracés dans le visualiseur central. Utilisez `Check/Uncheck all` (Tout cocher/décocher) pour les basculer tous en une fois.
- Cliquez sur la colonne `Color` (Couleur) pour changer la couleur de tracé de chaque profil.
- Réorganisez les entrées de la liste pour ajuster l'ordre de tracé de la superposition.
- La liste est désactivée en mode Profil unique et affiche plusieurs profils en mode Profils multiples.

Les réglages de profil plus détaillés (nom, style de ligne, lissage, soustraction du fond continu, correction d'axe, opérations sur les profils, etc.) se font dans la fenêtre [Paramètres du profil](4-profile-parameter.md), ouverte en cochant la case `Profile Parameter` (Paramètre de profil) sous la liste.

## Boîte de dialogue Data Converter

Lorsque vous chargez un fichier texte générique dont le type d'axe horizontal ne peut pas être déterminé, ou des données brutes SSD (à dispersion d'énergie), la boîte de dialogue `Data Converter` (Convertisseur de données) s'ouvre pour vous permettre de spécifier l'axe horizontal des données lues et ses paramètres associés.

![Boîte de dialogue Convertisseur de données avec les réglages d'axe horizontal, le temps d'exposition et les options EDX.](../assets/cap-fr-auto/FormDataConverter.png)

La boîte de dialogue règle les éléments suivants.

| Élément | Contenu |
| --- | --- |
| Réglage de l'axe horizontal | Spécifiez le type d'axe horizontal des données (longueur d'onde/énergie des rayons X, 2θ, longueur/angle TOF neutrons, etc.) et les paramètres de source correspondants. |
| `Exposure time (per step)` (Temps d'exposition (par pas)) | Temps d'exposition (de mesure) par pas de données, en secondes. Il sert à la conversion CPS ; les valeurs ≤ 0 sont traitées comme 1. |
| `Deconvolution` (Déconvolution) | La suppression de Kα2 a été déplacée vers le formulaire [Paramètres du profil](4-profile-parameter.md). Pour la supprimer, sélectionnez Kα1 comme source de rayons X. |
| `Low energy cutoff` (Coupure basse énergie) sous `For SSD data` (Pour les données SSD) | Élimine le côté basse énergie du spectre EDX en dessous du seuil (eV) à droite. |

Lorsque le type d'axe horizontal est à dispersion d'énergie (rayons X blancs, EDX), saisissez les coefficients d'étalonnage en énergie de `E = a₀ + a₁ n + a₂ n²` (E : énergie en eV, n : numéro de canal) pour convertir les numéros de canal en énergie. Cliquez sur `OK` pour appliquer les réglages et convertir les données, ou sur `Cancel` (Annuler) pour interrompre l'importation.

## Exporter les profils

- **`File ▸ Save profile(s)` (Fichier ▸ Enregistrer le(s) profil(s))** — Enregistre tous les profils chargés au format natif `pdi2` de PDIndexer. Les réglages d'axe et les informations de traitement sont préservés.
- **`File ▸ Export the selected profile(s)` (Fichier ▸ Exporter le(s) profil(s) sélectionné(s))** — Exporte le(s) profil(s) sélectionné(s) dans l'un des formats suivants :
  - `as CSV (comma separated values) file` (au format CSV (valeurs séparées par des virgules)) — séparé par des virgules (angle, intensité)
  - `as TSV (tab separated values) file` (au format TSV (valeurs séparées par des tabulations)) — séparé par des tabulations
  - `as GSAS file` (au format GSAS) — format de données GSAS (Rietveld)

!!! note "Enregistrer la figure"
    Pour enregistrer la figure rendue plutôt que les données de profil, utilisez `File ▸ Copy to Clipboard` (Fichier ▸ Copier dans le presse-papiers) ou `File ▸ Save as Metafile` (Fichier ▸ Enregistrer comme métafichier) (EMF). EMF est un format vectoriel qui peut être importé dans PowerPoint et Word.
