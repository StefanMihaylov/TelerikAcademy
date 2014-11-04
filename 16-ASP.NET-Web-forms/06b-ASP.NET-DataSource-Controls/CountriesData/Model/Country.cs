namespace CountriesData.Model
{
    using System.Collections.Generic;

    public class Country
    {
        private ICollection<Town> towns;

        public Country()
        {
            this.towns = new HashSet<Town>();
        }

        public int CountryId { get; set; }

        public string Name { get; set; }

        public long Population { get; set; }

        public string Language { get; set; }

        public byte[] Flag { get; set; }


        public int ContinentId { get; set; }

        public virtual Continent Continent { get; set; }

        public virtual ICollection<Town> Towns
        {
            get { return this.towns; }
            set { this.towns = value; }
        }
    }
}
