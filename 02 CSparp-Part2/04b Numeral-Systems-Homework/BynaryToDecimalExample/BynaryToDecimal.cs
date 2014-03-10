using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BynaryToDecimalExample
{
    class BynaryToDecimal
    {
        // Write a program to convert binary numbers to their decimal representation

        static void Main()
        {    
            //read the binary number from the console
            List<byte> bytes = new List<byte>();
            while (true)
            {
                Console.Write(" Enter binary number [max 16 bits]: ");
                string result = Console.ReadLine();
                byte bit;
                for (int i = 0; i < result.Length; i++)
			    {
			        if(byte.TryParse(result[i].ToString(), out bit) && ((bit == 0) || (bit == 1)))
                    {
                        bytes.Add(bit);
                    }
                    else
                    {
                        bytes.Clear();
                        break;
                    }
			    }
                if (bytes.Count >= 1 && bytes.Count <= 16)
                {
                    break;  // exit the while loop
                }
                else
                {
                        Console.WriteLine("\t Invalid value! Try again!");  // repeat again
                }
            }

            // convert the array to number
            int number = 0;
            if (bytes.Count == 16 && bytes[0] == 1) // when number is negative
            {
                number = - short.MaxValue - 1;
                bytes[0] = 0;
            }
                    
            int multiplier = 1;
            for (int i = bytes.Count-1; i >= 0; i--)
			{
                if (bytes[i] == 1)
                {
                    number += multiplier;
                }
                multiplier *= 2;
			}

            Console.WriteLine("\t\t Binary to Decimal: {0}", number);
            Console.WriteLine("\t\t Decimal to Binary: {0}", Convert.ToString((short)number, 2));  // to test the result
        }
    }
}
