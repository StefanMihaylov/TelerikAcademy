namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
            : base(height, width)
        {

        }

        public override double CalculateSurface()
        {
            return this.Height * this.Width;
        }
    }
}
