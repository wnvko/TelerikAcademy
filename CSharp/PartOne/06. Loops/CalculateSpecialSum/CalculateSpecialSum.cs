namespace CalculateSpecialSum
{
    using System;

    public class CalculateSpecialSum
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter X: ");
            int x = int.Parse(Console.ReadLine());

            double result = 1;
            int factorial = 1;

            for (int i = 1; i < n + 1; i++)
            {
                factorial *= i;
                result += factorial / Math.Pow(x, i);
            }

            Console.WriteLine("{0:n5}", result);
        }
    }
}
