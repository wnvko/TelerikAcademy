/*
 * You are given a sequence of positive integer values written
 * into a string, separated by spaces. Write a function that
 * reads these values from given string and calculates their sum.
 * Example: string = "43 68 9 23 318" -> result = 461
 */

namespace SumCalculator
{
    using System;

    public class SumCalculator
    {
        public static void Main()
        {
            Console.Write("Enter some integers separeted by intervals: ");
            string inputString = Console.ReadLine();

            int sum = 0;
            int number = 0;

            string[] numberAsString = inputString.Split(' ');
            foreach (var currentNumberAsText in numberAsString)
            {
                number = int.Parse(currentNumberAsText);
                sum += number;
            }

            Console.WriteLine("Total sum is {0}", sum);
        }
    }
}
