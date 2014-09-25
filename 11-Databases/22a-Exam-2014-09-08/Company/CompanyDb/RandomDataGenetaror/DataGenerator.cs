namespace RandomDataGenetaror
{
    using System;

    using CompanyDb.Data;

    public abstract class DataGenerator : IDataGenerator
    {
        public DataGenerator(ILogger logger, IRandomGenerator random, CompanyDbEntities db, int count, string message)
        {
            this.Logger = logger;
            this.Random = random;
            this.Database = db;
            this.Count = count;
            this.Message = message;
        }

        protected ILogger Logger { get; private set; }

        protected IRandomGenerator Random { get; private set; }

        protected CompanyDbEntities Database { get; private set; }

        protected int Count { get; private set; }

        protected string Message { get; private set; }

        public abstract void GenerateData();

        public void Generate()
        {
            this.Logger.LogLine("Adding {0}", this.Message);

            GenerateData();

            this.Logger.LogLine("\n{0} Added!", this.Message);
        }

        public void SaveBatch(int index, int batch = 100)
        {
            if (index % batch == 0)
            {
                this.Logger.Log(".");
                this.Database.SaveChanges();
            }
        }        
    }
}
