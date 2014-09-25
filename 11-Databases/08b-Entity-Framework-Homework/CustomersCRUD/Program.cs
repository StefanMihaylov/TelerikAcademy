namespace CustomersCrud
{
    using System;
    using System.Linq;

    using Northwind.Model;
    using System.Data.Entity.Infrastructure;

    public class Program
    {
        /* 2. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class. 
          3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
          4. Implement previous by using native SQL query and executing it through the DbContext.
          5. Write a method that finds all the sales by specified region and period (start / end dates). */

        public static void Main()
        {
            try
            {
                Console.WriteLine("Connecting to DB...");

                using (var northwindDB = new NorthwindEntities())
                {
                    Console.WriteLine("Connected to DB...");

                    string customerId = "Pesho";
                    string firstCompanyName = "Bay Peter and sons LTD";
                    Customers.Add(northwindDB, customerId, firstCompanyName);
                    Console.WriteLine("\t Add customer   : {0}", Customers.Print(northwindDB, customerId));

                    string newCompanyName = "Бай Пешо и синове ООД";
                    Customers.Edit(northwindDB, customerId, newCompanyName);
                    Console.WriteLine("\t Edit customer  : {0}", Customers.Print(northwindDB, customerId));

                    var deletedCustomer = Customers.Delete(northwindDB, customerId);
                    Console.WriteLine("\t Delete customer: {0}", Customers.Print(deletedCustomer));

                    // tast 3.
                    Console.WriteLine("\n Companies from Canada with orders in 1997");
                    var customers = Customers.FindAll(northwindDB, 1997, "Canada");
                    foreach (var customer in customers)
                    {
                        Console.WriteLine("\t{0}", Customers.Print(customer));
                    }

                    // tast 4.
                    Console.WriteLine("\n Companies from Canada with orders in 1997 (with SQL query)");
                    var customerIDs = Customers.FindAllSql(northwindDB, 1997, "Canada");
                    foreach (var customer in customerIDs)
                    {
                        Console.WriteLine("\t{0}", Customers.Print(northwindDB, customer));
                    }

                    // tast 5.
                    Console.WriteLine("\n All sales from Washington state in given period");
                    var sales = Customers.FindAllSales(northwindDB, new DateTime(1996, 1, 1), new DateTime(1998, 1, 1), "WA");
                    foreach (var sale in sales)
                    {
                        Console.WriteLine("\t id: {0}, customer: {1}, ship date: {2}, country: {3}", sale.OrderID, sale.Customer.CompanyName, ((DateTime)sale.ShippedDate).ToString("yyyy-MM-dd"), sale.ShipCountry);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
