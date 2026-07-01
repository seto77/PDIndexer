<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Hauptfenster

Wenn Sie die Software starten, erscheint der unten gezeigte Bildschirm. Das Hauptfenster besteht aus dem zentralen **Profilzeichenbereich**, der **Menüleiste** und der **Symbolleiste (Funktionsliste)** oben, dem Reitermenü nahe dem oberen Rand (`Horizontale Achse` / `Darstellung & Einzel-/Mehrprofil`), der **Profilliste** oben rechts und der **Kristallliste** unten rechts.

![Das gesamte PDIndexer-Hauptfenster](../assets/cap-de-auto/FormMain.png)

## Profilzeichenbereich

Dieser Bereich nimmt den größten Teil des Fensters ein und zeigt die in der Profilliste angehakten Profile an. Wenn in der Kristallliste ein Kristall ausgewählt ist, werden zusätzlich Beugungslinien an den Positionen der Beugungspeaks gezeichnet.

### Mausbedienung

| Bedienung | Aktion |
| --- | --- |
| Linke Taste ziehen | Beugungslinien verschieben (die Gitterkonstanten des Kristalls ändern) |
| Rechte Taste ziehen | Vergrößern |
| Rechte Taste klicken | Verkleinern |
| Mittlere Taste ziehen | Ansicht verschieben |

Die Zeichenbereiche der horizontalen und vertikalen Achse können geändert werden, indem Sie Werte direkt in die Zahlenfelder oberhalb des Zeichenbereichs eingeben (`2θ:`, `d:`, `Int.:`, `q:` usw., deren Beschriftungen vom gewählten Modus der horizontalen Achse abhängen).

!!! tip
    Der Anzeigemodus der horizontalen Achse (Winkel, Energie, Netzebenenabstand usw.) wird im [Reiter `Horizontale Achse`](#horizontal-axis-tab) umgeschaltet. Dies ist eine reine Anzeigeeinstellung und ändert die eigenen Daten der horizontalen Achse des Profils nicht.

## Symbolleiste (Funktionsliste)

Jede Schaltfläche der Symbolleiste blendet ein eigenes Analysefenster ein oder aus.

| Schaltfläche | Funktion | Siehe |
| --- | --- | --- |
| `Kristallparameter (C)` | Das Fenster Kristallparameter ein-/ausblenden. | [Kristallparameter](3-crystal-parameter.md) |
| `Profilparameter (P)` | Das Fenster Profilparameter ein-/ausblenden. | [Profilparameter](4-profile-parameter.md) |
| `Zustandsgleichung (E)` | Das Fenster Zustandsgleichung ein-/ausblenden, um den Druck aus dem Zellvolumen eines Standardmaterials abzuschätzen. | [Zustandsgleichungen](5-equation-of-states.md) |
| `Reflexe anpassen (F)` | Das Fenster Beugungspeak-Anpassung ein-/ausblenden, um Beugungspeaks anzupassen (Position, FWHM, Intensität). | [Beugungspeak-Anpassung](6-fitting-diffraction-peaks.md) |
| `Cell Finder` | Das Fenster Cell Finder ein-/ausblenden, um Gitterkonstanten aus Peakpositionen zu suchen. | — |
| `Sequentielle Analyse` | Das Fenster Sequentielle Analyse für die Stapelverarbeitung einer Dateiserie ein-/ausblenden. | [Sequentielle Analyse](7-sequential-analysis.md) |
| `Atomic Position Finder` | Das Fenster Atomic Position Finder ein-/ausblenden, um Atompositionen aus Beugungsintensitäten zu suchen. | — |
| `LPO-Analyse` | Das Fenster LPO-Analyse (gitterbezogene Vorzugsorientierung) ein-/ausblenden. | — |

!!! note
    Die Hauptfenster können auch mit Tastenkürzeln ein-/ausgeblendet werden: `Ctrl+Shift+C` (Kristallparameter), `Ctrl+Shift+E` (Zustandsgleichungen), `Ctrl+Shift+F` (Anpassungsparameter) und `Ctrl+Shift+D` (Peakmodus ändern).

## Menüleiste

### Datei

| Eintrag | Beschreibung |
| --- | --- |
| `Profil(e) lesen` | Profildaten lesen. Neben dem softwareeigenen Format `pdi` / `pdi2` können Sie die WinPIP-Ausgabe `csv`, die Fit2D-Ausgabe `chi` und so weiter lesen. Die meisten als Winkel-Intensitäts-Text gespeicherten Dateien können ebenfalls gelesen werden. |
| `Profil(e) speichern` | Alle geladenen Profile im softwareeigenen Format `pdi2` speichern. |
| `Ausgewählte Profil(e) exportieren` | Die ausgewählten Profile als kommagetrennte (CSV), tabulatorgetrennte (TSV) oder GSAS-Datendatei (Rietveld) exportieren. |
| `Kristalle laden (als neue Liste)` | Eine Kristalllistendatei (Erweiterung `xml`) laden. Die aktuelle Kristallliste wird verworfen. |
| `Kristalle laden (zur aktuellen Liste hinzufügen)` | Eine Kristalllistendatei (Erweiterung `xml`) laden und an das Ende der aktuellen Kristallliste anhängen. |
| `Kristalle speichern` | Die aktuelle Kristallliste in eine Datei (Erweiterung `xml`) speichern. |
| `CIF, AMC importieren...` | Eine Strukturdatendatei im Format `cif` oder `amc` importieren und zur aktuellen Kristallliste hinzufügen. |
| `Ausgewählten Kristall als CIF exportieren` | Den ausgewählten Kristall als Strukturdatendatei im Format `cif` speichern. |
| `Kristalle in den Anfangszustand zurücksetzen` | Die Kristallliste in den anfänglichen (Standard-)Zustand zurücksetzen. |
| `Seite einrichten` | Den Dialog zum Einrichten der Seite für den Druck öffnen. |
| `Druckvorschau` | Eine Druckvorschau des Profilbetrachters anzeigen. |
| `Drucken` | Drucken. Der Druckbereich ist der aktuelle Winkel- und Intensitätsbereich. |
| `In Zwischenablage kopieren` | Das aktuell gezeichnete Profil als Bitmap-Daten oder Metafile-Daten (Vektor) in die Zwischenablage kopieren. |
| `Als Metafile speichern` | Das aktuell gezeichnete Profil im Metafile-Format speichern. Das Format EMF (Enhanced Meta File) wird unterstützt, und die gespeicherten `*.emf`-Dateien können in PowerPoint und Word geöffnet werden. |
| `Schließen` | PDIndexer schließen. |

### Optionen

| Eintrag | Beschreibung |
| --- | --- |
| `QuickInfo` | Wenn angehakt, werden die QuickInfos im Hauptfenster angezeigt. |
| `Zwischenablage überwachen` | Die Zwischenablage überwachen und aus anderen Apps (z. B. IPAnalyzer) kopierte Profil-/Kristalldaten automatisch importieren. |
| `Datei überwachen` | Einen angegebenen Ordner überwachen und neu erstellte `.pdi`-Profildateien automatisch lesen. Wählen Sie den zu überwachenden Ordner über den Auswahldialog oder durch direkte Eingabe des Pfads. |
| `Registry löschen (anhaken und neu starten)` | Wenn angehakt, beim Beenden alle gespeicherten Einstellungen aus der Registry löschen (Neustart zum Zurücksetzen). |
| `Kristallliste beim Schließen speichern` | Wenn angehakt, die Kristallliste beim Beenden automatisch speichern und beim Start erneut laden. |

### Makro

`Editor` öffnet das Makro-Editor-Fenster. Einzelheiten zur Makrofunktion von PDIndexer finden Sie unter [Makro](8-macro.md).

### Hilfe

| Eintrag | Beschreibung |
| --- | --- |
| `Über PDIndexer` | Die Copyright-, Versions- und Autoreninformationen sowie die Versionshistorie anzeigen. |
| `Auf Updates prüfen` | Online nach einer neueren Version suchen und diese, falls verfügbar, herunterladen/installieren. |
| `Hinweis` | Nutzungshinweise anzeigen (veraltet). |
| `Hilfe (Web)` | Dieses Handbuch anzeigen. |

### Sprache

Die UI-Sprache umschalten. Derzeit werden Englisch (`English (need restart)`) und Japanisch (`Japanese (need restart)`) unterstützt. Nach dem Umschalten ist ein Neustart erforderlich.

## Reiter Horizontale Achse {#horizontal-axis-tab}

Der Reiter `Horizontale Achse` legt den Anzeigemodus der Achse fest. Die Einstellungen hier sind reine Anzeigeeinstellungen und stehen in keinem Zusammenhang mit den tatsächlichen Daten der horizontalen Achse (die tatsächlichen Informationen der horizontalen Achse können über die [Profilparameter](4-profile-parameter.md) geändert werden). Dadurch können Sie die horizontale Achse zum Vergleich angleichen, selbst wenn unterschiedliche Röntgenquellen verwendet wurden. Beispielsweise kann ein geladenes Profil, das mit der Cu-Kα-Linie aufgenommen wurde, so dargestellt werden, als wäre es mit der Wellenlänge der Mo-Kα-Linie aufgenommen worden.

| Eintrag | Beschreibung |
| --- | --- |
| `Nach dem Laden des Profils horizontale Achse anpassen` | Wenn angehakt, werden die Einstellungen der horizontalen Achse automatisch an die des neu geladenen Profils angeglichen. |
| 2θ (degree) | Die horizontale Achse auf Winkel einstellen. Die Wahl der Optionsschaltfläche `X-ray` liefert den Streuwinkel für Röntgenstrahlen; wählen Sie eine charakteristische Röntgenquelle oder `Custom` aus der Dropdown-Liste und geben Sie die Wellenlänge an. Die Wahl der Optionsschaltfläche `Electron` liefert den Streuwinkel für Elektronen; die Angabe der Beschleunigungsspannung berechnet die relativistisch korrigierte Wellenlänge. |
| Energy (eV) | Die horizontale Achse auf Energie (Einheit eV) einstellen. Dies entspricht einem Röntgenbeugungsexperiment mit einem EDX-Detektor. Stellen Sie den EDX-Abnahmewinkel (Take-off-Winkel) passend ein. |
| d-spacing (Å) | Die horizontale Achse auf den Netzebenenabstand (d-Wert) einstellen. |
| q | Die horizontale Achse auf den Betrag des Streuvektors \( q \) einstellen. |

Die Beziehung zwischen dem Streuwinkel und dem Netzebenenabstand wird durch das Braggsche Gesetz gegeben, mit \( \lambda \) als Wellenlänge:

$$ 2 d \sin\theta = n \lambda $$

## Reiter Darstellung & Einzel-/Mehrprofil

Der Reiter `Darstellung & Einzel-/Mehrprofil` konfiguriert das Erscheinungsbild der Zeichnung und die Einzel-/Mehrprofilanzeige.

### Skalen- und Farbeinstellungen

| Eintrag | Beschreibung |
| --- | --- |
| `Skalenlinie` | Auswählen, ob die Skalenlinien (Gitterlinien) angezeigt werden. |
| `Fehlerbalken` | Fehlerbalken anzeigen, wenn die Daten Fehlerinformationen enthalten. |
| `Farbe` | Die Anzeigefarben festlegen, etwa `Hintergrundfarbe`, `Skalenlinie` und `Skalentext`. |

### Einzel-/Mehrprofil

Der angehakte Modus ist der aktuelle Modus.

| Eintrag | Beschreibung |
| --- | --- |
| `Einzelprofil` | Einzelprofilmodus. Wenn ein Profil geladen oder über die Zwischenablage von IPAnalyzer gesendet wird, wird das alte Profil gelöscht und das neue Profil gezeichnet. |
| `Mehrere Profile` | Mehrprofilmodus. Neue Profile werden geladen und über die bestehenden gelegt. |
| `Intensitätsversatz pro Profil` | Legt den Intensitätsversatz zwischen Datensätzen beim Überlagern mehrerer Datensätze fest. Dies dient nur der Lesbarkeit der Anzeige; die tatsächlichen Daten werden nicht verändert. |
| `Farbe automatisch ändern` | Wenn angehakt, wird die Zeichenfarbe der Profile automatisch geändert. |

### Vertikale Achse

Geben Sie an, ob die vertikale Achse (Intensität) als rohe Counts (`Rohe Counts`) oder als Counts pro Schritt (`Counts pro Schritt (CPS)`) angezeigt wird. Sie können außerdem angeben, ob die vertikale Achse auf einer linearen (`Linear`) oder logarithmischen (`Logarithmisch`) Skala angezeigt wird.

## Profilliste

Zeigt die geladenen Profile an und ermöglicht ihre Auswahl. Im Modus `Einzelprofil` ist sie deaktiviert.

Im Mehrprofilmodus werden die geladenen Profile als Liste angezeigt, und nur die angehakten werden im zentralen Zeichenbereich gezeichnet. Detailliertere Profileinstellungen werden vorgenommen, indem Sie das Kontrollkästchen `Profilparameter` unten im Feld anhaken (siehe [Profilparameter](4-profile-parameter.md)).

## Kristallliste

Zeigt die Liste der Kristalle an und konfiguriert sie. Das Anhaken eines Eintrags zeichnet Beugungslinien an den Positionen der Beugungspeaks. Standardmäßig sind etwa 80 Kristalle vorregistriert.

!!! note "Besondere Zeilen"
    - Die erste Zeile (Zeile 0) ist der **Flexible Crystal** (cyanfarbener Hintergrund), der zum Zeichnen beliebiger Beugungslinien dient.
    - Die oberen Zeilen (rosa Hintergrund, z. B. `NaCl EOS` und `Pt EOS`) sind als Standardmaterialien für Zustandsgleichungsberechnungen (EOS) reserviert.

Detailliertere Kristalleinstellungen werden vorgenommen, indem Sie das Kontrollkästchen `Kristallparameter (C)` unten im Feld anhaken (siehe [Kristallparameter](3-crystal-parameter.md)). `Alle aktivieren/deaktivieren` aktiviert oder deaktiviert die gesamte Kristallliste auf einmal.
