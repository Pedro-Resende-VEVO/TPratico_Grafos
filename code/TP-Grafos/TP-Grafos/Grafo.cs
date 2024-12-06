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

        }

        abstract public bool addAresta(int V, int W, int peso);
    }
}
