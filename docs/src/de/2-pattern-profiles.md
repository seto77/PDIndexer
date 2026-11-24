<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Beugungsprofile

Diese Seite beschreibt die „Profildaten“ selbst (den gemessenen Datensatz), die PDIndexer verarbeitet, sowie das Laden, Anzeigen und Exportieren. Die nach dem Laden angewandte Verarbeitung — Glättung, Untergrundsubtraktion und so weiter — erfolgt im Fenster [Profilparameter](4-profile-parameter.md). Eine vollständige Liste der unterstützten Dateierweiterungen finden Sie unter [Dateiformate](appendix/file-formats.md).

![PDIndexer-Hauptfenster mit einem Profil in der Mitte und der Profil- und Kristallliste auf der rechten Seite.](../assets/cap-de-auto/FormMain.png)

## Was ein Profil ist

Ein Profil ist ein eindimensionaler Datensatz vom Typ „horizontale Achse vs. Intensität“, der aus einer Pulverdiffraktionsmessung gewonnen wird. Die horizontale Achse wird je nach Messgeometrie auf eine der folgenden Arten dargestellt:

- \( 2\theta \) (Beugungswinkel) für winkeldispersive Beugung (gewöhnliche Röntgenbeugung)
- Energie für energiedispersive Messungen (weiße Röntgenstrahlung, SSD-Detektion)
- Flugzeit für die Neutronen-Flugzeitmethode (TOF)
- In jedem Fall können die Daten intern auch nach Umrechnung in den Netzebenenabstand (d-Wert) \( d \) oder den Streuvektor \( q \) verarbeitet werden

Die vertikale Achse ist die Beugungsintensität, die als `Rohe Counts` oder als durch die Belichtungszeit in Sekunden geteilte Counts (`Counts pro Schritt (CPS)`) auf einer linearen oder logarithmischen Skala dargestellt werden kann (siehe `Vertikale Achse` auf der Seite [Hauptfenster](1-main-window.md)).

## Unterstützte Eingabeformate

`Datei` ▸ `Profil(e) lesen` lädt sowohl das eigene Format von PDIndexer als auch Ausgaben anderer Programme und generische Textformate.

| Erweiterung | Inhalt |
| --- | --- |
| `pdi` / `pdi2` | Natives Profilformat von PDIndexer (enthält Achseneinstellungen und Verarbeitungsinformationen) |
| `csv` | WinPIP-Ausgabe (kommagetrennt) |
| `chi` | Fit2D-Ausgabe |
| `tsv` | Tabulatorgetrennter Text |
| `ras` | Rigaku-Format (RAS) |
| `nxs` | NeXus-Format |
| `npd` / `xbm` / `rpt` (`rpf`) | SSD-Rohdaten (Halbleiterdetektor) |
| Sonstiger Text | Jeder zweispaltige Winkel- (oder d-Wert-)–Intensitäts-Text ist in der Regel lesbar |

!!! note "Generischen Text einlesen"
    Dateien, die als Winkel–Intensitäts-Text gespeichert sind, lassen sich in der Regel auch dann lesen, wenn sie keinem der oben genannten Standardformate entsprechen. Wenn der Typ der horizontalen Achse oder die Wellenlänge/Energie nicht bestimmt werden kann, geben Sie diese im unten beschriebenen Dialog `Datenkonverter` an.

Die ausführliche Spezifikation jedes Formats ist unter [Dateiformate](appendix/file-formats.md) zusammengestellt.

## Wie geladen wird

Profile können auf verschiedene Arten geladen werden.

- **Menü** — `Datei` ▸ `Profil(e) lesen`. Es können mehrere Dateien gleichzeitig ausgewählt werden.
- **Drag & Drop** — Ziehen Sie Dateien aus dem Explorer auf das Hauptfenster.
- `Zwischenablage überwachen` — Wenn `Optionen` ▸ `Zwischenablage überwachen` aktiviert ist, werden aus anderen Apps (z. B. IPAnalyzer oder CSManager) kopierte Profile/Kristalle automatisch importiert.
- `Datei überwachen` — Wenn `Optionen` ▸ `Datei überwachen` aktiviert und mit `Überwachungsverzeichnis festlegen` ein Ordner ausgewählt ist, werden neu erstellte `pdi`-Profildateien in diesem Ordner automatisch eingelesen. Das ist praktisch für die Echtzeitanzeige während einer kontinuierlichen Messung.

!!! tip "Horizontale Achse automatisch ausrichten"
    Wenn `Nach dem Laden des Profils horizontale Achse anpassen` aktiviert ist, wird die Anzeige der horizontalen Achse unmittelbar nach dem Einlesen an das neu geladene Profil angepasst.

## Modus Single Profile vs. Multi Profiles

Schalten Sie den Anzeigemodus mit `Einzel-/Mehrprofil` auf der rechten Seite des Hauptfensters um.

- `Einzelprofil` — Beim Laden eines neuen Profils werden die vorherigen Daten ersetzt; es wird immer nur ein Profil angezeigt.
- `Mehrere Profile` — Geladene Profile werden überlagert. Verwenden Sie `Intensitätsversatz pro Profil`, um die Intensität jedes Profils leicht zu versetzen, sodass sich mehrere Kurven leichter unterscheiden lassen. Bei aktiviertem `Farbe automatisch ändern` wird jedem Profil automatisch eine Zeichenfarbe zugewiesen.

## Profil-Checkliste

Die Liste `Profil` auf der rechten Seite des Hauptfensters zeigt alle geladenen Profile.

- Nur angehakte Profile werden im zentralen Anzeigebereich gezeichnet. Verwenden Sie `Alle aktivieren/deaktivieren`, um sie alle auf einmal umzuschalten.
- Klicken Sie auf die Spalte `Farbe`, um die Zeichenfarbe jedes Profils zu ändern.
- Ordnen Sie die Einträge in der Liste neu an, um die Zeichenreihenfolge der Überlagerung anzupassen.
- Die Liste ist im Modus `Einzelprofil` deaktiviert und zeigt im Modus `Mehrere Profile` mehrere Profile an.

Ausführlichere Profileinstellungen (Name, Linienart, Glättung, Untergrundsubtraktion, Achsenkorrektur, Profiloperationen und so weiter) werden im Fenster [Profilparameter](4-profile-parameter.md) vorgenommen, das durch Anhaken des Kontrollkästchens `Profilparameter` unterhalb der Liste geöffnet wird.

## Dialog Data Converter

Wenn Sie eine generische Textdatei laden, deren Typ der horizontalen Achse nicht bestimmt werden kann, oder SSD-Rohdaten (energiedispersiv), öffnet sich der Dialog `Datenkonverter`, in dem Sie die horizontale Achse der einzulesenden Daten und die zugehörigen Parameter angeben können.

![Dialog Datenkonverter mit Einstellungen für die horizontale Achse, Belichtungszeit und EDX-Optionen.](../assets/cap-de-auto/FormDataConverter.png)

Im Dialog werden die folgenden Punkte eingestellt.

| Punkt | Inhalt |
| --- | --- |
| Einstellung der horizontalen Achse | Geben Sie den Typ der horizontalen Achse der Daten an (Röntgen-Wellenlänge/-Energie, 2θ, Neutronen-TOF-Länge/-Winkel usw.) sowie die passenden Quellenparameter. |
| `Belichtungszeit (pro Schritt)` | Belichtungs- (Mess-)zeit pro Datenschritt in Sekunden. Sie wird für die CPS-Umrechnung verwendet; Werte ≤ 0 werden als 1 behandelt. |
| `Dekonvolution` | Die Kα2-Entfernung wurde in das Formular [Profilparameter](4-profile-parameter.md) verschoben. Um sie zu entfernen, wählen Sie Kα1 als Röntgenquelle. |
| `Niederenergie-Grenzwert` unter `Für SSD-Daten (*.rpf, *.npd, *.xbm, *.nxs)` | Verwirft die niederenergetische Seite des EDX-Spektrums unterhalb des rechts angegebenen Schwellenwerts (eV). |

Wenn der Typ der horizontalen Achse energiedispersiv ist (weiße Röntgenstrahlung, EDX), geben Sie die Energiekalibrierungskoeffizienten von `E = a₀ + a₁ n + a₂ n²` (E: Energie in eV, n: Kanalnummer) ein, um Kanalnummern in Energie umzurechnen. Klicken Sie auf `OK`, um die Einstellungen anzuwenden und die Daten zu konvertieren, oder auf `Abbrechen`, um den Import abzubrechen.

## Profile exportieren

- `Datei` ▸ `Profil(e) speichern` — Speichert alle geladenen Profile im nativen `pdi2`-Format von PDIndexer. Achseneinstellungen und Verarbeitungsinformationen bleiben erhalten.
- `Datei` ▸ `Ausgewählte Profil(e) exportieren` — Exportiert Profile in einem der folgenden Formate:
  - `als CSV-Datei (kommagetrennte Werte)` — Speichert die angehakten Profile als kommagetrennte Werte (X, Y), entweder gemeinsam in einer Datei oder als eine Datei pro Profil. Nachdem Sie den Speicherort gewählt haben, antworten Sie mit `Ja`, um sie zusammenzuführen, oder mit `Nein`, um sie getrennt zu speichern. X ist die Koordinate der angezeigten horizontalen Achse. Als Dezimaltrennzeichen wird unabhängig von den Regionseinstellungen immer `.` verwendet.
  - `als TSV-Datei (tabulatorgetrennte Werte)` — Speichert denselben Inhalt tabulatorgetrennt.
  - `als GSAS-Datei` — Schreibt das ausgewählte Profil im GSAS-Datenformat (Rietveld). Der Export ist nur möglich, wenn die horizontale Achse 2θ oder Neutronen-TOF ist.

!!! note "Die Abbildung speichern"
    Um die gerenderte Abbildung statt der Profildaten zu speichern, verwenden Sie `Datei` ▸ `In Zwischenablage kopieren` oder `Datei` ▸ `Als Metafile speichern` (EMF). EMF ist ein Vektorformat, das in PowerPoint und Word importiert werden kann.
