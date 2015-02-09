/*
 * Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class PrimeNumbers
{
    public static void Main(string[] args)
    {
        int maxValue = 10000000;
        int[] values = new int[maxValue + 1];
        bool[] prime = new bool[maxValue + 1];

        for (int index = 0; index <= maxValue; index++)
        {
            values[index] = index;
            prime[index] = true;
        }

        List<int> primeNumbers = new List<int>();
        double iterations = Math.Sqrt(maxValue);

        for (int index = 2; index < iterations; index++)
        {
            if (prime[index])
            {
                for (int marker = 2; marker < maxValue / index; marker++)
                {
                    prime[index * marker] = false;
                }
            }
        }

        string outputFile = "primeNumbers.txt";
        using (StreamWriter sw = new StreamWriter(outputFile))
        {
            for (int index = 0; index < maxValue; index++)
            {
                if (prime[index])
                {
                    sw.Write(string.Format("{0}, ", index));
                }
            }
        }

        Process.Start(outputFile);
    }
}
