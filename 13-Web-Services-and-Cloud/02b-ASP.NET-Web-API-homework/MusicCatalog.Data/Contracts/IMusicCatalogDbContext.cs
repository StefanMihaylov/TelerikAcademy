namespace MusicCatalog.Data.Contracts
{
    using MusicCatalog.Model;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IMusicCatalogDbContext
    {
        IDbSet<Album> Albums { get; set; }

        IDbSet<Artist> Artists { get; set; }

        IDbSet<Song> Songs { get; set; }


        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
