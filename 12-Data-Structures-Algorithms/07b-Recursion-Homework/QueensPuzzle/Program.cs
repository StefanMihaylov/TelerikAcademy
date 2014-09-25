namespace QueensPuzzle
{
    using System;

    class Program
    {
        // * Write a recursive program to solve the "8 Queens Puzzle" with backtracking. Learn more at: http://en.wikipedia.org/wiki/Eight_queens_puzzle

        static void Main()
        {
            int counter = 0;
            int[,] board;

            for (int boardSize = 1; boardSize <= 12; boardSize++)
            {
                board = new int[boardSize, boardSize];
                counter = 0;
                Solve(board, 0, ref counter);
                Console.WriteLine("All soltutions for {1,2} queens: {0}", counter, boardSize);
            }
        }

        private static void Solve(int[,] board, int row, ref int counter)
        {
            if (row >= board.GetLength(0))
            {
                counter++;
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] == 0)
                {
                    board[row, col] += 1;
                    MarkPaths(board, row, col, 1);

                    //Print(board);
                    Solve(board, row + 1, ref counter);

                    MarkPaths(board, row, col, -1);
                    board[row, col] += -1;
                }
            }
        }

        private static void MarkPaths(int[,] board, int startRow, int startCol, int addValue)
        {
            for (int row = startRow; row < board.GetLength(0); row++)
            {
                board[row, startCol] += addValue;

                int offset = row - startRow;
                int left = startCol - offset;
                if (left >= 0)
                {
                    board[row, left] += addValue;
                }

                int right = startCol + offset;
                if (right < board.GetLength(1))
                {
                    board[row, right] += addValue;
                }
            }
        }

        private static void Print(int[,] matrix)
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
    }
}
