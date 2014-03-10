namespace ThreeDSpace
{
    using System;

    public static class Distance3D
    {
        public static double CalcDistance(Point3D pointOne, Point3D pointTwo)
        {
            double distX = pointOne.X - pointTwo.X;
            double distY = pointOne.Y - pointTwo.Y;
            double distZ = pointOne.Z - pointTwo.Z;

            return Math.Sqrt(distX * distX + distY * distY + distZ * distZ);
        }
    }
}
