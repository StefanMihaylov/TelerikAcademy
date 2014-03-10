namespace RectangleAreaExample
{
    using System;
    using System.Globalization;

    class RectangleArea
    {
        //  Write an expression that calculates rectangle’s area by given width and height.

        static void Main()
        {
            double width;
            double height;
            string inputValue;
            bool validWidth;
            bool validHeight;

            Console.Write("\t Enter width:");
            inputValue = Console.ReadLine();
            validWidth = double.TryParse(inputValue, NumberStyles.Float, CultureInfo.CurrentCulture, out width) ||
                         double.TryParse(inputValue, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out width);
            
            Console.Write("\t Enter height:");
            inputValue = Console.ReadLine();
            validHeight = double.TryParse(inputValue, NumberStyles.Float, CultureInfo.CurrentCulture, out height) ||
                          double.TryParse(inputValue, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out height);

            if (validWidth && validHeight)
            {
                Console.WriteLine("\t Rectangle's area is {0}", height * width);
            }
            else 
            {
                Console.WriteLine("\t Invalid input data!");
            }
        }
    }
}
