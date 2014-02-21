namespace CatalanNumbers
{
    using System;

    class CatalanNumbers
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
             * In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:
             * Cn = (2n over n) / (n + 1) = (2n)! / (n + 1)!n!
             * Write a program to calculate the Nth Catalan number by given N.
             */
            
            Console.Write("Enter first number: ");
            int inputNumber = int.Parse(Console.ReadLine());

            double catalanNumber = Factoriel(2 * inputNumber) / (Factoriel(inputNumber + 1) * Factoriel(inputNumber));
            Console.WriteLine("The {0} Catalan number is {1}", inputNumber, catalanNumber);
        }
    }
}
