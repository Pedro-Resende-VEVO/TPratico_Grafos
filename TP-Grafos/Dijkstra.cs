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
            if (o < 0 || d < 0 || o >= grafo.Lenght || d >= grafo.Lenght)
            {
                throw new ArgumentOutOfRangeException();
            }

            // Coleta todas as arestas do grafo
            List<Aresta> todas = new List<Aresta>();
            for (int i = 0; i < grafo.Lenght; i++)
            {
                foreach (Aresta a in grafo.arestasIncidentes(i))
                {
                    todas.Add(a);
                }
            }

            // Construção simples de caminho seguindo a primeira aresta que sai do vértice atual
            int atual = o;
            StringBuilder sb = new StringBuilder();
            sb.Append(atual);
            HashSet<int> visitados = new HashSet<int> { atual };
            int guard = 0;
            while (atual != d && guard < grafo.Lenght)
            {
                Aresta proximo = todas.FirstOrDefault(e => e.V == atual);
                if (proximo == null)
                {
                    break; // caminho interrompido
                }
                atual = proximo.W;
                if (!visitados.Add(atual))
                {
                    break; // ciclo
                }
                sb.Append(" -> ").Append(atual);
                guard++;
            }
            return sb.ToString();
        }
    }
}
