using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class SortTextFile
{
    // Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file

    static void Main()
    {
        string filePath = @"..\..\Files\Input.txt";
        string ResultFilePath = @"..\..\Files\Output.txt";

        StreamReader reader = new StreamReader(filePath);
        List<string> list = new List<string>(); 

        using (reader)
        {
            Console.Write(" Reading the file... ");
            string line = reader.ReadLine();
            while (line != null)
            {
                list.Add(line);
                line = reader.ReadLine();
            }
            Console.WriteLine(" Ready");
        }

        list.Sort();

        StreamWriter writer = new StreamWriter(ResultFilePath, false);
        using (writer)
        {
            Console.Write(" Writing the result to file...");
            foreach (var item in list)
            {
                writer.WriteLine(item);
            } 
        }
        Console.WriteLine(" Ready");
    }
}