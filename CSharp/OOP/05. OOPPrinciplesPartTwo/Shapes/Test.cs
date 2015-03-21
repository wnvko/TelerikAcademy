namespace Shapes
{
    using System;
    using System.Collections.Generic;

    public static class Test
    {
        public static void Main()
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Circle(12));
            shapes.Add(new Rectangle(12, 6));
            shapes.Add(new Triangle(12, 8));
            shapes.Add(new Circle(8));
            shapes.Add(new Triangle(14, 5));

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);
            }

            Console.WriteLine();
        }
    }
}
