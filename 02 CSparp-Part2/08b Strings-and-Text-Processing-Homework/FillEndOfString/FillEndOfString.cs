﻿using System;

class FillEndOfString
{
    // Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with '*'. Print the result string into the console.

    static void Main()
    {
        Console.Write(" Enter text [max 20 symbols]: ");
        string text = Console.ReadLine();

        if (text.Length > 20)
        {
            Console.WriteLine(" Text is too long: {0} symbols", text.Length);
        }
        else
        {

            Console.WriteLine(" Result: {0}", text.PadRight(20, '*'));
        }
    }
}

