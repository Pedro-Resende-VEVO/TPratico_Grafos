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

        public void addAresta(int peso)
        {
            int V = 0;
            int W = 0;
            do
            {
                V = sortearVertice();
                W = sortearVertice();
            } while (V == W || grafo.indiceOcupado(V,W) == true);
            grafo.addAresta(V, W, peso);
        }

        public void addAresta(int verticeOrigem, int verticeDestino, int peso)
        {
            grafo.addAresta(verticeOrigem, verticeDestino, peso);
        }

        public int sortearVertice()
        {
            Random rng = new Random();
            return rng.Next(grafo.Lenght - 1);
        }

        public bool verticeDestinoValido(int w)
        {
            return (w > 0 || w <= grafo.Lenght - 1) ? true : throw new Exception("Vértice de destino inválido");
        }

        public bool qntVerticeGrafoValida(int N)
        {
            return (N > 0) ? true : throw new Exception("Quantidade de vértices inválido");
        }

        public bool qntArestaVerticeValida(int qntArestas)
        {
            return (qntArestas <= grafo.Lenght - 1 && qntArestas >= 0) ? true : false;
        }

        public bool qntArestaGrafoValida(int N, int M)
        {
            return (M <= N * 2 && M >= 0) ? true : throw new Exception("Quantidade de arestas inválido");
        }

        public string representacao()
        {
            return grafo.toString();
        }
    }
}
