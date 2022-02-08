namespace Kruskal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Program
    {
        private static Random r = new Random();
        public static void Main()
        {
            const int NumberOfNodes = 6;
            List<Edge> edges = new List<Edge>();

            InitializeGraph(edges);

            edges.Sort();

            int[] tree = new int[NumberOfNodes + 1]; //we start from 1, not from 0
            var mpd = new List<Edge>();
            int treesCount = 1;

            treesCount = FindMinimumSpanningTree(edges, tree, mpd, treesCount);

            PrintMinimumSpanningTree(mpd);
        }

        private static void InitializeGraph(List<Edge> edges)
        {
            GenerateEdges(5, edges);
            //edges.Add(new Edge(1, 6, 1));
            //edges.Add(new Edge(2, 3, 2));
            //edges.Add(new Edge(5, 6, 3));
            //edges.Add(new Edge(3, 4, 4));
            //edges.Add(new Edge(1, 5, 5));
            //edges.Add(new Edge(2, 4, 5));
            //edges.Add(new Edge(4, 5, 6));
        }

        private static void GenerateEdges(int count, List<Edge> edges)
        {
            if (count == 0) return;

            for (int i = 0; i < count; i++)
            {
                edges.Add(new Edge(count, i, r.Next(1, 9)));
            }
            GenerateEdges(count - 1, edges);
        }

        private static int FindMinimumSpanningTree(List<Edge> edges, int[] tree, List<Edge> mpd, int treesCount)
        {
            foreach (var edge in edges)
            {
                if (tree[edge.StartNode] == 0) // not visited
                {
                    if (tree[edge.EndNode] == 0) // both ends are not visited
                    {
                        tree[edge.StartNode] = tree[edge.EndNode] = treesCount;
                        treesCount++;
                    }
                    else
                    {
                        // attach the start node to the tree of the end node
                        tree[edge.StartNode] = tree[edge.EndNode];
                    }
                    mpd.Add(edge);
                }
                else // the start is part of a tree
                {
                    if (tree[edge.EndNode] == 0)
                    {
                        //attach the end node to the tree;
                        tree[edge.EndNode] = tree[edge.StartNode];
                        mpd.Add(edge);
                    }
                    else if (tree[edge.EndNode] != tree[edge.StartNode]) // combine the trees
                    {
                        int oldTreeNumber = tree[edge.EndNode];

                        for (int i = 0; i < tree.Length; i++)
                        {
                            if (tree[i] == oldTreeNumber)
                            {
                                tree[i] = tree[edge.StartNode];
                            }
                        }
                        mpd.Add(edge);
                    }
                }
            }
            return treesCount;
        }

        private static void PrintMinimumSpanningTree(IEnumerable<Edge> usedEdges)
        {
            foreach (var edge in usedEdges)
            {
                Console.WriteLine(edge);
            }
        }
    }
}