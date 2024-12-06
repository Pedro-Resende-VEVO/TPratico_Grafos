using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    abstract class Grafo
    {
        public Grafo(int N)
        {

        }

        abstract public bool add_aresta(int V, int W, int[] pesos);
    }
}
