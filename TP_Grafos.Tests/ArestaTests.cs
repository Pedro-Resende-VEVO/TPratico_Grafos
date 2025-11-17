using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_Grafos;

namespace TP_Grafos.Tests
{
    [TestClass]
    public class ArestaTests
    {
        [TestMethod]
        public void Construtor_DeveInicializarPropriedades()
        {
            // Arrange
            int v = 2;
            int w = 5;
            int peso = 10;

            // Act
            Aresta aresta = new Aresta(v, w, peso);

            // Assert
            Assert.AreEqual(v, aresta.V);
            Assert.AreEqual(w, aresta.W);
            Assert.AreEqual(peso, aresta.peso);
        }

        [TestMethod]
        public void ToString_DeveRetornarFormatoCorreto()
        {
            // Arrange
            Aresta aresta = new Aresta(0, 2, 7);

            // Act
            string resultado = aresta.toString();

            // Assert
            Assert.AreEqual("(1) -7-> (3)", resultado);
        }

        [TestMethod]
        public void Propriedades_PodemSerAlteradas()
        {
            // Arrange
            Aresta aresta = new Aresta(1, 1, 1);

            // Act
            aresta.V = 3;
            aresta.W = 4;
            aresta.peso = 9;

            // Assert
            Assert.AreEqual(3, aresta.V);
            Assert.AreEqual(4, aresta.W);
            Assert.AreEqual(9, aresta.peso);
        }
    }
}
