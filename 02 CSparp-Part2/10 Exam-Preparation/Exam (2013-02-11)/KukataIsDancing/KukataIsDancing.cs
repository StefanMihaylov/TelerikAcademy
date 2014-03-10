using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukataIsDancing
{
    class KukataIsDancing
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            string[] input = new string[N];
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Console.ReadLine();
            }

            char[,] field = new char[3, 3] { { 'R', 'B', 'R' }, { 'B', 'G', 'B' }, { 'R', 'B', 'R' } };

            for (int i = 0; i < input.Length; i++)
            {
                string command = input[i];
                int row = 1;
                int col = 1;
                string direction = "right";
                for (int j = 0; j < command.Length; j++)
                {
                    char letter = command[j];
                    if (letter == 'L' || letter == 'R')
                    {
                        Rotate(letter, ref direction);
                    }
                    else
                    {
                        Move(direction, ref row, ref col);
                    }
                }
                char last = field[row, col];
                if (last == 'R')
                {
                    Console.WriteLine("RED");
                }
                else if (last == 'B')
                {
                    Console.WriteLine("BLUE");
                }
                else if (last == 'G')
                {
                    Console.WriteLine("GREEN");
                }
            }
        }

        static void Move(string direction, ref int row, ref int col)
        {
            switch (direction)
            {
                case "left": col--; break;
                case "right": col++; break;
                case "up": row--; break;
                case "down": row++; break;                        
                default:
                    throw new ArgumentException("invalid direction");
            }

            if (row >= 3) row = 0;
            if (row < 0) row = 2;
            if (col >= 3) col = 0;
            if (col < 0) col = 2;
        }

        static void Rotate(char letter, ref string direction)
        {
            switch (direction)
            {
                case "left":
                    if (letter == 'L') direction = "down";
                    if (letter == 'R') direction = "up";
                    break;
                case "right":
                    if (letter == 'L') direction = "up";
                    if (letter == 'R') direction = "down";
                    break;
                case "down":
                    if (letter == 'L') direction = "right";
                    if (letter == 'R') direction = "left";
                    break;
                case "up":
                    if (letter == 'L') direction = "left";
                    if (letter == 'R') direction = "right";
                    break;
                default:
                    throw new ArgumentException("invalid direction");
            }
        }
    }
}
