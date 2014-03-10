using System;
using System.IO;
using System.Text;

class DeleteOddLines
{
    // Write a program that deletes from given text file all odd lines. The result should be in the same file

    static void Main()
    {
        string filePath = @"..\..\Files\Film.txt";
        string ResultFilePath = @"..\..\Files\Output.txt";

        StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("windows-1251"));
        StreamWriter writer = new StreamWriter(ResultFilePath, false, Encoding.GetEncoding("windows-1251"));

        using (reader)
        {
            using (writer)
            {
                Console.Write(" Reading the file and deleting ... ");
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 == 0)
                    {
                       writer.WriteLine(line);
                    }
                    line = reader.ReadLine();
                }
                Console.WriteLine("Ready");
            }
        }

        File.Delete(filePath); // delete the old file
        File.Move(ResultFilePath, filePath); // rename the result file
    }
}
