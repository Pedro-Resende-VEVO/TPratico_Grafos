using System;
using TP_Grafos;
using Xunit;

namespace Tests;

public class DijkstraTest
{
    private Lista BuildLista(int n, params (int v,int w,int peso)[] edges)
    {
        var g = new Lista(n);
        foreach (var e in edges)
            g.addAresta(e.v, e.w, e.peso);
        return g;
    }

    [Fact]
    public void Execucao_CaminhoLinear_RetornaSequenciaEsperada()
    {
        // 0->1, 1->2, 2->3
        var g = BuildLista(4,(0,1,1),(1,2,1),(2,3,1));
        var d = new Dijkstra(g);
        var caminho = d.execucao(0,3);
        Assert.Equal("0 -> 1 -> 2 -> 3", caminho);
    }

    [Fact]
    public void Execucao_IndiceInvalido_LancaExcecao()
    {
        var g = BuildLista(3,(0,1,1));
        var d = new Dijkstra(g);
        Assert.Throws<ArgumentOutOfRangeException>(() => d.execucao(-1,2));
        Assert.Throws<ArgumentOutOfRangeException>(() => d.execucao(0,5));
    }

    [Fact]
    public void Execucao_Inalcanavel_RetornaParcial()
    {
        // origin 0 without outgoing edges stored (only edge into 0)
        var g = BuildLista(3,(1,0,1));
        var d = new Dijkstra(g);
        var caminho = d.execucao(0,2);
        Assert.Equal("0", caminho); // não chegou ao destino
    }

    [Fact]
    public void Execucao_Ciclo_InterrompeAoDetectar()
    {
        var g = BuildLista(2,(0,1,1),(1,0,1));
        var d = new Dijkstra(g);
        var caminho = d.execucao(0,1);
        Assert.Equal("0 -> 1", caminho); // destino alcançado antes do ciclo

        // ciclo completo tentando ir de 0 para 0 via 1
        var ciclo = d.execucao(0,0);
        Assert.Equal("0", ciclo);
    }

    [Fact]
    public void Execucao_ArestaPrimeiraEscolhida_DeterminaCaminho()
    {
        // múltiplas saídas de 0: 0->2 e 0->1; ordem de coleta faz escolher a que aparece primeiro
        var g = BuildLista(4,(0,2,5),(0,1,2),(2,3,1),(1,3,1));
        var d = new Dijkstra(g);
        var caminho = d.execucao(0,3);
        Assert.Equal("0 -> 1 -> 3", caminho);
    }
}
