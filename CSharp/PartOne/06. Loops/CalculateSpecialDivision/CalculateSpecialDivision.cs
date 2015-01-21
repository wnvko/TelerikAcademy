namespace CalculateSpecialDivision
{
    using System;

    public class CalculateSpecialDivision
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter K < N: ");
            int k = int.Parse(Console.ReadLine());

            double result = Factoriel(n) / Factoriel(k);
            Console.WriteLine(result);
        }

        private static double Factoriel(double number)
        {
            double result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
