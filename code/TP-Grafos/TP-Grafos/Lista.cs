using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class Lista : Grafo
    {
        private Dictionary<int,int>[] dados;

        public Lista(int N) : base(N)
        {
            dados = new Dictionary<int, int>[N];
            Lenght = N;
        }

        override public void addAresta(int V, int W, int pesos)
        {
        }

        //public string toString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < dados.Count(); i++)
        //    {
        //        sb.AppendLine("\nVertice" + i + ": ");
        //        for (int j = 0; j < dados[i].Count(); j++)
        //        {
        //            sb.AppendLine("-> " + lista[i][j].toString());
        //        }
        //    }

        //    return sb.ToString();
        //}
    }
}
