using System;

namespace BatGoikoTower
{
    class Program
    {
        static void Main(string[] args)
        {
            int H = int.Parse(Console.ReadLine());

            char lines =' ';
            int changeLines = 1;
            int step = 2;
            for (int i = 0; i < H; i++)
            {
                if (i == changeLines)
                {
                    lines = '-';
                    changeLines += step;
                    step++;
                }
                else
                {
                    lines = '.';
                }

                Console.WriteLine(new string('.', H - i - 1) + '/' + new string(lines, 2*i) + '\\' + new string('.', H - i - 1));
            }
        }
    }
}
