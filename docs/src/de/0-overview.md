<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Überblick

![PDIndexer-Hauptfenster](../assets/cap-de-auto/FormMain.png)

PDIndexer ist eine Software zur Analyse eindimensionaler Pulver-Röntgenbeugungsmuster. Sie kann Beugungsprofile anzeigen und analysieren, die mit Pulver-Röntgenbeugungsgeräten, mit Synchrotron-Röntgenstrahlung in Debye-Scherrer-Transmissionsoptik sowie mit Neutronen-Flugzeitmessungen (TOF) gewonnen wurden.

Sie stellt einen vollständigen Satz von Werkzeugen für die Pulverdiffraktions-Analyse bereit, darunter die überlagerte Darstellung mehrerer Profile, den Vergleich mit den Beugungslinien bekannter Kristalle, die Temperatur- und Druckkalibrierung gegen Standardmaterialien, die Profilanpassung und die Verfeinerung der Gitterparameter nach der Methode der kleinsten Quadrate.

!!! note "Über dieses Handbuch"
    Diese Seite bietet nur einen Überblick. Ausführliche Anleitungen zu den einzelnen Funktionen finden Sie auf den jeweiligen eigenen Seiten.

## Hauptfunktionen

PDIndexer bietet die folgenden Funktionen.

| Funktion | Beschreibung |
| --- | --- |
| Anzeige und Vergleich von Profilen | Mehrere Beugungsprofile überlagern und vergleichen. Die Skalen der horizontalen Achse (\(2\theta\) / \(d\) / \(q\)) und der vertikalen Achse lassen sich flexibel umschalten. |
| Vergleich mit bekannten Kristallen | Berechnen Sie die Beugungslinien bekannter Kristalle und überlagern Sie sie zur Identifizierung mit dem beobachteten Profil. Siehe [Kristallparameter](3-crystal-parameter.md) für Details. |
| Kalibrierung mit Standards | Schätzen Sie mithilfe von Zustandsgleichungen (EOS) wie NaCl EOS und Pt EOS Temperatur und Druck aus dem Zellvolumen eines Standardmaterials. Siehe [Zustandsgleichung (EOS)](5-equation-of-states.md) für Details. |
| Peak-Anpassung | Passen Sie Position, Halbwertsbreite (FWHM) und Intensität von Beugungspeaks an. Siehe [Beugungspeak-Anpassung](6-fitting-diffraction-peaks.md) für Details. |
| Verfeinerung der Gitterparameter | Verfeinern Sie Gitterkonstanten aus Peak-Positionen nach der Methode der kleinsten Quadrate. Der **Cell Finder** kann zudem aus Peak-Positionen nach Gitterkonstanten suchen. |
| Sequentielle Analyse | Verarbeiten Sie eine Reihe von Dateien stapelweise mit der Funktion **Sequentielle Analyse**. Siehe [Sequentielle Analyse](7-sequential-analysis.md) für Details. |
| Import / Export | Importieren Sie Kristallstrukturen aus CIF- und AMC-Dateien und exportieren Sie in die Formate CSV, TSV und GSAS (Rietveld). |
| Automatisches Laden | Überwachen Sie die Zwischenablage oder einen Ordner, um Profile/Kristalle, die aus anderen Anwendungen (z. B. IPAnalyzer) kopiert wurden, oder neu erstellte Dateien automatisch einzulesen. |

!!! tip "Unterstützte Daten"
    Eine breite Palette von Profilen kann verarbeitet werden, darunter solche von Pulver-Röntgenbeugungsgeräten, Synchrotron-Röntgenstrahlung (Debye-Scherrer-Transmissionsoptik) und Neutronen-Flugzeitmessungen (TOF).

## Lizenz

Diese Software wird unter der **MIT License** verteilt ([LICENSE.md](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md)). Jeder darf diese Software kostenlos frei nutzen, sofern die folgenden Bedingungen akzeptiert werden.

- Sie dürfen die Software frei kopieren, verteilen, verändern, veränderte Versionen weiterverteilen, kommerziell nutzen, gegen Entgelt verkaufen oder auf jede andere Weise verwenden.
- Bei der Weiterverteilung fügen Sie den Urheberrechtshinweis dieser Software und den vollständigen Text dieser Lizenz in den Quellcode oder in eine separate, dem Quellcode beigefügte Lizenzdatei ein.
- Diese Software wird ohne jegliche Gewährleistung bereitgestellt. Der Autor übernimmt keinerlei Verantwortung für Probleme, die aus der Nutzung dieser Software entstehen.

## Feedback

Bitte senden Sie Ihre Kommentare und Wünsche über GitHub-[Issues](https://github.com/seto77/PDIndexer/issues). Der Quellcode ist unter [github.com/seto77/PDIndexer](https://github.com/seto77/PDIndexer) veröffentlicht.

## Installation und Systemvoraussetzungen

PDIndexer erfordert ein Windows-Betriebssystem, das **.NET Desktop Runtime 6.0 oder höher** ausführen kann. Einige Funktionen erfordern erhebliche Rechenressourcen; zur Beschleunigung werden Multithreading und GPU-Beschleunigung genutzt. Für eine komfortable Nutzung wird ein 64-Bit-Windows 10/11 mit 16 GB oder mehr Arbeitsspeicher und einer CPU mit 8 oder mehr Kernen empfohlen.

Ausführliche Installationsschritte und Systemvoraussetzungen finden Sie unter [Laufzeitumgebung und Installation](appendix/runtime-and-installation.md).
