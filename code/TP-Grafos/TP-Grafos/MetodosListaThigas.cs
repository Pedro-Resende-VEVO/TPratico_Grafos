//  List<Dictionary<int,int>> Grafo = new List<Dictionary<int,int>>();
public int[] ImprimirArestasAdjacentes(int v,int w)
{
    int[] arestasAdjacentes= new int[Length];
    if(w>= 0 && w < Lenght)
    {
        for(int i = 0  ; i < Lenght;i++)
        {
            if(dados[w,i]!= 0 && dados[w,i] != dados[v,w])
            {
                arestasAdjacentes.Append(dados[w,i]);
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
   return dados[v].ToArray();
}

public int [] ImprimirArestasIncidentes(int v, int w)
{
    int[] arestasIncidentes = new int[Lenght];
    if(w>=0 && w< Lenght)
    {
        for(int i = 0 ; i< Lenght;i++)
        {
            if(dados[w,i]!=0 && dados[w,i] != dados[v,w])
            {
                arestasIncidentes.Append(dados[w,i]);
            }

        }
        return arestasIncidentes;
    }
}

// public int[] ImprimirVerticesIncidentes(int v)
// {
//     if(v<=0 || v >= Lenght)
//     {
//         return new int[0];
//     }
//    return dados[v].ToArray();
// }

public int ImprimirGrau(int v)
{
    if(v==0 || v>Lenght)
    {
        return 0;
    }
    return dados[v].Count;
}
public bool VerificarAdjacencia(int v, int w)
{
    if(v == 0 || w==0 || v> Lenght|| w>Lenght)
    {
        return false;
    }
    return dados[v].Contains(w)|| dados[w].Contains(v);  
}
public void SubstituirPeso(Aresta a)
{
}
