using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace OnlineMarket
{
    class Market
    {
        static void Main()
        {
            // Load data from local HDD if program is run in VS
            //if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            //{
            //    Console.SetIn(new StreamReader(@"..\..\Test.txt"));
            //}

            var result = new StringBuilder();

            var types = new MultiDictionary<string, Product>(false);
            var names = new HashSet<string>();
            var prices = new OrderedBag<Product>();

            string line;
            while ((line = Console.ReadLine()) != "end")
            {
                int spaceIndex = line.IndexOf(' ');
                string command = line.Substring(0, spaceIndex);
                string[] arguments = line.Substring(spaceIndex + 1).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (command)
                {
                    case "add":
                        var newPrice = double.Parse(arguments[1]);
                        var newProduct = new Product(arguments[0], newPrice, arguments[2]);
                        if (!names.Contains(newProduct.Name))
                        {
                            names.Add(newProduct.Name);
                            types.Add(newProduct.Type, newProduct);
                            prices.Add(newProduct);
                            result.AppendFormat("Ok: Product {0} added successfully", newProduct.Name);
                            result.AppendLine();
                        }
                        else
                        {
                            result.AppendFormat("Error: Product {0} already exists", newProduct.Name);
                            result.AppendLine();
                        }
                        break;
                    case "filter":
                        string filterType = arguments[1];
                        switch (filterType)
                        {
                            case "type":
                                FilterByType(result, types, arguments[2]);
                                break;
                            case "price":
                                FilterByPrice(result, prices, arguments);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }

        private static void FilterByPrice(StringBuilder result, OrderedBag<Product> prices, string[] arguments)
        {
            IEnumerable<Product> products;
            if (arguments.Length == 6)
            {
                var from = double.Parse(arguments[3]);
                var to = double.Parse(arguments[5]);
                products = prices.Range(new Product("", from, ""), true, new Product("", to, ""), true);
            }
            else
            {
                var number = double.Parse(arguments[3]);
                if (arguments[2] == "from")
                {
                    products = prices.RangeFrom(new Product("", number, ""), true).AsQueryable();
                }
                else
                {
                    products = prices.RangeTo(new Product("", number, ""), true).AsQueryable();
                }
            }

            products = products.OrderBy(p => p.Price).ThenBy(p => p.Name).ThenBy(p => p.Type).Take(10);
            result.AppendFormat("Ok: {0}", string.Join(", ", products));
            result.AppendLine();
        }

        private static void FilterByType(StringBuilder result, MultiDictionary<string, Product> types, string type)
        {
            if (types.ContainsKey(type))
            {
                var products = types[type].OrderBy(p => p.Price).ThenBy(p => p.Name).ThenBy(p => p.Type).Take(10);
                result.AppendFormat("Ok: {0}", string.Join(", ", products));
                result.AppendLine();
            }
            else
            {
                result.AppendFormat("Error: Type {0} does not exists", type);
                result.AppendLine();
            }
        }
    }

    public class Product : IComparable<Product>
    {
        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
