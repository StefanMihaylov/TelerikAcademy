using System;

class TriangleSurface
{
    // Write methods that calculate the surface of a triangle by given:
    // 1.Side and an altitude to it; 2.Three sides; 3.Two sides and an angle between them. Use System.Math

    static double CalculateArea(double side, double altitude)
    {
        return (side * altitude) / 2;
    }

    static double CalculateArea(double sideA, double sideB, double sideC)
    {
        // Heron's formula
        double semiperimeter = (sideA + sideB + sideC) / 2;
        double formula = semiperimeter * (semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC);
        return Math.Sqrt(formula);
    }

    static double CalculateAreaByAngle(double sideA, double sideB, double angle)
    {
        return sideA * sideB * Math.Sin(angle*Math.PI/180) / 2;
    }

    static void Main()
    {
        Console.WriteLine(" Choose method for calculating the triangke surface");
        Console.WriteLine(" Enter \"1\" if you know side and altitude");
        Console.WriteLine(" Enter \"2\" if you know the three sides");
        Console.WriteLine(" Enter \"3\" if you know two sides and an angle between them");
        Console.Write(" Enter your choise: ");
        int choise = int.Parse(Console.ReadLine());

        double area;
        switch (choise)
        {
            case 1:
                Console.Write(" Enter triangle side: ");
                double side = double.Parse(Console.ReadLine());
                Console.Write(" Enter triangle altitude: ");
                double altitude = double.Parse(Console.ReadLine());

                area = CalculateArea(side,altitude);
                Console.WriteLine(" Triangle surface is {0:f3}",area);
                break;

            case 2:
                Console.Write(" Enter triangle side 1: ");
                double side1 = double.Parse(Console.ReadLine());
                Console.Write(" Enter triangle side 2: ");
                double side2 = double.Parse(Console.ReadLine());
                Console.Write(" Enter triangle side 3: ");
                double side3 = double.Parse(Console.ReadLine());

                area = CalculateArea(side1, side2, side3);
                Console.WriteLine(" Triangle surface is {0:f3}", area);
                break;

            case 3:
                Console.Write(" Enter triangle side 1: ");
                side1 = double.Parse(Console.ReadLine());
                Console.Write(" Enter triangle side 2: ");
                side2 = double.Parse(Console.ReadLine());
                Console.Write(" Enter triangle angle in degrees: ");
                double angle = double.Parse(Console.ReadLine());

                area = CalculateAreaByAngle(side1, side2, angle);
                Console.WriteLine(" Triangle surface is {0:f3}", area);
                break;

            default:
                Console.WriteLine("Invalid number!");
                break;
        }
    }
}

