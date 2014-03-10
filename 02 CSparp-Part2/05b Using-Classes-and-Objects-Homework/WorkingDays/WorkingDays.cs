using System;

class WorkingDays
{
    // Write a method that calculates the number of workdays between today and given date, passed as parameter. Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

    static readonly DateTime[] holidays = new DateTime[] // Part of holidays. Easter isn't included.
    {
            new DateTime(DateTime.Now.Year, 1, 1),
            new DateTime(DateTime.Now.Year, 3, 3),
            new DateTime(DateTime.Now.Year, 5, 1),
            new DateTime(DateTime.Now.Year, 5, 6),
            new DateTime(DateTime.Now.Year, 5, 24),
            new DateTime(DateTime.Now.Year, 9, 6),
            new DateTime(DateTime.Now.Year, 9, 22),
            new DateTime(DateTime.Now.Year, 12, 24),
            new DateTime(DateTime.Now.Year, 12, 25),
            new DateTime(DateTime.Now.Year, 12, 26),
    };

    static int WorkDays(DateTime testDate)
    {
        
        DateTime startDate = DateTime.Now;

        int numberOfDays = (testDate - startDate).Days;
        if(numberOfDays < 0)
        {
            startDate = testDate;
            testDate = DateTime.Now;
            numberOfDays *= -1;
        }

        int result = 0;
        DateTime currentDate = new DateTime(startDate.Year, startDate.Month, startDate.Day);
        DateTime currentHoliday;
        for (int i = 0; i <= numberOfDays; i++)
        {
            currentDate = currentDate.AddDays(1);
            bool weekend = (currentDate.DayOfWeek == DayOfWeek.Saturday) || (currentDate.DayOfWeek == DayOfWeek.Sunday);
            bool holiday = false;
            if (!weekend)       // check for holiday if current date isn't weekend
            {                            
                 for (int j = 0; j < holidays.Length; j++)
                 {
                     // build new holidey according to current year                
                     currentHoliday = new DateTime(currentDate.Year, holidays[j].Month, holidays[j].Day);
                     if (currentDate == currentHoliday)
                     {
                         holiday = true;
                         /* Console.WriteLine(" Found holiday {0}.{1:d2}.{2:d2}", 
                         currentHoliday.Year, currentHoliday.Month, currentHoliday.Day);  // Print if holiday is skiped */
                     }
                 }
            }
            if (! weekend && !holiday)
            {
                 result++;
            }              
      
        }

        return result;
    }

    static void Main()
    {
        Console.Write(" Enter year: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write(" Enter month: ");
        int month = int.Parse(Console.ReadLine());
        Console.Write(" Enter day: ");
        int day = int.Parse(Console.ReadLine());

        DateTime testDate = new DateTime(year, month, day);

        int workDays = WorkDays(testDate);
        Console.WriteLine(" Workdays between {0}.{1:d2}.{2:d2} and {3}.{4:d2}.{5:d2} are {6}", year, month, day,
            DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,workDays);
    }
}

