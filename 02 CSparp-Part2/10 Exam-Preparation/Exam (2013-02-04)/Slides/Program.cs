using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slides
{
    class Program
    {
        static void Main()
        {
            // Load data from local HDD if program is run in VS
            //bool debugPrint = false;
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                Console.SetIn(new StreamReader(@"..\..\Input.txt"));
                //debugPrint = true;
            }

            string[] inputString = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int[] dimentions = new int[inputString.Length];
            for (int i = 0; i < inputString.Length; i++)
            {
                dimentions[i] = int.Parse(inputString[i]);
            }

            string[, ,] cube = new string[dimentions[0], dimentions[1], dimentions[2]];

            for (int i = 0; i < dimentions[1]; i++)
            {
                string[] currentLine = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < currentLine.Length; j++)
                {
                    string[] tokens = currentLine[j].Trim().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int k = 0; k < tokens.Length; k++)
                    {
                        cube[k, i, j] = tokens[k].Trim();
                    }
                }
            }

            string[] startPosition = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] position = new int[3] { int.Parse(startPosition[0]), 0, int.Parse(startPosition[1]) };

            while (true)
            {
                string command = cube[position[0], position[1], position[2]].Trim();
                int[] nextPosition = new int[position.Length];
                Array.Copy(position, nextPosition, position.Length);

                if (command[0] == 'E')
                {
                    nextPosition[1]++;
                    if ((nextPosition[1] == dimentions[1] - 1))
                    {
                        Array.Copy(nextPosition, position, nextPosition.Length);
                        Console.WriteLine("Yes");
                        break;
                    }
                }
                else if (command[0] == 'B')
                {
                    Console.WriteLine("No");
                    break;
                }
                else if (command[0] == 'T')
                {
                    string[] commandParts = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    nextPosition[0] = int.Parse(commandParts[1]);
                    nextPosition[2] = int.Parse(commandParts[2]);
                }
                else if (command[0] == 'S')
                {
                    nextPosition[1]++;
                    for (int i = 2; i < command.Length; i++)
                    {
                        switch (command[i])
                        {
                            case 'L': nextPosition[0]--; break;
                            case 'R': nextPosition[0]++; break;
                            case 'F': nextPosition[2]--; break;
                            case 'B': nextPosition[2]++; break;
                        }
                    }
                    if ((nextPosition[1] == dimentions[1] - 1))
                    {
                        Array.Copy(nextPosition, position, nextPosition.Length);
                        Console.WriteLine("Yes");
                        break;
                    }
                }

                if ((nextPosition[0] < 0 || nextPosition[0] >= dimentions[0]) ||
                    (nextPosition[2] < 0 || nextPosition[2] >= dimentions[2]))
                {
                    Console.WriteLine("No");
                    break;
                }

                Array.Copy(nextPosition, position, nextPosition.Length);

               // Console.WriteLine(command + string.Join(" ", position));
            }

            Console.WriteLine(string.Join(" ", position));
        }       
    }
}
