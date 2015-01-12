namespace SumOfNNumbers
{
    using System;
    using System.Linq;

    public class SumOfNNumbers
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter a number: ");

            int numbersCount = int.Parse(Console.ReadLine());
            double[] numbers = new double[numbersCount];

            for (int number = 0; number < numbersCount; number++)
            {
                Console.Write("Please enter number N{0}: ", number + 1);
                numbers[number] = double.Parse(Console.ReadLine());
            }

            double sumOfNumbers = numbers.Sum(n => n);
            Console.WriteLine("\nSum of all numbers is {0}", sumOfNumbers);
        }
    }
}
