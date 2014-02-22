namespace BinaryTree
{
    using System;

    public class BinaryTreeTest
    {
        public static Random rnd = new Random();
        static void Main()
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
