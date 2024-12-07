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
            dados[W, V] = peso;
        }

        override public bool indiceOcupado(int V, int W)
        {
            return (dados[W, V] != 0) ? true : false;
        }

        public Aresta[] arestasAdjacentes(Aresta a)
        {
            Aresta[] adjacentes = new Aresta[Lenght];
            for (int i = 0; i < Lenght; i++)
            {
                if  (dados[i, a.V] != 0)
                {
                    adjacentes.Append(new Aresta(a.V, dados[i, a.V]));
                }
            }
            return adjacentes;
        }

        public int[] verticesAdjacentes(int v)
        {
            int[] adjacentes = new int[Lenght];
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[v, i] != 0)
                {
                    adjacentes.Append(i);
                }
            }
            return adjacentes;
        }

        public Aresta[] arestaIncidente(int v)
        {
            Aresta[] incidentes = new Aresta[Lenght];
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[v, i] != 0)
                {
                    incidentes.Append(new Aresta(i, dados[v, i]));
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

        public int grauEntrada(int v)
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

        public int grauSaida(int v)
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

        public bool existeAdjacencia(int v, int w)
        {
            return (dados[w, v] != 0 || dados[w, v] != 0) ? true : false;
        }

        public Aresta substituirPeso(Aresta a, int pesoNovo)
        {
            dados[a.W, a.V] = pesoNovo;
            a.peso = pesoNovo;
            return a;
        }

        public override string toString()
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
