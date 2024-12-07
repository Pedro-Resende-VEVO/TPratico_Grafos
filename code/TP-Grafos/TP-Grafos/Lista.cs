using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class Lista : Grafo
    {
        private List<Aresta>[] dados;

        public Lista(int N) : base(N)
        {
            dados = new List<Aresta>[N];
            for (int i = 0; i < N; i++)
            {
                dados[i] = new List<Aresta>();
            }
            Lenght = N;
        }

        override public void addAresta(int V, int W, int peso)
        {
            dados[W].Add(new Aresta(V, peso));
        }

        override public bool indiceOcupado(int V, int W)
        {
            return (dados[W].Any(A => A.V == V) ? true : false);
        }

        override public string toString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dados.Count(); i++)
            {
                sb.Append("|" +(i+1)+ "|");
                for (int j = 0; j < dados[i].Count(); j++)
                {
                    sb.Append(" -["+ dados[i][j].peso +"]-> |" + (dados[i][j].V + 1)+"|");
                }
                sb.AppendLine(" --x");
            }

            return sb.ToString();
        }
    }
}
