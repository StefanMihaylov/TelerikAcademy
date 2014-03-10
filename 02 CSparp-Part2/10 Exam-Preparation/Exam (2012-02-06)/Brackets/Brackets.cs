using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Brackets
{
    static void Main()
    {
        string input = Console.ReadLine();
        int N = input.Length;
        BigInteger[,] table = new BigInteger[2,N + 2];
       
        table[0,0] = 1; // start point

        for (int row = 1; row <= N; row++)
        {
            if (input[row - 1] == '(')
            {
                table[1, 0] = 0;
            }
            else
            {
                table[1, 0] = table[0, 1];
            }

            for (int col = 1; col <= N; col++)
            {
                if (input[row - 1] == '(')
                {
                    table[1, col] = table[0, col - 1];
                }
                else if (input[row - 1] == ')')
                {
                    table[1, col] = table[0, col + 1];
                }
                else
                {
                    table[1, col] = table[0, col - 1] + table[0, col + 1];
                }
            }

            for (int i = 0; i < table.GetLength(1); i++)
            {
                table[0, i] = table[1, i];
            }
        }
        Console.WriteLine(table[0, 0]);
    }
}

