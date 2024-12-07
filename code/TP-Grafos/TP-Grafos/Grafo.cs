using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    abstract class Grafo
    {
        public int Lenght;
        public Grafo(int N)
        {
            Lenght = 0;
        }

        abstract public bool indiceOcupado(int V, int W);

        abstract public void addAresta(int V, int W, int peso);

        abstract public int[] vizinhos(int v);

        abstract public string toString();
    }
}
