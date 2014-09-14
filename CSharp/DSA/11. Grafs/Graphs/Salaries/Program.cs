using System;
using System.Collections.Generic;

public class Program
{
    public static Node[] TheGraph;

    public static void Main(string[] args)
    {
        GetInput();
        ulong? totalSalary = 0l;

        foreach (var node in TheGraph)
        {
            totalSalary += node.Salary;
        }

        Console.WriteLine(totalSalary);
    }

    private static void GetInput()
    {
        int C = int.Parse(Console.ReadLine());
        TheGraph = new Node[C];
        for (int i = 0; i < C; i++)
        {
            TheGraph[i] = new Node(i);
        }

        for (int i = 0; i < C; i++)
        {
            string curentBosses = Console.ReadLine();
            for (int j = 0; j < C; j++)
            {
                if (curentBosses[j] == 'Y')
                {
                    TheGraph[i].ChildNodes.Add(TheGraph[j]);
                }
            }
        }
    }
}

public class Node
{
    private ulong? salary;
    public Node(int id)
    {
        this.Id = id;
        this.ChildNodes = new List<Node>();
        this.salary = null;
    }

    public int Id { get; private set; }

    public List<Node> ChildNodes { get; set; }

    public ulong? Salary
    {
        get
        {
            if (this.salary != null)
            {
                return this.salary;
            }

            if (this.ChildNodes.Count > 0)
            {
                this.salary = 0;
                foreach (var child in ChildNodes)
                {
                    this.salary += child.Salary;
                }
            }
            else
            {
                this.salary = 1;
            }

            return salary;
        }
    }
}