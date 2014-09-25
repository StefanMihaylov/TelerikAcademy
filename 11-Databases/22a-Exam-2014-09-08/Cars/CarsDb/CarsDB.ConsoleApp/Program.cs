namespace CarsDB.ConsoleApp
{
    using CarsDB.Data;
    using CarsDB.Import;
    using CarsDb.Exporter;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Connecting to database on \".\"\n");

            var database = new CarsDbContext();
            var logger = new ConsoleLogger();

            var jsonParser = new JsonParser(database, logger, @"..\..\..\");

            // import JSON only if database in empty
            var citiesCount = database.Cities.Count();
            if (citiesCount == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    jsonParser.Convert(string.Format("data.{0}.json", i));
                }
            }

            var xmlParser = new XmlParser(database, logger, @"..\..\..\", @"..\..\..\XmlResults\");

           xmlParser.Parse("Queries.xml");
           logger.LogLine("XML exported!");
        }
    }
}
