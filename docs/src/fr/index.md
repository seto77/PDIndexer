<!-- 260601Cl: English landing page for the PDIndexer Pages manual (content migrated from the legacy docx + yseto.net web manual). -->
<!-- 260625Cl: static-i18n folder mode へ移設 (docs/src/index.md → docs/src/en/index.md)。画像は ../assets、内部リンクは en/ 接頭辞を剥がす。 -->
# Manuel PDIndexer

**PDIndexer** est une application Windows gratuite, sous licence MIT, pour analyser les diagrammes de diffraction de poudre unidimensionnels (rayons X de laboratoire / synchrotron, neutrons TOF). Elle affiche les profils mesurés, superpose les raies de diffraction calculées à partir des structures cristallines, traite et corrige les profils, ajuste les pics pour affiner les paramètres de maille par la méthode des moindres carrés, et estime la pression à partir des équations d'état des matériaux étalons.

![Fenêtre principale de PDIndexer](../assets/cap-fr-auto/FormMain.png)

## Trouver par objectif

| Objectif | Commencer ici | Étapes suivantes principales |
|------|------------|-----------------|
| Charger et afficher un profil mesuré | [2. Profils de diffraction](2-pattern-profiles.md) | [1. Fenêtre principale](1-main-window.md), [Formats de fichier](appendix/file-formats.md) |
| Identifier les phases en superposant des cristaux connus | [3. Paramètres du cristal](3-crystal-parameter.md) | [2. Profils de diffraction](2-pattern-profiles.md) |
| Traiter / corriger un profil | [4. Paramètres du profil](4-profile-parameter.md) | [3. Paramètres du cristal](3-crystal-parameter.md) |
| Ajuster les pics et affiner les paramètres de maille | [6. Ajustement des pics de diffraction](6-fitting-diffraction-peaks.md) | [3. Paramètres du cristal](3-crystal-parameter.md) |
| Estimer la pression à partir d'un matériau étalon | [5. Équations d'état](5-equation-of-states.md) | [6. Ajustement des pics de diffraction](6-fitting-diffraction-peaks.md) |
| Traiter par lot une série de profils | [7. Analyse séquentielle](7-sequential-analysis.md) | [8. Macro](8-macro.md) |
| Automatiser des tâches avec des scripts | [8. Macro](8-macro.md) | [7. Analyse séquentielle](7-sequential-analysis.md) |

## Sommaire

- [0. Présentation](0-overview.md) — ce que fait PDIndexer et ses principales fonctionnalités
- [1. Fenêtre principale](1-main-window.md) — disposition, menus, barre d'outils, listes de profils/cristaux
- [2. Profils de diffraction](2-pattern-profiles.md) — données de profil, formats pris en charge, chargement
- [3. Paramètres du cristal](3-crystal-parameter.md) — affichage des raies de diffraction, informations sur le cristal, base de données
- [4. Paramètres du profil](4-profile-parameter.md) — traitement des profils, réglages d'axes, opérateurs
- [5. Équations d'état](5-equation-of-states.md) — pression à partir de l'EOS d'un matériau étalon
- [6. Ajustement des pics de diffraction](6-fitting-diffraction-peaks.md) — ajustement des pics et affinement de la maille
- [7. Analyse séquentielle](7-sequential-analysis.md) — analyse par lot sur une série de profils
- [8. Macro](8-macro.md) — script IronPython et référence des fonctions

### Annexe

- [Environnement d'exécution et installation](appendix/runtime-and-installation.md)
- [Formats de fichier](appendix/file-formats.md)
- [Dépannage](appendix/troubleshooting.md)

## Démarrage rapide

1. Téléchargez et installez depuis les [Releases](https://github.com/seto77/PDIndexer/releases/latest), puis lancez *PDIndexer*.
2. Ouvrez un profil mesuré (glissez-déposez un fichier, ou collez un profil copié depuis [IPAnalyzer](https://github.com/seto77/IPAnalyzer)).
3. Ajoutez des cristaux connus depuis la base de données intégrée (ou importez un fichier CIF/AMC) pour superposer leurs raies de diffraction.
4. Ajustez les pics pour affiner les paramètres de maille, ou estimez la pression à partir de l'équation d'état d'un matériau étalon.

## Configuration requise

| Élément | Exigence |
|------|-------------|
| OS | Windows avec le [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) (**et non** le .NET Runtime) |
| Recommandé | Windows 10/11 64 bits, 16 Go de mémoire ou plus, processeur 8 cœurs ou plus |

Voir [Environnement d'exécution et installation](appendix/runtime-and-installation.md) pour plus de détails.

!!! note
    Le code source, les versions et le suivi des problèmes sont sur [GitHub](https://github.com/seto77/PDIndexer). PDIndexer est distribué sous la [licence MIT](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md).
