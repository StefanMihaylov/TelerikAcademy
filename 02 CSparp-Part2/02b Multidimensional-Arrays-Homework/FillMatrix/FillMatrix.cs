using System;

namespace FillMatrixExample
{
    class FillMatrix
    {
        // Write a program that fills and prints a matrix of size (n, n) 

        static void FillTypeA(int[,] matrix)
        {
            int number = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = number;
                    number++;
                }
            }
            printMatrix(matrix);
        }

        static void FillTypeB(int[,] matrix)
        {
            int number = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        matrix[row, col] = number;
                        number++;
                    }
                }
                else
                {
                    for (int row = matrix.GetLength(0)-1; row >=0 ; row--)
                    {
                        matrix[row, col] = number;
                        number++;
                    }
                }
            }
            printMatrix(matrix);
        }

        static void FillTypeC(int[,] matrix)
        {
            // initialization
            int row = matrix.GetLength(0) - 1;
            int column = 0;

            int startRow = row;            
            int startColumn = column;

            for (int number = 1; number <=matrix.Length; number++)
            {
                matrix[row, column] = number;
                row++;
                column++;

                if ((row >= matrix.GetLength(0)) || (column >= matrix.GetLength(1)))
                {
                    startRow--;     // change start row
                    if (startRow < 0)
                    {
                        startRow = 0;
                    }
                    else
                    {
                        startColumn--;  // don't change start column
                    }

                    startColumn++;      // change start column
                    if (startColumn >= matrix.GetLength(1))
                    {
                        startColumn = matrix.GetLength(1)-1;
                    }

                    row = startRow;
                    column = startColumn;
                }
            }

            printMatrix(matrix);
        }

        static void FillTypeD(int[,] matrix)
        {
            // start point
            int startRow = 0;
            int startCol = 0;
            string direction = "Down";

            // initialization
            int row = startRow;
            int minRow = 0;
            int maxRow = matrix.GetLength(0);

            int column = startCol;
            int minColumn = 1;
            int maxColumn = matrix.GetLength(1);

            // matrix filling in
            for (int number = 1; number <= matrix.Length; number++)
            {
                matrix[row, column] = number;
                switch (direction)
                {
                    case "Right":
                        column++;
                        if (column >= maxColumn) // change direction from Right to Up
                        {
                            column--;
                            maxColumn--;                            
                            direction = "Up"; // new direction
                            row--;
                        }
                        break;

                    case "Down":
                        row++;
                        if (row >= maxRow) // change direction Down Down to Right
                        {
                            row--;
                            maxRow--;
                            direction = "Right"; // new direction
                            column++;                            
                        }
                        break;

                    case "Left":
                        column--;
                        if (column < minColumn) // change direction from Left to Down
                        {
                            column++;
                            minColumn++;
                            direction = "Down"; // new direction
                            row++;                            
                        }
                        break;

                    case "Up":
                        row--;
                        if (row < minRow) // change direction from Up to Left
                        {
                            row++;
                            minRow++;
                            direction = "Left"; // new direction
                            column--;
                        }
                        break;
                }
            }
            printMatrix(matrix);
        }

        static void printMatrix(int[,] matrix)
        {
            double realSize = Math.Log10(matrix.Length);
            int size = (int)Math.Floor(realSize) + 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(" {0," + size + "}", matrix[row,col]);
                }
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

        static char charInput(string text, char min, char max)
        {
            char InputValue;
            while (true)
            {
                Console.Write("{0} from {1} to {2}: ", text, min, max);
                if (char.TryParse(Console.ReadLine(), out InputValue) && InputValue >= min && InputValue <= max)
                {
                    return InputValue;
                }
                else
                {
                    Console.WriteLine("\t Invalid value! Try again!");
                }
            }
        }
          
        static void Main()
        {
            int matrixSize = intInput(" Enter matrix size", 1, 20);
            char type = charInput(" Enter matrix type", 'a', 'd');

            int[,] matrix = new int[matrixSize,matrixSize];

            switch (type)
            {
                case 'a':
                    FillTypeA(matrix);
                    break;
                case 'b':
                    FillTypeB(matrix);
                    break;
                case 'c':
                    FillTypeC(matrix);
                    break;
                case 'd':
                    FillTypeD(matrix);
                    break;
            }
        }
    }
}
