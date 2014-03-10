using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatNumberBinary
{
    class FloatNumber
    {
        // * Write a program that shows the internal binary representation of given 32-bit signed floating-point number 
        // in IEEE 754 format (the C# type float). 
        // Example: -27,25 -> sign = 1, exponent = 10000011, mantissa = 10110100000000000000000

        static float FloatInput(string text)
        {
            float number = 0;
            while (true)
            {
                Console.Write(" {0}: ", text);
                string input = Console.ReadLine();
                if (Single.TryParse(input, out number))
                {                
                    break;
                }
                else
                {
                    Console.WriteLine("\t Invalid value \"{0}\"! Try again!",input);
                }
            }
            return number;
        }

        static void Main()
        {
            float number = FloatInput("Enter float number");

            byte[] byteArray = BitConverter.GetBytes(number);
            Array.Reverse(byteArray);

            string result = "";
            for (int i = 0; i < byteArray.Length; i++)
            {
                result += Convert.ToString(byteArray[i],2).PadLeft(8,'0');
            }

            string sign = result[0].ToString();
            string exponent = result.Substring(1, 8);
            string mantissa = result.Substring(9, 23);
            Console.WriteLine("Binary: Sign = {0} Exponent = {1} Mantissa = {2}", sign, exponent, mantissa);
        }
    }
}
