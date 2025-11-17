using TP_Grafos;
using Xunit;

namespace Tests;

public class FloydWarshalTest
{
    [Fact]
    public void FloydWarshal_DeveCalcularDistanciasCorretas()
    {
        // Arrange
        Matriz g = new Matriz(4);

        g.addAresta(0, 1, 3);
        g.addAresta(0, 2, 8);
        g.addAresta(1, 2, 2);
        g.addAresta(2, 3, 1);
        g.addAresta(1, 3, 10);

        FloydWarshal fw = new FloydWarshal(g);

        // Act
        int[,] dist = fw.execucao(0);

        // Assert (valores esperados para caminho mínimo)
        Assert.Equal(0, dist[0, 0]);
        Assert.Equal(3, dist[0, 1]);
        Assert.Equal(5, dist[0, 2]);
        Assert.Equal(6, dist[0, 3]);

        Assert.Equal(0, dist[1, 1]);
        Assert.Equal(2, dist[1, 2]);
        Assert.Equal(3, dist[1, 3]);

        Assert.Equal(1, dist[2, 3]);
    }
}
