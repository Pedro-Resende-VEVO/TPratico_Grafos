using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class Edwaldo
    {
        private double CRITERIO_DENSIDADE = 0.5;
        private Grafo grafo;

        public Edwaldo()
        {

        }

        public Grafo definirGrafo(int N, int M)
        {
            if (M / N * (N - 1) > CRITERIO_DENSIDADE)
            {
                return new Matriz(N);
            }
            return new Lista(N);
        }

        public int[] sortearVertice(int limite)
        {
            Random rng = new Random();
            int[] verticesSortidos = new int[2];

            for (int i = 0; i < 2; i++)
            {
                verticesSortidos[i] = rng.Next(limite);
            }

            return (verticesSortidos[0] != verticesSortidos[1]) ? [verticesSortidos[0], verticesSortidos[1]] : sortearVertice(limite);
        }

        public string representacao()
        {

        }
    }
}
