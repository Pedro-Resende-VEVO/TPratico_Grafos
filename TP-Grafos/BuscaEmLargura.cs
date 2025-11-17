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
        int[] L;
        int[] nivel;
        int[] pai;
        Queue<int> fila;

        public BuscaEmLargura(Grafo grafo)
        {
            this.grafo = grafo;
            L = new int[grafo.Lenght];
            nivel = new int[grafo.Lenght];
            pai = new int[grafo.Lenght];
            fila = new Queue<int>();
        }

        public string execucao(int v)
        {
            StringBuilder caminho = new StringBuilder();

            for (int i = 0; i < grafo.Lenght; i++)
            {
                L[i] = 0;
                nivel[i] = 0;
                pai[i] = -1;
            }

           
            int t = 0;
            if (L[v] == 0)
            {
                t++;
                L[v] = t;
                fila.Enqueue(v);
                caminho.AppendLine($"Raiz: {v + 1}");

                while (fila.Count > 0)
                {
                    int atual = fila.Dequeue();
                    foreach (int w in grafo.vizinhos(atual))
                    {
                        if (L[w] == 0)
                        {
                            pai[w] = atual;
                            nivel[w] = nivel[v] + 1;
                            t = t + 1;
                            L[w] = t;
                            fila.Enqueue(w);
                            caminho.AppendLine($"Aresta de árvore: {atual + 1} -> {w + 1}");

                        }
                        else if (pai[atual] != w && nivel[atual] > nivel[w])
                        {
                            caminho.AppendLine($"Aresta de retorno: {atual + 1} -> {w + 1}");
                        }
                        else
                        {
                            caminho.AppendLine($"Aresta de cruzamento {atual + 1}-> {w + 1}");
                        }
                    }
                }
            }
            return caminho.ToString();
        }
    }
}
