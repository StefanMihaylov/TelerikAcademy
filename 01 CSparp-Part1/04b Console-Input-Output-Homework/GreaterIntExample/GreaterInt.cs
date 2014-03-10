namespace GreaterIntExample
{
    using System;

    class GreaterInt
    {
        // Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements

        static void Main()
        {
            double inputA;
            while (true)
            {
                Console.Write("\t Enter first number:");
                if (double.TryParse(Console.ReadLine(), out inputA))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            double inputB;
            while (true)
            {
                Console.Write("\t Enter second number:");
                if (double.TryParse(Console.ReadLine(), out inputB))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            Console.WriteLine("\t The greater number of {0} and {1} is {2}",inputA,inputB,Math.Max(inputA,inputB));
        }
    }
}
