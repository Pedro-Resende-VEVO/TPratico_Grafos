//  List<Dictionary<int,int>> Grafo = new List<Dictionary<int,int>>();
public List<(int origem, int destino, int peso)> EncontrarArestasAdjacentes(int v,int w)
{
    var arestasAdjacentes= new List<(int origem,int destino, int peso);
    if(v>= 0 && v<= grafo.Count)
    {
        foreach(var destino in grafo[v])
        {
            if(destino.Key != w)
            {
                arestasAdjacentes.Add((v,destino.Key,destino.Value));
            }
        }
    }
    if(w>=0 && w<= grafo.Count )
    {
        for(int i = 0 ;i<grafo.Count;i++)
        {
            if(grafo[i].ContainsKey(w) && i != v)
            {
                arestasAdjacentes.Add(i,w,grafo[i][w])
            }
        }
    }
    return arestasAdjacentes;
}

public List<(int vertice)> EncontrarVerticeAdjacente(int v)
{
    var verticesAdjacentes= new List<(int vertice);
    if()
}