using System;

namespace CartesianCoordinateSystem
{
    class CoordinateSystem
    {
        static void Main(string[] args)
        {
            decimal x = decimal.Parse(Console.ReadLine());
            decimal y = decimal.Parse(Console.ReadLine());
            int result = 0;

            if (x==0 && y==0)
            {
                result = 0;
            }
            if (x == 0 && y != 0)
            {
                result = 5;
            }
            if (x != 0 && y == 0)
            {
                result = 6;
            }
            if (x > 0 && y > 0)
            {
                result = 1;
            }
            if (x < 0 && y > 0)
            {
                result = 2;
            }
            if (x < 0 && y < 0)
            {
                result = 3;
            }
            if (x > 0 && y < 0)
            {
                result = 4;
            }
            Console.WriteLine(result);
        }
    }
}
