namespace CalculatSpecialDivisionTwo
{
    using System;

    public class CalculatSpecialDivisionTwo
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter K < N: ");
            int k = int.Parse(Console.ReadLine());

            double result = Factoriel(n) / (Factoriel(k) * Factoriel(n - k));
            Console.WriteLine(result);
        }

        private static double Factoriel(int n)
        {
            double result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
