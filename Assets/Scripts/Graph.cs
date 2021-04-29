


using System.Collections.Generic;

public class Node<T>
{
    private T _data;

    public Node(T data)
    {
        _data = data;
    } 
}


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



public abstract class Graph<T,D>
{
    private Node<T>[] _nodes;
    private Edge<T,D>[] _edges;

    public abstract void addNode();

    public abstract void removeNode();


    public abstract void addEdge();

    public abstract void removeEdge();

}
