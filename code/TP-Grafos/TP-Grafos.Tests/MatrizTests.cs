using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TP_Grafos;

namespace TP_Grafos.Tests
{
    /// <summary>
    /// Classe de testes para a implementação Matriz da classe abstrata Grafo
    /// Testa todos os métodos públicos da classe Matriz
    /// </summary>
    [TestClass]
    public class MatrizTests
    {
        private Matriz grafo;

        [TestInitialize]
        public void Setup()
        {
            // Cria um grafo de 5 vértices antes de cada teste
            grafo = new Matriz(5);
        }

        /// <summary>
        /// Testa se o grafo é inicializado corretamente
        /// </summary>
        [TestMethod]
        public void Constructor_DeveInicializarGrafoCorretamente()
        {
            // Arrange & Act
            Matriz novoGrafo = new Matriz(3);

            // Assert
            Assert.AreEqual(3, novoGrafo.Lenght);
            Assert.AreEqual("Matriz de Adjacência", novoGrafo.formato);
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
        /// </summary>
        [TestMethod]
        public void ArestasAdjacentes_DeveRetornarArestasCorretas()
        {
            // Arrange
            grafo.addAresta(0, 1, 5);
            grafo.addAresta(0, 2, 3);
            grafo.addAresta(0, 3, 7);
            Aresta aresta = new Aresta(0, 1, 5);

            // Act
            Aresta[] adjacentes = grafo.arestasAdjacentes(aresta);

            // Assert
            Assert.AreEqual(2, adjacentes.Length);
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
        /// </summary>
        [TestMethod]
        public void VerticesAdjacentes_DeveRetornarVerticesCorretos()
        {
            // Arrange
            grafo.addAresta(0, 1, 5);
            grafo.addAresta(2, 1, 3);
            grafo.addAresta(3, 1, 7);

            // Act
            int[] adjacentes = grafo.verticesAdjacentes(1);

            // Assert
            Assert.AreEqual(3, adjacentes.Length);
            Assert.IsTrue(adjacentes.Contains(1)); // 0+1
            Assert.IsTrue(adjacentes.Contains(3)); // 2+1
            Assert.IsTrue(adjacentes.Contains(4)); // 3+1
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
            Assert.AreEqual(2, vertices[0]); // 1+1
            Assert.AreEqual(4, vertices[1]); // 3+1
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
            Aresta aresta = new Aresta(0, 1, 5);

            // Act
            Aresta arestaAtualizada = grafo.substituirPeso(aresta, 15);

            // Assert
            Assert.AreEqual(15, arestaAtualizada.peso);
            Assert.IsTrue(grafo.indiceOcupado(0, 1));
        }

        /// <summary>
        /// Testa a troca de posições entre dois vértices
        /// </summary>
        [TestMethod]
        public void SubstituirVertice_DeveTrocarVerticesCorretamente()
        {
            // Arrange
            grafo.addAresta(0, 1, 5);
            grafo.addAresta(0, 2, 3);
            grafo.addAresta(3, 0, 7);

            // Act
            grafo.substituirVertice(0, 3);

            // Assert
            // Após a troca, as arestas que eram de 0 devem estar em 3 e vice-versa
            Assert.IsTrue(grafo.indiceOcupado(3, 1));
            Assert.IsTrue(grafo.indiceOcupado(3, 2));
            Assert.IsTrue(grafo.indiceOcupado(0, 3));
        }

        /// <summary>
        /// Testa a busca de vizinhos de um vértice
        /// </summary>
        [TestMethod]
        public void Vizinhos_DeveRetornarTodosOsVizinhos()
        {
            // Arrange
            grafo.addAresta(1, 0, 5);
            grafo.addAresta(1, 2, 3);
            grafo.addAresta(1, 3, 7);

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
            Matriz grafoUnico = new Matriz(1);

            // Assert
            Assert.AreEqual(1, grafoUnico.Lenght);
        }

        /// <summary>
        /// Testa adição de aresta com peso zero
        /// </summary>
        [TestMethod]
        public void AddAresta_DevePermitirPesoZero()
        {
            // Arrange & Act
            grafo.addAresta(0, 1, 0);

            // Assert
            Assert.IsFalse(grafo.indiceOcupado(0, 1)); // peso 0 é considerado vazio
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
        /// Testa a sobrescrita de uma aresta existente
        /// </summary>
        [TestMethod]
        public void AddAresta_DeveSobrescreverArestaExistente()
        {
            // Arrange
            grafo.addAresta(0, 1, 5);

            // Act
            grafo.addAresta(0, 1, 10);

            // Assert
            Assert.IsTrue(grafo.indiceOcupado(0, 1));
        }
    }
}
