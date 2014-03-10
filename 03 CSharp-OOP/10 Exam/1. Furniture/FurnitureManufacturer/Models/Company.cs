namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FurnitureManufacturer.Interfaces;

    class Company : ICompany
    {
        private const int MinCompanyNameLength = 5;
        private const int RegNumberLength = 10;

        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Company name cannot be null or empty");
                }

                if (value.Length < MinCompanyNameLength)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Company name must be longer than {0} letters", MinCompanyNameLength));
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Company registration number cannot be null or empty");
                }

                if (value.Length != RegNumberLength)
                {
                    throw new ArgumentException(string.Format("Company registration number must be {0} leters long",RegNumberLength));
                }
                if (!IsRegNumberValid(value))
                {
                    throw new ArgumentException("Company registration number must contain only digits");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return new List<IFurniture>(this.furnitures);
            }
        }


        public void Add(IFurniture furniture)
        {
            if (furniture != null) 
            {
                this.furnitures.Add(furniture);
            }
        }

        public void Remove(IFurniture furniture)
        {
            if (furniture != null)
            {
                this.furnitures.Remove(furniture);
            }
        }

        public IFurniture Find(string model)
        {
            if (model != null)
            {
                return this.furnitures.FirstOrDefault(f => f.Model.ToLower().Equals(model.ToLower()));
            }
            return null;
        }

        public string Catalog()
        {
            StringBuilder result = new StringBuilder();
            string numberOfFurnitures = this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no";
            string furnitureString = this.Furnitures.Count != 1 ? "furnitures" : "furniture";

            result.AppendLine(string.Format("{0} - {1} - {2} {3}", 
                this.Name, this.RegistrationNumber,numberOfFurnitures, furnitureString));
            if (this.Furnitures.Count != 0)
            {
                var sortedFurnitures = this.furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model);
                foreach (var furniture in sortedFurnitures)
                {
                    result.AppendLine(furniture.ToString());
                }
            }
            return result.ToString().TrimEnd();
        }

        private bool IsRegNumberValid(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
