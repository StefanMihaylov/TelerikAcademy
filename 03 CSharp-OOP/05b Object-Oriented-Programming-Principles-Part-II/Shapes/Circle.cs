namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double diameter)
            : base(diameter, diameter)
        {

        }

        public override double CalculateSurface()
        {
            double radius = this.Height / 2;
            return System.Math.PI * radius * radius;
        }

        public override string ToString()
        {
            return string.Format("Shape {0}, Diameter {1}, Surface: {2:f3}",
                this.GetType().Name, this.Height, this.CalculateSurface());
        }
    }
}
