using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeAndDecrypt
{
    class Program
    {
        static string Encrypt(string message, string cypher)
        {
            StringBuilder result = new StringBuilder(message.Length);

            if (message.Length >= cypher.Length)
            {
                int index = 0;
                for (int i = 0; i < message.Length; i++)
                {
                    int newCode = ((message[i] - 'A') ^ (cypher[index] - 'A')) + 'A';
                    result.Append((char)newCode);
                    index++;
                    if (index == cypher.Length)
                    {
                        index = 0;
                    }
                }
            }
            else
            {
                result.Append(message);
                int index = 0;
                for (int i = 0; i < cypher.Length; i++)
                {
                    int newCode = ((result[index] - 'A') ^ (cypher[i] - 'A')) + 'A';
                    result[index] = (char)newCode;

                    index++;
                    if (index == message.Length)
                    {
                        index = 0;
                    }
                }
            }

            return result.ToString();
        }

        static void Main()
        {
            string message = Console.ReadLine();

            StringBuilder decript = new StringBuilder();
            int counter = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (char.IsDigit(message[i]))
                {
                    counter++;
                }
                else
                {
                    if (counter == 0)
                    {
                        decript.Append(message[i]);
                    }
                    else
                    {
                        char letter = message[i];
                        string numberAsString = message.Substring(i - counter, counter);
                        int number = int.Parse(numberAsString);
                        decript.Append(new string(letter, number));
                        counter = 0;
                    }
                }
            }

            if (counter > 0)
            {
                decript.Append(message.Substring(message.Length - counter, counter));
            }

            message = decript.ToString();

            counter = 0;
            for (int i = message.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(message[i]))
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            int length = int.Parse(message.Substring(message.Length - counter, counter).ToString());
            string cypher = message.Substring(message.Length - length - counter, length);
            string text = message.Substring(0, message.Length - counter - length);
            Console.WriteLine(Encrypt(text, cypher));
        }
    }
}
