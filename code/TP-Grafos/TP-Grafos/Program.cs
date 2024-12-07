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
            string grafoString;
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
                            distribuirArestas(G[1]);
                            Console.Clear();
                            Console.WriteLine("Parabéns! você acabou de criar um grafo no formato de " + edwaldo.formato);
                            Console.WriteLine("Sua representação pode ser vista abaixo:\n");
                            Console.WriteLine(edwaldo.representacao());
                            Console.WriteLine("\n(Aperte qualquer tecla para voltar ao menu)");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Antes de utilizarmos o grafo no formato DIMIC, criaremos um!!\n");
                            G = criarGrafo();
                            grafoString = criarDIMIC(G[0], G[1]);

                            Console.WriteLine("Parabéns! você acabou de criar um grafo no formato de " + edwaldo.formato);
                            Console.WriteLine("Sua representação padrão pode ser vista abaixo:\n");
                            Console.WriteLine(edwaldo.representacao());

                            Console.WriteLine("\nEnquanto sua representação DIMIC pode ser vista abaixo:\n");
                            Console.WriteLine(grafoString);
                            Console.WriteLine("\n(Aperte qualquer tecla para acessar o menu DIMIC)");
                            Console.ReadKey();
                            Console.Clear();
                            mainDIMAC();
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
                Console.WriteLine("1) Criar grafo \n2) Ler formato DIMAC  \n3) Sair");
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

        static void distribuirArestas(int M)
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

                edwaldo.representacao();
            }
            catch (Exception e)
            {
                erro(e);
                distribuirArestas(M);
            }
        }

        private static string criarDIMIC(int N, int M)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                int arestasRestantes = M;

                sb.AppendLine(N + " " + M);
                for (int v = 0; v <= N; v++)
                {
                    if (arestasRestantes > 0)
                    {
                        Console.WriteLine("\n#Arestas restantes: " + arestasRestantes + "#");
                        Console.WriteLine("Quantas arestas terá o vértice " + (v+1) + "?");
                        Console.Write("RESPOSTA: ");
                        int qntArestas = Convert.ToInt32(Console.ReadLine());

                        if (qntArestas > arestasRestantes || edwaldo.qntArestaVerticeValida(qntArestas) == false)
                        {
                            throw new Exception("Quantidade inválida, favor tente novamente");
                        }

                        arestasRestantes = arestasRestantes - qntArestas;
                        for (int j = 0; j < qntArestas; j++)
                        {
                            sb.AppendLine(arestaDIMIC(N, v));
                        }
                    }
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                erro(e);
                return criarDIMIC(N,M);
            }
        }

        private static string arestaDIMIC(int N, int v)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\nA areta irá incidir sob qual vértice?");
                Console.WriteLine("(Escolha entre o vértice 1 e vértice " + N + ")");
                Console.Write("RESPOSTA: ");
                int w = Convert.ToInt32(Console.ReadLine());
                edwaldo.verticeDestinoValido(w);

                Console.WriteLine("\nPeso da aresta\n(Entre vértice " + (v+1) + "  -> vértice " + (w + 1) + ")");
                Console.Write("RESPOSTA: ");
                int peso = Convert.ToInt32(Console.ReadLine());
                edwaldo.addAresta(v, w - 1, peso);

                return ((v + 1) + " " + (w + 1) + " " + peso);
            }
            catch (Exception e)
            {
                erro(e);
                return arestaDIMIC(N, v);
            }
        }

        static void mainDIMAC()
        {
            
            bool fim = false;
            do
            {
                try
                {
                    Aresta E;
                    int V;
                    int resp = menuDIMAC();
                    switch (resp)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("##- Arestas adjacentes a aresta A -##");
                            E = inputAresta();
                            Console.WriteLine(edwaldo.arestaAdjacente(E));
                            continuar();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("##- Vértices adjacentes ao vértice V -##");
                            E = inputAresta();
                            Console.WriteLine(edwaldo.verticeAdjacente(E));
                            continuar();
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("##- Arestas adjacentes a aresta A -##");
                            E = inputAresta();
                            Console.WriteLine(edwaldo.arestaAdjacente(E));
                            continuar();
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("##- Vértices adjacentes ao vértice V -##");
                            E = inputAresta();
                            Console.WriteLine(edwaldo.verticeAdjacente(E));
                            continuar();
                            break;

                        case 5:
                            Console.Clear();
                            Console.WriteLine("##- Grau do vértice V -##");
                            E = inputVertice();
                            Console.WriteLine(edwaldo.verticeAdjacente(E));
                            continuar();
                            break;

                        case 6:
                            Console.Clear();
                            Console.WriteLine("##- Verificar adjacência entre vértices V e W -##");
                            E = inputAresta();
                            Console.WriteLine(edwaldo.verticeAdjacente(E));
                            continuar();
                            break;

                        case 7:
                            Console.Clear();
                            Console.WriteLine("##- Substituir peso de aresta A -##");
                            E = inputAresta();
                            Console.WriteLine(edwaldo.arestaAdjacente(E));
                            continuar();
                            break;

                        case 8:
                            Console.Clear();
                            Console.WriteLine("##- Trocar vértice V e W de posição -##");
                            E = inputAresta();
                            Console.WriteLine(edwaldo.verticeAdjacente(E));
                            continuar();
                            break;

                        case 9:
                            Console.Clear();
                            Console.WriteLine("##- Busca em Largura -##");
                            V = inputVertice();
                            Console.WriteLine(edwaldo.buscaEmLargura(V));
                            continuar();
                            break;

                        case 10:
                            Console.Clear();
                            Console.WriteLine("##- Busca em Profundidade -##");
                            V = inputVertice();
                            Console.WriteLine(edwaldo.buscaEmProfundidade(V));
                            continuar();
                            break;

                        case 11:
                            Console.Clear();
                            Console.WriteLine("##- Algoritimo de Dijkistra -##");
                            E = inputAresta();
                            Console.WriteLine(edwaldo.verticeAdjacente(E));
                            continuar();
                            break;

                        case 12:
                            Console.Clear();
                            Console.WriteLine("##- Algoritimo de Floyd Warshall -##");
                            E = inputAresta();
                            Console.WriteLine(edwaldo.verticeAdjacente(E));
                            continuar();
                            break;

                        case 13:
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

        static int menuDIMAC()
        {
            try
            {
                Console.WriteLine("########- Menu de DIMAC -#######");
                Console.WriteLine("----Impressões:");
                Console.WriteLine(
                    "1) Arestas adjacentes a aresta \"A\" \n2) Vértices adjacentes a um vértice \"V\"" +
                       "\n3) Arestas incidentes a um vértice \"V\" \n4) Vértices incidentes a uma aresta \"A\"" +
                            "\n5) grau do vértice \"V\"");
                Console.WriteLine("----Operações:");
                Console.WriteLine(
                    "6) Dois vértices são adjacentes? \n7) Substituir peso de uma aresta \"A\"" +
                       "\n8) Trocar dois vértices");
                Console.WriteLine("----Buscas/Algoritimos:");
                Console.WriteLine(
                    "9) Busca em Largura \n10) Busca em Profundidade" +
                       "\n11) Algoritmo de Dijkstra \n12) Algoritmo de Floyd Warshal");
                Console.WriteLine("############################");
                Console.Write("ESCOLHA UMA OPÇÃO: ");
                int resp = Convert.ToInt32(Console.ReadLine());

                return (resp > 0 || resp <= 12) ? resp : throw new Exception("Opção indisponível, favor tente novamente");
            }
            catch (Exception e)
            {
                erro(e);
                return menuDIMAC();
            }
        }

        public static Aresta inputAresta()
        {
            try
            {
                Console.WriteLine("Qual dessas arestas deseja selecionar?");
                Aresta[] arestas = edwaldo.arestasDisponiveis();
                for (int i = 0; i < arestas.Count(); i++)
                {
                    Console.WriteLine((i+1) + ": " + arestas[i].toString());
                }
                Console.Write("ESCOLHA UMA OPÇÃO: ");
                int resp = Convert.ToInt32(Console.ReadLine());
                if (resp > arestas.Count() || resp < 0)
                {
                    throw new Exception("Aresta inválida, favor tentar novamente");
                }
                return arestas[resp];
            }
            catch (Exception e)
            {
                erro(e);
                return inputAresta();
            }
        }

        public static int inputVertice()
        {
            try
            {
                Console.WriteLine("Qual desses vértices deseja selecionar?");
                int[] vertices = edwaldo.verticesDisponiveis();
                for (int i = 0; i < vertices.Count(); i++)
                {
                    Console.WriteLine((i + 1) + ": (" + vertices[i] + ")");
                }
                Console.Write("ESCOLHA UMA OPÇÃO: ");
                int resp = Convert.ToInt32(Console.ReadLine());
                if (resp > vertices.Count() || resp < 0)
                {
                    throw new Exception("Aresta inválida, favor tentar novamente");
                }
                return vertices[resp];
            }
            catch (Exception e)
            {
                erro(e);
                return inputVertice();
            }
        }

        public static void continuar()
        {
            Console.WriteLine("(Pressione qualquer tecla para continuar)");
            Console.ReadKey();
            Console.Clear();
        }

        public static void erro(Exception e)
        {
            Console.WriteLine("\n" + e.Message);
            Console.WriteLine("(Pressione qualquer tecla para continuar)");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
