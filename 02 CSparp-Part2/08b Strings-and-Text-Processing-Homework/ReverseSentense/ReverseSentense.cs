using System;
using System.Collections.Generic;
using System.Text;

class ReverseSentense
{
    // Write a program that reverses the words in given sentence.
	// Example: "C# is not C++, not PHP and not Delphi!" -> "Delphi not and PHP, not C++ not is C#!".

    static void Main()
    {

        string sentense = "C# is not C++, not PHP and not Delphi!";

        List<char> punctuations = new List<char>() { '.', ',', '?', '!', ':', ';' };

        Console.WriteLine(sentense);
        string[] words = sentense.Split(' ');

        char[] punctPosition = new char[words.Length];  // array of punctuation position - which word has a punctuation at its end
        for (int i = 0; i < words.Length; i++)  // initialize the array and remove the last symbol
        {
            int lastIndex = words[i].Length - 1;
            char lastSymbol = words[i][lastIndex];
            if (punctuations.Contains(lastSymbol))
            {
                punctPosition[i] = lastSymbol;
                words[i] = words[i].Substring(0, lastIndex);
            }
        }

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < words.Length; i++) // combine the words backwards and append the punctuation where needed;
        {
            result.Append(words[words.Length -1 - i]);
            if (punctuations.Contains(punctPosition[i]))
            {
                result.Append(punctPosition[i]);
            }
            if (i < words.Length - 1)
            {
                result.Append(' ');
            }            
        }
        
        Console.WriteLine(result); // print the result
    }
}

