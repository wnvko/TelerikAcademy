namespace CohesionAndCoupling
{
    public struct Point
    {
        private double x;
        private double y;
        private double z;
       
        public Point(double x, double y, double z = 0) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
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
    }
}