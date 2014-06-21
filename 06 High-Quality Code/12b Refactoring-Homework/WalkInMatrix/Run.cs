namespace WalkInMatrix
{
    using System;

    public class Run
    {
        public static void Main()
        {
            int number = ReadNumber(1, 100);

            int[,] matrix = WalkInMatrix.FillMatrix(number);

            Print(matrix);
        }

        public static int ReadNumber(int minRange, int maxRange)
        {
            Console.Write("Enter a positive number: ");
            int number = 0;
            while (!int.TryParse(Console.ReadLine(), out number) || number < minRange || number > maxRange)
            {
                Console.Write("Enter a positive number in range [{0}...{1}]: ", minRange, maxRange);
            }

            return number;
        }

        public static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3} ", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
