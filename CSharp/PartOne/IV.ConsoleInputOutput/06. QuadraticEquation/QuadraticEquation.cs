namespace QuadraticEquation
{
    using System;

    class QuadraticEquation
    {
        static void Main()
        {
            /*
             * Write a program that reads the coefficients a, b and c of a quadratic
             * equation ax2+bx+c=0 and solves it (prints its real roots).
             */

            Console.WriteLine("Please enter the coeficients");
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            double determinant;
            double firstRoot;
            double secondRoot;
            determinant = b * b - 4 * a * c;
            if (determinant < 0)
            {
                Console.WriteLine("There are no real roots");
            }
            else
            {
                if (determinant == 0)
                {
                    firstRoot = (-b) / (2 * a);
                    Console.WriteLine("There is one real root");
                    Console.WriteLine("X1 = X2 = {0}", firstRoot);
                }
                else
                {
                    firstRoot = (-b + Math.Sqrt(determinant)) / (2 * a);
                    secondRoot = (-b - Math.Sqrt(determinant)) / (2 * a);
                    Console.WriteLine("There are two real roots");
                    Console.WriteLine("X1 = {0}", firstRoot);
                    Console.WriteLine("X2 = {0}", secondRoot);
                }
            }

        }
    }
}
