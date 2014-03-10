namespace QuadraticEquationExample
{
    using System;
    
    class QuadraticEquation
    {
        // Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

        static void Main()
        {
            Console.WriteLine("\t Equation: A.X.X + B.X + C = 0");

            int a;
            while (true)
            {
                Console.Write("\t Enter coefficient A:");
                if (int.TryParse(Console.ReadLine(), out a) && a!=0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            int b;
            while (true)
            {
                Console.Write("\t Enter coefficient B:");
                if (int.TryParse(Console.ReadLine(), out b))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            int c;
            while (true)
            {
                Console.Write("\t Enter coefficient C:");
                if (int.TryParse(Console.ReadLine(), out c))
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
                Console.WriteLine("\t Two real roots: {0:f4} and {1:f4}", root1, root2);
            }
            else if (discriminant == 0)
            {
                root1 = -b / (2 * a);
                Console.WriteLine("\t One real root: {0:f4}", root1);
            }
            else 
            {
                Console.WriteLine("\t No real roots");
            }
        }
    }
}
