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
        public string formato;

        public Grafo(int N)
        {
            Lenght = N;
            formato = "";
        }

        abstract public bool indiceOcupado(int V, int W);

        abstract public void addAresta(int V, int W, int peso);
        
        abstract public Aresta[] arestasAdjacentes(Aresta a);

        abstract public int[] verticesAdjacentes(int v);

        abstract public int[] verticesIncidentes(Aresta a);

        abstract public Aresta[] arestasIncidentes(int v);

        abstract public int grauEntrada(int v);

        abstract public int grauSaida(int v);

        abstract public bool existeAdjacencia(int v, int w);

        abstract public Aresta substituirPeso(Aresta a, int pesoNovo);

        abstract public void substituirVertice(int v, int w);

        abstract public int[] vizinhos(int v);

        abstract public string toString();
    }
}
