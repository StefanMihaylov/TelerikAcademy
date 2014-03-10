using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

class ExtractDate
{
    // Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada.

    static void Main()
    {
        string text = "I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";  // extract from Nakov's book. I have no sister.
                                                                                // dates: 14.06.198 ; 3.7.1984

        MatchCollection matches = Regex.Matches(text, @"\b[0-9]{1,2}.[0-9]{1,2}.[0-9]{4}\b");        

        // http://msdn.microsoft.com/en-us/goglobal/bb896001.aspx  list of cultures
        Thread.CurrentThread.CurrentCulture =  new CultureInfo("en-CA");
        DateTime date;
        foreach (Match match in matches)
        {
            if(DateTime.TryParseExact(match.Value, "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,out date))
            {                
                Console.WriteLine(date.ToShortDateString()); // print in current cultures
            }
        }
    }
}

