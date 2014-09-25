namespace MajorantNumber
{
    using System;
    using System.Collections.Generic;

    public class MajorantNumber
    {
        /*      * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. Write a program to find the majorant of given array (if exists). 
          Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3   */

        public static void Main()
        {
            List<int> numbers = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            Console.WriteLine("Input: {0}", string.Join(", ", numbers));

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

            var maxKey = numbers[0];
            var maxCount = dict[maxKey];
            foreach (var pair in dict)
            {
                if (maxCount < pair.Value )
                {
                    maxCount = pair.Value;
                    maxKey = pair.Key;
                }
            }

            if (maxCount >= (numbers.Count / 2 + 1))
            {
                Console.WriteLine("Majorant element of the array is {0}", maxKey);
            }
            else
            {
                Console.WriteLine("Majorant element of the array do not exist");
            }
        }
    }
}
