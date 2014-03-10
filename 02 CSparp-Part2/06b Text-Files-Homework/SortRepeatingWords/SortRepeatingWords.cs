using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


class SortRepeatingWords
{
    // Write a program that reads a list of words from a file words.txt and finds how many times each of the words is contained in another file test.txt. The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order. Handle all possible exceptions in your methods.

    static int CountWords(string filePath, string word)
    {
        StreamReader reader = new StreamReader(filePath);
        using (reader)
        {
            int counter = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                counter += Regex.Matches(line, "(\\b)" + word + "(\\b)").Count;
                line = reader.ReadLine();
            }
            return counter;
        }
    }

    static void Main()
    {
        string directory = @"..\..\Files\";
        string fileName = "test.txt";
        string wordsFileName = "words.txt";
        string resultName = "result.txt";
        string filePath = directory + fileName;

        Dictionary<string, int> words = new Dictionary<string, int>();

        try
        {
            // initialize the dictionary by readung the "words.txt" file
            StreamReader reader = new StreamReader(directory + wordsFileName);
            using (reader)
            {
                Console.Write(" Reading the {0} file... ", wordsFileName);
                string word = reader.ReadLine();
                while (word != null)
                {
                    words.Add(word, CountWords(filePath,word));
                    word = reader.ReadLine();                    
                }
                Console.WriteLine("Ready");
            }

            // copied form stackoverflow :)
            words = words.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            // write the result to file
            StreamWriter writer = new StreamWriter(directory + resultName);
            using (writer)
            {
                Console.Write(" Writing the {0} file... ", resultName);
                foreach (var item in words)
                {
                    writer.WriteLine("Word \"{0}\" occurs {1} time(s) in the text",item.Key,item.Value);
                }
                Console.WriteLine("Ready");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Error: {0}", ex.Message);
        }
    }
}
