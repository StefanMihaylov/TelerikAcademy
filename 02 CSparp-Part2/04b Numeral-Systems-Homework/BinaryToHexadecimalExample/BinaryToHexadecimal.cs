using System;

namespace BinaryToHexadecimalExample
{
    class BinaryToHexadecimal
    {
        //Write a program to convert binary numbers to hexadecimal numbers (directly).

        static char BinToHex(string input)
        {
            switch (input)
            {
                case "0000": return '0';
                case "0001": return '1';
                case "0010": return '2';
                case "0011": return '3';
                case "0100": return '4';
                case "0101": return '5';
                case "0110": return '6';
                case "0111": return '7';
                case "1000": return '8';
                case "1001": return '9';
                case "1010": return 'A';
                case "1011": return 'B';
                case "1100": return 'C';
                case "1101": return 'D';
                case "1110": return 'E';
                case "1111": return 'F';
                default: return '*'; //error
            }
        }
        static void Main()
        {
            //read the binary number from the console
            string input;
            while (true)
            {
                Console.Write(" Enter binary number [max 16 bits]: ");
                input = Console.ReadLine();

                for (int i = 0; i < input.Length; i++)
                {
                    if ( !((input[i] == '0') || (input[i] == '1')) )
                    {
                        input = "";
                        break;
                    }
                }
                if (input.Length >= 1 && input.Length <= 16)
                {
                    break;  // exit the while loop
                }
                else
                {
                    Console.WriteLine("\t Invalid value! Try again!");  // repeat again
                }
            }

            // convert the binary to hexadecimal
            input = input.PadLeft(16, '0');
            Console.WriteLine("\t\t\t\t  Binary: {0}", input);
            string result = "";
            for (int i = 0; i < 16; i+=4)
            {
                result += BinToHex(input.Substring(i, 4));
            }
            Console.WriteLine("\t\t   Binary to hexadecimal: {0}", result);
        }
    }
}
