<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Ajuste de picos de difração

A ferramenta `Ajuste de picos de difração (F)` ajusta os picos de um perfil de difração com uma função apropriada, deriva o espaçamento d a partir de cada posição de pico 2θ e refina os parâmetros de rede por mínimos quadrados. Ela é iniciada a partir da barra de ferramentas da janela principal.

![Janela completa do ajuste de picos](../assets/cap-pt-auto/FormFitting.png)

## Fluxo de trabalho básico

1. Selecione o cristal alvo na lista de cristais (no modo multi-perfil, selecione também o perfil no qual deseja trabalhar).
2. Na janela principal, arraste as linhas de difração com o mouse de modo que se sobreponham aos picos medidos o mais próximo possível.
3. Escolha os índices das linhas de difração que deseja ajustar na lista de picos de difração (uma caixa de lista com marcações).
4. Assim que índices independentes suficientes forem escolhidos para que o cálculo por mínimos quadrados seja solúvel, os parâmetros de rede mais prováveis aparecem, com seus erros, no painel `Parâmetros de célula otimizados` no canto inferior direito.
5. Pressione `Aplicar ao cristal` para enviar os parâmetros de rede refinados de volta ao cristal no programa principal.

!!! note "Marcar e selecionar um cristal"
    A lista de cristais espelha a da janela principal. Para que o ajuste tenha efeito, o cristal alvo deve estar tanto marcado quanto selecionado.

## Lista de cristais

![Lista de cristais](../assets/cap-pt-auto/FormFitting.groupBox1.png)

A lista de cristais no canto superior esquerdo contém os mesmos cristais da janela principal. O cristal que você marca e seleciona aqui torna-se o alvo do ajuste. Consulte [Parâmetros do cristal](3-crystal-parameter.md) para mais detalhes.

## Lista de picos de difração

![Lista de picos de difração](../assets/cap-pt-auto/FormFitting.groupBox5.png)

As linhas de difração do cristal selecionado são listadas aqui. Ativar a caixa de marcação de uma linha torna essa linha de difração um alvo de ajuste. A lista contém colunas como as seguintes.

| Coluna | Conteúdo |
| --- | --- |
| `Marcar` | Se a linha deve ser incluída no ajuste |
| `Cor do pico` | Cor de exibição |
| `Cristal` | Nome do cristal |
| `HKL` | Índices de reflexão |
| `X calc.` | Posição calculada da linha de difração |
| `Func.` | Função de pico utilizada |
| `X` | Posição do pico obtida pelo ajuste |
| `Erro X` | Erro da posição do pico |
| `FWHM` | Largura à meia altura |
| `Intensidade` | Intensidade do pico |
| `Peso` | Peso no ajuste por mínimos quadrados |
| `R` | Índice de resíduo do ajuste |

Os botões abaixo da lista exportam os resultados.

- `Copiar para a área de transferência`: Copia a tabela para a área de transferência. Ela pode ser colada diretamente no Excel e aplicativos semelhantes.
- `Salvar como CSV`: Salva a tabela como um arquivo `.csv`. `Casas signif.` define o número de algarismos significativos mostrados na tabela.
- `Limpar picos`: Exclui todos os picos adicionados manualmente ao Flexible Crystal.

## Fitting option (Opções de ajuste)

![Opções de ajuste](../assets/cap-pt-auto/FormFitting.groupBox3.png)

Aqui você faz as configurações detalhadas usadas ao ajustar os perfis de pico.

### Search Range / Initial FWHM

![Search Range e Initial FWHM](../assets/cap-pt-auto/FormFitting.groupBox3.groupBox2.png)

- `Intervalo de pesquisa`: Define o intervalo sobre o qual o ajuste é realizado. Isto é, a região dentro de ±`Intervalo de pesquisa` em torno da posição calculada da linha de difração é tomada como alvo do ajuste para aquele pico.
- `FWHM inicial`: Especifica a largura à meia altura inicial da função de perfil. Ela é usada como valor de partida para a convergência dos mínimos quadrados.

Pressionar `Aplicar a todos` aplica as configurações atuais a todas as linhas de difração de uma só vez.

### Peak function (Função de pico)

Seleciona a função de pico usada para o ajuste.

| Função de pico | Conteúdo |
| --- | --- |
| `Pesquisa simples` | Não realiza ajuste de função; reconhece o ponto mais intenso dentro de ±Search Range em torno da posição calculada da linha de difração como a posição do pico. |
| `Pseudo-Voigt simétrico` | Ajusta com uma função pseudo-Voigt simétrica à esquerda e à direita. |
| `Pearson VII simétrico` | Ajusta com uma função Pearson VII simétrica à esquerda e à direita. |
| `Pseudo-Voigt dividido` | Ajusta com uma função pseudo-Voigt assimétrica (dividida) à esquerda e à direita. |
| `Pearson VII dividido` | Ajusta com uma função Pearson VII assimétrica (dividida) à esquerda e à direita. |

!!! tip "Função recomendada"
    A menos que haja uma razão específica para não fazê-lo, `Pseudo-Voigt simétrico` é recomendado por causa de sua estabilidade superior.

A função pseudo-Voigt é uma combinação linear de uma gaussiana \(G(x)\) e uma lorentziana \(L(x)\) com parâmetro de mistura \(\eta\), dada por:

$$
\mathrm{pV}(x) = \eta\, L(x) + (1-\eta)\, G(x), \qquad 0 \le \eta \le 1
$$

onde \(\eta\) é a fração da componente lorentziana. A forma dividida representa um perfil assimétrico tomando parâmetros como a FWHM independentemente à esquerda e à direita da posição do pico.

### Pattern Decomposition

![Pattern Decomposition](../assets/cap-pt-auto/FormFitting.groupBox3.flowLayoutPanelPatternDecomposition.png)

Quando as regiões de `Intervalo de pesquisa` de duas ou mais linhas de difração selecionadas se sobrepõem, esta opção seleciona se deve ser realizada a decomposição do padrão (ajuste simultâneo dos picos sobrepostos).

- `para cada cristal`: Realiza a decomposição do padrão independentemente para cada cristal.
- `entre cristais`: Realiza a decomposição do padrão através de todos os cristais.

## Optimized cell constants (Parâmetros de célula otimizados)

![Painel de parâmetros de célula otimizados](../assets/cap-pt-auto/FormFitting.groupBox4.png)

Assim que índices independentes suficientes forem escolhidos para que o cálculo por mínimos quadrados se torne solúvel, este painel exibe os parâmetros de rede mais prováveis \(a, b, c, \alpha, \beta, \gamma\) e o volume \(V\), cada um com seu erro (`±`).

!!! note "Sobre a exibição de NA"
    Quando o número de reflexões ajustadas é igual ao número de parâmetros de rede independentes, os resíduos não permitem obter erros-padrão, e por isso `NA` é exibido nos campos de erro. Quando há reflexões independentes de menos para resolver os parâmetros de rede, o programa mantém a forma original da célula e altera apenas sua escala global, e os erros são mostrados como `NA`. Escolher reflexões independentes suficientes permite que os erros sejam calculados.

- `Aplicar ao cristal`: Envia os parâmetros de rede refinados de volta ao cristal selecionado no programa principal.
- `Copiar para a área de transferência`: Copia os parâmetros de rede otimizados para a área de transferência.

## Remove fitted peaks (Remover picos ajustados)

Isto subtrai os picos ajustados do perfil e produz o perfil residual como um novo perfil. Digite o nome de destino em `Nome do novo perfil` e pressione `Remover picos ajustados` para realizar a subtração. É útil para verificar o fundo ou a separação de picos sobrepostos.

## Ferramentas relacionadas (Send d-values)

Pressionar `Enviar valores de d para CellFinder && AtomicPositionFinder` envia os valores de d obtidos do ajuste das reflexões marcadas para o `Cell Finder`. Abra o `Cell Finder` a partir da barra de ferramentas. <!-- 261124Cl changed (author decision): the Atomic Position Finder, not available in the current version, is no longer described -->

### Cell Finder

![Cell Finder](../assets/cap-pt-auto/FormCellFinder.png)

O `Cell Finder` procura candidatos a parâmetros de rede que expliquem um conjunto de posições de pico medidas (uma lista de valores de d). Ele é usado para indexar amostras desconhecidas.

!!! tip "Identificando uma amostra desconhecida"
    Depois de determinar os parâmetros de rede com o `Cell Finder`, registre esse cristal na lista de cristais, e você poderá refinar os parâmetros de rede ainda mais com o ajuste por mínimos quadrados desta ferramenta.
