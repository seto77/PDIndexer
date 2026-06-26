<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Fehlerbehebung

Wenn bei der Verwendung von PDIndexer ein Problem auftritt, prüfen Sie zuerst die folgenden Punkte. Die meisten Probleme lassen sich durch die Installation der Runtime oder durch Überprüfen einer Einstellung beheben.

## Die Anwendung startet nicht

PDIndexer benötigt die **.NET Desktop Runtime 10.0**. Wenn die Runtime nicht installiert ist, wird beim Start möglicherweise ein Fehler angezeigt, oder das Programm wird beendet, ohne etwas zu tun.

!!! warning "Lösung"
    Folgen Sie [Runtime und Installation](runtime-and-installation.md), um die neueste **.NET Desktop Runtime 10.0** (x64) zu installieren, und starten Sie PDIndexer anschließend neu.

## Die UI-Sprache wechselt nicht

Sie können die UI-Sprache im Menü unter **Optionen** ▸ **Sprache** ändern, indem Sie **English (need restart)** oder **Japanese (need restart)** wählen. Eine Sprachänderung wird jedoch erst **nach einem Neustart** wirksam.

!!! note
    Es ist normal, dass sich die Anzeige nach der Auswahl einer Sprache nicht sofort ändert. Schließen Sie PDIndexer und starten Sie es erneut.

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

Beim Verfeinern von Gitterkonstanten mit Peak-Anpassung kann eine unzureichende Anzahl unabhängiger Reflexe die Gitterkonstanten unbestimmt lassen, und das Ergebnis wird möglicherweise als NA (nicht verfügbar) gemeldet.

- Je nach Kristallsystem müssen Sie genügend Reflexe bereitstellen, damit die Anzahl der unabhängigen Gitterkonstanten bestimmt werden kann (z. B. nur \(a\) für kubisch, aber sechs Werte \(a, b, c, \alpha, \beta, \gamma\) für triklin).
- Wenn die Reflexe linear abhängig sind (in eine Richtung verzerrt), können bestimmte Gitterkonstanten nicht bestimmt werden. Schließen Sie Reflexe unterschiedlicher Orientierung ein.

!!! note "Lösung"
    Siehe [Beugungspeak-Anpassung](../6-fitting-diffraction-peaks.md) und stellen Sie sicher, dass die Anpassung genügend unabhängige Reflexe enthält.

## Immer noch nicht gelöst

Bei Problemen, die die obigen Schritte nicht lösen, oder bei reproduzierbaren Fehlern und Funktionswünschen melden Sie diese bitte im GitHub-Issue-Tracker. Geben Sie nach Möglichkeit die Schritte zur Reproduktion, die verwendete Datei und einen Screenshot an.

- Issue-Tracker: <https://github.com/seto77/PDIndexer/issues>
