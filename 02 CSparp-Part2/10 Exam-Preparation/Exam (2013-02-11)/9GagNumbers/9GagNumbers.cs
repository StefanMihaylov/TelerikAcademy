using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9GagNumbers
{
    class _9GagNumbers
    {
        static void Main()
        {
            string text = Console.ReadLine();
            //string text = "!!!**!-";

            List<string> tags = new List<string>() { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
            
            List<int> digits = new List<int>();

            int length = 2;
            for (int i = 0; i < text.Length; )
            {
                int index = tags.IndexOf(text.Substring(i, length));
                if (index < 0)
                {
                    length++;
                }
                else
                {
                    digits.Add(index);
                    i = i + length;
                    length = 2;
                }
            }

            ulong result = 0;
            int multiplier = digits.Count - 1;
            for (int i = 0; i < digits.Count; i++)
            {
                result += (ulong)digits[i] * Power(9, multiplier);
                multiplier--;
            }

            Console.WriteLine(result);
        }

        static ulong Power(int osnova, int multiplier)
        {
            ulong result = 1;

            for (int i = 1; i <= multiplier; i++)
            {
                result *= (ulong)osnova;
            }

            return result;
        }
    }
}
