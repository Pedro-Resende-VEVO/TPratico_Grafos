using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    internal class FloydWarshal
    {
        private Grafo grafo;
        private int[,] distancia;

        public FloydWarshal(Grafo grafo)
        {
            this.grafo = grafo;
            distancia = new int[this.grafo.Lenght, this.grafo.Lenght];

        }

        public int[,] execucao(int origemIgnorado)
        {
            int INF = int.MaxValue / 4;
            // Inicialização
            for (int i = 0; i < grafo.Lenght; i++)
            {
                for (int j = 0; j < grafo.Lenght; j++)
                {
                    distancia[i, j] = (i == j) ? 0 : INF;
                }
            }

            // Preenche pesos das arestas conhecidas
            for (int v = 0; v < grafo.Lenght; v++)
            {
                foreach (Aresta a in grafo.arestasIncidentes(v))
                {
                    distancia[a.V, a.W] = Math.Min(distancia[a.V, a.W], a.peso);
                }
            }

            // Floyd-Warshall
            for (int k = 0; k < grafo.Lenght; k++)
            {
                for (int i = 0; i < grafo.Lenght; i++)
                {
                    if (distancia[i, k] == INF) continue;
                    for (int j = 0; j < grafo.Lenght; j++)
                    {
                        if (distancia[k, j] == INF) continue;
                        int novo = distancia[i, k] + distancia[k, j];
                        if (novo < distancia[i, j])
                        {
                            distancia[i, j] = novo;
                        }
                    }
                }
            }

            return distancia;
        }
    }
}
