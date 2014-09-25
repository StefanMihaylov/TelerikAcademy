namespace ExtendEmployee
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Northwind.Model;

    public class Program
    {
        // By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type EntitySet<T>.

        public static void Main()
        {
            // seee the Northwind.Model.EmployeeExtention class

            using (var db = new NorthwindEntities())
            {
                var regions = db.Employees.First().Regions;
                foreach (var region in regions)
                {
                    Console.WriteLine(region.RegionDescription);
                }
            }
        }
    }
}
