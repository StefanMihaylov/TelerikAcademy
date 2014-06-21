namespace WalkInMatrix
{
    using System;

    public class WalkInMatrix
    {
        public static int[,] FillMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            int currentNumber = 1;

            Cell currentCell = FindFirstEmptyCell(matrix);
            while (currentCell != null)
            {
                Vector direction = new Vector(1, 1);
                while (true)
                {
                    matrix[currentCell.X, currentCell.Y] = currentNumber;
                    currentNumber++;
                    if (!FindNextDirection(matrix, currentCell, direction))
                    {
                        break;
                    }

                    currentCell += direction;
                }

                currentCell = FindFirstEmptyCell(matrix);
            }

            return matrix;
        }

        public static Cell FindFirstEmptyCell(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        return new Cell(i, j);
                    }
                }
            }

            return null;
        }

        private static bool IsNextCellValid(int[,] matrix, Cell currentCell, Vector directon)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int newX = currentCell.X + directon.X;
            int newY = currentCell.Y + directon.Y;

            bool isXCoordValid = newX >= 0 && newX < rows;
            bool isYCoordValid = newY >= 0 && newY < cols;

            return isXCoordValid && isYCoordValid &&
                matrix[newX, newY] == 0;
        }

        private static bool FindNextDirection(int[,] matrix, Cell cell, Vector direction)
        {
            for (int i = 0; i < direction.NumberOfRotations; i++)
            {
                if (IsNextCellValid(matrix, cell, direction))
                {
                    return true;
                }

                direction.Rotate();
            }

            return false;
        }
    }
}
