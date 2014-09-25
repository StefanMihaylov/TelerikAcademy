namespace CompanyDb.ConsoleDataGenerator
{
    using System;

    using CompanyDb.Data;
    using CompanyDb.RandomDataGenerator;

    public class Start
    {
        public static void Main()
        {
            Console.WriteLine("Connecting to database on \".\"\n");

            var database = new CompanyDbEntities();
            var companyGenerator = new CompanyDbRandomGenerator(database);
            companyGenerator.Generate();
        }
    }
}
