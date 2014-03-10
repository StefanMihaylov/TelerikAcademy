using System;
using System.Collections.Generic;

namespace HexadecimalToDecimalExample
{
    class HexadecimalToDecimal
    {
        static int CharToDec(char input)
        {
            int result;
            if ((input >= '0') && (input <= '9'))
            {
                result = (int)(input - '0');
            }
            else if ((input >= 'A') && (input <= 'F'))
            {
                result = (int)(input - 'A' + 10);
            }
            else if ((input >= 'a') && (input <= 'f'))
            {
                result = (int)(input - 'a' + 10);
            }
            else
            {
                result = -1; // error
            }
            return result;
        }

        static char DecToChar(int input)
        {
            if (input >= 10)
            {
                return (char)(input + 'A' - 10);
            }
            else if(input >= 0)
            {
                return (char)(input+'0');
            }
            else
            {
                return '*'; // error
            }
       }

        static void Main()
        {
            //read the hexadecimal number from the console
            char[] input;
            string inputString;
            int digit;
            while (true)
            {
                Console.Write(" Enter hexadecimal number [max 4 letters]: ");
                inputString = Console.ReadLine();
                input = inputString.Trim().ToCharArray();

                for (int i = 0; i < input.Length; i++)
                {
                    digit = CharToDec(input[i]);
                    if ( !(( digit >= 0) && (digit <= 15)) )
                    {
                        input = "".ToCharArray();
                        break;
                    }
                }
                if (input.Length >= 1 && input.Length <= 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t Invalid value! Try again!");
                }
            }

            // convert to hexadecimal to decimal
            int number = 0;
            digit = CharToDec(input[0]);
            if (input.Length == 4 && (digit >= 8 && digit <= 15)) // when number is negative
            {
                number = -short.MaxValue - 1;
                input[0] = DecToChar(digit - 8);
            }

            int multipy = 1;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                number += multipy * CharToDec(input[i]);
                multipy *= 16;
            }

            Console.WriteLine("\t\t   Hexadecimal to Decimal: {0}", number);
            Console.WriteLine("\t\t   Decimal to Hexadecimal: {0:X}", (short)number);  // to test the result
        }
    }
}
