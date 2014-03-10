namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public Furniture(string furnitureModel, string furnitureMaterial, decimal furniturePrice, decimal furnitureHeight)
        {
            this.Model = furnitureModel;
            this.Material = furnitureMaterial;
            this.Price = furniturePrice;
            this.Height = furnitureHeight;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Furniture model cannot be empty, null or with less than 3 symbols");
                }
                this.model = value;
            }
        }

        public string Material
        {
            get 
            {
                return this.material;
            }
            protected set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Furniture material cannot be empty or null");
                }
                this.material = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Furniture price cannot be less or equal to $0.00");
                }
                this.price = value;
            }
        }

        public virtual decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Furniture height cannot be less or equal to 0.00 m");
                }
                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }
    }
}
