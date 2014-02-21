namespace CalculateNDividedK
{
    using System;

    class Program
    {
        //method calculate factoriel of a number
        static double Factoriel(double number)
        {
            double result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
        
        static void Main()
        {
            /*
             * Write a program that calculates N!/K! for given N and K (1<K<N).
             */

            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter K < N: ");
            int k = int.Parse(Console.ReadLine());
            double result = Factoriel(n) / Factoriel(k);
            Console.WriteLine("{0}! / {1}! = {2}", n, k, result);
        }
    }
}
