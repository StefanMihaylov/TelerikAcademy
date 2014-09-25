namespace RemoveNegative
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EntryPoint
    {
        /* Write a program that removes from given sequence all negative numbers. */

        public static void Main()
        {
            List<int> numbers = new List<int>() { 1, -2, 2, 0, -4, -5, 4, -8, -2, 3, 2, -2, 8 };
            Console.WriteLine("Input: {0}", string.Join(", ", numbers));
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int current = numbers[i];
                if (current >= 0)
                {
                    result.Add(current);
                }
            }
            Console.WriteLine("Result: {0}", string.Join(", ", result));
            
            // variant 2
            numbers = new List<int>() { 1, -2, 2, 0, -4, -5, 4, -8, -2, 3, 2, -2, 8 };
            numbers.RemoveAll(n => n < 0);
            Console.WriteLine("Result: {0}", string.Join(", ", numbers));
        }
    }
}
