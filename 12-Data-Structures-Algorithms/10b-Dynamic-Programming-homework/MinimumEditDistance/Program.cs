using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumEditDistance
{
    class Program
    {
        public const decimal Deletion = 0.9m;
        public const decimal Insertion = 0.8m;
        public const decimal Substitution = 1m;

        static void Main()
        {
            string source = "developer";
            string target = "enveloped";

            var result = Solve(source, target);
            Console.WriteLine("Miminum edit distance between \"{1}\" and \"{2}\": {0}", result, source, target);

            // -------
            Console.WriteLine();

            source = "saturday";
            target = "sunday";

            result = Solve(source, target);
            Console.WriteLine("Miminum edit distance between \"{1}\" and \"{2}\": {0}", result, source, target);
        }

        private static decimal Solve(string source, string target)
        {
            // Levenshtein Distance matrix
            var matrix = new decimal[source.Length + 1, target.Length + 1];

            // source prefixes can be transformed into empty string by dropping all characters
            for (int i = 1; i <= source.Length; i++)
            {
                matrix[i, 0] = i * Deletion;
            }

            // target prefixes can be reached from empty source prefix by inserting every characters
            for (int j = 1; j <= target.Length; j++)
            {
                matrix[0, j] = j * Insertion;
            }

            for (int j = 1; j <= target.Length; j++)
            {
                for (int i = 1; i <= source.Length; i++)
                {
                    if (target[j - 1] == source[i - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1];
                    }
                    else
                    {
                        var forDeletion = matrix[i - 1, j] + Deletion;
                        var forInsertion = matrix[i, j - 1] + Insertion;
                        var forSubstitution = matrix[i - 1, j - 1] + Substitution;
                        matrix[i, j] = Math.Min(forDeletion, Math.Min(forInsertion, forSubstitution));
                    }
                }
            }

            // Print(matrix);

            Backtrace(matrix, source, target);

            return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
        }

        private static void Backtrace(decimal[,] matrix, string source, string target)
        {
            Console.WriteLine("Operation from last to first:");
            int row = matrix.GetLength(0) - 1;
            int col = matrix.GetLength(1) - 1;

            while (true)
            {
                if (row == 0 && col == 0)
                {
                    break;
                }

                var current = matrix[row, col];

                decimal left = decimal.MaxValue;
                if (col >= 1)
                {
                    left = matrix[row, col - 1];
                }

                decimal top = decimal.MaxValue;
                if (row >= 1)
                {
                    top = matrix[row - 1, col];
                }

                decimal leftTop = decimal.MaxValue;
                if (row >= 1 && col >= 1)
                {
                    leftTop = matrix[row - 1, col - 1];
                }

                var minValue = Math.Min(left, Math.Min(top, leftTop));
                if (leftTop == minValue)
                {
                    if (leftTop != current)
                    {
                        Console.WriteLine(" Replace \"{0}\" with \"{1}\" => {2}", source[row - 1], target[col - 1], current - leftTop);
                    }

                    row--;
                    col--;
                }
                else if (left == minValue)
                {
                    if (left != current)
                    {
                        Console.WriteLine(" Insert \"{0}\" => {1}", target[col - 1], current - left);
                    }

                    col--;
                }
                else if (top == minValue)
                {
                    if (top != current)
                    {
                        Console.WriteLine(" Delete \"{0}\" => {1}", source[row - 1], current - top);
                    }

                    row--;
                }
            }
        }

        private static void Print<T>(T[,] matrix)
        {
            int length = 4 * matrix.GetLength(1) + 1;
            Console.WriteLine(new string('-', length));
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("|{0:f1}", matrix[row, col]);
                }
                Console.WriteLine("|");
                Console.WriteLine(new string('-', length));
            }
        }
    }
}
