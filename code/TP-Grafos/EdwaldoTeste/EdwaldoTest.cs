using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_Grafos;

namespace EdwaldoTeste
{
    [TestClass]
    public class EdwaldoTest
    {
        private Edwaldo edwaldo;

        [TestInitialize]
        public void Setup()
        {
            edwaldo = new Edwaldo();
        }


        [TestMethod]
        public void DefinirGrafo_DensidadeAlta_UsaMatriz()
        {
            int N = 10;
            int M = 60; 

            edwaldo.definirGrafo(N, M);

            Assert.AreEqual("grafo no formato de Matriz de Adjacência", edwaldo.formatoString());
        }

        [TestMethod]
        public void DefinirGrafo_DensidadeBaixa_UsaLista()
        {
            int N = 10;
            int M = 10; 

            edwaldo.definirGrafo(N, M);

            Assert.AreEqual("grafo no formato de Lista de Adjacência", edwaldo.formatoString());
        }


        [TestMethod]
        public void AddAresta_Manual_InsereAresta()
        {
            edwaldo.definirGrafo(5, 5);

            edwaldo.addAresta(0, 1, 10);

            var resultado = edwaldo.adjacencia(0, 1);

            Assert.AreEqual("EXISTE a adjacência entre os vértices", resultado);
        }



        [TestMethod]
        public void Adjacencia_Existente_RetornaMensagemCorreta()
        {
            edwaldo.definirGrafo(5, 5);
            edwaldo.addAresta(3, 4, 8);

            var result = edwaldo.adjacencia(3, 4);

            Assert.AreEqual("EXISTE a adjacência entre os vértices", result);
        }

        [TestMethod]
        public void Adjacencia_Inexistente_RetornaMensagemCorreta()
        {
            edwaldo.definirGrafo(5, 5);

            var result = edwaldo.adjacencia(1, 2);

            Assert.AreEqual("NÃO EXISTE tal adjacência", result);
        }

        [TestMethod]
        public void Grau_EntradaESaida_RetornaFormatado()
        {
            edwaldo.definirGrafo(5, 5);

            edwaldo.addAresta(0, 1, 5); 
            edwaldo.addAresta(2, 0, 7); 

            var res = edwaldo.grau(0);

            Assert.AreEqual("Grau de Entrada: 1\nGrau de Saída: 1", res);
        }


        [TestMethod]
        public void BuscaEmLargura_ExecutaSemErro()
        {
            edwaldo.definirGrafo(5, 10);
            edwaldo.addAresta(0, 1, 10);
            edwaldo.addAresta(0, 2, 10);

            var r = edwaldo.buscaEmLargura(0);

            Assert.IsNotNull(r);
        }

        [TestMethod]
        public void BuscaEmProfundidade_ExecutaSemErro()
        {
            edwaldo.definirGrafo(4, 5);
            edwaldo.addAresta(0, 1, 3);
            edwaldo.addAresta(1, 2, 6);

            var r = edwaldo.buscaEmProfundidade(0);

            Assert.IsNotNull(r);
        }



        [TestMethod]
        public void Dijkstra_ExecutaCorretamente()
        {
            Edwaldo e = new Edwaldo();
            e.definirGrafo(5, 11);

            e.addAresta(0, 1, 2);
            e.addAresta(1, 2, 2);
            e.addAresta(2, 3, 2);
            e.addAresta(3, 4, 2);

            string r = e.Dijkstra(0, 4);

            Assert.AreEqual("0 -> 1 -> 2 -> 3 -> 4", r);
        }



        [TestMethod]
        public void FloydWarshal_ExecutaSemErro()
        {
            edwaldo.definirGrafo(3, 3);
            edwaldo.addAresta(0, 1, 2);
            edwaldo.addAresta(1, 2, 2);

            var r = edwaldo.FloydWarshal(0);

            Assert.IsNotNull(r);
        }

        [TestMethod]
        public void VerticeDestinoValido_ValorDentro_RetornaTrue()
        {
            edwaldo.definirGrafo(5, 5);

            bool r = edwaldo.verticeDestinoValido(3);

            Assert.IsTrue(r);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void VerticeDestinoValido_ValorFora_LancaExcecao()
        {
            edwaldo.definirGrafo(5, 5);

            edwaldo.verticeDestinoValido(10);
        }

        [TestMethod]
        public void QntVerticeGrafoValida_ValorCorreto_RetornaTrue()
        {
            bool r = edwaldo.qntVerticeGrafoValida(4);

            Assert.IsTrue(r);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void QntVerticeGrafoValida_ValorZero_LancaExcecao()
        {
            edwaldo.qntVerticeGrafoValida(0);
        }

        [TestMethod]
        public void QntArestaGrafoValida_ValorCorreto_RetornaTrue()
        {
            bool r = edwaldo.qntArestaGrafoValida(5, 3);

            Assert.IsTrue(r);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void QntArestaGrafoValida_ValorMaiorQueN_LancaExcecao()
        {
            edwaldo.qntArestaGrafoValida(5, 8);
        }
    }
}
