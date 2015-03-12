namespace EuclidianSpace
{
    using System;
    using System.IO;

    public static class PathStorage
    {
        public static void SavePath(Path path, string fileName)
        {
            try
            {
                StreamWriter writer = new StreamWriter(fileName, false);
                using (writer)
                {
                    writer.Write(string.Format("{0}{1}", path.Name, Environment.NewLine));
                    writer.Write(string.Format("{0}{1}", path.PathLenght, Environment.NewLine));
                    for (int i = 0; i < path.PathLenght; i++)
                    {
                        writer.Write(string.Format("{0} {1} {2}{3}", path[i].X, path[i].Y, path[i].Z, Environment.NewLine));
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("You can not access file {0}", fileName);
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("File name cannot be empty string.");
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Wrong or incorect file name");
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Wrong or missing directory.");
                Console.WriteLine(e.Message);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine("Path name too long. Try other directory.");
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("File not saved.");
                Console.WriteLine(e.Message);
            }
        }

        public static Path OpenPath(string fileName)
        {
            Path output = new Path();
            try
            {
                StreamReader reader = new StreamReader(fileName);
                using (reader)
                {
                    output.Name = reader.ReadLine();

                    int pathLenght = int.Parse(reader.ReadLine());
                    for (int i = 0; i < pathLenght; i++)
                    {
                        string[] pointCoordinates = reader.ReadLine().Split(' ');
                        Point3D point = new Point3D();
                        point.X = double.Parse(pointCoordinates[0]);
                        point.Y = double.Parse(pointCoordinates[1]);
                        point.Z = double.Parse(pointCoordinates[2]);
                        output.AddPointsToPath(point);
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("File name cannot be empty string.");
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Wrong or incorect file name");
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Wrong or missing directory.");
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("File not saved.");
                Console.WriteLine(e.Message);
            }

            return output;
        }
    }
}
