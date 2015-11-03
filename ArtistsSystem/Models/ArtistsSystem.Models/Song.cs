namespace ArtistsSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public int Year { get; set; }

        public virtual int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual Artist Artist { get; set; }

        public int ArtistId { get; set; }

        public virtual Album Album { get; set; }

        public int? AlbumId { get; set; }
    }
}
