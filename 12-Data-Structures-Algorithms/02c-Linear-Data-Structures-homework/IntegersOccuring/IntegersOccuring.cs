namespace IntegersOccuring
{
    using System;
    using System.Collections.Generic;

    public class IntegersOccuring
    {
        /* Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs. 
         * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2} 
         * 2 -> 2 times; 3 -> 4 times; 4 -> 3 times */
        public static void Main()
        {
            List<int> numbers = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            Console.WriteLine("Input: {0}", string.Join(", ", numbers));

            IDictionary<int, int> dict = new SortedDictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int current = numbers[i];
                if (!dict.ContainsKey(current))
                {
                    dict[current] = 0;
                }

                dict[current]++;
            }

            Console.WriteLine("Result:");
            foreach (var pair in dict)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
