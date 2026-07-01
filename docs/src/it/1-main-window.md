<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Finestra principale

All'avvio del software compare la schermata mostrata di seguito. La finestra principale è composta dall'**area di disegno del profilo** centrale, dalla **barra dei menu** e dalla **barra degli strumenti (elenco delle funzioni)** in alto, dal menu a schede vicino alla parte superiore (`Asse orizzontale` / `Aspetto && Profilo singolo/multiplo`), dall'**elenco dei profili** in alto a destra e dall'**elenco dei cristalli** in basso a destra.

![L'intera finestra principale di PDIndexer](../assets/cap-it-auto/FormMain.png)

## Area di disegno del profilo

Quest'area occupa la maggior parte della finestra e visualizza i profili spuntati nell'elenco dei profili. Quando un cristallo è selezionato nell'elenco dei cristalli, vengono tracciate anche le linee di diffrazione in corrispondenza delle posizioni dei picchi di diffrazione.

### Operazioni con il mouse

| Operazione | Azione |
| --- | --- |
| Trascinamento sinistro | Sposta le linee di diffrazione (modifica i parametri reticolari del cristallo) |
| Trascinamento destro | Ingrandisci |
| Clic destro | Riduci |
| Trascinamento centrale | Sposta la vista (pan) |

Gli intervalli di disegno degli assi orizzontale e verticale possono essere modificati digitando i valori direttamente nelle caselle numeriche sopra l'area di disegno (`2θ:`, `d:`, `Int.:`, `q:`, ecc., le cui etichette dipendono dalla modalità dell'asse orizzontale selezionata).

!!! tip
    La modalità di visualizzazione dell'asse orizzontale (angolo, energia, distanza interplanare, ecc.) si commuta nella [scheda `Asse orizzontale`](#horizontal-axis-tab). Si tratta di un'impostazione di sola visualizzazione e non modifica i dati dell'asse orizzontale del profilo stesso.

## Barra degli strumenti (elenco delle funzioni)

Ogni pulsante della barra degli strumenti apre e chiude una finestra di analisi dedicata.

| Pulsante | Funzione | Vedi |
| --- | --- | --- |
| `Parametri cristallo (C)` | Apre e chiude la finestra Parametri cristallo. | [Parametri del cristallo](3-crystal-parameter.md) |
| `Parametri profilo (P)` | Apre e chiude la finestra Parametri profilo. | [Parametri del profilo](4-profile-parameter.md) |
| `Equazione di stato (E)` | Apre e chiude la finestra Equazione di stato per stimare la pressione dal volume di cella di un materiale standard. | [Equazioni di stato](5-equation-of-states.md) |
| `Adattamento picchi di diffrazione (F)` | Apre e chiude la finestra Adattamento picchi per adattare i picchi di diffrazione (posizione, FWHM, intensità). | [Fitting dei picchi di diffrazione](6-fitting-diffraction-peaks.md) |
| `Cell Finder` | Apre e chiude la finestra Cell Finder per cercare i parametri reticolari dalle posizioni dei picchi. | — |
| `Analisi sequenziale` | Apre e chiude la finestra Analisi sequenziale per l'elaborazione in batch di una serie di file. | [Analisi sequenziale](7-sequential-analysis.md) |
| `Atomic Position Finder` | Apre e chiude la finestra Atomic Position Finder per cercare le posizioni atomiche dalle intensità di diffrazione. | — |
| `Analisi LPO` | Apre e chiude la finestra Analisi LPO (orientazione preferenziale del reticolo). | — |

!!! note
    Le finestre principali possono essere aperte e chiuse anche con le scorciatoie da tastiera: `Ctrl+Shift+C` (Parametri cristallo), `Ctrl+Shift+E` (Equazioni di stato), `Ctrl+Shift+F` (Parametri adattamento) e `Ctrl+Shift+D` (cambia modalità picco).

## Barra dei menu

### File

| Voce | Descrizione |
| --- | --- |
| `Leggi profilo/i` | Legge i dati di profilo. Oltre al formato proprietario `pdi` / `pdi2` di questo software, è possibile leggere il `csv` prodotto da WinPIP, il `chi` prodotto da Fit2D e così via. Si possono leggere anche la maggior parte dei file memorizzati come testo angolo-intensità. |
| `Salva profilo/i` | Salva tutti i profili caricati nel formato `pdi2` di questo software. |
| `Esporta il/i profilo/i selezionato/i` | Esporta il/i profilo/i selezionato/i come file di dati separati da virgola (CSV), separati da tabulazione (TSV) o GSAS (Rietveld). |
| `Carica cristalli (come nuova lista)` | Carica un file di elenco cristalli (estensione `xml`). L'elenco dei cristalli attuale viene scartato. |
| `Carica cristalli (e aggiungi alla lista attuale)` | Carica un file di elenco cristalli (estensione `xml`) e lo aggiunge in coda all'elenco dei cristalli attuale. |
| `Salva cristalli` | Salva l'elenco dei cristalli attuale in un file (estensione `xml`). |
| `Importa CIF, AMC...` | Importa un file di dati strutturali in formato `cif` o `amc` e lo aggiunge all'elenco dei cristalli attuale. |
| `Esporta il cristallo selezionato in CIF` | Salva il cristallo selezionato come file di dati strutturali in formato `cif`. |
| `Ripristina i cristalli allo stato iniziale` | Ripristina l'elenco dei cristalli allo stato iniziale (predefinito). |
| `Imposta pagina` | Apre la finestra di impostazione pagina per la stampa. |
| `Anteprima di stampa` | Mostra un'anteprima di stampa del visualizzatore di profili. |
| `Stampa` | Stampa. L'intervallo di stampa corrisponde all'attuale intervallo di angolo e intensità. |
| `Copia negli appunti` | Copia il profilo attualmente disegnato negli appunti come dati bitmap o dati metafile (vettoriali). |
| `Salva come Metafile` | Salva il profilo attualmente disegnato in formato metafile. È supportato il formato EMF (Enhanced Meta File) e i file `*.emf` salvati possono essere aperti in PowerPoint e Word. |
| `Chiudi` | Chiude PDIndexer. |

### Opzioni

| Voce | Descrizione |
| --- | --- |
| `Suggerimento` | Se spuntato, visualizza i suggerimenti nella finestra principale. |
| `Monitora appunti` | Monitora gli appunti e importa automaticamente i dati di profilo/cristallo copiati da altre app (es. IPAnalyzer). |
| `Monitora file` | Monitora una cartella specificata e legge automaticamente i file di profilo `.pdi` appena creati. Scegli la cartella da monitorare dalla finestra di selezione o digitando direttamente il percorso. |
| `Cancella registro (spunta e riavvia)` | Se spuntato, cancella all'uscita tutte le impostazioni salvate dal registro (riavvia per reimpostare). |
| `Salva l'elenco dei cristalli alla chiusura` | Se spuntato, salva automaticamente l'elenco dei cristalli all'uscita e lo ricarica all'avvio. |

### Macro

`Editor` apre la finestra dell'editor delle macro. Per i dettagli sulla funzione macro di PDIndexer, vedi [Macro](8-macro.md).

### Aiuto

| Voce | Descrizione |
| --- | --- |
| `Informazioni` | Mostra il copyright, la versione e le informazioni sull'autore, oltre alla cronologia delle versioni. |
| `Aggiornamenti del programma` | Cerca online una versione più recente e, se disponibile, la scarica/installa. |
| `Suggerimento` | Mostra i suggerimenti d'uso (deprecato). |
| `Aiuto (web)` | Mostra questo manuale. |

### Lingua

Cambia la lingua dell'interfaccia. Attualmente sono supportati l'inglese (`English (need restart)`) e il giapponese (`Japanese (need restart)`). Dopo il cambio è necessario un riavvio.

## Scheda Asse orizzontale {#horizontal-axis-tab}

La scheda `Asse orizzontale` imposta la modalità di visualizzazione dell'asse. Le impostazioni qui presenti sono di sola visualizzazione e non hanno relazione con i dati effettivi dell'asse orizzontale (le informazioni effettive dell'asse orizzontale possono essere modificate dai [Parametri del profilo](4-profile-parameter.md)). Per questo motivo è possibile allineare l'asse orizzontale per il confronto anche quando sono state usate sorgenti di raggi X diverse. Ad esempio, anche se il profilo caricato è stato acquisito con la linea Cu Kα, può essere visualizzato come se fosse stato acquisito alla lunghezza d'onda della linea Mo Kα.

| Voce | Descrizione |
| --- | --- |
| `Dopo la lettura del profilo, cambia l'asse orizzontale` | Se spuntato, allinea automaticamente le impostazioni dell'asse orizzontale a quelle del profilo appena caricato. |
| 2θ (degree) | Imposta l'asse orizzontale sull'angolo. Scegliendo il pulsante di opzione `X-ray` si ottiene l'angolo di diffusione per i raggi X; seleziona una sorgente di raggi X caratteristica o `Custom` dall'elenco a discesa e specifica la lunghezza d'onda. Scegliendo il pulsante di opzione `Electron` si ottiene l'angolo di diffusione per gli elettroni; specificando la tensione di accelerazione si calcola la lunghezza d'onda corretta relativisticamente. |
| Energy (eV) | Imposta l'asse orizzontale sull'energia (unità eV). Corrisponde a un esperimento di diffrazione a raggi X che utilizza un rivelatore EDX. Imposta correttamente l'angolo di uscita (take-off) EDX. |
| d-spacing (Å) | Imposta l'asse orizzontale sulla distanza interplanare (spaziatura dei piani reticolari). |
| q | Imposta l'asse orizzontale sul modulo del vettore di diffusione \( q \). |

La relazione tra l'angolo di diffusione e la distanza interplanare è data dalla legge di Bragg, con \( \lambda \) la lunghezza d'onda:

$$ 2 d \sin\theta = n \lambda $$

## Scheda Aspetto e Profilo singolo/multiplo

La scheda `Aspetto && Profilo singolo/multiplo` configura l'aspetto del disegno e la visualizzazione a profilo singolo/multiplo.

### Impostazioni di scala e colore

| Voce | Descrizione |
| --- | --- |
| `Linea scala` | Seleziona se visualizzare le linee di scala (griglia). |
| `Barra di errore` | Visualizza le barre di errore quando i dati contengono informazioni sull'errore. |
| `Colore` | Imposta i colori di visualizzazione, come `Colore sfondo`, `Linea scala` e `Testo scala`. |

### Profilo singolo/multiplo

La modalità spuntata è la modalità corrente.

| Voce | Descrizione |
| --- | --- |
| `Profilo singolo` | Modalità a profilo singolo. Quando un profilo viene caricato, o inviato da IPAnalyzer tramite gli appunti, il vecchio profilo viene eliminato e viene disegnato il nuovo profilo. |
| `Profili multipli` | Modalità a profili multipli. I nuovi profili vengono caricati e sovrapposti a quelli esistenti. |
| `Incremento di intensità per profilo` | Imposta l'offset di intensità tra i dati quando si sovrappongono più set di dati. Serve solo a mantenere leggibile la visualizzazione; i dati effettivi non vengono modificati. |
| `Cambia colore automaticamente` | Se spuntato, cambia automaticamente il colore di disegno dei profili. |

### Asse verticale

Specifica se visualizzare l'asse verticale (intensità) come conteggi grezzi (`Conteggi grezzi`) o come conteggi per passo (`Conteggi per passo (CPS)`). Puoi anche specificare se visualizzare l'asse verticale su scala lineare (`Lineare`) o logaritmica (`Logaritmica`).

## Elenco dei profili

Visualizza e seleziona i profili caricati. È disabilitato nella modalità `Profilo singolo`.

Nella modalità a profili multipli, i profili caricati sono mostrati come elenco e solo quelli spuntati vengono disegnati nell'area di disegno centrale. Impostazioni più dettagliate del profilo si effettuano spuntando la casella `Parametri profilo` nella parte inferiore del riquadro (vedi [Parametri del profilo](4-profile-parameter.md)).

## Elenco dei cristalli

Visualizza e configura l'elenco dei cristalli. Spuntando una voce si tracciano le linee di diffrazione in corrispondenza delle posizioni dei picchi di diffrazione. Per impostazione predefinita sono preregistrati circa 80 cristalli.

!!! note "Righe speciali"
    - La prima riga (riga 0) è il **Flexible Crystal** (sfondo ciano), usato per tracciare linee di diffrazione arbitrarie.
    - Le righe superiori (sfondo rosa, es. `NaCl EOS` e `Pt EOS`) sono riservate come materiali standard per i calcoli con l'equazione di stato (EOS).

Impostazioni più dettagliate del cristallo si effettuano spuntando la casella `Parametri cristallo (C)` nella parte inferiore del riquadro (vedi [Parametri del cristallo](3-crystal-parameter.md)). `Seleziona/Deseleziona tutto` spunta o deseleziona l'intero elenco dei cristalli in una sola volta.
