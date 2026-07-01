<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Panoramica

![Finestra principale di PDIndexer](../assets/cap-it-auto/FormMain.png)

PDIndexer è un'applicazione software per l'analisi di pattern di diffrazione da polveri di raggi X monodimensionali. Consente di visualizzare e analizzare profili di diffrazione ottenuti da strumenti di diffrazione da polveri di raggi X, da raggi X di sincrotrone misurati con ottica in trasmissione Debye-Scherrer e da misure di tempo di volo (TOF) di neutroni.

Fornisce un insieme completo di strumenti per l'analisi della diffrazione da polveri, tra cui la visualizzazione sovrapposta di più profili, il confronto con le linee di diffrazione di cristalli noti, la calibrazione di temperatura e pressione rispetto a materiali standard, il fitting dei profili e il raffinamento ai minimi quadrati dei parametri reticolari.

!!! note "Informazioni su questo manuale"
    Questa pagina è solo una panoramica. Per istruzioni dettagliate su ciascuna funzione, consultare le pagine dedicate.

## Funzioni principali

PDIndexer offre le seguenti funzioni.

| Funzione | Descrizione |
| --- | --- |
| Visualizzazione e confronto dei profili | Sovrapponi e confronta più profili di diffrazione. L'asse orizzontale (\(2\theta\) / \(d\) / \(q\)) e le scale dell'asse verticale possono essere commutati in modo flessibile. |
| Confronto con cristalli noti | Calcola le linee di diffrazione di cristalli noti e le sovrappone al profilo osservato per l'identificazione. Per i dettagli, vedi [Parametri del cristallo](3-crystal-parameter.md). |
| Calibrazione con materiali standard | Utilizzando equazioni di stato (EOS) come NaCl EOS e Pt EOS, stima temperatura e pressione dal volume di cella di un materiale standard. Per i dettagli, vedi [Equazione di stato (EOS)](5-equation-of-states.md). |
| Fitting dei picchi | Fitta la posizione, la larghezza a metà altezza (FWHM) e l'intensità dei picchi di diffrazione. Per i dettagli, vedi [Fitting](6-fitting-diffraction-peaks.md). |
| Raffinamento dei parametri reticolari | Raffina i parametri reticolari dalle posizioni dei picchi con i minimi quadrati. Il **Cell Finder** può anche cercare i parametri reticolari a partire dalle posizioni dei picchi. |
| Analisi sequenziale | Elabora in blocco una serie di file con la funzione **Analisi sequenziale**. Per i dettagli, vedi [Analisi sequenziale](7-sequential-analysis.md). |
| Importazione / esportazione | Importa strutture cristalline da file CIF e AMC ed esporta nei formati CSV, TSV e GSAS (Rietveld). |
| Caricamento automatico | Monitora gli appunti o una cartella per leggere automaticamente profili/cristalli copiati da altre app (ad es. IPAnalyzer) o file appena creati. |

!!! tip "Dati supportati"
    È possibile gestire un'ampia gamma di profili, inclusi quelli provenienti da strumenti di diffrazione da polveri di raggi X, raggi X di sincrotrone (ottica in trasmissione Debye-Scherrer) e misure di tempo di volo (TOF) di neutroni.

## Licenza

Questo software è distribuito con la **Licenza MIT** ([LICENSE.md](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md)). Chiunque è libero di utilizzare questo software gratuitamente, a condizione che vengano accettate le seguenti condizioni.

- Puoi liberamente copiare, distribuire, modificare, ridistribuire versioni modificate, utilizzare a scopo commerciale, vendere a pagamento o comunque utilizzare il software in qualsiasi modo.
- In caso di ridistribuzione, includi l'avviso di copyright di questo software e il testo completo di questa licenza nel codice sorgente, oppure in un file di licenza separato allegato al codice sorgente.
- Questo software è fornito senza alcuna garanzia. L'autore non si assume alcuna responsabilità per eventuali problemi derivanti dall'uso di questo software.

## Feedback

Invia i tuoi commenti e le tue richieste tramite le [Issues](https://github.com/seto77/PDIndexer/issues) di GitHub. Il codice sorgente è pubblicato su [github.com/seto77/PDIndexer](https://github.com/seto77/PDIndexer).

## Installazione e requisiti di sistema

PDIndexer richiede un sistema operativo Windows in grado di eseguire il **.NET Desktop Runtime 6.0 o successivo**. Alcune funzioni richiedono risorse di calcolo consistenti; per migliorare la velocità vengono utilizzati il multithreading e l'accelerazione GPU. Per un uso confortevole, si consiglia un Windows 10/11 a 64 bit con 16 GB o più di memoria e una CPU a 8 core o più.

Per i passaggi dettagliati di installazione e i requisiti di sistema, vedi [Ambiente di esecuzione e installazione](appendix/runtime-and-installation.md).
