namespace TrapezoidAreaExample
{
    using System;
    using System.Globalization;

    class TrapezoidArea
    {
        //  Write an expression that calculates trapezoid's area by given sides a and b and height h

        static void Main()
        {
            double sideA;
            double sideB;
            double height;
            string inputValue;
            bool isSideAValid;
            bool isSideBValid;
            bool isHeightValid;

            // Side A
            Console.Write("\t Enter trapezoid's side A:");
            inputValue = Console.ReadLine();
            isSideAValid = double.TryParse(inputValue, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out sideA) ||
                  double.TryParse(inputValue, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"), out sideA);

            // side B
            Console.Write("\t Enter trapezoid's side B:");
            inputValue = Console.ReadLine();
            isSideBValid = double.TryParse(inputValue, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out sideB) ||
                   double.TryParse(inputValue, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"), out sideB);

            //height
            Console.Write("\t Enter trapezoid height:");
            inputValue = Console.ReadLine();
            isHeightValid = double.TryParse(inputValue, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out height) ||
                double.TryParse(inputValue, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"), out height);

            // calculations
            if (isSideAValid && isSideBValid && isHeightValid)
            {
                Console.WriteLine("\t Trapezoid's area is {0}\n", (sideA + sideB)/2 * height);
            }
            else
            {
                Console.WriteLine("\t Invalid input data!");
            }
        }
    }
}
