/*
 * Write methods that calculate the surface of a triangle by given:
 *   - Side and an altitude to it;
 *   - Three sides;
 *   - Two sides and an angle between them;
 * Use System.Math.
 */

using System;

public class TriangleSurface
{
    public static void Main(string[] args)
    {
        CalculateAreaOfTriangle(10.0, 15.0);
        CalculateAreaOfTriangle(10.0, 15.0, 16.0);
        CalculateAreaOfTriangle(10.0, 15.0, 60);
    }

    public static void CalculateAreaOfTriangle(double side, double altitude)
    {
        double area = side * altitude / 2;
        Console.WriteLine("The area is {0}", area);
    }

    public static void CalculateAreaOfTriangle(double firstSide, double secondSide, double thirdSide)
    {
        double semiPerimeter = (firstSide + secondSide + thirdSide) / 2;
        double area = Math.Sqrt(semiPerimeter * (semiPerimeter - firstSide) * (semiPerimeter - secondSide) * (semiPerimeter - thirdSide));
        Console.WriteLine("The area is {0}", area);
    }

    public static void CalculateAreaOfTriangle(double firstSide, double secondSide, int angle)
    {
        double angleInRadians = angle * Math.PI / 180.0;
        double area = firstSide * secondSide * Math.Sin(angleInRadians) / 2;
        Console.WriteLine("The area is {0}", area);
    }
}
