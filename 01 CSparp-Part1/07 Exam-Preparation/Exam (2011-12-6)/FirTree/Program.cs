using System;

namespace FirTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int H = 1 + 2 * (N - 2);
            for (int i = 0; i < N-1; i++)
            {
                Console.WriteLine(new string('.', H / 2 - i) + new string('*', 1+2*i) + new string('.', H / 2 - i));
            }
            Console.WriteLine(new string('.', H / 2) + '*' + new string('.', H / 2));
        }
    }
}
