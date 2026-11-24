<!-- 261124Cl added: Q&A page, compiled anonymously from GitHub issues and support e-mails to the author (2006–2026); reviewed with codex2 (2 rounds). Lead language: ja/appendix/faq.md -->
# Q&A

Diese Seite sammelt Fragen, die Anwender tatsächlich gestellt haben, mit dem Schwerpunkt auf häufigen Fragen und auf Punkten, die leicht missverstanden werden. Zu Fehlern und Startproblemen siehe auch [Fehlerbehebung](troubleshooting.md).

## Was Sie zuerst versuchen sollten {#first-steps}

### Etwas stimmt nicht (es erscheinen keine Beugungslinien, eine Datei lässt sich nicht lesen, beim Start erscheint ein Fehler). Was sollte ich zuerst versuchen?

Suchen Sie zuerst auf dieser Seite den Eintrag, der zu Ihrem Symptom passt. Wenn keine Beugungslinien erscheinen, liegt die Ursache fast immer in der Einstellung der Strahlung oder der Wellenlänge ([Beugungslinien und die Kristallliste](#peaks-and-crystals)). Wenn das nicht hilft, versuchen Sie Folgendes in dieser Reihenfolge.

1. Aktualisieren Sie auf die neueste Version (`Hilfe` ▸ `Auf Updates prüfen`, oder laden Sie sie von der [Release-Seite](https://github.com/seto77/PDIndexer/releases/latest) herunter).
2. Haken Sie `Optionen` ▸ `Registry löschen (anhaken und neu starten)` an, beenden Sie PDIndexer und starten Sie es neu. PDIndexer speichert Fensterpositionen, Strahleinstellungen usw. in der Registry, und von einer älteren Version übernommene Einstellungen können Probleme verursachen.
3. Wenn die Kristallliste falsch aussieht, führen Sie `Datei` ▸ `Kristalle in den Anfangszustand zurücksetzen` aus.

!!! warning "Was verloren geht"
    - **Das Löschen der Registry** entfernt die gespeicherten Einstellungen und **die im Makrofenster registrierten Makros**. Exportieren Sie die benötigten Makros vorher als `.mcr`-Dateien. Die Kristallliste wird nicht in der Registry, sondern in einer eigenen Datei (`%APPDATA%\PDIndexer\PDIndexer\default.xml`) gespeichert und wird daher durch das Löschen der Registry nicht entfernt.
    - **Das Zurücksetzen der Kristallliste** verwirft die Kristalle, die Sie hinzugefügt oder bearbeitet haben. Speichern Sie die benötigten Kristalle vorher mit `Datei` ▸ `Kristalle speichern`.

### Wenn ich PDIndexer zusammen mit IPAnalyzer verwende, erhalte ich Fehler oder falsche Werte.

[IPAnalyzer](https://github.com/seto77/IPAnalyzer) und PDIndexer nutzen eine gemeinsame Bibliothek und tauschen Daten über die Zwischenablage aus. Wird nur eines der beiden Programme aktualisiert, passt das Austauschformat möglicherweise nicht mehr zusammen, was zu Fehlern oder falschen Werten führen kann. **Halten Sie beide gleichzeitig auf dem neuesten Stand.**

## Installation und Start {#install}

### Ich kann PDIndexer auf einem PC ohne Administratorrechte nicht installieren, oder eine Richtlinie blockiert die MSI.

Verwenden Sie das **installationsfreie ZIP-Paket** (`PDIndexer-v.<ver>.zip` für x64, `PDIndexer-v.<ver>_arm64.zip` für Arm64). Es enthält die Laufzeitumgebung, sodass Sie weder die MSI noch eine separate .NET Desktop Runtime benötigen. Entpacken Sie den gesamten Ordner an einen Ort, an dem Sie Schreibrechte haben, und starten Sie `PDIndexer.exe` im entpackten Ordner. PDIndexer selbst läuft mit gewöhnlichen Benutzerrechten.

Die Unterschiede zwischen MSI- und ZIP-Paket finden Sie unter [Laufzeit und Installation](runtime-and-installation.md).

!!! note
    PDIndexer ist eine nicht signierte Forschungssoftware, daher warnen Windows (SmartScreen) oder Ihr Browser möglicherweise beim Herunterladen oder beim ersten Start. Wählen Sie in der Downloadliste des Browsers **Weitere Informationen** ▸ **Beibehalten**; bei der Warnung beim Start wählen Sie **Weitere Informationen** ▸ **Trotzdem ausführen**.

### Es erscheint „You must install .NET Desktop Runtime“, obwohl ich .NET installiert habe.

Die Ursache ist meist eine der folgenden.

- **Falsche Hauptversion.** Die benötigte .NET-Version ändert sich zwischen PDIndexer-Versionen. Installieren Sie die **Desktop Runtime** der Version, die für die verwendete Version angegeben ist. Die einfache „.NET Runtime“ reicht nicht aus.
- **Falsche Architektur.** Die x64-Variante von PDIndexer benötigt die x64-Laufzeitumgebung, die Arm64-Variante die Arm64-Laufzeitumgebung. Verwenden Sie unter Arm-basiertem Windows (Snapdragon-PCs usw.) das Arm64-Installationsprogramm `PDIndexer-setup_arm64.msi`.
- Wenn es weiterhin nicht funktioniert, ist das **installationsfreie ZIP-Paket**, das die Laufzeitumgebung enthält, die zuverlässigste Wahl.

## Beugungslinien und die Kristallliste {#peaks-and-crystals}

### Ich hake einen Kristall an, aber es erscheinen keine Beugungslinien, oder sie liegen weit daneben.

Prüfen Sie zuerst Folgendes.

- [`Peaks über Profilen anzeigen`](../3-crystal-parameter.md) ist eingeschaltet, und der Kristall ist in der Kristallliste angehakt.
- **Strahlung und Wellenlänge (oder Energie) der Messung sind korrekt eingestellt.** Textdaten wie CSV enthalten oft keine Wellenlängeninformation; geben Sie in diesem Fall im Dialog, der beim Lesen der Datei erscheint, die bei der Messung verwendete Strahlung und Wellenlänge an. Die für die Anzeige verwendete Strahlung und Wellenlänge prüfen Sie auf dem [Reiter `Horizontale Achse`](../1-main-window.md#horizontal-axis-tab) des Hauptfensters.
- Die Linien liegen nicht außerhalb des Zeichenbereichs. Versuchen Sie, den horizontalen Bereich zu erweitern (insbesondere bei Neutronen-TOF).
- Wenn nur ein Kristall nicht erscheint, prüfen Sie, ob seine Gitterkonstanten und Atompositionen nicht weit daneben liegen, und vergleichen Sie ihn mit derselben Substanz in der eingebauten Datenbank.

### Ich habe eine Beugungslinie gezogen, und die Gitterkonstanten haben sich geändert. Ein Neustart stellt sie nicht wieder her.

Durch Ziehen einer Beugungslinie geänderte Gitterkonstanten werden beim Beenden von PDIndexer gespeichert, weil `Optionen` ▸ `Kristallliste beim Schließen speichern` standardmäßig eingeschaltet ist. Ein Neustart macht die Änderung daher nicht rückgängig.

- Um zu den Gitterkonstanten zurückzukehren, die der Kristall beim Laden in der aktuellen Sitzung hatte, klicken Sie mit der rechten Maustaste auf die Kristallinformation und wählen `Gitterkonstanten zurücksetzen`.
- Um die gesamte Kristallliste in den Zustand direkt nach der Installation zurückzuversetzen, wählen Sie `Datei` ▸ `Kristalle in den Anfangszustand zurücksetzen`.

### Die Kristallliste enthält seltsame Werte oder Duplikate, oder ein Druckstandard (Au, Pt usw.) fehlt.

`Datei` ▸ `Kristalle in den Anfangszustand zurücksetzen` stellt die anfängliche Kristallliste einschließlich der Druckstandards wieder her. Selbst hinzugefügte Kristalle gehen dabei verloren; speichern Sie sie bei Bedarf vorher.

### Intensitätsverhältnisse werden nicht berechnet; alle Linien haben dieselbe Höhe.

Zur Berechnung von Intensitätsverhältnissen benötigt der Kristall Atompositionen, und [`Intensitätsverhältnis berechnen`](../3-crystal-parameter.md) muss eingeschaltet sein. Falsche Strahlungseinstellungen ergeben ebenfalls falsche Intensitäten. Einzelheiten siehe [Fehlerbehebung](troubleshooting.md).

### Wie importiere ich Kristalle aus CSManager oder aus CIF-Dateien?

- **Aus CSManager**: Öffnen Sie zuerst das Fenster `Kristallparameter` von PDIndexer und schalten Sie `Optionen` ▸ `Zwischenablage überwachen` ein; wählen Sie dann den Kristall in CSManager aus. Sie müssen nicht zuerst eine CIF-Datei exportieren.
- **CIF-/AMC-Dateien** können per Drag & Drop auf den Bereich Kristallinformation des Fensters Kristallparameter gezogen werden.
- Sie können auch die **eingebaute Kristalldatenbank** (AMCSD) durchsuchen. Siehe [Kristallparameter](../3-crystal-parameter.md).

In jedem Fall erscheint der Kristall im Bereich Kristallinformation. Klicken Sie auf `Hinzufügen`, um ihn in die Kristallliste aufzunehmen.

### Kann ich Röntgendaten und Elektronendaten (oder Daten anderer Wellenlängen) auf derselben horizontalen Achse überlagern?

Ja. PDIndexer hat eine einzige horizontale Achse, und jedes geladene Profil wird auf die Strahlung und Wellenlänge umgerechnet, die auf dem Reiter `Horizontale Achse` gewählt sind. Beispielsweise kann ein Elektronenbeugungsprofil auf der 2θ-Skala von Cu Kα dargestellt werden.

Wenn `Nach dem Laden des Profils horizontale Achse anpassen` auf dem Reiter `Horizontale Achse` eingeschaltet ist, wechseln die Achseneinstellungen zu denen jeder neu geladenen Datei. Schalten Sie diese Option aus, um für den Vergleich eine feste Achse beizubehalten.

## Profile lesen und die horizontale Achse {#profiles-and-axis}

### Was ist der Unterschied zwischen dem Reiter `Horizontale Achse` des Hauptfensters und `Achseneinstellung` im Fenster Profilparameter?

- Der **Reiter `Horizontale Achse`** (Hauptfenster) legt nur fest, **wie die Daten angezeigt werden**; die Profildaten selbst ändern sich nicht.
- **[`Achseneinstellung`](../4-profile-parameter.md#axis-setting)** (Fenster Profilparameter) schreibt **die Bedingungen um, unter denen das Profil gemessen wurde** (Strahlungstyp, Wellenlänge, Take-off-Winkel usw.). Wenn Sie beim Lesen der Datei die falsche Strahlung oder Wellenlänge gewählt haben, korrigieren Sie sie hier. Wenn Sie Werte in der falschen **Einheit** eingegeben haben, lesen Sie die Originaldatei erneut ein.

### Energiedispersive Daten (weiße Röntgenstrahlung, `.npd` / `.nxs`) haben eine falsche horizontale Achse, oder es erscheinen keine Beugungslinien.

Prüfen Sie im Dialog, der beim Lesen der Datei erscheint, ob die **Energieeinheit (eV / keV)**, **2θ** und bei `.nxs` die **Kalibrierungskoeffizienten von Kanal zu Energie** zur Messung passen. `.npd`-Dateien verwenden die Energiespalte der Datei; prüfen Sie daher auch die Werte und die Einheit in der Originaldatei. Eine falsche Einheit verschiebt die Peak-Positionen stark.

### Kann PDIndexer GSAS-Dateien `.gsa` (2θ in Zenti-Grad) oder Daten auf einer q-Achse (Wellenzahl) lesen?

Ja.

- Für eine `.gsa`-Datei (drei durch Leerzeichen getrennte Spalten mit 2θ in Zenti-Grad) wählen Sie im Datenkonvertierungsdialog 2θ als horizontale Achse und Zenti-Grad (centi-degree) als Einheit.
- Für Daten auf einer q-Achse (Wellenzahl) wählen Sie q als horizontale Achse. Sie können Gitterkonstanten auch auf der q-Achse verfeinern.

## Peak-Anpassung und Gitterkonstanten {#fitting}

### Welchen Wert sollte ich für `Suchbereich` verwenden? Das Volumen ändert sich, wenn ich ihn ändere.

`Suchbereich` ist die Suchbreite auf jeder Seite des Peak-Zentrums. Beginnen Sie mit dem **2- bis 3-Fachen der Halbwertsbreite (FWHM)** des Peaks und verkleinern Sie ihn, wenn der benachbarte Peak überlappt. Ein zu weiter Bereich erfasst andere Peaks oder den Untergrund, ein zu enger Bereich schneidet die Peak-Ausläufer ab; beides verschiebt die angepasste Position. Die Verwendung vieler **Peaks bei hohen Winkeln** verbessert die Genauigkeit der Gitterkonstanten.

### Sind die in `Optimierte Gitterkonstanten` angezeigten Werte bereits auf den Kristall angewendet?

Nein. `Optimierte Gitterkonstanten` **zeigt** nur die Werte **an**, die sich aus den ausgewählten Reflexen und den Anpassungsbedingungen ergeben. Um die Gitterkonstanten des Kristalls zu überschreiben, klicken Sie auf `Auf den Kristall anwenden`. Um die Werte zu verwenden, ohne den Kristall zu ändern, nutzen Sie `In Zwischenablage kopieren`. Mehrmaliges Klicken auf `Auf den Kristall anwenden` kann die Konvergenz verbessern, da die berechneten Linienpositionen jedes Mal aktualisiert werden.

### Ich wähle dieselben Reflexe, aber der Fehler des Volumens wird plötzlich groß.

Die Peak-Anpassung (Anpassen einer Funktion an jeden Peak) und die Verfeinerung der Gitterkonstanten sind getrennte Berechnungen. PDIndexer sucht einen Peak nur innerhalb des Suchbereichs jedes Reflexes; fällt ein Peak einer anderen Phase oder Rauschen in diesen Bereich, geht ein falscher d-Wert in die Berechnung der Gitterkonstanten ein.

- Prüfen Sie die Anpassung jedes Reflexes in der Reflexliste und schließen Sie zweifelhafte oder schwache Peaks aus.
- Bei schlechtem Signal-Rausch-Verhältnis verfeinern Sie zuerst nur mit den starken Peaks und fügen schwächere Peaks danach hinzu. Sie benötigen mindestens so viele unabhängige Reflexe, wie es unabhängige Gitterkonstanten für das Kristallsystem gibt (1 für kubisch, 6 für triklin), und mehr als das, um die Fehler abzuschätzen.
- Für schwache oder stark überlappende Muster ist eine Anpassung des gesamten Musters wie die Rietveld-Analyse möglicherweise besser geeignet.

Wie die Gitterkonstanten und ihre Fehler berechnet werden, siehe [Algorithmen](algorithms.md#lattice-refinement).

## Sequentielle Analyse und Makros {#sequential-and-macro}

### Ich möchte viele Profile (zeitaufgelöst, Druckstufen usw.) automatisch anpassen und Gitterkonstanten oder Drücke erhalten.

Verwenden Sie die [Sequentielle Analyse](../7-sequential-analysis.md) (zu öffnen über die Symbolleiste des Hauptfensters oder mit `Ctrl+Shift+S`). **Öffnen Sie das Fenster der Peak-Anpassung** und wählen Sie den Kristall und die Reflexe, bevor Sie sie ausführen. Es werden mindestens vier Profile benötigt. Die Ergebnisse können automatisch gespeichert werden.

- Das gleichzeitige Lesen Tausender Profile verbraucht viel Speicher. Legen Sie die Bedingungen zuerst mit etwa 100 Profilen fest und führen Sie dann den gesamten Satz aus.
- Das direkte Lesen aus einem Netzwerkordner ist langsam. Kopieren Sie die Dateien vor der Analyse auf ein lokales Laufwerk.
- Wenn sich die Gitterkonstanten im Verlauf der Serie stark ändern, kann ein Peak seinen Suchbereich verlassen und ein anderer Peak erfasst werden. Wenn `Toleranzfaktor` eingeschaltet ist, werden Punkte, deren Volumen um mehr als den eingestellten Wert (%) **vom Volumen zu Beginn des Laufs** abweicht, als NaN ausgegeben.

### Kann die sequentielle Analyse mehrere Phasen (z. B. die Probe und einen Druckmarker) gleichzeitig anpassen?

Die Peaks aller angehakten Kristalle werden angepasst (wenn die Musterzerlegung auf `über alle Kristalle` eingestellt ist, werden überlappende Peaks verschiedener Phasen gemeinsam getrennt). Jeder sequentielle Lauf zeichnet Gitterkonstanten und Druck jedoch nur für den einen Kristall auf, der im Fenster der Peak-Anpassung ausgewählt ist. Um die Ergebnisse für eine andere Phase zu erhalten, wählen Sie diesen Kristall aus und führen Sie den Lauf erneut aus, oder verwenden Sie ein [Makro](../8-macro.md), das zwischen den Kristallen umschaltet.

### Ich habe eine Spannungsanalyse an nach Azimut aufgeteilten Profilen ausgeführt, aber die Registerkarte `Singh-Gleichung` ist leer.

Der Spannungsanalyse-Modus wird nur gewählt, wenn **der Name des ersten Profils in der Profilliste auf `whole` endet**. Beim zweiten und allen weiteren Profilen wird der Text **nach dem letzten Bindestrich** des Namens als Azimut in Grad gelesen (z. B. `sample-30`). Prüfen Sie außerdem, ob mindestens vier Profile geladen sind und das Fenster der Peak-Anpassung geöffnet ist. Bei einem gewöhnlichen Lauf (nicht im Spannungsmodus) bleibt die Registerkarte `Singh-Gleichung` leer. Einzelheiten siehe [Sequentielle Analyse](../7-sequential-analysis.md).

### Mit dem Komma als Dezimaltrennzeichen sind die Spalten der CSV-Datei der sequentiellen Analyse verschoben.

Die CSV-Datei der sequentiellen Analyse verwendet die auf dem Bildschirm angezeigten Zahlen, daher lassen sich bei einem Komma als Dezimaltrennzeichen (`1,5`) die Dezimalstellen nicht von den Spaltentrennzeichen unterscheiden. Verwenden Sie vorerst `Kopieren` auf der Ergebnis-Registerkarte, um die Tabelle als tabulatorgetrennten Text zu kopieren, und fügen Sie sie in Ihre Tabellenkalkulation als tabulatorgetrennte Daten ein. Der CSV-Export der Profile selbst (`Datei` ▸ `Ausgewählte Profil(e) exportieren`) schreibt unabhängig von den Regionseinstellungen immer `.` als Dezimaltrennzeichen.

### In welcher Sprache werden Makros geschrieben? Wie schreibe ich Dateipfade?

Makros werden in **Python (IronPython)** geschrieben. Schreiben Sie Windows-Pfade mit Schrägstrichen (`'C:/data/sample.pdi2'`) oder als Raw-Strings (`r'C:\data\sample.pdi2'`). Die verfügbaren Funktionen sind in der Funktionsreferenz unter [Makro](../8-macro.md) aufgeführt.

## Zustandsgleichungen {#eos}

### Ich habe eine Temperatur eingegeben. Ist das Ergebnis als Hochtemperaturdruck gültig?

Einige Zustandsgleichungen (EOS) haben in der Originalarbeit keinen Temperaturterm (isotherme Gleichungen), und die eingegebene Temperatur wird nicht verwendet. Zustandsgleichungen, die Tabellen aus der Literatur interpolieren, liefern **außerhalb des Temperatur- und Volumenbereichs der Tabelle ungenaue Drücke**. Prüfen Sie die Quelle und den Gültigkeitsbereich der Zustandsgleichung unter [Zustandsgleichung](../5-equation-of-states.md).

## Weitere Fragen {#others}

### Was sollte ich senden, wenn ich einen Fehler melde?

Melden Sie ihn in den [GitHub Issues](https://github.com/seto77/PDIndexer/issues) mit folgenden Angaben.

- Die PDIndexer-Version (`Hilfe` ▸ `Über PDIndexer`) und die Windows-Version
- Einen minimalen, weitergebbaren Satz von Dateien, der das Problem reproduziert (Profile, die `.xml`-Datei der Kristallliste, Einstellungsdateien von IPAnalyzer usw.)
- Die ausgeführten Schritte und die Fehlermeldung oder einen Screenshot
- Das erwartete Ergebnis (den Wert, den Sie für richtig halten)

### Darf ich PDIndexer auf einer Webseite einer Beamline oder eines Labors vorstellen oder weiterverbreiten?

Ja. PDIndexer wird unter der [MIT-Lizenz](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md) verbreitet. Wenn Sie es weiterverbreiten, fügen Sie den Urheberrechtshinweis und den Lizenztext bei.
