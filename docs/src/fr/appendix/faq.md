<!-- 261124Cl added: Q&A page, compiled anonymously from GitHub issues and support e-mails to the author (2006–2026); reviewed with codex2 (2 rounds). Lead language: ja/appendix/faq.md. fr translated from en -->
# Q&A

Cette page rassemble des questions réellement posées par les utilisateurs, en privilégiant les plus fréquentes et les points faciles à mal comprendre. Pour les erreurs et les problèmes de démarrage, voir aussi [Dépannage](troubleshooting.md).

## Ce qu'il faut essayer d'abord {#first-steps}

### Quelque chose ne va pas (aucune raie de diffraction n'apparaît, un fichier ne peut pas être lu, une erreur apparaît au démarrage). Que dois-je essayer d'abord ?

Cherchez d'abord sur cette page l'entrée qui correspond à votre symptôme. Lorsqu'aucune raie de diffraction n'apparaît, la cause est presque toujours le réglage du rayonnement ou de la longueur d'onde ([Raies de diffraction et liste des cristaux](#peaks-and-crystals)). Si cela ne suffit pas, essayez ce qui suit, dans cet ordre.

1. Passez à la dernière version (`Aide` ▸ `Rechercher des mises à jour`, ou téléchargez-la depuis la [page des versions](https://github.com/seto77/PDIndexer/releases/latest)).
2. Cochez `Options` ▸ `Effacer le registre (cocher et redémarrer)`, puis quittez et relancez PDIndexer. PDIndexer enregistre dans le registre les positions des fenêtres, les réglages du faisceau, etc., et des réglages hérités d'une ancienne version peuvent causer des problèmes.
3. Si la liste des cristaux semble incorrecte, exécutez `Fichier` ▸ `Rétablir les cristaux à l'état initial`.

!!! warning "Ce qui est perdu"
    - **Effacer le registre** supprime les réglages enregistrés et **les macros enregistrées dans la fenêtre des macros**. Exportez d'abord les macros dont vous avez besoin sous forme de fichiers `.mcr`. La liste des cristaux n'est pas stockée dans le registre mais dans un fichier séparé (`%APPDATA%\PDIndexer\PDIndexer\default.xml`) ; effacer le registre ne la supprime donc pas.
    - **Rétablir la liste des cristaux** abandonne les cristaux que vous avez ajoutés ou modifiés. Enregistrez d'abord les cristaux dont vous avez besoin avec `Fichier` ▸ `Enregistrer les cristaux`.

### Lorsque j'utilise PDIndexer avec IPAnalyzer, j'obtiens des erreurs ou des valeurs incorrectes.

[IPAnalyzer](https://github.com/seto77/IPAnalyzer) et PDIndexer partagent une bibliothèque commune et échangent des données via le presse-papiers. Si un seul des deux est mis à jour, le format d'échange peut ne plus correspondre, ce qui peut provoquer des erreurs ou des valeurs incorrectes. **Mettez les deux à jour en même temps.**

## Installation et démarrage {#install}

### Je ne peux pas installer PDIndexer sur un PC sans droits d'administrateur, ou une stratégie bloque le MSI.

Utilisez le **paquet ZIP sans installation** (`PDIndexer-v.<ver>.zip` pour x64, `PDIndexer-v.<ver>_arm64.zip` pour Arm64). Il inclut le runtime : vous n'avez besoin ni du MSI ni d'un .NET Desktop Runtime installé séparément. Extrayez le dossier complet vers un emplacement accessible en écriture et exécutez `PDIndexer.exe` dans le dossier extrait. PDIndexer lui-même fonctionne avec des droits d'utilisateur ordinaires.

Voir [Runtime et installation](runtime-and-installation.md) pour les différences entre les paquets MSI et ZIP.

!!! note
    PDIndexer est un logiciel de recherche non signé ; Windows (SmartScreen) ou votre navigateur peut donc afficher un avertissement lors du téléchargement ou de la première exécution. Dans la liste des téléchargements du navigateur, choisissez **Informations complémentaires** ▸ **Conserver** ; lors de l'avertissement à l'exécution, choisissez **Informations complémentaires** ▸ **Exécuter quand même**.

### Le message « You must install .NET Desktop Runtime » s'affiche, alors que j'ai installé .NET.

La cause est généralement l'une des suivantes.

- **Mauvaise version majeure.** La version de .NET requise change d'une version de PDIndexer à l'autre. Installez le **Desktop Runtime** de la version indiquée pour la version de PDIndexer que vous utilisez. Le simple « .NET Runtime » ne suffit pas.
- **Mauvaise architecture.** La version x64 de PDIndexer nécessite le runtime x64 ; la version Arm64 nécessite le runtime Arm64. Sous Windows sur Arm (PC Snapdragon, etc.), utilisez le programme d'installation Arm64 `PDIndexer-setup_arm64.msi`.
- Si cela ne fonctionne toujours pas, le **paquet ZIP sans installation**, qui inclut le runtime, est le choix le plus sûr.

## Raies de diffraction et liste des cristaux {#peaks-and-crystals}

### Je coche un cristal mais aucune raie de diffraction n'apparaît, ou elles sont très décalées.

Vérifiez d'abord les points suivants.

- [`Afficher les pics sur les profils`](../3-crystal-parameter.md) est activé, et le cristal est coché dans la liste des cristaux.
- **Le rayonnement et la longueur d'onde (ou l'énergie) de la mesure sont réglés correctement.** Les données texte comme les CSV ne contiennent souvent aucune information de longueur d'onde ; dans ce cas, indiquez le rayonnement et la longueur d'onde utilisés pour la mesure dans la boîte de dialogue affichée à la lecture du fichier. Vérifiez le rayonnement et la longueur d'onde utilisés pour l'affichage dans l'[onglet `Axe horizontal`](../1-main-window.md#horizontal-axis-tab) de la fenêtre principale.
- Les raies ne sont pas en dehors de la plage de tracé. Essayez d'élargir la plage horizontale (en particulier pour le TOF neutronique).
- Si un seul cristal n'apparaît pas, vérifiez que ses paramètres de maille et ses positions atomiques ne sont pas très éloignés des bonnes valeurs, et comparez-le avec la même substance dans la base de données intégrée.

### J'ai fait glisser une raie de diffraction et les paramètres de maille ont changé. Un redémarrage ne les rétablit pas.

Les paramètres de maille modifiés en faisant glisser une raie de diffraction sont enregistrés à la fermeture de PDIndexer, car `Options` ▸ `Enregistrer la liste des cristaux à la fermeture` est activé par défaut. Un redémarrage n'annule donc pas la modification.

- Pour revenir aux paramètres de maille qu'avait le cristal lors de son chargement dans la session en cours, faites un clic droit sur les informations du cristal et choisissez `Rétablir les paramètres de maille`.
- Pour ramener toute la liste des cristaux à son état juste après l'installation, choisissez `Fichier` ▸ `Rétablir les cristaux à l'état initial`.

### La liste des cristaux contient des valeurs étranges ou des doublons, ou un étalon de pression (Au, Pt, etc.) a disparu.

`Fichier` ▸ `Rétablir les cristaux à l'état initial` restaure la liste initiale des cristaux, y compris les étalons de pression. Les cristaux que vous avez ajoutés vous-même sont perdus ; enregistrez-les d'abord si nécessaire.

### Les rapports d'intensité ne sont pas calculés ; toutes les raies ont la même hauteur.

Pour calculer les rapports d'intensité, le cristal doit avoir des positions atomiques et [`Calculer le rapport d'intensité`](../3-crystal-parameter.md) doit être activé. Des réglages de rayonnement incorrects donnent aussi des intensités incorrectes. Voir [Dépannage](troubleshooting.md) pour plus de détails.

### Comment importer des cristaux depuis CSManager ou depuis des fichiers CIF ?

- **Depuis CSManager** : ouvrez la fenêtre `Paramètres du cristal` de PDIndexer et activez d'abord `Options` ▸ `Surveiller le presse-papiers`, puis sélectionnez le cristal dans CSManager. Il n'est pas nécessaire d'exporter d'abord un fichier CIF.
- Les **fichiers CIF / AMC** peuvent être glissés-déposés sur la zone des informations sur le cristal de la fenêtre Paramètres du cristal.
- Vous pouvez aussi faire une recherche dans la **base de données cristallines intégrée** (AMCSD). Voir [Paramètres du cristal](../3-crystal-parameter.md).

Dans tous les cas, le cristal apparaît dans la zone des informations sur le cristal. Appuyez sur `Ajouter` pour le conserver dans la liste des cristaux.

### Puis-je superposer des données de rayons X et des données d'électrons (ou d'une autre longueur d'onde) sur le même axe horizontal ?

Oui. PDIndexer possède un seul axe horizontal, et chaque profil chargé est converti dans le rayonnement et la longueur d'onde choisis dans l'onglet `Axe horizontal`. Par exemple, un profil de diffraction électronique peut être affiché sur l'échelle 2θ de Cu Kα.

Si `Après lecture du profil, changer l'axe horizontal` est activé dans l'onglet `Axe horizontal`, les réglages d'axe passent à ceux de chaque fichier nouvellement chargé. Désactivez cette option pour conserver un axe fixe pour la comparaison.

## Lecture des profils et axe horizontal {#profiles-and-axis}

### Quelle est la différence entre l'onglet `Axe horizontal` de la fenêtre principale et `Réglage des axes` dans la fenêtre Paramètres du profil ?

- L'**onglet `Axe horizontal`** (fenêtre principale) décide seulement **de la façon dont les données sont affichées** ; les données du profil elles-mêmes ne changent pas.
- **[`Réglage des axes`](../4-profile-parameter.md#axis-setting)** (fenêtre Paramètres du profil) réécrit **les conditions dans lesquelles le profil a été mesuré** (type de rayonnement, longueur d'onde, angle de sortie, etc.). Si vous avez choisi un rayonnement ou une longueur d'onde incorrects à la lecture du fichier, corrigez-les ici. Si vous avez saisi des valeurs dans une **unité** incorrecte, relisez le fichier d'origine.

### Les données à dispersion d'énergie (rayons X blancs) (`.npd` / `.nxs`) ont un axe horizontal incorrect, ou aucune raie de diffraction n'apparaît.

Dans la boîte de dialogue affichée à la lecture du fichier, vérifiez que l'**unité d'énergie (eV / keV)**, le **2θ** et, pour `.nxs`, les **coefficients d'étalonnage canal-énergie** correspondent à la mesure. Les fichiers `.npd` utilisent la colonne d'énergie du fichier ; vérifiez donc aussi les valeurs et l'unité dans le fichier d'origine. Une unité incorrecte décale fortement les positions des pics.

### PDIndexer peut-il lire les fichiers GSAS `.gsa` (2θ en centidegrés) ou des données sur un axe q (nombre d'onde) ?

Oui.

- Pour un fichier `.gsa` (trois colonnes séparées par des espaces, avec 2θ en centidegrés), choisissez 2θ comme axe horizontal et les centidegrés (centi-degree) comme unité dans la boîte de dialogue de conversion des données.
- Pour des données sur un axe q (nombre d'onde), choisissez q comme axe horizontal. Vous pouvez aussi affiner les paramètres de maille sur l'axe q.

## Ajustement des pics et paramètres de maille {#fitting}

### Quelle valeur utiliser pour `Plage de recherche` ? Le volume change quand je la modifie.

`Plage de recherche` est la largeur de recherche de chaque côté du centre du pic. Commencez par **2 à 3 fois la largeur à mi-hauteur (FWHM)** du pic, et réduisez-la si le pic voisin se chevauche. Une plage trop large capte d'autres pics ou le fond continu, et une plage trop étroite coupe les queues du pic ; dans les deux cas, la position ajustée est décalée. Utiliser de nombreux **pics aux grands angles** améliore la précision des paramètres de maille.

### Les valeurs affichées dans `Paramètres de maille optimisés` sont-elles déjà appliquées au cristal ?

Non. `Paramètres de maille optimisés` ne fait qu'**afficher** les valeurs obtenues à partir des réflexions sélectionnées et des conditions d'ajustement. Pour remplacer les paramètres de maille du cristal, appuyez sur `Appliquer au cristal`. Pour utiliser les valeurs sans modifier le cristal, utilisez `Copier dans le presse-papiers`. Appuyer plusieurs fois sur `Appliquer au cristal` peut aider la convergence, car les positions calculées des raies sont mises à jour à chaque fois.

### Je sélectionne les mêmes réflexions, mais l'erreur sur le volume devient soudain grande.

L'ajustement des pics (ajustement d'une fonction à chaque pic) et l'affinement des paramètres de maille sont des calculs distincts. PDIndexer cherche seulement un pic à l'intérieur de la plage de recherche de chaque réflexion ; si un pic d'une autre phase ou du bruit tombe dans cette plage, une valeur d erronée entre dans le calcul des paramètres de maille.

- Vérifiez l'ajustement de chaque réflexion dans la liste des réflexions et excluez les pics douteux ou faibles.
- Lorsque le rapport signal/bruit est mauvais, affinez d'abord avec les pics intenses seulement, puis ajoutez les pics plus faibles. Il faut au moins autant de réflexions indépendantes qu'il y a de paramètres de maille indépendants pour le système cristallin (1 pour le cubique, 6 pour le triclinique), et davantage pour estimer les erreurs.
- Pour des diagrammes faibles ou fortement chevauchants, un ajustement de tout le diagramme, comme l'analyse Rietveld, peut être plus adapté.

Voir [Algorithmes](algorithms.md#lattice-refinement) pour la façon dont les paramètres de maille et leurs erreurs sont calculés.

## Analyse séquentielle et macros {#sequential-and-macro}

### Je veux ajuster automatiquement de nombreux profils (résolus en temps, paliers de pression, etc.) et obtenir les paramètres de maille ou les pressions.

Utilisez l'[Analyse séquentielle](../7-sequential-analysis.md) (ouvrez-la depuis la barre d'outils de la fenêtre principale ou avec `Ctrl+Shift+S`). **Ouvrez la fenêtre d'ajustement des pics** et choisissez le cristal et les réflexions avant de la lancer. Il faut au moins quatre profils. Les résultats peuvent être enregistrés automatiquement.

- Lire des milliers de profils à la fois consomme beaucoup de mémoire. Fixez d'abord les conditions avec une centaine de profils, puis lancez l'ensemble.
- La lecture directe depuis un dossier réseau est lente. Copiez les fichiers sur un disque local avant l'analyse.
- Si les paramètres de maille changent beaucoup au cours de la série, un pic peut sortir de sa plage de recherche et un autre pic peut être capté. Avec `Facteur de tolérance` activé, les points dont le volume diffère de **celui du début de l'exécution** de plus de la valeur réglée (%) sont sortis comme NaN.

### L'analyse séquentielle peut-elle ajuster plusieurs phases (par ex. l'échantillon et un marqueur de pression) en même temps ?

Les pics de tous les cristaux cochés sont ajustés (avec la décomposition du diagramme réglée sur `entre les cristaux`, les pics de phases différentes qui se chevauchent sont séparés ensemble). Cependant, chaque exécution séquentielle n'enregistre les paramètres de maille et la pression que pour le seul cristal sélectionné dans la fenêtre d'ajustement des pics. Pour obtenir les résultats d'une autre phase, sélectionnez ce cristal et relancez, ou utilisez une [macro](../8-macro.md) qui passe d'un cristal à l'autre.

### J'ai lancé une analyse de contrainte sur des profils découpés par azimut, mais l'onglet `Équation de Singh` est vide.

Le mode analyse de contrainte n'est sélectionné que lorsque **le nom du premier profil de la liste des profils se termine par `whole`**. Pour le deuxième profil et les suivants, le texte **après le dernier trait d'union** du nom est lu comme l'azimut en degrés (par ex. `sample-30`). Vérifiez aussi qu'au moins quatre profils sont chargés et que la fenêtre d'ajustement des pics est ouverte. Lors d'une exécution ordinaire (hors mode contrainte), l'onglet `Équation de Singh` reste vide. Voir [Analyse séquentielle](../7-sequential-analysis.md) pour plus de détails.

### Avec la virgule comme séparateur décimal, les colonnes du CSV de l'analyse séquentielle sont décalées.

Le CSV de l'analyse séquentielle réutilise les nombres affichés à l'écran ; avec une virgule comme séparateur décimal (`1,5`), les décimales ne peuvent donc pas être distinguées des séparateurs de colonnes. Pour l'instant, utilisez `Copier` dans l'onglet de résultats pour copier le tableau en texte séparé par des tabulations, et collez-le dans votre tableur comme données séparées par des tabulations. L'exportation CSV des profils eux-mêmes (`Fichier` ▸ `Exporter le(s) profil(s) sélectionné(s)`) écrit toujours `.` comme séparateur décimal, quels que soient les paramètres régionaux.

### Dans quel langage les macros sont-elles écrites ? Comment écrire les chemins de fichier ?

Les macros sont écrites en **Python (IronPython)**. Écrivez les chemins Windows avec des barres obliques (`'C:/data/sample.pdi2'`) ou sous forme de chaînes brutes (`r'C:\data\sample.pdi2'`). Les fonctions disponibles sont répertoriées dans la référence des fonctions de [Macro](../8-macro.md).

## Équations d'état {#eos}

### J'ai saisi une température. Le résultat est-il valable comme pression à haute température ?

Certaines équations d'état (EOS) n'ont pas de terme de température dans l'article d'origine (équations isothermes), et la température saisie n'est pas utilisée. Les EOS qui interpolent des tables de la littérature donnent des **pressions inexactes en dehors de la plage de température et de volume de la table**. Vérifiez la source et le domaine de validité de l'EOS dans [Équations d'état](../5-equation-of-states.md).

## Autres questions {#others}

### Que dois-je envoyer pour signaler un bogue ?

Signalez-le dans les [GitHub Issues](https://github.com/seto77/PDIndexer/issues) avec les éléments suivants.

- La version de PDIndexer (`Aide` ▸ `À propos de PDIndexer`) et la version de Windows
- Un jeu de fichiers minimal et partageable qui reproduit le problème (profils, `.xml` de la liste des cristaux, fichiers de réglages d'IPAnalyzer, etc.)
- Les étapes que vous avez suivies, et le message d'erreur ou une capture d'écran
- Le résultat attendu (la valeur que vous pensez correcte)

### Puis-je présenter ou redistribuer PDIndexer sur une page web de ligne de lumière ou de laboratoire ?

Oui. PDIndexer est distribué sous la [licence MIT](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md). Lorsque vous le redistribuez, incluez la mention de copyright et le texte de la licence.
