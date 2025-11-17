using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    internal class Dijkstra
    {
        private Grafo grafo;
        private int[] distancia;
        private int[] predecessor;
        private List<int> explorados;

        public Dijkstra(Grafo grafo)
        {
            this.grafo = grafo;
            distancia = new int[this.grafo.Lenght];
            predecessor = new int[this.grafo.Lenght];
            explorados = new List<int>(new int[this.grafo.Lenght]);
        }

        public string execucao(int o, int d)
        {
            for (int i = 0; i < grafo.Lenght; i++)
            {
                distancia[i] = int.MaxValue;
                predecessor[i] = -1;
            }

            distancia[o] = 0;
            
            List<int> naoVisitados = new List<int>();
            for (int i = 0; i < grafo.Lenght; i++)
            {
                naoVisitados.Add(i);
            }

            while (naoVisitados.Count > 0)
            {
                int u = -1;
                int min_dist = int.MaxValue;
                foreach (int vertice in naoVisitados)
                {
                    if (distancia[vertice] < min_dist)
                    {
                        min_dist = distancia[vertice];
                        u = vertice;
                    }
                }

                if (u == -1) break;

                naoVisitados.Remove(u);

                if (u == d) break;

                
                int[] vizinhosArray = grafo.vizinhos(u);

                foreach (int v in vizinhosArray)
                {
                
                    int peso = 0;
        
                    Aresta[] arestasEmV = grafo.arestasIncidentes(v);
                    foreach (var aresta in arestasEmV)
                    {
                        if (aresta.V == u && aresta.W == v)
                        {
                            peso = aresta.peso;
                            break;
                        }
                    }

                    if (peso > 0 && distancia[u] != int.MaxValue && distancia[u] + peso < distancia[v])
                    {
                        distancia[v] = distancia[u] + peso;
                        predecessor[v] = u;
                    }
                }
            }

            if (predecessor[d] == -1 && d != o)
            {
                return "Não há caminho de " + o + " para " + d;
            }

            List<int> caminho = new List<int>();
            int atual = d;
            while (atual != -1)
            {
                caminho.Add(atual);
                atual = predecessor[atual];
            }
            caminho.Reverse();

            return string.Join(" -> ", caminho);
        }

        private Aresta menorOpcao(int v)
        {
            Aresta[] incidentes = grafo.arestasIncidentes(v);
            if (incidentes == null || incidentes.Length == 0) return null;
            int menorPeso = incidentes.Min(c => c.peso + distancia[v]);
            return incidentes.First(b => b.peso + distancia[v] == menorPeso);
        }
    }
}
