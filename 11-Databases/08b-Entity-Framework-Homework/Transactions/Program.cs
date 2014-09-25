namespace Transactions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Northwind.Model;

    public class Program
    {
        // Create a method that places a new order in the Northwind database. The order should contain several order items. Use transaction to ensure the data consistency.

        public static void Main()
        {
            ICollection<Order> orders = new List<Order>();

            // some random data
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                orders.Add(new Order()
                    {
                        Freight = random.Next(1, 100),
                        OrderDate = DateTime.Now
                    });
            }

            SaveOrder(orders);


            // print the imported data
            using (var db = new NorthwindEntities())
            {
                var insertedOrders = db.Orders.Where(o => o.OrderDate.Value.Year == 2014)
                    .Select(o => new { ID = o.OrderID, Freight = o.Freight, OrderDate = o.OrderDate });

                foreach (var order in insertedOrders)
                {
                    Console.WriteLine("{0} : Freight={1:f2}  OrderDate={2}",
                        order.ID, order.Freight, order.OrderDate.Value.ToShortDateString());
                }
            }
        }

        private static void SaveOrder(ICollection<Order> orders)
        {
            // http://msdn.microsoft.com/en-us/data/dn456843.aspx

            using (var context = new NorthwindEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Orders.AddRange(orders);
                        context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
    }
}
