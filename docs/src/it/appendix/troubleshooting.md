<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Risoluzione dei problemi

Se si verifica un problema durante l'uso di PDIndexer, controllare prima gli elementi qui sotto. La maggior parte dei problemi si risolve installando il runtime o rivedendo un'impostazione.

## L'applicazione non si avvia

PDIndexer richiede il **.NET Desktop Runtime 10.0**. Se il runtime non è installato, all'avvio potrebbe comparire un errore, oppure il programma potrebbe terminare senza fare nulla.

!!! warning "Soluzione"
    Seguire [Runtime e installazione](runtime-and-installation.md) per installare l'ultimo **.NET Desktop Runtime 10.0** (x64), quindi riavviare PDIndexer.

## La lingua dell'interfaccia non cambia

È possibile cambiare la lingua dell'interfaccia dal menu **Opzioni** ▸ **Lingua**, scegliendo **English (need restart)** o **Japanese (need restart)**. Tuttavia, il cambio di lingua ha effetto solo **dopo un riavvio**.

!!! note
    È normale che la visualizzazione non cambi immediatamente dopo aver scelto una lingua. Chiudere PDIndexer e avviarlo di nuovo.

## Reimpostare le impostazioni corrotte

Le posizioni delle finestre, le impostazioni dei colori e le varie opzioni vengono salvate nel registro. Se le impostazioni si corrompono e il programma si comporta in modo anomalo, è possibile cancellare il registro per tornare allo stato iniziale.

1. Dal menu, spuntare **Opzioni** ▸ **Cancella registro (spunta e riavvia)**.
2. Chiudere PDIndexer. Tutte le impostazioni salvate vengono cancellate all'uscita.
3. Avviare di nuovo PDIndexer; si aprirà nel suo stato iniziale (predefinito).

!!! warning
    Questa operazione cancella tutte le impostazioni salvate, comprese la disposizione delle finestre e le opzioni. Non può essere annullata finché non si riavvia e le impostazioni vengono reimpostate.

## L'importazione dagli appunti da IPAnalyzer / CSManager non funziona

I profili e i cristalli copiati in app affini come [IPAnalyzer](https://github.com/seto77/IPAnalyzer) e [CSManager](https://github.com/seto77/CSManager) possono essere importati automaticamente in PDIndexer tramite gli appunti. Se non viene importato nulla, il monitoraggio degli appunti potrebbe essere disabilitato.

- Verificare che **Opzioni** ▸ **Monitora appunti** sia abilitato nel menu.
- Quando è abilitato, i profili/cristalli copiati da altre app vengono letti automaticamente.

!!! tip
    Se si desidera leggere automaticamente i file `.pdi` appena creati in una cartella specifica, utilizzare **Opzioni** ▸ **Monitora file**.

## I rapporti di intensità non vengono calcolati

Per calcolare le intensità di diffrazione teoriche, la struttura del cristallo deve contenere **posizioni atomiche (coordinate atomiche)**. Se le posizioni atomiche non vengono inserite, le posizioni dei picchi (valori \(d\)) possono comunque essere calcolate, ma i rapporti di intensità no.

!!! note "Soluzione"
    In [Parametri del cristallo](../3-crystal-parameter.md), inserire l'elemento, le coordinate e l'occupazione per ciascun atomo. Una volta inserite le posizioni atomiche, i rapporti di intensità vengono calcolati dal fattore di struttura.

## Il fitting riporta parametri reticolari NA (non disponibili)

Quando si raffinano i parametri reticolari con il fitting dei picchi, un numero insufficiente di riflessi indipendenti può lasciare i parametri reticolari indeterminati, e il risultato può essere riportato come NA (non disponibile).

- A seconda del sistema cristallino, è necessario fornire riflessi sufficienti affinché sia determinabile il numero di parametri reticolari indipendenti (ad esempio solo \(a\) per il cubico, ma sei valori \(a, b, c, \alpha, \beta, \gamma\) per il triclino).
- Se i riflessi sono linearmente dipendenti (concentrati in una sola direzione), alcuni parametri reticolari non possono essere determinati. Includere riflessi di orientazioni diverse.

!!! note "Soluzione"
    Consultare [Fitting dei picchi di diffrazione](../6-fitting-diffraction-peaks.md) e assicurarsi che il fitting includa un numero sufficiente di riflessi indipendenti.

## Ancora non risolto

Per i problemi che i passaggi precedenti non risolvono, o per bug riproducibili e richieste di funzionalità, segnalarli sull'issue tracker di GitHub. Se possibile, includere i passaggi per riprodurre il problema, il file utilizzato e uno screenshot.

- Issue tracker: <https://github.com/seto77/PDIndexer/issues>
