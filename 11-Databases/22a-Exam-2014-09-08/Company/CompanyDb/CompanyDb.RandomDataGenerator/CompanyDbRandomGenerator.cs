namespace CompanyDb.RandomDataGenerator
{
    using System.Collections.Generic;

    using CompanyDb.Data;
    using RandomDataGenetaror; 

    public class CompanyDbRandomGenerator : IDataGenerator
    {
        private IRandomGenerator random;
        private ILogger logger;
        private CompanyDbEntities database;

        public CompanyDbRandomGenerator(ILogger logger, IRandomGenerator random, CompanyDbEntities database)
        {
            this.random = random;
            this.logger = logger;
            this.database = database;
        }

        public CompanyDbRandomGenerator(CompanyDbEntities database)
            : this(new ConsoleLogger(), RandomGenerator.Instance, database)
        {
        }

        public void Generate()
        {
            this.database.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>();
            listOfGenerators.Add(new DepartmentDataGenerator(this.logger, this.random, this.database, 100));
            listOfGenerators.Add(new EmployeeDataGenerator(this.logger, this.random, this.database, 5000));
            listOfGenerators.Add(new ProjectDataGenerator(this.logger, this.random, this.database, 1000));
            listOfGenerators.Add(new ReportDataGenerator(this.logger, this.random, this.database, 250000));

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                this.database.SaveChanges();
            }

            this.database.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
