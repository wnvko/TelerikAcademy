namespace PointInsideACircleAndOutsideOfARectangle
{
    using System;

    public class PointInsideACircleAndOutsideOfARectangle
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the abscise of the point X: ");
            float xOfPoint = float.Parse(Console.ReadLine());

            Console.Write("Enter the ordinate of the point Y: ");
            float yOfPoint = float.Parse(Console.ReadLine());

            bool pointIsInCircle = false;
            bool pointIsNotInRectangle = false;

            pointIsInCircle = (((xOfPoint - 1) * (xOfPoint - 1)) + ((yOfPoint - 1) * (yOfPoint - 1))) < 3 * 3;
            pointIsNotInRectangle = (xOfPoint < -1 || xOfPoint > 5) || (yOfPoint < -1 || yOfPoint > 1);

            if (pointIsInCircle && pointIsNotInRectangle)
            {
                Console.WriteLine("The point is within the circle K(1, 1), 3 and out of the rectangle [(-1,-1);(1,5)]");
            }
            else
            {
                Console.WriteLine("The point is not in the circle K(1, 1), 3 and out of the rectangle [(-1,-1);(1,5)]");
            }
        }
    }
}
