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

public int[] ImprimirVerticesIncidentes(int v)
{
    if(v<=0 || v >= Lenght)
    {
        return new int[0];
    }
   return dados[v].ToArray();
}
public