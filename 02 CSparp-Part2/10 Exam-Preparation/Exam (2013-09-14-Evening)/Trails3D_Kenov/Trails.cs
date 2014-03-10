using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trails3D_Kenov
{
    class Program
    {
        static bool[,] field;

        static string convertCommands(string path)
        {
            StringBuilder result = new StringBuilder();

            path = path.Replace("M", " M ");
            path = path.Replace("L", " L ");
            path = path.Replace("R", " R ");
            string[] separtatedPaths = path.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string lastNumber = null;
            for (int i = 0; i < separtatedPaths.Length; i++)
            {
                if (separtatedPaths[i] == "L" || separtatedPaths[i] == "R")
                {
                    result.Append(separtatedPaths[i]);
                }
                else if (separtatedPaths[i] == "M")
                {
                    if (lastNumber == null)
                    {
                        result.Append("M");
                    }
                    else
                    {
                        int number = int.Parse(lastNumber);
                        result.Append(new string('M', number));
                        lastNumber = null;
                    }
                }
                else
                {
                    lastNumber = separtatedPaths[i];
                }
            }

            result.Replace("LM", "L");
            result.Replace("RM", "R");
            return result.ToString();
        }

        static void Move(ref int row, ref int col, string direction)
        {
            switch (direction)
            {
                case "up": row--; break;
                case "down": row++; break;
                case "left": col--; break;
                case "right": col++; break;
                default: break;
            }

            if (col < 0) col = field.GetLength(1) - 1;
            if (col == field.GetLength(1)) col = 0;
        }

        static string ChangeDirection(string direction, char command)
        {
            switch (direction)
            {
                case "up":
                    if (command == 'L') return "left";
                    if (command == 'R') return "right";
                    break;
                case "down":
                    if (command == 'L') return "right";
                    if (command == 'R') return "left";
                    break;
                case "left":
                    if (command == 'L') return "down";
                    if (command == 'R') return "up";
                    break;
                case "right":
                    if (command == 'L') return "up";
                    if (command == 'R') return "down";
                    break;
                default:
                    throw new ArgumentException("Invalid direction");
            }
            throw new ArgumentException("Invalid direction");
        }

        static void Main()
        {
            string dimentions = Console.ReadLine();
            //string dimentions = "8 4 6";
            string redCommandsInput = Console.ReadLine();
            //string redCommandsInput = "2MLM1MRM2MR2MLMLMR3MRM";
            string blueCommandsInput = Console.ReadLine();
            //string blueCommandsInput = "LMMR2M4MRMLMRMR1M2MRM";

            string[] dimentionsSplitted = dimentions.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int X = int.Parse(dimentionsSplitted[0]);
            int Y = int.Parse(dimentionsSplitted[1]);
            int Z = int.Parse(dimentionsSplitted[2]);

            string redCommands = convertCommands(redCommandsInput);
            string blueCommands = convertCommands(blueCommandsInput);

            field = new bool[Y + 1, 2 * (X + Z)];

            int redRow = Y / 2;
            int redCol = Z + X / 2;
            string redDir = "right";
            bool redDies = false;

            int blueRow = Y / 2;
            int blueCol = 2 * Z + X + X / 2;
            string blueDir = "left";
            bool blueDies = false;

            field[redRow, redCol] = true;
            field[blueRow, blueCol] = true;

            for (int i = 0; i < redCommands.Length; i++)
            {
                char currentRedCommand = redCommands[i];
                if (currentRedCommand == 'L' || currentRedCommand == 'R')
                {
                    redDir = ChangeDirection(redDir, currentRedCommand);
                }

                Move(ref redRow, ref redCol, redDir);

                if (redRow < 0)
                {
                    redRow = 0;
                    redDies = true;
                }
                if (redRow == field.GetLength(0))
                {
                    redRow = field.GetLength(0) - 1;
                    redDies = true;
                }

                if (field[redRow, redCol])
                {
                    redDies = true;
                }

                //blue
                char currentBlueCommand = blueCommands[i];
                if (currentBlueCommand == 'L' || currentBlueCommand == 'R')
                {
                    blueDir = ChangeDirection(blueDir, currentBlueCommand);
                }

                Move(ref blueRow, ref blueCol, blueDir);

                if (blueRow < 0)
                {
                    blueRow = 0;
                    blueDies = true;
                }
                if (blueRow == field.GetLength(0))
                {
                    blueRow = field.GetLength(0) - 1;
                    blueDies = true;
                }

                if (redRow == blueRow && redCol == blueCol)
                {
                    redDies = true;
                    blueDies = true;
                }

                if (field[blueRow, blueCol])
                {
                    blueDies = true;
                }

                if (redDies && !blueDies)
                {
                    Console.WriteLine("BLUE");
                    break;
                }
                if (!redDies && blueDies)
                {
                    Console.WriteLine("RED");
                    break;
                }
                if (redDies && blueDies)
                {
                    Console.WriteLine("DRAW");
                    break;
                }

                field[redRow, redCol] = true;
                field[blueRow, blueCol] = true;
            }

            int distanceRow = Math.Abs(redRow - Y / 2);
            int distanceCol = Math.Abs(redCol - (Z + X / 2));
            if (distanceCol > (field.GetLength(1) / 2))
            {
                distanceCol = field.GetLength(1) - distanceCol;
            }
            Console.WriteLine(distanceRow + distanceCol);
        }
    }
}
