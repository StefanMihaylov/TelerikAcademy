namespace PrintIntegersExample
{
    using System;

    class PrintIntegers
    {
        // Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line.

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

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine("\t {0}",i);
            }
        }
    }
}
