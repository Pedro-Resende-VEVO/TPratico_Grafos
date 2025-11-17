namespace TP_Grafos
{
    public class FloydWarshal
    {
        private Grafo grafo;
        private int[,] distancia;

        private const int INF = 999999;

        public FloydWarshal(Grafo grafo)
        {
            this.grafo = grafo;
            distancia = new int[this.grafo.Lenght, this.grafo.Lenght];
        }

        public int[,] execucao(int origem)
        {
            // Inicializa matriz de distância com os pesos existentes
            for (int i = 0; i < grafo.Lenght; i++)
            {
                for (int j = 0; j < grafo.Lenght; j++)
                {
                    var p = ((Matriz)grafo).Peso(i, j);

                    if (i == j)
                        distancia[i, j] = 0;
                    else if (p != 0)
                        distancia[i, j] = p;
                    else
                        distancia[i, j] = INF;
                }
            }

            // Floyd-Warshall
            for (int k = 0; k < grafo.Lenght; k++)
            {
                for (int i = 0; i < grafo.Lenght; i++)
                {
                    for (int j = 0; j < grafo.Lenght; j++)
                    {
                        if (distancia[i, j] > distancia[i, k] + distancia[k, j])
                        {
                            distancia[i, j] = distancia[i, k] + distancia[k, j];
                        }
                    }
                }
            }

            return distancia;
        }
    }
}
