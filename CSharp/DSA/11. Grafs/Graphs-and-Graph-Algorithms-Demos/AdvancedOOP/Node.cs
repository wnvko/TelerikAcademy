namespace AdvancedOOP
{
    using System;
    using System.Collections.Generic;

    public class Node<T>
    {
        private readonly IList<Edge<T>> connections;

        public Node(T name)
        {
            this.Name = name;
            this.connections = new List<Edge<T>>();
        }

        public T Name { get; private set; }

        public IEnumerable<Edge<T>> Connections
        {
            get { return this.connections; }
        }

        public void AddConnection(Node<T> targetNode, double distance, bool twoWay)
        {
            if (targetNode == null)
            {
                throw new ArgumentNullException("targetNode");
            }

            if (targetNode == this)
            {
                throw new ArgumentException("Node may not connect to itself.");
            }

            if (distance <= 0)
            {
                throw new ArgumentException("Distance must be positive.");
            }

            this.connections.Add(new Edge<T>(targetNode,distance));
            if (twoWay)
            {
                targetNode.AddConnection(this, distance, false);
            }
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}