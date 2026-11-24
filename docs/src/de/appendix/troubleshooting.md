<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Fehlerbehebung

Wenn bei der Verwendung von PDIndexer ein Problem auftritt, prüfen Sie zuerst die folgenden Punkte. Die meisten Probleme lassen sich durch die Installation der Runtime oder durch Überprüfen einer Einstellung beheben.

## Die Anwendung startet nicht

Diese Anforderungen gelten für .NET-11-Builds aus diesem Quellstand. Beachten Sie bei veröffentlichten Versionen die jeweils angegebene Laufzeitanforderung.

Die MSI-Installation von PDIndexer benötigt die von der jeweiligen Version angegebene **.NET Desktop Runtime** (Builds aus diesem Quellbaum zielen auf .NET 11). Das installationsfreie ZIP enthält seine Laufzeitumgebung. Wenn die Runtime bei einer MSI-Installation nicht installiert ist, wird beim Start möglicherweise ein Fehler angezeigt, oder das Programm wird beendet, ohne etwas zu tun.

!!! warning "Lösung"
    Folgen Sie [Runtime und Installation](runtime-and-installation.md), um die von der verwendeten Version benötigte **.NET Desktop Runtime** passend zur Architektur der Anwendung (x64 oder Arm64) zu installieren, und starten Sie PDIndexer anschließend neu.

## Die UI-Sprache wechselt nicht

<!-- 261124Cl changed: the old text described an English/Japanese choice and a manual restart; now there are 11 languages and PDIndexer restarts itself after a confirmation dialog -->
Wählen Sie die Anzeigesprache (11 Sprachen, jeweils mit ihrem eigenen Namen angezeigt) über **Sprache** am rechten Ende der Menüleiste. Der Sprachwechsel erfordert einen Neustart: Wählen Sie im Bestätigungsdialog **Ja**, und PDIndexer startet automatisch in der gewählten Sprache neu.

!!! note
    Der Neustart verwirft nicht gespeicherte Arbeit (geladene Profile und laufende Bearbeitungen); speichern Sie daher vor dem Wechsel, was Sie benötigen. Wenn Sie **Nein** wählen, ändert sich die Sprache nicht.

## Beschädigte Einstellungen zurücksetzen

Fensterpositionen, Farbeinstellungen und verschiedene Optionen werden in der Registry gespeichert. Wenn die Einstellungen beschädigt werden und sich das Programm fehlerhaft verhält, können Sie die Registry löschen, um in den Ausgangszustand zurückzukehren.

1. Setzen Sie im Menü unter **Optionen** ▸ **Registry löschen (anhaken und neu starten)** ein Häkchen.
2. Schließen Sie PDIndexer. Beim Beenden werden alle gespeicherten Einstellungen gelöscht.
3. Starten Sie PDIndexer erneut; es wird im anfänglichen (Standard-)Zustand gestartet.

!!! warning
    Dadurch werden alle gespeicherten Einstellungen gelöscht, einschließlich Fensterlayout und Optionen. Dies kann nicht rückgängig gemacht werden, bis Sie neu starten und die Einstellungen zurückgesetzt werden.

## Zwischenablage-Import aus IPAnalyzer / CSManager funktioniert nicht

Profile und Kristalle, die in Schwester-Apps wie [IPAnalyzer](https://github.com/seto77/IPAnalyzer) und [CSManager](https://github.com/seto77/CSManager) kopiert wurden, können über die Zwischenablage automatisch in PDIndexer importiert werden. Wenn nichts importiert wird, ist möglicherweise die Zwischenablage-Überwachung deaktiviert.

- Prüfen Sie, ob im Menü **Optionen** ▸ **Zwischenablage überwachen** aktiviert ist.
- Wenn aktiviert, werden aus anderen Apps kopierte Profile/Kristalle automatisch eingelesen.

!!! tip
    Wenn Sie neu erstellte `.pdi`-Dateien in einem bestimmten Ordner automatisch einlesen möchten, verwenden Sie **Optionen** ▸ **Datei überwachen**.

## Intensitätsverhältnisse werden nicht berechnet

Um theoretische Beugungsintensitäten zu berechnen, muss die Kristallstruktur **Atompositionen (Atomkoordinaten)** enthalten. Wenn keine Atompositionen eingegeben sind, können zwar die Peakpositionen (\(d\)-Werte) berechnet werden, die Intensitätsverhältnisse jedoch nicht.

!!! note "Lösung"
    Geben Sie auf [Kristallparameter](../3-crystal-parameter.md) für jedes Atom das Element, die Koordinaten und die Besetzung ein. Sobald die Atompositionen eingegeben sind, werden die Intensitätsverhältnisse aus dem Strukturfaktor berechnet.

## Anpassung meldet NA (nicht verfügbare) Gitterkonstanten

Beim Verfeinern von Gitterkonstanten mit Peak-Anpassung lässt eine unzureichende Anzahl unabhängiger Reflexe die Gitterkonstanten unbestimmt. In diesem Fall behält das Programm die ursprüngliche Zellform bei und ändert nur ihren Gesamtmaßstab, und die Fehlerfelder zeigen NA (nicht verfügbar). Wenn die Anzahl der Reflexe gleich der Anzahl der unabhängigen Gitterkonstanten ist, lassen sich aus den Residuen keine Standardfehler gewinnen, sodass die Fehlerfelder ebenfalls NA zeigen.

- Je nach Kristallsystem müssen Sie genügend Reflexe bereitstellen, damit die Anzahl der unabhängigen Gitterkonstanten bestimmt werden kann (z. B. nur \(a\) für kubisch, aber sechs Werte \(a, b, c, \alpha, \beta, \gamma\) für triklin).
- Wenn die Reflexe linear abhängig sind (in eine Richtung verzerrt), können bestimmte Gitterkonstanten nicht bestimmt werden. Schließen Sie Reflexe unterschiedlicher Orientierung ein.

!!! note "Lösung"
    Siehe [Beugungspeak-Anpassung](../6-fitting-diffraction-peaks.md) und stellen Sie sicher, dass die Anpassung genügend unabhängige Reflexe enthält.

## Immer noch nicht gelöst

Bei Problemen, die die obigen Schritte nicht lösen, oder bei reproduzierbaren Fehlern und Funktionswünschen melden Sie diese bitte im GitHub-Issue-Tracker. Geben Sie nach Möglichkeit die Schritte zur Reproduktion, die verwendete Datei und einen Screenshot an.

- Issue-Tracker: <https://github.com/seto77/PDIndexer/issues>
