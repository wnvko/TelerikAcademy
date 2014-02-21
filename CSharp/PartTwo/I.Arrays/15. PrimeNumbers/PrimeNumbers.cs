/*
 * Write a program that finds all prime numbers in the range [1...10 000 000].
 * Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
 */

namespace PrimeNumbers
{
    using System;
    using System.Collections.Generic;

    class PrimeNumbers
    {
        static void Main()
        {
            //input
            int maxValue = 10000000;
            int[] values = new int[maxValue + 1];
            bool[] isPrime = new bool[maxValue + 1];
            for (int index = 0; index <= maxValue; index++)
            {
                values[index] = index;
                isPrime[index] = true;
            }

            //calculations
            List<int> primeNumbers = new List<int>();
            int iterations = (int)Math.Sqrt(maxValue);

            for (int index = 2; index < iterations; index++)
            {
                if (isPrime[index])
                {
                    for (int marker = 2; marker < maxValue / index; marker++)
                    {

                        isPrime[index * marker] = false;
                    }
                }
            }

            //output
            Console.WriteLine();
            for (int index = 0; index < maxValue; index++)
            {
                if (isPrime[index])
                {
                    Console.Write("{0}, ", index);
                }
            }
        }
    }
}