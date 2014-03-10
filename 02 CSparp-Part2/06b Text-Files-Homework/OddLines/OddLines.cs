using System;
using System.IO;
using System.Text;

class OddLines
{
    // Write a program that reads a text file and prints on the console its odd lines.

    static void Main()
    {
        string filePath = @"..\..\Files\Film.txt";  // part of subtitles from "Escape Plan"
        StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("windows-1251"));
        using (reader)
        {
            Console.WriteLine(" Odd lines only:");
            int lineNumber = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                lineNumber++;                
                if (lineNumber%2 != 0 )
                {
                    Console.WriteLine("Line {0:d2}: {1}", lineNumber, line);                    
                }
                line = reader.ReadLine();
            }
        }
    }
}