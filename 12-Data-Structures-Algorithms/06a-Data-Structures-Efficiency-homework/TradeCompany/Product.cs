namespace TradeCompany
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(string title, decimal price)
        {
            this.Title = title;
            this.Price = price;
        }

        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1:c2}", this.Title, this.Price);
        }

        public int CompareTo(Product other)
        {
            if (this.Title != other.Title)
            {
                return this.Title.CompareTo(other.Title);
            }
            else
            {
                return this.Price.CompareTo(this.Price);
            }
        }
    }
}
