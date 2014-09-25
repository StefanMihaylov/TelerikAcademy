namespace MusicCatalog.Services.Models
{
    using MusicCatalog.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class ArtistModel
    {
        public static Expression<Func<Artist, ArtistModel>> FromDbModel
        {
            get
            {
                return (a) => new ArtistModel()
                {
                    Id = a.ArtistId,
                    Name = a.Name,
                    Country = a.Country,
                    MusicGenre = a.MusicGenre,
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Country { get; set; }

        public string MusicGenre { get; set; }
    }
}