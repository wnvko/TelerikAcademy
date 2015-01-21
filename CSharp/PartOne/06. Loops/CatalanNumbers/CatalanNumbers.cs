namespace CatalanNumbers
{
    using System;

    public class CatalanNumbers
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int inputNumber = int.Parse(Console.ReadLine());

            double catalanNumber = Factoriel(2 * inputNumber) / (Factoriel(inputNumber + 1) * Factoriel(inputNumber));
            Console.WriteLine(catalanNumber);
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
