using System;
using System.IO;

namespace BitBall
{
    class Program
    {
        static void Main()
        {
            bool debugPrint = false;
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                Console.SetIn(new StreamReader("Input.txt"));
                debugPrint = true;
            }

            int[] top = new int[8];
            int[] bottom = new int[8];
            for (int i = 0; i < 8; i++)
            {
                top[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < 8; i++)
            {
                bottom[i] = int.Parse(Console.ReadLine());
            }

            int mask;
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    mask = 1 << column;
                    if ((top[row] & mask) != 0 && (bottom[row] & mask) != 0)
                    {
                        top[row] ^= mask;
                        bottom[row] ^= mask;
                    }
                }
            }

            int scoreTop = 0;
            int scoreBottom = 0;
            for (int column = 0; column < 8; column++) 
            {
                mask = 1 << column;
                for (int row = 0; row < 8; row++)
                {
                    if ((top[7-row] & mask) != 0)
                    {
                        for (int nextRow = 7-row; nextRow < 8; nextRow++)
                        {
                            if ((bottom[nextRow]& mask) != 0)
                            {
                                break;
                            }
                            if (nextRow == 7)
                            {
                                scoreTop++;
                            }
                        }
                        break;
                    }
                }
                for (int row = 0; row < 8; row++)
                {
                    if ((bottom[row] & mask) != 0)
                    {
                        for (int nextRow = row; nextRow >= 0; nextRow--)
                        {
                            if ((top[nextRow] & mask) != 0)
                            {
                                break;
                            }
                            if (nextRow == 0)
                            {
                                scoreBottom++;
                            }
                        }
                        break;
                    }
                }
            }
            Console.WriteLine("{0}:{1}",scoreTop,scoreBottom);
        }
    }
}
