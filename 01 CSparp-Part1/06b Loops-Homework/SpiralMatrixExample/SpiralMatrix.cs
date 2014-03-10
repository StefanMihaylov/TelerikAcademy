namespace SpiralMatrixExample
{
    using System;

    class SpiralMatrix
    {
        // * Write a program that reads a positive integer number N (N < 20) from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.

        static void Main(string[] args)
        {
            int valueN; // Enter integer 0 < N < 20
            while (true)
            {
                Console.Write("\t Enter integer 0 < N < 20: ");
                if (int.TryParse(Console.ReadLine(), out valueN) && valueN > 0 && valueN < 20)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            // initialization
            int[,] matrix = new int[valueN, valueN];            
            string direction = "Right";           

            int row = 0;
            int minRow = 1;
            int maxRow = valueN;
           
            int column = 0;
            int minColumn = 0;
            int maxColumn = valueN;

            // matrix filling in
            for (int number = 1; number <= matrix.Length; number++)
            {
                matrix[row, column] = number;
                switch (direction)
                {
                    case "Right":
                        column++;
                        if (column >= maxColumn) // change direction from Right to Down
                        {
                            row++;
                            column--;
                            direction = "Down";
                            maxColumn--;
                        }
                        break;
                    case "Down":
                        row++;
                        if (row >= maxRow) // change direction Down Down to Left
                        {
                            row--;
                            column--;
                            direction = "Left";
                            maxRow--;
                        }
                        break;
                    case "Left":
                        column--;
                        if (column < minColumn) // change direction from Left to Up
                        {
                            row--;
                            column++;
                            direction = "Up";
                            minColumn++;
                        }
                        break;
                    case "Up":
                        row--;
                        if (row < minRow) // change direction from Up to Right
                        {
                            row++;
                            column++;
                            direction = "Right";
                            minRow++;
                        }
                        break;
                }
            }

            // matrix printing
            int maxNumberOfDigits = (int)(Math.Log10(matrix.Length)) + 1;
            for (int i = 0; i < valueN; i++)
            {
                for (int j = 0; j < valueN; j++)
                {
                    // increase the number of digits according to maximal number
                    Console.Write("{0," + maxNumberOfDigits + "} ", matrix[i, j]);                
                }
                Console.WriteLine();
            }
        }
    }
}