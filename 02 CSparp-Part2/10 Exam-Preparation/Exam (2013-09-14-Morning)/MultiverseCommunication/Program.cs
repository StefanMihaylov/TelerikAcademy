using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiverseCommunication
{
    class Program
    {
        static void Main()
        {
            List<string> letters = new List<string> { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };

            string messageText = Console.ReadLine();

            List<int> digits = new List<int>();
            for (int i = 0; i < messageText.Length; i += 3)
            {
                string text = messageText.Substring(i, 3);
                digits.Add(letters.IndexOf(text));
            }

            long multiplier = 1;
            long result = 0;
            for (int i = digits.Count - 1; i >= 0; i--)
            {
                result += digits[i] * multiplier;
                multiplier *= 13;
            }
            Console.WriteLine(result);
        }
    }
}
