namespace CompanyDb.RandomDataGenerator
{
    using System.Collections.Generic;
    using System.Linq;

    using CompanyDb.Data;
    using RandomDataGenetaror;

    public class EmployeeDataGenerator : DataGenerator, IDataGenerator
    {
        public EmployeeDataGenerator(ILogger logger, IRandomGenerator random, CompanyDbEntities db, int count)
            : base(logger, random, db, count, "Employee")
        {
        }

        public override void GenerateData()
        {
            var departmentsIds = this.Database.Departments.Select(d => d.DepartmentId).ToList();
            var employeeList = new List<Employee>(this.Count);

            for (int i = 0; i < this.Count; i++)
            {
                int randomDepartmentIndex = this.Random.GetNumber(0, departmentsIds.Count - 1);
                var departmentId = departmentsIds[randomDepartmentIndex];

                var employee = new Employee()
                {
                    FirstName = this.Random.GetString(5, 20),
                    LastName = this.Random.GetString(5, 20),
                    DepartmentId = departmentId,
                    YearSalary = this.Random.GetNumber(50000, 200000),
                    Employee1 = GetManager(employeeList)
                };

                employeeList.Add(employee);
                this.Database.Employees.Add(employee);
                SaveBatch(i);
            }

            /* // Too slow
            this.Database.SaveChanges();
            this.Logger.LogLine("\nAdding managers");
            this.Database.Configuration.AutoDetectChangesEnabled = true;

            int index = 0;
            var employeesIds = this.Database.Employees.Select(e => e.EmployeeId).ToList();
            foreach (var employeeId in employeesIds)
            {
                bool hasManager = this.Random.GetChance(95);
                if (hasManager)
                {
                    int randomManagerId;
                    bool hasLoop;
                    do
                    {
                        int randomManagerIdIndex = this.Random.GetNumber(0, employeesIds.Count - 1);
                        randomManagerId = employeesIds[randomManagerIdIndex];

                        hasLoop = CheckForLoop(employeeId, randomManagerId);

                    } while (randomManagerId == employeeId || hasLoop);

                    var employee = this.Database.Employees.Find(employeeId);
                    employee.ManagerId = randomManagerId;

                    index++;
                    SaveBatch(index);
                }
            }

            this.Database.Configuration.AutoDetectChangesEnabled = false;
             */
        }

        private Employee GetManager(IList<Employee> list)
        {
            int numberOfEmployees = list.Count;
            bool hasManager = this.Random.GetChance(95);
            if (hasManager && numberOfEmployees > 5)
            {
                int randomEmployeeIndex = this.Random.GetNumber(0, numberOfEmployees - 1);
                return list[randomEmployeeIndex];
            }
            else
            {
                return null;
            }
        }

        private bool CheckForLoop(int employeeId, int? managerId)
        {
            int? currentManagerId = managerId;
            do
            {
                currentManagerId = this.Database.Employees.Find(currentManagerId).ManagerId;
                if (currentManagerId == employeeId)
                {
                    return true;
                }

            } while (currentManagerId != null);

            return false;
        }
    }
}
