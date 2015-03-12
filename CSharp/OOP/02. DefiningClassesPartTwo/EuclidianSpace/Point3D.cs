namespace EuclidianSpace
{
    using System;

    public struct Point3D
    {
        private static readonly Point3D Oxyz = new Point3D(0, 0, 0);

        private double x;
        private double y;
        private double z;

        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D O
        {
            get { return Oxyz; }
        }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public override string ToString()
        {
            string output = string.Format("[{0,7:F2}, {1,6:F2}, {2,6:F2}]", this.X, this.Y, this.Z);
            return output;
        }
    }
}
