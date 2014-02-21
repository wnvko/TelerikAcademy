namespace Geometry
{
    public class Triangle : Shape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return Width * Height / 2;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" (w = {0}; h = {1})", this.Width, this.Height);
        }
    }
}
