namespace CarsDB.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using CarsDB.Model;
    using CarsDB.Data.Migrations;

    public class CarsDbContext : DbContext // IBookStoreDbContext
    {
        public CarsDbContext()
            : base("CarsDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<City> Cities { get; set; }


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}










