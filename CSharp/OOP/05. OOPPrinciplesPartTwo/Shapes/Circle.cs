namespace Shapes
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
            return this.Width * this.Height * Pi;
        }

        public override string ToString()
        {
            return "Circle said:\n" + base.ToString() + string.Format(" (r = {0})", this.Width);
        }
    }
}
