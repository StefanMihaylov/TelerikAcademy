namespace CountNumbers
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        /* Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
                Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
                    -2.5  2 times, 3  4 times, 4  3 times */

        public static void Main()
        {
            double[] numbers = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            IDictionary<double, int> dict = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!dict.ContainsKey(number))
                {
                    dict[number] = 0;
                }

                dict[number]++;
            }

            foreach (var pair in dict)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
