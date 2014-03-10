using System;
using System.IO;
using System.Text.RegularExpressions;

class RemoveWordsByList
{
    // Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in your methods

    static void RemoveWord(string filePath, string word)
    {
        string ResultFilePath = @"..\..\Files\Output.txt";
        StreamReader reader = new StreamReader(filePath);
        StreamWriter writer = new StreamWriter(ResultFilePath, false);

        using (reader)
        {
            using (writer)
            {                
                string line = reader.ReadLine();
                while (line != null)
                {                    
                    line = Regex.Replace(line, "(\\b)" + word +"(\\b)", string.Empty);
                    line = Regex.Replace(line, @"(\s){2,}", " "); // replace two spaces with one
                    writer.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }

        File.Delete(filePath);                  // delete the old file
        File.Move(ResultFilePath, filePath);    // rename the result file
    }

    static void Main()
    {
        string filePath = @"..\..\Files\Input.txt";
        string listPath = @"..\..\Files\List.txt";

        try
        {
            StreamReader readerList = new StreamReader(listPath);
            using (readerList)
            {
                string word = readerList.ReadLine();
                while (word != null)
                {
                    RemoveWord(filePath, word);  // remove word form the input file
                    word = readerList.ReadLine();
                }
                Console.WriteLine("Ready");
            }            
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Error: {0}",ex.Message);
        }
    }
}