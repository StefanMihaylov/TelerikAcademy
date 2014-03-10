using System;

namespace LargestNumberExample
{
    class MaxSum
    {
        // Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

        static void RandomMatix(int[,] matrix, int minElement, int maxElement)
        {
            // Initialize random matrix
            Random randomGenerator = new Random();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = randomGenerator.Next(minElement, maxElement + 1);
                }               
            }
        }

        static void UserMatrix(int[,] matrix)
        {
            // initialize matrix enter by the user
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = intInput(string.Format(" Element [{0},{1}] = ", row, col));
                }
            }

        }

        static void printMatrix(int[,] matrix, int colourRowStart, int colourColStart, int colourLenght, int elementSize = 3)
        {
            Console.Write(" Submatrix is highlighted in ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("yellow");
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if ((row >= colourRowStart && row < colourRowStart + colourLenght) &&
                        (col >= colourColStart && col < colourColStart + colourLenght))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

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

        static int intInput(string text) 
        {
            int InputValue;
            while (true)
            {
                Console.Write(text);
                if (int.TryParse(Console.ReadLine(), out InputValue))
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
            int matrixHight = intInput(" Enter matrix hight N", 3, 20);
            int matrixLenght = intInput(" Enter matrix lenght M", 3, 20);
            int[,] matrix = new int[matrixHight, matrixLenght];
            Console.WriteLine();
            Console.WriteLine(" Enter \"1\" to test random matrix");
            Console.WriteLine(" Enter \"2\" to test your matrix");
            int choise = intInput(" Enter your choise", 1, 2);
            switch (choise)
            {
                case 1:
                    RandomMatix(matrix, -20, 20); // random matrix filled with elements from -20 to 20
                    break;
                case 2:
                    UserMatrix(matrix);
                    break;
            }

            int maximalSum = int.MinValue;
            int startRow = 0;
            int startCol = 0;
            int sum;
            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    sum = 0;
                    for (int i = row; i < row + 3; i++)
                    {
                        for (int j = col; j < col + 3; j++)
                        {
                            sum += matrix[i, j];
                        }
                    }
                    if (sum > maximalSum)
                    {
                        maximalSum = sum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            // Print result
            Console.WriteLine(new string('-', 20) + " Result " + new string('-', 20));
            Console.WriteLine(" The maximal sum is {0}",maximalSum);
            printMatrix(matrix, startRow, startCol, 3);
        }
    }
}
