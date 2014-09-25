namespace MusicCatalog.Data.Contracts
{
    using MusicCatalog.Model;

    public interface IMusicCatalogData
    {
        IRepository<Song> Songs { get; }

        IRepository<Artist> Artists { get; }

        IRepository<Album> Albums { get; }

        void SaveChanges();
    }
}
