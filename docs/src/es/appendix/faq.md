<!-- 261124Cl added: Q&A page, compiled anonymously from GitHub issues and support e-mails to the author (2006–2026); reviewed with codex2 (2 rounds). Lead language: ja/appendix/faq.md -->
# Q&A

Esta página recoge preguntas que los usuarios han planteado realmente, centrándose en las más frecuentes y en los puntos que se prestan a malentendidos. Para errores y problemas de inicio, consulte también [Resolución de problemas](troubleshooting.md).

## Qué probar primero {#first-steps}

### Algo no funciona (no aparecen líneas de difracción, no se puede leer un archivo, aparece un error al iniciar). ¿Qué debo probar primero?

Busque primero en esta página el apartado que corresponda a su síntoma. Cuando no aparecen líneas de difracción, la causa es casi siempre la configuración de la radiación o de la longitud de onda ([Líneas de difracción y lista de cristales](#peaks-and-crystals)). Si eso no ayuda, pruebe lo siguiente en este orden.

1. Actualice a la versión más reciente (`Ayuda` ▸ `Buscar actualizaciones`, o descárguela desde la [página de versiones](https://github.com/seto77/PDIndexer/releases/latest)).
2. Marque `Opciones` ▸ `Borrar el registro (marcar y reiniciar)` y, a continuación, cierre y vuelva a iniciar PDIndexer. PDIndexer guarda en el registro las posiciones de las ventanas, la configuración del haz, etc., y una configuración heredada de una versión antigua puede causar problemas.
3. Si la lista de cristales parece incorrecta, ejecute `Archivo` ▸ `Restaurar los cristales al estado inicial`.

!!! warning "Qué se pierde"
    - **Al borrar el registro** se eliminan la configuración guardada y **las macros registradas en la ventana de macros**. Exporte antes como archivos `.mcr` las macros que necesite. La lista de cristales no se guarda en el registro sino en un archivo aparte (`%APPDATA%\PDIndexer\PDIndexer\default.xml`), por lo que borrar el registro no la elimina.
    - **Al restaurar la lista de cristales** se descartan los cristales que haya añadido o editado. Guarde antes los cristales que necesite con `Archivo` ▸ `Guardar cristales`.

### Cuando uso PDIndexer junto con IPAnalyzer, obtengo errores o valores incorrectos.

[IPAnalyzer](https://github.com/seto77/IPAnalyzer) y PDIndexer comparten una biblioteca común e intercambian datos a través del portapapeles. Si solo se actualiza uno de ellos, el formato de intercambio puede no coincidir, lo que puede provocar errores o valores incorrectos. **Mantenga ambos actualizados a la vez.**

## Instalación e inicio {#install}

### No puedo instalar PDIndexer en un PC sin derechos de administrador, o una directiva bloquea el MSI.

Use el **paquete ZIP sin instalación** (`PDIndexer-v.<ver>.zip` para x64, `PDIndexer-v.<ver>_arm64.zip` para Arm64). Incluye el runtime, por lo que no necesita ni el MSI ni un .NET Desktop Runtime por separado. Extraiga la carpeta completa en una ubicación en la que pueda escribir y ejecute `PDIndexer.exe` en la carpeta extraída. El propio PDIndexer funciona con derechos de usuario normales.

Consulte [Entorno de ejecución e instalación](runtime-and-installation.md) para conocer las diferencias entre los paquetes MSI y ZIP.

!!! note
    PDIndexer es software de investigación sin firmar, por lo que Windows (SmartScreen) o su navegador pueden mostrar una advertencia al descargarlo o al ejecutarlo por primera vez. En la lista de descargas del navegador, elija **Más información** ▸ **Conservar**; en la advertencia al ejecutarlo, elija **Más información** ▸ **Ejecutar de todas formas**.

### Dice "You must install .NET Desktop Runtime", aunque he instalado .NET.

La causa suele ser una de las siguientes.

- **Versión principal incorrecta.** La versión de .NET requerida cambia entre versiones de PDIndexer. Instale el **Desktop Runtime** de la versión indicada para la versión de PDIndexer que utilice. El ".NET Runtime" simple no es suficiente.
- **Arquitectura incorrecta.** La versión x64 de PDIndexer necesita el runtime x64; la versión Arm64 necesita el runtime Arm64. En Windows basado en Arm (PCs con Snapdragon, etc.), use el instalador Arm64 `PDIndexer-setup_arm64.msi`.
- Si sigue sin funcionar, el **paquete ZIP sin instalación**, que incluye el runtime, es la opción más fiable.

## Líneas de difracción y lista de cristales {#peaks-and-crystals}

### Marco un cristal pero no aparecen líneas de difracción, o aparecen muy desplazadas.

Compruebe primero lo siguiente.

- [`Mostrar picos sobre los perfiles`](../3-crystal-parameter.md) está activado y el cristal está marcado en la lista de cristales.
- **La radiación y la longitud de onda (o la energía) de la medición están configuradas correctamente.** Los datos de texto como CSV a menudo no contienen información sobre la longitud de onda; en ese caso, especifique la radiación y la longitud de onda usadas en la medición en el cuadro de diálogo que se muestra al leer el archivo. Compruebe la radiación y la longitud de onda usadas para la visualización en la [pestaña `Eje horizontal`](../1-main-window.md#horizontal-axis-tab) de la ventana principal.
- Las líneas no están fuera del rango de dibujo. Pruebe a ampliar el rango horizontal (sobre todo para TOF de neutrones).
- Si solo un cristal no aparece, compruebe que sus parámetros de red y posiciones atómicas no son muy distintos de los esperados, y compárelo con la misma sustancia de la base de datos integrada.

### Arrastré una línea de difracción y cambiaron los parámetros de red. Reiniciar no los restablece.

Los parámetros de red modificados al arrastrar una línea de difracción se guardan al cerrar PDIndexer, porque `Opciones` ▸ `Guardar la lista de cristales al cerrar` está activado de forma predeterminada. Por eso, reiniciar no deshace el cambio.

- Para volver a los parámetros de red que tenía el cristal cuando se cargó en la sesión actual, haga clic con el botón derecho en la información del cristal y elija `Revertir constantes de celda`.
- Para devolver toda la lista de cristales a su estado justo después de la instalación, elija `Archivo` ▸ `Restaurar los cristales al estado inicial`.

### La lista de cristales contiene valores extraños o duplicados, o falta un estándar de presión (Au, Pt, etc.).

`Archivo` ▸ `Restaurar los cristales al estado inicial` restaura la lista inicial de cristales, incluidos los estándares de presión. Los cristales que haya añadido usted se pierden, así que guárdelos antes si es necesario.

### No se calculan las relaciones de intensidad; todas las líneas tienen la misma altura.

Para calcular las relaciones de intensidad, el cristal necesita posiciones atómicas y [`Calcular relación de intensidad`](../3-crystal-parameter.md) debe estar activado. Una configuración de radiación incorrecta también da intensidades incorrectas. Consulte [Resolución de problemas](troubleshooting.md) para más detalles.

### ¿Cómo importo cristales desde CSManager o desde archivos CIF?

- **Desde CSManager**: abra primero la ventana `Parámetros del cristal` de PDIndexer y active `Opciones` ▸ `Vigilar portapapeles`; a continuación, seleccione el cristal en CSManager. No es necesario exportar antes un CIF.
- **Los archivos CIF / AMC** se pueden arrastrar y soltar en el área de información del cristal de la ventana Parámetros del cristal.
- También puede buscar en la **base de datos de cristales integrada** (AMCSD). Consulte [Parámetros del cristal](../3-crystal-parameter.md).

En todos los casos, el cristal aparece en el área de información del cristal. Pulse `Añadir` para conservarlo en la lista de cristales.

### ¿Puedo superponer datos de rayos X y de electrones (o de otra longitud de onda) en el mismo eje horizontal?

Sí. PDIndexer tiene un único eje horizontal, y todos los perfiles cargados se convierten a la radiación y la longitud de onda elegidas en la pestaña `Eje horizontal`. Por ejemplo, un perfil de difracción de electrones puede mostrarse en la escala 2θ de Cu Kα.

Si `Tras leer el perfil, cambiar el eje horizontal` está activado en la pestaña `Eje horizontal`, la configuración del eje cambia a la de cada archivo recién cargado. Desactive esta opción para mantener un eje fijo al comparar.

## Lectura de perfiles y eje horizontal {#profiles-and-axis}

### ¿Qué diferencia hay entre la pestaña `Eje horizontal` de la ventana principal y `Configuración de ejes` de la ventana de parámetros del perfil?

- La **pestaña `Eje horizontal`** (ventana principal) solo decide **cómo se muestran los datos**; los datos del perfil en sí no cambian.
- **[`Configuración de ejes`](../4-profile-parameter.md#axis-setting)** (ventana de parámetros del perfil) reescribe **las condiciones en las que se midió el perfil** (tipo de radiación, longitud de onda, ángulo de salida, etc.). Si eligió una radiación o una longitud de onda incorrectas al leer el archivo, corríjalas aquí. Si introdujo los valores en una **unidad** incorrecta, vuelva a leer el archivo original.

### Los datos de dispersión de energía (rayos X blancos) (`.npd` / `.nxs`) tienen un eje horizontal incorrecto, o no aparecen líneas de difracción.

En el cuadro de diálogo que se muestra al leer el archivo, compruebe que la **unidad de energía (eV / keV)**, el **2θ** y, para `.nxs`, los **coeficientes de calibración de canal a energía** coinciden con la medición. Los archivos `.npd` usan la columna de energía del archivo, así que compruebe también los valores y la unidad en el archivo original. Una unidad incorrecta desplaza mucho las posiciones de los picos.

### ¿Puede PDIndexer leer archivos GSAS `.gsa` (2θ en centésimas de grado) o datos en un eje q (número de onda)?

Sí.

- Para un archivo `.gsa` (tres columnas separadas por espacios con 2θ en centésimas de grado), elija 2θ como eje horizontal y centésimas de grado (centi-degree) como unidad en el cuadro de diálogo de conversión de datos.
- Para datos en un eje q (número de onda), elija q como eje horizontal. También puede refinar los parámetros de red en el eje q.

## Ajuste de picos y parámetros de red {#fitting}

### ¿Qué valor debo usar para `Rango de búsqueda`? El volumen cambia cuando lo modifico.

`Rango de búsqueda` es el ancho de búsqueda a cada lado del centro del pico. Empiece con **2–3 veces la anchura a media altura (FWHM)** del pico y redúzcalo si se solapa el pico vecino. Un rango demasiado ancho recoge otros picos o el fondo, y uno demasiado estrecho corta las colas del pico; ambos desplazan la posición ajustada. Usar muchos **picos a ángulos altos** mejora la precisión de los parámetros de red.

### ¿Los valores mostrados en `Parámetros de celda optimizados` ya se han aplicado al cristal?

No. `Parámetros de celda optimizados` solo **muestra** los valores obtenidos a partir de las reflexiones seleccionadas y de las condiciones de ajuste. Para sobrescribir los parámetros de red del cristal, pulse `Aplicar al cristal`. Para usar los valores sin cambiar el cristal, use `Copiar al portapapeles`. Pulsar `Aplicar al cristal` varias veces puede ayudar a la convergencia, porque las posiciones calculadas de las líneas se actualizan cada vez.

### Selecciono las mismas reflexiones, pero el error del volumen se vuelve de pronto grande.

El ajuste de picos (ajuste de una función a cada pico) y el refinamiento de los parámetros de red son cálculos distintos. PDIndexer solo busca un pico dentro del rango de búsqueda de cada reflexión, por lo que, si un pico de otra fase o el ruido cae dentro del rango, un valor de d erróneo entra en el cálculo de los parámetros de red.

- Compruebe el ajuste de cada reflexión en la lista de reflexiones y excluya los picos dudosos o débiles.
- Cuando la relación señal/ruido es mala, refine primero solo con los picos intensos y añada después los más débiles. Necesita al menos tantas reflexiones independientes como parámetros de red independientes tenga el sistema cristalino (1 para el cúbico, 6 para el triclínico), y más para estimar los errores.
- Para patrones débiles o muy solapados, puede ser más adecuado un ajuste del patrón completo, como el análisis Rietveld.

Consulte [Algoritmos](algorithms.md#lattice-refinement) para ver cómo se calculan los parámetros de red y sus errores.

## Análisis secuencial y macros {#sequential-and-macro}

### Quiero ajustar automáticamente muchos perfiles (resueltos en el tiempo, por pasos de presión, etc.) y obtener parámetros de red o presiones.

Use el [Análisis secuencial](../7-sequential-analysis.md) (ábralo desde la barra de herramientas de la ventana principal o con `Ctrl+Shift+S`). **Abra la ventana de ajuste de picos** y elija el cristal y las reflexiones antes de ejecutarlo. Se necesitan al menos cuatro perfiles. Los resultados se pueden guardar automáticamente.

- Leer miles de perfiles a la vez consume mucha memoria. Ajuste primero las condiciones con unos 100 perfiles y, a continuación, procese el conjunto completo.
- Leer directamente desde una carpeta de red es lento. Copie los archivos a un disco local antes del análisis.
- Si los parámetros de red cambian mucho a lo largo de la serie, un pico puede salir de su rango de búsqueda y recogerse otro pico. Con `Factor de tolerancia` activado, los puntos cuyo volumen difiere del **volumen al inicio de la ejecución** en más del valor establecido (%) se emiten como NaN.

### ¿Puede el análisis secuencial ajustar varias fases (p. ej., la muestra y un marcador de presión) al mismo tiempo?

Se ajustan los picos de todos los cristales marcados (con la descomposición del patrón configurada en `entre cristales`, los picos solapados de distintas fases se separan conjuntamente). Sin embargo, cada ejecución secuencial registra los parámetros de red y la presión solo del cristal seleccionado en la ventana de ajuste de picos. Para obtener los resultados de otra fase, seleccione ese cristal y vuelva a ejecutarlo, o use una [macro](../8-macro.md) que cambie entre los cristales.

### Ejecuté un análisis de esfuerzo sobre perfiles divididos por azimut, pero la pestaña `Ecuación de Singh` está vacía.

El modo de análisis de esfuerzo solo se selecciona cuando **el nombre del primer perfil de la lista de perfiles termina en `whole`**. Para el segundo perfil y los siguientes, el texto **que sigue al último guion** del nombre se lee como el azimut en grados (p. ej., `sample-30`). Compruebe también que haya al menos cuatro perfiles cargados y que la ventana de ajuste de picos esté abierta. En una ejecución ordinaria (fuera del modo de esfuerzo), la pestaña `Ecuación de Singh` queda vacía. Consulte [Análisis secuencial](../7-sequential-analysis.md) para más detalles.

### Con la coma como separador decimal, las columnas del CSV del análisis secuencial aparecen desplazadas.

El CSV del análisis secuencial reutiliza los números mostrados en pantalla, por lo que con la coma como separador decimal (`1,5`) los decimales no se pueden distinguir de los separadores de columna. Por ahora, use `Copiar` en la pestaña de resultados para copiar la tabla como texto separado por tabuladores y péguela en su hoja de cálculo como datos separados por tabuladores. La exportación CSV de los propios perfiles (`Archivo` ▸ `Exportar el/los perfil(es) seleccionado(s)`) siempre escribe `.` como separador decimal, independientemente de la configuración regional.

### ¿En qué lenguaje se escriben las macros? ¿Cómo debo escribir las rutas de archivo?

Las macros se escriben en **Python (IronPython)**. Escriba las rutas de Windows con barras normales (`'C:/data/sample.pdi2'`) o como cadenas sin procesar (`r'C:\data\sample.pdi2'`). Las funciones disponibles se enumeran en la referencia de funciones de [Macro](../8-macro.md).

## Ecuaciones de estado {#eos}

### He introducido una temperatura. ¿Es válido el resultado como presión a alta temperatura?

Algunas ecuaciones de estado (EOS) no tienen término de temperatura en el artículo original (ecuaciones isotérmicas), y la temperatura que introduzca no se usa. Las EOS que interpolan tablas de la bibliografía dan **presiones inexactas fuera del intervalo de temperatura y volumen de la tabla**. Compruebe la fuente y el intervalo de validez de la EOS en [Ecuaciones de estado](../5-equation-of-states.md).

## Otras preguntas {#others}

### ¿Qué debo enviar al informar de un error?

Infórmelo en [GitHub Issues](https://github.com/seto77/PDIndexer/issues) con lo siguiente.

- La versión de PDIndexer (`Ayuda` ▸ `Acerca de PDIndexer`) y la versión de Windows
- Un conjunto mínimo de archivos que se pueda compartir y que reproduzca el problema (perfiles, el `.xml` de la lista de cristales, archivos de configuración de IPAnalyzer, etc.)
- Los pasos que siguió, y el mensaje de error o una captura de pantalla
- El resultado que esperaba (el valor que cree correcto)

### ¿Puedo presentar o redistribuir PDIndexer en la página web de una línea de luz o de un laboratorio?

Sí. PDIndexer se distribuye bajo la [Licencia MIT](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md). Cuando lo redistribuya, incluya el aviso de copyright y el texto de la licencia.
