namespace MusicCatalog.Services.Controllers
{
    using MusicCatalog.Data;
    using MusicCatalog.Data.Contracts;
    using MusicCatalog.Model;
    using MusicCatalog.Services.Models;

    using System.Linq;
    using System.Web.Http;

    public class AlbumsController : ApiController
    {
        private IMusicCatalogData catalog;

        public AlbumsController()
            : this(new MusicCatalogData())
        {
        }

        public AlbumsController(IMusicCatalogData catalog)
        {
            this.catalog = catalog;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var collection = this.catalog.Albums.All().Select(AlbumModel.FromDbModel);
            return Ok(collection);
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var newAlbum = new Album()
            {
                Name = album.Name,
                Producer = album.Producer,
                ReleaseDateYear = album.ReleaseDateYear
            };

            this.catalog.Albums.Add(newAlbum);
            this.catalog.SaveChanges();

            album.Id = newAlbum.AlbumId;

            return Ok(album);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var existingAlbum = this.catalog.Albums.All().FirstOrDefault(a => a.AlbumId == id);
            if (existingAlbum == null)
            {
                return BadRequest("Such album does not exist");
            }

            existingAlbum.Name = album.Name;
            existingAlbum.Producer = album.Producer;
            existingAlbum.ReleaseDateYear = album.ReleaseDateYear;

            this.catalog.SaveChanges();
            album.Id = id;

            return Ok(album);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingAlbum = this.catalog.Albums.All().FirstOrDefault(a => a.AlbumId == id);
            if (existingAlbum == null)
            {
                return BadRequest("Such album does not exist");
            }

            this.catalog.Albums.Delete(existingAlbum);
            this.catalog.SaveChanges();

            return Ok();
        }
    }
}
