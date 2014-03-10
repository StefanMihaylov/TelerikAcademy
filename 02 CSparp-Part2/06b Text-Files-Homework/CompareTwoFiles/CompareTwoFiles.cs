using System;
using System.IO;
using System.Text;

class CompareTwoFiles
{
    // Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different. Assume the files have equal number of lines.
    
    static void Main()
    {
        string filePath1 = @"..\..\Files\Film1.txt";
        string filePath2 = @"..\..\Files\Film2.txt";
        StreamReader reader1 = new StreamReader(filePath1, Encoding.GetEncoding("windows-1251"));
        StreamReader reader2 = new StreamReader(filePath2, Encoding.GetEncoding("windows-1251"));

        int row = 1;
        int equal = 0;
        int different = 0;
        using (reader1)
        {
            using (reader2)
            {
                string line1 = reader1.ReadLine();
                string line2 = reader2.ReadLine();
                while (line1 != null)
                {
                    if (line1 == line2)
                    {
                        Console.WriteLine("Line {0:d2}:     Equal : {1}", row, line1);
                        equal++;
                    }
                    else
                    {
                        Console.WriteLine("Line {0:d2}: Not Equal : {1}", row, line1);
                        Console.WriteLine("                   : {0}", line2);
                        different++;
                    }
                    row++;
                    line1 = reader1.ReadLine();
                    line2 = reader2.ReadLine();
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine(" Equal lines: {0}, Different lines: {1}",equal,different);
        Console.WriteLine();
    }
}

