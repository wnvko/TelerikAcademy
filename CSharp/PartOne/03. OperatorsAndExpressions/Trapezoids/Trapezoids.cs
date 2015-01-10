namespace Trapezoids
{
    using System;

    public class Trapezoids
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter side a: ");
            double sideA = double.Parse(Console.ReadLine());

            Console.Write("Enter side b: ");
            double sideB = double.Parse(Console.ReadLine());

            Console.Write("Enter height h: ");
            double height = double.Parse(Console.ReadLine());

            double area = (sideA + sideB) * height / 2;
            Console.WriteLine("The area of trapezoid is {0}", area);
        }
    }
}
