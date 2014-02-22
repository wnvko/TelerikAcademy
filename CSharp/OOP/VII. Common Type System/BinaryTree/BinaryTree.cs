namespace BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : ICloneable where T : IComparable<T>
    {
        private TreeNode<T> root;

        #region Constructors
        public BinaryTree()
        {
            this.Root = null;
        }
        #endregion

        #region Properties
        public TreeNode<T> Root
        {
            get { return this.root; }
            set { this.root = value; }
        }
        #endregion

        #region Methods
        public void Insert(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Node cannot be null.");
            }

            this.Root = Insert(value, null, Root);
        }

        private TreeNode<T> Insert(T value, TreeNode<T> parentNode, TreeNode<T> node)
        {
            if (node == null)
            {
                node = new TreeNode<T>(value);
                node.Parent = parentNode;
            }
            else
            {
                int compareTo = value.CompareTo(node.Value);
                if (compareTo < 0)
                {
                    node.LeftChild = Insert(value, node, node.LeftChild);
                }
                else if (compareTo > 0)
                {
                    node.RightChild = Insert(value, node, node.RightChild);
                }
            }

            return node;
        }

        public TreeNode<T> Find(T value)
        {
            TreeNode<T> node = this.Root;
            while (node != null)
            {
                int compareTo = value.CompareTo(node.Value);
                if (compareTo < 0)
                {
                    node = node.LeftChild;
                }
                else if (compareTo > 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        public void Remove(T value)
        {
            TreeNode<T> nodeToDelete = this.Find(value);
            if (nodeToDelete == null)
            {
                return;
            }

            Remove(nodeToDelete);
        }

        private void Remove(TreeNode<T> node)
        {
            if (node.LeftChild != null && node.RightChild != null)
            {
                TreeNode<T> replacement = node.RightChild;
                while (replacement.LeftChild != null)
                {
                    replacement = replacement.LeftChild;
                }

                node.Value = replacement.Value;
                node = replacement;
            }

            TreeNode<T> theChild = node.LeftChild != null ? node.LeftChild : node.RightChild;
            if (theChild != null)
            {
                theChild.Parent = node.Parent;

                if (node.Parent == null)
                {
                    root = theChild;
                }
                else
                {
                    if (node.Parent.LeftChild == node)
                    {
                        node.Parent.LeftChild = theChild;
                    }
                    else
                    {
                        node.Parent.RightChild = theChild;
                    }
                }
            }
            else
            {
                if (node.Parent == null)
                {
                    root = null;
                }
                else
                {
                    if (node.Parent.LeftChild == node)
                    {
                        node.Parent.LeftChild = theChild;
                    }
                    else
                    {
                        node.Parent.RightChild = theChild;
                    }
                }
            }
        }

        private string Print(TreeNode<T> node, int tabs)
        {
            var printedTree = new StringBuilder();
            var printedTreeLeftChild = new StringBuilder();
            var printedTreeRightChilde = new StringBuilder();
            if (node != null)
            {
                printedTree.AppendLine(node.ToString());
                tabs += 2;
                if (node.LeftChild != null)
                {
                    printedTreeLeftChild.Append(new String('>', tabs));
                    printedTreeLeftChild.AppendLine(Print(node.LeftChild, tabs));
                }

                if (node.RightChild != null)
                {
                    printedTreeRightChilde.Append(new string('>', tabs));
                    printedTreeRightChilde.AppendLine(Print(node.RightChild, tabs));
                }

                if (printedTreeLeftChild != null)
                {
                    printedTree.Append(printedTreeLeftChild.ToString());

                }

                if (printedTreeRightChilde != null)
                {
                    printedTree.Append(printedTreeRightChilde.ToString());
                }
            }

            return printedTree.ToString().Trim();
        }

        private List<T> ListValues(TreeNode<T> original)
        {
            BinaryTree<T> copy = new BinaryTree<T>();
            List<T> treeValues = new List<T>();
            List<T> leftTreeValues = new List<T>();
            List<T> rightTreeValues = new List<T>();
            if (original != null)
            {
                treeValues.Add(original.Value);
                if (original.LeftChild != null)
                {
                    leftTreeValues.AddRange(ListValues(original.LeftChild));
                }

                if (original.RightChild != null)
                {
                    rightTreeValues.AddRange(ListValues(original.RightChild));
                }

                treeValues.AddRange(leftTreeValues);
                treeValues.AddRange(rightTreeValues);
            }

            return treeValues;
        }


        #endregion

        #region Overrided methods
        public override string ToString()
        {
            return Print(this.Root, 0);
        }

        public override bool Equals(object obj)
        {
            List<T> original = ListValues(this.Root);
            List<T> compare = ListValues(((BinaryTree<T>)obj).Root);

            if (original.Count != compare.Count)
            {
                return false;
            }

            for (int i = 0; i < original.Count; i++)
            {
                if (original[i].CompareTo(compare[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            List<T> hashList = ListValues(this.Root);
            int hashValue = 0;
            foreach (var item in hashList)
            {
                hashValue ^= item.GetHashCode();
            }

            return hashValue;
        }

        public static bool operator ==(BinaryTree<T> first, BinaryTree<T> second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BinaryTree<T> first, BinaryTree<T> second)
        {
            return !first.Equals(second);
        }
        #endregion

        public object Clone()
        {
            List<T> treeValues = new List<T>();
            treeValues.AddRange(ListValues(this.Root));

            BinaryTree<T> clonedTree = new BinaryTree<T>();
            foreach (var value in treeValues)
            {
                clonedTree.Insert(value);
            }

            return clonedTree;
        }

    }
}
