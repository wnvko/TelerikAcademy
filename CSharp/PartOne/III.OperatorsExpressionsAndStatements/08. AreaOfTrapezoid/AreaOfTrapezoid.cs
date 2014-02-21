namespace AreaOfTrapezoid
{
    using System;

    class AreaOfTrapezoid
    {
        static void Main()
        {
            /*
             * Write an expression that calculates trapezoid's
             * area by given sides a and b and height h.
             */

            Console.Write("Enter side a: ");
            double sideA = double.Parse(Console.ReadLine());
            Console.Write("Enter side b: ");
            double sideB = double.Parse(Console.ReadLine());
            Console.Write("Enter height h: ");
            double height = double.Parse(Console.ReadLine());

            double area = (sideA + sideB) * height / 2;
            Console.WriteLine("The area of trapezoid is {0}",area);
        }
    }
}
