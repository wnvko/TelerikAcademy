namespace CirclePerimeterAndArea
{
    using System;

    public class CirclePerimeterAndArea
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the radius r= ");
            double r = double.Parse(Console.ReadLine());

            double area = r * r * Math.PI;
            double perimeter = 2 * r * Math.PI;

            Console.WriteLine("Circle with radius {0} has", r);
            Console.WriteLine("Perimeter = {0,5:F2}", perimeter);
            Console.WriteLine("Area = {0,10:F2}", area);
        }
    }
}
