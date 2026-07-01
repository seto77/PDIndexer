<!-- 260601Cl: English landing page for the PDIndexer Pages manual (content migrated from the legacy docx + yseto.net web manual). -->
<!-- 260625Cl: static-i18n folder mode へ移設 (docs/src/index.md → docs/src/en/index.md)。画像は ../assets、内部リンクは en/ 接頭辞を剥がす。 -->
# Manuale di PDIndexer

**PDIndexer** è un'applicazione Windows gratuita, con licenza MIT, per analizzare pattern di diffrazione da polveri monodimensionali (raggi X da laboratorio / sincrotrone, neutroni TOF). Visualizza i profili misurati, sovrappone le linee di diffrazione calcolate a partire dalle strutture cristalline, elabora e calibra i profili, esegue il fitting dei picchi per raffinare i parametri reticolari con i minimi quadrati e stima la pressione a partire dalle equazioni di stato dei materiali standard.

![Finestra principale di PDIndexer](../assets/cap-it-auto/FormMain.png)

## Trova per obiettivo

| Obiettivo | Inizia qui | Passi successivi principali |
|------|------------|-----------------|
| Caricare e visualizzare un profilo misurato | [2. Profili di diffrazione](2-pattern-profiles.md) | [1. Finestra principale](1-main-window.md), [Formati di file](appendix/file-formats.md) |
| Identificare le fasi sovrapponendo cristalli noti | [3. Parametri del cristallo](3-crystal-parameter.md) | [2. Profili di diffrazione](2-pattern-profiles.md) |
| Elaborare / calibrare un profilo | [4. Parametri del profilo](4-profile-parameter.md) | [3. Parametri del cristallo](3-crystal-parameter.md) |
| Eseguire il fitting dei picchi e raffinare i parametri reticolari | [6. Fitting dei picchi di diffrazione](6-fitting-diffraction-peaks.md) | [3. Parametri del cristallo](3-crystal-parameter.md) |
| Stimare la pressione da un materiale standard | [5. Equazioni di stato](5-equation-of-states.md) | [6. Fitting dei picchi di diffrazione](6-fitting-diffraction-peaks.md) |
| Elaborare in blocco una serie di profili | [7. Analisi sequenziale](7-sequential-analysis.md) | [8. Macro](8-macro.md) |
| Automatizzare i compiti con gli script | [8. Macro](8-macro.md) | [7. Analisi sequenziale](7-sequential-analysis.md) |

## Indice

- [0. Panoramica](0-overview.md) — cosa fa PDIndexer e le sue funzionalità principali
- [1. Finestra principale](1-main-window.md) — layout, menu, barra degli strumenti, liste di profili/cristalli
- [2. Profili di diffrazione](2-pattern-profiles.md) — dati di profilo, formati supportati, caricamento
- [3. Parametri del cristallo](3-crystal-parameter.md) — visualizzazione delle linee di diffrazione, informazioni sul cristallo, database
- [4. Parametri del profilo](4-profile-parameter.md) — elaborazione del profilo, impostazioni degli assi, operatori
- [5. Equazioni di stato](5-equation-of-states.md) — pressione dall'EOS di un materiale standard
- [6. Fitting dei picchi di diffrazione](6-fitting-diffraction-peaks.md) — fitting dei picchi e raffinamento reticolare
- [7. Analisi sequenziale](7-sequential-analysis.md) — analisi in blocco su una serie di profili
- [8. Macro](8-macro.md) — scripting IronPython e riferimento delle funzioni

### Appendice

- [Runtime e installazione](appendix/runtime-and-installation.md)
- [Formati di file](appendix/file-formats.md)
- [Risoluzione dei problemi](appendix/troubleshooting.md)

## Avvio rapido

1. Scarica e installa da [Releases](https://github.com/seto77/PDIndexer/releases/latest), quindi avvia *PDIndexer*.
2. Apri un profilo misurato (trascina e rilascia un file, oppure incolla un profilo copiato da [IPAnalyzer](https://github.com/seto77/IPAnalyzer)).
3. Aggiungi cristalli noti dal database integrato (oppure importa un file CIF/AMC) per sovrapporre le loro linee di diffrazione.
4. Esegui il fitting dei picchi per raffinare i parametri reticolari, oppure stima la pressione a partire dall'equazione di stato di un materiale standard.

## Requisiti di sistema

| Voce | Requisito |
|------|-------------|
| OS | Windows con [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) (**non** il .NET Runtime) |
| Consigliato | Windows 10/11 a 64 bit, 16 GB di memoria o più, CPU a 8 core o superiore |

Consulta [Runtime e installazione](appendix/runtime-and-installation.md) per i dettagli.

!!! note
    Il codice sorgente, le release e il tracker dei problemi si trovano su [GitHub](https://github.com/seto77/PDIndexer). PDIndexer è distribuito con la [licenza MIT](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md).
