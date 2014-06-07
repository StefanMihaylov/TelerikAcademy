namespace Methods
{
    using System;

    public class Test
    {
        public static void Main()
        {
            // test CalculateTriangleArea method
            double area = Methods.CalculateTriangleArea(3, 4, 5);
            Console.WriteLine("Triangle area is {0}", area);

            // test ConvertDigitToWord method
            Console.WriteLine();
            int digit = 7;
            Console.WriteLine("The digit {0} is pronounced \"{1}\"", digit, Methods.ConvertDigitToWord(digit));

            // test FindMax method
            Console.WriteLine();
            int maxValue = Methods.FindMax(5, -1, 3, 2, 14, 2, 3);
            Console.WriteLine("Maximal value: {0}", maxValue);

            // test PrintAsNumber method
            Console.WriteLine();
            Console.WriteLine("Print objects as numbers:");
            Methods.PrintAsNumber(1.3, "f");
            Methods.PrintAsNumber(0.75, "%");
            Methods.PrintAsNumber(2.30, "r");
            Methods.PrintAsNumber(2.30, "q");

            // test CalculateDistance method
            Console.WriteLine();
            Point point1 = new Point(3, -1);
            Point point2 = new Point(3, 2.5);
            double distance = Methods.CalculateDistance(point1, point2);
            bool horisontalLine = Methods.IsHorisontalLine(point1, point2);
            bool verticalLine = Methods.IsVerticalLine(point1, point2);

            Console.WriteLine("Distance between {0} and {1} is {2} ", point1, point2, distance);
            Console.WriteLine("Is line horizontal? -> {0} ", horisontalLine ? "Yes" : "No");
            Console.WriteLine("Is line vertical? -> {0} ", verticalLine ? "Yes" : "No");

            // test class Student
            Console.WriteLine();
            Student peter = new Student("Peter", "Ivanov", DateTime.Parse("17.03.1992"), SexEnum.Male);
            peter.City = "Sofia";

            Student stella = new Student("Stella", "Markova", DateTime.Parse("03.11.1993"), SexEnum.Female);
            stella.City = "Vidin";
            stella.Hobby = "gamer";

            bool isPeterOlderThanStella = peter.IsOlderThan(stella);
            Console.WriteLine("{0} is older than {1}? -> {2}", peter.FirstName, stella.FirstName,                                                 isPeterOlderThanStella ? "Yes" : "No");
        }
    }
}
