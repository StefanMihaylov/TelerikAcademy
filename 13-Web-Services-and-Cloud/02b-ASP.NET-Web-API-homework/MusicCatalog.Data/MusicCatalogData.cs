namespace MusicCatalog.Data
{
    using MusicCatalog.Data.Contracts;
    using MusicCatalog.Model;
    using System;
    using System.Collections.Generic;

    public class MusicCatalogData : IMusicCatalogData
    {
        private IMusicCatalogDbContext context;
        private IDictionary<Type, object> repositories;

        public MusicCatalogData()
            : this(new MusicCatalogDbContext())
        {
        }

        public MusicCatalogData(MusicCatalogDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
            }
        }

        public IRepository<Artist> Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        public IRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }


        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
