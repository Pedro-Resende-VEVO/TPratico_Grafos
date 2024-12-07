using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    internal class BuscaEmProfundidade
    {
        private Grafo grafo;
        private int[] tempoDescoberta;
        private int[] tempoTermino;
        private int[] pai;
        private int t;

        public BuscaEmProfundidade(Grafo grafo)
        {
            this.grafo = grafo;
            tempoDescoberta = new int[this.grafo.Lenght];
            tempoTermino = new int[this.grafo.Lenght];
            pai = new int[this.grafo.Lenght];
            t = 0;
        }

        public void execucao(int v)
        {
            t++;
            tempoDescoberta[v] = t;

            foreach (int w in grafo.vizinhos(v))
            {
                if (tempoDescoberta[w] == 0)
                {
                    pai[w] = v;
                    execucao(w);
                }
            }
            t++;
            tempoTermino[v] = t;
        }
    }
}
