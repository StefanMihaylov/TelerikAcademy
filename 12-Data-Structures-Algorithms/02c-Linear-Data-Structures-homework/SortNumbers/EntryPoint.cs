namespace SortNumbers
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        /*  Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order. */

        public static void Main()
        {
            List<int> numbers = new List<int>();

            int number;
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            input.Trim();

            while (input.Length != 0)
            {
                if (int.TryParse(input, out number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine("\t Invalid number");
                }

                Console.Write("Enter number: ");
                input = Console.ReadLine();
                input.Trim();
            }

            numbers.Sort();
            Console.WriteLine("Sorted numbers: {0}", string.Join(",", numbers)); 
        }
    }
}
