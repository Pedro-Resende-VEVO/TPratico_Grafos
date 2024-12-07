using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Bom_Presidente
{
    internal class Program
    {
        static List<int>[] grafoAdj;
        static bool[] visitadas;

        static void Main(string[] args)
        {

            int T = int.Parse(Console.ReadLine());

            for (int t = 0; t < T; t++)
            {

                string[] firstLine = Console.ReadLine().Split();
                int N = int.Parse(firstLine[0]);
                int M = int.Parse(firstLine[1]);
                int B = int.Parse(firstLine[2]);
                int E = int.Parse(firstLine[3]);

                grafoAdj = new List<int>[N + 1];
                for (int i = 1; i <= N; i++)
                {
                    grafoAdj[i] = new List<int>();
                }


                for (int i = 0; i < M; i++)
                {
                    string[] road = Console.ReadLine().Split();
                    int x = int.Parse(road[0]);
                    int y = int.Parse(road[1]);
                    grafoAdj[x].Add(y);
                    grafoAdj[y].Add(x);
                }

                if (B <= E)
                {
                    Console.WriteLine($"{((long)N * B)}");
                    continue;
                }

                visitadas = new bool[N + 1];
                long totalCost = 0;

                for (int i = 1; i <= N; i++)
                {
                    if (!visitadas[i])
                    {
                        int componentSize = BFS(i);
                        totalCost += B + (long)(componentSize - 1) * E;
                    }
                }

                Console.WriteLine($"{totalCost}");
            }
        }
        static int BFS(int raiz)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(raiz);
            visitadas[raiz] = true;

            int comprimento = 0;

            while (queue.Count > 0)
            {
                int no = queue.Dequeue();
                comprimento++;

                foreach (int vizinho in grafoAdj[no])
                {
                    if (!visitadas[vizinho])
                    {
                        visitadas[vizinho] = true;
                        queue.Enqueue(vizinho);
                    }
                }
            }

            return comprimento;
        }
    }
}
