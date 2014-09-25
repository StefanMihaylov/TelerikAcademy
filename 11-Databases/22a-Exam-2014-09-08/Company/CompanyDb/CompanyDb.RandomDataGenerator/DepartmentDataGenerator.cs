namespace CompanyDb.RandomDataGenerator
{
    using System.Collections.Generic;

    using CompanyDb.Data;
    using RandomDataGenetaror;    

    public class DepartmentDataGenerator : DataGenerator, IDataGenerator
    {
        public DepartmentDataGenerator(ILogger logger, IRandomGenerator random, CompanyDbEntities db, int count)
            : base(logger, random, db, count, "Departments")
        {
        }

        public override void GenerateData()
        {
            var uniqueNames = new HashSet<string>();
            while (uniqueNames.Count < this.Count)
            {
                string name = this.Random.GetString(10, 50);
                uniqueNames.Add(name);
            }

            int index = 0;
            foreach (var name in uniqueNames)
            {
                var manufactures = new Department()
                {
                    Name = name,
                };

                this.Database.Departments.Add(manufactures);

                SaveBatch(index);
                index++;
            }
        }
    }
}
