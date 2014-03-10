using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelColumns
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            long result = 0;
            long multiplier = 1;
            for (int i = 0; i < N-1; i++)
            {
                multiplier *= 26;
            }

            for (int i = 0; i < N; i++)
            {
                char currentLetter = char.Parse(Console.ReadLine());
                result += ((int)(currentLetter) - 64) * multiplier;
                multiplier /= 26;
            }
            Console.WriteLine(result);
        }
    }
}
