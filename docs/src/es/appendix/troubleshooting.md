<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Resolución de problemas

Si encuentra un problema al usar PDIndexer, revise primero los puntos siguientes. La mayoría de los problemas se resuelven instalando el runtime o revisando una configuración.

## La aplicación no se inicia

PDIndexer requiere el **.NET Desktop Runtime 10.0**. Si el runtime no está instalado, es posible que vea un error al iniciar, o que el programa se cierre sin hacer nada.

!!! warning "Solución"
    Siga [Runtime e instalación](runtime-and-installation.md) para instalar el último **.NET Desktop Runtime 10.0** (x64) y, a continuación, reinicie PDIndexer.

## El idioma de la interfaz no cambia

Puede cambiar el idioma de la interfaz desde el menú en **Opciones** ▸ **Idioma**, eligiendo **English (need restart)** o **Japanese (need restart)**. Sin embargo, un cambio de idioma solo surte efecto **tras un reinicio**.

!!! note
    Es normal que la pantalla no cambie inmediatamente después de elegir un idioma. Cierre PDIndexer e inícielo de nuevo.

## Restablecer una configuración dañada

Las posiciones de las ventanas, la configuración de colores y diversas opciones se guardan en el registro. Si la configuración se daña y el programa se comporta de forma incorrecta, puede borrar el registro para volver al estado inicial.

1. En el menú, marque **Opciones** ▸ **Borrar el registro (marcar y reiniciar)**.
2. Cierre PDIndexer. Toda la configuración guardada se borra al salir.
3. Inicie PDIndexer de nuevo; arrancará en su estado inicial (predeterminado).

!!! warning
    Esto borra toda la configuración guardada, incluida la disposición de las ventanas y las opciones. No se puede deshacer hasta que reinicie y la configuración se restablezca.

## La importación desde el portapapeles de IPAnalyzer / CSManager no funciona

Los perfiles y cristales copiados en aplicaciones hermanas como [IPAnalyzer](https://github.com/seto77/IPAnalyzer) y [CSManager](https://github.com/seto77/CSManager) pueden importarse automáticamente en PDIndexer a través del portapapeles. Si no se importa nada, es posible que la vigilancia del portapapeles esté desactivada.

- Compruebe que **Opciones** ▸ **Vigilar portapapeles** esté activado en el menú.
- Cuando está activado, los perfiles/cristales copiados desde otras aplicaciones se leen automáticamente.

!!! tip
    Si desea leer automáticamente los archivos `.pdi` recién creados en una carpeta concreta, use **Opciones** ▸ **Vigilar archivo**.

## Los cocientes de intensidad no se calculan

Para calcular las intensidades de difracción teóricas, la estructura del cristal debe contener **posiciones atómicas (coordenadas atómicas)**. Si no se introducen las posiciones atómicas, aún se pueden calcular las posiciones de los picos (valores de \(d\)), pero no los cocientes de intensidad.

!!! note "Solución"
    En [Parámetros del cristal](../3-crystal-parameter.md), introduzca el elemento, las coordenadas y la ocupación de cada átomo. Una vez introducidas las posiciones atómicas, los cocientes de intensidad se calculan a partir del factor de estructura.

## El ajuste informa de parámetros de red NA (no disponibles)

Al refinar los parámetros de red mediante el ajuste de picos, un número insuficiente de reflexiones independientes puede dejar los parámetros de red sin determinar, y el resultado puede informarse como NA (no disponible).

- Según el sistema cristalino, debe proporcionar suficientes reflexiones para que se pueda determinar el número de parámetros de red independientes (p. ej., solo \(a\) para el cúbico, pero seis valores \(a, b, c, \alpha, \beta, \gamma\) para el triclínico).
- Si las reflexiones son linealmente dependientes (sesgadas hacia una dirección), ciertos parámetros de red no pueden determinarse. Incluya reflexiones de orientaciones diferentes.

!!! note "Solución"
    Consulte [Ajuste de picos de difracción](../6-fitting-diffraction-peaks.md) y asegúrese de que el ajuste incluya suficientes reflexiones independientes.

## Sigue sin resolverse

Para los problemas que los pasos anteriores no resuelven, o para errores reproducibles y solicitudes de funciones, comuníquelos en el rastreador de incidencias de GitHub. Si es posible, incluya los pasos para reproducirlo, el archivo que utilizó y una captura de pantalla.

- Rastreador de incidencias: <https://github.com/seto77/PDIndexer/issues>
