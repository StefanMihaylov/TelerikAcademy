namespace LabirintMinimalDistance
{
    using System;
    using System.Collections.Generic;

    public class Labirinth
    {
        public const string StartPoint = "*";
        public const string EmptyCell = "0";
        public const string UnreachedCell = "u";

        public static void Main()
        {
            string[,] matrix = new string[,]
            {
                { 
                    "0", "0", "0", "x", "0", "x"
                },
                {
                    "0", "x", "0", "x", "0", "x"
                },
                {
                    "0", "*", "x", "0", "x", "0"
                },
                {
                    "0", "x", "0", "0", "0", "0"
                },
                {
                    "0", "0", "0", "x", "x", "0"
                },
                {
                    "0", "0", "0", "x", "0", "x"
                },
            };

            Console.WriteLine(" Input matrix");
            Print(matrix);

            CalculateMinimalDistance(matrix);

            Console.WriteLine("\n Result matrix");
            Print(matrix);
        }

        public static void Print(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3} ", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static void CalculateMinimalDistance(string[,] matrix)
        {
            Queue<Point> queue = new Queue<Point>();

            Point start = FindStartPoint(matrix);
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                Point current = queue.Dequeue();
                CheckNeighbours(queue, matrix, current);
                if (current.Value > 0)
                {
                    matrix[current.X, current.Y] = current.Value.ToString();
                }
            }

            MarkUnreachedCells(matrix);
        }

        private static Point FindStartPoint(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == StartPoint)
                    {
                        return new Point(i, j, 0);
                    }
                }
            }

            throw new ArgumentException("No start point in the labirinth");
        }

        private static void CheckNeighbours(Queue<Point> queue, string[,] matrix, Point center)
        {
            CheckOneNeighbour(queue, matrix, center, new Point(-1, 0, 0));
            CheckOneNeighbour(queue, matrix, center, new Point(+1, 0, 0));
            CheckOneNeighbour(queue, matrix, center, new Point(0, -1, 0));
            CheckOneNeighbour(queue, matrix, center, new Point(0, +1, 0));
        }

        private static void CheckOneNeighbour(Queue<Point> queue, string[,] matrix, Point center, Point direction)
        {
            Point limits = new Point(matrix.GetLength(0), matrix.GetLength(1), -1);

            Point current = center + direction;
            if (IsPointValid(limits, current) && matrix[current.X, current.Y] == EmptyCell)
            {
                current.Value++;
                queue.Enqueue(current);
            }
        }

        private static bool IsPointValid(Point limits, Point current)
        {
            return (current.X >= 0 && current.X < limits.X) && (current.Y >= 0 && current.Y < limits.Y);
        }

        private static void MarkUnreachedCells(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == EmptyCell)
                    {
                        matrix[i, j] = UnreachedCell;
                    }
                }
            }
        }
    }
}
