namespace TicTacToe.GameLogic
{
    using System;
    using System.Collections.Generic;

    public class GameResultValidator : IGameResultValidator
    {
        public GameResult GetResult(string board)
        {
            int size = (int)Math.Sqrt(board.Length);
            int[,] matrix = new int[size, size];
            for (int i = 0; i < board.Length; i++)
            {
                int row = i / size;
                int col = i % size;
                char symbol = board[i];
                if (symbol == 'X')
                {
                    matrix[row, col] = 1;
                }
                else if (symbol == 'O')
                {
                    matrix[row, col] = 2;
                }
                else
                {
                    matrix[row, col] = -100;
                }
            }

            var result = new HashSet<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result.Add(this.RowSum(matrix, i));
                result.Add(this.ColSum(matrix, i));
            }

            result.Add(this.DiagonalSum(matrix, false));
            result.Add(this.DiagonalSum(matrix, true));

            bool wonX = result.Contains(3);
            bool wonO = result.Contains(6);

            if (wonX && !wonO)
            {
                return GameResult.WonByX;
            }
            else if (!wonX && wonO)
            {
                return GameResult.WonByO;
            }
            else
            {
                if (board.IndexOf('-') >= 0)
                {
                    return GameResult.NotFinished;
                }
                else
                {
                    return GameResult.Draw;
                }                
            }
        }

        private int RowSum(int[,] matrix, int row)
        {
            int sum = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sum += matrix[row, col];
            }

            return sum;
        }

        private int ColSum(int[,] matrix, int col)
        {
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, col];
            }

            return sum;
        }

        private int DiagonalSum(int[,] matrix, bool direction)
        {
            int offset = 0;
            if (direction)
            {
                offset = matrix.GetLength(0) - 1;
            }

            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (direction)
                {
                    sum += matrix[i, offset - i];
                }
                else
                {
                    sum += matrix[i, i];
                }
            }

            return sum;
        }
    }
}
