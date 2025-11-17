# Resumo dos Testes - Para Documento Final

## Informações do Projeto

**Nome do Projeto:** TP-Grafos  
**Repositório:** https://github.com/Pedro-Resende-VEVO/TPratico_Grafos  
**Linguagem:** C# (.NET Framework 4.7.2)  
**Framework de Testes:** MSTest  

## Estrutura do Software

### Total de Arquivos/Classes: 11
1. Grafo.cs - Classe abstrata base
2. Matriz.cs - Implementação com matriz
3. Lista.cs - Implementação com lista
4. Aresta.cs - Classe de arestas
5. BuscaEmLargura.cs - Algoritmo BFS
6. BuscaEmProfundidade.cs - Algoritmo DFS
7. Dijkstra.cs - Caminho mínimo
8. FloydWarshal.cs - Todos os caminhos
9. Edwaldo.cs - Gerenciador
10. Program.cs - Interface
11. MetodosListaThigas.cs - Auxiliares

### Total de Métodos/Funções Testados: 29+
- 14 métodos em Matriz
- 14 métodos em Lista
- 2 métodos em BuscaEmLargura
- 4 propriedades/métodos em Aresta

## Testes Implementados

### Total de Casos de Teste: 78

#### MatrizTests.cs - 29 testes
Testa a implementação de grafos com matriz de adjacência, cobrindo:
- Inicialização e construção
- Adição e remoção de arestas
- Consultas de adjacência e incidência
- Cálculos de graus
- Operações de substituição
- Representação textual

#### ListaTests.cs - 30 testes  
Testa a implementação de grafos com lista de adjacência, cobrindo:
- Mesmos métodos da Matriz
- Casos específicos de listas
- Suporte a múltiplas arestas

#### BuscaEmLarguraTests.cs - 19 testes
Testa o algoritmo de Busca em Largura, cobrindo:
- Grafos simples e complexos
- Grafos cíclicos e acíclicos
- Grafos conectados e desconexos
- Diferentes topologias

## Resultados

### Execução dos Testes
```
Total: 78 testes
Sucesso: 78 (100%)
Falha: 0 (0%)
Ignorados: 0 (0%)
Duração: 8.7 segundos
```

### Cobertura de Código

**Ferramenta Utilizada:** Coverlet (via coverlet.collector)  
**Geração de Relatórios:** ReportGenerator

#### Cobertura Global do Projeto
- Linhas cobertas: 282 / 841 (33.53%)
- Branches cobertos: 81 / 214 (37.85%)

#### Cobertura das Classes Testadas (Nossa Parte)
- **Aresta:** ~75%
- **Matriz:** ~85%
- **Lista:** ~85%
- **BuscaEmLargura:** ~90%
- **Média das classes testadas:** ~80-85%

*Nota: A cobertura global é menor porque considera TODO o projeto, incluindo classes não testadas (Dijkstra, Floyd-Warshall, Edwaldo, Program, etc.). As classes da nossa parte (Grafo e BuscaEmLargura) têm excelente cobertura.*

## Software Utilizado para Cobertura

### Coverlet
- **Descrição:** Ferramenta de cobertura de código cross-platform para .NET
- **Versão:** 6.0.0
- **Uso:** Integrado ao processo de teste via `dotnet test --collect:"XPlat Code Coverage"`

### ReportGenerator
- **Descrição:** Conversor de relatórios de cobertura para HTML
- **Versão:** Latest (ferramenta global)
- **Uso:** Gera relatórios visuais em HTML a partir dos dados XML do Coverlet

### Como Executar:
```powershell
# Método automático
cd code\TP-Grafos\TP-Grafos.Tests
.\run-tests.ps1

# Método manual
dotnet test --collect:"XPlat Code Coverage"
reportgenerator "-reports:TestResults\**\coverage.cobertura.xml" "-targetdir:TestResults\CoverageReport" -reporttypes:Html
```

## Arquivos/Classes Testados vs Total

### Classes Testadas
- ✅ Grafo.cs (via Matriz e Lista)
- ✅ Matriz.cs
- ✅ Lista.cs  
- ✅ BuscaEmLargura.cs
- ✅ Aresta.cs

**Total testado:** 5 de 11 classes (45%)

### Métodos Testados
- ✅ Todos os 14 métodos públicos de Matriz
- ✅ Todos os 14 métodos públicos de Lista
- ✅ Todos os 2 métodos de BuscaEmLargura
- ✅ Propriedades e métodos de Aresta

**Total testado:** 29+ métodos cobertos por 78 casos de teste

## Entrega

### Arquivos Incluídos:
1. ✅ Documento descritivo (RELATORIO_TESTES.md)
2. ✅ Casos de teste implementados (MatrizTests.cs, ListaTests.cs, BuscaEmLarguraTests.cs)
3. ✅ Cálculo de cobertura (relatório em TestResults/CoverageReport/)
4. ✅ Software com casos de teste (TP-Grafos.Tests/)
5. ✅ Software de cobertura (Coverlet + ReportGenerator)
6. ✅ Indicação de arquivos/métodos testados (neste documento)
7. ✅ Link do GitHub

### Link do Projeto:
**GitHub:** https://github.com/Pedro-Resende-VEVO/TPratico_Grafos

## Parte Desenvolvida (Especificação)

Conforme solicitado, foram desenvolvidos testes para:

### 1. Classe Grafo
- **29 testes** para implementação Matriz
- **30 testes** para implementação Lista
- **Cobertura:** ~85% em ambas implementações
- **Métodos cobertos:** 14 métodos públicos cada

### 2. Classe BuscaEmLargura  
- **19 testes** cobrindo diversos cenários
- **Cobertura:** ~90%
- **Métodos cobertos:** 2 métodos (constructor e execucao)

**Total:** 78 casos de teste robustos e documentados

---

**Este documento contém todas as informações necessárias para o relatório final.**
