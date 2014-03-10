namespace ThreeDSpace
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        private List<Point3D> allPoints3D;

        public Path()
        {
            this.AllPoints3D = new List<Point3D>();
        }

        public List<Point3D> AllPoints3D
        {
            get { return this.allPoints3D; }
            set { this.allPoints3D = value; }
        }

        public void Add(Point3D point)
        {
            this.AllPoints3D.Add(point);
        }
    }
}
