namespace Problem01
{
    using System;

    class Problem01
    {
        static void Main()
        {
            int[] array = new int[20];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
                array[i] *= 5;
                Console.WriteLine("Element {0} is {1}", i, array[i]);
            }
        }
    }
}
