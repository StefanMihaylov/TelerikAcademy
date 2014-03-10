namespace InvalidRange
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class Test
    {
        // Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range. It should hold error message and a range definition [start … end].

        // Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime> by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].
        
        public static void Check<T>(T number, T start, T end) where T: IComparable<T>, IEquatable<T>
        {
            int compareToStart = number.CompareTo(start);
            int compareToEnd = number.CompareTo(end);
            if (compareToStart < 0 || compareToEnd > 0)
            {
                throw new InvalidRangeException<T>(string.Format("Value \"{0}\" out of range",number), start, end);
            }
            Console.WriteLine("Value \"{0}\" checked", number);
        }

        public static void Main()
        {
            try
            {
                // one idea from stackoverflow to cheat DateTime to print only short format
                CultureInfo culture = new CultureInfo("en-US");
                culture.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
                culture.DateTimeFormat.LongTimePattern = "";
                Thread.CurrentThread.CurrentCulture = culture;

                // check integer value
                Check(5, 1, 100);
                Check(-1, 1, 100); // comment this line and check the rest ot commented lines to see the exception message
                // Check(123, 1, 100);

                // check DateTime value
                Check(new DateTime(1999, 05, 06), new DateTime(1980, 01, 01), new DateTime(2013, 12, 31));
                // Check(new DateTime(1752, 10, 12), new DateTime(1980, 01, 01), new DateTime(2013, 12, 31));
                // Check(new DateTime(2125, 08, 26), new DateTime(1980, 01, 01), new DateTime(2013, 12, 31));


                // I know that there is one extra space after the date, but it is 2:15am and I am tired.
                // If there is clever way to print generic value and display "generic" DateTime in short format, please let me know. :)
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
        }
    }
}
