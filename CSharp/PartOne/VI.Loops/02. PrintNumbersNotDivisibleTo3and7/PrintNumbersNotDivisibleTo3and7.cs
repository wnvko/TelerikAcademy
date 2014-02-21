namespace PrintNumbersNotDivisibleTo3and7
{
    using System;

    class PrintNumbersNotDivisibleTo3and7
    {
        static void Main()
        {
            /*
             * Write a program that prints all the numbers from 1 to N,
             * that are not divisible by 3 and 7 at the same time.
             */
            
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                bool isDivisibleTo3and7 = (i % 3 == 0) && (i % 7 == 0);
                if (!isDivisibleTo3and7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}