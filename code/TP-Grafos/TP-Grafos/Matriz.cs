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

        public int[] arestasAdjacentes(int V, int W)
        {
            int[] adjacentes = new int[Lenght];
            for (int i = 0; i < Lenght; i++)
            {
                if  (dados[W,i] != 0 && dados[W, i] != dados[W, V])
                {
                    adjacentes.Append(dados[W, i]);
                }
            }
            return adjacentes;
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
