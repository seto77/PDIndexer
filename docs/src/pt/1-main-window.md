<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Janela principal

Ao iniciar o software, aparece a tela mostrada abaixo. A janela principal é composta pela **área de desenho do perfil** central, pela **barra de menus** e pela **barra de ferramentas (lista de funções)** na parte superior, pelo menu de abas próximo ao topo (`Eixo horizontal` / `Aparência & Perfil único/múltiplo`), pela **lista de perfis** no canto superior direito e pela **lista de cristais** no canto inferior direito.

![A janela principal completa do PDIndexer](../assets/cap-pt-auto/FormMain.png)

## Área de desenho do perfil

Esta área ocupa a maior parte da janela e exibe os perfis marcados na lista de perfis. Quando um cristal está selecionado na lista de cristais, também são desenhadas linhas de difração nas posições dos picos de difração.

### Operações do mouse

| Operação | Ação |
| --- | --- |
| Arrastar com o botão esquerdo | Mover as linhas de difração (alterar os parâmetros de rede do cristal) |
| Arrastar com o botão direito | Ampliar |
| Clicar com o botão direito | Reduzir |
| Arrastar com o botão do meio | Deslocar a visualização (pan) |

Os intervalos de desenho dos eixos horizontal e vertical podem ser alterados digitando valores diretamente nas caixas numéricas acima da área de desenho (`2θ:`, `d:`, `Int.:`, `q:` etc., cujos rótulos dependem do modo de eixo horizontal selecionado).

!!! tip
    O modo de exibição do eixo horizontal (ângulo, energia, espaçamento d etc.) é alternado na [aba `Eixo horizontal`](#horizontal-axis-tab). Esta é uma configuração apenas de exibição e não modifica os próprios dados do eixo horizontal do perfil.

## Barra de ferramentas (lista de funções)

Cada botão da barra de ferramentas alterna uma janela de análise dedicada.

| Botão | Função | Ver |
| --- | --- | --- |
| `Parâmetro de cristal (C)` | Alterna a janela Parâmetro de cristal. | [Parâmetros do cristal](3-crystal-parameter.md) |
| `Parâmetro de perfil (P)` | Alterna a janela Parâmetro de perfil. | [Parâmetros do perfil](4-profile-parameter.md) |
| `Equação de estado (E)` | Alterna a janela Equação de estado para estimar a pressão a partir do volume da célula de um material padrão. | [Equações de estado](5-equation-of-states.md) |
| `Ajuste de picos de difração (F)` | Alterna a janela Ajuste de picos para ajustar picos de difração (posição, FWHM, intensidade). | [Ajuste de picos de difração](6-fitting-diffraction-peaks.md) |
| `Cell Finder` | Alterna a janela Cell Finder para pesquisar parâmetros de rede a partir das posições dos picos. | — |
| `Análise sequencial` | Alterna a janela Análise sequencial para o processamento em lote de uma série de arquivos. | [Análise sequencial](7-sequential-analysis.md) |
| `Atomic Position Finder` | Alterna a janela Atomic Position Finder para pesquisar posições atômicas a partir das intensidades de difração. | — |
| `LPO Analysis` | Alterna a janela de análise LPO (orientação preferencial de rede). | — |

!!! note
    As janelas principais também podem ser alternadas com atalhos de teclado: `Ctrl+Shift+C` (Parâmetro de cristal), `Ctrl+Shift+E` (Equação de estado), `Ctrl+Shift+F` (Parâmetro de ajuste) e `Ctrl+Shift+D` (alterar o modo de pico).

## Barra de menus

### Arquivo

| Item | Descrição |
| --- | --- |
| `Ler perfil(is)` | Lê dados de perfil. Além do formato próprio deste software, `pdi` / `pdi2`, é possível ler o `csv` de saída do WinPIP, o `chi` de saída do Fit2D e assim por diante. A maioria dos arquivos armazenados como texto de ângulo-intensidade também pode ser lida. |
| `Salvar perfil(is)` | Salva todos os perfis carregados no formato `pdi2` deste software. |
| `Exportar o(s) perfil(is) selecionado(s)` | Exporta o(s) perfil(is) selecionado(s) como arquivo de dados separado por vírgula (CSV), separado por tabulação (TSV) ou GSAS (Rietveld). |
| `Carregar cristais (como nova lista)` | Carrega um arquivo de lista de cristais (extensão `xml`). A lista de cristais atual é descartada. |
| `Carregar cristais (e adicionar à lista atual)` | Carrega um arquivo de lista de cristais (extensão `xml`) e o acrescenta ao final da lista de cristais atual. |
| `Salvar cristais` | Salva a lista de cristais atual em um arquivo (extensão `xml`). |
| `Importar CIF, AMC...` | Importa um arquivo de dados de estrutura no formato `cif` ou `amc` e o adiciona à lista de cristais atual. |
| `Exportar o cristal selecionado para CIF` | Salva o cristal selecionado como arquivo de dados de estrutura no formato `cif`. |
| `Reverter cristais ao estado inicial` | Reverte a lista de cristais ao estado inicial (padrão). |
| `Configurar página` | Abre a caixa de diálogo de configuração de página para impressão. |
| `Visualizar impressão` | Mostra uma visualização de impressão do visualizador de perfis. |
| `Imprimir` | Imprime. O intervalo de impressão é o intervalo de ângulo e intensidade atual. |
| `Copiar para a área de transferência` | Copia o perfil atualmente desenhado para a área de transferência como dados de bitmap ou de metafile (vetorial). |
| `Salvar como Metafile` | Salva o perfil atualmente desenhado no formato metafile. O formato EMF (Enhanced Meta File) é suportado, e os arquivos `*.emf` salvos podem ser abertos no PowerPoint e no Word. |
| `Fechar` | Fecha o PDIndexer. |

### Opções

| Item | Descrição |
| --- | --- |
| `Dica de ferramenta` | Quando marcado, exibe as dicas de ferramenta na janela principal. |
| `Monitorar área de transferência` | Monitora a área de transferência e importa automaticamente dados de perfil/cristal copiados de outros aplicativos (por exemplo, o IPAnalyzer). |
| `Monitorar arquivo` | Monitora uma pasta especificada e lê automaticamente arquivos de perfil `.pdi` recém-criados. Escolha a pasta a monitorar na caixa de diálogo de seleção ou digitando o caminho diretamente. |
| `Limpar Registro (marcar e reiniciar)` | Quando marcado, limpa todas as configurações salvas no registro ao sair (reinicie para redefinir). |
| `Salvar a lista de cristais ao fechar` | Quando marcado, salva automaticamente a lista de cristais ao sair e a recarrega ao iniciar. |

### Macro

`Editor` abre a janela do editor de macros. Para detalhes sobre o recurso de macro do PDIndexer, consulte [Macro](8-macro.md).

### Ajuda

| Item | Descrição |
| --- | --- |
| `Sobre` | Exibe informações de copyright, versão e autor, além do histórico de versões. |
| `Atualizações do Programa` | Verifica online se há uma versão mais recente e, se houver, a baixa/instala. |
| `Dica` | Exibe dicas de uso (obsoleto). |
| `Ajuda (web)` | Exibe este manual. |

### Language

Alterna o idioma da interface. Atualmente há suporte para inglês (`English (need restart)`) e japonês (`Japanese (need restart)`). É necessário reiniciar após a troca.

## Aba Eixo horizontal {#horizontal-axis-tab}

A aba `Eixo horizontal` define o modo de exibição do eixo. As configurações aqui são apenas de exibição e não têm relação com os dados reais do eixo horizontal (as informações reais do eixo horizontal podem ser alteradas em [Parâmetros do perfil](4-profile-parameter.md)). Por isso, é possível alinhar o eixo horizontal para comparação mesmo quando fontes de raios X diferentes foram usadas. Por exemplo, mesmo que o perfil carregado tenha sido adquirido com a linha Cu Kα, ele pode ser exibido como se tivesse sido adquirido no comprimento de onda da linha Mo Kα.

| Item | Descrição |
| --- | --- |
| `Após ler o perfil, alterar o eixo horizontal` | Quando marcado, alinha automaticamente as configurações do eixo horizontal às do perfil recém-carregado. |
| 2θ (degree) | Define o eixo horizontal como ângulo. Escolher o botão de opção `X-ray` fornece o ângulo de espalhamento para raios X; selecione uma fonte de raios X característica ou `Custom` na lista suspensa e especifique o comprimento de onda. Escolher o botão de opção `Electron` fornece o ângulo de espalhamento para elétrons; especificar a tensão de aceleração calcula o comprimento de onda corrigido relativisticamente. |
| Energy (eV) | Define o eixo horizontal como energia (unidade eV). Isso corresponde a um experimento de difração de raios X usando um detector EDX. Defina o ângulo de saída (take-off) do EDX adequadamente. |
| d-spacing (Å) | Define o eixo horizontal como espaçamento d (espaçamento dos planos de rede). |
| q | Define o eixo horizontal como a magnitude do vetor de espalhamento \( q \). |

A relação entre o ângulo de espalhamento e o espaçamento d é dada pela lei de Bragg, sendo \( \lambda \) o comprimento de onda:

$$ 2 d \sin\theta = n \lambda $$

## Aba Aparência & Perfil único/múltiplo

A aba `Aparência & Perfil único/múltiplo` configura a aparência do desenho e a exibição de perfil único/múltiplo.

### Configurações de escala e cor

| Item | Descrição |
| --- | --- |
| `Linha de escala` | Seleciona se as linhas de escala (grade) devem ser exibidas. |
| `Barra de erro` | Exibe barras de erro quando os dados contêm informações de erro. |
| `Cor` | Define as cores de exibição, como `Cor de fundo`, `Linha de escala` e `Texto da escala`. |

### Perfil único/múltiplo

O modo que está marcado é o modo atual.

| Item | Descrição |
| --- | --- |
| `Perfil único` | Modo de perfil único. Quando um perfil é carregado, ou enviado do IPAnalyzer pela área de transferência, o perfil antigo é excluído e o novo perfil é desenhado. |
| `Múltiplos perfis` | Modo de múltiplos perfis. Os novos perfis são carregados e sobrepostos aos existentes. |
| `Incremento de intensidade por perfil` | Define o deslocamento de intensidade entre os dados ao sobrepor vários conjuntos de dados. Isso serve apenas para manter a exibição legível; os dados reais não são modificados. |
| `Alterar cor automaticamente` | Quando marcado, altera automaticamente a cor de desenho dos perfis. |

### Eixo vertical

Especifica se o eixo vertical (intensidade) deve ser exibido como contagens brutas (`Contagens brutas`) ou como contagens por passo (`Contagens por passo (CPS)`). Também é possível especificar se o eixo vertical deve ser exibido em escala linear (`Linear`) ou logarítmica (`Logarítmico`).

## Lista de perfis

Exibe e seleciona os perfis carregados. Fica desabilitada no modo `Perfil único`.

No modo de múltiplos perfis, os perfis carregados são mostrados como uma lista, e apenas os marcados são desenhados na área de desenho central. Configurações mais detalhadas do perfil são feitas marcando a caixa de seleção `Parâmetro de perfil` na parte inferior da caixa (consulte [Parâmetros do perfil](4-profile-parameter.md)).

## Lista de cristais

Exibe e configura a lista de cristais. Marcar uma entrada desenha linhas de difração nas posições dos picos de difração. Por padrão, cerca de 80 cristais vêm pré-registrados.

!!! note "Linhas especiais"
    - A primeira linha (linha 0) é o **Flexible Crystal** (fundo ciano), usado para desenhar linhas de difração arbitrárias.
    - As linhas superiores (fundo rosa, por exemplo `NaCl EOS` e `Pt EOS`) são reservadas como materiais padrão para cálculos de equação de estado (EOS).

Configurações mais detalhadas do cristal são feitas marcando a caixa de seleção `Parâmetro de cristal (C)` na parte inferior da caixa (consulte [Parâmetros do cristal](3-crystal-parameter.md)). `Marcar/Desmarcar todos` marca ou desmarca a lista de cristais inteira de uma só vez.
