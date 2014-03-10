namespace SumOfNExample
{
    using System;

    class SumOfN
    {
        // Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum

        static void Main()
        {
            uint number;
            while (true)
            {
                Console.Write("\t Enter number N:");
                if (uint.TryParse(Console.ReadLine(), out number) && number != 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            int counter=0;
            double input;
            double sum = 0;

            while (counter < number)
            {
                while (true)
                {
                    Console.Write("\t Enter number {0}:", counter+1);
                    if (double.TryParse(Console.ReadLine(), out input))
                    {
                        sum += input;
                        counter++;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\t\t Invalid value. Try again");
                    }
                }
            }
            Console.WriteLine("\t Sum is {0}",sum);
        }
    }
}
