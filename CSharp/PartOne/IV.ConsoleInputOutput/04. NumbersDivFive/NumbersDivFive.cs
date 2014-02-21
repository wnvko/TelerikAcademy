namespace NumbersDivFive
{
    using System;

    class NumbersDivFive
    {
        static void Main()
        {
            /*
             * Write a program that reads two positive integer numbers and prints how many
             * numbers p exist between them such that the reminder of the division by 5 is 0 (inclusive).
             * Example: p(17,25) = 2.
             */

            Console.WriteLine("Please enter two integers:");
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            int count = 0;
                        
            count = Math.Abs((a - b) / 5);
            if ((b % 5 == 0) || (a % 5 == 0))
            {
                count++;
            }
            Console.WriteLine("Between {0} and {1} there are {2} diviseable by five.", a, b, count);
        }
    }
}
