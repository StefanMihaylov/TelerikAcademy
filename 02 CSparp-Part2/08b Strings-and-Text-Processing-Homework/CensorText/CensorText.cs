using System;
using System.Text;

class CensorText
{
    // We are given a string containing a list of forbidden words and a text containing some of these words. Write a program that replaces the forbidden words with asterisks.

    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string censor = "PHP, CLR, Microsoft";

        string[] censorWords = censor.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        StringBuilder result = new StringBuilder();

        result.Append(text);
        for (int i = 0; i < censorWords.Length; i++)
        {
            result.Replace(censorWords[i], new string('*', censorWords[i].Length));
        }

        Console.WriteLine();
        Console.WriteLine(text);
        Console.WriteLine();
        Console.WriteLine(" Censored text");
        Console.WriteLine(result.ToString());
        Console.WriteLine();
    }
}

