using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SecretsOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            BigInteger N = BigInteger.Parse(input);

            if (N < 0)
            {
                N *= -1;
            }

            BigInteger reminder;
            BigInteger sum = 0;
            int counter = 0;
            while (N > 0)
            {
                reminder = N % 10;
                N /= 10;
                counter++;
                if (counter%2!=0)
                {
                    sum += reminder * counter * counter;
                }
                else
                {
                    sum += reminder * reminder * counter;
                }
            }
            Console.WriteLine(sum);

            int length = (int)(sum % 10);
            if (length == 0)
            {
               Console.WriteLine(input + " has no secret alpha-sequence");
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    Console.Write((char)(65+(sum+i)%26));
                }
            }
        }
    }
}
