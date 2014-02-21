/*
 * Write a program that prints from given array of integers all numbers that
 * are divisible by 7 and 3. Use the built-in extension methods and lambda
 * expressions. Rewrite the same with LINQ.
 */

using System;
using System.Linq;

namespace DivisibleToThreeAnsSeven
{
    public class DivisibleToThreeAnsSeven
    {
        public static void Main()
        {
            int[] numbers = new int[15];
            DivisibleToThreeAnsSeven.AddRandomNumbers(numbers);

            Console.WriteLine("Initial numbers:");
            foreach (var number in numbers)
            {
                Console.Write(number+" ");
            }
            Console.WriteLine();

            Console.WriteLine("Special numbers:");
            var specialNumbers = numbers.Where(number => (number % 7 == 0 || number % 3 == 0));
            foreach (var number in specialNumbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        public static void AddRandomNumbers(int[] numbers)
        {
            Random rnd = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(1, 101);
            }
        }
    }
}