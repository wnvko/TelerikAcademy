namespace NumbersNotDivisibleByThreeAndSevent
{
    using System;

    public class NumbersNotDivisibleByThreeAndSeven
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                bool isDivisibleToThreeandSeven = (i % 3 == 0) && (i % 7 == 0);
                if (!isDivisibleToThreeandSeven)
                {
                    Console.Write("{0} ", i);
                }
            }

            Console.WriteLine();
        }
    }
}
