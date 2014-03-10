using System;
using System.IO;
using System.Text;

namespace MaximalSum
{
    class MaximalSum
    {
        static void Main()
        {
            string filePath = @"..\..\Files\Input.txt";
            string ResultFilePath = @"..\..\Files\Output.txt";

            StreamReader reader = new StreamReader(filePath);

            int maxSum = 0;
            using (reader)
            {
                Console.Write(" Reading the file... ");
                int N = int.Parse(reader.ReadLine());
                int[,] array = new int[N, N];
                string line;                
                for (int i = 0; i < N; i++)
                {
                    line = reader.ReadLine();
                    string[] numbers = line.Split(' ');
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        array[i, j] = int.Parse(numbers[j]);
                    }
                }
                Console.WriteLine();

                int sum = 0;
                int indexRow = 0;
                int indexCol = 0;
                for (int i = 0; i < array.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < array.GetLength(1) -1; j++)
                    {
                        sum = array[i, j] + array[i, j + 1] + array[i + 1, j] + array[i + 1, j + 1];
                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            indexRow = i;
                            indexCol = j;
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine(" Maximal sum is {0} in matrix starting from [{1},{2}]", maxSum, indexRow,indexCol);
                Console.WriteLine();
            }           

            StreamWriter writer = new StreamWriter(ResultFilePath, false);
            using (writer)
            {
                Console.Write(" Writing the result to file...");
                writer.WriteLine(maxSum.ToString());
                Console.WriteLine();
            }
        }
    }
}
