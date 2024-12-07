//  List<Dictionary<int,int>> Grafo = new List<Dictionary<int,int>>();
public Aresta[] ImprimirArestasAdjacentes(Aresta a)
{
    Aresta[] arestasAdjacentes= new Aresta[Length];
    if(a.W >= 0 && a.W < Lenght)
    {
        for(int i = 0  ; i < Lenght;i++)
        {
            if(dados[w][i].peso != null && dados[w][i].peso != dados[v][w].peso )
            {
                arestasAdjacentes.Append(dados[w][i]);
            }
        }
    }
    return arestasAdjacentes;
}

public int[] ImprimirVerticesAdjacente(int v)
{
    if(v<=0 || v >= Lenght)
    {
        return new int[0];
    }
   return dados[v].Select(aresta => aresta.W).ToArray();
}

public Aresta [] ImprimirArestasIncidentes(int v)
{
    Aresta[] arestasIncidentes = new int[Lenght];
    if(w>=0 && w< Lenght)
    {
        return new Aresta[0];      
    }
    return dados[v].ToArray();
}

public int[] ImprimirVerticesIncidentes(Aresta a)
{
    
    if(a.V<=0 || a.W<=0 ||a.V >= Lenght|| a.W >=Lenght)
    {
        return new int[0];
    }

   return new int[] {a.V,a.W};
}

public int ImprimirGrau(int v)
{
    if(v<=0 || v>Lenght)
    {
        return 0;
    }
    return dados[v].Count;
}
public bool VerificarAdjacencia(int v, int w)
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
public void SubstituirPeso(Aresta a,int pesoaresta)
{
    if(a.peso <=null || pesoaresta <= null)
    {
        Console.WriteLine("Inválido")
        return;
    }
        a.peso = pesoaresta;
}

public void TrocarVertices(int v,int w) // o método troca as conexões entre os vértices, não os vértices em si(troca reversa)
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


public static string BuscaEmLarguraListaDirecionado(int v)
{
    int[]L = new int[Lenght];
    int[]nivel = new int[Lenght];
    int[] pai = new int[Lenght];
    StringBuilder caminho = new StringBuilder;
    Queue<int> fila = new Queue<int>();

    for(int i = 0; i<grafo.Lenght;i++)
    {
        L[i]=0;
        nivel=0;
        pai[i]= null;
    }
    for(int i = 0; i < Lenght;i++)
    {
        L[i]=0;
        nivel
    }
}
public int[]
