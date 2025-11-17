# Testes Unitários - TP Grafos

Este diretório contém os testes unitários para o projeto TP-Grafos.

## 📋 Resumo

- **Total de Testes:** 78
- **Classes Testadas:** Grafo (Matriz e Lista), BuscaEmLargura, Aresta
- **Framework:** MSTest
- **Cobertura:** >70%

## 🚀 Como Executar

### Método Rápido (Recomendado)
```powershell
.\run-tests.ps1
```

### Método Manual
```powershell
# Compilar
dotnet build

# Executar testes
dotnet test

# Executar com cobertura
dotnet test --collect:"XPlat Code Coverage"

# Gerar relatório HTML
reportgenerator "-reports:TestResults\**\coverage.cobertura.xml" "-targetdir:TestResults\CoverageReport" -reporttypes:Html
```

## 📊 Classes de Teste

### MatrizTests.cs (29 testes)
Testa a implementação de grafos usando Matriz de Adjacência:
- Constructor e inicialização
- Operações de adição de arestas
- Consultas de adjacência e incidência
- Cálculos de grau
- Substituições e manipulações

### ListaTests.cs (30 testes)
Testa a implementação de grafos usando Lista de Adjacência:
- Todos os métodos da classe Matriz
- Casos específicos para listas
- Suporte a arestas duplicadas

### BuscaEmLarguraTests.cs (19 testes)
Testa o algoritmo de Busca em Largura (BFS):
- Grafos simples e complexos
- Grafos com ciclos
- Grafos desconexos
- Diferentes topologias (estrela, árvore, etc.)

## 📈 Cobertura de Código

A cobertura de código é calculada automaticamente usando **Coverlet** e visualizada com **ReportGenerator**.

Após executar os testes, abra o relatório em:
```
TestResults/CoverageReport/index.html
```

## ✅ Status dos Testes

| Classe | Testes | Status |
|--------|--------|--------|
| MatrizTests | 29 | ✅ 100% |
| ListaTests | 30 | ✅ 100% |
| BuscaEmLarguraTests | 19 | ✅ 100% |
| **Total** | **78** | **✅ 100%** |

## 🛠️ Dependências

- MSTest.TestAdapter (3.1.1)
- MSTest.TestFramework (3.1.1)
- coverlet.collector (6.0.0)
- Microsoft.NET.Test.Sdk (17.8.0)

## 📝 Notas

- Os testes foram desenvolvidos seguindo as boas práticas de testes unitários
- Cada teste é independente e pode ser executado isoladamente
- A nomenclatura segue o padrão: `MetodoTestado_Cenario_ComportamentoEsperado`
- Todos os testes incluem documentação XML explicando seu propósito

## 🎯 Parte do Trabalho

Este projeto de testes cobre especificamente:
- ✅ Classe Grafo (através das implementações Matriz e Lista)
- ✅ Classe BuscaEmLargura

Conforme solicitado para o Trabalho Prático de Teste de Software.
