<!-- 260601Cl: English landing page for the PDIndexer Pages manual (content migrated from the legacy docx + yseto.net web manual). -->
<!-- 260625Cl: static-i18n folder mode へ移設 (docs/src/index.md → docs/src/en/index.md)。画像は ../assets、内部リンクは en/ 接頭辞を剥がす。 -->
# PDIndexer-Handbuch

**PDIndexer** ist eine kostenlose, MIT-lizenzierte Windows-Anwendung zur Analyse eindimensionaler Pulverdiffraktionsmuster (Labor-/Synchrotron-Röntgenstrahlung, Neutronen-TOF). Sie zeigt gemessene Profile an, überlagert berechnete Beugungslinien aus Kristallstrukturen, verarbeitet und kalibriert Profile, passt Peaks an, um Gitterkonstanten mit der Methode der kleinsten Quadrate zu verfeinern, und schätzt den Druck aus den Zustandsgleichungen von Standardmaterialien ab.

![PDIndexer-Hauptfenster](../assets/cap-de-auto/FormMain.png)

## Nach Ziel suchen

| Ziel | Hier starten | Wichtigste nächste Schritte |
|------|------------|-----------------|
| Ein gemessenes Profil laden und anzeigen | [2. Beugungsprofile](2-pattern-profiles.md) | [1. Hauptfenster](1-main-window.md), [Dateiformate](appendix/file-formats.md) |
| Phasen durch Überlagern bekannter Kristalle identifizieren | [3. Kristallparameter](3-crystal-parameter.md) | [2. Beugungsprofile](2-pattern-profiles.md) |
| Ein Profil verarbeiten / kalibrieren | [4. Profilparameter](4-profile-parameter.md) | [3. Kristallparameter](3-crystal-parameter.md) |
| Peaks anpassen und Gitterkonstanten verfeinern | [6. Beugungspeak-Anpassung](6-fitting-diffraction-peaks.md) | [3. Kristallparameter](3-crystal-parameter.md) |
| Druck aus einem Standardmaterial abschätzen | [5. Zustandsgleichungen](5-equation-of-states.md) | [6. Beugungspeak-Anpassung](6-fitting-diffraction-peaks.md) |
| Eine Serie von Profilen stapelweise verarbeiten | [7. Sequentielle Analyse](7-sequential-analysis.md) | [8. Makro](8-macro.md) |
| Aufgaben mit Skripten automatisieren | [8. Makro](8-macro.md) | [7. Sequentielle Analyse](7-sequential-analysis.md) |

## Inhalt

- [0. Überblick](0-overview.md) — was PDIndexer leistet und seine wichtigsten Funktionen
- [1. Hauptfenster](1-main-window.md) — Layout, Menüs, Symbolleiste, Profil-/Kristallliste
- [2. Beugungsprofile](2-pattern-profiles.md) — Profildaten, unterstützte Formate, Laden
- [3. Kristallparameter](3-crystal-parameter.md) — Beugungslinien-Anzeige, Kristallinformationen, Datenbank
- [4. Profilparameter](4-profile-parameter.md) — Profilverarbeitung, Achseneinstellungen, Operatoren
- [5. Zustandsgleichungen](5-equation-of-states.md) — Druck aus der EOS eines Standardmaterials
- [6. Beugungspeak-Anpassung](6-fitting-diffraction-peaks.md) — Peak-Anpassung und Gitterverfeinerung
- [7. Sequentielle Analyse](7-sequential-analysis.md) — Stapelanalyse über eine Profilserie
- [8. Makro](8-macro.md) — IronPython-Skripting und Funktionsreferenz

### Anhang

- [Laufzeit und Installation](appendix/runtime-and-installation.md)
- [Dateiformate](appendix/file-formats.md)
- [Fehlerbehebung](appendix/troubleshooting.md)

## Schnellstart

1. Von [Releases](https://github.com/seto77/PDIndexer/releases/latest) herunterladen und installieren, dann *PDIndexer* starten.
2. Ein gemessenes Profil öffnen (eine Datei per Drag & Drop ziehen oder ein aus [IPAnalyzer](https://github.com/seto77/IPAnalyzer) kopiertes Profil einfügen).
3. Bekannte Kristalle aus der integrierten Datenbank hinzufügen (oder eine CIF-/AMC-Datei importieren), um deren Beugungslinien zu überlagern.
4. Die Peaks anpassen, um Gitterkonstanten zu verfeinern, oder den Druck aus der Zustandsgleichung eines Standardmaterials abschätzen.

## Systemanforderungen

| Element | Anforderung |
|------|-------------|
| Betriebssystem | Windows mit [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) (**nicht** die .NET Runtime) |
| Empfohlen | 64-Bit-Windows 10/11, 16 GB oder mehr Arbeitsspeicher, CPU mit 8 oder mehr Kernen |

Siehe [Laufzeit und Installation](appendix/runtime-and-installation.md) für Details.

!!! note
    Quellcode, Releases und der Issue-Tracker befinden sich auf [GitHub](https://github.com/seto77/PDIndexer). PDIndexer wird unter der [MIT License](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md) vertrieben.
