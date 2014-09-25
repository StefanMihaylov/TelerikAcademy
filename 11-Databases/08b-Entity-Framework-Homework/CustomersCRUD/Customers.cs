namespace CustomersCrud
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Northwind.Model;

    public class Customers
    {
        public static void Add(NorthwindEntities northwindDB, string customerID, string companyName)
        {
            if (IsIdValid(northwindDB, customerID))
            {
                throw new ArgumentException(string.Format("Customer ID \"{0}\" alweady exist in the database", customerID));
            }

            Customer newCustomer = new Customer()
            {
                CustomerID = customerID,
                CompanyName = companyName
            };

            northwindDB.Customers.Add(newCustomer);
            northwindDB.SaveChanges();
        }

        public static void Edit(NorthwindEntities northwindDB, string oldId, string newName)
        {
            if (!IsIdValid(northwindDB, oldId))
            {
                throw new ArgumentException(string.Format("Customer ID \"{0}\" don't exist in the database", oldId));
            }

            var customer = northwindDB.Customers.FirstOrDefault(c => c.CustomerID == oldId);
            customer.CompanyName = newName;
            northwindDB.SaveChanges();
        }

        public static Customer Delete(NorthwindEntities northwindDB, string id)
        {
            if (!IsIdValid(northwindDB, id))
            {
                throw new ArgumentException(string.Format("Customer ID \"{0}\" don't exist in the database", id));
            }

            var customer = northwindDB.Customers.FirstOrDefault(c => c.CustomerID == id);
            northwindDB.Customers.Remove(customer);
            northwindDB.SaveChanges();
            return customer;
        }

        public static IQueryable<Customer> FindAll(NorthwindEntities northwindDB, int year, string country)
        {
            var result = northwindDB.Orders.Where(o => o.OrderDate.Value.Year == year && o.ShipCountry == country)
                                           .GroupBy(o => o.Customer)
                                           .Select(g => g.Key);
            return result;

        }

        public static IQueryable<string> FindAllSql(NorthwindEntities northwindDB, int year, string country)
        {
            string query = @"SELECT c.CustomerID
                            FROM Orders o
	                            JOIN Customers c
	                            ON o.CustomerID = c.CustomerID
                            WHERE o.ShipCountry = {1} And YEAR(o.ShippedDate) = {0}
                            GROUP BY c.CustomerID";

            var result = northwindDB.Database.SqlQuery<string>(query, year, country).AsQueryable();
            return result;
        }

        public static IQueryable<Order> FindAllSales(NorthwindEntities northwindDB, DateTime start, DateTime end, string region)
        {
            var result = northwindDB.Orders.Where(o => o.ShippedDate >= start && o.ShippedDate <= end && o.ShipRegion == region);
            return result;
        }


        public static string Print(NorthwindEntities northwindDB, string id)
        {
            if (!IsIdValid(northwindDB, id))
            {
                throw new ArgumentException(string.Format("Customer ID \"{0}\" don't exist in the database", id));
            }

            var customer = northwindDB.Customers.FirstOrDefault(c => c.CustomerID == id);
            return Print(customer);
        }

        public static string Print(Customer customer)
        {
            return string.Format("{0} : {1}", customer.CustomerID, customer.CompanyName);
        }

        private static bool IsIdValid(NorthwindEntities northwindDB, string id)
        {
            return northwindDB.Customers.Any(c => c.CustomerID == id);
        }
    }
}
