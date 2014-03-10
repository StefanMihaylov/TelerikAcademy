
namespace ProductSignExample
{
    using System;

    class ProductSign
    {
        //Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.

        static void Main()
        {
            double number1;
            while (true)
            {
                Console.Write("\t Enter number 1: ");
                if (double.TryParse(Console.ReadLine(), out number1) && (Math.Sign(number1) != 0))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            double number2;
            while (true)
            {
                Console.Write("\t Enter number 2: ");
                if (double.TryParse(Console.ReadLine(), out number2) && (Math.Sign(number2) != 0))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            double number3;
            while (true)
            {
                Console.Write("\t Enter number 3: ");
                if (double.TryParse(Console.ReadLine(), out number3) && (Math.Sign(number3) != 0))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            bool sign1 = Math.Sign(number1) > 0;
            bool sign2 = Math.Sign(number2) > 0;
            bool sign3 = Math.Sign(number3) > 0;
            bool result = true; // false "< 0" ; true "> 0"

            if (sign1 ^ sign2)
            {
                result = false;
            }

            if (result ^ sign3)
            {
                result = false;
            }

            Console.WriteLine("\t Product sign is " + (result ? "'+'" : "'-'"));
        }
    }
}