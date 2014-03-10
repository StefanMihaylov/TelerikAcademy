namespace CheckInCircleExample
{
    using System;
    using System.Globalization;

    class CheckInCircle
    {
        // Write an expression that checks if given point (x,  y) is within a circle K((0,0), 5).
        
        static void Main()
        {
            double valueX;
            double valueY;
            bool tryValueX;
            bool tryValueY;
            string inputValue;

            Console.Write("\t Enter X coordinate:");
            inputValue = Console.ReadLine();
            tryValueX = double.TryParse(inputValue, NumberStyles.Float, CultureInfo.CurrentCulture, out valueX) ||
                        double.TryParse(inputValue, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out valueX);
            
            Console.Write("\t Enter Y coordinate:");
            inputValue = Console.ReadLine();
            tryValueY = double.TryParse(inputValue, NumberStyles.Float, CultureInfo.CurrentCulture, out valueY) ||
                        double.TryParse(inputValue, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out valueY);

            if (tryValueX && tryValueY)
            {
                double radius = 5;
                bool result = valueX * valueX + valueY * valueY <= radius * radius;
                Console.WriteLine("\t Point ({0};{1}) {2} within the circle K((0;0),5)!\n", valueX, valueY, result ? "is" : "isn't");
            }
            else 
            {
                Console.WriteLine("\t Invalid input data!");
            }
        }
    }
}
