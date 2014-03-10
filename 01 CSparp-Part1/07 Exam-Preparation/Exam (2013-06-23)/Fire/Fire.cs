using System;

namespace Fire
{
    class Fire
    {
        static void Main(string[] args)
        {
            char fire = '#';
            char torchTop = '-';
            char torchLeft = '\\';
            char torchRight = '/';
            char blank = '.';

            int N = int.Parse(Console.ReadLine());

            int halfN = N >> 1;
            int quatN = N >> 2;

            string result;

            for (int i = 0; i < halfN; i++)
            {
                result = new string(blank, halfN - i - 1);
                result += new string(fire, 1);
                result += new string(blank, i + i);
                result += new string(fire, 1);
                result += new string(blank, halfN - i - 1);
                Console.WriteLine(result);
            }

            for (int i = 0; i < quatN; i++)
            {
                result = new string(blank, i);
                result += new string(fire, 1);
                result += new string(blank, 2 * (halfN - i - 1));
                result += new string(fire, 1);
                result += new string(blank, i);
                Console.WriteLine(result);
            }

            result = new string(torchTop, N);
            Console.WriteLine(result);

            for (int i = 0; i < halfN; i++)
            {
                result = new string(blank, i);
                result += new string(torchLeft, halfN - i);
                result += new string(torchRight, halfN - i);
                result += new string(blank, i);
                Console.WriteLine(result);
            }
        }
    }
}
