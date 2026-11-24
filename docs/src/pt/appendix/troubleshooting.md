<!-- 260601Cl: migrated from legacy docx + yseto.net web manual -->
# Solução de problemas

Se você encontrar um problema ao usar o PDIndexer, verifique primeiro os itens abaixo. A maioria dos problemas é resolvida instalando o runtime ou revisando uma configuração.

## O aplicativo não inicia

Estes requisitos aplicam-se às compilações .NET 11 deste código-fonte. Para versões publicadas, siga os requisitos de runtime indicados para a versão correspondente.

A instalação por MSI do PDIndexer requer o **.NET Desktop Runtime** especificado por essa versão (as compilações deste código-fonte têm como alvo o .NET 11). O ZIP sem instalação inclui seu runtime. Se o runtime não estiver instalado em uma instalação por MSI, você poderá ver um erro na inicialização, ou o programa poderá encerrar sem fazer nada.

!!! warning "Correção"
    Siga [Runtime e instalação](runtime-and-installation.md) para instalar o **.NET Desktop Runtime** exigido pela versão que você usa, correspondente à arquitetura do aplicativo (x64 ou Arm64), e, em seguida, reinicie o PDIndexer.

## O idioma da interface não muda

<!-- 261124Cl changed: the old text described an English/Japanese choice and a manual restart; now there are 11 languages and PDIndexer restarts itself after a confirmation dialog -->
Escolha o idioma de exibição (11 idiomas, cada um mostrado pelo próprio nome) em `Idioma`, na extremidade direita da barra de menus. A troca de idioma exige reiniciar: escolha **Sim** na caixa de diálogo de confirmação, e o PDIndexer reinicia automaticamente no idioma selecionado.

!!! note
    A reinicialização descarta o trabalho não salvo (perfis carregados e edições em andamento), portanto salve o que precisar antes de trocar. Se você escolher **Não**, o idioma não muda.

## Redefinir configurações corrompidas

Posições das janelas, configurações de cores e várias opções são salvas no registro. Se as configurações ficarem corrompidas e o programa se comportar mal, você pode limpar o registro para retornar ao estado inicial.

1. No menu, marque `Opções` ▸ `Limpar Registro (marcar e reiniciar)`.
2. Feche o PDIndexer. Todas as configurações salvas são limpas ao sair.
3. Inicie o PDIndexer novamente; ele será iniciado no seu estado inicial (padrão).

!!! warning
    Isso limpa todas as configurações salvas, incluindo o layout das janelas e as opções. Não pode ser desfeito até que você reinicie e as configurações sejam redefinidas.

## A importação da área de transferência do IPAnalyzer / CSManager não funciona

Perfis e cristais copiados em aplicativos irmãos como o [IPAnalyzer](https://github.com/seto77/IPAnalyzer) e o [CSManager](https://github.com/seto77/CSManager) podem ser importados automaticamente para o PDIndexer via área de transferência. Se nada for importado, o monitoramento da área de transferência pode estar desativado.

- Verifique se `Opções` ▸ `Monitorar área de transferência` está ativado no menu.
- Quando ativado, perfis/cristais copiados de outros aplicativos são lidos automaticamente.

!!! tip
    Se você quiser ler automaticamente arquivos `.pdi` recém-criados em uma pasta específica, use `Opções` ▸ `Monitorar arquivo`.

## As razões de intensidade não são calculadas

Para calcular as intensidades teóricas de difração, a estrutura do cristal deve conter **posições atômicas (coordenadas atômicas)**. Se as posições atômicas não forem inseridas, as posições dos picos (valores de \(d\)) ainda podem ser calculadas, mas as razões de intensidade não.

!!! note "Correção"
    Em [Parâmetros do cristal](../3-crystal-parameter.md), insira o elemento, as coordenadas e a ocupação de cada átomo. Uma vez inseridas as posições atômicas, as razões de intensidade são calculadas a partir do fator de estrutura.

## O ajuste relata parâmetros de rede NA (não disponível)

Ao refinar os parâmetros de rede com o ajuste de picos, um número insuficiente de reflexões independentes deixa os parâmetros de rede indeterminados. Nesse caso, o programa mantém a forma original da célula e altera apenas sua escala global, e os campos de erro mostram NA (não disponível). Quando o número de reflexões é igual ao número de parâmetros de rede independentes, os resíduos não permitem obter erros-padrão, e por isso os campos de erro também mostram NA.

- Dependendo do sistema cristalino, você deve fornecer reflexões suficientes para que o número de parâmetros de rede independentes seja determinado (por exemplo, apenas \(a\) para cúbico, mas seis valores \(a, b, c, \alpha, \beta, \gamma\) para triclínico).
- Se as reflexões forem linearmente dependentes (enviesadas em uma direção), certos parâmetros de rede não podem ser determinados. Inclua reflexões de diferentes orientações.

!!! note "Correção"
    Consulte [Ajuste de picos de difração](../6-fitting-diffraction-peaks.md) e certifique-se de que o ajuste inclua reflexões independentes suficientes.

## Ainda não resolvido

Para problemas que os passos acima não resolvem, ou para bugs reproduzíveis e solicitações de recursos, reporte-os no rastreador de issues do GitHub. Se possível, inclua os passos para reproduzir, o arquivo que você usou e uma captura de tela.

- Rastreador de issues: <https://github.com/seto77/PDIndexer/issues>
