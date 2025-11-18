using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    internal class Aresta
    {
        public int V { get; set; }
        public int W { get; set; }
        public int peso { get; set; }


        public Aresta(int V, int W, int peso)
        {
            this.V = V;
            this.W = W;
            this.peso = peso;
        }

        public string toString()
        {
            return "("+(V+1)+") -"+peso+"-> ("+(W+1)+")";
        }
    }
}
