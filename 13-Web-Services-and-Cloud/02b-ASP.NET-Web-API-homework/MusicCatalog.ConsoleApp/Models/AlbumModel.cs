namespace MusicCatalog.ConsoleApp.Models
{
    using MusicCatalog.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class AlbumModel
    {
        public static Expression<Func<Album, AlbumModel>> FromDbModel
        {
            get
            {
                return (a) => new AlbumModel()
                {
                    Id = a.AlbumId,
                    Name = a.Name,
                    Producer = a.Producer,
                    ReleaseDateYear = a.ReleaseDateYear
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Producer { get; set; }

        public int? ReleaseDateYear { get; set; }
    }
}