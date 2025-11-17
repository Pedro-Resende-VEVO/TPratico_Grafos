using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_Grafos;

namespace TP_Grafos.Tests
{
    [TestClass]
    public class FloydWarshalTests
    {
        [TestMethod]
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

            // Assert
            Assert.AreEqual(0, dist[0, 0]);
            Assert.AreEqual(3, dist[0, 1]);
            Assert.AreEqual(5, dist[0, 2]); 
            Assert.AreEqual(6, dist[0, 3]);  

            Assert.AreEqual(0, dist[1, 1]);
            Assert.AreEqual(2, dist[1, 2]);
            Assert.AreEqual(3, dist[1, 3]); 

            Assert.AreEqual(1, dist[2, 3]);
        }
    }
}
