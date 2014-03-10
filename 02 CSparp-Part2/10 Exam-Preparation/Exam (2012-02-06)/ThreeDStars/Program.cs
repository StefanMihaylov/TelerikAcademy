using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDStars
{
    class Program
    {
        static char[, ,] cube;

        static void Main(string[] args)
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

            int[] result = new int[26];
            int counter = 0;
            for (int width = 1; width < cube.GetLength(0) - 1; width++)
            {
                for (int higth = 1; higth < cube.GetLength(1) - 1; higth++)
                {
                    for (int depth = 1; depth < cube.GetLength(2) - 1; depth++)
                    {
                        if (IsStar(width, higth, depth))
                        {
                            counter++;
                            result[cube[width, higth, depth] - 'A']++;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] > 0)
                {
                    Console.WriteLine("{0} {1}", (char)(i + 'A'), result[i]);
                }
            }
        }

        static bool IsStar(int w, int h, int d)
        {
            int counter = 0;
            if (cube[w, h, d] == cube[w + 1, h, d]) counter++;
            if (cube[w, h, d] == cube[w - 1, h, d]) counter++;
            if (cube[w, h, d] == cube[w, h + 1, d]) counter++;
            if (cube[w, h, d] == cube[w, h - 1, d]) counter++;
            if (cube[w, h, d] == cube[w, h, d + 1]) counter++;
            if (cube[w, h, d] == cube[w, h, d - 1]) counter++;

            if (counter == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
