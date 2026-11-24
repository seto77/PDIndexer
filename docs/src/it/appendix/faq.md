<!-- 261124Cl added: Q&A page, compiled anonymously from GitHub issues and support e-mails to the author (2006–2026); reviewed with codex2 (2 rounds). Lead language: ja/appendix/faq.md -->
# Q&A

Questa pagina raccoglie domande realmente poste dagli utenti, concentrandosi su quelle più frequenti e sui punti facili da fraintendere. Per errori e problemi di avvio, vedi anche [Risoluzione dei problemi](troubleshooting.md).

## Cosa provare per prima cosa {#first-steps}

### Qualcosa non va (non compaiono linee di diffrazione, un file non si legge, compare un errore all'avvio). Cosa devo provare per prima cosa?

Cerca prima in questa pagina la voce che corrisponde al tuo sintomo. Quando non compaiono linee di diffrazione, la causa è quasi sempre l'impostazione della radiazione o della lunghezza d'onda ([Linee di diffrazione ed elenco dei cristalli](#peaks-and-crystals)). Se questo non basta, prova i passaggi seguenti in quest'ordine.

1. Aggiorna all'ultima versione (`Aiuto` ▸ `Aggiornamenti del programma`, oppure scaricala dalla [pagina delle release](https://github.com/seto77/PDIndexer/releases/latest)).
2. Spunta `Opzioni` ▸ `Cancella registro (spunta e riavvia)`, poi chiudi e riavvia PDIndexer. PDIndexer memorizza nel registro le posizioni delle finestre, le impostazioni del fascio e così via, e le impostazioni ereditate da una versione precedente possono causare problemi.
3. Se l'elenco dei cristalli sembra errato, esegui `File` ▸ `Ripristina i cristalli allo stato iniziale`.

!!! warning "Cosa si perde"
    - **Cancellando il registro** si eliminano le impostazioni salvate e **le macro registrate nella finestra delle macro**. Esporta prima come file `.mcr` le macro che ti servono. L'elenco dei cristalli non è memorizzato nel registro ma in un file separato (`%APPDATA%\PDIndexer\PDIndexer\default.xml`), quindi la cancellazione del registro non lo elimina.
    - **Ripristinando l'elenco dei cristalli** si perdono i cristalli che hai aggiunto o modificato. Salva prima i cristalli che ti servono con `File` ▸ `Salva cristalli`.

### Quando uso PDIndexer insieme a IPAnalyzer, ottengo errori o valori errati.

[IPAnalyzer](https://github.com/seto77/IPAnalyzer) e PDIndexer condividono una libreria comune e si scambiano i dati attraverso gli appunti. Se ne viene aggiornato solo uno, il formato di scambio può non corrispondere, causando errori o valori errati. **Mantieni entrambi aggiornati allo stesso tempo.**

## Installazione e avvio {#install}

### Non riesco a installare PDIndexer su un PC senza diritti di amministratore, oppure un criterio blocca l'MSI.

Usa il **pacchetto ZIP senza installazione** (`PDIndexer-v.<ver>.zip` per x64, `PDIndexer-v.<ver>_arm64.zip` per Arm64). Include il runtime, quindi non servono né l'MSI né un .NET Desktop Runtime separato. Estrai l'intera cartella in una posizione in cui puoi scrivere ed esegui `PDIndexer.exe` nella cartella estratta. PDIndexer stesso funziona con i normali diritti utente.

Vedi [Runtime e installazione](runtime-and-installation.md) per le differenze tra i pacchetti MSI e ZIP.

!!! note
    PDIndexer è un software di ricerca non firmato, quindi Windows (SmartScreen) o il browser possono mostrare un avviso quando lo scarichi o lo esegui per la prima volta. Nell'elenco dei download del browser scegli **Altre informazioni** ▸ **Mantieni**; all'avviso di esecuzione scegli **Ulteriori informazioni** ▸ **Esegui comunque**.

### Compare il messaggio "You must install .NET Desktop Runtime", anche se ho installato .NET.

La causa è di solito una delle seguenti.

- **Versione principale errata.** La versione di .NET richiesta cambia tra le versioni di PDIndexer. Installa il **Desktop Runtime** della versione indicata per la release che usi. Il semplice ".NET Runtime" non basta.
- **Architettura errata.** La build x64 di PDIndexer richiede il runtime x64; la build Arm64 richiede il runtime Arm64. Su Windows per processori Arm (PC Snapdragon, ecc.), usa il programma di installazione Arm64 `PDIndexer-setup_arm64.msi`.
- Se ancora non funziona, il **pacchetto ZIP senza installazione**, che include il runtime, è la scelta più affidabile.

## Linee di diffrazione ed elenco dei cristalli {#peaks-and-crystals}

### Spunto un cristallo ma non compaiono linee di diffrazione, oppure sono molto spostate.

Controlla prima quanto segue.

- [`Mostra i picchi sopra i profili`](../3-crystal-parameter.md) è attivo e il cristallo è spuntato nell'elenco dei cristalli.
- **La radiazione e la lunghezza d'onda (o l'energia) della misura sono impostate correttamente.** I dati di testo come i CSV spesso non contengono informazioni sulla lunghezza d'onda; in tal caso, specifica la radiazione e la lunghezza d'onda usate per la misura nella finestra di dialogo mostrata alla lettura del file. Controlla la radiazione e la lunghezza d'onda usate per la visualizzazione nella [scheda `Asse orizzontale`](../1-main-window.md#horizontal-axis-tab) della finestra principale.
- Le linee non sono fuori dall'intervallo di disegno. Prova ad allargare l'intervallo orizzontale (soprattutto per il TOF neutronico).
- Se non compare un solo cristallo, controlla che i suoi parametri reticolari e le posizioni atomiche non siano molto lontani dal vero e confrontalo con la stessa sostanza nel database incorporato.

### Ho trascinato una linea di diffrazione e i parametri reticolari sono cambiati. Riavviando non tornano come prima.

I parametri reticolari modificati trascinando una linea di diffrazione vengono salvati alla chiusura di PDIndexer, perché `Opzioni` ▸ `Salva l'elenco dei cristalli alla chiusura` è attivo per impostazione predefinita. Riavviando, quindi, la modifica non viene annullata.

- Per tornare ai parametri reticolari che il cristallo aveva quando è stato caricato nella sessione corrente, fai clic destro sulle informazioni del cristallo e scegli `Ripristina le costanti di cella`.
- Per riportare l'intero elenco dei cristalli allo stato immediatamente successivo all'installazione, scegli `File` ▸ `Ripristina i cristalli allo stato iniziale`.

### L'elenco dei cristalli contiene valori strani o duplicati, oppure manca uno standard di pressione (Au, Pt, ecc.).

`File` ▸ `Ripristina i cristalli allo stato iniziale` ripristina l'elenco iniziale dei cristalli, compresi gli standard di pressione. I cristalli che hai aggiunto tu vanno persi, quindi salvali prima, se necessario.

### I rapporti di intensità non vengono calcolati; tutte le linee hanno la stessa altezza.

Per calcolare i rapporti di intensità, il cristallo deve avere le posizioni atomiche e [`Calcola il rapporto di intensità`](../3-crystal-parameter.md) deve essere attivo. Anche impostazioni errate della radiazione danno intensità errate. Vedi [Risoluzione dei problemi](troubleshooting.md) per i dettagli.

### Come importo cristalli da CSManager o da file CIF?

- **Da CSManager**: apri prima la finestra `Parametri del cristallo` di PDIndexer e attiva `Opzioni` ▸ `Monitora appunti`, poi seleziona il cristallo in CSManager. Non è necessario esportare prima un CIF.
- I **file CIF / AMC** possono essere trascinati e rilasciati sull'area delle informazioni del cristallo della finestra Parametri del cristallo.
- Puoi anche cercare nel **database dei cristalli incorporato** (AMCSD). Vedi [Parametri del cristallo](../3-crystal-parameter.md).

In ogni caso il cristallo compare nell'area delle informazioni del cristallo. Premi `Aggiungi` per conservarlo nell'elenco dei cristalli.

### Posso sovrapporre dati a raggi X e dati da elettroni (o da un'altra lunghezza d'onda) sullo stesso asse orizzontale?

Sì. PDIndexer ha un unico asse orizzontale, e ogni profilo caricato viene convertito nella radiazione e nella lunghezza d'onda scelte nella scheda `Asse orizzontale`. Ad esempio, un profilo di diffrazione elettronica può essere mostrato sulla scala 2θ di Cu Kα.

Se nella scheda `Asse orizzontale` è attivo `Dopo la lettura del profilo, cambia l'asse orizzontale`, le impostazioni dell'asse passano a quelle di ciascun file appena caricato. Disattiva questa opzione per mantenere fisso l'asse di confronto.

## Lettura dei profili e asse orizzontale {#profiles-and-axis}

### Qual è la differenza tra la scheda `Asse orizzontale` della finestra principale e `Impostazione assi` nella finestra dei parametri del profilo?

- La scheda `Asse orizzontale` (finestra principale) decide solo **come vengono visualizzati i dati**; i dati del profilo non cambiano.
- [`Impostazione assi`](../4-profile-parameter.md#axis-setting) (finestra dei parametri del profilo) riscrive **le condizioni in cui il profilo è stato misurato** (tipo di radiazione, lunghezza d'onda, angolo di take-off, ecc.). Se alla lettura del file hai scelto la radiazione o la lunghezza d'onda sbagliata, correggila qui. Se hai inserito valori nell'**unità** sbagliata, rileggi il file originale.

### I dati a dispersione di energia (raggi X bianchi) (`.npd` / `.nxs`) hanno un asse orizzontale errato, oppure non compaiono linee di diffrazione.

Nella finestra di dialogo mostrata alla lettura del file, controlla che l'**unità dell'energia (eV / keV)**, il **2θ** e, per `.nxs`, i **coefficienti di calibrazione canale-energia** corrispondano alla misura. I file `.npd` usano la colonna dell'energia presente nel file, quindi controlla anche i valori e l'unità nel file originale. Un'unità errata sposta di molto le posizioni dei picchi.

### PDIndexer può leggere i file GSAS `.gsa` (2θ in centesimi di grado) o dati su un asse q (numero d'onda)?

Sì.

- Per un file `.gsa` (tre colonne separate da spazi, con 2θ in centesimi di grado), nella finestra di dialogo di conversione dei dati scegli 2θ come asse orizzontale e `Centi-grado` come unità.
- Per i dati su un asse q (numero d'onda), scegli q come asse orizzontale. Puoi anche raffinare i parametri reticolari sull'asse q.

## Fitting dei picchi e parametri reticolari {#fitting}

### Quale valore devo usare per `Intervallo di ricerca`? Il volume cambia quando lo modifico.

`Intervallo di ricerca` è l'ampiezza di ricerca su ciascun lato del centro del picco. Parti da **2–3 volte la larghezza a metà altezza (FWHM)** del picco e restringilo se il picco vicino si sovrappone. Un intervallo troppo ampio cattura altri picchi o il fondo, mentre uno troppo stretto taglia le code del picco; in entrambi i casi la posizione fittata si sposta. Usare molti **picchi ad alto angolo** migliora la precisione dei parametri reticolari.

### I valori mostrati in `Parametri di cella ottimizzati` sono già applicati al cristallo?

No. `Parametri di cella ottimizzati` si limita a **visualizzare** i valori ottenuti dalle riflessioni selezionate e dalle condizioni di fitting. Per sovrascrivere i parametri reticolari del cristallo, premi `Applica al cristallo`. Per usare i valori senza modificare il cristallo, usa `Copia negli appunti`. Premere `Applica al cristallo` alcune volte può favorire la convergenza, perché le posizioni calcolate delle linee vengono aggiornate ogni volta.

### Seleziono le stesse riflessioni, ma l'errore del volume diventa improvvisamente grande.

Il fitting dei picchi (adattamento di una funzione a ciascun picco) e il raffinamento dei parametri reticolari sono calcoli separati. PDIndexer cerca un picco solo all'interno dell'intervallo di ricerca di ciascuna riflessione, quindi se un picco di un'altra fase o del rumore cade nell'intervallo, un valore d errato entra nel calcolo dei parametri reticolari.

- Controlla il fit di ciascuna riflessione nell'elenco delle riflessioni ed escludi i picchi dubbi o deboli.
- Quando il rapporto segnale/rumore è scarso, raffina prima con i soli picchi forti e aggiungi poi quelli più deboli. Servono almeno tante riflessioni indipendenti quanti sono i parametri reticolari indipendenti del sistema cristallino (1 per il cubico, 6 per il triclino), e più di queste per stimare gli errori.
- Per pattern deboli o con forti sovrapposizioni, un fitting dell'intero pattern come l'analisi di Rietveld può essere più adatto.

Vedi [Algoritmi](algorithms.md#lattice-refinement) per il modo in cui vengono calcolati i parametri reticolari e i loro errori.

## Analisi sequenziale e macro {#sequential-and-macro}

### Voglio fittare automaticamente molti profili (risolti nel tempo, a passi di pressione, ecc.) e ottenere parametri reticolari o pressioni.

Usa l'[Analisi sequenziale](../7-sequential-analysis.md) (aprila dalla barra degli strumenti della finestra principale o con `Ctrl+Shift+S`). **Apri la finestra di fitting dei picchi** e scegli il cristallo e le riflessioni prima di eseguirla. Servono almeno quattro profili. I risultati possono essere salvati automaticamente.

- Leggere migliaia di profili in una volta usa molta memoria. Definisci prima le condizioni con circa 100 profili, poi esegui l'intero insieme.
- La lettura diretta da una cartella di rete è lenta. Copia i file su un disco locale prima dell'analisi.
- Se i parametri reticolari cambiano molto durante la serie, un picco può uscire dal suo intervallo di ricerca e può essere catturato un altro picco. Con `Fattore di tolleranza` attivo, i punti il cui volume differisce dal **volume all'inizio dell'esecuzione** di più del valore impostato (%) vengono restituiti come NaN.

### L'analisi sequenziale può fittare più fasi (ad es. il campione e un marcatore di pressione) contemporaneamente?

Vengono fittati i picchi di tutti i cristalli spuntati (con la separazione dei picchi impostata su `tra i cristalli`, anche i picchi sovrapposti di fasi diverse vengono separati insieme). Tuttavia, ogni esecuzione sequenziale registra i parametri reticolari e la pressione solo per l'unico cristallo selezionato nella finestra di fitting dei picchi. Per ottenere i risultati di un'altra fase, seleziona quel cristallo ed esegui di nuovo, oppure usa una [macro](../8-macro.md) che passa da un cristallo all'altro.

### Ho eseguito un'analisi degli sforzi su profili suddivisi per azimut, ma la scheda `Equazione di Singh` è vuota.

La modalità analisi degli sforzi viene selezionata solo quando **il nome del primo profilo nell'elenco dei profili termina con `whole`**. Per il secondo profilo e i successivi, il testo **dopo l'ultimo trattino** del nome viene letto come azimut in gradi (ad es. `sample-30`). Controlla anche che siano caricati almeno quattro profili e che la finestra di fitting dei picchi sia aperta. In un'esecuzione ordinaria (non in modalità sforzi), la scheda `Equazione di Singh` resta vuota. Vedi [Analisi sequenziale](../7-sequential-analysis.md) per i dettagli.

### Con la virgola come separatore decimale, le colonne del CSV dell'analisi sequenziale risultano sfalsate.

Il CSV dell'analisi sequenziale riutilizza i numeri mostrati a schermo, quindi con la virgola come separatore decimale (`1,5`) i decimali non si distinguono dai separatori di colonna. Per ora, usa `Copia` nella scheda dei risultati per copiare la tabella come testo separato da tabulazioni e incollala nel foglio di calcolo come dati separati da tabulazioni. L'esportazione CSV dei profili stessi (`File` ▸ `Esporta il/i profilo/i selezionato/i`) scrive sempre `.` come separatore decimale, indipendentemente dalle impostazioni internazionali.

### In quale linguaggio si scrivono le macro? Come devo scrivere i percorsi dei file?

Le macro si scrivono in **Python (IronPython)**. Scrivi i percorsi di Windows con barre normali (`'C:/data/sample.pdi2'`) oppure come stringhe raw (`r'C:\data\sample.pdi2'`). Le funzioni disponibili sono elencate nel riferimento delle funzioni di [Macro](../8-macro.md).

## Equazioni di stato {#eos}

### Ho inserito una temperatura. Il risultato è valido come pressione ad alta temperatura?

Alcune equazioni di stato (EOS) non hanno un termine di temperatura nell'articolo originale (equazioni isoterme), e la temperatura inserita non viene usata. Le EOS che interpolano tabelle della letteratura danno **pressioni inaccurate al di fuori dell'intervallo di temperatura e di volume della tabella**. Controlla la fonte e l'intervallo di validità dell'EOS in [Equazioni di stato](../5-equation-of-states.md).

## Altre domande {#others}

### Cosa devo inviare quando segnalo un bug?

Segnalalo nelle [GitHub Issues](https://github.com/seto77/PDIndexer/issues) con quanto segue.

- La versione di PDIndexer (`Aiuto` ▸ `Informazioni`) e la versione di Windows
- Un insieme minimo e condivisibile di file che riproduce il problema (profili, il `.xml` dell'elenco dei cristalli, file di impostazione di IPAnalyzer, ecc.)
- I passaggi eseguiti e il messaggio di errore o uno screenshot
- Il risultato atteso (il valore che ritieni corretto)

### Posso presentare o ridistribuire PDIndexer sulla pagina web di una beamline o di un laboratorio?

Sì. PDIndexer è distribuito con la [licenza MIT](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md). Quando lo ridistribuisci, includi l'avviso di copyright e il testo della licenza.
