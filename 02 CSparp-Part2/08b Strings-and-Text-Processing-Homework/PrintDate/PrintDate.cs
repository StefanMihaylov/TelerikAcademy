using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

class PrintDate
{
    // Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the dateandtime    after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian

      static void Main()
      {      
          // Console.Write("Enter date in format dd.mm.yyyy hh:mm:ss : ");
          // string inputDate = Console.ReadLine();

          string inputDate = "05.06.2007 20:19:18"; // Random date        

          DateTime date = DateTime.ParseExact(inputDate, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
          Console.WriteLine(" Date: {0:d.MM.yyyy H:m:s}", date);

          date = date.AddHours(6);
          date = date.AddMinutes(30);
           Console.WriteLine(" After 6h 30 min date will be {0:d.MM.yyyy h:m:s}, day of week: {1}",
           date, date.ToString("dddd", new CultureInfo("bg-BG")));
      }
}

