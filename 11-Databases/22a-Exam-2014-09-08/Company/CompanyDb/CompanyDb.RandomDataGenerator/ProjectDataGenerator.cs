namespace CompanyDb.RandomDataGenerator
{
    using System.Collections.Generic;
    using System.Linq;

    using CompanyDb.Data;
    using RandomDataGenetaror;
    using System;

    public class ProjectDataGenerator : DataGenerator, IDataGenerator
    {
        public ProjectDataGenerator(ILogger logger, IRandomGenerator random, CompanyDbEntities db, int count)
            : base(logger, random, db, count, "Projects")
        {
        }

        public override void GenerateData()
        {
            var employeesIds = this.Database.Employees.Select(e => e.EmployeeId).ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var currentProject = new Project();
                currentProject.Name = this.Random.GetString(5, 50);

                int employeeCount = this.Random.GetNumber(2, 20);

                var UniqueEmployesIndexes = new HashSet<int>();

                while (UniqueEmployesIndexes.Count < employeeCount)
                {
                    int randomEmployeeIndex = this.Random.GetNumber(0, employeesIds.Count - 1);
                    UniqueEmployesIndexes.Add(randomEmployeeIndex);
                }

                foreach (var employeeIndex in UniqueEmployesIndexes)
                {
                    int employeeId = employeesIds[employeeIndex];

                    DateTime startDate;
                    do
                    {
                        startDate = this.GetRandomDate();

                    } while (startDate > DateTime.Now);

                    DateTime endDate;
                    do
                    {
                        endDate = this.GetRandomDate();

                    } while (startDate >= endDate);

                    var employeeProject = new EmployeesProject();
                    employeeProject.EmployeeId = employeeId;
                    employeeProject.StartingDate = startDate;
                    employeeProject.EndDate = endDate;
                    currentProject.EmployeesProjects.Add(employeeProject);
                }

                this.Database.Projects.Add(currentProject);
                SaveBatch(i);
            }
        }

        private DateTime GetRandomDate()
        {
            int year = this.Random.GetNumber(2000, 2020);
            int month = this.Random.GetNumber(1, 12);
            int day = this.Random.GetNumber(1, 28);

            return new DateTime(year, month, day);
        }
    }
}
