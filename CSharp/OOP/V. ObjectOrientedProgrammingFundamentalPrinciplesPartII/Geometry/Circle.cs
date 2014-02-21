namespace Geometry
{
    public class Circle : Shape
    {
        private const double Pi = 3.14159265358979;

        public Circle(double radius)
            : base(radius, radius)
        {
        }

        public override double CalculateSurface()
        {
            return Width * Height * Pi;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" (r = {0})",this.Width);
        }
    }
}