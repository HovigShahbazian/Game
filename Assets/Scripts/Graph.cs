
using UnityEngine;

using System.Collections.Generic;
using System;

[Serializable]
public class Node<T>
{
    [SerializeField]
    private T _data;

    public Node(T data)
    {
        _data = data;
    } 
}

[Serializable]
public class Edge<T,D>
{
    private Node<T> _start;
    private Node<T> _end;
    private int _weight;

    private List<D> _data;

    public Edge(Node<T> nodeA, Node<T> nodeB, int weight = -1)
    {
        _start = nodeA;
        _end = nodeB;
        _weight = weight;
    }
}


[Serializable]
public abstract class Graph<T,D>
{
   
    public abstract void AddNode(T Node);

    public abstract void RemoveNode(T Node);

    public abstract void GetNode(T Node);


    public abstract void AddEdge(D Edge);

    public abstract void RemoveEdge(D Edge);


    public abstract void GetEdge(D Edge);


}

[Serializable]
public class TownGraph 
{
    
    public Town[] _nodes;

  
    public TownInteraction[] _edges;


    public void AddEdge(TownInteraction Edge)
    {
        
    }

    public void AddNode(Town Node)
    {
        
    }

    public void GetEdge(TownInteraction Edge)
    {
       
    }

    public void GetNode(Town Node)
    {
 
    }

    public void RemoveEdge(TownInteraction Edge)
    {

    }

    public void RemoveNode(Town Node)
    {
       
    }
}