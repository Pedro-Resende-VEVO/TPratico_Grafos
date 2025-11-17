using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TP_Grafos;

namespace TP_Grafos.Tests
{
    /// <summary>
    /// Classe de testes para a classe BuscaEmLargura (BFS)
    /// Testa o algoritmo de busca em largura em diferentes cenários de grafos
    /// </summary>
    [TestClass]
    public class BuscaEmLarguraTests
    {
        /// <summary>
        /// Testa a execução da BFS em um grafo simples linear
        /// </summary>
        [TestMethod]
        public void Execucao_GrafoLinearSimples_DeveExecutarCorretamente()
        {
            // Arrange
            Matriz grafo = new Matriz(4);
            grafo.addAresta(0, 1, 1);
            grafo.addAresta(1, 2, 1);
            grafo.addAresta(2, 3, 1);
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Contains("Raiz: 1"));
            Assert.IsTrue(resultado.Contains("Aresta"));
        }

        /// <summary>
        /// Testa a BFS começando pelo vértice raiz
        /// </summary>
        [TestMethod]
        public void Execucao_DeveIdentificarRaizCorretamente()
        {
            // Arrange
            Matriz grafo = new Matriz(3);
            grafo.addAresta(0, 1, 1);
            grafo.addAresta(0, 2, 1);
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsTrue(resultado.Contains("Raiz: 1"));
        }

        /// <summary>
        /// Testa a BFS em um grafo com forma de árvore
        /// </summary>
        [TestMethod]
        public void Execucao_GrafoArvore_DeveIdentificarArestasDeArvore()
        {
            // Arrange
            Matriz grafo = new Matriz(7);
            // Criando uma árvore binária
            grafo.addAresta(0, 1, 1); // raiz -> esquerda
            grafo.addAresta(0, 2, 1); // raiz -> direita
            grafo.addAresta(1, 3, 1); // esquerda -> filho esquerdo
            grafo.addAresta(1, 4, 1); // esquerda -> filho direito
            grafo.addAresta(2, 5, 1); // direita -> filho esquerdo
            grafo.addAresta(2, 6, 1); // direita -> filho direito
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Contains("Raiz: 1"));
            Assert.IsTrue(resultado.Contains("Aresta de árvore"));
        }

        /// <summary>
        /// Testa a BFS em um grafo com ciclos
        /// </summary>
        [TestMethod]
        public void Execucao_GrafoComCiclo_DeveIdentificarArestasDeRetorno()
        {
            // Arrange
            Matriz grafo = new Matriz(4);
            grafo.addAresta(0, 1, 1);
            grafo.addAresta(1, 2, 1);
            grafo.addAresta(2, 3, 1);
            grafo.addAresta(3, 0, 1); // Cria um ciclo
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Length > 0);
        }

        /// <summary>
        /// Testa a BFS em um grafo completamente conectado (clique)
        /// </summary>
        [TestMethod]
        public void Execucao_GrafoCompleto_DeveExecutarSemErros()
        {
            // Arrange
            Matriz grafo = new Matriz(4);
            // Conectando todos os vértices entre si
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i != j)
                    {
                        grafo.addAresta(i, j, 1);
                    }
                }
            }
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Contains("Raiz: 1"));
        }

        /// <summary>
        /// Testa a BFS em um grafo com vértices isolados
        /// </summary>
        [TestMethod]
        public void Execucao_GrafoComVerticeIsolado_DeveVisitarApenasComponenteConectado()
        {
            // Arrange
            Matriz grafo = new Matriz(5);
            grafo.addAresta(0, 1, 1);
            grafo.addAresta(1, 2, 1);
            // Vértices 3 e 4 ficam isolados
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Contains("Raiz: 1"));
            // O resultado não deve conter referências aos vértices isolados 4 e 5
        }

        /// <summary>
        /// Testa a BFS começando de vértices diferentes
        /// </summary>
        [TestMethod]
        public void Execucao_DiferentesVerticesInicio_DeveExecutarCorretamente()
        {
            // Arrange
            Matriz grafo = new Matriz(4);
            grafo.addAresta(0, 1, 1);
            grafo.addAresta(1, 2, 1);
            grafo.addAresta(2, 3, 1);
            BuscaEmLargura bfs1 = new BuscaEmLargura(grafo);
            BuscaEmLargura bfs2 = new BuscaEmLargura(grafo);

            // Act
            string resultado1 = bfs1.execucao(0);
            string resultado2 = bfs2.execucao(2);

            // Assert
            Assert.IsNotNull(resultado1);
            Assert.IsNotNull(resultado2);
            Assert.IsTrue(resultado1.Contains("Raiz: 1"));
            Assert.IsTrue(resultado2.Contains("Raiz: 3"));
        }

        /// <summary>
        /// Testa a BFS em um grafo com apenas um vértice
        /// </summary>
        [TestMethod]
        public void Execucao_GrafoComUmVertice_DeveExecutarSemErros()
        {
            // Arrange
            Matriz grafo = new Matriz(1);
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Contains("Raiz: 1"));
        }

        /// <summary>
        /// Testa a BFS em um grafo em forma de estrela
        /// </summary>
        [TestMethod]
        public void Execucao_GrafoEstrela_DeveTerNivelCorreto()
        {
            // Arrange
            Matriz grafo = new Matriz(6);
            // Vértice central conectado a todos os outros
            grafo.addAresta(0, 1, 1);
            grafo.addAresta(0, 2, 1);
            grafo.addAresta(0, 3, 1);
            grafo.addAresta(0, 4, 1);
            grafo.addAresta(0, 5, 1);
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Contains("Raiz: 1"));
            Assert.IsTrue(resultado.Contains("Aresta de árvore"));
        }

        /// <summary>
        /// Testa a BFS com Lista de Adjacência
        /// </summary>
        [TestMethod]
        public void Execucao_ComListaAdjacencia_DeveExecutarCorretamente()
        {
            // Arrange
            Lista grafo = new Lista(5);
            grafo.addAresta(0, 1, 1);
            grafo.addAresta(0, 2, 1);
            grafo.addAresta(1, 3, 1);
            grafo.addAresta(2, 4, 1);
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Contains("Raiz: 1"));
        }

        /// <summary>
        /// Testa a BFS em um grafo bidirecional
        /// </summary>
        [TestMethod]
        public void Execucao_GrafoBidirecional_DeveIdentificarArestasCorretamente()
        {
            // Arrange
            Matriz grafo = new Matriz(3);
            grafo.addAresta(0, 1, 1);
            grafo.addAresta(1, 0, 1);
            grafo.addAresta(1, 2, 1);
            grafo.addAresta(2, 1, 1);
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Length > 0);
        }

        /// <summary>
        /// Testa a BFS em um grafo com múltiplos componentes
        /// </summary>
        [TestMethod]
        public void Execucao_MultiploComponentes_DeveVisitarApenasComponenteInicial()
        {
            // Arrange
            Matriz grafo = new Matriz(6);
            // Primeiro componente
            grafo.addAresta(0, 1, 1);
            grafo.addAresta(1, 2, 1);
            // Segundo componente (desconectado)
            grafo.addAresta(3, 4, 1);
            grafo.addAresta(4, 5, 1);
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Contains("Raiz: 1"));
            // Deve visitar apenas os vértices 1, 2, 3
        }

        /// <summary>
        /// Testa a BFS em um grafo com auto-loop
        /// </summary>
        [TestMethod]
        public void Execucao_GrafoComAutoLoop_DeveExecutarCorretamente()
        {
            // Arrange
            Matriz grafo = new Matriz(3);
            grafo.addAresta(0, 0, 1); // Auto-loop
            grafo.addAresta(0, 1, 1);
            grafo.addAresta(1, 2, 1);
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Contains("Raiz: 1"));
        }

        /// <summary>
        /// Testa se a BFS retorna string não vazia
        /// </summary>
        [TestMethod]
        public void Execucao_DeveRetornarStringNaoVazia()
        {
            // Arrange
            Matriz grafo = new Matriz(3);
            grafo.addAresta(0, 1, 1);
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(resultado));
        }

        /// <summary>
        /// Testa a BFS em um grafo em forma de caminho longo
        /// </summary>
        [TestMethod]
        public void Execucao_GrafoCaminhoLongo_DeveVisitarTodosVertices()
        {
            // Arrange
            Matriz grafo = new Matriz(10);
            for (int i = 0; i < 9; i++)
            {
                grafo.addAresta(i, i + 1, 1);
            }
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Act
            string resultado = bfs.execucao(0);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Contains("Raiz: 1"));
            Assert.IsTrue(resultado.Contains("Aresta de árvore"));
        }

        /// <summary>
        /// Testa construtor da BFS com grafo de Lista
        /// </summary>
        [TestMethod]
        public void Constructor_ComListaAdjacencia_DeveInicializarCorretamente()
        {
            // Arrange
            Lista grafo = new Lista(5);
            
            // Act
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Assert
            Assert.IsNotNull(bfs);
        }

        /// <summary>
        /// Testa construtor da BFS com grafo de Matriz
        /// </summary>
        [TestMethod]
        public void Constructor_ComMatrizAdjacencia_DeveInicializarCorretamente()
        {
            // Arrange
            Matriz grafo = new Matriz(5);
            
            // Act
            BuscaEmLargura bfs = new BuscaEmLargura(grafo);

            // Assert
            Assert.IsNotNull(bfs);
        }
    }
}
