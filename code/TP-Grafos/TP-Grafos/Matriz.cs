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

    }
}
