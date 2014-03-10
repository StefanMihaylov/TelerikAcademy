using System;

namespace ForestRoad
{
    class ForestRoad
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(new string('.', i) + "*" + new string('.', N-i-1));
            }
            for (int i = 1; i < N; i++)
            {
                Console.WriteLine(new string('.', N-i-1) + "*" + new string('.', i));
            }
        }        
    }
}
