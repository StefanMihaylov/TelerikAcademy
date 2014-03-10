using System;

namespace ChooseMethodExample
{
    class ChooseMethod
    {
        /* Write a program that can solve these tasks:
                - Reverses the digits of a number
                - Calculates the average of a sequence of integers
                - Solves a linear equation a * x + b = 0
		    Create appropriate methods. Provide a simple text-based menu for the user to choose which task to solve.
		    Validate the input data:
                - The decimal number should be non-negative
                - The sequence should not be empty
                - "a" should not be equal to 0   */

        static int ReverseNumber(int number)
        {
            int sign = Math.Sign(number);
            number *= sign;
            int power = (int)Math.Log10(number);
            int multiplier = (int)Math.Pow(10, power); // this function is slow but the code is smaller than one FOR cycle :)
            int result = 0;
            while (number > 0)
            {
                result += multiplier * (number % 10);
                number /= 10;
                multiplier /= 10;
            }
            return sign * result;
        }

        static decimal Average()
        {
            Console.WriteLine(" Enter sequence of integers, enter \"0\" for exit");
            int counter = 0;
            int sum = 0;
            int number = 0;
            do
            {
                number = ArrayLibrary.intInput(string.Format("  Enter number #{0}: ",counter+1));
                if (number != 0)
                {
                    sum += number;
                    counter++;
                } 

            } while (number != 0);

            if (counter > 0)
            {
                return (decimal)sum / counter;
            }
            else
            {
                Console.WriteLine(" Invalid sequence! Try again");
                return Average();
            }
        }

        static decimal LinearEquation()
        {
            Console.WriteLine(" Enter coefficients of a linear equation A*x + B = 0");
            decimal A;
            while (true)
            {
                Console.Write("  Enter number \"A\": ");
                if (decimal.TryParse(Console.ReadLine(), out A) && A != 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t Invalid value! Try again!");
                }
            }

            decimal B;
            while (true)
            {
                Console.Write("  Enter number \"B\": ");
                if (decimal.TryParse(Console.ReadLine(), out B))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t Invalid value! Try again!");
                }
            }
           
            return -B/A;
        }

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("  Enter \"0\" to exit");
                Console.WriteLine("  Enter \"1\" to reverse the digits of a number");
                Console.WriteLine("  Enter \"2\" to calculate the average of a sequence of integers");
                Console.WriteLine("  Enter \"3\" to solve a linear equation A*x + B = 0");
                int choise = ArrayLibrary.intInput("  Enter your choise", 0, 3);
                switch (choise)
                {
                    case 0:
                        return;  // exit
                    case 1:
                        int number = ArrayLibrary.intInput(" Enter number: ");
                        Console.WriteLine(" Reverse number is {0}",ReverseNumber(number));
                        break;
                    case 2:                        
                        Console.WriteLine(" Average of the sequence of integers is {0:f3}",Average());
                        break;
                    case 3:
                        Console.WriteLine(" Linear equation root is {0:f3}",LinearEquation());
                        break;
                }
                Console.WriteLine();
                Console.Write(" Press any key to open the menu again ");
                Console.ReadKey();
            }
        }
    }
}