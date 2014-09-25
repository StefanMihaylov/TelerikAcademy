using System;
using System.IO;
using System.Linq;

public class Program
{
    // Result 100/100 :)

    public static void Main()
    {
        //// Load data from local HDD if program is run in VS
        if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
        {
            Console.SetIn(new StreamReader(@"..\..\Test03.txt"));
        }

        int C = int.Parse(Console.ReadLine());

        bool[,] matrix = new bool[C, C];

        for (int i = 0; i < C; i++)
        {
            string currentRow = Console.ReadLine();
            for (int j = 0; j < currentRow.Length; j++)
            {
                char currentSymbol = currentRow[j];
                if (currentSymbol == 'Y')
                {
                    matrix[i, j] = true;
                }
            }
        }

        var salaries = new long[C];

        for (int i = 0; i < salaries.Length; i++)
        {
            GetSalary(matrix, salaries, i);
        }

        var result = salaries.Sum();

        Console.WriteLine(result);
    }

    private static long GetSalary(bool[,] matrix, long[] salaries, int person)
    {
        if (salaries[person] != 0)
        {
            return salaries[person];
        }
        else
        {
            long result = 0;
            int count = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[person, i])
                {
                    result += GetSalary(matrix, salaries, i);
                    count++;
                }
            }

            if (count == 0)
            {
                result = 1;
            }

            salaries[person] = result;
            return result;
        }
    }
}

