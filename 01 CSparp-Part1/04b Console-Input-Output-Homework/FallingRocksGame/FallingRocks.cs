using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FallingRocksGame
{
    // * Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys). A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash. Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150). Implement collision detection and scoring system.

    class FallingRocks
    {
        public struct Dwarf
        {
            public int Row;
            public int Column;
            public int Size;
            public ConsoleColor Colour;
        }

        static char[] symbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
        static int score;
        static int speed;
        static int minSymbolsInLine = 0;
        static int maxSymbolsInLine = 5;
        static int minSpeed = 80; // ms "sleep"
        static int maxSpeed = 40; // ms "sleep"
        static Random randomGenerator = new Random();
        static Dwarf dwarf;   
        static List<string> rocksList = new List<string>();

        static void Main()
        {
            int fallingPause = 0;
            // Remove Scrollbars
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.Title = "Falling rocks";

            SetInitialPositions();           

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.LeftArrow) // move dwarf left
                    {
                        if (dwarf.Column > 0)
                        {
                            dwarf.Column--;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.RightArrow) // move dwarf right
                    {
                        if ((dwarf.Column + dwarf.Size + 2) < Console.WindowWidth)
                        {
                            dwarf.Column++;
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Escape)  //EXIT
                    {
                        break;
                    }

                    while (Console.KeyAvailable) // Clean console input buffer
                    {
                        Console.ReadKey(true);
                    }
                }

                if (fallingPause == 0)
                {
                    MoveRocksDown();
                    GenerateNewLine();
                }

                Console.Clear();                
                PrintRocks();
                DrawDwarf();
                PrintScoreAndInfo();

                fallingPause++;
                if (fallingPause > 2)  // the dwarf is 2 times faster than the rocks (or more, if required)
                {
                    fallingPause = 0;
                }

                Thread.Sleep(speed);
            }            
        }

        static void GenerateNewLine()
        {
            int maxNumber = Console.WindowWidth-1;
            int currentMaxNumber = randomGenerator.Next(minSymbolsInLine, maxSymbolsInLine+1);
            // next lone is copied from stackoverflow.com 
            var randomUniqueNumbers = Enumerable.Range(0, maxNumber).
                Select(i => randomGenerator.Next(0, maxNumber)).Distinct().Take(currentMaxNumber);
                        
            StringBuilder rowString = new StringBuilder(new string(' ', Console.WindowWidth - 1));

            int currentSymbol;
            foreach (var number in randomUniqueNumbers)
            {
                currentSymbol = randomGenerator.Next(0, symbols.Length);
                rowString[number]= symbols[currentSymbol];
            }
            rocksList.Insert(0,rowString.ToString());
        }

        static void MoveRocksDown()
        {
            if (rocksList.Count - 1 == Console.WindowHeight - 2)
            {
                string identicalWithDwarf = rocksList[rocksList.Count - 1].Substring(dwarf.Column, dwarf.Size + 2);
                if (identicalWithDwarf.Trim().Length != 0) // there arе rocks on the dwarf
                {
                    GameOverScreen();
                }
                else
                {
                    rocksList.RemoveAt(Console.WindowHeight - 2);
                    score++;
                    if (score % 100 == 0)
                    {
                        if (dwarf.Size < 5)
                        {
                            dwarf.Size++; // increase dwarf size :);
                        }
                        if (speed > maxSpeed)
                        {
                            speed -= 10; // increase speed :);
                        }
                    }
                }
            }
        }

        static void SetInitialPositions()
        {
            dwarf.Size = 1;
            dwarf.Column = Console.WindowWidth / 2 - (dwarf.Size + 2) / 2;
            dwarf.Row = Console.WindowHeight - 2;
            dwarf.Colour = ConsoleColor.White;
            rocksList.Clear();
            score = 0;
            speed = minSpeed;
        }

        static void DrawDwarf()
        {
            string dwarfPad = "(" + new string('=', dwarf.Size) + ")";
            Console.ForegroundColor = dwarf.Colour;
            Console.SetCursorPosition(dwarf.Column, dwarf.Row);
            Console.Write(dwarfPad);
        }

        static void PrintRocks()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < rocksList.Count; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(rocksList[i]);
            }
        }

        static void PrintScoreAndInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int speedStep = 1000 / (minSpeed - maxSpeed + 10);
            int speedInPersents = speedStep + (minSpeed - speed) * speedStep/10;
            PrintCenteredString(Console.WindowHeight - 1, "Score:" + score + " Speed:" + speedInPersents + "%");
            
            Console.ForegroundColor = ConsoleColor.White;
            string infoString = "Press ESC to exit";
            Console.SetCursorPosition(Console.WindowWidth / 2 + 18, Console.WindowHeight - 1);
            Console.Write(infoString);
        }

        static void PrintCenteredString(int row, string text)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, row);
            Console.Write(text);
        }

        static void GameOverScreen()
        {
            int currentRow = Console.WindowHeight / 2 - 1;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            PrintCenteredString(currentRow++, "Game Over!");
            PrintCenteredString(currentRow++, "Your score is " + score);
            PrintCenteredString(currentRow++, "Press any key to start new game");
            PrintCenteredString(currentRow++, "Press ESC to exit");
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // start new game
                if (keyInfo.Key == ConsoleKey.Escape)  //EXIT
                {
                    Environment.Exit(0); // game exit
                }
                else if (keyInfo.Key != ConsoleKey.LeftArrow && keyInfo.Key != ConsoleKey.RightArrow)
                {
                    SetInitialPositions();
                    break;
                }
            }
        }
    }
}