using System;

class PrintNumber
{
    // Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation. Format the output aligned right in 15 symbols

    static void Main()
    {
        Console.Write(" Enter number: ");
         var number = int.Parse(Console.ReadLine());

        Console.WriteLine("     Decimal format: {0,15}",number);
        Console.WriteLine(" Hexadecimal format: {0,15:X}", number);
        Console.WriteLine("  Percentage format: {0,15:P}", number);
        Console.WriteLine("  Scientific format: {0,15:E}", number);
    }
}
