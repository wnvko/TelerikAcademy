namespace QuadraticEquation
{
    using System;

    public class QuadraticEquation
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the coefficients");

            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            double determinant = (b * b) - (4 * a * c);
            double firstRoot;
            double secondRoot;

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
