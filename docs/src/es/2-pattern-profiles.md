<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Perfiles de difracción

Esta página describe los propios "datos de perfil" (el conjunto de datos medido) que maneja PDIndexer, y cómo cargarlos, mostrarlos y exportarlos. El procesamiento aplicado después de la carga —suavizado, sustracción de fondo, etc.— se realiza en la ventana [Parámetros del perfil](4-profile-parameter.md). Para la lista completa de extensiones de archivo admitidas, consulte [Formatos de archivo](appendix/file-formats.md).

![Ventana principal de PDIndexer con un perfil en el centro y las listas de perfiles y cristales a la izquierda.](../assets/cap-es-auto/FormMain.png)

## Qué es un perfil

Un perfil es un conjunto de datos unidimensional de "eje horizontal frente a intensidad" obtenido de una medición de difracción de polvo. El eje horizontal se expresa de una de las siguientes maneras, según la geometría de medición:

- \( 2\theta \) (ángulo de difracción) para la difracción dispersiva en ángulo (difracción de rayos X ordinaria)
- Energía para las mediciones dispersivas en energía (rayos X blancos, detección SSD)
- Tiempo de vuelo para el método de tiempo de vuelo (TOF) de neutrones
- En todos los casos, los datos también pueden manejarse internamente tras convertirlos al espaciado de red \( d \) o al vector de dispersión \( q \)

El eje vertical es la intensidad de difracción, que puede mostrarse como `Raw Counts` o `Count per Step (CPS)`, en escala lineal o logarítmica (consulte `Vertical Axis` en la página de la [Ventana principal](1-main-window.md)).

## Formatos de entrada admitidos

`File ▸ Read profile(s)` carga el formato propio de PDIndexer, así como la salida de otros programas y formatos de texto genéricos.

| Extensión | Contenido |
| --- | --- |
| `pdi` / `pdi2` | Formato de perfil nativo de PDIndexer (incluye la configuración de ejes y la información de procesamiento) |
| `csv` | Salida de WinPIP (separado por comas) |
| `chi` | Salida de Fit2D |
| `tsv` | Texto separado por tabulaciones |
| `ras` | Formato Rigaku (RAS) |
| `nxs` | Formato NeXus |
| `npd` / `xbm` / `rpt` (`rpf`) | Datos brutos de SSD (detector de estado sólido) |
| Otro texto | Cualquier texto de dos columnas ángulo (o valor d)–intensidad es generalmente legible |

!!! note "Lectura de texto genérico"
    Los archivos almacenados como texto ángulo–intensidad normalmente pueden leerse aunque no sean uno de los formatos estándar anteriores. Si no se puede determinar el tipo de eje horizontal o la longitud de onda/energía, especifíquelos en el cuadro de diálogo `Data Converter` que se describe a continuación.

La especificación detallada de cada formato se recoge en [Formatos de archivo](appendix/file-formats.md).

## Cómo cargar

Los perfiles pueden cargarse de varias maneras.

- **Menú** — `File ▸ Read profile(s)`. Se pueden seleccionar varios archivos a la vez.
- **Arrastrar y soltar** — Suelte archivos desde el Explorador sobre la ventana principal.
- **Watch Clipboard** — Cuando `Option ▸ Watch Clipboard` está activado, los perfiles/cristales copiados desde otras aplicaciones (p. ej. IPAnalyzer o CSManager) se importan automáticamente.
- **Watch File** — Cuando `Option ▸ Watch File` está activado y se elige una carpeta con `Set Directory to the watch`, los archivos de perfil `pdi` recién creados en esa carpeta se leen automáticamente. Esto resulta cómodo para la visualización en tiempo real durante una medición continua.

!!! tip "Alinear el eje horizontal automáticamente"
    Marcar `After reading profile, change horizontal axis` cambia la visualización del eje horizontal para que coincida con el perfil recién cargado inmediatamente después de leerlo.

## Modo Single Profile frente a Multi Profiles

Cambie el modo de visualización con `Single/Multi Profile` en el lado derecho de la ventana principal.

- **`Single Profile`** — Cargar un perfil nuevo reemplaza los datos anteriores; solo se muestra un perfil a la vez.
- **`Multi Profiles`** — Los perfiles cargados se superponen. Use `Increasing intensity by a profile` para desplazar ligeramente la intensidad de cada perfil de modo que varias curvas sean más fáciles de distinguir. Al activar `Change automatically color` se asigna un color de dibujo a cada perfil automáticamente.

## Lista de comprobación de perfiles

La lista `Profile` en el lado izquierdo de la ventana principal muestra todos los perfiles cargados.

- Solo los perfiles marcados se dibujan en el visor central. Use `Check/Uncheck all` para alternarlos todos a la vez.
- Haga clic en la columna `Color` para cambiar el color de dibujo de cada perfil.
- Reordene las entradas de la lista para ajustar el orden de dibujo de la superposición.
- La lista está deshabilitada en el modo Single Profile y muestra varios perfiles en el modo Multi Profiles.

Los ajustes de perfil más detallados (nombre, estilo de línea, suavizado, sustracción de fondo, corrección de ejes, operaciones de perfil, etc.) se realizan en la ventana [Parámetros del perfil](4-profile-parameter.md), que se abre marcando la casilla `Profile Parameter` debajo de la lista.

## Cuadro de diálogo Data Converter

Cuando carga un archivo de texto genérico cuyo tipo de eje horizontal no se puede determinar, o datos brutos de SSD (dispersivos en energía), se abre el cuadro de diálogo `Data Converter` para que pueda especificar el eje horizontal de los datos que se leen y sus parámetros asociados.

![Cuadro de diálogo Data Converter con la configuración del eje horizontal, el tiempo de exposición y las opciones EDX.](../assets/cap-es-auto/FormDataConverter.png)

El cuadro de diálogo establece los siguientes elementos.

| Elemento | Contenido |
| --- | --- |
| Configuración del eje horizontal | Especifica el tipo de eje horizontal de los datos (longitud de onda/energía de rayos X, 2θ, longitud/ángulo de TOF de neutrones, etc.) y los parámetros de fuente correspondientes. |
| `Exposure time (per step)` | Tiempo de exposición (medición) por paso de datos, en segundos. Se usa para la conversión a CPS; los valores ≤ 0 se tratan como 1. |
| `Deconvolution` | La eliminación de Kα2 se ha trasladado al formulario [Parámetros del perfil](4-profile-parameter.md). Para eliminarla, seleccione Kα1 como fuente de rayos X. |
| `Low energy cutoff` en `For SSD data` | Descarta el lado de baja energía del espectro EDX por debajo del umbral (eV) situado a la derecha. |

Cuando el tipo de eje horizontal es dispersivo en energía (rayos X blancos, EDX), introduzca los coeficientes de calibración de energía de `E = a₀ + a₁ n + a₂ n²` (E: energía en eV, n: número de canal) para convertir los números de canal en energía. Haga clic en `OK` para aplicar la configuración y convertir los datos, o en `Cancel` para abortar la importación.

## Exportación de perfiles

- **`File ▸ Save profile(s)`** — Guarda todos los perfiles cargados en el formato `pdi2` nativo de PDIndexer. La configuración de ejes y la información de procesamiento se conservan.
- **`File ▸ Export the selected profile(s)`** — Exporta los perfiles seleccionados en uno de los siguientes formatos:
  - `as CSV (comma separated values) file` — separado por comas (ángulo, intensidad)
  - `as TSV (tab separated values) file` — separado por tabulaciones
  - `as GSAS file` — formato de datos GSAS (Rietveld)

!!! note "Guardar la figura"
    Para guardar la figura representada en lugar de los datos del perfil, use `File ▸ Copy to Clipboard` o `File ▸ Save as Metafile` (EMF). EMF es un formato vectorial que puede importarse en PowerPoint y Word.
