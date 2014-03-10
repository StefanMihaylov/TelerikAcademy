using System;

class DayOfWeek
{
    // Write a program that prints to the console which day of the week is today. Use System.DateTime.

    static void Main()
    {
        DateTime date = DateTime.Now;
        Console.WriteLine(" Today is {0}", date.DayOfWeek); 
    }
}

