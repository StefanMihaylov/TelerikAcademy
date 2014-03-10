namespace BiggestIntExample
{
    using System;

    class BiggestInt
    {
        // Write a program that finds the biggest of three integers using nested if statements

        static void Main()
        {
            int number1;
            while (true)
            {
                Console.Write("\t Enter number 1: ");
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
                Console.Write("\t Enter number 2: ");
                if (int.TryParse(Console.ReadLine(), out number2))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            int number3;
            while (true)
            {
                Console.Write("\t Enter number 3: ");
                if (int.TryParse(Console.ReadLine(), out number3))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

           // nested if
           if (number1 >= number2 && number1 >= number3)
            {
                Console.WriteLine("\t Biggest number is {0}",number1);
             
            }
           else if (number2 >= number1 && number2 >= number3)
            {
                Console.WriteLine("\t Biggest number is {0}", number2);
            }
           else
           {
               Console.WriteLine("\t Biggest number is {0}", number3);
           }
        }
    }
}
