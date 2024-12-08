using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    class Lista : Grafo
    {
        private List<Aresta>[] dados;
        //construtores da classe Lista
        public Lista(int N) :base(N)
        {
            dados = new List<Aresta>[N];
            for (int i = 0; i < N; i++)
            {
                dados[i] = new List<Aresta>();
            }
            formato = "Lista de Adjacência";

        }
        
        override public void addAresta(int V, int W, int peso)
        {
            dados[W].Add(new Aresta(V, W, peso));
        }

        override public bool indiceOcupado(int V, int W)
        {
            return (dados[W].Any(A => A.V == V) ? true : false);
        }

        override public Aresta[] arestasAdjacentes(Aresta a)
        {
            List<Aresta> arestasAdjacentes= new List<Aresta>();
            foreach(Aresta x in dados[a.V])
            {
                if (a.GetHashCode() != x.GetHashCode())
                {
                    arestasAdjacentes.Add(x);
                }
            }
            return arestasAdjacentes.ToArray();
        }

        override public int[] verticesAdjacentes(int v)
        {
            return dados[v].Select(aresta => aresta.W).ToArray();
        }

        override public Aresta [] arestasIncidentes(int v)
        {
            return dados[v].ToArray();
        }

        override public int[] verticesIncidentes(Aresta a)
        {
            return new int[] {a.V,a.W};
        }

        override public int grauEntrada(int v)
        {
            return dados[v].Count;
        }

        override public int grauSaida(int v)
        {
            int qnt = 0;
            foreach (List<Aresta> lista in dados)
            {
                qnt = qnt + lista.Count(a => a.V == v);
            }
            return qnt;
        }

        override public bool existeAdjacencia(int v, int w)
        {
            if(v <= 0 || w<=0 || v>= Lenght|| w>=Lenght)
            {
                return false; 
            }
            foreach(var aresta in dados[v])
            {
                if(aresta.W == w)
                {
                    return true;
                }
            }  
            foreach(var aresta in dados[w])
            {
                if(aresta.W == v)
                {
                    return true;
                }
            }
            return false;
        }

        override public Aresta substituirPeso(Aresta a,int peso)
        {
            if(a.peso <= 0 || peso <= 0)
            {
                throw new Exception("Inválido");
            }
            a.peso = peso;
            return a;
        }
        
        override public void substituirVertice(int v, int w) // o método troca as conexões entre os vértices, não os vértices em si(troca reversa)
        {
            if(v<=0||w<=0 || v>=Lenght||w>=Lenght)
            {
                Console.WriteLine("inválido")
                return;
            }
            for (int i = 0 ; i< dados.Lenght; i++)
            {
                Aresta aresta = dados[i][j] // criada a variável temporária pra facilitar o acesso 
                if(aresta.V == v) 
                {
                    aresta.V == w;
                }                       // é feita a troca de arestas de saída de v para w e vice-versa
                else if(aresta.V == w)
                {
                    aresta.V = v;
                }
                if(aresta.W == v)   //é feita a troca de arestas de entrada para v e w
                {
                    aresta.W = w;
                }
                else if( aresta.W == w)
                {
                    aresta.W =v;
                }
            }
            var temp = dados[v];
            dados[v]= dados[w];
            dados[w]= temp;
        }

        override public int[] vizinhos(int v)
        {
            return new int[1];
        }

        override public string toString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dados.Count(); i++)
            {
                sb.Append("|" + (i + 1) + "|");
                for (int j = 0; j < dados[i].Count(); j++)
                {
                    sb.Append(" -[" + dados[i][j].peso + "]-> |" + (dados[i][j].V + 1) + "|");
                }
                sb.AppendLine(" --x");
            }

            return sb.ToString();
        }

    }
}
//