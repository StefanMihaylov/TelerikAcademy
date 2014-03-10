namespace ThreeDSpace
{
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        private readonly static Point3D point0 = new Point3D();

        public Point3D(double x, double y, double z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D Point0
        {
            get { return point0; }
        }

        public override string ToString()
        {
            return string.Format("{0}{1:f1}, {2:f1}, {3:f1}{4}",'{',this.X, this.Y, this.Z,'}');
        }
    }
}
