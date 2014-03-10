using System;

namespace QuadronacciRectangle
{
    class Program
    {
        static void Main()
        {
            long A = long.Parse(Console.ReadLine());
            long B = long.Parse(Console.ReadLine());
            long C = long.Parse(Console.ReadLine());
            long D = long.Parse(Console.ReadLine());
            int Row = int.Parse(Console.ReadLine());
            int Col = int.Parse(Console.ReadLine());
            long T;
            int number=1;

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (number == 1)
                    {
                        Console.Write("{0}",A);                        
                    }
                    else if (number == 2)
                    {
                        Console.Write("{0}", B);
                    }
                    else if (number == 3)
                    {
                        Console.Write("{0}", C);
                    }
                    else if (number == 4)
                    {
                        Console.Write("{0}", D);
                    }
                    else
                    {
                        T = A + B + C + D;
                        A = B;
                        B = C;
                        C = D;
                        D = T;
                        Console.Write("{0}", D);
                    }

                    number++;
                    if (j != (Col-1))
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
