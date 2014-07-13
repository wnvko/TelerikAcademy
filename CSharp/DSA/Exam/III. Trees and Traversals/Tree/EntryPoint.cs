namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        private static Dictionary<string, Node> theTree = new Dictionary<string, Node>();

        public static void Main()
        {
            TakeEntryData();

            // a. Find the root.
            FindTheRoot();

            // b. Find all leaf nodes.
            FindAllLeaves();

            // c. Find all middle nodes.
            FindAllMidleNodes();

            // d. Find the longets path in the tree.
            int maxPath = 0;
            foreach (var node in theTree)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node.Value));
            }

            Console.WriteLine("\nThe longest path is {0} steps.\n", maxPath);

            // e. Find all paths in the tree with given sum S of their nodes.
            int targetSum = 6;
            foreach (var node in theTree)
            {
                List<Node> path = new List<Node>();
                FindPathsWithSumS(node.Value, 0, targetSum, path);
            }
        }

        public static void TakeEntryData()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                string entryLine = Console.ReadLine();
                string[] nodes = entryLine.Split(' ');

                if (!theTree.ContainsKey(nodes[0]))
                {
                    Node parent = new Node(nodes[0]);
                    theTree.Add(nodes[0], parent);
                }

                if (!theTree.ContainsKey(nodes[1]))
                {
                    Node child = new Node(nodes[1]);
                    theTree.Add(nodes[1], child);
                }

                theTree[nodes[0]].AddChild(theTree[nodes[1]]);
            }
        }

        public static void FindTheRoot()
        {
            foreach (var node in theTree)
            {
                if (!node.Value.HasPArent)
                {
                    Console.WriteLine("The root of the tree is {0}", node.Key);
                    break;
                }
            }
        }

        public static void FindAllLeaves()
        {
            List<Node> leaves = new List<Node>();

            foreach (var node in theTree)
            {
                if (node.Value.NumberOfChilds == 0)
                {
                    leaves.Add(node.Value);
                }
            }

            Console.WriteLine("\nList of all leaves:");
            foreach (var leaf in leaves)
            {
                Console.Write("{0}, ", leaf.Name);
            }

            Console.WriteLine();
        }

        public static void FindAllMidleNodes()
        {
            List<Node> middleNodes = new List<Node>();

            foreach (var node in theTree)
            {
                if (node.Value.NumberOfChilds > 0 && node.Value.HasPArent)
                {
                    middleNodes.Add(node.Value);
                }
            }

            Console.WriteLine("\nList of all middle nodes:");
            foreach (var midleNode in middleNodes)
            {
                Console.Write("{0}, ", midleNode.Name);
            }

            Console.WriteLine();
        }

        public static int FindLongestPath(Node curentNode)
        {
            int currentPath = 0;

            if (curentNode.NumberOfChilds == 0)
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < curentNode.NumberOfChilds; i++)
                {
                    currentPath = Math.Max(FindLongestPath(curentNode[i]), currentPath);
                }

                return ++currentPath;
            }
        }

        public static void FindPathsWithSumS(Node currentNode, int sum, int targetSum, List<Node> path)
        {
            int valueOfNode = int.Parse(currentNode.Name);
            path.Add(currentNode);
            sum += valueOfNode;

            if (sum == targetSum)
            {
                Console.Write("Target sum of {0} =", targetSum);
                foreach (var node in path)
                {
                    Console.Write(" {0}", node.Name);
                }

                Console.WriteLine();
                return;
            }

            if (currentNode.NumberOfChilds > 0)
            {
                for (int i = 0; i < currentNode.NumberOfChilds; i++)
                {
                    FindPathsWithSumS(currentNode[i], sum, targetSum, path);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }


    }
}