# 🎯 Guia Rápido - Testes Unitários TP Grafos

## ✅ O Que Foi Feito

### Testes Implementados
- **78 casos de teste** cobrindo:
  - ✅ Classe Grafo (via Matriz - 29 testes)
  - ✅ Classe Grafo (via Lista - 30 testes)
  - ✅ Classe BuscaEmLargura (19 testes)

### Resultado
- **100% dos testes passando**
- **~80-85% de cobertura** nas classes testadas
- **Ferramentas automatizadas** configuradas

## 🚀 Como Usar

### Executar Testes (Forma mais Fácil)
```powershell
cd code\TP-Grafos\TP-Grafos.Tests
.\run-tests.ps1
```

Este script irá:
1. ✅ Compilar o projeto
2. ✅ Executar todos os 78 testes
3. ✅ Gerar relatório de cobertura
4. ✅ Abrir o relatório no navegador

### Executar Testes (Forma Manual)
```powershell
cd code\TP-Grafos\TP-Grafos.Tests
dotnet test --collect:"XPlat Code Coverage"
```

### Ver Relatório de Cobertura
```powershell
cd code\TP-Grafos\TP-Grafos.Tests
reportgenerator "-reports:TestResults\**\coverage.cobertura.xml" "-targetdir:TestResults\CoverageReport" -reporttypes:Html
Start-Process TestResults\CoverageReport\index.html
```

## 📊 Estatísticas

| Métrica | Valor |
|---------|-------|
| Total de Testes | 78 |
| Taxa de Sucesso | 100% |
| Classes Testadas | 5 (Grafo, Matriz, Lista, BuscaEmLargura, Aresta) |
| Métodos Testados | 29+ |
| Duração | 8.7s |

## 📁 Arquivos Importantes

### Testes
- `MatrizTests.cs` - 29 testes para implementação com Matriz
- `ListaTests.cs` - 30 testes para implementação com Lista
- `BuscaEmLarguraTests.cs` - 19 testes para algoritmo BFS

### Documentação
- `README.md` - Documentação do projeto de testes
- `COBERTURA.md` - Detalhes completos de cobertura
- `RELATORIO_TESTES.md` (raiz) - Relatório completo do trabalho

### Scripts
- `run-tests.ps1` - Script automatizado de execução

### Configuração
- `TP-Grafos.Tests.csproj` - Configuração do projeto

## 🎓 Para a Apresentação

### Pontos Principais:
1. **78 testes implementados** (100% de sucesso)
2. **Classes testadas:** Grafo (Matriz e Lista) + BuscaEmLargura
3. **Cobertura:** ~80-85% nas classes testadas
4. **Ferramenta:** Coverlet + ReportGenerator (automatizada)

### Demonstração:
```powershell
# 1. Mostrar estrutura do projeto
ls code\TP-Grafos\TP-Grafos.Tests\*.cs

# 2. Executar testes
.\run-tests.ps1

# 3. Mostrar relatório HTML
# (abre automaticamente)
```

## 📋 Requisitos Atendidos

- ✅ Software com 10+ classes
- ✅ 20+ métodos/funções testados
- ✅ Casos de teste desenvolvidos (78)
- ✅ Cálculo de cobertura via software
- ✅ 70%+ de cobertura (nas classes testadas)

## 🔗 Links

- **Repositório:** https://github.com/Pedro-Resende-VEVO/TPratico_Grafos
- **Relatório HTML:** `TestResults/CoverageReport/index.html`

---

**Pronto para apresentar! 🎉**
