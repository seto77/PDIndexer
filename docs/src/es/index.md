<!-- 260601Cl: English landing page for the PDIndexer Pages manual (content migrated from the legacy docx + yseto.net web manual). -->
<!-- 260625Cl: static-i18n folder mode へ移設 (docs/src/index.md → docs/src/en/index.md)。画像は ../assets、内部リンクは en/ 接頭辞を剥がす。 -->
# Manual de PDIndexer

**PDIndexer** es una aplicación de Windows gratuita y con licencia MIT para analizar patrones de difracción de polvo unidimensionales (rayos X de laboratorio / sincrotrón, TOF de neutrones). Muestra los perfiles medidos, superpone las líneas de difracción calculadas a partir de estructuras cristalinas, procesa y calibra perfiles, ajusta picos para refinar los parámetros de red por mínimos cuadrados y estima la presión a partir de las ecuaciones de estado de materiales estándar.

![Ventana principal de PDIndexer](../assets/cap-es-auto/FormMain.png)

## Buscar por objetivo

| Objetivo | Empezar aquí | Siguientes pasos principales |
|------|------------|-----------------|
| Cargar y mostrar un perfil medido | [2. Perfiles de difracción](2-pattern-profiles.md) | [1. Ventana principal](1-main-window.md), [Formatos de archivo](appendix/file-formats.md) |
| Identificar fases superponiendo cristales conocidos | [3. Parámetros del cristal](3-crystal-parameter.md) | [2. Perfiles de difracción](2-pattern-profiles.md) |
| Procesar / calibrar un perfil | [4. Parámetros del perfil](4-profile-parameter.md) | [3. Parámetros del cristal](3-crystal-parameter.md) |
| Ajustar picos y refinar los parámetros de red | [6. Ajuste de picos de difracción](6-fitting-diffraction-peaks.md) | [3. Parámetros del cristal](3-crystal-parameter.md) |
| Estimar la presión a partir de un material estándar | [5. Ecuaciones de estado](5-equation-of-states.md) | [6. Ajuste de picos de difracción](6-fitting-diffraction-peaks.md) |
| Procesar por lotes una serie de perfiles | [7. Análisis secuencial](7-sequential-analysis.md) | [8. Macro](8-macro.md) |
| Automatizar tareas con scripts | [8. Macro](8-macro.md) | [7. Análisis secuencial](7-sequential-analysis.md) |

## Contenido

- [0. Visión general](0-overview.md) — qué hace PDIndexer y sus funciones principales
- [1. Ventana principal](1-main-window.md) — disposición, menús, barra de herramientas, listas de perfiles/cristales
- [2. Perfiles de difracción](2-pattern-profiles.md) — datos de perfil, formatos admitidos, carga
- [3. Parámetros del cristal](3-crystal-parameter.md) — visualización de líneas de difracción, información del cristal, base de datos
- [4. Parámetros del perfil](4-profile-parameter.md) — procesamiento de perfiles, ajustes de ejes, operadores
- [5. Ecuaciones de estado](5-equation-of-states.md) — presión a partir de la EOS de materiales estándar
- [6. Ajuste de picos de difracción](6-fitting-diffraction-peaks.md) — ajuste de picos y refinamiento de la red
- [7. Análisis secuencial](7-sequential-analysis.md) — análisis por lotes sobre una serie de perfiles
- [8. Macro](8-macro.md) — scripting con IronPython y referencia de funciones

### Apéndice

- [Entorno de ejecución e instalación](appendix/runtime-and-installation.md)
- [Formatos de archivo](appendix/file-formats.md)
- [Resolución de problemas](appendix/troubleshooting.md)

## Inicio rápido

1. Descargue e instale desde [Releases](https://github.com/seto77/PDIndexer/releases/latest), luego inicie *PDIndexer*.
2. Abra un perfil medido (arrastre y suelte un archivo, o pegue un perfil copiado desde [IPAnalyzer](https://github.com/seto77/IPAnalyzer)).
3. Añada cristales conocidos desde la base de datos integrada (o importe un archivo CIF/AMC) para superponer sus líneas de difracción.
4. Ajuste los picos para refinar los parámetros de red, o estime la presión a partir de la ecuación de estado de un material estándar.

## Requisitos del sistema

| Elemento | Requisito |
|------|-------------|
| SO | Windows con [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) (**no** el .NET Runtime) |
| Recomendado | Windows 10/11 de 64 bits, 16 GB o más de memoria, CPU de 8 núcleos o superior |

Consulte [Entorno de ejecución e instalación](appendix/runtime-and-installation.md) para más detalles.

!!! note
    El código fuente, las versiones y el seguimiento de incidencias están en [GitHub](https://github.com/seto77/PDIndexer). PDIndexer se distribuye bajo la [licencia MIT](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md).
