namespace FibonacciNumbers
{
    using System;

    public class FibonacciNumbers
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter a number: ");

            int numbersCount = int.Parse(Console.ReadLine());

            ulong[] fibonacciNumbers = new ulong[numbersCount];

            fibonacciNumbers[0] = 0;
            fibonacciNumbers[1] = 1;

            for (int number = 2; number < numbersCount; number++)
            {
                fibonacciNumbers[number] = fibonacciNumbers[number - 2] + fibonacciNumbers[number - 1];
            }

            for (int i = 0; i < fibonacciNumbers.Length; i++)
            {
                Console.WriteLine("The {0,3} Fibonacci number is {1,22}", i + 1, fibonacciNumbers[i]);
            }
        }
    }
}
