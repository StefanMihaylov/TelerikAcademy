using System;
using System.IO;
using System.Text;

class LineNumbers
{
    // Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file

    static void Main()
    {
        string filePath = @"..\..\Files\Film.txt";
        string ResultFilePath = @"..\..\Files\Result.txt";

        StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("windows-1251"));
        StreamWriter writer = new StreamWriter(ResultFilePath, false, Encoding.GetEncoding("windows-1251"));

        using (reader)
        {
            using (writer)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    writer.WriteLine(string.Format("Line {0:d2}: {1}", lineNumber, line));
                    line = reader.ReadLine();
                }
            }
        }
        Console.WriteLine("Ready");
    }
}
