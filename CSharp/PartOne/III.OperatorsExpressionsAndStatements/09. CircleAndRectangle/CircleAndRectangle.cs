namespace CircleAndRectangle
{
    using System;

    class CircleAndRectangle
    {
        static void Main()
        {
            /*
             * Write an expression that checks for given point
             * (x, y) if it is within the circle K( (1,1), 3)
             * and out of the rectangle R(top=1, left=-1, width=6, height=2).
             */

            Console.Write("Enter the abcis of the point X: ");
            float xOfPoint = float.Parse(Console.ReadLine());
            Console.Write("Enter the ordinate of the point Y: ");
            float yOfPoint = float.Parse(Console.ReadLine());

            bool pointIsInCircle = false;
            bool pointIsNotInRectangle = false;
            
            //Check if point is in the circle
            pointIsInCircle = ((xOfPoint - 1) * (xOfPoint - 1) + (yOfPoint - 1) * (yOfPoint - 1)) < 3 * 3;


            //Check if point is outside the rectangle
            //Top left vertex is (-1, 1)
            //Bottom left vertex (-1, -1)
            //Top right vertex is (5, 1)
            //Bottom left vertex (5, -1)
            pointIsNotInRectangle = ((xOfPoint < -1 || xOfPoint > 5) || (yOfPoint < -1 || yOfPoint > 1));
            
            
            //print the result
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