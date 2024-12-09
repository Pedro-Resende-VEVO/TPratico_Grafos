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
        static bool[] visitadas;// variáveis globais 

        static void Main(string[] args)
        {

            int T = int.Parse(Console.ReadLine()); // leitura dos mapas/casos de teste

            for (int t = 0; t < T; t++)
            {

                string[] firstLine = Console.ReadLine().Split();
                int N = int.Parse(firstLine[0]); //numero de cidades
                int M = int.Parse(firstLine[1]);// numero de estradas
                int B = int.Parse(firstLine[2]);// custo  da biblioteca
                int E = int.Parse(firstLine[3]); //custo da estrada

                grafoAdj = new List<int>[N + 1];
                for (int i = 1; i <= N; i++)
                {
                    grafoAdj[i] = new List<int>(); //faz a inicialização do grafo com uma lista de adjacência para as N cidades.
                }

                //le todas as estradas e constrói o grafo
                for (int i = 0; i < M; i++)
                {
                    string[] road = Console.ReadLine().Split();
                    int x = int.Parse(road[0]);
                    int y = int.Parse(road[1]);
                    
                    grafoAdj[x].Add(y);// adiciona as conexões
                    grafoAdj[y].Add(x);
                }
                //caso a biblioteca seja mais barata ou igual a construir a estrada
                if (B <= E)
                {
                    Console.WriteLine($"{((long)N * B)}"); // fica mais barato construir uma biblioteca em cada cidade
                    continue;
                }
                //caso contrário é necessário usar o grafo pra determinar os componentes 
                visitadas = new bool[N + 1]; // inicializa cidades não visitadas
                long totalCost = 0;// custo total

                for (int i = 1; i <= N; i++)
                {
                    if (!visitadas[i]) // se não foi visitada,pertence a um novo componente
                    {
                        int componentSize = BFS(i); //tamanho é definido via BFS
                        totalCost += B + (long)(componentSize - 1) * E; // calcula aqui o custo para conectar os componetes
                    }
                }
                //Exibe o custo total mínim
                Console.WriteLine($"{totalCost}");
            }
        }
        static int BFS(int raiz) // busca em largura pra calcular o tamanho do componente
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
