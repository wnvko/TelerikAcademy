namespace RectangleArea
{
    using System;

    class RectangleArea
    {
        static void Main()
        {
            /*
             * Write an expression that calculates rectangle’s
             * area by given width and height.
             */

            Console.Write("Enter the width of the rectangle: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Enter the height of the rectangle: ");
            double height = double.Parse(Console.ReadLine());
            double rectangleArea = height * width;
            Console.WriteLine("The area of the rectangle is {0}", rectangleArea);
        }
    }
}
