namespace MusicCatalog.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using MusicCatalog.Model;
    using MusicCatalog.Data.Migrations;
    using MusicCatalog.Data.Contracts;

    public class MusicCatalogDbContext : DbContext, IMusicCatalogDbContext
    {
        public MusicCatalogDbContext()
            : base("MusicCatalogDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicCatalogDbContext, Configuration>());
        }

        public virtual IDbSet<Song> Songs { get; set; }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }


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
