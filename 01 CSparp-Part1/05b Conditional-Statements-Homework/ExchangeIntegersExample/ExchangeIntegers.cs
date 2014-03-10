namespace ExchangeIntegersExample
{
    using System;

    class ExchangeIntegers
    {
        // Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.

        static void Main()
        {
            int number1;
            while (true)
            {
                Console.Write("\t Enter integer 1: ");
                if (int.TryParse(Console.ReadLine(), out number1))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            int number2;
            while (true)
            {
                Console.Write("\t Enter integer 2: ");
                if (int.TryParse(Console.ReadLine(), out number2))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            int temp;
            if (number1 > number2)
            {
                Console.WriteLine("\t Integers exchanging");
                temp = number1;
                number1 = number2;
                number2 = temp;                
            }
            Console.WriteLine("\t Integers: {0} < {1}\n", number1, number2);

        }
    }
}
