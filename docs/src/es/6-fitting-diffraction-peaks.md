<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Ajuste de picos de difracción

La herramienta `Ajustar picos de difracción (F)` ajusta los picos de un perfil de difracción con una función adecuada, deduce el espaciado d a partir de la posición 2θ de cada pico y refina los parámetros de red por mínimos cuadrados. Se inicia desde la barra de herramientas de la ventana principal.

![Ventana completa de ajuste de picos](../assets/cap-es-auto/FormFitting.png)

## Flujo de trabajo básico

1. Seleccione el cristal de destino en la lista de cristales (en el modo multiperfil, seleccione también el perfil con el que desea trabajar).
2. En la ventana principal, arrastre las líneas de difracción con el ratón para que se superpongan lo más posible a los picos medidos.
3. Elija los índices de las líneas de difracción que desea ajustar en la lista de líneas de difracción (un cuadro de lista con casillas de verificación).
4. Una vez elegidos suficientes índices independientes para que el cálculo de mínimos cuadrados sea resoluble, los parámetros de red más probables aparecen, con sus errores, en el panel `Parámetros de celda optimizados` en la parte inferior derecha.
5. Pulse `Aplicar al cristal` para enviar los parámetros de red refinados de vuelta al cristal en el programa principal.

!!! note "Marcar y seleccionar un cristal"
    La lista de cristales refleja la de la ventana principal. Para que el ajuste surta efecto, el cristal de destino debe estar marcado y seleccionado al mismo tiempo.

## Lista de cristales

![Lista de cristales](../assets/cap-es-auto/FormFitting.groupBox1.png)

La lista de cristales en la parte superior izquierda contiene los mismos cristales que la ventana principal. El cristal que marque y seleccione aquí se convierte en el destino del ajuste. Consulte [Parámetros del cristal](3-crystal-parameter.md) para más detalles.

## Lista de líneas de difracción

![Lista de líneas de difracción](../assets/cap-es-auto/FormFitting.groupBox5.png)

Aquí se enumeran las líneas de difracción del cristal seleccionado. Al activar la casilla de verificación de una fila, esa línea de difracción se convierte en un destino del ajuste. La lista contiene columnas como las siguientes.

| Columna | Contenido |
| --- | --- |
| `Selección` | Si se incluye la línea en el ajuste |
| `Color de pico` | Color de visualización |
| `Cristal` | Nombre del cristal |
| `HKL` | Índices de reflexión |
| `X calc.` | Posición calculada de la línea de difracción |
| `Func.` | Función de pico utilizada |
| `X` | Posición del pico obtenida por el ajuste |
| `Err. X` | Error de la posición del pico |
| `FWHM` | Anchura total a media altura |
| `Intensidad` | Intensidad del pico |
| `Peso` | Peso en el ajuste por mínimos cuadrados |
| `R` | Índice de residuo del ajuste |

Los botones debajo de la lista exportan los resultados.

- `Copiar al portapapeles`: Copia la tabla al portapapeles. Puede pegarse directamente en Excel y aplicaciones similares.
- `Guardar como CSV`: Guarda la tabla como un archivo `.csv`. `Cifras signif.` establece el número de cifras significativas mostradas en la tabla.
- `Borrar picos`: Elimina todos los picos añadidos manualmente al Flexible Crystal.

## Fitting option (Opciones de ajuste)

![Opciones de ajuste](../assets/cap-es-auto/FormFitting.groupBox3.png)

Aquí se realizan los ajustes detallados utilizados al ajustar los perfiles de los picos.

### Search Range / Initial FWHM

![Search Range e Initial FWHM](../assets/cap-es-auto/FormFitting.groupBox3.groupBox2.png)

- `Rango de búsqueda`: Establece el rango sobre el cual se realiza el ajuste. Es decir, la región dentro de ±`Rango de búsqueda` de la posición calculada de la línea de difracción se toma como destino del ajuste para ese pico.
- `FWHM inicial`: Especifica la anchura total a media altura inicial de la función de perfil. Se utiliza como valor de partida para la convergencia por mínimos cuadrados.

Al pulsar `Aplicar a todos` se aplican los ajustes actuales a todas las líneas de difracción a la vez.

### Peak function (Función de pico)

Selecciona la función de pico utilizada para el ajuste.

| Función de pico | Contenido |
| --- | --- |
| `Búsqueda simple` | No realiza ningún ajuste de función; reconoce el punto de mayor intensidad dentro de ±`Rango de búsqueda` de la posición calculada de la línea de difracción como posición del pico. |
| `Pseudo-Voigt simétrico` | Ajusta con una función pseudo-Voigt simétrica a izquierda y derecha. |
| `Pearson VII simétrico` | Ajusta con una función Pearson VII simétrica a izquierda y derecha. |
| `Pseudo-Voigt dividido` | Ajusta con una función pseudo-Voigt asimétrica (dividida) a izquierda y derecha. |
| `Pearson VII dividido` | Ajusta con una función Pearson VII asimétrica (dividida) a izquierda y derecha. |

!!! tip "Función recomendada"
    A menos que haya una razón particular para no hacerlo, se recomienda `Pseudo-Voigt simétrico` por su estabilidad superior.

La función pseudo-Voigt es una combinación lineal de una gaussiana \(G(x)\) y una lorentziana \(L(x)\) con parámetro de mezcla \(\eta\), dada por:

$$
\mathrm{pV}(x) = \eta\, L(x) + (1-\eta)\, G(x), \qquad 0 \le \eta \le 1
$$

donde \(\eta\) es la fracción de la componente lorentziana. La forma dividida representa un perfil asimétrico tomando parámetros como la FWHM de forma independiente a la izquierda y a la derecha de la posición del pico.

### Pattern Decomposition (Descomposición de patrón)

![Descomposición de patrón](../assets/cap-es-auto/FormFitting.groupBox3.flowLayoutPanelPatternDecomposition.png)

Cuando los `Rango de búsqueda` de dos o más líneas de difracción seleccionadas se solapan, esta opción selecciona si se realiza la descomposición de patrón (ajuste simultáneo de los picos solapados).

- `para cada cristal`: Realiza la descomposición de patrón de forma independiente para cada cristal.
- `entre cristales`: Realiza la descomposición de patrón a través de todos los cristales.

## Optimized cell constants (Parámetros de celda optimizados)

![Panel de parámetros de celda optimizados](../assets/cap-es-auto/FormFitting.groupBox4.png)

Una vez elegidos suficientes índices independientes para que el cálculo de mínimos cuadrados sea resoluble, este panel muestra los parámetros de red más probables \(a, b, c, \alpha, \beta, \gamma\) y el volumen \(V\), cada uno con su error (`±`).

!!! note "Acerca de la indicación NA"
    Cuando el número de reflexiones ajustadas es igual al número de parámetros de red independientes, los residuos no permiten obtener errores estándar, por lo que se muestra `NA` en los campos de error. Cuando hay demasiado pocas reflexiones independientes para resolver los parámetros de red, el programa conserva la forma original de la celda y solo cambia su escala global, y los errores se muestran como `NA`. Elegir suficientes reflexiones independientes permite calcular los errores.

- `Aplicar al cristal`: Envía los parámetros de red refinados de vuelta al cristal seleccionado en el programa principal.
- `Copiar al portapapeles`: Copia los parámetros de red optimizados al portapapeles.

## Remove fitted peaks (Eliminar picos ajustados)

Esto resta los picos ajustados del perfil y genera el perfil residual como un nuevo perfil. Introduzca el nombre de destino en `Nombre del nuevo perfil` y pulse `Eliminar picos ajustados` para realizar la resta. Es útil para comprobar el fondo o la separación de picos solapados.

## Herramientas relacionadas (Send d-values)

Al pulsar `Enviar distancias d a CellFinder && AtomicPositionFinder` se envían a `Cell Finder` los valores d obtenidos del ajuste de las reflexiones marcadas. Abra `Cell Finder` desde la barra de herramientas. <!-- 261124Cl changed (author decision): the Atomic Position Finder, not available in the current version, is no longer described -->

### Cell Finder

![Cell Finder](../assets/cap-es-auto/FormCellFinder.png)

`Cell Finder` busca candidatos de parámetros de red que expliquen un conjunto de posiciones de picos medidas (una lista de valores d). Se utiliza para indexar muestras desconocidas.

!!! tip "Identificar una muestra desconocida"
    Tras determinar los parámetros de red con `Cell Finder`, registre ese cristal en la lista de cristales, y podrá refinar los parámetros de red aún más con el ajuste por mínimos cuadrados de esta herramienta.
