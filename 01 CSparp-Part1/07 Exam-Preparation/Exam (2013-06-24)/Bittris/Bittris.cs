using System;
using System.IO;

class Bittris
{
    static void Main()
    {
        //  // Load data from local HDD if program is run in VS
        //  bool debugPrint = false;
        //  if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
        //  {
        //      Console.SetIn(new StreamReader("Input.txt"));
        //      debugPrint = true;
        //  }

        int N = int.Parse(Console.ReadLine());
        N >>= 2; //delete N by 4;

        int score = 0;
        int[] gameField = new int[4];

        for (int i = 0; i < N; i++)
        {
            int currentInput = int.Parse(Console.ReadLine());
            int currentShape = currentInput & 255; // get the shape

            // count the number of bits in the input integer
            int numberOfBits = 0;
            while (currentInput != 0)
            {
                if (currentInput % 2 == 1)
                {
                    numberOfBits++;
                }
                currentInput >>= 1;
            }

            // read all commands
            string command = Console.ReadLine() + Console.ReadLine() + Console.ReadLine();

            int currentRow = 0;  // curret row of the table                
            for (int j = 0; j < 3; j++)
            {
                if ((command[j] == 'L') && (currentShape & 128) == 0)
                {
                    currentShape <<= 1; // shift left
                }
                else if ((command[j] == 'R') && (currentShape & 1) == 0)
                {
                    currentShape >>= 1; // shift right
                }

                if ((currentShape & gameField[currentRow + 1]) == 0) // next row is empty
                {
                    currentRow++;
                    if (currentRow < 3) 
                        continue;
                }

                // place shape on current row and calculate the score
                gameField[currentRow] |= currentShape;
                if (gameField[currentRow] < 255) // currrent row is not full 
                {
                    score += numberOfBits;
                }
                else // currrent row is full 
                {
                    score += 10 * (numberOfBits);
                    // remove current row and move upper rows down
                    for (int row = currentRow; row > 0; row--)
                    {
                        gameField[row] = gameField[row - 1];
                    }
                    gameField[0] = 0; 
                }

        //          if (debugPrint) // print some debug info if program is run on Visual Studio
        //          {
        //              Console.WriteLine();
        //              Console.WriteLine("Input#{0}, command = {1}, current = {2}, Score = {3}, Shape = {4}",
        //                  i, command, currentRow, score, Convert.ToString(currentShape, 2).PadLeft(8, '0'));
        //              for (int print = 0; print < 4; print++)
        //              {
        //                  Console.WriteLine(Convert.ToString(gameField[print], 2).PadLeft(8, '0'));
        //              }
        //          }
                break; // ignore rest of the commands
            }              
        }
        Console.WriteLine(score);
    }
}
