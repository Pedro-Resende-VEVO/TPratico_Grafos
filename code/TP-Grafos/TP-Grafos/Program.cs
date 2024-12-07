using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    internal class Program
    {
        private static Edwaldo edwaldo;
        private static char[] indiceLiteral;

        static void Main(string[] args)
        {
            edwaldo = new Edwaldo();
            indiceLiteral = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            int[] G = new int[2];
            bool fim = false;
            do
            {
                try
                {
                    cabecalho();
                    int resp = menu();
                    switch (resp)
                    {
                        case 1:
                            Console.Clear();
                            G = criarGrafo();
                            string grafoString = distribuirArestas(G[1]);
                            Console.Clear();
                            Console.WriteLine("Parabéns! você acabou de criar um grafo no formato de " + edwaldo.formato);
                            Console.WriteLine("Sua representação pode ser vista abaixo:\n");
                            Console.WriteLine(grafoString);
                            Console.WriteLine("\n(Aperte qualquer tecla para voltar ao menu)");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Antes de utilizarmos o grafo no formato DIMIC, criaremos um!!\n");
                            G = criarGrafo();
                            criarDIMIC(G[0], G[1]);

                            Console.WriteLine("Sua representação pode ser vista abaixo:\n");
                            Console.WriteLine("\n(Aperte qualquer tecla para voltar ao menu)");
                            Console.ReadKey();
                            Console.Clear();
                            int resp_repre = menuDIMAC();
                            break;

                        case 3:
                            fim = true;
                            break;

                        default:
                            throw new Exception("Opção indisponível, favor tente novamente");
                    }
                }
                catch (Exception e)
                {
                    erro(e);
                }
            }
            while (fim == false);
        }

        static void cabecalho()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("#######-Trabalho Prático de Grafos-######");
            Console.WriteLine("Integrantes: \n -Pedro Resende \n -Thiago Caetano \n -Artur Amendoeira");
            Console.WriteLine("------------------------------------------");
        }

        static int menu()
        {
            try
            {
                Console.WriteLine("######## - Menu - #######");
                Console.WriteLine("1) Criar grafo \n2) Ler formato DIMAC  \n 3) Sair");
                Console.WriteLine("#######################");
                Console.Write("ESCOLHA UMA OPÇÃO: ");
                int resp = Convert.ToInt32(Console.ReadLine());

                return (resp >= 0 || resp <= 3) ? resp : throw new Exception("Opção indisponível, favor tente novamente");
            }
            catch (Exception e)
            {
                erro(e);
                return menu();
            }
        }

        static int[] criarGrafo()
        {
            try
            {
                Console.WriteLine("Quantos vértices terá o grafo?");
                Console.Write("RESPOSTA: ");
                int N = Convert.ToInt32(Console.ReadLine());
                edwaldo.qntVerticeGrafoValida(N);

                Console.WriteLine("\nQuantas arestas terá o grafo ?");
                Console.Write("RESPOSTA: ");
                int M = Convert.ToInt32(Console.ReadLine());
                edwaldo.qntArestaGrafoValida(N, M);

                edwaldo.definirGrafo(N, M);
                Console.Clear();

                return new int[] {N,M};
            }
            catch (Exception e)
            {
                erro(e);
                return criarGrafo();
            }
        }

        static string distribuirArestas(int M)
        {
            try
            {
                for (int j = 0; j < M; j++)
                {
                    Console.WriteLine("\nPeso da aresta " + (j + 1));
                    Console.Write("RESPOSTA: ");
                    int peso = Convert.ToInt32(Console.ReadLine());
                    edwaldo.addAresta(peso);
                }

                return edwaldo.representacao();
            }
            catch (Exception e)
            {
                erro(e);
                return distribuirArestas(M);
            }
        }

        static int menuDIMAC()
        {
            try
            {
                
                Console.WriteLine("########- Menu de DIMAC -#######");
                Console.WriteLine("1) Lista de Adjacência \n2) Matriz de Adjacência \n 3) Matriz de Incidência \n 4) Sair");
                Console.WriteLine("#######################");
                Console.Write("ESCOLHA UMA OPÇÃO: ");
                int resp = Convert.ToInt32(Console.ReadLine());

                return (resp <= 0 || resp > 4) ? resp : throw new Exception("Opção indisponível");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("(Pressione qualquer tecla para continuar)");
                Console.ReadKey();
                return menuDIMAC();
            }
        }

        private static void criarDIMIC(int N, int M)
        {
            try
            {
                int arestasRestantes = M;
                for (int v = 0; v <= N; v++)
                {
                    if (arestasRestantes > 0)
                    {
                        Console.WriteLine("\n#Arestas restantes: " + arestasRestantes + "#");
                        Console.WriteLine("Quantas arestas terá o vértice " + indiceLiteral[v] + "?");
                        Console.Write("RESPOSTA: ");
                        int qntArestas = Convert.ToInt32(Console.ReadLine());

                        if (qntArestas > arestasRestantes || edwaldo.qntArestaVerticeValida(qntArestas) == false)
                        {
                            throw new Exception("Quantidade inválida, favor tente novamente");
                        }

                        int peso = 0;
                        for (int j = 0; j < qntArestas; j++)
                        {
                            Console.WriteLine("Escolha entre 1 e " + (N-1));
                            Console.WriteLine("\nVértice incidente W:");
                            Console.Write("RESPOSTA: ");
                            int w = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("\nPeso da aresta " + (j + 1) + " - Vértice " + indiceLiteral[v]);
                            Console.Write("RESPOSTA: ");
                            peso = Convert.ToInt32(Console.ReadLine());
                            edwaldo.addAresta(v, w, peso);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                erro(e);
                return criarDIMIC(N,M);
            }
        }
        public static void erro(Exception e)
        {
            Console.WriteLine("\n" + e);
            Console.WriteLine("(Pressione qualquer tecla para continuar)");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
