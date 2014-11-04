namespace CountriesData.Migrations
{
    using CountriesData.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CountriesData.CountriesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CountriesData.CountriesDbContext context)
        {
            if (context.Continents.Count() > 0)
            {
                return;
            }

            //europe
            var bulgaria = new Country() { Name = "Bulgaria", Population = 7364570, Language = "Bulgarian" };
            bulgaria.Towns.Add(new Town() { Name = "Sofia", Population = 1288658 });
            bulgaria.Towns.Add(new Town() { Name = "Varna", Population = 335819 });
            bulgaria.Towns.Add(new Town() { Name = "Bourgas", Population = 200271 });
            bulgaria.Towns.Add(new Town() { Name = "Pleven", Population = 106954 });
            bulgaria.Towns.Add(new Town() { Name = "Kaspichan", Population = 3260 });

            var germany = new Country() { Name = "Germany", Population = 80716000, Language = "German" };
            germany.Towns.Add(new Town() { Name = "Berlin", Population = 3517424 });
            germany.Towns.Add(new Town() { Name = "Hamburg", Population = 1751775 });
            germany.Towns.Add(new Town() { Name = "Frankfurt", Population = 701350 });
            germany.Towns.Add(new Town() { Name = "Munich", Population = 1210223 });
            germany.Towns.Add(new Town() { Name = "Köln", Population = 1034175 });

            var italy = new Country() { Name = "Italy", Population = 60782668, Language = "Italian" };
            italy.Towns.Add(new Town() { Name = "Rome", Population = 2863322 });
            italy.Towns.Add(new Town() { Name = "Milan", Population = 1336106 });
            italy.Towns.Add(new Town() { Name = "Venice", Population = 270660 });

            var england = new Country() { Name = "United Kingdom", Population = 50000000, Language = "English" };
            england.Towns.Add(new Town() { Name = "London", Population = 5000000 });
            england.Towns.Add(new Town() { Name = "Liverpool", Population = 2000000 });
            england.Towns.Add(new Town() { Name = "Newcastle ", Population = 3000000 });

            var europe = new Continent() { Name = "Europe" };
            europe.Countries.Add(bulgaria);
            europe.Countries.Add(germany);
            europe.Countries.Add(italy);
            europe.Countries.Add(england);

            // africa
            var egypt = new Country() { Name = "Egypt", Population = 40000000, Language = "Arabic" };
            egypt.Towns.Add(new Town() { Name = "Kairo", Population = 5000000 });

            var africa = new Continent() { Name = "Africa" };
            africa.Countries.Add(egypt);

            //asia
            var india = new Country() { Name = "India", Population = 1400000000, Language = "Hindi" };
            india.Towns.Add(new Town() { Name = "New Delhi", Population = 90000000 });
            india.Towns.Add(new Town() { Name = "Mombai", Population = 80000000 });
            india.Towns.Add(new Town() { Name = "Chenai", Population = 60000000 });

            var asia = new Continent() { Name = "Asia" };
            asia.Countries.Add(india);

            //North America
            var usa = new Country() { Name = "USA", Population = 400000000, Language = "English" };
            usa.Towns.Add(new Town() { Name = "New York", Population = 90000000 });
            usa.Towns.Add(new Town() { Name = "Chicago", Population = 80000000 });
            usa.Towns.Add(new Town() { Name = "Los Angeles", Population = 60000000 });

            var canada = new Country() { Name = "Canada", Population = 300000000, Language = "French" };
            canada.Towns.Add(new Town() { Name = "Ottawa", Population = 90000000 });
            canada.Towns.Add(new Town() { Name = "Quebec", Population = 80000000 });

            var northAmerica = new Continent() { Name = "North America" };
            northAmerica.Countries.Add(usa);
            northAmerica.Countries.Add(canada);


            var southAmerica = new Continent() { Name = "South America" };

            var australia = new Continent() { Name = "Australia" };

            context.Continents.Add(europe);
            context.Continents.Add(africa);
            context.Continents.Add(asia);
            context.Continents.Add(northAmerica);
            context.Continents.Add(southAmerica);
            context.Continents.Add(australia);
        }
    }
}
