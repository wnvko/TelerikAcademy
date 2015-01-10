namespace Rectangles
{
    using System;

    public class Rectangles
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the width of the rectangle: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Enter the height of the rectangle: ");
            double height = double.Parse(Console.ReadLine());
            double rectangleArea = height * width;
            double rectanglePerimeter = (height + width) * 2;
            Console.WriteLine("The area of the rectangle is {0}", rectangleArea);
            Console.WriteLine("The perimeter of the rectangle is {0}", rectanglePerimeter);
        }
    }
}
