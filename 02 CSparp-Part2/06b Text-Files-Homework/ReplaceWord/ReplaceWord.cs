using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceWord
{
    // Modify the solution of the previous problem to replace only whole words (not substrings)

    static void Main()
    {
        string filePath = @"..\..\Files\Input.txt";
        string ResultFilePath = @"..\..\Files\Output.txt";

        string oldText = "start";
        string newText = "finish";
        string pattern = "\\b" + oldText + "\\b";


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
                    writer.WriteLine(Regex.Replace(line, pattern, newText));
                    line = reader.ReadLine();
                }
                Console.WriteLine(" Ready");
            }
        }
    }
}