using System;
using System.Globalization;

class ReadTwoDates
{
    // Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.

    static void Main()
    {
        Console.Write("Enter first date in format dd.mm.yyyy: ");
        string inputDate1 = Console.ReadLine();
        Console.Write("Enter second date in format dd.mm.yyyy: ");
        string inputDate2 = Console.ReadLine();

        DateTime date1 = DateTime.ParseExact(inputDate1, "d.M.yyyy", CultureInfo.InvariantCulture);
        DateTime date2 = DateTime.ParseExact(inputDate2, "d.M.yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine("\n First date: {0:d.MM.yyyy}; Second date: {1:d.MM.yyyy} => Distance: {2} day(s)", 
            date1, date2, Math.Abs((date2-date1).Days));       
    }    
}

