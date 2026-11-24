<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Resolución de problemas

Si encuentra un problema al usar PDIndexer, revise primero los puntos siguientes. La mayoría de los problemas se resuelven instalando el runtime o revisando una configuración.

## La aplicación no se inicia

Estos requisitos se aplican a las compilaciones .NET 11 de este código fuente. Para las versiones publicadas, siga los requisitos de runtime indicados para esa versión.

La instalación MSI de PDIndexer requiere el **.NET Desktop Runtime** especificado por esa versión (las compilaciones de este código fuente usan .NET 11). El ZIP sin instalación incluye su runtime. Si el runtime no está instalado en una instalación MSI, es posible que vea un error al iniciar, o que el programa se cierre sin hacer nada.

!!! warning "Solución"
    Siga [Runtime e instalación](runtime-and-installation.md) para instalar el **.NET Desktop Runtime** requerido por la versión que utilice, correspondiente a la arquitectura de la aplicación (x64 o Arm64), y, a continuación, reinicie PDIndexer.

## El idioma de la interfaz no cambia

<!-- 261124Cl changed: the old text described an English/Japanese choice and a manual restart; now there are 11 languages and PDIndexer restarts itself after a confirmation dialog -->
Elija el idioma de visualización (11 idiomas, cada uno mostrado con su propio nombre) en **Idioma**, en el extremo derecho de la barra de menús. Cambiar el idioma requiere un reinicio: elija **Sí** en el cuadro de diálogo de confirmación y PDIndexer se reiniciará automáticamente en el idioma seleccionado.

!!! note
    El reinicio descarta el trabajo no guardado (perfiles cargados y ediciones en curso), así que guarde lo que necesite antes de cambiar. Si elige **No**, el idioma no cambia.

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

Al refinar los parámetros de red mediante el ajuste de picos, un número insuficiente de reflexiones independientes deja los parámetros de red sin determinar. En ese caso, el programa conserva la forma original de la celda y solo cambia su escala global, y los campos de error muestran NA (no disponible). Cuando el número de reflexiones es igual al número de parámetros de red independientes, los residuos no permiten obtener errores estándar, por lo que los campos de error también muestran NA.

- Según el sistema cristalino, debe proporcionar suficientes reflexiones para que se pueda determinar el número de parámetros de red independientes (p. ej., solo \(a\) para el cúbico, pero seis valores \(a, b, c, \alpha, \beta, \gamma\) para el triclínico).
- Si las reflexiones son linealmente dependientes (sesgadas hacia una dirección), ciertos parámetros de red no pueden determinarse. Incluya reflexiones de orientaciones diferentes.

!!! note "Solución"
    Consulte [Ajuste de picos de difracción](../6-fitting-diffraction-peaks.md) y asegúrese de que el ajuste incluya suficientes reflexiones independientes.

## Sigue sin resolverse

Para los problemas que los pasos anteriores no resuelven, o para errores reproducibles y solicitudes de funciones, comuníquelos en el rastreador de incidencias de GitHub. Si es posible, incluya los pasos para reproducirlo, el archivo que utilizó y una captura de pantalla.

- Rastreador de incidencias: <https://github.com/seto77/PDIndexer/issues>
