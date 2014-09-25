namespace AllPathsInLabirinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        // We are given a matrix of passable and non-passable cells. Write a recursive program for finding all paths between two cells in the matrix

        static string[,] labyrinth = 
        {
            {" ", " ", " ", "*", " ", " ", " "},
            {"*", "*", " ", "*", " ", "*", " "},
            {" ", " ", " ", " ", " ", " ", " "},
            {" ", "*", "*", "*", "*", "*", " "},
            {" ", " ", " ", " ", " ", " ", "e"},
        };

        public const string ExitString = "e";
        public const string EmptyCell = " ";
        public const string MarkString = "v";

        public static List<Tuple<int, int>> path;

        static void Main()
        {
            path = new List<Tuple<int, int>>();
            FindPath(0, 0);
        }

        private static void FindPath(int row, int col)
        {
            if (row < 0 || row >= labyrinth.GetLength(0) || col < 0 || col >= labyrinth.GetLength(1))
            {
                return;
            }

            if (labyrinth[row, col] == ExitString)
            {
                Console.WriteLine("Path: {0}", string.Join("->", path.Select(p => string.Format("({0} {1})", p.Item1, p.Item2))));
            }

            if (labyrinth[row, col] != EmptyCell)
            {
                return;
            }
            else
            {
                labyrinth[row, col] = MarkString;
                path.Add(new Tuple<int, int>(row, col));

                FindPath(row, col + 1);
                FindPath(row, col - 1);
                FindPath(row + 1, col);
                FindPath(row - 1, col);

                path.RemoveAt(path.Count - 1);
                labyrinth[row, col] = EmptyCell;
            }
        }
    }
}
