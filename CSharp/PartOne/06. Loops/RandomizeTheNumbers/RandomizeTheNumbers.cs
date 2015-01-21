namespace RandomizeTheNumbers
{
    using System;
    using System.Collections.Generic;

    public class RandomizeTheNumbers
    {
        private static Random random = new Random();

        public static void Main(string[] args)
        {
            Console.Write("Enter n: ");
            int numbers = int.Parse(Console.ReadLine());
            List<int> allnumbers = new List<int>();

            for (int number = 0; number < numbers; number++)
            {
                allnumbers.Insert(random.Next(number), number);
            }

            Console.WriteLine(string.Join(" ", allnumbers.ToArray()));
        }
    }
}
