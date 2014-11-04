namespace CountriesData
{
    using CountriesData.Migrations;
    using CountriesData.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CountriesDbContext : DbContext
    {
        public CountriesDbContext()
            : base("CountriesDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CountriesDbContext, Configuration>());
        }

        public IDbSet<Continent> Continents { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Town> Towns { get; set; }
    }
}
