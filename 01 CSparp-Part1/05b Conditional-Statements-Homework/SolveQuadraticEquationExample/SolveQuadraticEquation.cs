namespace SolveQuadraticEquationExample
{
    using System;
    using System.Text;

    class SolveQuadraticEquation
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;         
            Console.WriteLine("\t Equation: A.X" + '\u00B2' + " + B.X + C = 0");

            double a;
            while (true)
            {
                Console.Write("\t Enter coefficient A:");
                if (double.TryParse(Console.ReadLine(), out a) && a!=0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            double b;
            while (true)
            {
                Console.Write("\t Enter coefficient B:");
                if (double.TryParse(Console.ReadLine(), out b))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            double c;
            while (true)
            {
                Console.Write("\t Enter coefficient C:");
                if (double.TryParse(Console.ReadLine(), out c))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            double root1;
            double root2;

            double discriminant = b * b - 4 * a * c;
            if (discriminant>0)
            {
                root1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                root2 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine("\t Two Roots: {0:f4} and {1:f4}", root1, root2);
            }
            else if (discriminant == 0)
            {
                root1 = -b / (2 * a);
                Console.WriteLine("\t One Root: {0:f4}", root1);
            }
            else 
            {
                Console.WriteLine("\t No real roots");
            }        
        }
    }
}
