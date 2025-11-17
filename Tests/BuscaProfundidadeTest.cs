using TP_Grafos;

namespace Tests;

public class BuscaProfundidadeTest
{
    [Fact]
    public void Execucao_ComGrafoSimples_NaoLancaExcecao()
    {

        Grafo grafo = new Lista(5);
        grafo.addAresta(0, 1, 1);
        grafo.addAresta(0, 2, 1);
        grafo.addAresta(1, 3, 1);
        grafo.addAresta(2, 4, 1);

        BuscaEmProfundidade busca = new BuscaEmProfundidade(grafo);

        string resultado = busca.execucao(0);

        Assert.NotNull(resultado);
        Assert.Equal("", resultado);
    }

    [Fact]
    public void Execucao_ComGrafoDesconexo_NaoLancaExcecao()
    {

        Grafo grafo = new Lista(5);

        grafo.addAresta(0, 1, 1);

        grafo.addAresta(2, 3, 1);

        BuscaEmProfundidade busca = new BuscaEmProfundidade(grafo);

        string resultado1 = busca.execucao(0);
        string resultado2 = busca.execucao(2);

        Assert.NotNull(resultado1);
        Assert.NotNull(resultado2);
        Assert.Equal("", resultado1);
        Assert.Equal("", resultado2);
    }

    [Fact]
    public void Execucao_ComGrafoVazio_NaoLancaExcecao()
    {

        Grafo grafo = new Lista(0);
        BuscaEmProfundidade busca = new BuscaEmProfundidade(grafo);

        Assert.NotNull(busca);
    }

    [Fact]
    public void Execucao_ComVerticeInexistente_LancaExcecao()
    {

        Grafo grafo = new Lista(3);
        grafo.addAresta(0, 1, 1);
        BuscaEmProfundidade busca = new BuscaEmProfundidade(grafo);


        Assert.Throws<IndexOutOfRangeException>(() => busca.execucao(5));
    }

    [Fact]
    public void Execucao_ComGrafoCiclico_NaoLancaExcecao()
    {
        Grafo grafo = new Lista(4);
        grafo.addAresta(0, 1, 1);
        grafo.addAresta(1, 2, 1);
        grafo.addAresta(2, 0, 1);
        grafo.addAresta(2, 3, 1);

        BuscaEmProfundidade busca = new BuscaEmProfundidade(grafo);

        string resultado = busca.execucao(0);

        Assert.NotNull(resultado);
        Assert.Equal("", resultado);
    }

    [Fact]
    public void Execucao_ComVerticeIsolado_NaoLancaExcecao()
    {
        Grafo grafo = new Lista(3);
        grafo.addAresta(0, 1, 1);

        BuscaEmProfundidade busca = new BuscaEmProfundidade(grafo);

        string resultado = busca.execucao(2);

        Assert.NotNull(resultado);
        Assert.Equal("", resultado);
    }

    [Fact]
    public void Execucao_ComGrafoLinear_NaoLancaExcecao()
    {
        Grafo grafo = new Lista(5);
        grafo.addAresta(0, 1, 1);
        grafo.addAresta(1, 2, 1);
        grafo.addAresta(2, 3, 1);
        grafo.addAresta(3, 4, 1);

        BuscaEmProfundidade busca = new BuscaEmProfundidade(grafo);

        string resultado = busca.execucao(0);

        Assert.NotNull(resultado);
        Assert.Equal("", resultado);
    }
}
