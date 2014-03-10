using System;
using System.Collections.Generic;
using System.Text;

class CompressString
{
    // Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".

    static string Compress(string message)
    {
        StringBuilder result = new StringBuilder();

        char previousSymbol = message[0];
        for (int i = 1; i < message.Length; i++)
        {
            if (previousSymbol != message[i])
            {
                result.Append(previousSymbol);
                previousSymbol = message[i];
            }
        }
        result.Append(previousSymbol);

        return result.ToString();
    }

    static void Main()
    {
        Console.Write(" Enter text: ");  
        string text = Console.ReadLine();

        Console.WriteLine(" Compress text: {0}", Compress(text));
    }
}

