namespace Geometry
{
    using System;

    class Test
    {
        static void Main()
        {
            var shapes = new Shape[5];
            shapes[0] = new Circle(12);
            shapes[1] = new Rectangle(12, 6);
            shapes[2] = new Triangle(12, 8);
            shapes[3] = new Circle(8);
            shapes[4] = new Triangle(14, 5);

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }
            Console.WriteLine();
        }
    }
}
