namespace EuclidianCoordinates
{
    using System;

    public static class Distance
    {
        public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            double deltaX = firstPoint.X - secondPoint.X;
            double deltaY = firstPoint.Y - secondPoint.Y;
            double deltaZ = firstPoint.Z - secondPoint.Z;

            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ));

            return distance;
        }
    }
}
