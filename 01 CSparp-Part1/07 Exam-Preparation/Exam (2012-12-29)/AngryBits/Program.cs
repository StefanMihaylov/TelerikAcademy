using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBits
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

            ushort[] matrix = new ushort[8];
            
            for (int i = 0; i < 8; i++)
            {
                matrix[i] = ushort.Parse(Console.ReadLine());
            }

            long score = 0;

            for (int col = 8; col < 16; col++)
            {
                ushort mask = (ushort)(1 << col); 
                for (int row = 0; row < 8; row++)
                {
                    if ((matrix[row] & mask) != 0)
                    {
                        matrix[row] ^= mask;
                        bool upDirection = true;
                        int flyRow = row;
                        int flyCol = col;
                        int flyLength = 0;

                        while (true)
                        {
                            if (flyRow == 0) upDirection = false;
                            if (upDirection)
                            {
                                flyRow--;                                
                            }
                            else flyRow++;
                            flyCol--;
                            flyLength++;                            

                            if ((flyCol >= 0 && flyCol < 8) && (flyRow >= 0 && flyRow < 8))
                            {
                                int secondMAsk = 1 << flyCol;
                                if ((matrix[flyRow] & secondMAsk) != 0)
                                {
                                    int bitCount = 0;
                                    for (int i = flyRow - 1; i <= flyRow + 1; i++)
                                    {
                                        for (int j = flyCol - 1; j <= flyCol + 1; j++)
                                        {
                                            if ((j >= 0 && j < 8) && (i >= 0 && i < 8))
                                            {
                                                int thirdMask = 1 << j;
                                                if ((matrix[i] & thirdMask) != 0)
                                                {
                                                    bitCount++;
                                                    matrix[i] ^= (ushort)thirdMask;
                                                }
                                            }
                                        }
                                    }
                                    if (debugPrint)
                                    {
                                        Console.WriteLine("{0}, {1}*{2}, [{3} {4}]; [{5} {6}]", score, bitCount, flyLength, row, col, flyRow, flyCol);
                                    }
                                    score += (bitCount * flyLength);
                                    break;
                                }
                            }
                            if (flyCol == 0 || flyRow == 7)
                            {
                                break;
                            }
                        }
                        
                    }                    
                }
            }

            bool isEmpty = true;
            for (int row = 0; row < 8; row++)
            {
                if ((matrix[row] & 255)!=0)
                {
                    isEmpty = false;
                }
            }
            
            Console.WriteLine("{0} {1}",score,isEmpty?"Yes":"No");            
        }
    }
}
