using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindProducts
{
    public class Product : IComparable<Product>
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0,12} : {1:c2}", this.Name, this.Price);
        }

        public int CompareTo(Product other)
        {
           return this.Price.CompareTo(other.Price);
        }
    }
}
