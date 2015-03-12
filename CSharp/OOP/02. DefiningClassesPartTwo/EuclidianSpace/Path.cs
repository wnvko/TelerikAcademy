namespace EuclidianSpace
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Path
    {
        private const string PathDefaultName = "PATH";

        private string name;
        private List<Point3D> points;

        // Constructors
        public Path()
        {
            this.Name = PathDefaultName;
            this.points = new List<Point3D>();
        }

        public Path(Point3D point)
            : this()
        {
            this.points.Add(point);
        }

        public Path(Point3D[] points)
            : this()
        {
            this.points.AddRange(points);
        }

        public Path(string name, Point3D point)
            : this(point)
        {
            this.Name = name;
        }

        public Path(string name, Point3D[] points)
            : this(points)
        {
            this.Name = name;
        }

        // Properties
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    value = PathDefaultName;
                }

                this.name = value;
            }
        }

        public int PathLenght
        {
            get { return this.points.Count; }
        }

        // Indexer
        public Point3D this[int index]
        {
            get
            {
                if (index < this.points.Count && index >= 0)
                {
                    return this.points[index];
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
            this.points.AddRange(points);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(this.Name);
            output.Append(string.Format("\nPoint Number {0,4}{1,8}{2,8}\n", "X", "Y", "Z"));

            for (int i = 0; i < this.points.Count; i++)
            {
                output.Append(string.Format("Point {0,3}: {1}\n", i + 1, this.points[i].ToString()));
            }

            return output.ToString();
        }
    }
}
