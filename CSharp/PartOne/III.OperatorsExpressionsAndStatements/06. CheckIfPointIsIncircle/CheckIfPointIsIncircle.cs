namespace CheckIfPointIsIncircle
{
    using System;

    class CheckIfPointIsIncircle
    {
        static void Main()
        {
            /*
             * Write an expression that checks if given point
             * (x,  y) is within a circle K(O, 5).
             */

            Console.Write("Enter the abcis of the point X: ");
            float xOfPoint = float.Parse(Console.ReadLine());
            Console.Write("Enter the ordinate of the point Y: ");
            float yOfPoint = float.Parse(Console.ReadLine());

            //all the points within the cicle are x^2 + y^2 < r^2
            bool isWithinCircle = (xOfPoint * xOfPoint) + (yOfPoint * yOfPoint) < 5 * 5;

            if (isWithinCircle)
            {
                Console.WriteLine("The point is within the circle K(0,5)");
            }
        }
    }
}