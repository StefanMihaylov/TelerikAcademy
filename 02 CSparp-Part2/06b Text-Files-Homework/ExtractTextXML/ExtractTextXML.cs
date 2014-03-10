using System;
using System.IO;
using System.Text;
using System.Threading;

class ExtractTextXML
{
    // Write a program that extracts from given XML file all the text without the tags

    static void Main()
    {
        string filePath = @"..\..\Files\books.xml";
        StreamReader reader = new StreamReader(filePath);

        StringBuilder result = new StringBuilder();

        Console.WriteLine(" Reading the file ... ");
        Console.WriteLine();
        using (reader)
        {
            bool startTag = false;
            int symbol = reader.Read();            
            while (symbol != -1) // end of file is not reached
            {                
                if (symbol == '<') // start of tag
                {
                    startTag = true;
                }
                if (!startTag && (symbol != '\r') && (symbol != '\n'))  // every symbol except end of line
                {
                    result.Append((char)symbol);
                }
                if (symbol == '>') // end of tag
                {
                    startTag = false;
                }
                if (symbol == '\n') // end of line => print the result
                {
                    string line = result.ToString().Trim();
                    if (line.Length > 0)
                    {
                        Console.WriteLine(line);
                        result.Clear();
                    }                    
                }
                symbol = reader.Read();
            }
            Console.WriteLine();
            Console.WriteLine("\t Ready");
        }
    }
}
