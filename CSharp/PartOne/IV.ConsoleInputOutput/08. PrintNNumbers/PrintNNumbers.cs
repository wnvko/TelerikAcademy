namespace PrintNNumbers
{
    using System;

    class PrintNNumbers
    {
        static void Main()
        {
            /*
             * Write a program that reads an integer number n from the console and prints
             * all the numbers in the interval [1..n], each on a single line.
             */
            
            Console.Write("Please enter a number: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}", (i + 1));
            }
        }
    }
}
