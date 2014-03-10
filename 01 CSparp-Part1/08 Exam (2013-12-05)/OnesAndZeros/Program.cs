using System;

namespace OnesAndZeros
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            ushort numberShort = (ushort)N;
            string number = Convert.ToString(numberShort, 2).PadLeft(16, '0');

            int matrixLengh = 16 * 3 + 15;
            char[,] matrix = new char[5, matrixLengh];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < matrixLengh; j++)
                {
                    matrix[i, j] = '.';
                }
            }
            
            char[,] matrixOnes = { {'.','#','.'}, {'#','#','.'},{'.','#','.'},{'.','#','.'},{'#','#','#'} };
            char[,] matrixZeros = { { '#', '#', '#' }, { '#', '.', '#' }, { '#', '.', '#' }, { '#', '.', '#' }, { '#', '#', '#' } };
           

            int currentCol = 0;
            for (int i = 0; i < 16; i++)
            {

                if (number[i]=='0')
                {
                    for (int row = 0; row < 5; row++)
                    {
                        for (int col = 0; col < 3; col++)
                        {
                            matrix[row, currentCol+col] = matrixZeros[row, col];
                        }                        
                    }
                }

                if (number[i] == '1')
                {
                    for (int row = 0; row < 5; row++)
                    {
                        for (int col = 0; col < 3; col++)
                        {
                            matrix[row, currentCol+col] = matrixOnes[row, col];
                        }                       
                    }                    
                }
                currentCol += 4;
            }


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < matrixLengh; j++)
                {
                    Console.Write(matrix[i, j]);;
                }
                Console.WriteLine();
            }


        }
    }
}
