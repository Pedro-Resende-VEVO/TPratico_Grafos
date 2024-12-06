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

        static void Main(string[] args)
        {
            bool fim = false;
            while (fim == false)
            {
                cabecalho();
                int resp = menu();
                switch (resp)
                {
                    case 1:
                        Console.Clear();
                        criarGrafo();
                        break;

                    //case 2:
                    //    Console.Clear();
                    //    int resp_repre = menuDIMAC();
                    //    executarRepresentacao(resp_repre);
                    //    break;

                    case 3:
                        fim = true;
                        break;
                }
            }

        }

        static void cabecalho()
        {
            Console.WriteLine("#########################################");
            Console.WriteLine("#######-Trabalho Prático de Grafos-######");
            Console.WriteLine("Integrantes: \n Pedro Resende \n Thiago Caetano \n Artur Amendoeira");
            Console.WriteLine("#########################################");
        }

        static int menu()
        {
            try
            {
                cabecalho();
                Console.WriteLine("######## - Menu - #######");
                Console.WriteLine("1) Criar grafo \n2) Ler formato DIMAC  \n 3) Sair");
                Console.WriteLine("#######################");
                Console.Write("ESCOLHA UMA OPÇÃO: ");
                int resp = Convert.ToInt32(Console.ReadLine());

                return (resp <= 0 || resp > 3) ? resp : throw new Exception("Opção indisponível");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("(Pressione qualquer tecla para continuar)");
                Console.ReadKey();
                return menu();
            }

        }

        static void criarGrafo()
        {
            int[] verticesAleatorios = new int[2];

            Console.WriteLine("Quantos vértices terá o grafo?");
            Console.Write("RESPOSTA: ");
            int N = Convert.ToInt32(Console.ReadLine());

            int total_arestas = 0;
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Quantas arestas terá o vértice " + i + "?");
                Console.Write("RESPOSTA: ");
                int qnt_arestas = Convert.ToInt32(Console.ReadLine());
                total_arestas = total_arestas + qnt_arestas

                int[] pesos = new int[qnt_arestas];
                for (int j = 0; j < qnt_arestas; j++)
                {
                    Console.WriteLine("Qual peso da aresta " + (j + 1) + "?");
                    Console.Write("RESPOSTA: ");
                    pesos[j] = Convert.ToInt32(Console.ReadLine());

                }
                verticesAleatorios = edwaldo.sortearVertice(N);
                grafo.add_aresta(verticesAleatorios[0], verticesAleatorios[1], pesos);

            }
            grafo = edwaldo.definirGrafo(N, total_arestas);

            Console.WriteLine(edwaldo.representacao());
        }

        // static int menuDIMAC()
        // {
        //     try
        //     {
        //         cabecalho();
        //         Console.WriteLine("########- Menu de DIMAC -#######");
        //         Console.WriteLine("1) Lista de Adjacência \n2) Matriz de Adjacência \n 3) Matriz de Incidência \n 4) Sair");
        //         Console.WriteLine("#######################");
        //         Console.Write("ESCOLHA UMA OPÇÃO: ");
        //         int resp = Convert.ToInt32(Console.ReadLine());

        //         return (resp <= 0 || resp > 4) ? resp : throw new Exception("Opção indisponível");
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e);
        //         Console.WriteLine("(Pressione qualquer tecla para continuar)");
        //         Console.ReadKey();
        //         return menuDIMAC();
        //     }
        // }

    }
}
