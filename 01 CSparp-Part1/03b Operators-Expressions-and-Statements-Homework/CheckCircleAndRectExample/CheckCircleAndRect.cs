namespace CheckCircleAndRectExample
{
    using System;
    using System.Globalization;

    class CheckCircleAndRect
    {
        static void Main()
        {
            // Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

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
                double circleCenterX = 1;
                double circleCenterY = 1;
                double circleRadius = 3;

                double rectangleTop = 1;
                double rectangleLeft = -1;
                double rectangleWidth = 6;
                double rectangleHeight = 2;

                double shiftValueXSQ = (valueX - circleCenterX) * (valueX - circleCenterX);
                double shiftValueYSQ = (valueY - circleCenterY) * (valueY - circleCenterY);
                bool resultCircle = shiftValueXSQ + shiftValueYSQ <= circleRadius * circleRadius;

                double rectangleRight = rectangleLeft + rectangleWidth;
                double rectangleBottom = rectangleTop - rectangleHeight;
                bool resultRectangle = valueX < rectangleRight && valueX > rectangleLeft && 
                                        valueY < rectangleTop && valueY > rectangleBottom;
                bool result = resultCircle && !resultRectangle;
 
                Console.WriteLine("\t The point ({0};{1}) {2} inside the permitted area!", valueX, valueY, result ? "is" : "isn't");
            }
            else 
            {
                Console.WriteLine("\t Invalid input data!");
            }

        }
    }
}
