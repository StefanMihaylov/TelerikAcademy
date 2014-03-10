using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractSentanseByWord
{
    // Write a program that extracts from a given text all sentences containing given word.

    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string word = "in";

        string[] sentenses = text.Split('.');

        for (int i = 0; i < sentenses.Length; i++)
        {
            string[] words = sentenses[i].Split(' ');
            bool isWordFound = false;
            for (int j = 0; j < words.Length; j++)
            {
                if (words[j].Trim().Equals(word))
                {
                    isWordFound = true;
                    break;
                }
            }
            if (isWordFound)
            {
                Console.WriteLine("{0}.", sentenses[i].Trim());
            }            
        }

        // using RegEx
        Console.WriteLine();
        Console.WriteLine(" using RegEx...");
        string pattern = string.Format("\\b{0}\\b", word);
        for (int i = 0; i < sentenses.Length; i++)
        {
            if (Regex.IsMatch(sentenses[i], pattern))
            {
                Console.WriteLine("{0}.", sentenses[i].Trim());
            }
        }
    }
}