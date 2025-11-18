using System;
using System.Linq;
using TP_Grafos;
using Xunit;

namespace Tests;

public class ListaTest
{
    [Fact]
    public void AddAresta_IndiceOcupado_DeveRetornarCorretamente()
        {
            var g = new Lista(3);

            g.addAresta(0, 1, 10);

            Assert.True(g.indiceOcupado(0, 1), "Deveria existir aresta de 0 para 1.");
            Assert.False(g.indiceOcupado(1, 0), "Não deveria existir aresta de 1 para 0.");
        }

    [Fact]
    public void ArestasAdjacentes_DeveFiltrarArestaOriginalEManterOutras()
        {
            var g = new Lista(3);

            // Vamos adicionar duas arestas com mesmo destino (0),
            // e usar uma delas como referência (a.V = 0).
            g.addAresta(0, 0, 1); // primeira aresta
            g.addAresta(1, 0, 2); // segunda aresta

            // Recupera a primeira aresta interna para usar como referência,
            // garantindo que o GetHashCode será igual para ela.
            var incidentes = g.arestasIncidentes(0);
            Assert.True(incidentes.Length >= 2);

            var aBase = incidentes[0];

            var adj = g.arestasAdjacentes(aBase);

            // A própria aresta não deve aparecer,
            // mas a outra aresta na mesma lista deve.
            Assert.Single(adj);
            Assert.Equal(1, adj[0].V);
            Assert.Equal(0, adj[0].W);
            Assert.Equal(2, adj[0].peso);
        }

    [Fact]
    public void VerticesAdjacentes_DeveRetornarDestinoDasArestasDaLista()
        {
            var g = new Lista(3);

            g.addAresta(0, 1, 5);   // armazenada em dados[1]
            g.addAresta(2, 1, 7);   // também em dados[1]

            var vertices = g.verticesAdjacentes(1);

            // O método retorna o W das arestas daquele índice,
            // que neste caso é sempre 1.
            Assert.Equal(new[] { 1, 1 }, vertices);
        }

    [Fact]
    public void ArestasIncidentes_DeveRetornarTodasArestasNoIndice()
        {
            var g = new Lista(3);

            g.addAresta(0, 2, 1);
            g.addAresta(1, 2, 2);

            var arestas = g.arestasIncidentes(2);

            Assert.Equal(2, arestas.Length);
            Assert.Contains(arestas, a => a.V == 0 && a.W == 2 && a.peso == 1);
            Assert.Contains(arestas, a => a.V == 1 && a.W == 2 && a.peso == 2);
        }

    [Fact]
    public void VerticesIncidentes_DeveRetornarVDeAresta()
        {
            var a = new Aresta(1, 2, 10);
            var g = new Lista(3);

            var vertices = g.verticesIncidentes(a);

            Assert.Equal(new[] { 1, 2 }, vertices);
        }

    [Fact]
    public void GrauEntradaEGrauSaida_DevemSerCalculadosCorretamente()
        {
            var g = new Lista(4);

            // addAresta(V,W,p)
            g.addAresta(0, 1, 1); // 0->1
            g.addAresta(2, 1, 2); // 2->1
            g.addAresta(1, 3, 3); // 1->3

            // grauEntrada(v): quantidade de arestas no índice v -> "entram" em v
            Assert.Equal(2, g.grauEntrada(1)); // 0->1 e 2->1

            // grauSaida(v): percorre todas as listas e conta a.V == v
            Assert.Equal(1, g.grauSaida(0));
            Assert.Equal(1, g.grauSaida(2));
            Assert.Equal(1, g.grauSaida(1));
        }

    [Fact]
    public void ExisteAdjacencia_DeveRetornarTrueQuandoHaAresta()
        {
            var g = new Lista(3);

            g.addAresta(0, 2, 10);

            Assert.True(g.existeAdjacencia(0, 2));
            Assert.False(g.existeAdjacencia(2, 0));
        }

    [Fact]
    public void SubstituirPeso_DeveAlterarPesoDaAresta()
        {
            var g = new Lista(3);
            var a = new Aresta(0, 1, 5);

            var nova = g.substituirPeso(a, 9);

            Assert.Equal(9, nova.peso);
        }

    [Fact]
    public void SubstituirVertice_DeveTrocarVerticesNasListasEArestas()
        {
            var g = new Lista(3);

            // 0->1 e 2->0
            g.addAresta(0, 1, 1);
            g.addAresta(2, 0, 2);

            Assert.True(g.existeAdjacencia(0, 1));
            Assert.True(g.existeAdjacencia(2, 0));

            g.substituirVertice(0, 2);

            // Agora, 0 e 2 devem trocar "identidade" de vértice.
            Assert.False(g.existeAdjacencia(0, 1));
            Assert.False(g.existeAdjacencia(2, 0));

            Assert.True(g.existeAdjacencia(2, 1), "Aresta 0->1 deve virar 2->1.");
            Assert.True(g.existeAdjacencia(0, 2), "Aresta 2->0 deve virar 0->2.");
        }

    [Fact]
    public void Vizinhos_DeveRetornarVerticesQueApontamParaV()
        {
            var g = new Lista(4);

            g.addAresta(0, 1, 1);
            g.addAresta(2, 1, 2);

            var viz = g.vizinhos(1);

            // vizinhos(v) percorre dados[v] e adiciona a.V (origem)
            var expected = new[] { 0, 2 };
            Assert.Equal(expected.Length, viz.Length);
            foreach (var v in expected) Assert.Contains(v, viz);
        }

    [Fact]
    public void Vizinhos_DeveRetornarArrayVazioQuandoNaoHaArestas()
        {
            var g = new Lista(3);

            var viz = g.vizinhos(1);

            Assert.NotNull(viz);
            Assert.Empty(viz);
        }

    [Fact]
    public void ToString_DeveGerarRepresentacaoDaLista()
        {
            var g = new Lista(2);

            // 0->1 com peso 5
            g.addAresta(0, 1, 5);

            // toString percorre índices (i+1) e imprime arestas daquele índice
            var texto = g.toString();

            var expected =
                "|1| --x" + Environment.NewLine +
                "|2| -[5]-> |1| --x" + Environment.NewLine;

            Assert.Equal(expected, texto);
        }
}
