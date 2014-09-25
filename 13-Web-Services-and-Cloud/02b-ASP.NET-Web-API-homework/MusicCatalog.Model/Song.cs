namespace MusicCatalog.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        private ICollection<Album> albums;

        public Song()
        {
            this.albums = new HashSet<Album>();
        }

        public int SongId { get; set; }

        [Required]
        public string Name { get; set; }

        public TimeSpan Duration { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }

            set
            {
                this.albums = value;
            }
        }
    }
}
