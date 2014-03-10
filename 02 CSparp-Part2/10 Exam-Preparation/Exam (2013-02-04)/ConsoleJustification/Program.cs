using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleJustification
{
    class Program
    {
        static StringBuilder result = new StringBuilder();
        static int width;

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
            width = int.Parse(Console.ReadLine());

            int wordsWidth = 0;
            List<string> words = new List<string>();
            for (int line = 0; line < N; line++)
            {
                string[] currentWords = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int index = 0; index < currentWords.Length; index++)
                {
                    int currentLength = wordsWidth + words.Count + currentWords[index].Length;

                    if (currentLength <= width)
                    {
                        words.Add(currentWords[index]);
                        wordsWidth += currentWords[index].Length;
                    }

                    if (currentLength >= width)
                    {
                        FixWhiteSpaces(words, wordsWidth);
                        result.AppendLine();
                        words.Clear();
                        wordsWidth = 0;
                        if (currentLength > width)
                        {
                            words.Add(currentWords[index]);
                            wordsWidth += currentWords[index].Length;
                        }
                    }
                }
            }

            if (words.Count > 0)
            {
                FixWhiteSpaces(words, wordsWidth);
            }

            Console.WriteLine(result);

        }

        static void FixWhiteSpaces(List<string> words, int wordsWidth)
        {
            int spaceCounter = words.Count - 1;
            int[] spaces = new int[spaceCounter];
            if (spaceCounter != 0)
            {
                int index = 0;
                for (int i = wordsWidth; i < width; i++)
                {
                    spaces[index]++;
                    index = (index + 1) % spaces.Length;
                }
            }
            for (int i = 0; i < spaceCounter; i++)
            {
                result.Append(words[i]);
                result.Append(new string(' ', spaces[i]));
            }
            result.Append(words[words.Count - 1]);
        }

        static bool IsNewLine()
        {
            if (result.Length == 0 || result[result.Length - 1] == '\n' || result[result.Length - 1] == '\r')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
