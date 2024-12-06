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
        public string formato;

        public Edwaldo()
        {
            formato = "";
        }

        public void definirGrafo(int N, int M)
        {
            if (M / N * (N - 1) > CRITERIO_DENSIDADE)
            {
                grafo = new Matriz(N);
                formato = "Matriz de Adjacência";
            }
            grafo = new Lista(N);
            formato = "Lista de Adjacência";
        }

        public void addAresta(int verticeOrigem, int peso)
        {
            grafo.addAresta(verticeOrigem, sortearVertice(), peso);
        }

        public int sortearVertice()
        {
            Random rng = new Random();
            return rng.Next(grafo.Lenght);
        }

        public string representacao()
        {

        }
    }
}
