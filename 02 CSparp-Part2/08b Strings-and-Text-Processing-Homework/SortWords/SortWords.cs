using System;
using System.Collections.Generic;
using System.Text;

class SortWords
{
    // Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

    static void Main()
    {
        Console.Write(" Enter a list of words, separated by spaces: ");
        string text = Console.ReadLine().ToLower();

        string[] textAsWords = text.Split(new Char[] { ' ', '.', ',', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

        SortedSet<string> words = new SortedSet<string>();

        for (int i = 0; i < textAsWords.Length; i++)
        {
            words.Add(textAsWords[i]);
        }

        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}

