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
                            string grafoString = criarGrafo();
                            Console.Clear();
                            Console.WriteLine("Parabéns! você acabou de criar um grafo no formato de " + edwaldo.formato);
                            Console.WriteLine("Sua representação pode ser vista abaixo:\n");
                            Console.WriteLine(grafoString);
                            Console.WriteLine("\n(Aperte qualquer tecla para voltar ao menu)");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        //case 2:
                        //    Console.Clear();
                        //    int resp_repre = menuDIMAC();
                        //    executarRepresentacao(resp_repre);
                        //    break;

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

        static string criarGrafo()
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

                int arestasRestantes = M;
                for (int i = 0; i <= N; i++) {
                    if (arestasRestantes > 0){
                        arestasRestantes = criarAresta(i, arestasRestantes);
                    }
                }

                return edwaldo.representacao();
                }
            catch (Exception e)
            {
                erro(e);
                return criarGrafo();
            }

        }

        static int criarAresta(int indexVertice, int arestasRestantes)
        {
            try
            {
                Console.WriteLine("#Arestas restantes: "+ arestasRestantes+"#");
                Console.WriteLine("Quantas arestas terá o vértice " + indiceLiteral[indexVertice] + "?");
                Console.Write("RESPOSTA: ");
                int qntArestas = Convert.ToInt32(Console.ReadLine());

                if (qntArestas > arestasRestantes || edwaldo.qntArestaVerticeValida(qntArestas) == false){
                    throw new Exception("Quantidade inválida, favor tente novamente");
                }

                int peso = 0;
                for (int j = 0; j < qntArestas; j++)
                {
                    Console.WriteLine("\nPeso da aresta " + (j + 1) + " - Vértice "+ indiceLiteral[indexVertice]);
                    Console.Write("RESPOSTA: ");
                    peso = Convert.ToInt32(Console.ReadLine());
                    edwaldo.addAresta(indexVertice, peso);
                }

                return arestasRestantes - qntArestas;
                }
            catch (Exception e)
            {
                erro(e);
                return criarAresta(indexVertice, arestasRestantes);

            }
        }

        public static void erro(Exception e)
        {
            Console.WriteLine("\n" + e);
            Console.WriteLine("(Pressione qualquer tecla para continuar)");
            Console.ReadKey();
            Console.Clear();
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
