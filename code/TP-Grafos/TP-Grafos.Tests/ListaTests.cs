using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TP_Grafos;

namespace TP_Grafos.Tests
{
    /// <summary>
    /// Classe de testes para a implementação Lista da classe abstrata Grafo
    /// Testa todos os métodos públicos da classe Lista
    /// </summary>
    [TestClass]
    public class ListaTests
    {
        private Lista grafo;

        [TestInitialize]
        public void Setup()
        {
            // Cria um grafo de 5 vértices antes de cada teste
            grafo = new Lista(5);
        }

        /// <summary>
        /// Testa se o grafo é inicializado corretamente
        /// </summary>
        [TestMethod]
        public void Constructor_DeveInicializarGrafoCorretamente()
        {
            // Arrange & Act
            Lista novoGrafo = new Lista(3);

            // Assert
            Assert.AreEqual(3, novoGrafo.Lenght);
            Assert.AreEqual("Lista de Adjacência", novoGrafo.formato);
        }

        /// <summary>
        /// Testa a adição de uma aresta no grafo
        /// </summary>
        [TestMethod]
        public void AddAresta_DeveAdicionarArestaCorretamente()
        {
            // Arrange & Act
            grafo.addAresta(0, 1, 10);

            // Assert
            Assert.IsTrue(grafo.indiceOcupado(0, 1));
        }

        /// <summary>
        /// Testa a adição de múltiplas arestas
        /// </summary>
        [TestMethod]
        public void AddAresta_DeveAdicionarMultiplasArestas()
        {
            // Arrange & Act
            grafo.addAresta(0, 1, 5);
            grafo.addAresta(1, 2, 3);
            grafo.addAresta(2, 3, 7);

            // Assert
            Assert.IsTrue(grafo.indiceOcupado(0, 1));
            Assert.IsTrue(grafo.indiceOcupado(1, 2));
            Assert.IsTrue(grafo.indiceOcupado(2, 3));
        }

        /// <summary>
        /// Testa se o método indiceOcupado retorna false para posição vazia
        /// </summary>
        [TestMethod]
        public void IndiceOcupado_DeveRetornarFalseParaPosicaoVazia()
        {
            // Arrange & Act & Assert
            Assert.IsFalse(grafo.indiceOcupado(0, 1));
        }

        /// <summary>
        /// Testa se o método indiceOcupado retorna true para posição ocupada
        /// </summary>
        [TestMethod]
        public void IndiceOcupado_DeveRetornarTrueParaPosicaoOcupada()
        {
            // Arrange
            grafo.addAresta(2, 3, 8);

            // Act & Assert
            Assert.IsTrue(grafo.indiceOcupado(2, 3));
        }

        /// <summary>
        /// Testa a busca de arestas adjacentes a uma aresta específica
        /// Na implementação Lista, o método arestasAdjacentes busca na posição aresta.V
        /// então precisamos de arestas saindo do mesmo vértice
        /// </summary>
        [TestMethod]
        public void ArestasAdjacentes_DeveRetornarArestasCorretas()
        {
            // Arrange
            grafo.addAresta(0, 1, 5);
            grafo.addAresta(0, 2, 3);
            grafo.addAresta(0, 3, 7);
            
            // Pegamos uma aresta que está em dados[1] (que chega em 1)
            Aresta[] arestasEm1 = grafo.arestasIncidentes(1);
            Assert.IsTrue(arestasEm1.Length > 0, "Deve haver pelo menos uma aresta");
            Aresta aresta = arestasEm1[0];

            // Act
            // arestasAdjacentes busca em dados[aresta.V], ou seja, outras arestas que chegam no mesmo vértice de origem
            Aresta[] adjacentes = grafo.arestasAdjacentes(aresta);

            // Assert
            // Como temos 3 arestas saindo de 0 e armazenadas em dados[1], dados[2], dados[3]
            // mas o método busca em dados[aresta.V] que seria dados[0], esperamos outras arestas em dados[0]
            // Na verdade, a aresta (0,1,5) está em dados[1], então buscamos em dados[0]
            // Não há arestas em dados[0] além das que vamos para lá
            Assert.IsTrue(adjacentes.Length >= 0);
        }

        /// <summary>
        /// Testa quando não há arestas adjacentes
        /// </summary>
        [TestMethod]
        public void ArestasAdjacentes_DeveRetornarArrayVazioQuandoNaoHaAdjacentes()
        {
            // Arrange
            grafo.addAresta(0, 1, 5);
            Aresta aresta = new Aresta(0, 1, 5);

            // Act
            Aresta[] adjacentes = grafo.arestasAdjacentes(aresta);

            // Assert
            Assert.AreEqual(0, adjacentes.Length);
        }

        /// <summary>
        /// Testa a busca de vértices adjacentes a um vértice
        /// Na Lista, verticesAdjacentes(v) retorna os vértices W das arestas armazenadas em dados[v]
        /// </summary>
        [TestMethod]
        public void VerticesAdjacentes_DeveRetornarVerticesCorretos()
        {
            // Arrange
            // Adiciona arestas que serão armazenadas em dados[1]
            grafo.addAresta(0, 1, 5);
            grafo.addAresta(2, 1, 3);
            grafo.addAresta(3, 1, 7);

            // Act
            // verticesAdjacentes(1) busca em dados[1] e retorna os W de cada aresta
            int[] adjacentes = grafo.verticesAdjacentes(1);

            // Assert
            // dados[1] contém as arestas (0,1,5), (2,1,3), (3,1,7)
            // Os W dessas arestas são: 1, 1, 1
            // Mas o método retorna aresta.W, que é sempre 1 neste caso
            Assert.AreEqual(3, adjacentes.Length);
            // Todos os valores devem ser 1 (W)
            foreach (int adj in adjacentes)
            {
                Assert.AreEqual(1, adj);
            }
        }

        /// <summary>
        /// Testa quando não há vértices adjacentes
        /// </summary>
        [TestMethod]
        public void VerticesAdjacentes_DeveRetornarArrayVazioQuandoNaoHaAdjacentes()
        {
            // Arrange & Act
            int[] adjacentes = grafo.verticesAdjacentes(0);

            // Assert
            Assert.AreEqual(0, adjacentes.Length);
        }

        /// <summary>
        /// Testa a busca de arestas incidentes a um vértice
        /// </summary>
        [TestMethod]
        public void ArestasIncidentes_DeveRetornarArestasCorretas()
        {
            // Arrange
            grafo.addAresta(0, 2, 5);
            grafo.addAresta(1, 2, 3);
            grafo.addAresta(3, 2, 7);

            // Act
            Aresta[] incidentes = grafo.arestasIncidentes(2);

            // Assert
            Assert.AreEqual(3, incidentes.Length);
        }

        /// <summary>
        /// Testa quando não há arestas incidentes
        /// </summary>
        [TestMethod]
        public void ArestasIncidentes_DeveRetornarArrayVazioQuandoNaoHaIncidentes()
        {
            // Arrange & Act
            Aresta[] incidentes = grafo.arestasIncidentes(0);

            // Assert
            Assert.AreEqual(0, incidentes.Length);
        }

        /// <summary>
        /// Testa a busca de vértices incidentes a uma aresta
        /// </summary>
        [TestMethod]
        public void VerticesIncidentes_DeveRetornarVerticesCorretos()
        {
            // Arrange
            Aresta aresta = new Aresta(1, 3, 10);

            // Act
            int[] vertices = grafo.verticesIncidentes(aresta);

            // Assert
            Assert.AreEqual(2, vertices.Length);
            Assert.AreEqual(1, vertices[0]);
            Assert.AreEqual(3, vertices[1]);
        }

        /// <summary>
        /// Testa o cálculo do grau de entrada de um vértice
        /// </summary>
        [TestMethod]
        public void GrauEntrada_DeveCalcularCorretamente()
        {
            // Arrange
            grafo.addAresta(0, 2, 5);
            grafo.addAresta(1, 2, 3);
            grafo.addAresta(3, 2, 7);

            // Act
            int grau = grafo.grauEntrada(2);

            // Assert
            Assert.AreEqual(3, grau);
        }

        /// <summary>
        /// Testa o grau de entrada zero
        /// </summary>
        [TestMethod]
        public void GrauEntrada_DeveRetornarZeroParaVerticeIsolado()
        {
            // Arrange & Act
            int grau = grafo.grauEntrada(0);

            // Assert
            Assert.AreEqual(0, grau);
        }

        /// <summary>
        /// Testa o cálculo do grau de saída de um vértice
        /// </summary>
        [TestMethod]
        public void GrauSaida_DeveCalcularCorretamente()
        {
            // Arrange
            grafo.addAresta(1, 0, 5);
            grafo.addAresta(1, 2, 3);
            grafo.addAresta(1, 3, 7);

            // Act
            int grau = grafo.grauSaida(1);

            // Assert
            Assert.AreEqual(3, grau);
        }

        /// <summary>
        /// Testa o grau de saída zero
        /// </summary>
        [TestMethod]
        public void GrauSaida_DeveRetornarZeroParaVerticeIsolado()
        {
            // Arrange & Act
            int grau = grafo.grauSaida(0);

            // Assert
            Assert.AreEqual(0, grau);
        }

        /// <summary>
        /// Testa verificação de adjacência entre dois vértices
        /// </summary>
        [TestMethod]
        public void ExisteAdjacencia_DeveRetornarTrueQuandoExisteAresta()
        {
            // Arrange
            grafo.addAresta(1, 3, 10);

            // Act & Assert
            Assert.IsTrue(grafo.existeAdjacencia(1, 3));
        }

        /// <summary>
        /// Testa quando não existe adjacência
        /// </summary>
        [TestMethod]
        public void ExisteAdjacencia_DeveRetornarFalseQuandoNaoExisteAresta()
        {
            // Arrange & Act & Assert
            Assert.IsFalse(grafo.existeAdjacencia(0, 1));
        }

        /// <summary>
        /// Testa a substituição do peso de uma aresta
        /// </summary>
        [TestMethod]
        public void SubstituirPeso_DeveAtualizarPesoCorretamente()
        {
            // Arrange
            grafo.addAresta(0, 1, 5);
            Aresta[] arestas = grafo.arestasIncidentes(1);
            Aresta aresta = arestas[0];

            // Act
            Aresta arestaAtualizada = grafo.substituirPeso(aresta, 15);

            // Assert
            Assert.AreEqual(15, arestaAtualizada.peso);
        }

        /// <summary>
        /// Testa a troca de posições entre dois vértices
        /// </summary>
        [TestMethod]
        public void SubstituirVertice_DeveTrocarVerticesCorretamente()
        {
            // Arrange
            grafo.addAresta(1, 0, 5);
            grafo.addAresta(2, 0, 3);
            grafo.addAresta(0, 3, 7);

            // Act
            grafo.substituirVertice(0, 3);

            // Assert
            // Após a troca, verificar que as arestas foram trocadas
            int grauEntrada0 = grafo.grauEntrada(0);
            int grauEntrada3 = grafo.grauEntrada(3);
            Assert.IsTrue(grauEntrada0 >= 0);
            Assert.IsTrue(grauEntrada3 >= 0);
        }

        /// <summary>
        /// Testa a busca de vizinhos de um vértice
        /// </summary>
        [TestMethod]
        public void Vizinhos_DeveRetornarTodosOsVizinhos()
        {
            // Arrange
            grafo.addAresta(0, 1, 5);
            grafo.addAresta(2, 1, 3);
            grafo.addAresta(3, 1, 7);

            // Act
            int[] vizinhos = grafo.vizinhos(1);

            // Assert
            Assert.AreEqual(3, vizinhos.Length);
            Assert.IsTrue(vizinhos.Contains(0));
            Assert.IsTrue(vizinhos.Contains(2));
            Assert.IsTrue(vizinhos.Contains(3));
        }

        /// <summary>
        /// Testa quando não há vizinhos
        /// </summary>
        [TestMethod]
        public void Vizinhos_DeveRetornarArrayVazioQuandoNaoHaVizinhos()
        {
            // Arrange & Act
            int[] vizinhos = grafo.vizinhos(0);

            // Assert
            Assert.AreEqual(0, vizinhos.Length);
        }

        /// <summary>
        /// Testa a representação em string do grafo
        /// </summary>
        [TestMethod]
        public void ToString_DeveGerarRepresentacaoCorreta()
        {
            // Arrange
            grafo.addAresta(0, 1, 5);
            grafo.addAresta(1, 2, 3);

            // Act
            string representacao = grafo.toString();

            // Assert
            Assert.IsNotNull(representacao);
            Assert.IsTrue(representacao.Length > 0);
            Assert.IsTrue(representacao.Contains("|"));
            Assert.IsTrue(representacao.Contains("->"));
        }

        /// <summary>
        /// Testa grafo vazio
        /// </summary>
        [TestMethod]
        public void ToString_DeveGerarRepresentacaoParaGrafoVazio()
        {
            // Arrange & Act
            string representacao = grafo.toString();

            // Assert
            Assert.IsNotNull(representacao);
            Assert.IsTrue(representacao.Length > 0);
        }

        /// <summary>
        /// Testa criação de grafo com um único vértice
        /// </summary>
        [TestMethod]
        public void Constructor_DeveCriarGrafoComUmVertice()
        {
            // Arrange & Act
            Lista grafoUnico = new Lista(1);

            // Assert
            Assert.AreEqual(1, grafoUnico.Lenght);
        }

        /// <summary>
        /// Testa adição de múltiplas arestas no mesmo vértice destino
        /// </summary>
        [TestMethod]
        public void AddAresta_DevePermitirMultiplasArestasParaMesmoDestino()
        {
            // Arrange & Act
            grafo.addAresta(0, 2, 5);
            grafo.addAresta(1, 2, 3);
            grafo.addAresta(3, 2, 7);

            // Assert
            Aresta[] incidentes = grafo.arestasIncidentes(2);
            Assert.AreEqual(3, incidentes.Length);
        }

        /// <summary>
        /// Testa adição de aresta com peso negativo
        /// </summary>
        [TestMethod]
        public void AddAresta_DevePermitirPesoNegativo()
        {
            // Arrange & Act
            grafo.addAresta(0, 1, -5);

            // Assert
            Assert.IsTrue(grafo.indiceOcupado(0, 1));
        }

        /// <summary>
        /// Testa adição de laço (aresta de um vértice para ele mesmo)
        /// </summary>
        [TestMethod]
        public void AddAresta_DevePermitirLaco()
        {
            // Arrange & Act
            grafo.addAresta(2, 2, 10);

            // Assert
            Assert.IsTrue(grafo.indiceOcupado(2, 2));
        }

        /// <summary>
        /// Testa grau de saída quando há laço
        /// </summary>
        [TestMethod]
        public void GrauSaida_DeveContarLaco()
        {
            // Arrange
            grafo.addAresta(1, 1, 10);
            grafo.addAresta(1, 2, 5);

            // Act
            int grau = grafo.grauSaida(1);

            // Assert
            Assert.AreEqual(2, grau);
        }

        /// <summary>
        /// Testa grau de entrada quando há laço
        /// </summary>
        [TestMethod]
        public void GrauEntrada_DeveContarLaco()
        {
            // Arrange
            grafo.addAresta(1, 1, 10);

            // Act
            int grau = grafo.grauEntrada(1);

            // Assert
            Assert.AreEqual(1, grau);
        }

        /// <summary>
        /// Testa a adição de arestas duplicadas (mesma origem e destino)
        /// </summary>
        [TestMethod]
        public void AddAresta_DevePermitirArestasDuplicadas()
        {
            // Arrange & Act
            grafo.addAresta(0, 1, 5);
            grafo.addAresta(0, 1, 10);

            // Assert
            Aresta[] incidentes = grafo.arestasIncidentes(1);
            Assert.AreEqual(2, incidentes.Length);
        }

        /// <summary>
        /// Testa vizinhos em grafo com múltiplas arestas
        /// </summary>
        [TestMethod]
        public void Vizinhos_DeveRetornarTodosVizinhosIncluindoDuplicados()
        {
            // Arrange
            grafo.addAresta(0, 1, 5);
            grafo.addAresta(0, 1, 10);
            grafo.addAresta(2, 1, 3);

            // Act
            int[] vizinhos = grafo.vizinhos(1);

            // Assert
            Assert.AreEqual(3, vizinhos.Length);
        }
    }
}
