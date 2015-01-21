namespace RandomNumbersInGivenRange
{
    using System;

    public class RandomNumbersInGivenRange
    {
        private static Random random = new Random();

        public static void Main(string[] args)
        {
            Console.Write("Enter n: ");
            int numbers = int.Parse(Console.ReadLine());

            Console.Write("Enter min: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Enter max: ");
            int max = int.Parse(Console.ReadLine());

            for (int number = 0; number < numbers; number++)
            {
                Console.Write("{0} ", random.Next(min, max + 1));
            }

            Console.WriteLine();
        }
    }
}
