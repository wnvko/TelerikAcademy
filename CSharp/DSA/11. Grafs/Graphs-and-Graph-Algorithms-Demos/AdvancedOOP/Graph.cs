namespace AdvancedOOP
{
    using System.Collections.Generic;
    using System.Text;

    public class Graph<T>
    {
        public Graph()
        {
            this.Nodes = new Dictionary<T, Node<T>>();
        }

        internal IDictionary<T, Node<T>> Nodes { get; private set; }

        public void AddNode(T name)
        {
            var node = new Node<T>(name);
            this.Nodes.Add(name, node);
        }

        public void AddConnection(T fromNode, T toNode, int distance, bool twoWay)
        {
            this.Nodes[fromNode].AddConnection(this.Nodes[toNode], distance, twoWay);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var node in this.Nodes)
            {
                result.Append(node.Key + " -> ");

                foreach (var connection in node.Value.Connections)
                {
                    result.Append(connection.Target + "-" + connection.Distance + " ");
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
