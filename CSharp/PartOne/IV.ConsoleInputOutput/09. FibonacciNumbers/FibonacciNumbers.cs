namespace FibonacciNumbers
{
    using System;

    class FibonacciNumbers
    {
        static void Main()
        {
            /*
             * Write a program to print the first 100 members of the sequence of
             * Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
             */

            //the 100th Fibonacci number 16 008 811 023 750 101 250
            //fits only in ulong, float, double and decimal type
            ulong [] fibonacciNumbers = new ulong[100];
            
            //initialize fibonacci numbers N[i] = N[i-2] + N[i-1]
            fibonacciNumbers[0] = 0;
            fibonacciNumbers[1] = 1;
            for (int i = 2; i < fibonacciNumbers.Length; i++)
            {
                fibonacciNumbers[i] = fibonacciNumbers[i - 2] + fibonacciNumbers[i - 1];
            }

            //print out first 100 Fibonacci numbers
            for (int i = 0; i < fibonacciNumbers.Length; i++)
            {
                Console.WriteLine("The {0,3} Fibonacci number is {1,22}", (i + 1), fibonacciNumbers[i]);
            }
        }
    }
}
