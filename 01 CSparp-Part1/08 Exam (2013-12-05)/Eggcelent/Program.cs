using System;

namespace Eggcelent
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            Console.WriteLine(new string('.', N + 1) + new string('*', N - 1) + new string('.', N + 1));
           
            int col = N;
            int row = 0;
            for (int i = 1; i < N-1; i++)
            {
                Console.WriteLine(new string('.', col-1) + '*' + new string('.', 3*N + 1 -2*col) +
                     '*' + new string('.', col - 1));
                if (col>2)
                {
                    col -= 2;
                }
                else
                {
                    row++;
                }
            }

            Console.Write(".*");
            bool position = true;
            for (int i = 0; i < 3*N-3; i++)
            {
                if (position)
                {
                    Console.Write("@");
                }
                else
                {
                    Console.Write(".");
                }
                position=!position;
            }
            Console.WriteLine("*.");

            Console.Write(".*");
            position = false;
            for (int i = 0; i < 3 * N - 3; i++)
            {
                if (position)
                {
                    Console.Write("@");
                }
                else
                {
                    Console.Write(".");
                }
                position = !position;
            }
            Console.WriteLine("*.");

            col = 2;
            for (int i = 1; i < N - 1; i++)
            {
                Console.WriteLine(new string('.', col - 1) + '*' + new string('.', 3 * N + 1 - 2 * col) +
                     '*' + new string('.', col - 1));
                row--;
                if (row <= 0)
                {
                    col += 2;
                }
            }

            Console.WriteLine(new string('.', N + 1) + new string('*', N - 1) + new string('.', N + 1));
        }
    }
}
