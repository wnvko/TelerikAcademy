namespace BitArrayLong
{
    using System;

    public class BitArrayTest
    {
        static void Main(string[] args)
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
