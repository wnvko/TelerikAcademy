namespace Geometry
{
    using System;
    public class Rectangle
    {
        public double width;
        public double height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public static Rectangle GetRotatedRectangle(
        Rectangle rectangle, double rotationAngle)
        {
            double rotatedWidth = Math.Abs(Math.Cos(rotationAngle)) * rectangle.width +
                              Math.Abs(Math.Sin(rotationAngle)) * rectangle.height;
            double rotatedHeight = Math.Abs(Math.Sin(rotationAngle)) * rectangle.width +
                               Math.Abs(Math.Cos(rotationAngle)) * rectangle.height;
            
            Rectangle rotatedRectangle = new Rectangle(rotatedWidth, rotatedHeight);
            return rotatedRectangle;
        }
    }
}
