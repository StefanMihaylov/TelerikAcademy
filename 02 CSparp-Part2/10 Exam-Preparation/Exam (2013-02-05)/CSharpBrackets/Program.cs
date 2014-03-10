using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 90/100

namespace CSharpBrackets
{
    class Program
    {
        static string separator = string.Empty;
        const char endOfLine = '\n';

        static void Main(string[] args)
        {
            // Load data from local HDD if program is run in VS
            //bool debugPrint = false;
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                Console.SetIn(new StreamReader(@"..\..\Input.txt"));
                //debugPrint = true;
            }

            int N = int.Parse(Console.ReadLine());
            separator = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            int depth = 0;
            bool afterSeparator = false;
            for (int i = 0; i < N; i++)
            {
                string currentLine = Console.ReadLine().TrimStart();
                for (int index = 0; index < currentLine.Length; index++)
                {
                    if (currentLine[index] == '{')
                    {
                        afterSeparator = false;
                        if (result.Length > 0 && result[result.Length - 1] != endOfLine)
                        {
                            result.AppendLine();
                        }
                        AddSeparator(result, depth);
                        result.AppendLine(currentLine[index].ToString());
                        depth++;
                    }
                    else if (currentLine[index] == '}')
                    {
                        afterSeparator = false;
                        if (result.Length > 0 && result[result.Length - 1] != endOfLine)
                        {
                            result.AppendLine();
                        }
                        depth--;
                        AddSeparator(result, depth);
                        result.AppendLine(currentLine[index].ToString());
                    }
                    else
                    {
                        if (result.Length > 0 && result[result.Length - 1] == endOfLine)
                        {
                            AddSeparator(result, depth);
                            afterSeparator = true;

                        }

                        if (currentLine[index] == ' ')
                        {
                            if (!((result.Length > 0 && result[result.Length - 1] == ' ') || afterSeparator))
                            {
                                result.Append(currentLine[index].ToString());
                                afterSeparator = false;
                            }
                        }
                        else
                        {
                            result.Append(currentLine[index].ToString());
                            afterSeparator = false;
                        }
                    }

                    // end of input line
                    if (index == currentLine.Length - 1 && result[result.Length - 1] != endOfLine)
                    {
                        result.AppendLine();
                    }
                }
            }

            int lastIndex = result.Length - 1;
            while (result[lastIndex] == '\n' || result[lastIndex] == '\r')
            {
                result.Remove(lastIndex, 1);
                lastIndex--;
            }

            Console.WriteLine(result.ToString());
        }

        static void AddSeparator(StringBuilder result, int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                result.Append(separator);
            }
        }
    }
}
