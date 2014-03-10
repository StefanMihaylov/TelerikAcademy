namespace ConvertNumberExample
{
    using System;

    class ConvertNumber
    {
        /* * Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
	      0 -> "Zero"
	    273 -> "Two hundred seventy three"
	    400 -> "Four hundred"
	    501 -> "Five hundred and one"
	    711 -> "Seven hundred and eleven" */

        static string[] unitsArray = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        static string[] tensArray = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        static void Main()
        {
            int number;
            while (true) // main while loop
            {
                while (true) // input while loop
                {
                    Console.Write("\t Enter number in the range [0..999]. Enter 0 for exit: ");
                    if (int.TryParse(Console.ReadLine(), out number) && number >= 0 && number <= 999)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\t\t Invalid value. Try again");
                    }
                }
  
                if (number == 0)
                {
                    Console.WriteLine("\t {0,3} -> {1} \n", number, "Zero");
                    break;  // exit of main while loop
                }

                int hundreds = number / 100;
                int hundredsRemainder = number % 100; // number = hundreds*100 + hundredsReminder;
                int tens = hundredsRemainder / 10;
                int units = hundredsRemainder % 10; // number = hundreds*100 + tens*10 + units;
                string result = "";

                if (hundreds != 0)
                {
                    result += unitsArray[hundreds] + " hundred ";
                    if (hundredsRemainder > 0 && hundredsRemainder < 20)
                    {
                        result += "and ";
                    }
                }

                if (hundredsRemainder > 0)
                {
                    if (hundredsRemainder < 20)
                    {
                        result += unitsArray[hundredsRemainder] + " ";
                    }
                    else
                    {
                        result += tensArray[tens - 2] + " ";
                        if (units != 0)
                        {
                            result += unitsArray[units];
                        }
                    }
                }
                    
                result = result.Trim(); // remove spaces, if any
                result = char.ToUpper(result[0]) + result.Substring(1); // uppercase of first letter

                Console.WriteLine("\t {0,3} -> {1}\n", number, result);
            }
        }
    }
}