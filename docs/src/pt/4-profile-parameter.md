<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Parâmetros do perfil

Ao clicar no ícone `Parâmetro de perfil (P)` na janela principal, esta subjanela é aberta. Aqui você faz ajustes detalhados nos perfis carregados e aplica diversos processamentos numéricos.

![Janela inteira de Parâmetros do perfil](../assets/cap-pt-auto/FormProfileSetting.png)

O lado esquerdo da janela contém a [Lista de verificação de perfis](#profile), e o lado direito é dividido em três páginas em abas — [Processamento de perfil](#profile-processing), [Configuração de eixo](#axis-setting) e [Operador de perfil](#profile-operator). Cada etapa de processamento pode ser ativada/desativada com uma caixa de seleção e é aplicada em ordem, de cima para baixo.

!!! note
    As configurações feitas nesta janela são refletidas nos perfis da [janela principal](1-main-window.md) em tempo real. Escolha a unidade de exibição do eixo horizontal na aba `Eixo horizontal` da janela principal. Para configurações do lado do cristal, como os rótulos de índice das linhas de difração, consulte [Crystal Parameter](3-crystal-parameter.md).

---

## Lista de verificação de perfis {#profile}

A lista no lado esquerdo da janela mostra as mesmas informações que a Lista de verificação de perfis na janela principal. Selecionar um perfil na lista o torna o alvo do processamento e das configurações no lado direito da janela.

| Item | Descrição |
| --- | --- |
| `↑` `↓` (botões de seta para cima/baixo) | Alteram a ordem dos perfis na lista. |
| `Excluir` | Exclui o perfil selecionado. |
| `Excluir tudo` | Exclui todos os perfis. |

Na área `Propriedades básicas` abaixo da lista, você edita os atributos básicos do perfil selecionado.

| Item | Descrição |
| --- | --- |
| `Line color` | Clique para alterar a cor de desenho do perfil selecionado. |
| `Line width` | Define a espessura da linha do perfil (`pt`). |
| `Nome do perfil` | Define o nome do perfil. |
| `Comentário` | Um campo de comentário de formato livre. |

---

## Processamento de perfil {#profile-processing}

Na aba `Processamento de perfil` você aplica diversos processamentos numéricos ao perfil selecionado. As etapas 1–7 podem ser habilitadas de forma independente com uma caixa de seleção, e as habilitadas são aplicadas em ordem numérica.

### 1. Deslocamento de 2θ {#two-theta-offset}

![Painel de deslocamento de 2θ](../assets/cap-pt-auto/FormProfileSetting.tabControl1.tabPage2.flowLayoutPanel1.flowLayoutPanelTwoThetaOffset.png)

`1. Offset de 2θ (para difratometria dispersiva em ângulo)` corrige o ângulo de dados dispersivos em ângulo. A expressão de correção é uma função quadrática de \( \tan\theta \).

$$ \Delta(2\theta) = a_0 + a_1 \tan\theta + a_2 \tan^2\theta $$

Se o perfil contiver um padrão interno (uma amostra com parâmetros de rede conhecidos), pressione o botão `Calibração usando um padrão interno` e siga as mensagens; os coeficientes da função quadrática são então determinados automaticamente. Na caixa de diálogo de calibração, as posições de pico observadas são correspondidas às posições de pico teóricas do padrão, e os coeficientes são ajustados.

![Caixa de diálogo de calibração de 2θ](../assets/cap-pt-auto/FormTwoThetaCalibration.png)

O botão `Redefinir` reinicia os coeficientes de deslocamento que você definiu.

!!! tip
    Padrões internos são comumente materiais com parâmetros de rede determinados com precisão, como Si ou LaB₆. Após a calibração, os valores de 2θ corrigidos são usados diretamente em toda a análise subsequente.

### 2. Máscara e interpolação {#mask}

![Painel de máscara e interpolação](../assets/cap-pt-auto/FormProfileSetting.tabControl1.tabPage2.flowLayoutPanel1.flowLayoutPanelMaskingMode.png)

`2. Máscara e interpolação` mascara um intervalo angular especificado (ou intervalo de energia) e interpola o perfil usando as intensidades fora do intervalo mascarado.

| Item | Descrição |
| --- | --- |
| `Definir intervalo de mascaramento` | Especifica o intervalo do eixo horizontal a mascarar. |
| `Point No.` | Especifica o número de pontos de extremidade (de cada lado) usados para interpolação. |
| `Polynomial order` | Especifica a ordem do polinômio usado para interpolação. |
| `Salvar intervalos de mascaramento` / `Ler intervalos de máscara` | Salva os intervalos de mascaramento configurados em um arquivo, ou os lê de volta. |
| `Excluir` / `Excluir tudo` | Exclui um intervalo de mascaramento individual, ou todos eles. |

### 3. Suavização {#smoothing}

![Painel de suavização](../assets/cap-pt-auto/FormProfileSetting.tabControl1.tabPage2.flowLayoutPanel1.flowLayoutPanelSmoothing.png)

`3. Suavização` aplica suavização ao perfil selecionado. O algoritmo de suavização é o método `Savitzky-Golay`.

Neste método, para cada posição \(x\) de interesse, um ajuste por mínimos quadrados com um polinômio de grau `Order` é realizado sobre os dados dentro de \(\pm\) `Point No.` desse ponto, e o valor da função resultante \(F(x)\) é adotado como a nova intensidade nessa posição \(x\).

!!! note
    Quando `Order` \(= 1\), a suavização de Savitzky–Golay é equivalente a uma simples média móvel. Aumentar `Order` preserva melhor as formas dos picos, enquanto aumentar `Point No.` intensifica a suavização.

### 4. Filtro passa-banda {#bandpass}

![Painel de filtro passa-banda](../assets/cap-pt-auto/FormProfileSetting.tabControl1.tabPage2.flowLayoutPanel1.flowLayoutPanelBandPassFilter.png)

`4. Filtro passa-banda` usa uma transformada de Fourier (FFT) para cortar componentes acima ou abaixo de frequências especificadas.

| Item | Descrição |
| --- | --- |
| `Cortar alta freq. acima de` | Remove componentes com frequência mais alta que o valor especificado (reduz o ruído de alta frequência). |
| `Cortar baixa freq. abaixo de` | Remove componentes com frequência mais baixa que o valor especificado (remove um fundo que varia lentamente). |

### 5. Remover Kα2 {#remove-ka2}

`5. Remover Kα2 (se Kα1 for usado como fonte de raios X)`: se o perfil selecionado foi medido com raios X nos quais Kα1 e Kα2 não estão separados, e foi carregado especificando Kα1, marcar esta opção remove a intensidade de difração originada por Kα2.

!!! warning
    Este processamento só é eficaz quando Kα1 é selecionado como fonte de raios X. Verifique e configure a unidade do eixo horizontal e o tipo de radiação na aba [Configuração de eixo](#axis-setting).

### 6. Fundo {#background}

![Painel de subtração de fundo](../assets/cap-pt-auto/FormProfileSetting.tabControl1.tabPage2.flowLayoutPanel1.flowLayoutPanelBackgroundSubtraction.png)

`6. Fundo` subtrai o fundo do perfil. Há dois métodos.

#### B-Spline curve

Pressionar `Detecção automática` calcula e subtrai o fundo automaticamente. Com `Point No.` você define o número máximo de pontos de controle de fundo a procurar automaticamente.

Você também pode alterar os pontos de controle manualmente. Arraste com o mouse os pontos de controle redondos desenhados na janela principal para criar uma curva apropriada.

#### Reference

Você pode especificar outro perfil como o fundo do perfil selecionado. Marcar `Mostrar perfil de fundo` exibe o perfil que está sendo usado como fundo.

!!! note
    A subtração de fundo (etapa 6) é excluída da aplicação em massa realizada pelo botão `Aplicar a todos os perfis (sem ajuste de fundo)` descrito abaixo.

### 7. Normalizar intensidade {#normalize}

![Painel de normalização de intensidade](../assets/cap-pt-auto/FormProfileSetting.tabControl1.tabPage2.flowLayoutPanel1.flowLayoutPanelNormarizeIntensity.png)

`7. Normalizar intensidade` normaliza o perfil de modo que a `Média` ou o `Máximo` sobre um intervalo especificado do eixo horizontal se torne uma intensidade especificada.

| Item | Descrição |
| --- | --- |
| `Média` / `Máximo` | Escolha se a média ou o máximo dentro do intervalo é usado como referência. |
| `in the range` | Especifica o intervalo alvo do eixo horizontal. |
| `to` | Especifica o valor de intensidade alvo após a normalização. |

### Botão Apply for all profiles {#apply-all}

O botão `Aplicar a todos os perfis (sem ajuste de fundo)` aplica as configurações das etapas 1–7, **excluindo 6. Background**, a todos os perfis de uma só vez.

---

## Configuração de eixo {#axis-setting}

Na aba `Ajuste de eixo` você redefine o tipo de eixo horizontal de origem, o comprimento de onda, o ângulo de saída (take-off) e o tempo de exposição do perfil selecionado. A unidade de exibição do eixo horizontal não é escolhida aqui, mas na aba `Eixo horizontal` da janela principal.

| Item | Descrição |
| --- | --- |
| `Configuração do eixo horizontal` | Define o tipo de eixo horizontal de origem, o comprimento de onda e o ângulo de saída; `Alterar` os grava de volta no perfil selecionado. Com `Deslocar` você também pode deslocar todo o eixo horizontal. |
| `Exposure Time` | Define o tempo de exposição (`seg.`) usado no modo CPS (`(for CPS mode)`). |
| `Configuração do eixo vertical` | Configurações relacionadas ao eixo vertical. |

!!! note
    Clicar em `Alterar` grava de volta no perfil o tipo de eixo de origem, o ângulo de saída, o comprimento de onda e o tempo de exposição. Diferentemente da troca de eixo apenas para exibição na janela principal, isso afeta como os próprios dados são interpretados. Como o comprimento de onda e o ângulo de saída influenciam diretamente o cálculo das posições das linhas de difração, defina os valores corretos. Uma unidade de entrada errada escolhida na importação não pode ser corrigida aqui; abra novamente o arquivo de origem.

---

## Operador de perfil {#profile-operator}

Na aba `Operador de perfis` você realiza a média de múltiplos perfis e operações aritméticas entre perfis.

Após especificar os perfis alvo do cálculo e a operação que deseja realizar, pressione o botão `Calcular`; o resultado é adicionado como um novo perfil.

| Modo | Descrição |
| --- | --- |
| `Média` | Faz a média de múltiplos perfis. |
| `Perfil e valor` | Opera entre um perfil e um valor escalar. |
| `Dois perfis` | Realiza uma operação aritmética (como adição) entre dois perfis. |

Com `Nome de saída do perfil` você pode especificar o nome do perfil gerado (o padrão é `Result #01`).

!!! tip
    Isso pode ser usado, por exemplo, para fazer a média de várias medições e melhorar a razão S/N, ou para tomar a diferença de dois perfis a fim de extrair a mudança entre eles.
