using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static Dictionary<Node, List<Connection>> TheGraph = new Dictionary<Node, List<Connection>>();

    public static void Main(string[] args)
    {
        var startingPoints = GetInput();
        double minPath = double.MaxValue;
        var bestH = new Node(0);

        for (int i = 0; i < startingPoints.Count; i++)
        {
            Dijkstra.DijkstraAlgorithm(TheGraph, startingPoints[i]);
            double curentPathLenght = 0;
            for (int j = 0; j < TheGraph.Count; j++)
            {
                curentPathLenght += TheGraph.Keys.Where(g => g.Id == j + 1).FirstOrDefault().DijkstraDistance;
            }

            for (int l = 0; l < startingPoints.Count; l++)
            {
                curentPathLenght -= startingPoints[l].DijkstraDistance;
            }

            if (curentPathLenght < minPath)
            {
                minPath = curentPathLenght;
                bestH = startingPoints[i];
            }

            //for (int k = 0; k < TheGraph.Count; k++)
            //{
            //    //Console.Write("Distance from {0} to {1} ", startingPoints[i].Id, k + 1);
            //    Console.WriteLine(TheGraph.Keys.Where(g => g.Id == k + 1).FirstOrDefault().DijkstraDistance);
            //}
        }

        Console.WriteLine(minPath);
    }

    private static List<Node> GetInput()
    {
        string[] inputElementsCountNMH = Console.ReadLine().Split(' ');

        int hospitalsH = int.Parse(inputElementsCountNMH[2]);
        int streetsM = int.Parse(inputElementsCountNMH[1]);
        int housesN = int.Parse(inputElementsCountNMH[0]) - hospitalsH;

        string[] hospitalsListInput = Console.ReadLine().Split(' ');
        List<Node> hospitals = new List<Node>();

        // adding nodes to Graph
        for (int i = 0; i < housesN + hospitalsH; i++)
        {
            Node currentNode = new Node(i + 1);
            TheGraph[currentNode] = new List<Connection>();
        }

        // adding hospitals to list
        for (int i = 0; i < hospitalsListInput.Length; i++)
        {
            hospitals.Add(TheGraph.Keys.Where(g => g.Id == int.Parse(hospitalsListInput[i])).FirstOrDefault());
        }


        // adding connections to graph
        for (int i = 0; i < streetsM; i++)
        {
            string[] connectionsFSD = Console.ReadLine().Split(' ');
            Node firstNodeF = TheGraph.Keys.Where(g => g.Id == int.Parse(connectionsFSD[0])).FirstOrDefault();
            Node secondNodeS = TheGraph.Keys.Where(g => g.Id == int.Parse(connectionsFSD[1])).FirstOrDefault();
            double pathLenghtD = double.Parse(connectionsFSD[2]);

            TheGraph[firstNodeF].Add(new Connection(secondNodeS, pathLenghtD));
            TheGraph[secondNodeS].Add(new Connection(firstNodeF, pathLenghtD));
        }

        return hospitals;
    }
}


public class Node : IComparable
{
    public Node(int id)
    {
        this.Id = id;
    }

    public int Id { get; private set; }

    public double DijkstraDistance { get; set; }

    public bool Visited { get; set; }

    public int CompareTo(object obj)
    {
        if (!(obj is Node))
        {
            return -1;
        }

        return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
    }
}

public class PriorityQueue<T> where T : IComparable
{
    private T[] heap;
    private int index;

    public PriorityQueue()
    {
        this.heap = new T[16];
        this.index = 1;
    }

    public int Count
    {
        get
        {
            return this.index - 1;
        }
    }

    public void Enqueue(T element)
    {
        if (this.index >= this.heap.Length)
        {
            this.IncreaseArray();
        }

        this.heap[this.index] = element;

        int childIndex = this.index;
        int parentIndex = childIndex / 2;
        this.index++;

        while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
        {
            T swapValue = this.heap[parentIndex];
            this.heap[parentIndex] = this.heap[childIndex];
            this.heap[childIndex] = swapValue;

            childIndex = parentIndex;
            parentIndex = childIndex / 2;
        }
    }

    public T Dequeue()
    {
        T result = this.heap[1];

        this.heap[1] = this.heap[this.Count];
        this.index--;

        int rootIndex = 1;

        while (true)
        {
            int leftChildIndex = rootIndex * 2;
            int rightChildIndex = (rootIndex * 2) + 1;

            if (leftChildIndex > this.index)
            {
                break;
            }

            int minChild;
            if (rightChildIndex > this.index)
            {
                minChild = leftChildIndex;
            }
            else
            {
                if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    minChild = rightChildIndex;
                }
            }

            if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
            {
                T swapValue = this.heap[rootIndex];
                this.heap[rootIndex] = this.heap[minChild];
                this.heap[minChild] = swapValue;

                rootIndex = minChild;
            }
            else
            {
                break;
            }
        }

        return result;
    }

    public T Peek()
    {
        return this.heap[1];
    }

    private void IncreaseArray()
    {
        var copiedHeap = new T[this.heap.Length * 2];

        for (int i = 0; i < this.heap.Length; i++)
        {
            copiedHeap[i] = this.heap[i];
        }

        this.heap = copiedHeap;
    }
}

public class Connection
{
    public Connection(Node node, double distance)
    {
        this.Node = node;
        this.Distance = distance;
    }

    public Node Node { get; set; }

    public double Distance { get; set; }
}

public class Dijkstra
{
    public static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
    {
        var queue = new PriorityQueue<Node>();

        foreach (var node in graph)
        {
            node.Key.DijkstraDistance = double.PositiveInfinity;
            node.Key.Visited = false;
        }

        source.DijkstraDistance = 0.0d;
        queue.Enqueue(source);
        source.Visited = true;

        while (queue.Count != 0)
        {
            var currentNode = queue.Dequeue();
            currentNode.Visited = true;

            if (double.IsPositiveInfinity(currentNode.DijkstraDistance))
            {
                break;
            }

            foreach (var neighbor in graph[currentNode])
            {
                var potDistance = currentNode.DijkstraDistance + neighbor.Distance;
                if (potDistance < neighbor.Node.DijkstraDistance)
                {
                    neighbor.Node.DijkstraDistance = potDistance;
                    if (!neighbor.Node.Visited)
                    {
                        queue.Enqueue(neighbor.Node);
                    }
                }
            }
        }
    }
}