using System;

namespace FallDown
{
    class Program
    {
        static void Main()
        {
            char[,] matrix = new char[8, 8];
            string input;
            for (int i = 0; i < 8; i++)
            {
                input = Convert.ToString(int.Parse(Console.ReadLine()),2).PadLeft(8,'0');                
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int counter;
            for (int j = 0; j < 8; j++)
            {
                counter = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (matrix[i,j]=='1')
                    {
                        counter++;
                        matrix[i, j] = '0';
                    }
                }
                for (int i = 0; i < counter; i++)
                {
                    matrix[7-i, j] = '1';
                }
            }
            int result;
            int multiply;
            for (int i = 0; i < 8; i++)
            {
                result = 0;
                multiply = 1;
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, 7-j]=='1')
                    {
                        result += multiply;
                    }
                    multiply *= 2;
                }
                Console.WriteLine(result);
            }
        }
    }
}
