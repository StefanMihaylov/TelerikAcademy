namespace DigitNameExample
{
    using System;

    class DigitName
    {
        //Write program that asks for a digit and depending on the input shows the name of that digit (in English) using a switch statement

        static void Main()
        {
            int number;
            while (true)
            {
                Console.Write("\t Enter number: ");
                if (int.TryParse(Console.ReadLine(), out number) && number>=0 && number<=9)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }
            switch (number)
            {
                case 0: Console.WriteLine("\t Zero"); break;
                case 1: Console.WriteLine("\t One"); break;
                case 2: Console.WriteLine("\t Two"); break;
                case 3: Console.WriteLine("\t Three"); break;
                case 4: Console.WriteLine("\t Four"); break;
                case 5: Console.WriteLine("\t Five"); break;
                case 6: Console.WriteLine("\t Six"); break;
                case 7: Console.WriteLine("\t Seven"); break;
                case 8: Console.WriteLine("\t Eight"); break;
                case 9: Console.WriteLine("\t Nine"); break;
            }
        }
    }
}
