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

        override public bool add_aresta(int V, int W, int[] pesos)
        {

        }

    }
}
