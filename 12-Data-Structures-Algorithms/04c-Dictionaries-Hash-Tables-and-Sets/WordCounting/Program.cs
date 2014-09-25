namespace WordCounting
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        /* Write a program that counts how many times each word from given text file words.txt appears in it. The character casing differences should be ignored. The result words should be ordered by their number of occurrences in the text */

        public static void Main()
        {
            string text = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";

            string[] words = text.Split(new char[] { ' ', ',', '.', '?', '!', ';', ':', '-', '–' }, StringSplitOptions.RemoveEmptyEntries);

            IDictionary<string, int> dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string lowerWord = word.ToLower();
                if (!dict.ContainsKey(lowerWord))
                {
                    dict[lowerWord] = 0;
                }

                dict[lowerWord]++;
            }

            foreach (var pair in dict)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
