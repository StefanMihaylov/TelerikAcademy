using System;
using System.IO;
using System.Text;

namespace AddTwoFiles
{
    class AddTwoFiles
    {
        // Write a program that concatenates two text files into another text file.

        static void Main()
        {
            string filePath1 = @"..\..\Files\Film1.txt";
            string filePath2 = @"..\..\Files\Film2.txt";
            string ResultFilePath = @"..\..\Files\Result.txt";

            StringBuilder fileContents = new StringBuilder();

            StreamReader reader = new StreamReader(filePath1, Encoding.GetEncoding("windows-1251"));
            using (reader)
            {
                Console.Write(" Reading first file...");
                fileContents.Append(reader.ReadToEnd());
                Console.WriteLine();
            }
            reader = new StreamReader(filePath2, Encoding.GetEncoding("windows-1251"));
            using (reader)
            {
                Console.Write(" Reading second file...");
                fileContents.Append(reader.ReadToEnd());
                Console.WriteLine();
            }

            StreamWriter writer = new StreamWriter(ResultFilePath, false, Encoding.GetEncoding("windows-1251"));
            using (writer)
            {
                Console.Write(" Writing the combined file...");
                writer.Write(fileContents.ToString());
                Console.WriteLine();
            }
            Console.WriteLine(" Combining Ready");
        }
    }
}
