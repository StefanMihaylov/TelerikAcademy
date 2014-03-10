using System;
using System.Collections.Generic;

class PrintAllLetters
{
    // "Write a program that reads a string from the console and prints all different letters, in the string along with information how many times each letter is found."

    static void Main()
    {
        //string text = "Write a program that reads a string from the console and prints all different letters, in the string along with information how many times each letter is found.";

        Console.Write("Insert text: ");
        string text = Console.ReadLine();

        SortedDictionary<char, int> Letters = new SortedDictionary<char,int>();

        foreach (var item in text.ToLower())  // capital and small letters are count as one letter
        {
            if (Char.IsLetter(item))
            {
                if (Letters.ContainsKey(item))
                {
                    Letters[item]++;
                }
                else
                {
                    Letters.Add(item, 1);
                }
            }
        }

        foreach (var letter in Letters)
        {
            Console.WriteLine(" Letter \"{0}\" - {1,3} time(s)",letter.Key,letter.Value);
        }

        Console.WriteLine();
    }
}

