using System;
using System.IO;
using System.Text;

class ReplaceString
{
    // Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

    static void Main()
    {
        string filePath = @"..\..\Files\Input.txt";
        string ResultFilePath = @"..\..\Files\Output.txt";

        string oldText = "start";
        string newText = "finish";

        StreamReader reader = new StreamReader(filePath);
        StreamWriter writer = new StreamWriter(ResultFilePath, false);

        using (reader)
        {
            using (writer)
            {
                Console.Write(" Reading the file and replacing ... ");
                string line = reader.ReadLine();
                while (line != null)
                {
                    writer.WriteLine(line.Replace(oldText, newText));
                    line = reader.ReadLine();
                }
                Console.WriteLine(" Ready");
            }
        }
    }
}