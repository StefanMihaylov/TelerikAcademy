using System;

namespace UKFlag
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int halfN = N/2;

            for (int i = 0; i < halfN; i++)
            {
                Console.Write(new string('.', i) + '\\' + new string('.', halfN-1-i)+'|');
                Console.WriteLine(new string('.', halfN - 1 - i) + '/' + new string('.', i));
            }
            Console.WriteLine(new string('-', halfN) + '*' + new string('-', halfN));
            for (int i = halfN-1; i >= 0; i--)
            {
                Console.Write(new string('.', i) + '/' + new string('.', halfN - 1 - i) + '|');
                Console.WriteLine(new string('.', halfN - 1 - i) + '\\' + new string('.', i));
            }
        }
    }
}
