namespace CalculateFactoriels
{
    using System;

    class CalculateFactoriels
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
             * Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
             */
            
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter K < N: ");
            int k = int.Parse(Console.ReadLine());
            double result = (Factoriel(n) * Factoriel(k)) / (Factoriel(n - k));
            Console.WriteLine("{0}! * {1}! / ({0} - {1})! = {2}", n, k, result);
        }
    }
}
