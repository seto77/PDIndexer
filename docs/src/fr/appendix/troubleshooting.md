<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Dépannage

Si vous rencontrez un problème lors de l'utilisation de PDIndexer, vérifiez d'abord les points ci-dessous. La plupart des problèmes se résolvent en installant le runtime ou en revoyant un paramètre.

## L'application ne démarre pas

PDIndexer nécessite le **.NET Desktop Runtime 10.0**. Si le runtime n'est pas installé, une erreur peut s'afficher au démarrage, ou le programme peut se fermer sans rien faire.

!!! warning "Solution"
    Suivez [Runtime et installation](runtime-and-installation.md) pour installer le dernier **.NET Desktop Runtime 10.0** (x64), puis redémarrez PDIndexer.

## La langue de l'interface ne change pas

Vous pouvez changer la langue de l'interface depuis le menu **Options** ▸ **Langue**, en choisissant **English (need restart)** ou **Japanese (need restart)**. Cependant, un changement de langue ne prend effet qu'**après un redémarrage**.

!!! note
    Il est normal que l'affichage ne change pas immédiatement après avoir choisi une langue. Fermez PDIndexer et relancez-le.

## Réinitialiser des paramètres corrompus

Les positions des fenêtres, les réglages de couleur et diverses options sont enregistrés dans le registre. Si les paramètres deviennent corrompus et que le programme se comporte mal, vous pouvez effacer le registre pour revenir à l'état initial.

1. Dans le menu, cochez **Options** ▸ **Effacer le registre (cocher et redémarrer)**.
2. Fermez PDIndexer. Tous les paramètres enregistrés sont effacés à la sortie.
3. Relancez PDIndexer ; il démarrera dans son état initial (par défaut).

!!! warning
    Cette opération efface tous les paramètres enregistrés, y compris la disposition des fenêtres et les options. Elle ne peut pas être annulée tant que vous n'avez pas redémarré et que les paramètres ne sont pas réinitialisés.

## L'import depuis le presse-papiers d'IPAnalyzer / CSManager ne fonctionne pas

Les profils et cristaux copiés dans des applications sœurs comme [IPAnalyzer](https://github.com/seto77/IPAnalyzer) et [CSManager](https://github.com/seto77/CSManager) peuvent être importés automatiquement dans PDIndexer via le presse-papiers. Si rien n'est importé, la surveillance du presse-papiers est peut-être désactivée.

- Vérifiez que **Options** ▸ **Surveiller le presse-papiers** est activé dans le menu.
- Lorsque cette option est activée, les profils/cristaux copiés depuis d'autres applications sont lus automatiquement.

!!! tip
    Si vous souhaitez lire automatiquement les fichiers `.pdi` nouvellement créés dans un dossier spécifique, utilisez **Options** ▸ **Surveiller le fichier**.

## Les rapports d'intensité ne sont pas calculés

Pour calculer les intensités théoriques de diffraction, la structure cristalline doit contenir des **positions atomiques (coordonnées atomiques)**. Si les positions atomiques ne sont pas saisies, les positions des pics (valeurs \(d\)) peuvent toujours être calculées, mais pas les rapports d'intensité.

!!! note "Solution"
    Dans [Paramètres du cristal](../3-crystal-parameter.md), saisissez l'élément, les coordonnées et l'occupation de chaque atome. Une fois les positions atomiques saisies, les rapports d'intensité sont calculés à partir du facteur de structure.

## L'ajustement renvoie des paramètres de maille NA (non disponibles)

Lors de l'affinement des paramètres de maille par ajustement des pics, un nombre insuffisant de réflexions indépendantes peut laisser les paramètres de maille indéterminés, et le résultat peut être indiqué comme NA (non disponible).

- Selon le système cristallin, vous devez fournir suffisamment de réflexions pour que le nombre de paramètres de maille indépendants puisse être déterminé (par exemple, seulement \(a\) pour le cubique, mais six valeurs \(a, b, c, \alpha, \beta, \gamma\) pour le triclinique).
- Si les réflexions sont linéairement dépendantes (biaisées vers une seule direction), certains paramètres de maille ne peuvent pas être déterminés. Incluez des réflexions d'orientations différentes.

!!! note "Solution"
    Consultez [Ajustement des pics de diffraction](../6-fitting-diffraction-peaks.md) et assurez-vous que l'ajustement inclut suffisamment de réflexions indépendantes.

## Toujours pas résolu

Pour les problèmes que les étapes ci-dessus ne résolvent pas, ou pour les bogues reproductibles et les demandes de fonctionnalités, veuillez les signaler sur le suivi des problèmes GitHub. Si possible, incluez les étapes pour reproduire, le fichier que vous avez utilisé et une capture d'écran.

- Suivi des problèmes : <https://github.com/seto77/PDIndexer/issues>
