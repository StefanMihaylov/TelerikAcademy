namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            bool isSidesFormTriangle = (a + b > c) || (a + c > b) || (b + c > a);
            if (!isSidesFormTriangle)
            {
                throw new ArgumentException("The entered sides can't form a triangle.");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
            return area;
        }

        public static string ConvertDigitToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Input number should be in range [0..9]");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Input array cannot be null or empty");
            }

            int result = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > result)
                {
                    result = elements[i];
                }
            }

            return result;
        }

        public static void PrintAsNumber(object number, string format)
        {
            string formatingString;
            switch (format)
            {
                case "f": formatingString = "{0:f2}";
                    break;
                case "%": formatingString = "{0:p0}";
                    break;
                case "r": formatingString = "{0,8}";
                    break;
                default:
                    throw new ArgumentException(string.Format("Unknown formating symbol \"{0}\"", format));
            }

            Console.WriteLine(formatingString, number);
        }

        public static double CalculateDistance(Point point1, Point point2)
        {
            double distanceX = point2.X - point1.X;
            double distanceY = point2.Y - point1.Y;

            double distance = Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY));
            return distance;
        }

        public static bool IsHorisontalLine(Point point1, Point point2)
        {
            return point1.Y == point2.Y;
        }

        public static bool IsVerticalLine(Point point1, Point point2)
        {
            return point1.X == point2.X;
        }
    }
}
