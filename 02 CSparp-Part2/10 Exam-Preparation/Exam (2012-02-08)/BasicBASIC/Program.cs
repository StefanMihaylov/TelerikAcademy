using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBASIC
{
     // NOT FINISHED YET - DON'T START IT

    class Program
    {
        static List<string> lines;
        static List<string> rowNumbers;

        static List<char> variables = new List<char>() { 'V', 'W', 'X', 'Y', 'Z' };

        static int X = 0;
        static int Y = 0;
        static int Z = 0;
        static int V = 0;
        static int W = 0;

        static void Main()
        {

            // Load data from local HDD if program is run in VS
            //bool debugPrint = false;
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                Console.SetIn(new StreamReader(@"..\..\Input.txt"));
                //debugPrint = true;
            }

            lines = new List<string>();
            rowNumbers = new List<string>();

            string readtLine;
            do
            {
                readtLine = Console.ReadLine().Trim();
                lines.Add(readtLine);
                rowNumbers.Add(null);

            } while (readtLine != "RUN");
            lines.RemoveAt(lines.Count - 1);
            rowNumbers.RemoveAt(lines.Count - 1);

            SplitRowNumbers();

            StringBuilder result = new StringBuilder();

            int row = 0;
            while (true)
            {
                string currentRow = lines[row];
                if (currentRow == "STOP")
                {
                    break;
                }
                else if (currentRow == "CLS")
                {
                    result.Clear();
                }
                else if (currentRow[0] == 'P')
                {
                    result.Append(GetValue(currentRow[currentRow.Length - 1]));
                }
                else if (currentRow[0] == 'G')
                {
                    row = Jump(currentRow);
                }
                else if (currentRow[0] == 'I')
                {

                }
                else
                {
                    Calculate(currentRow);
                }

            }

            Console.WriteLine(result);


        }

        static void Calculate(string currentRow)
        {

            string[] operands = currentRow.Split(' ');
            if (operands.Length == 3)
            {
                if (variables.Contains(operands[2][0]))
                {
                    SetValue(operands[0][0], GetValue(operands[2][0]));
                }
                else
                {
                    int digit = int.Parse(operands[2]);
                    SetValue(operands[0][0], digit);
                }
            }
            else
            {
                int operand1;
                if (variables.Contains(operands[2][0]))
                {
                    operand1=GetValue(operands[2][0]);
                }
                else
                {
                    operand1 = int.Parse(operands[2]);
                }

                int operand2;
                if (variables.Contains(operands[4][0]))
                {
                    operand2 = GetValue(operands[4][0]);
                }
                else
                {
                    operand2 = int.Parse(operands[4]);
                }

                if (operands[3] == "+")
                {
                    SetValue(operands[0][0], operand1 + operand2);
                }
                else
                {
                    SetValue(operands[0][0], operand1 - operand2);
                }
            }
        }

        static int GetValue(char name)
        {
            switch (name)
            {
                case 'V': return V;
                case 'W': return W;
                case 'X': return X;
                case 'Y': return Y;
                case 'Z': return Z;
                default: throw new ArgumentException(string.Format("Invalid variable {0}", name));
            }
        }

        static void SetValue(char name, int value)
        {
            switch (name)
            {
                case 'V': V = value; break;
                case 'W': W = value; break;
                case 'X': X = value; break;
                case 'Y': Y = value; break;
                case 'Z': Z = value; break;
                default: throw new ArgumentException(string.Format("Invalid variable {0}", name));
            }
        }

        static int Jump(string currentRow)
        {
            StringBuilder number = new StringBuilder();

            for (int i = 0; i < currentRow.Length; i++)
            {
                if (char.IsDigit(currentRow[i]))
                {
                    number.Append(currentRow[i]);
                }
            }

            //int newIndex = int.Parse(number.ToString());
            return rowNumbers.IndexOf(number.ToString());
        }

        static void SplitRowNumbers()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                string currentLine = lines[i];
                int counter = 0;
                for (int j = 0; j < currentLine.Length; j++)
                {
                    if (char.IsDigit(currentLine[j]))
                    {
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }

                string digit = currentLine.Substring(0, counter);
                string command = currentLine.Substring(counter).Trim();
                lines[i] = command;
                rowNumbers[i] = digit;
            }
        }
    }
}
