namespace MinndMaxOfNExample
{
    using System;

    class MinAndMaxOfN
    {
        //Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

        static void Main()
        {
            int number;            
            while (true)
            {
                Console.Write("\t Enter number of elements: ");
                if (int.TryParse(Console.ReadLine(), out number) && number > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            int[] array = new int[number];
            for (int i = 0; i < number; i++)
            {
                while (true)
                {
                    Console.Write("\t Enter element {0}: ",i+1);
                    if (int.TryParse(Console.ReadLine(), out array[i]))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\t\t Invalid value! Try again!");
                    }
                }
            }

            int max = int.MinValue;
            int min = int.MaxValue;
            foreach (int element in array)
            {
                if (element > max)
                {
                    max = element;
                }
                if (element < min)
                {
                    min = element;
                }
            }
            Console.WriteLine("\t minimal value is {0}, Maximum value is {1}", min, max);
        }
    }
}
