using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals
{
    class Portal
    {
        static void Main()
        {
            // Load data from local HDD if program is run in VS
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                Console.SetIn(new StreamReader(@"..\..\Test.txt"));
            }

            var startPointArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => int.Parse(a)).ToArray();

            var start = new Point(startPointArray[0], startPointArray[1], 0);

            var dimens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => int.Parse(a)).ToArray();

            var matrix = new int[dimens[0], dimens[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < line.Length; j++)
                {
                    char symbol = line[j][0];
                    if (symbol == '#')
                    {
                        matrix[i, j] = -1;
                    }
                    else
                    {
                        matrix[i, j] = symbol - '0';
                    }
                }
            }

            var stack = new Stack<Point>();
            stack.Push(start);

            int maxPower = 0;

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (current.Row >= 0 && current.Row < matrix.GetLength(0) && current.Col >= 0 && current.Col < matrix.GetLength(1))
                {
                    int cell = matrix[current.Row, current.Col];

                    if (cell > 0)
                    {
                        current.LastPower = cell;
                        current.Power += cell;
                        // Console.WriteLine("{0}-{1}-{2}",current.Row, current.Col, current.Power);
                        matrix[current.Row, current.Col] = 0;

                        stack.Push(new Point(current.Row - cell, current.Col, current.Power));
                        stack.Push(new Point(current.Row + cell, current.Col, current.Power));
                        stack.Push(new Point(current.Row, current.Col - cell, current.Power));
                        stack.Push(new Point(current.Row, current.Col + cell, current.Power));
                    }
                    else if (cell == 0)
                    {
                        // current.Power += cell;
                        maxPower = Math.Max(maxPower, current.Power);
                    }
                    else
                    {
                        maxPower = Math.Max(maxPower, current.Power - current.LastPower);
                    }
                }
            }

            Console.WriteLine(maxPower);
        }
    }

    class Point
    {
        public Point(int row, int col, int power)
        {
            this.Row = row;
            this.Col = col;
            this.Power = power;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Power { get; set; }

        public int LastPower { get; set; }
    }
}
