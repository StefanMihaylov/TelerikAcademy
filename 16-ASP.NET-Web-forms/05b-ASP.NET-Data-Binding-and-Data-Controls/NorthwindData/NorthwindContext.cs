using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindData
{
    public class NorthwindContext
    {
        private NorthwindEntities db;

        public NorthwindContext()
        {
            this.db = new NorthwindEntities();
        }

        public ICollection<EmployeeModel> GetEmployees()
        {
            var employeeList = db.Employees.Select(emp => new EmployeeModel()
            {
                Id = emp.EmployeeID,
                FullName = emp.FirstName + " " + emp.LastName
            })
            .ToList();

            return employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
            return db.Employees.FirstOrDefault(emp => emp.EmployeeID == id);
        }

        public ICollection<Employee> GetAllEmployees()
        {
            var employeeList = db.Employees.ToList();
            return employeeList;
        }
    }
}
