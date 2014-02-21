namespace NumberBitCheck
{
    using System;

    class NumberBitCheck
    {
        static void Main()
        {
            /*
             * Write an expression that extracts from a given integer
             * i the value of a given bit number b. Example: i=5; b=2 -> value=1.
             */

            Console.Write("Enter a number: ");
            int i = int.Parse(Console.ReadLine());
            Console.Write("Enter a possition to check (0 - 31): ");
            int b = int.Parse(Console.ReadLine());
            int mask = 1;
            mask <<= b;
            int vWithMask = i & mask;
            if (vWithMask > 0)
            {
                Console.WriteLine("The {0}th position of {1} is 1", b, i);
            }
            else
            {
                Console.WriteLine("The {0}th position of {1} is 0", b, i);
            }
        }
    }
}
