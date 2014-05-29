namespace CohesionAndCoupling
{
    using System;

    public static class Utils
    {
        public static double Width { get; set; }

        public static double Height { get; set; }

        public static double Depth { get; set; }

        public static double CalcDistance(Point firstPoint, Point secondPoint)
        {
            double deltaX = firstPoint.X - secondPoint.X;
            double deltaY = firstPoint.Y - secondPoint.Y;
            double deltaZ = firstPoint.Z - secondPoint.Z;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
            return distance;
        }

        public static double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public static double CalcDiagonalXYZ()
        {
            Point firstPoint = new Point(0, 0, 0);
            Point secondPoint = new Point(Width, Height, Depth);

            double distance = CalcDistance(firstPoint, secondPoint);
            return distance;
        }

        public static double CalcDiagonalXY()
        {
            Point firstPoint = new Point(0, 0);
            Point secondPoint = new Point(Width, Height);

            double distance = CalcDistance(firstPoint, secondPoint);
            return distance;
        }

        public static double CalcDiagonalXZ()
        {
            Point firstPoint = new Point(0, 0);
            Point secondPoint = new Point(Width, Height);

            double distance = CalcDistance(firstPoint, secondPoint);
            return distance;
        }

        public static double CalcDiagonalYZ()
        {
            Point firstPoint = new Point(0, 0);
            Point secondPoint = new Point(Height, Depth);

            double distance = CalcDistance(firstPoint, secondPoint);
            return distance;
        }
    }
}