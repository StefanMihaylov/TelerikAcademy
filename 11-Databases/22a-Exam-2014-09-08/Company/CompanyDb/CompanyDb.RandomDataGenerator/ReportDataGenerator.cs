namespace CompanyDb.RandomDataGenerator
{
    using System.Collections.Generic;
    using System.Linq;

    using CompanyDb.Data;
    using RandomDataGenetaror;
    using System;

    public class ReportDataGenerator : DataGenerator, IDataGenerator
    {
        public ReportDataGenerator(ILogger logger, IRandomGenerator random, CompanyDbEntities db, int count)
            : base(logger, random, db, count, "Reports")
        {
        }

        public override void GenerateData()
        {
            var employeesIds = this.Database.Employees.Select(e => e.EmployeeId).ToList();

            for (int i = 0; i < this.Count; i++)
            {
                int randomIndex = this.Random.GetNumber(0, employeesIds.Count - 1);
                int employeeId = employeesIds[randomIndex];

                var report = new Report();
                report.EmployeeId = employeeId;
                report.Content = this.Random.GetString(10, 50);
                report.Time = this.GetRandomDate();

                this.Database.Reports.Add(report);
                SaveBatch(i);
            }
        }

        private DateTime GetRandomDate()
        {
            DateTime randomDate;
            do
            {
                int year = this.Random.GetNumber(2000, 2020);
                int month = this.Random.GetNumber(1, 12);
                int day = this.Random.GetNumber(1, 28);
                int hour = this.Random.GetNumber(0, 23);
                int minute = this.Random.GetNumber(0, 59);
                int second = this.Random.GetNumber(0, 59);

                randomDate = new DateTime(year, month, day, hour, minute, second);

            } while (randomDate > DateTime.Now);

            return randomDate;
        }
    }
}
