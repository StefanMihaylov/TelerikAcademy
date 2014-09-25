namespace StringsOddCounter
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        /* Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. Example: {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL} */

        public static void Main()
        {
            string[] numbers = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            IDictionary<string, int> dict = new Dictionary<string, int>();

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
                if (pair.Value % 2 != 0)
                {
                    Console.Write("{0} ", pair.Key);
                }
            }

            Console.WriteLine();
        }
    }
}
