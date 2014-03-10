using System;

namespace GetMaxExample
{
    class Program
    {
        // Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax()

        static int GetMax(int value1, int value2)
        {
            int max = value1;
            if (value2 > max)
            {
                max = value2;
            }
            return max;
        }

        static void Main()
        {
            Console.Write(" Enter first number: ");
            int number1 = int.Parse(Console.ReadLine());
            Console.Write(" Enter second number: ");
            int number2 = int.Parse(Console.ReadLine());
            Console.Write(" Enter third number: ");
            int number3 = int.Parse(Console.ReadLine());

            int max = GetMax(number1, number2);
            max = GetMax(max, number3);
            Console.WriteLine(" Maximal number is {0}",max);
        }
    }
}
