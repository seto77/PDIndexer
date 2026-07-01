<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Vue d'ensemble

![Fenêtre principale de PDIndexer](../assets/cap-fr-auto/FormMain.png)

PDIndexer est une application logicielle dédiée à l'analyse des diagrammes de diffraction de poudre de rayons X unidimensionnels. Elle permet d'afficher et d'analyser les profils de diffraction obtenus à partir d'instruments de diffraction de poudre de rayons X, de rayons X synchrotron mesurés en optique de transmission Debye-Scherrer, et de mesures de neutrons par temps de vol (TOF).

Elle fournit un ensemble complet d'outils pour l'analyse de la diffraction de poudre, notamment l'affichage superposé de plusieurs profils, la comparaison avec les raies de diffraction de cristaux connus, l'étalonnage en température et en pression par rapport à des matériaux étalons, l'ajustement des profils et l'affinement par moindres carrés des paramètres de maille.

!!! note "À propos de ce manuel"
    Cette page n'est qu'une vue d'ensemble. Pour des instructions détaillées sur chaque fonctionnalité, reportez-vous aux pages dédiées.

## Fonctionnalités principales

PDIndexer offre les fonctionnalités suivantes.

| Fonctionnalité | Description |
| --- | --- |
| Affichage et comparaison des profils | Superposez et comparez plusieurs profils de diffraction. Les échelles de l'axe horizontal (\(2\theta\) / \(d\) / \(q\)) et de l'axe vertical peuvent être commutées de manière flexible. |
| Comparaison avec des cristaux connus | Calculez les raies de diffraction de cristaux connus et superposez-les au profil observé pour l'identification. Voir [Paramètres du cristal](3-crystal-parameter.md) pour plus de détails. |
| Étalonnage avec des étalons | À l'aide d'équations d'état (EOS) telles que NaCl EOS et Pt EOS, estimez la température et la pression à partir du volume de maille d'un matériau étalon. Voir [Équation d'état (EOS)](5-equation-of-states.md) pour plus de détails. |
| Ajustement des pics | Ajustez la position, la largeur à mi-hauteur (FWHM) et l'intensité des pics de diffraction. Voir [Ajustement des pics de diffraction](6-fitting-diffraction-peaks.md) pour plus de détails. |
| Affinement des paramètres de maille | Affinez les paramètres de maille à partir des positions des pics par moindres carrés. Le **Cell Finder** peut également rechercher les paramètres de maille à partir des positions des pics. |
| Analyse séquentielle | Traitez par lots une série de fichiers grâce à la fonctionnalité **Analyse séquentielle**. Voir [Analyse séquentielle](7-sequential-analysis.md) pour plus de détails. |
| Importation / exportation | Importez des structures cristallines depuis des fichiers CIF et AMC, et exportez aux formats CSV, TSV et GSAS (Rietveld). |
| Chargement automatique | Surveillez le presse-papiers ou un dossier pour lire automatiquement les profils/cristaux copiés depuis d'autres applications (par ex. IPAnalyzer) ou les fichiers nouvellement créés. |

!!! tip "Données prises en charge"
    Une large gamme de profils peut être traitée, notamment ceux issus d'instruments de diffraction de poudre de rayons X, de rayons X synchrotron (optique de transmission Debye-Scherrer) et de mesures de neutrons par temps de vol (TOF).

## Licence

Ce logiciel est distribué sous **licence MIT** ([LICENSE.md](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md)). Toute personne est libre d'utiliser ce logiciel gratuitement, à condition d'accepter les conditions suivantes.

- Vous pouvez librement copier, distribuer, modifier, redistribuer des versions modifiées, utiliser à des fins commerciales, vendre contre rémunération ou utiliser le logiciel de toute autre manière.
- Lors de la redistribution, incluez la mention de copyright de ce logiciel et le texte intégral de cette licence dans le code source, ou dans un fichier de licence séparé fourni avec le code source.
- Ce logiciel est fourni sans aucune garantie. L'auteur n'assume aucune responsabilité pour les problèmes découlant de l'utilisation de ce logiciel.

## Retours

Veuillez envoyer vos commentaires et demandes via les [Issues](https://github.com/seto77/PDIndexer/issues) GitHub. Le code source est publié sur [github.com/seto77/PDIndexer](https://github.com/seto77/PDIndexer).

## Installation et configuration requise

PDIndexer nécessite un système d'exploitation Windows capable d'exécuter le **.NET Desktop Runtime 6.0 ou ultérieur**. Certaines fonctionnalités requièrent des ressources de calcul importantes ; le multithreading et l'accélération GPU sont utilisés pour améliorer les performances. Pour un usage confortable, un Windows 10/11 64 bits avec 16 Go de mémoire ou plus et un processeur de 8 cœurs ou plus est recommandé.

Pour les étapes d'installation détaillées et la configuration requise, voir [Environnement d'exécution et installation](appendix/runtime-and-installation.md).
