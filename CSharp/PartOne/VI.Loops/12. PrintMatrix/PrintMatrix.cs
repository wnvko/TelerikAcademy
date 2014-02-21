
namespace PrintMatrix
{
    using System;

    class PrintMatrix
    {
        static void Main()
        {
            /*
             * Write a program that reads from the console a positive integer
             * number N (N < 20) and outputs a matrix like the following:
             * N = 3
             * 1 2 3
             * 2 3 4
             * 3 4 5
             * 
             * N = 4
             * 1 2 3 4
             * 2 3 4 5
             * 3 4 5 6
             * 4 5 6 7
             */

            Console.Write("Enter a number: ");
            int inputNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= inputNumber; i++)
            {
                for (int j = i; j < (inputNumber + i); j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }
    }
}
