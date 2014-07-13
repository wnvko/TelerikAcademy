
namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Node
    {
        private string name;
        private List<Node> children;
        private bool hasParent;
        private int numberOfChilds;

        public Node(string name)
        {
            this.Name = name;
            this.children = new List<Node>();
            this.HasPArent = false;
            this.NumberOfChilds = 0;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Node this[int index]
        {
            get { return children[index]; }
        }

        public bool HasPArent
        {
            get { return this.hasParent; }
            set { this.hasParent = value; }
        }

        public int NumberOfChilds
        {
            get { return this.numberOfChilds; }
            private set { this.numberOfChilds = value; }
        }

        public void AddChild(Node child)
        {
            this.children.Add(child);
            child.HasPArent = true;
            NumberOfChilds++;
        }
    }
}
