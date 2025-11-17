using System;
using System.Linq;
using TP_Grafos;
using Xunit;

namespace Tests;

public class MatrizTest
{
    [Fact]
    public void AddAresta_IndiceOcupado_DeveRetornarCorretamente()
    {
        var g = new Matriz(3);
        g.addAresta(0, 1, 10);
        Assert.True(g.indiceOcupado(0, 1));
        Assert.False(g.indiceOcupado(1, 2));
    }

    [Fact]
    public void ArestasAdjacentes_DeveRetornarArestasDaMesmaLinhaExcetoOriginal()
    {
        var g = new Matriz(4);
        g.addAresta(0, 1, 10);
        g.addAresta(0, 2, 20);
        var arestaBase = new Aresta(0, 1, 10);
        var adj = g.arestasAdjacentes(arestaBase);
        Assert.Single(adj);
        Assert.Equal(0, adj[0].V);
        Assert.Equal(2, adj[0].W);
        Assert.Equal(20, adj[0].peso);
    }

    [Fact]
    public void VerticesAdjacentes_DeveRetornarVerticesQuePossuemArestasParaV()
    {
        var g = new Matriz(4);
        g.addAresta(1, 0, 5);
        g.addAresta(2, 0, 7);
        var adj = g.verticesAdjacentes(0);
        var expected = new[] { 2, 3 };
        Assert.Equal(expected.Length, adj.Length);
        foreach (var v in expected) Assert.Contains(v, adj);
    }

    [Fact]
    public void ArestasIncidentes_DeveRetornarArestasQueChegamEmV()
    {
        var g = new Matriz(3);
        g.addAresta(1, 0, 5);
        g.addAresta(2, 0, 10);
        g.addAresta(2, 1, 3);
        var incidentes = g.arestasIncidentes(0);
        Assert.Equal(2, incidentes.Length);
        Assert.Contains(incidentes, a => a.V == 1 && a.W == 0 && a.peso == 5);
        Assert.Contains(incidentes, a => a.V == 2 && a.W == 0 && a.peso == 10);
    }

    [Fact]
    public void VerticesIncidentes_DeveRetornarVerticesDaArestaComUmBase()
    {
        var a = new Aresta(1, 2, 10);
        var g = new Matriz(3);
        var vertices = g.verticesIncidentes(a);
        Assert.Equal(new[] { 2, 3 }, vertices);
    }

    [Fact]
    public void GrauEntradaESaida_DevemSerCalculadosCorretamente()
    {
        var g = new Matriz(4);
        g.addAresta(0, 1, 1);
        g.addAresta(2, 1, 2);
        g.addAresta(1, 3, 3);
        Assert.Equal(2, g.grauEntrada(1));
        Assert.Equal(1, g.grauSaida(1));
        Assert.Equal(1, g.grauSaida(0));
        Assert.Equal(0, g.grauEntrada(0));
    }

    [Fact]
    public void ExisteAdjacencia_DeveRetornarTrueOuFalseConformeAresta()
    {
        var g = new Matriz(3);
        g.addAresta(0, 2, 7);
        Assert.True(g.existeAdjacencia(0, 2));
        Assert.False(g.existeAdjacencia(2, 0));
    }

    [Fact]
    public void SubstituirPeso_DeveAlterarPesoNaArestaENaMatriz()
    {
        var g = new Matriz(3);
        var a = new Aresta(0, 1, 5);
        g.addAresta(0, 1, 5);
        var nova = g.substituirPeso(a, 9);
        Assert.Equal(9, nova.peso);
        Assert.True(g.existeAdjacencia(0, 1));
        Assert.Equal(1, g.grauSaida(0));
    }

    [Fact]
    public void SubstituirVertice_DeveMoverArestasEntreVertices()
    {
        var g = new Matriz(3);
        g.addAresta(0, 1, 1);
        g.addAresta(2, 0, 2);
        Assert.True(g.existeAdjacencia(0, 1));
        Assert.True(g.existeAdjacencia(2, 0));
        g.substituirVertice(0, 2);
        Assert.False(g.existeAdjacencia(0, 1));
        Assert.False(g.existeAdjacencia(2, 0));
        Assert.True(g.existeAdjacencia(2, 1));
        Assert.True(g.existeAdjacencia(0, 2));
    }

    [Fact]
    public void Vizinhos_DeveRetornarVerticesAlcancadosPorV()
    {
        var g = new Matriz(4);
        g.addAresta(1, 2, 3);
        g.addAresta(1, 3, 4);
        var viz = g.vizinhos(1);
        var expected = new[] { 2, 3 };
        Assert.Equal(expected.Length, viz.Length);
        foreach (var v in expected) Assert.Contains(v, viz);
    }

    [Fact]
    public void Vizinhos_DeveRetornarArrayVazioQuandoNaoHaArestas()
    {
        var g = new Matriz(3);
        var viz = g.vizinhos(1);
        Assert.NotNull(viz);
        Assert.Empty(viz);
    }

    [Fact]
    public void ToString_DeveGerarMatrizCorreta()
    {
        var g = new Matriz(2);
        g.addAresta(0, 1, 5);
        g.addAresta(1, 0, 7);
        var texto = g.toString();
        var expected =
            "  1 2 " + Environment.NewLine +
            "1|0|5|" + Environment.NewLine +
            "2|7|0|" + Environment.NewLine;
        Assert.Equal(expected, texto);
    }
}
