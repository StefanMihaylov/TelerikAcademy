namespace DateConverter
{
    using System;
    using System.Globalization;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConvertService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ConvertService.svc or ConvertService.svc.cs at the Solution Explorer and start debugging.

    public class ConvertService : IConvertService
    {
        public string Convert(DateTime date)
        {
            var culture = new CultureInfo("bg-BG");
            string day = culture.DateTimeFormat.GetDayName(date.DayOfWeek);
            return day;
        }
    }
}
