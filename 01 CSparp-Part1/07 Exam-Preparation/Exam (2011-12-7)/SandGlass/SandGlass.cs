using System;

namespace SandGlass
{
    class SandGlass
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int halfN = N / 2;

            for (int i = 0; i <= halfN; i++)
            {
                Console.WriteLine(new string('.', i)+new string('*', N-i*2)+new string('.', i));
            }
            for (int i = 0; i < halfN; i++)
            {
                Console.WriteLine(new string('.', halfN - i-1) + new string('*', 3 + 2*i) + new string('.', halfN - i-1));
            }
            
        }
    }
}
