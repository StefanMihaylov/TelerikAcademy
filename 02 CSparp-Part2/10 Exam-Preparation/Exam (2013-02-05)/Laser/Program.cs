using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laser
{
    class Program
    {
        public static int[] dimentions;

        static void Main(string[] args)
        {
            // Load data from local HDD if program is run in VS
            //bool debugPrint = false;
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                Console.SetIn(new StreamReader(@"..\..\Input.txt"));
                //debugPrint = true;
            }

            dimentions = Parser(Console.ReadLine(), new char[] { ',', ' ' });
            int[] startPoint = Parser(Console.ReadLine(), new char[] { ',', ' ' });
            int[] direction = Parser(Console.ReadLine(), new char[] { ',', ' ' });

            bool[, ,] cube = new bool[dimentions[0], dimentions[1], dimentions[2]];

            for (int i = 1; i <= dimentions[0]; i++)
            {
                for (int j = 1; j <= dimentions[1]; j++)
                {
                    for (int k = 1; k <= dimentions[2]; k++)
                    {
                        if (IsEdge(new int[]{i,j,k}))
                        {
                            cube[i - 1, j - 1, k - 1] = true;
                        }
                    }
                }
            }

            cube[startPoint[0] - 1, startPoint[1] - 1, startPoint[2] - 1] = true;

            int[] currentPosition = startPoint;
            int[] nextPosition;
            while (true)
            {
                nextPosition = NextPosition(currentPosition, direction);
                if (!cube[nextPosition[0]-1,nextPosition[1]-1,nextPosition[2]-1])
                {
                    Array.Copy(nextPosition, currentPosition, nextPosition.Length);
                    cube[currentPosition[0] - 1, currentPosition[1] - 1, currentPosition[2] - 1] = true;
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}",currentPosition[0], currentPosition[1], currentPosition[2]);
                    break;
                }
            }
        }

        static int[] Parser(string input, char[] splitArray)
        {
            string[] inputArray = input.Split(splitArray, StringSplitOptions.RemoveEmptyEntries);

            int[] steps = new int[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                steps[i] = int.Parse(inputArray[i]);
            }
            return steps;
        }

        static bool IsEdge(int[] coordinates)
        {
            bool Wend = coordinates[0] == 1 || coordinates[0] == dimentions[0];
            bool Hend = coordinates[1] == 1 || coordinates[1] == dimentions[1];
            bool Dend = coordinates[2] == 1 || coordinates[2] == dimentions[2];
            if (Wend && Hend || Wend && Dend || Hend && Dend)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int[] NextPosition(int[] position, int[] direction)
        {

            int[] nextPositon = new int[position.Length];
            Array.Copy(position, nextPositon, position.Length);

            nextPositon[0] += direction[0];
            nextPositon[1] += direction[1];
            nextPositon[2] += direction[2];

            if ((nextPositon[0] < 1) || (nextPositon[0] > dimentions[0]))
            {
                direction[0] = 0 - direction[0];
                nextPositon[0] += 2*direction[0];
            }

            if ((nextPositon[1] < 1) || (nextPositon[1] > dimentions[1]))
            {
                direction[1] = 0 - direction[1];
                nextPositon[1] += 2*direction[1];
            }

            if ((nextPositon[2] < 1) || (nextPositon[2] > dimentions[2]))
            {
                direction[2] = 0 - direction[2];
                nextPositon[2] += 2*direction[2];
            }

            return nextPositon;
        }
    }
}
