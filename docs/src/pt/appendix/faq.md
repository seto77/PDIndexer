<!-- 261124Cl added: Q&A page, compiled anonymously from GitHub issues and support e-mails to the author (2006–2026); reviewed with codex2 (2 rounds). Lead language: ja/appendix/faq.md -->
# Q&A

Esta página reúne perguntas que os usuários realmente fizeram, com foco nas mais comuns e nos pontos que costumam causar confusão. Para erros e problemas na inicialização, consulte também [Solução de problemas](troubleshooting.md).

## O que tentar primeiro {#first-steps}

### Algo não funciona (as linhas de difração não aparecem, um arquivo não pode ser lido, aparece um erro na inicialização). O que devo tentar primeiro?

Primeiro procure nesta página o item que corresponde ao seu sintoma. Quando as linhas de difração não aparecem, a causa é quase sempre a configuração da radiação ou do comprimento de onda ([Linhas de difração e lista de cristais](#peaks-and-crystals)). Se isso não resolver, tente o seguinte, nesta ordem.

1. Atualize para a versão mais recente (`Ajuda` ▸ `Atualizações do Programa`, ou baixe-a da [página de versões](https://github.com/seto77/PDIndexer/releases/latest)).
2. Marque `Opções` ▸ `Limpar Registro (marcar e reiniciar)`, depois feche e reinicie o PDIndexer. O PDIndexer armazena no registro as posições das janelas, as configurações do feixe etc., e configurações herdadas de uma versão antiga podem causar problemas.
3. Se a lista de cristais parecer errada, execute `Arquivo` ▸ `Reverter cristais ao estado inicial`.

!!! warning "O que se perde"
    - **Limpar o registro** remove as configurações salvas e **as macros registradas na janela de macros**. Exporte antes as macros de que precisa como arquivos `.mcr`. A lista de cristais não é armazenada no registro, mas em um arquivo separado (`%APPDATA%\PDIndexer\PDIndexer\default.xml`); por isso, limpar o registro não a remove.
    - **Reverter a lista de cristais** descarta os cristais que você adicionou ou editou. Salve antes os cristais de que precisa com `Arquivo` ▸ `Salvar cristais`.

### Quando uso o PDIndexer junto com o IPAnalyzer, aparecem erros ou valores errados.

O [IPAnalyzer](https://github.com/seto77/IPAnalyzer) e o PDIndexer compartilham uma biblioteca comum e trocam dados pela área de transferência. Se apenas um deles for atualizado, o formato de troca pode não coincidir, o que pode causar erros ou valores errados. **Mantenha os dois atualizados ao mesmo tempo.**

## Instalação e inicialização {#install}

### Não consigo instalar o PDIndexer em um PC sem direitos de administrador, ou uma política bloqueia o MSI.

Use o **pacote ZIP sem instalação** (`PDIndexer-v.<ver>.zip` para x64, `PDIndexer-v.<ver>_arm64.zip` para Arm64). Ele inclui o runtime, portanto você não precisa nem do MSI nem de um .NET Desktop Runtime separado. Extraia a pasta inteira para um local com permissão de escrita e execute `PDIndexer.exe` na pasta extraída. O próprio PDIndexer funciona com direitos de usuário comum.

Consulte [Runtime e instalação](runtime-and-installation.md) para as diferenças entre os pacotes MSI e ZIP.

!!! note
    O PDIndexer é um software de pesquisa sem assinatura, por isso o Windows (SmartScreen) ou o navegador podem exibir um aviso quando você o baixa ou o executa pela primeira vez. Na lista de downloads do navegador, escolha **Mais informações** ▸ **Manter**; no aviso de execução, escolha **Mais informações** ▸ **Executar assim mesmo**.

### Aparece "You must install .NET Desktop Runtime", embora eu tenha instalado o .NET.

A causa costuma ser uma das seguintes.

- **Versão principal errada.** A versão do .NET exigida muda entre as versões do PDIndexer. Instale o **Desktop Runtime** da versão indicada para a versão do PDIndexer que você usa. O simples ".NET Runtime" não basta.
- **Arquitetura errada.** O build x64 do PDIndexer precisa do runtime x64; o build Arm64 precisa do runtime Arm64. No Windows para Arm (PCs com Snapdragon etc.), use o instalador Arm64 `PDIndexer-setup_arm64.msi`.
- Se ainda assim não funcionar, o **pacote ZIP sem instalação**, que inclui o runtime, é a opção mais segura.

## Linhas de difração e lista de cristais {#peaks-and-crystals}

### Marco um cristal, mas nenhuma linha de difração aparece, ou elas estão muito deslocadas.

Verifique primeiro o seguinte.

- [`Mostrar peaks sobre os perfis`](../3-crystal-parameter.md) está ativado, e o cristal está marcado na lista de cristais.
- **A radiação e o comprimento de onda (ou a energia) da medição estão definidos corretamente.** Dados de texto como CSV muitas vezes não contêm informação de comprimento de onda; nesse caso, especifique a radiação e o comprimento de onda usados na medição na caixa de diálogo exibida ao ler o arquivo. Verifique a radiação e o comprimento de onda usados para exibição na [aba `Eixo horizontal`](../1-main-window.md#horizontal-axis-tab) da janela principal.
- As linhas não estão fora do intervalo de desenho. Tente ampliar o intervalo horizontal (especialmente para TOF de nêutrons).
- Se apenas um cristal não aparecer, verifique se seus parâmetros de rede e posições atômicas não estão muito errados, e compare-o com a mesma substância no banco de dados incorporado.

### Arrastei uma linha de difração e os parâmetros de rede mudaram. Reiniciar não os restaura.

Os parâmetros de rede alterados ao arrastar uma linha de difração são salvos quando o PDIndexer é fechado, porque `Opções` ▸ `Salvar a lista de cristais ao fechar` vem ativado por padrão. Por isso, reiniciar não desfaz a alteração.

- Para voltar aos parâmetros de rede que o cristal tinha quando foi carregado na sessão atual, clique com o botão direito nas informações do cristal e escolha `Reverter constantes de célula`.
- Para devolver toda a lista de cristais ao estado logo após a instalação, escolha `Arquivo` ▸ `Reverter cristais ao estado inicial`.

### A lista de cristais contém valores estranhos ou duplicatas, ou falta um padrão de pressão (Au, Pt etc.).

`Arquivo` ▸ `Reverter cristais ao estado inicial` restaura a lista inicial de cristais, incluindo os padrões de pressão. Os cristais que você mesmo adicionou são perdidos; salve-os antes, se necessário.

### As razões de intensidade não são calculadas; todas as linhas têm a mesma altura.

Para calcular as razões de intensidade, o cristal precisa ter posições atômicas e [`Calcular razão de intensidade`](../3-crystal-parameter.md) deve estar ativado. Configurações de radiação erradas também produzem intensidades erradas. Consulte [Solução de problemas](troubleshooting.md) para detalhes.

### Como importo cristais do CSManager ou de arquivos CIF?

- **Do CSManager**: abra a janela `Parâmetro do cristal` do PDIndexer e ative antes `Opções` ▸ `Monitorar área de transferência`; depois selecione o cristal no CSManager. Não é preciso exportar um CIF primeiro.
- **Arquivos CIF / AMC** podem ser arrastados e soltos na área de informações do cristal da janela Parâmetro do cristal.
- Você também pode pesquisar no **banco de dados de cristais incorporado** (AMCSD). Consulte [Parâmetros do cristal](../3-crystal-parameter.md).

Em todos os casos, o cristal aparece na área de informações do cristal. Pressione `Adicionar` para mantê-lo na lista de cristais.

### Posso sobrepor dados de raios X e dados de elétrons (ou de outro comprimento de onda) no mesmo eixo horizontal?

Sim. O PDIndexer tem um único eixo horizontal, e todos os perfis carregados são convertidos para a radiação e o comprimento de onda escolhidos na aba `Eixo horizontal`. Por exemplo, um perfil de difração de elétrons pode ser mostrado na escala 2θ do Cu Kα.

Se `Após ler o perfil, alterar o eixo horizontal` estiver ativado na aba `Eixo horizontal`, as configurações do eixo passam a ser as de cada arquivo recém-carregado. Desmarque essa opção para manter um eixo fixo para comparação.

## Leitura de perfis e eixo horizontal {#profiles-and-axis}

### Qual é a diferença entre a aba `Eixo horizontal` da janela principal e `Ajuste de eixo` na janela de parâmetros do perfil?

- A **aba `Eixo horizontal`** (janela principal) decide apenas **como os dados são exibidos**; os próprios dados do perfil não mudam.
- **[`Ajuste de eixo`](../4-profile-parameter.md#axis-setting)** (janela de parâmetros do perfil) reescreve **as condições em que o perfil foi medido** (tipo de radiação, comprimento de onda, ângulo de saída etc.). Se você escolheu a radiação ou o comprimento de onda errados ao ler o arquivo, corrija aqui. Se você inseriu valores na **unidade** errada, leia novamente o arquivo original.

### Dados de dispersão de energia (raios X brancos) (`.npd` / `.nxs`) têm o eixo horizontal errado, ou nenhuma linha de difração aparece.

Na caixa de diálogo exibida ao ler o arquivo, verifique se a **unidade de energia (eV / keV)**, o **2θ** e, para `.nxs`, os **coeficientes de calibração canal–energia** correspondem à medição. Os arquivos `.npd` usam a coluna de energia do arquivo; por isso, verifique também os valores e a unidade no arquivo original. Uma unidade errada desloca muito as posições dos picos.

### O PDIndexer consegue ler arquivos GSAS `.gsa` (2θ em centigraus) ou dados em um eixo q (número de onda)?

Sim.

- Para um arquivo `.gsa` (três colunas separadas por espaços, com 2θ em centigraus), escolha 2θ como eixo horizontal e centigraus (centi-degree) como unidade na caixa de diálogo de conversão de dados.
- Para dados em um eixo q (número de onda), escolha q como eixo horizontal. Também é possível refinar os parâmetros de rede no eixo q.

## Ajuste de picos e parâmetros de rede {#fitting}

### Que valor devo usar em `Intervalo de pesquisa` (Search Range)? O volume muda quando eu o altero.

`Intervalo de pesquisa` é a largura de busca de cada lado do centro do pico. Comece com **2–3 vezes a largura total a meia altura (FWHM)** do pico e reduza-o se o pico vizinho se sobrepuser. Um intervalo largo demais capta outros picos ou o background, e um intervalo estreito demais corta as caudas do pico; ambos deslocam a posição ajustada. Usar muitos **picos de alto ângulo** melhora a precisão dos parâmetros de rede.

### Os valores mostrados em `Parâmetros de célula otimizados` (Optimized cell constants) já foram aplicados ao cristal?

Não. `Parâmetros de célula otimizados` apenas **exibe** os valores obtidos a partir das reflexões selecionadas e das condições de ajuste. Para sobrescrever os parâmetros de rede do cristal, pressione `Aplicar ao cristal` (Apply to the crystal). Para usar os valores sem alterar o cristal, use `Copiar para a área de transferência`. Pressionar `Aplicar ao cristal` algumas vezes pode ajudar a convergência, porque as posições calculadas das linhas são atualizadas a cada vez.

### Seleciono as mesmas reflexões, mas o erro do volume de repente fica grande.

O ajuste de picos (ajustar uma função a cada pico) e o refinamento dos parâmetros de rede são cálculos separados. O PDIndexer apenas procura um pico dentro do intervalo de pesquisa de cada reflexão; portanto, se um pico de outra fase ou ruído cair dentro do intervalo, um valor de d errado entra no cálculo dos parâmetros de rede.

- Verifique o ajuste de cada reflexão na lista de reflexões e exclua picos duvidosos ou fracos.
- Quando a razão sinal-ruído for ruim, refine primeiro apenas com os picos fortes e adicione os picos mais fracos depois. São necessárias pelo menos tantas reflexões independentes quanto o número de parâmetros de rede independentes do sistema cristalino (1 para cúbico, 6 para triclínico), e mais do que isso para estimar os erros.
- Para padrões fracos ou com muita sobreposição, um ajuste de padrão completo, como a análise de Rietveld, pode ser mais adequado.

Consulte [Algoritmos](algorithms.md#lattice-refinement) para saber como os parâmetros de rede e seus erros são calculados.

## Análise sequencial e macros {#sequential-and-macro}

### Quero ajustar automaticamente muitos perfis (resolvidos no tempo, etapas de pressão etc.) e obter parâmetros de rede ou pressões.

Use a [Análise sequencial](../7-sequential-analysis.md) (abra-a pela barra de ferramentas da janela principal ou com `Ctrl+Shift+S`). **Abra a janela de ajuste de picos** e escolha o cristal e as reflexões antes de executá-la. São necessários pelo menos quatro perfis. Os resultados podem ser salvos automaticamente.

- Ler milhares de perfis de uma vez consome muita memória. Defina primeiro as condições com cerca de 100 perfis e depois execute o conjunto inteiro.
- Ler diretamente de uma pasta de rede é lento. Copie os arquivos para um disco local antes da análise.
- Se os parâmetros de rede mudarem muito ao longo da série, um pico pode sair do seu intervalo de pesquisa e outro pico pode ser captado. Com `Fator de tolerância` ativado, os pontos cujo volume difere do **volume no início da execução** em mais do que o valor definido (%) são gravados como NaN.

### A análise sequencial pode ajustar várias fases (por exemplo, a amostra e um marcador de pressão) ao mesmo tempo?

Os picos de todos os cristais marcados são ajustados (com a decomposição do padrão definida como `entre cristais` (between crystals), os picos sobrepostos de fases diferentes são separados em conjunto). No entanto, cada execução sequencial registra parâmetros de rede e pressão apenas para o único cristal selecionado na janela de ajuste de picos. Para obter os resultados de outra fase, selecione esse cristal e execute novamente, ou use uma [macro](../8-macro.md) que alterne entre os cristais.

### Executei uma análise de tensão em perfis divididos por azimute, mas a aba `Equação de Singh` está vazia.

O modo de análise de tensão é selecionado somente quando **o nome do primeiro perfil da lista de perfis termina em `whole`**. Para o segundo perfil e os seguintes, o texto **após o último hífen** do nome é lido como o azimute em graus (por exemplo, `sample-30`). Verifique também se pelo menos quatro perfis estão carregados e se a janela de ajuste de picos está aberta. Em uma execução comum (fora do modo de tensão), a aba `Equação de Singh` fica vazia. Consulte [Análise sequencial](../7-sequential-analysis.md) para detalhes.

### Com a vírgula como separador decimal, as colunas do CSV da análise sequencial ficam deslocadas.

O CSV da análise sequencial reutiliza os números mostrados na tela; por isso, com vírgula como separador decimal (`1,5`), as casas decimais não podem ser distinguidas dos separadores de coluna. Por enquanto, use `Copiar` na aba de resultados para copiar a tabela como texto separado por tabulações e cole-a na sua planilha como dados separados por tabulações. A exportação CSV dos próprios perfis (`Arquivo` ▸ `Exportar o(s) perfil(is) selecionado(s)`) sempre grava `.` como separador decimal, independentemente das configurações regionais.

### Em que linguagem as macros são escritas? Como devo escrever os caminhos de arquivo?

As macros são escritas em **Python (IronPython)**. Escreva os caminhos do Windows com barras normais (`'C:/data/sample.pdi2'`) ou como strings raw (`r'C:\data\sample.pdi2'`). As funções disponíveis estão listadas na referência de funções de [Macro](../8-macro.md).

## Equações de estado {#eos}

### Inseri uma temperatura. O resultado é válido como pressão em alta temperatura?

Algumas equações de estado (EOS) não têm termo de temperatura no artigo original (equações isotérmicas), e a temperatura inserida não é usada. As EOS que interpolam tabelas da literatura dão **pressões imprecisas fora do intervalo de temperatura e volume da tabela**. Verifique a fonte e o intervalo de validade da EOS em [Equações de estado](../5-equation-of-states.md).

## Outras perguntas {#others}

### O que devo enviar ao relatar um bug?

Relate-o nas [GitHub Issues](https://github.com/seto77/PDIndexer/issues) com o seguinte.

- A versão do PDIndexer (`Ajuda` ▸ `Sobre`) e a versão do Windows
- Um conjunto mínimo e compartilhável de arquivos que reproduza o problema (perfis, o `.xml` da lista de cristais, arquivos de configuração do IPAnalyzer etc.)
- Os passos que você seguiu e a mensagem de erro ou uma captura de tela
- O resultado que você esperava (o valor que você acredita ser o correto)

### Posso apresentar ou redistribuir o PDIndexer na página web de uma linha de luz ou de um laboratório?

Sim. O PDIndexer é distribuído sob a [Licença MIT](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md). Ao redistribuí-lo, inclua o aviso de direitos autorais e o texto da licença.
