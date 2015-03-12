namespace EuclidianSpace
{
    using System;

    public class Test
    {
        public static void Main()
        {
            Point3D coordinateBeginning = Point3D.O;
            Console.WriteLine(coordinateBeginning);

            Point3D firstPoint = new Point3D(3, 4, 3.75);
            Console.WriteLine(Distance.CalculateDistance(firstPoint, coordinateBeginning));

            Point3D[] samplePath = new Point3D[10];
            for (int i = 0; i < samplePath.Length; i++)
            {
                // calculate some strange coordinates just for testing
                double x = (3 * i * i) - (4 * i) - 5;
                double y = (i * i) - (2 * i) + 8;
                double z = (4 * i) - 10;
                samplePath[i] = new Point3D(x, y, z);
            }

            Path journey = new Path("My trip", samplePath);
            journey.AddPointsToPath(firstPoint);
            Console.WriteLine(journey);

            //Console.WriteLine(journey[15]); // Out of range exeption

            PathStorage.SavePath(journey, "test.txt");

            Path secondJourney = PathStorage.OpenPath("test.txt");

            // Path thirdJourney = PathStorage.OpenPath("tes.txt"); // File not found exception
        }
    }
}
