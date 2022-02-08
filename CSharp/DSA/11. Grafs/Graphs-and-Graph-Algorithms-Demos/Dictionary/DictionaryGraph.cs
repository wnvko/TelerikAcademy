namespace Dictionary
{
    using System;
    using System.Collections.Generic;


    public class MainClass
    {
        public static void Main()
        {
            var graph = new DictionaryGraph<int>();
            graph.GetGraph();
        }
    }

    public class DictionaryGraph<T> where T : IComparable, IConvertible
    {
        public void GetGraph()
        {
            var graph = new Dictionary<T, List<T>>();

            string line = Console.ReadLine();
            while (line != string.Empty)
            {
                string[] connection = line.Split(' ');

                T first = (T)Convert.ChangeType(connection[0], typeof(T));
                T second = (T)Convert.ChangeType(connection[1], typeof(T));

                if (!graph.ContainsKey(first))
                {
                    graph[first] = new List<T>();
                }

                graph[first].Add(second);

                //// if incomment creates each node as bedirectional
                //if (!first.Equals(second))
                //{
                //    if (!graph.ContainsKey(second))
                //    {
                //        graph[second] = new List<T>();
                //    }

                //    graph[second].Add(first);
                //}

                line = Console.ReadLine();
            }

            foreach (var node in graph)
            {
                Console.Write(node.Key + " -> ");

                foreach (T neighbors in node.Value)
                {
                    Console.Write(neighbors + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
