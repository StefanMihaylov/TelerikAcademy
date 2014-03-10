using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurankulakNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();          

            List<int> digits = new List<int>();
            string letter;
            for (int index = 0; index < input.Length; index++)
            {
                if (char.IsUpper(input[index]))
                {
                    letter = input.Substring(index, 1);
                }
                else
                {
                    letter = input.Substring(index, 2);
                    index++;
                }                
                digits.Add(ConvertLetters(letter));
            }

            long result = 0;
            long multiplier = 1;
            for (int i = digits.Count - 1; i >= 0; i--)
            {
                result += digits[i] * multiplier;
                multiplier *= 168;
            }

            Console.WriteLine(result);
        }

        static int ConvertLetters(string letter)
        {
            if (letter.Length == 1)
            {
                return letter[0] - 'A';
            }
            else
            {
                return (letter[0] - 'a' + 1) * 26 + (letter[1] - 'A');
            }
        }
    }
}
