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
        public int peso { get; set; }


        public Aresta(int V, int peso)
        {
            this.V = V;
            this.peso = peso;
        }
    }
}
