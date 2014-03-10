using System;

namespace DecimalToBinaryExample
{
    class DecimalToBinary
    {
        //01. Write a program to convert decimal numbers to their binary representation

        //08. Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

        static void Main()
        {      
            // read number from the console
            short number;
            while (true)
            {
                Console.Write(" Enter decimal number from {0} to {1}: ",short.MinValue,short.MaxValue);
                if (short.TryParse(Console.ReadLine(), out number))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t Invalid value! Try again!");
                }
            }

            // convert "short" number to string representing binary number
            string result = "";
            if (number == 0)
            {
                result = "0";
            }
            else
            {
                int bit;
                bool skipLeadingZeros = true;
                for (int position = 15; position >= 0; position--) // 16-bit short number
                {
                    bit = (number & (1 << position)) >> position;
                    if (bit == 1)
                    {
                        skipLeadingZeros = false;
                    }
                    if (!skipLeadingZeros)
                    {
                        result += bit;
                    }
                }  
            }
            Console.WriteLine(" Binary representation is {0}", result);
            Console.WriteLine("           Second method: {0}", Convert.ToString(number, 2)); //second method to test the result
        }
    }
}
