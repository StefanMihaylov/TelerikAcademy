namespace CohesionAndCoupling
{
    using System;

    public class Geometry
    {
        public static double CalculateDiagonal2D(double side1, double side2)
        {
            double distance = CalculateDistance2D(0, 0, side1, side2);
            return distance;
        }

        public static double CalculateDiagonal3D(double side1, double side2, double side3)
        {
            double distance = CalculateDistance3D(0, 0, 0, side1, side2, side3);
            return distance;
        }

        public static double CalculateVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;
            return volume;
        }

        public static double CalculateDistance2D(double x1, double y1, double x2, double y2)
        {
            return CalculateDistance3D(x1, y1, 0, x2, y2, 0);
        }

        public static double CalculateDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distanceX = x2 - x1;
            double distanceY = y2 - y1;
            double distanceZ = z2 - z1;

            double distance = Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY) + (distanceZ * distanceZ));
            return distance;
        }
    }
}
