<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Perfis de difração

Esta página descreve os próprios "dados de perfil" (o conjunto de dados medido) que o PDIndexer manipula, e como carregá-los, exibi-los e exportá-los. O processamento aplicado após o carregamento — suavização, subtração de fundo e assim por diante — é feito na janela [Parâmetros do perfil](4-profile-parameter.md). Para a lista completa de extensões de arquivo suportadas, consulte [Formatos de arquivo](appendix/file-formats.md).

![Janela principal do PDIndexer com um perfil no centro e as listas de perfis e de cristais à esquerda.](../assets/cap-pt-auto/FormMain.png)

## O que é um perfil

Um perfil é um conjunto de dados unidimensional de "eixo horizontal vs. intensidade" obtido de uma medição de difração de pó. O eixo horizontal é expresso de uma das seguintes formas, dependendo da geometria de medição:

- \( 2\theta \) (ângulo de difração) para difração de dispersão angular (difração de raios X comum)
- Energia para medições de dispersão de energia (raios X brancos, detecção por SSD)
- Tempo de voo para o método de tempo de voo de nêutrons (TOF)
- Em todos os casos, os dados também podem ser tratados internamente após a conversão para o espaçamento de rede \( d \) ou o vetor de espalhamento \( q \)

O eixo vertical é a intensidade de difração, que pode ser mostrada como `Raw Counts` ou `Count per Step (CPS)`, em escala linear ou logarítmica (consulte `Vertical Axis` na página [Janela principal](1-main-window.md)).

## Formatos de entrada suportados

`File ▸ Read profile(s)` carrega o formato nativo do PDIndexer, bem como a saída de outros programas e formatos de texto genéricos.

| Extensão | Conteúdo |
| --- | --- |
| `pdi` / `pdi2` | Formato de perfil nativo do PDIndexer (inclui configurações de eixo e informações de processamento) |
| `csv` | Saída do WinPIP (separado por vírgula) |
| `chi` | Saída do Fit2D |
| `tsv` | Texto separado por tabulação |
| `ras` | Formato Rigaku (RAS) |
| `nxs` | Formato NeXus |
| `npd` / `xbm` / `rpt` (`rpf`) | Dados brutos de SSD (detector de estado sólido) |
| Outro texto | Qualquer texto de duas colunas de ângulo (ou valor d)–intensidade é geralmente legível |

!!! note "Leitura de texto genérico"
    Arquivos armazenados como texto de ângulo–intensidade geralmente podem ser lidos mesmo que não sejam um dos formatos padrão acima. Se o tipo de eixo horizontal ou o comprimento de onda/energia não puder ser determinado, especifique-os na caixa de diálogo `Data Converter` descrita abaixo.

A especificação detalhada de cada formato está reunida em [Formatos de arquivo](appendix/file-formats.md).

## Como carregar

Os perfis podem ser carregados de várias maneiras.

- **Menu** — `File ▸ Read profile(s)`. Vários arquivos podem ser selecionados de uma só vez.
- **Arrastar e soltar** — Solte arquivos do Explorer na janela principal.
- **Watch Clipboard** — Quando `Option ▸ Watch Clipboard` está ativado, perfis/cristais copiados de outros aplicativos (por exemplo, IPAnalyzer ou CSManager) são importados automaticamente.
- **Watch File** — Quando `Option ▸ Watch File` está ativado e uma pasta é escolhida com `Set Directory to the watch`, os arquivos de perfil `pdi` recém-criados nessa pasta são lidos automaticamente. Isso é conveniente para a exibição em tempo real durante uma medição contínua.

!!! tip "Alinhar o eixo horizontal automaticamente"
    Marcar `After reading profile, change horizontal axis` faz com que a exibição do eixo horizontal mude para corresponder ao perfil recém-carregado imediatamente após sua leitura.

## Modo Single Profile vs. Multi Profiles

Alterne o modo de exibição com `Single/Multi Profile` no lado direito da janela principal.

- **`Single Profile`** — Carregar um novo perfil substitui os dados anteriores; apenas um perfil é mostrado de cada vez.
- **`Multi Profiles`** — Os perfis carregados são sobrepostos. Use `Increasing intensity by a profile` para deslocar levemente a intensidade de cada perfil, de modo que várias curvas fiquem mais fáceis de distinguir. Ativar `Change automatically color` atribui automaticamente uma cor de desenho a cada perfil.

## Lista de verificação de perfis

A lista `Profile` no lado esquerdo da janela principal mostra todos os perfis carregados.

- Apenas os perfis marcados são desenhados no visualizador central. Use `Check/Uncheck all` para alterná-los todos de uma vez.
- Clique na coluna `Color` para alterar a cor de desenho de cada perfil.
- Reordene as entradas na lista para ajustar a ordem de desenho da sobreposição.
- A lista fica desativada no modo Single Profile e mostra vários perfis no modo Multi Profiles.

Configurações de perfil mais detalhadas (nome, estilo de linha, suavização, subtração de fundo, correção de eixo, operações de perfil e assim por diante) são feitas na janela [Parâmetros do perfil](4-profile-parameter.md), aberta ao marcar a caixa de seleção `Profile Parameter` abaixo da lista.

## Caixa de diálogo Data Converter

Quando você carrega um arquivo de texto genérico cujo tipo de eixo horizontal não pode ser determinado, ou dados brutos de SSD (dispersão de energia), a caixa de diálogo `Data Converter` abre para que você possa especificar o eixo horizontal dos dados que estão sendo lidos e seus parâmetros associados.

![Caixa de diálogo Data Converter com configurações de eixo horizontal, tempo de exposição e opções de EDX.](../assets/cap-pt-auto/FormDataConverter.png)

A caixa de diálogo define os seguintes itens.

| Item | Conteúdo |
| --- | --- |
| Configuração do eixo horizontal | Especifique o tipo de eixo horizontal dos dados (comprimento de onda/energia de raios X, 2θ, comprimento/ângulo de TOF de nêutrons, etc.) e os parâmetros de fonte correspondentes. |
| `Exposure time (per step)` | Tempo de exposição (medição) por passo de dados, em segundos. É usado para a conversão de CPS; valores ≤ 0 são tratados como 1. |
| `Deconvolution` | A remoção de Kα2 foi movida para o formulário [Parâmetros do perfil](4-profile-parameter.md). Para removê-la, selecione Kα1 como a fonte de raios X. |
| `Low energy cutoff` em `For SSD data` | Descarta o lado de baixa energia do espectro de EDX abaixo do limiar (eV) à direita. |

Quando o tipo de eixo horizontal é de dispersão de energia (raios X brancos, EDX), insira os coeficientes de calibração de energia de `E = a₀ + a₁ n + a₂ n²` (E: energia em eV, n: número do canal) para converter os números de canal em energia. Clique em `OK` para aplicar as configurações e converter os dados, ou em `Cancel` para abortar a importação.

## Exportação de perfis

- **`File ▸ Save profile(s)`** — Salva todos os perfis carregados no formato nativo `pdi2` do PDIndexer. As configurações de eixo e as informações de processamento são preservadas.
- **`File ▸ Export the selected profile(s)`** — Exporta o(s) perfil(is) selecionado(s) em um dos seguintes formatos:
  - `as CSV (comma separated values) file` — separado por vírgula (ângulo, intensidade)
  - `as TSV (tab separated values) file` — separado por tabulação
  - `as GSAS file` — formato de dados GSAS (Rietveld)

!!! note "Salvar a figura"
    Para salvar a figura renderizada em vez dos dados de perfil, use `File ▸ Copy to Clipboard` ou `File ▸ Save as Metafile` (EMF). EMF é um formato vetorial que pode ser importado no PowerPoint e no Word.
