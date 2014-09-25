namespace LargestConnectedArea
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        // Write a recursive program to find the largest connected area of adjacent empty cells in a matrix

        public static string[,] matrix = 
        {
            {" ", " ", " ", "*", " ", " ", " "},
            {"*", "*", " ", "*", " ", "*", " "},
            {" ", " ", "*", " ", " ", " ", " "},
            {" ", "*", "*", "*", "*", "*", "*"},
            {" ", " ", " ", " ", " ", " ", " "},
        };

        public static int pathLength;

        public const string ExitString = "e";
        public const string EmptyCell = " ";
        public const string MarkString = "v";

        public static void Main()
        {
            Print();

            int startRow = -1;
            int startCol = -1;
            int maxLength = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == EmptyCell)
                    {
                        pathLength = 0;
                        CountEmptycells(row, col);
                        if (maxLength < pathLength)
                        {
                            maxLength = pathLength;
                            startRow = row;
                            startCol = col;
                        }
                    }
                }
            }

            // result
            Console.WriteLine("largest connected area of adjacent empty cells contains {0} cells and start from ({1} {2})",
                maxLength, startRow, startCol);
        }
 
        private static void Print()
        {
            Console.WriteLine(new string('-', 2 * matrix.GetLength(1) + 1));
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("|{0}", matrix[row, col]);
                }
                Console.WriteLine("|");
                Console.WriteLine(new string('-', 2 * matrix.GetLength(1) + 1));
            }
        }

        private static void CountEmptycells(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] != EmptyCell)
            {
                return;
            }
            else
            {
                matrix[row, col] = MarkString;
                pathLength++;

                CountEmptycells(row, col + 1);
                CountEmptycells(row, col - 1);
                CountEmptycells(row + 1, col);
                CountEmptycells(row - 1, col);

                //matrix[row, col] = EmptyCell;
            }
        }
    }
}
