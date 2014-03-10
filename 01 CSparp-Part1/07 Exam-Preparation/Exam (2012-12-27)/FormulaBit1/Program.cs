using System;
using System.IO;

namespace FormulaBit1
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

            byte[] matrix = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                matrix[i] = byte.Parse(Console.ReadLine());
            }

            string direction = "south";
            int trackLenght = 0;
            int countTurns = 0;
            string nextDirection = "";
            bool isFinished = false;
            bool dirChanged = false;
            int carRow = 0;
            int carColumn = 0;

            if ((matrix[0] & 1) == 0)
            {
                trackLenght++;
                while (true)
                {
                    switch (direction)
                    {
                        case "south": nextDirection = "west1"; break;
                        case "west1": nextDirection = "north"; break;
                        case "north": nextDirection = "west2"; break;
                        case "west2": nextDirection = "south"; break;
                    }
                                    
                    int nextRow;
                    int nextColumn;
                    bool borderReached;
                    int mask;
                    if (direction == "south")
                    {
                        nextRow = carRow + 1;
                        nextColumn = carColumn;
                        mask = 1 << nextColumn;
                        borderReached = nextRow < 8;
                    }
                    else if (direction == "north")
                    {
                        nextRow = carRow - 1;
                        nextColumn = carColumn;
                        mask = 1 << nextColumn;
                        borderReached = nextRow >= 0;
                    }
                    else
                    {
                        nextRow = carRow;
                        nextColumn = carColumn+1;
                        mask = 1 << nextColumn;
                        borderReached = nextColumn < 8;
                    }

                    if (borderReached && ((matrix[nextRow] & mask) == 0))
                    {
                        trackLenght++;
                        carRow = nextRow;
                        carColumn = nextColumn;
                        dirChanged = false;
                    }
                    else
                    {
                        if (!dirChanged)
                        {
                            direction = nextDirection;
                            dirChanged = true;
                            countTurns++;
                        }
                        else
                        {
                            break;    
                        } 
                    }

                    if (carRow == 7 && carColumn == 7)
                    {
                        isFinished = true;
                        break;
                    }        
                }
            }

            if(isFinished)
            {
                Console.WriteLine("{0} {1}",trackLenght, countTurns);
            }
            else
            {
                Console.WriteLine("No {0}", trackLenght);
            }
        }
    }
}
