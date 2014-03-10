using System;

namespace ConvertLastDigitExample
{
    class ConvertLastDigit
    {
        // Write a method that returns the last digit of given integer as an English word. 
        // Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine"

        static string ConvertDigit(int number)
        {
            int lastDigit = number % 10;
            if (lastDigit < 0)
            {
                lastDigit *= -1;
            }

            switch (lastDigit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: return "convertion error!!!!";
            }
        }

        static void Main()
        {
            Console.Write(" Enter number: ");
            int number = int.Parse(Console.ReadLine());

            string digit = ConvertDigit(number);
            Console.WriteLine(" Last digit is {0}",digit);
        }


    }
}
