using System;

namespace RevertNumberDigitsExample
{
    class RevertNumberDigits
    {
        // Write a method that reverses the digits of given decimal number. Example: 256 -> 652

        static int ReverseNumber(int number)
        {
            int sign = Math.Sign(number);
            number *= sign;    

            int power = (int)Math.Log10(number);
            int multiplier = 1;
            for (int i = 0; i < power; i++)
            {
                multiplier*=10;
            }

            int result = 0;
            while (number > 0)
            {
                result += multiplier * (number % 10);
                number /= 10;
                multiplier /= 10;
            }
            return sign*result;
        }
        
        static void Main()
        {  
            int number = ArrayLibrary.intInput(" Enter number: ");

            Console.WriteLine(" Reversed number: {0}",ReverseNumber(number));
        }
    }
}
