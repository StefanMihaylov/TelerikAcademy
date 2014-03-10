using System;
using System.Text;

class ReadDictionary
{
    // A dictionary is stored as a sequence of text lines containing words and their explanations. Write a program that enters a word and translates it by using the dictionary

    static void Main()
    {
        string dictionary = 
@".NET – platform for applications from Microsoft
CLR – managed execution environment for .NET
namespace – hierarchical organization of classes";

        string[] dictionaryAsArray = dictionary.Split(new char[]{'\r','\n'},StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < dictionaryAsArray.Length; i++)
        {
            dictionaryAsArray[i] = dictionaryAsArray[i].Trim();
        }

        Console.Write(" Enter word: ");
        string input = Console.ReadLine();
        bool isFound = false;

        for (int i = 0; i < dictionaryAsArray.Length; i++)
        {
            string word = dictionaryAsArray[i].Substring(0, input.Length);
            if (word == input)
            {
                Console.WriteLine(" \"{0}\": {1}", input, dictionaryAsArray[i].Substring(input.Length + 3));
                isFound = true;
                break;
            }
        }

        if (!isFound)
        {
            Console.WriteLine(" \"{0}\" not found in the dictionary",input);
        }
    }
}

