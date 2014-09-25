namespace TradeCompany
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Program
    {
        // A large trade company has millions of articles, each described by barcode, vendor, title and price. Implement a data structure to store them that allows fast retrieval of all articles in given price range [x…y]. Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET. 

        public static void Main()
        {
            var storage = new OrderedMultiDictionary<decimal, Product>(true);

            Random random = new Random();

            int min = 1;
            int max = 200000; //2 000.00 лв.

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 500000; i++)
            {
                string name = "Name" + i;
                decimal price = random.Next(min, max) / 100m;
                var product = new Product(name, price);
                storage.Add(price, product);
            }

            Console.WriteLine("Storage: {0} elements, created for {1}", storage.Count, stopwatch.Elapsed);

            decimal minRange = 100m;
            decimal maxRange = 100.5m;

            stopwatch.Restart();
            var productInRange = storage.Range(minRange, true, maxRange, true);

            Console.WriteLine("Products in range [{0:c2}, {1:c2}] found for {2}", minRange, maxRange, stopwatch.Elapsed);

            // print the result
            Console.WriteLine("\n Result:");
            foreach (var item in productInRange)
            {
                Console.WriteLine("{0:c2} : {1}", item.Key, string.Join(", ", item.Value.Select(p => p.Title)));
            }
        }
    }
}
