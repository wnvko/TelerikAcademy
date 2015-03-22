namespace _64BitArray
{
    using System;

    public class BitArrayTest
    {
        public static void Main(string[] args)
        {
            BitArray64 first = new BitArray64(255);
            Console.WriteLine(first);

            BitArray64 second = new BitArray64(255);
            Console.WriteLine(second);

            Console.WriteLine(first.Equals(second));
            Console.WriteLine(first != second);

            Console.WriteLine();
            second[60] = 1;
            Console.WriteLine(second);

            Console.WriteLine(first.Equals(second));
            Console.WriteLine(first == second);

            Console.WriteLine(first.GetHashCode());
            Console.WriteLine(second.GetHashCode());
        }
    }
}
