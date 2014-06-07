namespace Methods
{
    public struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        } 
   
        public override string ToString()
        {
            return "{" + this.X + ";" + this.Y + "}";
        }
    }
}
