using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodeAndDecode
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

        static string Encode(string message)
        {
            StringBuilder result = new StringBuilder();

            int count = 1;
            char previousSymbol = message[0];
            for (int i = 1; i < message.Length; i++)
            {
                if (previousSymbol == message[i])
                {
                    count++;
                }
                else
                {
                    if (count > 2)
                    {
                        result.Append(count);
                        result.Append(previousSymbol);
                    }
                    else if (count == 2)
                    {
                        result.Append(new string(previousSymbol,2));
                    }
                    else
                    {
                        result.Append(previousSymbol);
                    }
                    count = 1;
                    previousSymbol = message[i];
                }
            }

            if (count > 2)
            {
                result.Append(count);
                result.Append(previousSymbol);
            }
            else if (count == 2)
            {
                result.Append(previousSymbol);
                result.Append(previousSymbol);
            }
            else
            {
                result.Append(previousSymbol);
            }

            return result.ToString();
        }

        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            //string message = "JOHNY";
            string cypher = Console.ReadLine();
            //string cypher = "DEPPP";

            //Console.WriteLine(Encrypt(message, cypher));
            string finalResult = Encode(Encrypt(message, cypher) + cypher) + cypher.Length;
            Console.WriteLine(finalResult);
        }
    }
}
