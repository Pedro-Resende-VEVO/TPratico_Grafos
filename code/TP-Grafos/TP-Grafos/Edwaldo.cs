using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class Edwaldo
    {
        private double CRITERIO_DENSIDADE = 0.5;
        private Grafo grafo;
        public string formato;

        public Edwaldo()
        {
            formato = "";
        }

        public void definirGrafo(int N, int M)
        {
            if (M / N * (N - 1) > CRITERIO_DENSIDADE)
            {
                grafo = new Matriz(N);
                formato = "Matriz de Adjacência";
            }
            grafo = new Lista(N);
            formato = "Lista de Adjacência";
        }

        public void addAresta(int peso)
        {
            int V = 0;
            int W = 0;
            do
            {
                V = sortearVertice();
                W = sortearVertice();
            } while (V == W || grafo.indiceOcupado(V,W) == true);
            grafo.addAresta(V, W, peso);
        }

        public void addAresta(int verticeOrigem, int verticeDestino, int peso)
        {
            grafo.addAresta(verticeOrigem, verticeDestino, peso);
        }

        public int sortearVertice()
        {
            Random rng = new Random();
            return rng.Next(grafo.Lenght - 1);
        }

        public Aresta[] arestasDisponiveis()
        {
            List<Aresta> arestasTotal = new List<Aresta>();
            for (int i = 0; i < grafo.Lenght; i++)
            {
                foreach(Aresta V in grafo.incidentesVertice(i))
                {
                    arestasTotal.Add(V);
                }
            }
            return arestasTotal.ToArray();
        }

        public int[] verticesDisponiveis()
        {
            List<int> verticesTotal = new List<int>();
            for (int i = 0; i < grafo.Lenght; i++)
            {
                verticesTotal.Add(i);
            }
            return verticesTotal.ToArray();
        }

        public Aresta[] adjacencia(Aresta A)
        {
            return grafo.arestasAdjacentes(A);
        }

        public int[] adjacencia(int V)
        {
            return grafo.verticesAdjacentes(V);
        }

        public string adjacencia(int V, int W)
        {
            return (grafo.existeAdjacencia(V, W)) ? "EXISTE a adjacência entre os vértices" : "NÃO EXISTE tal adjacência";

        }

        public int[] incidencia(Aresta A)
        {
            return grafo.incidentesAresta(A);
        }

        public Aresta[] incidencia(int V)
        {
            return grafo.incidentesVertice(V);
        }

        public string grau(int V)
        {
            return "Grau de Entrada: " + grafo.grauEntrada(V) + "\nGrau de Saída: " + grafo.grauSaida(V);
        }

        public Aresta substituir(Aresta A, int peso)
        {
            return grafo.substituirPeso(A, peso);
        }

        public void substituir(int V, int W)
        {
            grafo.substituirVertice(V, W);
        }

        public string buscaEmLargura(int v)
        {
            return new BuscaEmLargura(grafo).execucao(v);
        }

        public string buscaEmProfundidade(int v)
        {
            return new BuscaEmProfundidade(grafo).execucao(v);
        }

        public string Dijkstra(int o, int d)
        {
            return new Dijkstra(grafo).execucao(o,d);
        }

        public int[,] FloydWarshal(int o)
        {
            return new FloydWarshal(grafo).execucao(o);
        }


        public bool verticeDestinoValido(int w)
        {
            return (w > 0 || w <= grafo.Lenght - 1) ? true : throw new Exception("Vértice de destino inválido");
        }

        public bool qntVerticeGrafoValida(int N)
        {
            return (N > 0) ? true : throw new Exception("Quantidade de vértices inválido");
        }

        public bool qntArestaVerticeValida(int qntArestas)
        {
            return (qntArestas <= grafo.Lenght - 1 && qntArestas >= 0) ? true : false;
        }

        public bool qntArestaGrafoValida(int N, int M)
        {
            return (M <= N * 2 && M >= 0) ? true : throw new Exception("Quantidade de arestas inválido");
        }

        public string representacao()
        {
            return grafo.toString();
        }
    }
}
