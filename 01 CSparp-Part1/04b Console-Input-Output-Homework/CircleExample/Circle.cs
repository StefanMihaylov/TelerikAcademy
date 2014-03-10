namespace CircleExample
{
    using System;
    using System.Globalization;

    class Circle
    {
        // Write a program that reads the radius r of a circle and prints its perimeter and area

        static void Main()
        {
            double radius;
            string inputValue;
            bool tryParseTest;
            
            while (true)
            {
                Console.Write("\t Enter circle radius: ");
                inputValue = Console.ReadLine();
                tryParseTest = double.TryParse(inputValue, NumberStyles.Float, CultureInfo.CurrentCulture, out radius) ||
                         double.TryParse(inputValue, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out radius);
                
                if (tryParseTest)
                {
                    double perimeter = 2 * Math.PI * radius;
                    double area = Math.PI * radius * radius;
                    Console.WriteLine("\t Circle perimeter is {0:f4}, circle area is {1:f4}",perimeter,area);
                    break;      
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }
        }
    }
}
