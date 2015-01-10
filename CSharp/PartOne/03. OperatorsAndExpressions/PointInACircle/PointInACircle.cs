namespace PointInACircle
{
    using System;

    public class PointInACircle
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the abscise of the point X: ");
            float xOfPoint = float.Parse(Console.ReadLine());
            Console.Write("Enter the ordinate of the point Y: ");
            float yOfPoint = float.Parse(Console.ReadLine());

            bool isWithinCircle = (xOfPoint * xOfPoint) + (yOfPoint * yOfPoint) < 5 * 5;

            if (isWithinCircle)
            {
                Console.WriteLine("The point is within the circle K(0,5)");
            }
            else
            {
                Console.WriteLine("The point is not within the circle K(0,5)");
            }
        }
    }
}
