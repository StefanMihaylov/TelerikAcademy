namespace MusicCatalog.Services.Controllers
{
    using MusicCatalog.Data;
    using MusicCatalog.Data.Contracts;
    using MusicCatalog.Model;
    using MusicCatalog.Services.Models;

    using System.Linq;
    using System.Web.Http;

    public class ArtistsController : ApiController
    {
        private IMusicCatalogData catalog;

        public ArtistsController()
            : this(new MusicCatalogData())
        {
        }

        public ArtistsController(MusicCatalogData catalog)
        {
            this.catalog = catalog;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var collection = this.catalog.Artists.All().Select(ArtistModel.FromDbModel);
            return Ok(collection);
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var newArtist = new Artist()
            {
                Name = artist.Name,
                Country = artist.Country,
                MusicGenre = artist.MusicGenre
            };

            this.catalog.Artists.Add(newArtist);
            this.catalog.Artists.SaveChanges();

            artist.Id = newArtist.ArtistId;

            return Ok(artist);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var existingArtist = this.catalog.Artists.All().FirstOrDefault(a => a.ArtistId == id);
            if (existingArtist == null)
            {
                return BadRequest("Such artist does not exist");
            }

            existingArtist.Name = artist.Name;
            existingArtist.Country = artist.Country;
            existingArtist.MusicGenre = artist.MusicGenre;

            this.catalog.Artists.SaveChanges();
            artist.Id = id;

            return Ok(artist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingArtist = this.catalog.Artists.All().FirstOrDefault(a => a.ArtistId == id);
            if (existingArtist == null)
            {
                return BadRequest("Such artist does not exist");
            }

            this.catalog.Artists.Delete(existingArtist);
            this.catalog.Artists.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddAlbum(int id, int albumId)
        {
            var artist = this.catalog.Artists.All().FirstOrDefault(a => a.ArtistId == id);
            if (artist == null)
            {
                return BadRequest("Such artist does not exist");
            }

            var album = this.catalog.Albums.All().FirstOrDefault(a => a.AlbumId == albumId);
            if (album == null)
            {
                return BadRequest("Such album does not exist");
            }

            artist.Albums.Add(album);
            this.catalog.Artists.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAlbums(int id)
        {
            var artist = this.catalog.Artists.All().FirstOrDefault(a => a.ArtistId == id);
            if (artist == null)
            {
                return BadRequest("Such artist does not exist");
            }

            var collection = artist.Albums.Select((AlbumModel.FromDbModel).Compile());
            return Ok(collection);
        }
    }
}
