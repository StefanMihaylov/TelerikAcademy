using System;

namespace LargestAreaExample
{
    class LargestArea
    {
        // * Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size.

        static int[,] matrix = 
        {
          {1, 3, 2, 2, 2, 4},
          {3, 3, 3, 2, 4, 4},
          {4, 3, 1, 2, 3, 3},
          {4, 3, 1, 3, 3, 1},
          {4, 3, 3, 3, 1, 1},
        };

        static bool[,] usedElements = new bool[matrix.GetLength(0), matrix.GetLength(1)];        
        static int counter;

        static void DepthFirstSearch(int element, int row, int col)
        {            
            if ((row >= 0) && (row < matrix.GetLength(0)) &&
                (col >= 0) && (col < matrix.GetLength(1)))      // "row" and "col" are in range
            {
                if (!usedElements[row, col] && element == matrix[row, col]) // new element is not used AND is equal to the old one
                {
                    counter++;
                    usedElements[row, col] = true;

                    // check the surrounding elements recursively
                    for (int i = row - 1; i <= row + 1; i++)
                    {
                        for (int j = col - 1; j <= col + 1; j++)
                        {
                            DepthFirstSearch(element, i, j);
                        }
                    }
                }
            }
        }

        static void printMatrix(int[,] matrix, int element)
        {
            Console.Write(" Area is highlighted in ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("yellow");
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == element)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(" {0}", matrix[row, col]);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }
        }

        static void Main()
        {
            int maxCounter = int.MinValue;
            int maxElement = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    counter = 0;
                    DepthFirstSearch(matrix[row, col], row, col);

                    if (maxCounter < counter)
                    {
                        maxCounter = counter;
                        maxElement = matrix[row, col];
                    }
                }
            }

            printMatrix(matrix, maxElement);
            Console.WriteLine();
            Console.WriteLine(" Length = {0}",maxCounter);
        }
    }
}
