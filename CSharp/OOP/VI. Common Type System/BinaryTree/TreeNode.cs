namespace BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T> : IComparable<TreeNode<T>> where T : IComparable<T>
    {
        private T value;
        private TreeNode<T> parent;
        private TreeNode<T> leftChild;
        private TreeNode<T> rightChild;

        #region Constructors
        public TreeNode(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.LeftChild = null;
            this.RightChild = null;
        }
        #endregion

        #region Properties
        public T Value
        {
            get { return this.value; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Tree nod cannot be null.");
                }

                this.value = value;
            }
        }

        public TreeNode<T> Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                this.parent = value;
            }
        }

        public TreeNode<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                this.leftChild = value;
            }
        }

        public TreeNode<T> RightChild
        {
            get
            {
                return this.rightChild;
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                this.rightChild = value;
            }
        }
        #endregion

        #region IComparable methods
        public int CompareTo(TreeNode<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }
        #endregion

        #region Overrided methods
        public override string ToString()
        {
            return this.value.ToString();
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            TreeNode<T> other = (TreeNode<T>)obj;
            return this.CompareTo(other) == 0;
        }
        #endregion
    }
}
