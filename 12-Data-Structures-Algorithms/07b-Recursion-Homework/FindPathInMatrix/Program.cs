namespace FindPathInMatrix
{
    using System;

    class Program
    {
        // Modify the above program to check whether a path exists between two cells without finding all possible paths. Test it over an empty 100 x 100 matrix

        static string[,] matrix = new string[100, 100];

        public const string EmptyCell = " ";

        static void Main()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = EmptyCell;
                }
            }

            bool result = false;

            FindPath(0, 0, ref result);




            if (result)
            {
                Console.WriteLine("Path found");
            }
            else
            {
                Console.WriteLine("Path not found");
            }
        }

        private static void FindPath(int row, int col, ref bool found)
        {
            if (found)
            {
                return;
            }

            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            // end cell
            if (row == (matrix.GetLength(0) - 1) && col == (matrix.GetLength(1) - 1))
            {
                found = true;
                return;
            }

            if (matrix[row, col] != EmptyCell)
            {
                return;
            }

            matrix[row, col] = "v";

            FindPath(row + 1, col, ref found);
            FindPath(row - 1, col, ref found);
            FindPath(row, col - 1, ref found);
            FindPath(row, col + 1, ref found);

            //matrix[row, col] = EmptyCell;
        }
    }
}
