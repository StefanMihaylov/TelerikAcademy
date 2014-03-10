using System;

namespace DecimalToHexadecimal
{
    class DecimalToHexadecimal
    {
        // Write a program to convert decimal numbers to their hexadecimal representation

        static void Main()
        {
            // read number from the console
            short number;
            while (true)
            {
                Console.Write(" Enter decimal number from {0} to {1}: ", short.MinValue, short.MaxValue);
                if (short.TryParse(Console.ReadLine(), out number))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t Invalid value! Try again!");
                }
            }

            // convert "short" number to string representing hexadecimal number
            string result = "";
            if (number == 0)
            {
                result = "0";
            }

            int bit;
            for (int position = 12; position >= 0; position -= 4)
            {
                bit = (number & (15 << position)) >> position;
                if (bit >= 10)
                {
                    result += (char)('A' + bit -10);
                }
                else
                {
                    result += bit;
                }                
            }

            Console.WriteLine(" Decimal to hexadecimal: {0}", result);
            Console.WriteLine("          Second method: {0:X4}", number);  // to test the result
        }
    }
}
