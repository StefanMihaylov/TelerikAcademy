using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialValue
{
    class SpecialValue
    {
        static void ReadLine(int[][] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                string[] currentLine = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                field[i] = new int[currentLine.Length];
                
                for (int j = 0; j < field[i].Length; j++)
                {
                    field[i][j] = int.Parse(currentLine[j]);
                }
            }
        }

        static long FindCurrentSpecialValue(int[][] field, int column)
        {
            long result = 0;
            int currentRow = 0;

            bool[][] used = new bool[field.GetLength(0)][];
            for (int i = 0; i < used.GetLength(0); i++)
            {
                used[i] = new bool[field[i].Length];
            }

            while (true)
            {
                result++;

                if (used[currentRow][column])
                {
                    return long.MinValue;
                }

                if (field[currentRow][column] < 0)
                {
                    result -= field[currentRow][column];
                    return result;
                }

                used[currentRow][column] = true;
                column = field[currentRow][column];

                currentRow++;
                if (currentRow == field.GetLength(0))
                {
                    currentRow = 0;
                }
            }
        }

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            int[][] field = new int[N][];
          
            ReadLine(field);           

            long maxValue = 0;
            for (int i = 0; i < field[0].Length; i++)
            {
                long currentValue = FindCurrentSpecialValue(field, i);
                if (maxValue< currentValue)
                {
                    maxValue = currentValue;
                }
            }

            Console.WriteLine(maxValue);
        }
    }
}
