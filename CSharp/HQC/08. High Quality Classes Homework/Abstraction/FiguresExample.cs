namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            Figure circle = new Circle(5);
            double circlePerimeter = circle.CalcPerimeter();
            double circleSurface = circle.CalcSurface();
            Console.WriteLine(
                "I am a circle. My perimeter is {0:f2}. My surface is {1:f2}.",
                circlePerimeter,
                circleSurface);

            Figure rect = new Rectangle(2, 3);
            double rectPerimeter = rect.CalcPerimeter();
            double rectSurface = rect.CalcSurface();
            Console.WriteLine(
                "I am a rectangle. My perimeter is {0:f2}. My surface is {1:f2}.",
                rectPerimeter,
                rectSurface);
        }
    }
}