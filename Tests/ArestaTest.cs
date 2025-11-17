using TP_Grafos;
using Xunit;

namespace Tests;

public class ArestaTest
{
    [Fact]
    public void Construtor_DeveInicializarPropriedades()
    {
        // Arrange
        int v = 2;
        int w = 5;
        int peso = 10;

        // Act
        Aresta aresta = new Aresta(v, w, peso);

        // Assert
        Assert.Equal(v, aresta.V);
        Assert.Equal(w, aresta.W);
        Assert.Equal(peso, aresta.peso);
    }

    [Fact]
    public void ToString_DeveRetornarFormatoCorreto()
    {
        // Arrange
        Aresta aresta = new Aresta(0, 2, 7);

        // Act
        string resultado = aresta.toString();

        // Assert
        Assert.Equal("(1) -7-> (3)", resultado);
    }

    [Fact]
    public void Propriedades_PodemSerAlteradas()
    {
        // Arrange
        Aresta aresta = new Aresta(1, 1, 1);

        // Act
        aresta.V = 3;
        aresta.W = 4;
        aresta.peso = 9;

        // Assert
        Assert.Equal(3, aresta.V);
        Assert.Equal(4, aresta.W);
        Assert.Equal(9, aresta.peso);
    }
    }
