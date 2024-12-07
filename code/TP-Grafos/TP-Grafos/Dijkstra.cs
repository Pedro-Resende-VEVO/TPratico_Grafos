using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    internal class Dijkstra
    {
        private Grafo grafo;
        private int[] distancia;
        private int[] predecessor;
        private List<int> explorados;

        public Dijkstra(Grafo grafo)
        {
            this.grafo = grafo;
            distancia = new int[this.grafo.Lenght];
            predecessor = new int[this.grafo.Lenght];
            explorados = new List<int>();
        }

        public string execucao(int o, int d)
        {
            explorados[o] = o;
            distancia[o] = 0;
            Aresta menor;
            for (int i = 0; i < grafo.Lenght - 1; i++)
            {
                menor = menorOpcao(i);
                distancia[menor.W] = distancia[menor.V] + menor.peso;
                predecessor[menor.W] = menor.V;
                explorados[menor.W] = menor.W;
            }
            return "";
        }

        private Aresta menorOpcao(int v)
        {
            Aresta[] incidentes = grafo.incidentesVertice(v);
            int menorPeso = incidentes.Min(c => c.peso + distancia[v]);
            return incidentes[0];
            //return incidentes.Where(b => !explorados.Contains(b.V) && b.peso == menorPeso);
        }
    }
}
