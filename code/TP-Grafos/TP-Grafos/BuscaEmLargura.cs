using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    internal class BuscaEmLargura
    {
        private Grafo grafo;
        private int[] tempoDescoberta;
        private int[] tempoTermino;
        private int[] pai;
        private int t;

        public BuscaEmLargura(Grafo grafo)
        {
            this.grafo = grafo;
            tempoDescoberta = new int[this.grafo.Lenght];
            tempoTermino = new int[this.grafo.Lenght];
            pai = new int[this.grafo.Lenght];
            t = 0;
        }
    }
}
