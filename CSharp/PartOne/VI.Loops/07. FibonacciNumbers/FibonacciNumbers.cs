namespace FibonacciNumbers
{
    using System;

    

    class FibonacciNumbers
    {
        //calculates Nth Fibonacci number
        static double FibonacciNumber(int input)
        {
            if (input == 0)
            {
                return 0.0;
            }
            if (input == 1)
            {
                return 1.0;
            }
            double fibonacciN2 = 0;
            double fibonacciN1 = 1;
            double fibonacciN = 0;
            for (int i = 1; i < input; i++)
			{
                fibonacciN = fibonacciN2 + fibonacciN1;
                fibonacciN2 = fibonacciN1;
                fibonacciN1 = fibonacciN;
			}
            return fibonacciN;
        }

        static void Main()
        {
            /*
             * Write a program that reads a number N and calculates the sum of
             * the first N members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
             * Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.
             */

            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            double sumOfFibonacci = 0;
            Console.Write("0 ");

            for (int i = 1; i <= n; i++)
            {
                sumOfFibonacci = sumOfFibonacci + FibonacciNumber(i);
                Console.Write("+ {0} ", FibonacciNumber(i));
            }
            Console.WriteLine("= {0}", sumOfFibonacci);
        }
    }
}
