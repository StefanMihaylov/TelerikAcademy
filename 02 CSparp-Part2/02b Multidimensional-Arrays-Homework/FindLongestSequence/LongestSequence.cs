using System;

namespace FindLongestSequence
{
    class LongestSequence
    {
        // We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix

        static void UserMatrix(string[,] matrix)
        {
            // initialize matrix enter by the user
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(" Element [{0},{1}] = ", row, col);
                    matrix[row, col] = Console.ReadLine();
                }
            }

        }

        static void printMatrix(string[,] matrix, int startColourRow, int startColourCol, int endColourRow, int endColourCol)
        {
            decimal A = 0;
            decimal B = 0;
            bool rowLine = startColourRow == endColourRow;
            bool colLine = startColourCol == endColourCol;
            bool diagLine = !rowLine && !colLine;
            if (rowLine && colLine)
            {
                rowLine = false;
                colLine = false;
                Console.WriteLine(" Sequence not found");
            }
            else
            {
                Console.Write(" Sequence is highlighted in ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("yellow");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (diagLine)
            {
                A = (endColourRow - startColourRow) / (endColourCol - startColourCol);
                B = endColourRow - A * endColourCol;
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    bool rowCondition = rowLine && (row == startColourRow) && (col >= startColourCol) && (col <= endColourCol);
                    bool colCondition = colLine && (col == startColourCol) && (row >= startColourRow) && (row <= endColourRow);
                    bool diagCondition = diagLine && (row == (A * col + B));

                    if (rowCondition || colCondition || diagCondition)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    int elementSize = GetMaxLenght(matrix);
                    Console.Write(" {0," + elementSize + "}", matrix[row, col]);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }
        }

        static int intInput(string text, int min, int max)
        {
            int InputValue;
            while (true)
            {
                Console.Write("{0} from {1} to {2}: ", text, min, max);
                if (int.TryParse(Console.ReadLine(), out InputValue) && InputValue >= min && InputValue <= max)
                {
                    return InputValue;
                }
                else
                {
                    Console.WriteLine("\t Invalid value! Try again!");
                }
            }
        }

        static int GetMaxLenght(string[,] matrix)
        {
            int lenght = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (lenght < matrix[row,col].Length)
                    {
                        lenght = matrix[row, col].Length;
                    }
                }
            }
            return lenght;
        }

        static void RowSequenceSearch(string[,] matrix, ref int maxCounter, int[] maxStart, int[] maxEnd)
        {
            // index of element in the matrix: row = matrix[0], column = matrix[1]. I don't want to use structures yet.
            int[] start = new int[2]; 
            int[] end = new int[2];
            int counter;
            string element;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                start[0] = row;
                end[0] = row;

                element = matrix[row, 0];
                counter = 1;
                start[1] = 0;
                end[1] = 0;
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (element == matrix[row, col])
                    {
                        counter++;
                        end[1] = col;
                    }
                    else
                    {
                        if (counter > maxCounter)
                        {
                            maxCounter = counter;
                            Array.Copy(start,maxStart,start.Length);
                            Array.Copy(end, maxEnd, end.Length);
                        }
                        element = matrix[row, col];
                        counter = 1;
                        start[1] = col;
                        end[1] = col;
                    }
                }
                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    Array.Copy(start, maxStart, start.Length);
                    Array.Copy(end, maxEnd, end.Length);
                }
            }
        }

        static void ColumnSequenceSearch(string[,] matrix, ref int maxCounter, int[] maxStart, int[] maxEnd)
        {
            // index of element in the matrix: row = matrix[0], column = matrix[1]. I don't want to use structures yet.
            int[] start = new int[2];
            int[] end = new int[2];
            int counter;
            string element;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                start[1] = col;
                end[1] = col;

                element = matrix[0, col];
                counter = 1;
                start[0] = 0;
                end[0] = 0;
                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    if (element == matrix[row, col])
                    {
                        counter++;
                        end[0] = row;
                    }
                    else
                    {
                        if (counter > maxCounter)
                        {
                            maxCounter = counter;
                            Array.Copy(start, maxStart, start.Length);
                            Array.Copy(end, maxEnd, end.Length);
                        }
                        element = matrix[row, col];
                        counter = 1;
                        start[0] = row;
                        end[0] = row;
                    }
                }
                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    Array.Copy(start, maxStart, start.Length);
                    Array.Copy(end, maxEnd, end.Length);
                }
            }
        }

        static void LeftDiagonalSequenceSearch(string[,] matrix, ref int maxCounter, int[] maxStart, int[] maxEnd)
        {
            // index of element in the matrix: row = matrix[0], column = matrix[1]. I don't want to use structures yet.
            int[] start = new int[2];
            int[] end = new int[2];
            int counter = 0;
            string element = "";

            int row = 0;
            int col = 0;
            int beginRow = row;
            int beginCol = col;
            bool newRow = true;

            for (int number = 0; number < matrix.Length; number++)
            {
                if (newRow)
                {
                    element = matrix[row, col];
                    counter = 1;
                    start[0] = row;
                    start[1] = col;
                    newRow = false;
                }
                else
                {
                   if (element == matrix[row, col])
                    {
                        counter++;
                        end[0] = row;
                        end[1] = col;
                    }
                    else
                    {
                        if (counter > maxCounter)
                        {
                            maxCounter = counter;
                            Array.Copy(start, maxStart, start.Length);
                            Array.Copy(end, maxEnd, end.Length);
                        }
                        element = matrix[row, col];
                        counter = 1;
                        start[0] = row;
                        start[1] = col;
                    }
                }

                row++;
                col--;
                if ((row >= matrix.GetLength(0)) || (col < 0))
                {

                    beginCol++;      // change start column
                    if (beginCol >= matrix.GetLength(1))
                    {
                        beginCol = matrix.GetLength(1) - 1;
                    }
                    else
                    {
                        beginRow--; // don't change start row
                    }

                    beginRow++;     // change start row
                    if (beginRow >= matrix.GetLength(0))
                    {
                        beginRow = matrix.GetLength(0) - 1;
                    }

                    row = beginRow;
                    col = beginCol;
                    newRow = true;
                    if (counter > maxCounter)
                    {
                        maxCounter = counter;
                        Array.Copy(start, maxStart, start.Length);
                        Array.Copy(end, maxEnd, end.Length);
                    }
                }
            }  
        }

        static void RightDiagonalSequenceSearch(string[,] matrix, ref int maxCounter, int[] maxStart, int[] maxEnd)
        {
            // index of element in the matrix: row = matrix[0], column = matrix[1]. I don't want to use structures yet.
            int[] start = new int[2];
            int[] end = new int[2];
            int counter = 0;
            string element = "";

            int row = matrix.GetLength(0) - 1;
            int col = 0;
            int beginRow = row;
            int beginCol = col;
            bool newRow = true;

            for (int number = 0; number < matrix.Length; number++)
            {
                if (newRow)
                {
                    element = matrix[row, col];
                    counter = 1;
                    start[0] = row;
                    start[1] = col;
                    newRow = false;
                }
                else
                {
                    if (element == matrix[row, col])
                    {
                        counter++;
                        end[0] = row;
                        end[1] = col;
                    }
                    else
                    {
                        if (counter > maxCounter)
                        {
                            maxCounter = counter;
                            Array.Copy(start, maxStart, start.Length);
                            Array.Copy(end, maxEnd, end.Length);
                        }
                        element = matrix[row, col];
                        counter = 1;
                        start[0] = row;
                        start[1] = col;
                    }
                }

                row++;
                col++;
                if ((row >= matrix.GetLength(0)) || (col >= matrix.GetLength(1)))
                {
                    beginRow--;     // change start row
                    if (beginRow < 0)
                    {
                        beginRow = 0;
                    }
                    else
                    {
                        beginCol--; // don't change start column
                    }
                    beginCol++;      // change start column
                    if (beginCol >= matrix.GetLength(1))
                    {
                        beginCol = matrix.GetLength(1) - 1;
                    }

                    row = beginRow;
                    col = beginCol;
                    newRow = true;
                    if (counter > maxCounter)
                    {
                        maxCounter = counter;
                        Array.Copy(start, maxStart, start.Length);
                        Array.Copy(end, maxEnd, end.Length);
                    }
                }
            }
        }

        static void Main()
        {
            string[,] matrix = new string[1,1];
            Console.WriteLine(" Enter \"1\" to test default matrix 1");
            Console.WriteLine(" Enter \"2\" to test default matrix 2");
            Console.WriteLine(" Enter \"3\" to test your matrix");
            int choise = intInput(" Enter your choise", 1, 3);
            switch (choise)
            {
                case 1:
                    matrix = new string[,]
                    {
                        {"ha", "fifi", "ho", "hi"},
                        {"fo", "ha", "hi", "xx"},
                        {"xxx", "ho", "ha", "xx"}
                    };
                    break;
                case 2:
                    matrix = new string[,]
                    {
                        {"s", "qq", "s"},
                        {"pp", "pp", "s"},
                        {"pp", "qq", "s"}
                    };
                    break;
                case 3:
                    int matrixHight = intInput(" Enter matrix hight N", 1, 20);
                    int matrixLenght = intInput(" Enter matrix lenght M", 1, 20);
                    matrix = new string[matrixHight, matrixLenght];
                    UserMatrix(matrix);
                    break;
            }

            int maxCounter = 0;
            // index of element in the matrix: row = matrix[0], column = matrix[1]. I don't want to use structures yet.
            int[] maxStart = new int[2]; 
            int[] maxEnd = new int[2];

            RowSequenceSearch(matrix, ref maxCounter, maxStart, maxEnd);

            ColumnSequenceSearch(matrix, ref maxCounter, maxStart, maxEnd);

            LeftDiagonalSequenceSearch(matrix, ref maxCounter, maxStart, maxEnd);

            RightDiagonalSequenceSearch(matrix, ref maxCounter, maxStart, maxEnd);

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));
            printMatrix(matrix, maxStart[0], maxStart[1], maxEnd[0], maxEnd[1]);
        }
    }
}
