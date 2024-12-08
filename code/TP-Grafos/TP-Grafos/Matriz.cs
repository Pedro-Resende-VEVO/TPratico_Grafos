using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class Matriz : Grafo
    {
        private int[,] dados;
        //construtores da classe matriz
        public Matriz(int N) :base(N)
        {
            dados = new int[N, N];
            formato = "Matriz de Adjacência";
        }
        ///<summary>
        /// Adiciona uma Aresta ao grafo
        ///</summary>
        ///<param name ="V">int</param>
        ///<param name ="W">int</param>
        ///<return>Uma nova nova aresta com o V e o W </returns>
        override public void addAresta(int V, int W, int peso)
        {
            dados[V, W] = peso;
        }
        ///<summary>
        /// Verifica se dentro do grafo há uma aresta que conecta os vétrices V e W
        ///</summary>
        ///<param name ="V">int</param>
        ///<param name ="W">int</param>
        ///<return>Um booleano que indica se há uma aresta entre esses vértices ou não. </returns>
        override public bool indiceOcupado(int V, int W)
        {
            return (dados[V, W] != 0) ? true : false;
        }
        ///<summary>
        /// Mostra as arestas adjacentes a uma aresta passada pelo usuário
        ///</summary>
        ///<param name ="a">Aresta</param>
        ///<return>Um array com todas as arestas adjacentes </returns>
        override public Aresta[] arestasAdjacentes(Aresta a)
        {
            List<Aresta> adjacentes = new List<Aresta>();
            for (int i = 0; i < Lenght; i++)
            {
                if  (dados[a.V, i] != 0)
                {
                    adjacentes.Add(new Aresta(a.V, i, dados[a.V, i]));
                }
            }
            return adjacentes.ToArray();
        }
         ///<summary>
        /// Mostra os vértices adjacentes a um vértice passado pelo usuário
        ///</summary>
        ///<param name ="v">int</param>
        ///<return>Um array com todos os vértices adjacentes </returns>
        override public int[] verticesAdjacentes(int v)
        {
            List<int> adjacentes = new List<int>();
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[i, v] != 0)
                {
                    adjacentes.Add(i);
                }
            }
            return adjacentes.ToArray();
        }
        ///<summary>
        /// Mostra os vértices incidentes a um vértice passado pelo usuário
        ///</summary>
        ///<param name ="v">int</param>
        ///<return>Um array com todos os vértices adjacentes </returns>
        override public Aresta[] arestasIncidentes(int v)
        {
            List<Aresta> incidentes = new List<Aresta>();
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[i, v] != 0)
                {
                    incidentes.Add(new Aresta(i, v, dados[i, v]));// é criada a aresta com o i ,v e o peso da aresta
                }
            }
            return incidentes.ToArray();
        }
        ///<summary>
        /// Mostra os vértices incidentes a uma aresta passada pelo usuário
        ///</summary>
        ///<param name ="a">Aresta</param>
        ///<return>Um array com todos os vértices incidentes a aresta </returns>
        override public int[] verticesIncidentes(Aresta a)
        {
            List<int> incidentes = new List<int>();
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[i, a.V] != 0)
                {
                    incidentes.Add(dados[i, a.V]);
                }
            }
            return incidentes.ToArray();
        }
        ///<summary>
        /// Mostra o grau de entrada de um vértice passado por parâmetro
        ///</summary>
        ///<param name ="v">int</param>
        ///<return>O grau de entrada um vértice em formato int </returns>
        override public int grauEntrada(int v)
        {
            int grau = 0;
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[i, v] != 0)
                {
                    grau++;
                }
            }
            return grau;
        }
        ///<summary>
        /// Mostra o grau de saída de um vértice passado por parâmetro
        ///</summary>
        ///<param name ="v">int</param>
        ///<return>O grau de saída um vértice em formato int </returns>
        override public int grauSaida(int v)
        {
            int grau = 0;
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[v, i] != 0)
                {
                    grau++;
                }
            }
            return grau;
        }
        ///<summary>
        /// Mostra se há adjancencia de um vértice com outro
        ///</summary>
        ///<param name ="v">int</param>
        ///<param name ="w">int</param>
        ///<return>Um booleano confirmando se há ou não adjacencia </returns>
        override public bool existeAdjacencia(int v, int w)
        {
            return (dados[w, v] != 0 || dados[w, v] != 0) ? true : false;
        }
        ///<summary>
        /// Coloca um novo peso para uma aresta
        ///</summary>
        ///<param name ="a">Aresta</param>
        ///<param name ="pesoNovo">int</param>
        ///<return>Retorna a aresta com o novo peso </returns>
        override public Aresta substituirPeso(Aresta a, int pesoNovo)
        {
            dados[a.V, a.W] = pesoNovo;
            a.peso = pesoNovo;
            return a;
        }
        ///<summary>
        /// Substitui um vértice por outro mantendo as conexões
        ///</summary>
        ///<param name ="v">int</param>
        ///<param name ="w">int</param>
        override public void substituirVertice(int v, int w)
        {
            int valorTroca = 0;

            for (int i = 0; i < Lenght; i++)
            {
                valorTroca = dados[i, w];
                dados[i, w] = dados[i, v];
                dados[i, v] = valorTroca;

                valorTroca = dados[w, i];
                dados[w, i] = dados[v, i];
                dados[v, i] = valorTroca;
            }
        }
        ///<summary>
        /// Mostra todos os vizinhos de um vértice passado por parâmetro
        ///</summary>
        ///<param name ="v">int</param>
        ///<return>Um array com toda a vizinhança de um vértice</returns>
        override public int[] vizinhos(int v)
        {
            List<int> vizinhaca = new List<int>();
            for (int i = 0; i < Lenght; i++)
            {
                if (dados[v, i] != 0)
                {
                    vizinhaca.Add(i);
                }

            }
            return vizinhaca.ToArray();
        }
        ///<summary>
        /// Representação gráfica do grafo em formato de matriz
        ///</summary>
        ///<param name ="v">int</param>
        ///<return>Um array com toda a vizinhança de um vértice</returns>
        override public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  ");
            for (int i = 0; i < Lenght; i++)
            {
                sb.Append((i + 1) + " ");
            }

            sb.AppendLine();
            for (int i = 0; i < Lenght; i++)
            {
                sb.Append(i + 1 + "|");
                for (int j = 0; j < Lenght; j++)
                {
                    sb.Append(dados[i,j] + "|");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

    }
}
