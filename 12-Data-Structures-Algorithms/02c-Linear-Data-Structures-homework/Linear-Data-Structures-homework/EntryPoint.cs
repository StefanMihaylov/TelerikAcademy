namespace Linear_Data_Structures_homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EntryPoint
    {
        /*  Write a program that reads from the console a sequence of positive integer numbers. The sequence ends when empty line is entered. Calculate and print the sum and average of the elements of the sequence. Keep the sequence in List<int>.  */

        public static void Main()
        {
            List<int> collection = new List<int>();

            int number;
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            input.Trim();

            while (input.Length != 0)
            {
                if (int.TryParse(input, out number))
                {
                    collection.Add(number);
                }
                else
                {
                    Console.WriteLine("\t Invalid number");
                }

                // TODO: remove repeated code
                Console.Write("Enter number: ");
                input = Console.ReadLine();
                input.Trim();
            }

            if (collection.Count> 0)
            {
                long sum = collection.Sum();
                long average = sum / collection.Count;

                Console.WriteLine("Sum of numbers: {0}, Average of numbers: {1}", sum, average);
            }
            else
            {
                Console.WriteLine("No numbers entered");
            }
        }
    }
}
