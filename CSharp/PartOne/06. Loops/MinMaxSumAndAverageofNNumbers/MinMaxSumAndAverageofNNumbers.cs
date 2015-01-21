namespace MinMaxSumAndAverageofNNumbers
{
    using System;

    public class MinMaxSumAndAverageofNNumbers
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the count of numbers: ");
            int countOfNumbers = int.Parse(Console.ReadLine());

            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;
            int sum = 0;
            double average = 0;

            for (int number = 0; number < countOfNumbers; number++)
            {
                Console.Write("Enter number {0}: ", number + 1);
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber > maxNumber)
                {
                    maxNumber = currentNumber;
                }

                if (currentNumber < minNumber)
                {
                    minNumber = currentNumber;
                }

                sum += currentNumber;
            }

            Console.WriteLine("min = {0}", minNumber);
            Console.WriteLine("max = {0}", maxNumber);
            Console.WriteLine("sum = {0}", sum);
            Console.WriteLine("avg = {0:n2}", ((double)sum) / countOfNumbers);
        }
    }
}
