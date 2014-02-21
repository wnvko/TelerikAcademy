namespace EuclidianCoordinates
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Path
    {
        private const string PathDefaultName = "PATH";

        private string pathDescription;
        private List<Point3D> pathList;

        // Constructors
        public Path()
        {
            this.PathDescription = PathDefaultName;
            this.pathList = new List<Point3D>();
        }

        public Path(Point3D point)
            : this()
        {
            this.pathList.Add(point);
        }

        public Path(Point3D[] points)
            : this()
        {
            this.pathList.AddRange(points);
        }

        public Path(string pathDescription, Point3D point)
            : this(point)
        {
            this.PathDescription = pathDescription;
        }

        public Path(string pathDescription, Point3D[] points)
            : this(points)
        {
            this.PathDescription = pathDescription;
        }

        // Properties
        public string PathDescription
        {
            get
            {
                return this.pathDescription;
            }

            set
            {
                if (value == null)
                {
                    value = PathDefaultName;
                }

                this.pathDescription = value;
            }
        }

        public int PathLenght
        {
            get { return this.pathList.Count; }
        }

        // Indexer
        public Point3D this[int index]
        {
            get
            {
                if (index < this.pathList.Count && index >= 0)
                {
                    return this.pathList[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Input index is out of range.");
                }
            }
        }

        // Methods
        public void AddPointsToPath(params Point3D[] points)
        {
            this.pathList.AddRange(points);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(this.PathDescription);
            output.Append(string.Format("\nPoint Number {0,4}{1,8}{2,8}\n", "X", "Y", "Z"));

            for (int i = 0; i < this.pathList.Count; i++)
            {
                output.Append(string.Format("Point {0,3}: {1}\n", i + 1, this.pathList[i].ToString()));
            }

            return output.ToString();
        }
    }
}