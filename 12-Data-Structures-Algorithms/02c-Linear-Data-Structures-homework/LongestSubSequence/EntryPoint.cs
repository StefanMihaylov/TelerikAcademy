namespace LongestSubSequence
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        /* Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the result as new List<int>. Write a program to test whether the method works correctly. */

        public static void Main()
        {
            IList<int> numbers = new List<int>() { 1, 2, 2, 3, 4, 5, 4, 4, 4, 3, 2, 2 };
            IList<int> result = LongestSubsequence(numbers);
            Console.WriteLine("Result: {0}", string.Join(",", result));

            numbers = new List<int>() { 1, 2, 2, 3, 4, 5, 4, 4, 4, 3, 2, 2, 2, 2 };
            result = LongestSubsequence(numbers);
            Console.WriteLine("Result: {0}", string.Join(",", result));

            numbers = new List<int>() { 1, 1, 1, 3, 4, 5, 6, 4, 4, 3, 2 };
            result = LongestSubsequence(numbers);
            Console.WriteLine("Result: {0}", string.Join(",", result));
        }

        public static IList<int> LongestSubsequence(IList<int> numbers)
        {
            IList<int> result = new List<int>();

            int start = numbers[0];
            int count = 1;
            int maxCount = count;
            int maxCountStart = start;
            for (int i = 1; i < numbers.Count; i++)
            {
                int current = numbers[i];
                if (current == start)
                {
                    count++;
                }
                else
                {
                    if (maxCount < count)
                    {
                        maxCount = count;
                        maxCountStart = start;
                    }
                    start = current;
                    count = 1;
                }
            }

            if (maxCount < count)
            {
                maxCount = count;
                maxCountStart = start;
            }

            for (int i = 0; i < maxCount; i++)
            {
                result.Add(maxCountStart);
            }

            return result;
        }
    }
}
