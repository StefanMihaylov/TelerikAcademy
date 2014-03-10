namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string tableModel, string tableMaterial, decimal tablePrice, decimal tableHeight, 
                    decimal tableLength, decimal tableWidth)
            : base(tableModel, tableMaterial, tablePrice, tableHeight)
        {
            this.Length = tableLength;
            this.Width = tableWidth;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Table length cannot be less than zero");
                }
                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Table width cannot be less than zero");
                }
                this.width = value;
            }

        }

        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Length: {1}, Width: {2}, Area: {3}", 
                base.ToString(), this.Length, this.Width, this.Area);
        }
    }
}
