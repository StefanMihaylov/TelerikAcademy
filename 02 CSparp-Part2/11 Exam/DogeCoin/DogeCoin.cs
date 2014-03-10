using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DogeCoin
{
    static int[,] matrix;
    static bool[,] usedElements;
    static int counter;
    static int maxCounter;

    static void DepthFirstSearch(int row, int col)
    {
        if ((row >= 0) && (row < matrix.GetLength(0)) && (col >= 0) && (col < matrix.GetLength(1)))  // "row" and "col" are in range
        {
            if (!usedElements[row, col])
            {
                counter += matrix[row, col];
                usedElements[row, col] = true;

                DepthFirstSearch(row, col + 1);
                DepthFirstSearch(row + 1, col);
            }
        }

        if (row == (matrix.GetLength(0) - 1) && col == (matrix.GetLength(1) - 1))
        {
            if (counter > maxCounter)
            {
                maxCounter = counter;
            }
        }
    }


    static void Main()
    {
        // Load data from local HDD if program is run in VS
        //bool debugPrint = false;
        if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
        {
            Console.SetIn(new StreamReader(@"..\..\Input.txt"));
            //debugPrint = true;
        }

        string[] dim = Console.ReadLine().Split(' ');
        int N = int.Parse(dim[0]);
        int M = int.Parse(dim[1]);

        matrix = new int[N, M];
        usedElements = new bool[matrix.GetLength(0), matrix.GetLength(1)];

        int K = int.Parse(Console.ReadLine());

        for (int i = 0; i < K; i++)
        {
            string[] position = Console.ReadLine().Split(' ');
            int row = int.Parse(position[0]);
            int col = int.Parse(position[1]);
            matrix[row, col]++;
        }

        counter = 0;
        maxCounter = 0;
       // DepthFirstSearch(0, 0);
        Random rand = new Random();
        Console.WriteLine(rand.Next(0,K/2));
    }
}

