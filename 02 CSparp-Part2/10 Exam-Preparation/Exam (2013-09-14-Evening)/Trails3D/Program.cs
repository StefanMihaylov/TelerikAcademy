using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trails3D
{
    class Program
    {
        static bool[,] matrix;

        struct Player
        {
            public int Row;
            public int Col;
            public string Dir;
        }

        static void Main()
        {
            // string dimentions = Console.ReadLine();

            string dimentions = "8 4 6";
            string redMoves = "2MLM1MRM2MR2MLMLMR3MRM";
            string blueMoves = "LMMR2M4MRMLMRMR1M2MRM";

            string[] dimentionsSplitted = dimentions.Split(' ');
            int X = int.Parse(dimentionsSplitted[0]);
            int Y = int.Parse(dimentionsSplitted[1]);
            int Z = int.Parse(dimentionsSplitted[2]);

            matrix = new bool[Y + 1, 2 * (X + Z)];

            Player redPlayer = new Player();
            redPlayer.Row = Y / 2;
            redPlayer.Col = X / 2;
            redPlayer.Dir = "Right";

            Player bluePlayer = new Player();
            bluePlayer.Row = Y / 2;
            bluePlayer.Col = X + Z + X / 2;
            bluePlayer.Dir = "Left";

            matrix[redPlayer.Row, redPlayer.Col] = true;
            matrix[bluePlayer.Row, bluePlayer.Col] = true;

            int redIndex = 0;
            int blueIndex = 0;
            int redForth = 0;
            int blueForth = 0;

            char redDirection;
            char blueDirection;

           while (redIndex < redMoves.Length && blueIndex < blueMoves.Length)
            {
               redDirection = ReadCommand(redMoves, ref redIndex, ref redForth);
               blueDirection = ReadCommand(blueMoves, ref blueIndex, ref blueForth);

               bool redSucceed = MovePlayer(ref redPlayer, redDirection, ref redForth);
               bool blueSucceed = MovePlayer(ref bluePlayer, blueDirection, ref blueForth);

               if (!redSucceed || !blueSucceed)
               {
                   if (!redSucceed && blueSucceed)
                   {
                       Console.WriteLine("RED");
                   }
                   else if (redSucceed && !blueSucceed)
                   {
                       Console.WriteLine("BLUE");
                   }
                   else if(!redSucceed || !blueSucceed)
                   {
                       Console.WriteLine("DRAW");
                   }
                   break;
               }
            }
        }

        static bool MovePlayer(ref Player player, char direction, ref int forth)
        {
            bool success = false;           

            if (direction == 'M' && forth > 0)
            {
                forth--;
            }       
           
            if (direction == 'M')
            {
                UpdateDirection(ref player, player.Dir);
                if (!matrix[player.Row, player.Col])
                {
                    if (player.Row >= 0 && player.Row < matrix.GetLength(0))
                    {
                        matrix[player.Row, player.Col] = true;
                        success = true;
                    }
                }
            }
            else if (direction == 'L')
            {
                if (player.Dir == "Left")
                {
                    player.Dir = "Down";
                }
                else if (player.Dir == "Down")
                {
                    player.Dir = "Right";
                }
                else if (player.Dir == "Right")
                {
                    player.Dir = "Up";
                }
                else if (player.Dir == "Up")
                {
                    player.Dir = "Left";
                }
                success = true;
                UpdateDirection(ref player, player.Dir);
            }
            else if (direction == 'R')
            {
                if (player.Dir == "Left")
                {
                    player.Dir = "Up";
                }
                else if (player.Dir == "Up")
                {
                    player.Dir = "Right";
                }
                else if (player.Dir == "Right")
                {
                    player.Dir = "Down";
                }
                else if (player.Dir == "Down")
                {
                    player.Dir = "Left";
                }
                success = true;
                UpdateDirection(ref player, player.Dir);
            }

            return success;
        }
        
        static void UpdateDirection(ref Player player, string direction)
        {
            if (direction == "Right")
            {
                player.Col++;
                if (player.Col == matrix.GetLength(1))
                {
                    player.Col = 0;
                }
            }
            else if (direction == "Left")        
            {
                player.Col--;
                if (player.Col == -1)
                {
                    player.Col = matrix.GetLength(1) - 1;
                }
            }
            else if (direction == "Up")
            {
                player.Row--;
            }
            else if (direction == "Down")
            {
                player.Row++;
            }
        }

        static char ReadCommand(string moves, ref int index, ref int forth)
        {
            char direction = 'M';
            if (forth == 0)
            {
                if (char.IsNumber(moves[index]))
                {
                    int endIndex = moves.IndexOf('M', index);
                    forth = int.Parse(moves.Substring(index, endIndex - index));
                    direction = 'M';
                    index = endIndex + 1;
                }
                else
                {
                    direction = moves[index];
                    index++;
                    if (direction == 'M')
                    {
                        forth = 1;
                    }
                }
            }
            return direction;
        }
    }
}
