namespace GenerateCountriesDB
{
    using CountriesData;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main()
        {
            var db = new CountriesDbContext();
            db.Countries.Count();
            Console.WriteLine("Database initialized");
        }
    }
}
