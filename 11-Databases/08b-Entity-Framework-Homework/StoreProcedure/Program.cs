namespace StoreProcedure
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Northwind.Model;


    public class Program
    {
        // Create a stored procedures in the Northwind database for finding the total incomes for given supplier name and period (start date, end date). Implement a C# method that calls the stored procedure and returns the retuned record set.

        public static void Main()
        {
            // http://visualstudiomagazine.com/articles/2014/04/01/calling-stored-procedures-from-entity-framework.aspx

            CreateProcedure();

            using (var db = new NorthwindEntities())
            {
                string companyName = "Bigfoot Breweries";
                DateTime startDate = new DateTime(1990, 1, 1);
                DateTime endDate = new DateTime(2000, 1, 1);

                var result = db.usp_GetTotalIncome(companyName, startDate, endDate).First();
                Console.WriteLine("Company \"{0}\" : Income = {1:c2}", companyName, result == null ? 0 : result);
            }
        }

        private static void CreateProcedure()
        {
            using (var db = new NorthwindEntities())
            {
                string command = @"CREATE PROC usp_GetTotalIncome(@supplierName nvarchar(50), @startDate date, @endDate date)
                                    AS
                                    	SELECT SUM(od.UnitPrice * CONVERT(money, (od.Quantity * (1 - od.Discount))))
                                    	FROM [Order Details] od
                                    		JOIN Orders o 
                                    		ON od.OrderID = o.OrderID
                                    		JOIN Products p 
                                    		ON od.ProductID = p.ProductID
                                    		JOIN Suppliers s 
                                    		ON p.SupplierID = s.SupplierID
                                    	WHERE (o.ShippedDate BETWEEN @startDate AND @endDate) 
                                    			AND s.CompanyName = @supplierName";

                db.Database.ExecuteSqlCommand(command);
            }
        }
    }
}
