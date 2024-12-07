using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class Matriz : Grafo
    {
        private int[,] dados;

        public Matriz(int N) :base(N)
        {
            dados = new int[N, N];
            Lenght = N;
        }

        override public void addAresta(int V, int W, int peso)
        {
            dados[V, W] = peso;
        }

        override public bool indiceOcupado(int V, int W)
        {
            return (dados[V, W] != 0) ? true : false;
        }

        override public Aresta[] arestasAdjacentes(Aresta a)
        {
            Aresta[] adjacentes = new Aresta[Lenght];
            for (int i = 0; i < Lenght; i++)
            {
                if  (dados[a.V, i] != 0)
                {
                    adjacentes.Append(new Aresta(a.V, i, dados[a.V, i]));
                }
            }
            return adjacentes;
        }

        override public int[] verticesAdjacentes(int v)
        {
            int[] adjacentes = new int[Lenght];
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[i, v] != 0)
                {
                    adjacentes.Append(i);
                }
            }
            return adjacentes;
        }

        override public Aresta[] incidentesVertice(int v)
        {
            Aresta[] incidentes = new Aresta[Lenght];
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[i, v] != 0)
                {
                    incidentes.Append(new Aresta(i, v, dados[i, v]));
                }
            }
            return incidentes;
        }

        //public Aresta[] verticesIncidentes(Aresta a)
        //{
        //    Aresta[] adjacentes = new Aresta[Lenght];
        //    for (int i = 0; i < Lenght; i++)
        //    {
        //        if (dados[i, a.V] != 0)
        //        {
        //            adjacentes.Append(new Aresta(a.V, dados[i, a.V]));
        //        }
        //    }
        //    return adjacentes;
        //}

        override public int grauEntrada(int v)
        {
            int grau = 0;
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[i, v] != 0)
                {
                    grau++;
                }
            }
            return grau;
        }

        override public int grauSaida(int v)
        {
            int grau = 0;
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[v, i] != 0)
                {
                    grau++;
                }
            }
            return grau;
        }

        override public bool existeAdjacencia(int v, int w)
        {
            return (dados[w, v] != 0 || dados[w, v] != 0) ? true : false;
        }

        override public Aresta substituirPeso(Aresta a, int pesoNovo)
        {
            dados[a.V, a.W] = pesoNovo;
            a.peso = pesoNovo;
            return a;
        }

        override public void substituirVertice(int v, int w)
        {
            int valorTroca = 0;

            for (int i = 0; i < Lenght; i++)
            {
                valorTroca = dados[i, w];
                dados[i, w] = dados[i, v];
                dados[i, v] = valorTroca;

                valorTroca = dados[w, i];
                dados[w, i] = dados[v, i];
                dados[v, i] = valorTroca;
            }
        }

        override public int[] vizinhos(int v)
        {
            int[] vizinhaca = new int[Lenght];
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[v, i] != 0)
                {
                    vizinhaca.Append(i);
                }

            }
            return vizinhaca;
        }

        override public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  ");
            for (int i = 0; i < Lenght; i++)
            {
                sb.Append((i + 1) + " ");
            }

            sb.AppendLine();
            for (int i = 0; i < Lenght; i++)
            {
                sb.Append(i + 1 + "|");
                for (int j = 0; j < Lenght; j++)
                {
                    sb.Append(dados[i,j] + "|");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

    }
}
