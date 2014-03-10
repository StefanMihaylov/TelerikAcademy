using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class StrangeLandNumbers
{
    static void Main()
    {
        List<string> digits = new List<string>() { "f", "bIN", "oBJEC", "mNTRAVL", "lPVKNQ", "pNWE", "hT" };
        for (int i = 0; i < digits.Count; i++)
        {
            digits[i] = digits[i].ToLower();
        }

        string message = Console.ReadLine();

        List<int> numbers = new List<int>();

        int start = 0;
        for (int i = 0; i < message.Length; i++)
        {
            string currentText = message.Substring(start, i - start + 1).ToLower();
            if (digits.Contains(currentText))
            {
                numbers.Add(digits.IndexOf(currentText));
                start = i+1;
            }
        }

        BigInteger result = 0;
        BigInteger multipier = 1;
        for (int i = numbers.Count - 1; i >= 0; i--)
        {
            result += numbers[i] * multipier;
            multipier *= 7;
        }

        Console.WriteLine(result);
    }
}

