using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurankulakNumbers
{
    class Program
    {
        static void Main()
        {
            ulong N = ulong.Parse(Console.ReadLine());
            List<string> separatedDigits = new List<string>();

            if (N == 0)
            {
                separatedDigits.Add("A");
            }
            while (N > 0)
            {
                int digit = (int)(N % 256);
                N /= 256;
                separatedDigits.Add(ConvertDigits(digit));
            }

            StringBuilder result = new StringBuilder();

            for (int i = separatedDigits.Count - 1; i >= 0; i--)
            {
                result.Append(separatedDigits[i]);
            }

            Console.WriteLine(result);
        }

        static string ConvertDigits(int number)
        {
            int reminder = number % 26;
            number /= 26;

            if (number == 0)
            {
                return ((char)(reminder + 'A')).ToString();
            }
            else
            {
                return string.Format("{0}{1}", (char)((number - 1) + 'a'), (char)((reminder + 'A')));
            }
        }
    }
}

