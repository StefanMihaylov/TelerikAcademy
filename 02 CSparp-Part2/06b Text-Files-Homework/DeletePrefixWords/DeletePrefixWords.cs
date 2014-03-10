using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class DeletePrefixWords
{
    // Write a program that deletes from a text file all words that start with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _
    // http://www.codeproject.com/Articles/9099/The-30-Minute-Regex-Tutorial

    static void Main()
    {
        string filePath = @"..\..\Files\Input.txt";
        string ResultFilePath = @"..\..\Files\Output.txt";

        StreamReader reader = new StreamReader(filePath);
        StreamWriter writer = new StreamWriter(ResultFilePath, false);

        using (reader)
        {
            using (writer)
            {
                Console.Write(" Reading the file... ");
                string line = reader.ReadLine();
                while (line != null)
                {
                    // remove all words starting with "test": \d = digits, \w = letters,  _ = symbol "_"
                    line = Regex.Replace(line, @"(\b)test((\d|\w|_)*)(\b)", string.Empty);
                    line = Regex.Replace(line, @"(\s){2,}", " "); // replace two spaces with one
                    writer.WriteLine(line);                    
                    line = reader.ReadLine();
                }
                Console.WriteLine("Ready");
            }
        }

        File.Delete(filePath);                  // delete the old file
        File.Move(ResultFilePath, filePath);    // rename the result file
    }
}
