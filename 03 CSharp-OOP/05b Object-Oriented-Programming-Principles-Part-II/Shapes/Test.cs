namespace Shapes
{
    using System;
    using System.Globalization;
    using System.Threading;

    class Test
    {
        static void Main()
        {
            Shape[] shapes = new Shape[]
            {
                new Rectangle(1.2, 1.5),
                new Rectangle(5.8, 2),
                new Triangle(1.4, 1.7),
                new Triangle(3.4, 5.2),
                new Circle(4.2),
                new Circle(8.6),
            };

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }
        }
    }
}
