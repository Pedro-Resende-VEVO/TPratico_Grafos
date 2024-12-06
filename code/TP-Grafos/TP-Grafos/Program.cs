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
                        string grafoString = criarGrafo();
                        Console.Clear();
                        Console.WriteLine("Parabéns! você acabo de criar um grafo no formato de " + edwaldo.formato);
                        Console.WriteLine("Sua representação pode ser vista abaixo:\n");
                        Console.WriteLine(grafoString);
                        Console.WriteLine("\n(Aperte qualquer tecla para voltar ao menu)");
                        Console.ReadKey();
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

        static string criarGrafo()
        {
            int[] verticesAleatorios = new int[2];

            Console.WriteLine("Quantos vértices terá o grafo?");
            Console.Write("RESPOSTA: ");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Quantas arestas terá o grafo ?");
            Console.Write("RESPOSTA: ");
            int M = Convert.ToInt32(Console.ReadLine());

            edwaldo.definirGrafo(N, M);

            int arestasRestantes = M;
            for (int i = 0; i < N; i++) {
                if (arestasRestantes <= 0){
                    arestasRestantes = criarAresta(i, arestasRestantes);
                }
            }

            return edwaldo.representacao();
        }

        static int criarAresta(int indexVertice, int arestasRestantes)
        {
            Console.WriteLine("#Arestas restantes: "+ arestasRestantes+" #");
            Console.WriteLine("Quantas arestas terá o vértice " + indexVertice + "?");
            Console.Write("RESPOSTA: ");
            int qntArestas = Convert.ToInt32(Console.ReadLine());

            if (qntArestas <= arestasRestantes){
                Console.WriteLine("Quantidade inválida, favor tente novamente\n(Aperte qualquer tecla para continuar");
                return criarAresta(indexVertice, arestasRestantes);
            }

            int peso = 0;
            for (int j = 0; j < qntArestas; j++)
            {
                Console.WriteLine("Peso da aresta " + (j + 1) + " - Vértice "+indexVertice+"?");
                Console.Write("RESPOSTA: ");
                peso = Convert.ToInt32(Console.ReadLine());
                edwaldo.addAresta(indexVertice, peso);
            }

            return arestasRestantes - qntArestas;
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
