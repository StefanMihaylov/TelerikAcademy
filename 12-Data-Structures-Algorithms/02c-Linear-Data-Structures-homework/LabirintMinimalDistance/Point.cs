namespace LabirintMinimalDistance
{
    public class Point
    {
        public Point(int x, int y, int value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }

        public Point(Point other)
            : this(other.X, other.Y, other.Value)
        {
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Value { get; set; }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Value);
        }
    }
}
