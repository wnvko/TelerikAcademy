namespace SumOfNNumbers
{
    using System;

    class SumOfNNumbers
    {
        static void Main()
        {
            /*
             * Write a program that gets a number n and after that gets
             * more n numbers and calculates and prints their sum.
             */

            Console.Write("Please enter a number: ");
            int n = int.Parse(Console.ReadLine());
            double[] numbers = new double[n];
            double sumOfNumbers = 0;
            for (int i = 0; i < n; i++)
            {
                Console.Write("Please enter number N{0}: ", (i + 1));
                numbers[i] = double.Parse(Console.ReadLine());
                sumOfNumbers += numbers[i];
            }
            Console.WriteLine("\nSum of all numbers is {0}", sumOfNumbers);
        }
    }
}
