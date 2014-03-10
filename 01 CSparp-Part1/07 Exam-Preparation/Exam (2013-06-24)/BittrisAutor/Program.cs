using System;

class Program
{
    static void Main()
    {

        int N = int.Parse(Console.ReadLine()); //this solution does not need the number of operations, so we ignore them

        // no need to keep row0 (the top row) explicitly
        // it's always 0 while the game is running

        uint row1 = 0;
        uint row2 = 0;
        uint row3 = 0;

        int score = 0;

        int current = 0;

        while (true)
        {
            current++;
            if (current > N)
            {
                Console.WriteLine(score);
                break;
            }

            uint integer;

            if (!uint.TryParse(Console.ReadLine(), out integer))
            {
                // end of input
                Console.WriteLine(score);
                return;
            }

            string controls = Console.ReadLine() + Console.ReadLine() + Console.ReadLine();

            int scoreWeight = 0;

            // calculate number of '1' bits, aka the 'hamming weight' of the piece

            for (int ii = 0; ii < 32; ++ii)
            {
                if ((integer & (1 << ii)) != 0)
                {
                    scoreWeight += 1;
                }
            }

            uint shape = integer & 255;

            // move the piece down

            for (int currentRowIndex = 0; currentRowIndex < 4; ++currentRowIndex)
            {
                if (currentRowIndex < 3)
                {
                    char ctrl = controls[currentRowIndex];

                    // perhaps shift the piece left or right
                    if (ctrl == 'L')
                    {
                        if ((shape & 128) == 0)
                        {
                            shape <<= 1;
                        }
                    }
                    else if (ctrl == 'R')
                    {
                        if ((shape & 1) == 0)
                        {
                            shape >>= 1;
                        }
                    }
                }

                int nextRowIndex = currentRowIndex + 1;
                uint nextRowBits = 0;

                switch (nextRowIndex)
                {
                    case 1: nextRowBits = row1; break;
                    case 2: nextRowBits = row2; break;
                    case 3: nextRowBits = row3; break;
                }

                if (nextRowIndex == 4 || (nextRowBits & shape) != 0)
                {
                    // piece can't go any lower
                    // 'land' the piece on the field and check if the destination row is filled
                    switch (currentRowIndex)
                    {
                        case 1: row1 |= shape; break;
                        case 2: row2 |= shape; break;
                        case 3: row3 |= shape; break;
                    }

                    bool isRowFull = false;
                    switch (currentRowIndex)
                    {
                        case 0: isRowFull = (shape == 255); break;
                        case 1: isRowFull = (row1 == 255); break;
                        case 2: isRowFull = (row2 == 255); break;
                        case 3: isRowFull = (row3 == 255); break;
                    }

                    if (isRowFull)
                    {
                        score += scoreWeight * 10;

                        // shift rows down
                        for (int ii = currentRowIndex; ii >= 1; --ii)
                        {
                            switch (ii)
                            {
                                case 1: row1 = 0; break;
                                case 2: row2 = row1; break;
                                case 3: row3 = row2; break;
                            }
                        }
                    }
                    else
                    {
                        score += scoreWeight;
                    }

                    if (currentRowIndex == 0 && !isRowFull)
                    {
                        // blocked on the top row
                        Console.WriteLine(score);
                        return;
                    }

                    break;
                }
            }

        }
    }
}
