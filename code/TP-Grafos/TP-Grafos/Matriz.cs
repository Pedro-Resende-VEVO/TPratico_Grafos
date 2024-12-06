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

        public Matriz(int N)
        {
            dados = new int[N, N];
        }

        override public bool addAresta(int V, int W, int[] pesos)
        {

        }

    }
}
