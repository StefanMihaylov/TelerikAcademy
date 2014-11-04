namespace CountriesData.Model
{
    public class Town
    {
        public int TownId { get; set; }

        public string Name { get; set; }

        public long Population { get; set; }


        public int CountryId { get; set; }

        public virtual Country Couuntry { get; set; }
    }
}
