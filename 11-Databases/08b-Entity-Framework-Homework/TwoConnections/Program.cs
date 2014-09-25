namespace TwoConnections
{
    using System;
    using Northwind.Model;

    public class Program
    {
        // Try to open two different data contexts and perform concurrent changes on the same records. What will happen at SaveChanges()? How to deal with it?

        public static void Main()
        {
            try
            {
                using (var firstDbContext = new NorthwindEntities())
                {
                    using (var secondDbContext = new NorthwindEntities())
                    {

                        CustomersCrud.Customers.Edit(firstDbContext, "ALFKI", "ET Бат Гьорги");
                        CustomersCrud.Customers.Edit(secondDbContext, "ALFKI", "ET Бай Стамат");
                        firstDbContext.SaveChanges();
                        secondDbContext.SaveChanges();

                        Console.WriteLine(CustomersCrud.Customers.Print(secondDbContext, "ALFKI"));
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
