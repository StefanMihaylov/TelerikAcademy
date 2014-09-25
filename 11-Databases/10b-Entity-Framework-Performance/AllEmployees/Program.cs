namespace AllEmployees
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using TelerikAcademy.Model;

    public class Program
    {
        // 1. Using Entity Framework write a SQL query to select all employees from the Telerik Academy database and later print their name, department and town. Try the both variants: with and without .Include(…). Compare the number of executed SQL statements and the performance.

        // 2. Using Entity Framework write a query that selects all employees from the Telerik Academy database, then invokes ToList(), then selects their addresses, then invokes ToList(), then selects their towns, then invokes ToList() and finally checks whether the town is "Sofia". Rewrite the same in more optimized way and compare the performance.

        public static void Main()
        {
            StringBuilder result = new StringBuilder();
            Stopwatch watch = new Stopwatch();

            using (var db = new TelerikAcademyEntities())
            {
                // first connection
                var count = db.Employees.Count();

                // N+1 query problem 
                watch.Start();
                foreach (var employee in db.Employees)
                {
                    result.AppendLine(ParseEmployee(employee));
                }

                Console.WriteLine("   N+1 problem, data received for {0}", watch.Elapsed);
                // Console.WriteLine(result.ToString());

                result.Clear();
                watch.Restart();
                foreach (var employee in db.Employees.Include("Department").Include("Address"))
                {
                    result.AppendLine(ParseEmployee(employee));
                }

                Console.WriteLine("With Include(), data received for {0}", watch.Elapsed);
                // Console.WriteLine(result.ToString());

                result.Clear();
                watch.Restart();
                foreach (var employee in db.Employees.Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Department = e.Department.Name,
                    Town = e.Address.Town.Name
                }))
                {
                    string firstName = employee.FirstName;
                    string lastName = employee.LastName;
                    string department = employee.Department;
                    string town = employee.Town;

                    result.AppendLine(string.Format("{0} {1} - {2} - {3}", firstName, lastName, department, town));
                }

                Console.WriteLine(" With Select(), data received for {0}", watch.Elapsed);
                // Console.WriteLine(result.ToString());

            }

            // task 2
            using (var db = new TelerikAcademyEntities())
            {
                // first connection
                var count = db.Employees.Count();

                Console.WriteLine("\n\t Task 2");

                result.Clear();
                watch.Restart();
                var cities = db.Employees.ToList().Select(e => e.Address).ToList().Select(a => a.Town).ToList().Where(t => t.Name == "Sofia");

                foreach (var city in cities)
                {
                    result.AppendLine(city.Name);
                }

                Console.WriteLine("With ToList(), data received for {0}", watch.Elapsed);
                //Console.WriteLine(result.ToString());

                result.Clear();
                watch.Restart();
                // var cityNames = db.Employees.Select(e => e.Address).Select(a => a.Town).Select(t => t.Name).Where(n => n == "Sofia");
                var cityNames = db.Employees.Where(e => e.Address.Town.Name == "Sofia").Select(e => e.Address.Town.Name);

                foreach (var city in cityNames)
                {
                    result.AppendLine(city);
                }

                Console.WriteLine("With Select(), data received for {0}", watch.Elapsed);
                //Console.WriteLine(result.ToString());
            }
        }

        private static string ParseEmployee(Employee employee)
        {
            string firstName = employee.FirstName;
            string lastName = employee.LastName;
            string department = employee.Department.Name;
            string town = employee.Address.Town.Name;

            return string.Format("{0} {1} - {2} - {3}", firstName, lastName, department, town);
        }
    }
}
