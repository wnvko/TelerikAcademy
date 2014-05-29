namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Point pointA = new Point(1, -2);
            Point pointB = new Point(3, 4);
            double distanceAB = Utils.CalcDistance(pointA, pointB);
            Console.WriteLine("Distance in the 2D space = {0:f2}", distanceAB);

            Point pointM = new Point(5, 2, -1);
            Point pointN = new Point(3, -6, 4);
            double distanceMN = Utils.CalcDistance(pointM, pointN);
            Console.WriteLine("Distance in the 3D space = {0:f2}", distanceMN);

            Utils.Width = 3;
            Utils.Height = 4;
            Utils.Depth = 5;

            Console.WriteLine("Volume = {0:f2}", Utils.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Utils.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", Utils.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", Utils.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", Utils.CalcDiagonalYZ());
        }
    }
}