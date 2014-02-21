namespace SumOfInfinitRow
{
    using System;

    class SumOfInfinitRow
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

        //method calculate power of a number instead of using Mat.Pow
        static double Power(double number, int power)
        {
            if (power == 0)
            {
                return 1;
            }
            for (int i = 0; i < power; i++)
            {
                number *= number;
            }
            return number;
        }
        
        static void Main()
        {
            /*
            * Write a program that, for a given two integer numbers N and X,
             * calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N
            */

            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter X: ");
            int x = int.Parse(Console.ReadLine());
            double sum = 0;

            for (int i = 0; i <= n; i++)
            {
                sum = sum + Factoriel(i) / Power(x, i);
            }

            Console.WriteLine("The sum is {0}", sum);
        }
    }
}
