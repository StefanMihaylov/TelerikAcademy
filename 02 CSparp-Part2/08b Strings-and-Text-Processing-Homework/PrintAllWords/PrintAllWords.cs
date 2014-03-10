using System;
using System.Collections.Generic;
using System.Text;

class PrintAllWords
{
    static void Main()
    {
        // Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found

        Console.Write("Enter text: ");
        string text = Console.ReadLine().ToLower();

        string[] textAsWords = text.Split(new Char[] { ' ', '.', ',', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);


        SortedDictionary<string, int> words = new SortedDictionary<string, int>();

        foreach (var item in textAsWords)  
        {
            if (item.Length > 0)
            {
                if (words.ContainsKey(item))
                {
                    words[item]++;
                }
                else
                {
                    words.Add(item, 1);
                }
            }
        }

        foreach (var word in words)
        {
            Console.WriteLine(" The word \"{0}\" appears {1} time(s) in the text.", word.Key, word.Value);
        }

        Console.WriteLine();
    }
}

