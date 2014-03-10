using System;

namespace HaxadecimalToBinaryExample
{
    class HexadecimalToBinary
    {
        // Write a program to convert hexadecimal numbers to binary numbers (directly).

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

        static string HexToBin(char input)
        {
            switch (input)
            {
                case '0': return "0000";
                case '1': return "0001";
                case '2': return "0010";
                case '3': return "0011";
                case '4': return "0100";
                case '5': return "0101";
                case '6': return "0110";
                case '7': return "0111";
                case '8': return "1000";
                case '9': return "1001";
                case 'a':
                case 'A': return "1010";
                case 'b':
                case 'B': return "1011";
                case 'c':
                case 'C': return "1100";
                case 'd':
                case 'D': return "1101";
                case 'e':
                case 'E': return "1110";
                case 'f':
                case 'F': return "1111";
                default: return "error";
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
                        input = "".ToCharArray(); // empty array (maybe)
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

            // convert to hexadecimal to binary
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                result += HexToBin(input[i]) + " ";
            }

            Console.WriteLine("\t\t   Hexadecimal to binary: {0}", result);
        }
    }
}
