namespace BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BinarySearchTreeTest
    {
        public static Random rnd = new Random();
        
        public static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();

            for (int i = 0; i < 10; i++)
            {
                binaryTree.Insert(rnd.Next(100));
            }

            BinaryTree<int> copy = new BinaryTree<int>();
            copy = (BinaryTree<int>)binaryTree.Clone();
            Console.WriteLine(copy);

            Console.WriteLine(binaryTree);
            for (int i = 0; i < 30; i++)
            {
                binaryTree.Remove(i);
            }
            Console.WriteLine();
            Console.WriteLine(binaryTree);
            Console.WriteLine();
            Console.WriteLine(binaryTree.GetHashCode());
        }
    }
}
