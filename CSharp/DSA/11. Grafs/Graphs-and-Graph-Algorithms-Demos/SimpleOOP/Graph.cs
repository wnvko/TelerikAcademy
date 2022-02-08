namespace DFSRecursiveOOPGraph
{
    using System.Collections.Generic;

    public class Graph<T>
    {
        public Graph(List<T>[] nodes)
        {
            this.ChildNodes = nodes;
        }

        public List<T>[] ChildNodes { get; set; }
    }
}
