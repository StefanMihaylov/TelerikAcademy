namespace RemoveOddOccurNumbers
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        /* Write a program that removes from given sequence all numbers that occur odd number of times. 
         * Example:{4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5} */

        public static void Main()
        {
            List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            Console.WriteLine("Input: {0}", string.Join(", ", numbers));

            List<int> result = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int current = numbers[i];
                if (!dict.ContainsKey(current))
                {
                    dict[current] = 0;
                }

                dict[current]++;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                int current = numbers[i];
                int count = dict[current];
                if (count % 2 == 0)
                {
                    result.Add(current);
                }
            }

            Console.WriteLine("Result: {0}", string.Join(", ", result));
        }
    }
}
