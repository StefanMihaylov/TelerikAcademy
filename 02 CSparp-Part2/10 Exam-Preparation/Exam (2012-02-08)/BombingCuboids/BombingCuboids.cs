using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BombingCuboids
{
    static char[, ,] cube;
    static bool[,] destroyed;

    static int[] result;
    static int counter;

    const char empty = '@';

    static void Main()
    {
        // Load data from local HDD if program is run in VS
        //bool debugPrint = false;
        if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
        {
            Console.SetIn(new StreamReader(@"..\..\Input.txt"));
            //debugPrint = true;
        }

        string[] dim = Console.ReadLine().Split(' ');
        int[] dimentions = new int[dim.Length];
        for (int i = 0; i < dimentions.Length; i++)
        {
            dimentions[i] = int.Parse(dim[i]);
        }

        cube = new char[dimentions[0], dimentions[1], dimentions[2]];
        destroyed = new bool[dimentions[0],dimentions[2]];

        for (int h = 0; h < dimentions[1]; h++)
        {
            string[] rows = Console.ReadLine().Split(' ');
            for (int depth = 0; depth < rows.Length; depth++)
            {
                string depthLetters = rows[depth];
                for (int width = 0; width < depthLetters.Length; width++)
                {
                    cube[width, h, depth] = depthLetters[width];
                }
            }
        }

        result = new int[26];
        counter = 0;
        int numberOfBombs = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfBombs; i++)
        {
            Array.Clear(destroyed,0,destroyed.Length);
            string[] bombString = Console.ReadLine().Split(' ');
            int[] bomb = new int[bombString.Length];
            for (int j = 0; j < bombString.Length; j++)
            {
                bomb[j] = int.Parse(bombString[j]);
            }

            RemoveCubes(bomb);
            FallDown();
        }

        Console.WriteLine(counter);
        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] > 0)
            {
                Console.WriteLine("{0} {1}",(char)(i+'A'), result[i]);
            }
        }
    }


    static void FallDown()
    {
        for (int width = 0; width < cube.GetLength(0); width++)
        {
            for (int depth = 0; depth < cube.GetLength(2); depth++)
            {
                if (!destroyed[width,depth])
                {
                    continue;
                }
                int holes = 0;
                for (int hight = 0; hight < cube.GetLength(1); hight++)
                {
                    if (cube[width, hight, depth] == empty)
                    {
                        holes++;
                    }
                    else
                    {
                        if (holes > 0)
                        {
                            cube[width, hight - holes, depth] = cube[width, hight, depth];
                            cube[width, hight, depth] = empty;
                        }
                    }
                }                
            }
        }
    }

    static void RemoveCubes(int[] bomb)
    {
        for (int width = 0; width < cube.GetLength(0); width++)
        {
            for (int hight = 0; hight < cube.GetLength(1); hight++)
            {
                for (int depth = 0; depth < cube.GetLength(2); depth++)
                {
                    int[] point = new int[] { width, hight, depth };
                    char letter = cube[width, hight, depth];
                    if (letter != empty && IsBombed(point, bomb))
                    {
                        counter++;
                        destroyed[width, depth] = true;
                        cube[width, hight, depth] = empty;
                        result[letter - 'A']++;
                    }
                }
            }
        }
    }

    static bool IsBombed(int[] coordinates, int[] bomb)
    {
        int X = coordinates[0] - bomb[0];
        int Y = coordinates[1] - bomb[1];
        int Z = coordinates[2] - bomb[2];
        double distance = Math.Sqrt(X * X + Y * Y + Z * Z);
        if (distance <= bomb[3])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

