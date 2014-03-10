using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Digits
{
    static List<int[,]> digits;
    static List<int> length;
    static int[,] matrix;

    static void Main()
    {
        // Load data from local HDD if program is run in VS
        //bool debugPrint = false;
        if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
        {
            Console.SetIn(new StreamReader(@"..\..\Input.txt"));
            //debugPrint = true;
        }

        int[,] zero = new int[,] { { 0, 0, 0 }, { 0, -1, 0 }, { 0, -1, 0 }, { 0, -1, 0 }, { 0, 0, 0 }, };
        int[,] one = new int[,] { { -1, -1, 1 }, { -1, 1, 1 }, { 1, -1, 1 }, { -1, -1, 1 }, { -1, -1, 1 }, };
        int[,] two = new int[,] { { -1, 2, -1 }, { 2, -1, 2 }, { -1, -1, 2 }, { -1, 2, -1 }, { 2, 2, 2 }, };
        int[,] three = new int[,] { { 3, 3, 3 }, { -1, -1, 3 }, { -1, 3, 3 }, { -1, -1, 3 }, { 3, 3, 3 }, };
        int[,] four = new int[,] { { 4, -1, 4 }, { 4, -1, 4 }, { 4, 4, 4 }, { -1, -1, 4 }, { -1, -1, 4 }, };
        int[,] five = new int[,] { { 5, 5, 5 }, { 5, -1, -1 }, { 5, 5, 5 }, { -1, -1, 5 }, { 5, 5, 5 }, };
        int[,] six = new int[,] { { 6, 6, 6 }, { 6, -1, -1 }, { 6, 6, 6 }, { 6, -1, 6 }, { 6, 6, 6 }, };
        int[,] seven = new int[,] { { 7, 7, 7 }, { -1, -1, 7 }, { -1, 7, -1 }, { -1, 7, -1 }, { -1, 7, -1 }, };
        int[,] eight = new int[,] { { 8, 8, 8 }, { 8, -1, 8 }, { -1, 8, -1 }, { 8, -1, 8 }, { 8, 8, 8 }, };
        int[,] nine = new int[,] { { 9, 9, 9 }, { 9, -1, 9 }, { -1, 9, 9 }, { -1, -1, 9 }, { 9, 9, 9 }, };

        digits = new List<int[,]>() { zero, one, two, three, four, five, six, seven, eight, nine };
        length = new List<int>() { 12, 7, 8, 10, 9, 11, 12, 7, 11, 11 };

        int N = int.Parse(Console.ReadLine());

        matrix = new int[N, N];
        for (int row = 0; row < N; row++)
        {
            string[] currentText = Console.ReadLine().Split(' ');
            for (int col = 0; col < currentText.Length; col++)
            {
                //matrix[row, col] = int.Parse(currentText[col]);
                matrix[row, col] = (int)(currentText[col][0] - '0');
            }
        }

        // result
        int sum = 0;
        for (int row = 0; row <= N - 5; row++)
        {
            for (int col = 0; col <= N - 3; col++)
            {
                int currentDigit = CheckDigit(row, col);
                if (currentDigit > 0)
                {
                    sum += currentDigit;
                }
            }
        }
        Console.WriteLine(sum);
    }

    static int CheckDigit(int row, int col)
    {
        int[] counters = new int[10];
        for (int i = row; i < row + 5; i++)
        {
            for (int j = col; j < col + 3; j++)
            {
                counters[matrix[i, j]]++;
            }
        }

        for (int i = 0; i < counters.Length; i++)
        {
            if (counters[i] >= length[i])
            {
                if (IsMatched(row, col, i))
                {
                    return i;
                }
            }
        }

        return -1;
    }

    static bool IsMatched(int row, int col, int number)
    {
        int[,] checkedDigit = digits[number];
        int counter = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (checkedDigit[i,j] == matrix[row+i, col+j])
                {
                    counter++;
                }
            }
        }
        if (counter == length[number])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

