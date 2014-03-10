using System;

namespace Sheets
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            string bits = Convert.ToString(N, 2).PadLeft(11,'0');
            for (int i = bits.Length-1; i >= 0; i--)
            {
                if (bits[i] == '0')
                {
                    Console.WriteLine("A{0}", i);
                }
            }
        }
    }
}
