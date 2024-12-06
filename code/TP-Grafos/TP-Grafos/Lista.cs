using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class Lista : Grafo
    {
        private List<int>[] dados;

        public Lista(int N) : base(N)
        {
            dados = new List<int>();
        }

        //override public bool add_aresta(int V, int W, int[] pesos)
        //{

        //}

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dados.Count(); i++)
            {
                sb.AppendLine("\nVertice" + i + ": ");
                for (int j = 0; j < dados[i].Count(); j++)
                {
                    sb.AppendLine("-> " + lista[i][j].toString());
                }
            }

            return sb.ToString();
        }
    }
}
