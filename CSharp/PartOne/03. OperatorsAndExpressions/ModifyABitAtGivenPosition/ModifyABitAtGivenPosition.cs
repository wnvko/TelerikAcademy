namespace ModifyABitAtGivenPosition
{
    using System;

    public class ModifyABitAtGivenPosition
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter a position to replace (0 - 31): ");
            int p = int.Parse(Console.ReadLine());

            Console.Write("Enter what to put on position {0} - 0 or 1?: ", p);
            int v = int.Parse(Console.ReadLine());

            int mask = 1;
            mask <<= p;
            if (v == 1)
            {
                n |= mask;
                Console.WriteLine("Result is {0}", n);
            }
            else
            {
                mask = ~mask;
                n &= mask;
                Console.WriteLine("Result is {0}", n);
            }
        }
    }
}
