using System;

namespace ConvertNumberExample
{
    class ConvertNumber
    {
        // Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

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
                result = 0; // error
            }
            return result;
        }
        
        static char DecToChar(int input)
        {
            if (input > 9)
            {
                return (char)(input + 'A' - 10);
            }
            else
            {
                return (char)(input + '0');
            }  
        }

        static int IntInput(string text, int min, int max)
        {
            int number = 0;
            while (true)
            {
                Console.Write("{2} from {0} to {1}: ", min, max, text);
                if (int.TryParse(Console.ReadLine(), out number) && (number >= min && number <= max))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t Invalid value! Try again!");
                }
            }
            return number;
        }

        static void Main()
        {
            int baseS = IntInput("Enter numeral system base S", 2, 16);

            Console.Write(" Enter number of base {0}: ",baseS);
            string number = Console.ReadLine();           

            int decNumber = 0;
            int digit;
            int multiplier = 1;
            for (int i = 0; i < number.Length; i++)
            {
                digit = CharToDec(number[number.Length - i - 1]);
                if (digit >= baseS)
                {
                    Console.WriteLine(" Invalid digit \"{0}\" in numeral system of base {1}",digit, baseS);
                    Environment.Exit(0);
                }
                else
                {
                    decNumber += digit * multiplier;
                    multiplier *= baseS;
                }            
            }
            Console.WriteLine(" Decimal value: {0}",decNumber);

            int baseD = IntInput("Enter numeral system base D", 2, 16);
            string result = "";
            while (decNumber > 0)
            {
                result = DecToChar(decNumber % baseD) + result;
                decNumber /= baseD;
            }            
            Console.WriteLine(" Number of base {0}: {1}", baseD, result);
        }
    }
}
