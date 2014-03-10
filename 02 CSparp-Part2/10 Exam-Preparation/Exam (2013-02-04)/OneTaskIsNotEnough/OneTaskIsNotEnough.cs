using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OneTaskIsNotEnough
{
    static void Main()
    {
        // firts task
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine(LastLamp(N));

        // second task
        Console.WriteLine(IsInCircle(Console.ReadLine()));
        Console.WriteLine(IsInCircle(Console.ReadLine()));
    }

    static int LastLamp(int N)
    {
        int[] lampsOFF = new int[N];
        bool[] lampsON = new bool[N];

        for (int i = 0; i < lampsOFF.Length; i++)
        {
            lampsOFF[i] = i + 1;
        }

        int lastLamp = 0;
        int step = 2;
        int index;
        while (N > 0)
        {
            Array.Clear(lampsON, 0, N);

            for (int i = 0; i < N; i += step)
            {
                lampsON[i] = true;
            }

            index = 0;
            for (int i = 0; i < N; i++)
            {
                if (!lampsON[i])
                {
                    lampsOFF[index] = lampsOFF[i]; // hitroooooo !!!!!
                    index++;
                    lastLamp = lampsOFF[index];
                }
            }
            N = index;
            step++;
        }

        return lastLamp;
    }

    static string IsInCircle(string input)
    {
        int[] dx = new int[] { 1, 0, -1, 0 };
        int[] dy = new int[] { 0, 1, 0, -1 };

        int x = 0;
        int y = 0;
        int orintation = 0;

        for (int turn = 0; turn < 4; turn++)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'L')
                {
                    orintation--;
                    orintation = (orintation + 4) % 4;
                }
                else if (input[i] == 'R')
                {
                    orintation++;
                    orintation %= 4;
                }
                else if (input[i] == 'S')
                {
                    x += dx[orintation];
                    y += dy[orintation];
                }
            }
        }


        if (x == 0 && y == 0)
        {
            return "bounded";
        }
        else
        {
            return "unbounded";
        }
    }
}

