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

        public override string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" 0");
            for (int i = 1; i < Lenght; i++)
            {
                sb.Append("-" + (i + 1));
            }
            sb.AppendLine();
            for (int i = 0; i < Lenght; i++)
            {
                sb.Append(i + 1 + "|");
                for (int j = 0; j < Lenght; j++)
                {
                    sb.Append(i + 1 + "|");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

    }
}
