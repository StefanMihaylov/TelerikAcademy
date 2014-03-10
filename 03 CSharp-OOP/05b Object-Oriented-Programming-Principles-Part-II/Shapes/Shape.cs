namespace Shapes
{
    public abstract class Shape
    {
        public double Height { get; private set; }
        public double Width { get; private set; }

        public Shape(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public abstract double CalculateSurface();

        public override string ToString()
        {
            return string.Format("Shape {0}, Height {1}, Width {2}, Surface: {3:f3}",
                this.GetType().Name, this.Height, this.Width, this.CalculateSurface());
        }
    }
}
