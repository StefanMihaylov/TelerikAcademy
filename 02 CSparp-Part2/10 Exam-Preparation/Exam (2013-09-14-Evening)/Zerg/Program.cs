using System;
using System.Collections.Generic;

namespace Zerg
{
    class Program
    {
        static void Main()
        {

            List<string> words = new List<string>() 
            {   "Rawr", "Rrrr", "Hsst", "Ssst", "Grrr", 
                "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", 
                "Zzzz", "Bauu", "Djav", "Myau", "Gruh",};

            string input = Console.ReadLine();

            long multipier = 1;
            long message = 0;
            string word;
            int digit = 0;
            for (int i = input.Length-4; i >= 0; i-=4)
            {
                word = input.Substring(i, 4);
                digit = words.IndexOf(word);
                message += digit * multipier;
                multipier *= 15;
            }
            Console.WriteLine(message);
        }
    }
}
