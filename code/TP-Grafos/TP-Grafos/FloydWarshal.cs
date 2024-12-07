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

        public int[,] execucao(int o)
        {
            for (int i = 0; i < grafo.Lenght; i++)
            {
                distancia[i, i] = 0;
                for (int j = 0; j < grafo.Lenght; j++)
                {
                    //distancia[i, j] = grafo.distanciaEntre(i,j);
                }
            }

            for (int k = 0; k < grafo.Lenght; k++)
            {
                for (int i = 0; i < grafo.Lenght; i++)
                {
                    for (int j = 0; j < grafo.Lenght; j++)
                    {
                        if (distancia[i,j] > distancia[i,k] + distancia[k, j])
                        {
                            distancia[i, j] = distancia[i, k] + distancia[k, j];
                        }
                    }
                }
            }

            return distancia;
        }
    }
}
