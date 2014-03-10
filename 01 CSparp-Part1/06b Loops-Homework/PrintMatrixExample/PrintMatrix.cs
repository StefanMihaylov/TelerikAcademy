namespace PrintMatrixExample
{
    using System;

    class PrintMatrix
    {
        // Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix

        static void Main()
        {
            int valueN;
            while (true)
            {
                Console.Write("\t Enter integer 0<N<20: ");
                if (int.TryParse(Console.ReadLine(), out valueN) && valueN > 0 && valueN<20)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value! Try again!");
                }
            }

            for (int row = 1; row <= valueN; row++)
            {
                Console.Write("\t");
                for (int column = row; column < valueN+row; column++)
                {
                    Console.Write("{0,2} ",column);
                }
                Console.WriteLine();
            }
        }
    }
}
