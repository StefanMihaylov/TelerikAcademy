using System;

namespace TelerikLogo
{
    class Program
    {
        static void Main()
        {
            int X = int.Parse(Console.ReadLine());
            int Z = (X/2)+1;

            int Width = 2 * (X + Z - 1) - 1;
            
            string result = new string('.', X - Z) + '*' + new string('.', Width - 2 * Z) + '*' + new string('.', X - Z);
            Console.WriteLine(result);
            for (int i = 0; i < X - Z; i++)
            {
                result = new string('.', X - Z -1 -i) + '*' + new string('.', 2*i+1) + '*';
                result += new string('.', Width - 2 * Z - 2 * i - 2);
                result += '*' + new string('.', 2*i+1) + '*' + new string('.', X - Z -1- i);
                Console.WriteLine(result);
            }
            for (int i = 0; i < X-Z-1; i++)
            {
                result = new string('.', 2 * (X - Z) + 1 + i) + '*' + new string('.', Width-4*Z-2*i);
                result += '*' + new string('.', 2 * (X - Z) +1 + i);
                Console.WriteLine(result);
            }
            result = new string('.', Width/2) + '*' + new string('.', Width/2);
            Console.WriteLine(result);
            for (int i = 0; i < X-1; i++)
            {
                result = new string('.', 2*X - Z -2 -i) + '*' + new string('.', 2*i+1) + '*';
                result += new string('.', 2*X - Z -2 -i);
                Console.WriteLine(result);
            }
            for (int i = 0; i < X - 2; i++)
            {
                result = new string('.', X - Z + 1 + i) + '*' + new string('.', 2*X - 5 - 2*i) + '*';
                result += new string('.', X - Z + 1 + i);
                Console.WriteLine(result);
            }
            result = new string('.', Width / 2) + '*' + new string('.', Width / 2);
            Console.WriteLine(result);
        }
    }
}
