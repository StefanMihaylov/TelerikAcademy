namespace SortIntExample
{
    using System;

    class SortInt
    {
        // Sort 3 real values in descending order using nested if statements.

        static void Main()
        {
            double number1;
            while (true)
            {
                Console.Write("\t Enter number 1: ");
                if (double.TryParse(Console.ReadLine(), out number1))
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
                if (double.TryParse(Console.ReadLine(), out number2))
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
                if (double.TryParse(Console.ReadLine(), out number3))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            double temp;

            // nested if statements - too complicated
            if (number1 < number2)
            {
                // exchange the values
                temp = number1;
                number1 = number2;
                number2 = temp;

                if (number1 < number3)
                {
                    temp = number1;
                    number1 = number3;
                    number3 = temp;
                }
            }
            else
            {
                if (number1 < number3)
                {
                    temp = number1;
                    number1 = number3;
                    number3 = temp;
                }
            }

            if (number2 < number3)
            {
                temp = number2;
                number2 = number3;
                number3 = temp;
            }
            
            Console.WriteLine("\t Sorted numbers: {0}; {1}; {2}",number1, number2, number3);
        }
    }
}
