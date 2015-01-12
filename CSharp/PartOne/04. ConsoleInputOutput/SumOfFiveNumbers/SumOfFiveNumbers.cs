namespace SumOfFiveNumbers
{
    using System;
    using System.Linq;

    public class SumOfFiveNumbers
    {
        public const int NumbersCount = 5;

        public static void Main(string[] args)
        {
            double[] numbers = new double[NumbersCount];

            for (int number = 0; number < NumbersCount; number++)
            {
                Console.Write("Please enter number N{0}: ", number + 1);
                numbers[number] = double.Parse(Console.ReadLine());
            }

            double sumOfNumbers = numbers.Sum(c => c);
            Console.WriteLine("\nSum of all numbers is {0}", sumOfNumbers);
        }
    }
}
