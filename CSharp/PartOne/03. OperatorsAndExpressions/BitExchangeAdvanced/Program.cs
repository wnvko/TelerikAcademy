namespace BitExchangeAdvanced
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            int buffer = number;
            Console.Write("Enter p: ");
            int p = int.Parse(Console.ReadLine());
            
            Console.Write("Enter q: ");
            int q = int.Parse(Console.ReadLine());
            
            Console.Write("Enter k: ");
            int k = int.Parse(Console.ReadLine());
            
            int leftBit;
            int rightBit;

            for (int i = 0; i < k; i++)
            {
                leftBit = ((number >> (q + i)) & 1) == 0 ? 0 : 1;
                rightBit = ((number >> (p + i)) & 1) == 0 ? 0 : 1;

                if (leftBit != rightBit)
                {
                    number = (leftBit == 0) ? (number + (1 << (q + i)) - (1 << (p + i))) : (number - (1 << (q + i)) + (1 << (p + i)));
                }
            }

            Console.WriteLine("If you change bits {0}..{1} with bits {2}..{3} of {4} the result is {5}", p, p + k - 1, q, q + k - 1, buffer, number);
        }
    }
}