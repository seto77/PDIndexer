<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Descripción general

![Ventana principal de PDIndexer](../assets/cap-es-auto/FormMain.png)

PDIndexer es una aplicación de software para analizar patrones unidimensionales de difracción de polvo de rayos X. Permite mostrar y analizar perfiles de difracción obtenidos con instrumentos de difracción de polvo de rayos X, con rayos X de sincrotrón medidos mediante óptica de transmisión de Debye-Scherrer, y con mediciones de neutrones por tiempo de vuelo (TOF).

Ofrece un conjunto completo de herramientas para el análisis de difracción de polvo, que incluye la visualización superpuesta de varios perfiles, la comparación con las líneas de difracción de cristales conocidos, la calibración de temperatura y presión frente a materiales estándar, el ajuste de perfiles y el refinamiento por mínimos cuadrados de los parámetros de red.

!!! note "Acerca de este manual"
    Esta página es solo una descripción general. Para obtener instrucciones detalladas sobre cada función, consulte las páginas dedicadas.

## Funciones principales

PDIndexer ofrece las siguientes funciones.

| Función | Descripción |
| --- | --- |
| Visualización y comparación de perfiles | Superponga y compare varios perfiles de difracción. La escala del eje horizontal (\(2\theta\) / \(d\) / \(q\)) y del eje vertical se puede cambiar con flexibilidad. |
| Comparación con cristales conocidos | Calcule las líneas de difracción de cristales conocidos y superpóngalas sobre el perfil observado para su identificación. Consulte [Parámetros del cristal](3-crystal-parameter.md) para más detalles. |
| Calibración con estándares | Mediante ecuaciones de estado (EOS) como NaCl EOS y Pt EOS, estime la temperatura y la presión a partir del volumen de celda de un material estándar. Consulte [Ecuación de estado (EOS)](5-equation-of-states.md) para más detalles. |
| Ajuste de picos | Ajuste la posición, la anchura total a media altura (FWHM) y la intensidad de los picos de difracción. Consulte [Ajuste de picos de difracción](6-fitting-diffraction-peaks.md) para más detalles. |
| Refinamiento de parámetros de red | Refine los parámetros de red a partir de las posiciones de los picos por mínimos cuadrados. El **Cell Finder** también puede buscar parámetros de red a partir de las posiciones de los picos. |
| Análisis secuencial | Procese por lotes una serie de archivos con la función **Análisis secuencial**. Consulte [Análisis secuencial](7-sequential-analysis.md) para más detalles. |
| Importación / exportación | Importe estructuras cristalinas desde archivos CIF y AMC, y exporte a los formatos CSV, TSV y GSAS (Rietveld). |
| Carga automática | Supervise el portapapeles o una carpeta para leer automáticamente perfiles/cristales copiados desde otras aplicaciones (p. ej. IPAnalyzer) o archivos recién creados. |

!!! tip "Datos compatibles"
    Se puede manejar una amplia variedad de perfiles, incluidos los procedentes de instrumentos de difracción de polvo de rayos X, rayos X de sincrotrón (óptica de transmisión de Debye-Scherrer) y mediciones de neutrones por tiempo de vuelo (TOF).

## Licencia

Este software se distribuye bajo la **Licencia MIT** ([LICENSE.md](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md)). Cualquier persona puede usar este software libremente y de forma gratuita, siempre que acepte las siguientes condiciones.

- Puede copiar, distribuir, modificar, redistribuir versiones modificadas, usar comercialmente, vender por un precio o utilizar el software de cualquier otra forma libremente.
- Al redistribuirlo, incluya el aviso de derechos de autor de este software y el texto completo de esta licencia en el código fuente, o en un archivo de licencia independiente incluido junto con el código fuente.
- Este software se ofrece sin ninguna garantía. El autor no asume responsabilidad alguna por cualquier problema que surja del uso de este software.

## Comentarios

Envíe sus comentarios y solicitudes a través de [Issues](https://github.com/seto77/PDIndexer/issues) en GitHub. El código fuente está publicado en [github.com/seto77/PDIndexer](https://github.com/seto77/PDIndexer).

## Instalación y requisitos del sistema

PDIndexer requiere un sistema operativo Windows capaz de ejecutar **.NET Desktop Runtime 6.0 o posterior**. Algunas funciones requieren considerables recursos de cómputo; se utilizan el multihilo y la aceleración por GPU para mejorar la velocidad. Para un uso cómodo, se recomienda un Windows 10/11 de 64 bits con 16 GB o más de memoria y una CPU de 8 núcleos o superior.

Para conocer los pasos detallados de instalación y los requisitos del sistema, consulte [Entorno de ejecución e instalación](appendix/runtime-and-installation.md).
