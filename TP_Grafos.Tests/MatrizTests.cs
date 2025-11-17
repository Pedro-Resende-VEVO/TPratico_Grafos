using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_Grafos;

namespace TP_Grafos.Tests
{
    [TestClass]
    public class MatrizTests
    {
        [TestMethod]
        public void AddAresta_IndiceOcupado_DeveRetornarCorretamente()
        {
            var g = new Matriz(3);

            g.addAresta(0, 1, 10);

            Assert.IsTrue(g.indiceOcupado(0, 1), "Deveria haver uma aresta entre 0 e 1.");
            Assert.IsFalse(g.indiceOcupado(1, 2), "Não deveria haver uma aresta entre 1 e 2.");
        }

        [TestMethod]
        public void ArestasAdjacentes_DeveRetornarArestasDaMesmaLinhaExcetoOriginal()
        {
            var g = new Matriz(4);

            // Linha 0: 0->1 (10), 0->2 (20)
            g.addAresta(0, 1, 10);
            g.addAresta(0, 2, 20);

            var arestaBase = new Aresta(0, 1, 10);

            var adj = g.arestasAdjacentes(arestaBase);

            Assert.AreEqual(1, adj.Length, "Deveria haver uma única aresta adjacente na mesma linha.");
            Assert.AreEqual(0, adj[0].V);
            Assert.AreEqual(2, adj[0].W);
            Assert.AreEqual(20, adj[0].peso);
        }

        [TestMethod]
        public void VerticesAdjacentes_DeveRetornarVerticesQuePossuemArestasParaV()
        {
            var g = new Matriz(4);

            // 1->0 e 2->0
            g.addAresta(1, 0, 5);
            g.addAresta(2, 0, 7);

            var adj = g.verticesAdjacentes(0);

            CollectionAssert.AreEquivalent(
                new[] { 2, 3 }, // i+1 (1->0, 2->0)
                adj,
                "Vertices adjacentes devem ser 2 e 3.");
        }

        [TestMethod]
        public void ArestasIncidentes_DeveRetornarArestasQueChegamEmV()
        {
            var g = new Matriz(3);

            g.addAresta(1, 0, 5);
            g.addAresta(2, 0, 10);
            g.addAresta(2, 1, 3);

            var incidentes = g.arestasIncidentes(0);

            Assert.AreEqual(2, incidentes.Length);
            Assert.IsTrue(Array.Exists(incidentes, a => a.V == 1 && a.W == 0 && a.peso == 5));
            Assert.IsTrue(Array.Exists(incidentes, a => a.V == 2 && a.W == 0 && a.peso == 10));
        }

        [TestMethod]
        public void VerticesIncidentes_DeveRetornarVerticesDaArestaComUmBase()
        {
            var a = new Aresta(1, 2, 10);
            var g = new Matriz(3);

            var vertices = g.verticesIncidentes(a);

            CollectionAssert.AreEqual(new[] { 2, 3 }, vertices);
        }

        [TestMethod]
        public void GrauEntradaESaida_DevemSerCalculadosCorretamente()
        {
            var g = new Matriz(4);

            // 0->1, 2->1, 1->3
            g.addAresta(0, 1, 1);
            g.addAresta(2, 1, 2);
            g.addAresta(1, 3, 3);

            Assert.AreEqual(2, g.grauEntrada(1), "Vértice 1 deve ter grau de entrada 2.");
            Assert.AreEqual(1, g.grauSaida(1), "Vértice 1 deve ter grau de saída 1.");
            Assert.AreEqual(1, g.grauSaida(0), "Vértice 0 deve ter grau de saída 1.");
            Assert.AreEqual(0, g.grauEntrada(0), "Vértice 0 deve ter grau de entrada 0.");
        }

        [TestMethod]
        public void ExisteAdjacencia_DeveRetornarTrueOuFalseConformeAresta()
        {
            var g = new Matriz(3);
            g.addAresta(0, 2, 7);

            Assert.IsTrue(g.existeAdjacencia(0, 2));
            Assert.IsFalse(g.existeAdjacencia(2, 0));
        }

        [TestMethod]
        public void SubstituirPeso_DeveAlterarPesoNaArestaENaMatriz()
        {
            var g = new Matriz(3);
            var a = new Aresta(0, 1, 5);
            g.addAresta(0, 1, 5);

            var nova = g.substituirPeso(a, 9);

            Assert.AreEqual(9, nova.peso);
            Assert.IsTrue(g.existeAdjacencia(0, 1));
            // grauSaida continua 1, mas o peso muda; apenas garantimos que a aresta ainda existe
            Assert.AreEqual(1, g.grauSaida(0));
        }

        [TestMethod]
        public void SubstituirVertice_DeveMoverArestasEntreVertices()
        {
            var g = new Matriz(3);

            // 0->1 e 2->0
            g.addAresta(0, 1, 1);
            g.addAresta(2, 0, 2);

            Assert.IsTrue(g.existeAdjacencia(0, 1));
            Assert.IsTrue(g.existeAdjacencia(2, 0));

            g.substituirVertice(0, 2);

            // Depois da troca, a lógica da função faz com que:
            // 0 e 2 "troquem de lugar".
            Assert.IsFalse(g.existeAdjacencia(0, 1));
            Assert.IsFalse(g.existeAdjacencia(2, 0));

            // Agora deve existir 2->1 (anteriormente 0->1)
            // e 0->2 (anteriormente 2->0).
            Assert.IsTrue(g.existeAdjacencia(2, 1), "Aresta 0->1 deve virar 2->1.");
            Assert.IsTrue(g.existeAdjacencia(0, 2), "Aresta 2->0 deve virar 0->2.");
        }

        [TestMethod]
        public void Vizinhos_DeveRetornarVerticesAlcancadosPorV()
        {
            var g = new Matriz(4);

            g.addAresta(1, 2, 3);
            g.addAresta(1, 3, 4);

            var viz = g.vizinhos(1);

            CollectionAssert.AreEquivalent(new[] { 2, 3 }, viz);
        }

        [TestMethod]
        public void Vizinhos_DeveRetornarArrayVazioQuandoNaoHaArestas()
        {
            var g = new Matriz(3);

            var viz = g.vizinhos(1);

            Assert.IsNotNull(viz);
            Assert.AreEqual(0, viz.Length);
        }

        [TestMethod]
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

            Assert.AreEqual(expected, texto);
        }
    }
}
