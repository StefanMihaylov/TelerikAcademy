using System;
using System.IO;
using System.Numerics;

namespace NaBabaMiSmetalnika
{
    class Program
    {
        static void Main()
        {             
            // Load data from local HDD if program is run in VS
            bool debugPrint = false;
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                Console.SetIn(new StreamReader("Input.txt"));
                debugPrint = true;
            }

            int width = int.Parse(Console.ReadLine());

            uint[] table = new uint[8];

            uint maskAll=((uint)Math.Pow(2,width))-1;

            for (int i = 0; i < 8; i++)
            {
                table[i] = uint.Parse(Console.ReadLine()) & maskAll;
            }
            
            if (debugPrint) ////debug
            {
                for (int i = 0; i < 8; i++)
                {
                    Console.Write("{0} ", table[i]);
                }
                Console.WriteLine();
            }

            string command;
            while (true)
            {
                command = Console.ReadLine();
                if (command == "right" || command == "left")
                {
                    int rowCommand = int.Parse(Console.ReadLine());
                    int colCommand = int.Parse(Console.ReadLine());

                    if (colCommand < 0)
                    {
                        colCommand = 0;
                    }
                    if (colCommand > width-1)
                    {
                        colCommand = width-1;
                    }

                    colCommand = width - 1 - colCommand;

                    uint shiftMask;
                    int bitShift;
                    if (command == "right")
	                {
                        bitShift = 0;
                        for (int col = 0; col <= colCommand; col++)
                        {
                            shiftMask = (uint)(1 << col);
                            if ((table[rowCommand] & shiftMask) != 0)
                            {
                                bitShift++;
                            }
                            table[rowCommand] &= (~shiftMask);
                        }
                        for (int col = 0; col < bitShift; col++)
                        {
                            shiftMask = (uint)(1 << col);
                            table[rowCommand] |= shiftMask;
                        }
	                }

                    if (command == "left")
                    {
                        bitShift = 0;
                        for (int col = colCommand; col < width; col++)
                        {
                            shiftMask = (uint)(1 << col);
                            if ((table[rowCommand] & shiftMask) != 0)
                            {
                                bitShift++;
                            }
                            table[rowCommand] &= (~shiftMask);
                        }
                        for (int col = width-bitShift; col < width; col++)
                        {
                            shiftMask = (uint)(1 << col);
                            table[rowCommand] |= shiftMask;
                        }
                    }
                }

                if (command == "reset")
                {
                    int bitCounter;
                    uint mask;
                    for (int row = 0; row < 8; row++)
                    {
                        bitCounter = 0;
                        for (int col = 0; col < width; col++)
                        {
                            mask = (uint)(1 << col);
                            if (( table[row] & mask ) != 0)
                            {
                                bitCounter++;
                            }
                        }
                        table[row] = 0;
                        for (int col = width - 1; col >= width - bitCounter; col--)
                        {
                            mask = (uint)(1 << col);
                            table[row] |= mask;
                        }
                    }
                }

                if (command == "stop")
                {
                    break;
                }

                if (debugPrint) ////debug
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Console.Write("{0} ",table[i]);
                    }
                    Console.WriteLine();
                }
            }

            BigInteger result = 0;
            for (int i = 0; i < 8; i++)
            {
                result += table[i];
            }

            int emptyCol = 0;
            int rowCounter;
            int resultmask;
            for (int col = 0; col < width; col++)
            {
                resultmask = 1 << col;
                rowCounter=0;
                for (int row = 0; row < 8; row++)
                {
                    if((table[row] & resultmask)!= 0)
                    {
                        rowCounter++;
                    }
                }
                if (rowCounter == 0)
                {
                    emptyCol++;
                }
            }

            result *= emptyCol;

            Console.WriteLine(result);
        }
    }
}
