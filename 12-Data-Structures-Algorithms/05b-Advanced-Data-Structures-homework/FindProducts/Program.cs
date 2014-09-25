namespace FindProducts
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Program
    {
        // Write a program to read a large collection of products (name + price) and efficiently find the first 20 products in the price range [a…b]. Test for 500 000 products and 10 000 price searches

        public static void Main()
        {
            var storage = new OrderedBag<Product>();

            Random random = new Random();

            int min = 1;
            int max = 5000000; //50 000.00 лв.

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 500000; i++)
            {
                string name = "Name" + i;
                decimal price = random.Next(min, max) / 100m;
                var product = new Product(name, price);
                storage.Add(product);
            }

            var created = stopwatch.Elapsed;
            Console.WriteLine("Storage: {0} elements, created for {1}", storage.Count, created);

            decimal minRange = 100m;
            decimal maxRange = 120m;
            int topProductCount = 20;

            var productWithMinPrice = new Product("", minRange);
            var productWithMaxPrice = new Product("", maxRange);

            stopwatch.Restart();

            var productInRange = storage.Range(productWithMinPrice, true, productWithMaxPrice, true).Take(topProductCount);

            var found = stopwatch.Elapsed;
            Console.WriteLine("Top {4} products in range [{0:c2}, {1:c2}] found for {2}, count {3}"
                , minRange, maxRange, found, productInRange.Count(), topProductCount);

            // print the result
            Console.WriteLine("\n Result:");
            foreach (var item in productInRange)
            {
                Console.WriteLine(item);
            }
        }
    }
}
