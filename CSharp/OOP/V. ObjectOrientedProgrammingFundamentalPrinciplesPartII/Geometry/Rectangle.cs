namespace Geometry
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return Width * Height;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" (w = {0}; h = {1})", this.Width, this.Height);
        }
    }
}
