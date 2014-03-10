namespace GreatestOfFiveExample
{
    using System;

    class GreatestOfFive
    {
        //Write a program that finds the greatest of given 5 variables

        static void Main()
        {
            int[] numbers = new int[5];
            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    Console.Write("\t Enter integer {0}: ",i+1);
                    if (int.TryParse(Console.ReadLine(), out numbers[i]))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\t\t Invalid value. Try again");
                    }
                }
            }

            int biggest=numbers[0];
            foreach (int num in numbers)
            {
                if (num > biggest)
                {
                    biggest = num;
                }
            }

            Console.WriteLine("\t Biggest value is {0}",biggest);
        }
    }
}