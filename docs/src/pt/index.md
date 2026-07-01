<!-- 260601Cl: English landing page for the PDIndexer Pages manual (content migrated from the legacy docx + yseto.net web manual). -->
<!-- 260625Cl: static-i18n folder mode へ移設 (docs/src/index.md → docs/src/en/index.md)。画像は ../assets、内部リンクは en/ 接頭辞を剥がす。 -->
# Manual do PDIndexer

**PDIndexer** é um aplicativo Windows gratuito, licenciado sob MIT, para analisar padrões de difração de pó unidimensionais (raios X de laboratório / síncrotron, nêutrons TOF). Ele exibe perfis medidos, sobrepõe linhas de difração calculadas a partir de estruturas cristalinas, processa e calibra perfis, ajusta picos para refinar parâmetros de rede por mínimos quadrados e estima a pressão a partir das equações de estado de materiais padrão.

![Janela principal do PDIndexer](../assets/cap-pt-auto/FormMain.png)

## Encontrar por objetivo

| Objetivo | Comece aqui | Próximos passos principais |
|------|------------|-----------------|
| Carregar e exibir um perfil medido | [2. Perfis de difração](2-pattern-profiles.md) | [1. Janela principal](1-main-window.md), [Formatos de arquivo](appendix/file-formats.md) |
| Identificar fases sobrepondo cristais conhecidos | [3. Parâmetros do cristal](3-crystal-parameter.md) | [2. Perfis de difração](2-pattern-profiles.md) |
| Processar / calibrar um perfil | [4. Parâmetros do perfil](4-profile-parameter.md) | [3. Parâmetros do cristal](3-crystal-parameter.md) |
| Ajustar picos e refinar parâmetros de rede | [6. Ajuste de picos de difração](6-fitting-diffraction-peaks.md) | [3. Parâmetros do cristal](3-crystal-parameter.md) |
| Estimar a pressão a partir de um material padrão | [5. Equações de estado](5-equation-of-states.md) | [6. Ajuste de picos de difração](6-fitting-diffraction-peaks.md) |
| Processar em lote uma série de perfis | [7. Análise sequencial](7-sequential-analysis.md) | [8. Macro](8-macro.md) |
| Automatizar tarefas com scripts | [8. Macro](8-macro.md) | [7. Análise sequencial](7-sequential-analysis.md) |

## Conteúdo

- [0. Visão geral](0-overview.md) — o que o PDIndexer faz e seus principais recursos
- [1. Janela principal](1-main-window.md) — layout, menus, barra de ferramentas, listas de perfis/cristais
- [2. Perfis de difração](2-pattern-profiles.md) — dados de perfil, formatos suportados, carregamento
- [3. Parâmetros do cristal](3-crystal-parameter.md) — exibição de linhas de difração, informações do cristal, banco de dados
- [4. Parâmetros do perfil](4-profile-parameter.md) — processamento de perfil, configurações de eixo, operadores
- [5. Equações de estado](5-equation-of-states.md) — pressão a partir da EOS de material padrão
- [6. Ajuste de picos de difração](6-fitting-diffraction-peaks.md) — ajuste de picos e refinamento de rede
- [7. Análise sequencial](7-sequential-analysis.md) — análise em lote sobre uma série de perfis
- [8. Macro](8-macro.md) — script IronPython e referência de funções

### Apêndice

- [Runtime e instalação](appendix/runtime-and-installation.md)
- [Formatos de arquivo](appendix/file-formats.md)
- [Solução de problemas](appendix/troubleshooting.md)

## Início rápido

1. Baixe e instale a partir de [Releases](https://github.com/seto77/PDIndexer/releases/latest) e, em seguida, inicie o *PDIndexer*.
2. Abra um perfil medido (arraste e solte um arquivo, ou cole um perfil copiado do [IPAnalyzer](https://github.com/seto77/IPAnalyzer)).
3. Adicione cristais conhecidos a partir do banco de dados integrado (ou importe um arquivo CIF/AMC) para sobrepor suas linhas de difração.
4. Ajuste os picos para refinar parâmetros de rede, ou estime a pressão a partir da equação de estado de um material padrão.

## Requisitos do sistema

| Item | Requisito |
|------|-------------|
| SO | Windows com o [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) (**não** o .NET Runtime) |
| Recomendado | Windows 10/11 de 64 bits, 16 GB ou mais de memória, CPU de 8 núcleos ou superior |

Consulte [Runtime e instalação](appendix/runtime-and-installation.md) para obter detalhes.

!!! note
    O código-fonte, as versões e o rastreador de problemas estão no [GitHub](https://github.com/seto77/PDIndexer). O PDIndexer é distribuído sob a [Licença MIT](https://github.com/seto77/PDIndexer/blob/master/LICENSE.md).
