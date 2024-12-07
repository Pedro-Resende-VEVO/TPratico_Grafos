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
            formato = "Matriz de Adjacência";
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
            List<Aresta> adjacentes = new List<Aresta>();
            for (int i = 0; i < Lenght; i++)
            {
                if  (dados[a.V, i] != 0)
                {
                    adjacentes.Add(new Aresta(a.V, i, dados[a.V, i]));
                }
            }
            return adjacentes.ToArray();
        }

        override public int[] verticesAdjacentes(int v)
        {
            List<int> adjacentes = new List<int>();
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[i, v] != 0)
                {
                    adjacentes.Add(i);
                }
            }
            return adjacentes.ToArray();
        }

        override public Aresta[] arestasIncidentes(int v)
        {
            List<Aresta> incidentes = new List<Aresta>();
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[i, v] != 0)
                {
                    incidentes.Add(new Aresta(i, v, dados[i, v]));
                }
            }
            return incidentes.ToArray();
        }

        override public int[] verticesIncidentes(Aresta a)
        {
            List<int> incidentes = new List<int>();
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[i, a.V] != 0)
                {
                    incidentes.Add(dados[i, a.V]);
                }
            }
            return incidentes.ToArray();
        }

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
            List<int> vizinhaca = new List<int>();
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[v, i] != 0)
                {
                    vizinhaca.Add(i);
                }

            }
            return vizinhaca.ToArray();
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
