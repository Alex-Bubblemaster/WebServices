namespace ArtistsSystem.Api.Models
{
    using System.Collections.Generic;

    public class AlbumRequestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public ICollection<ArtistRequestModel> Artists { get; set; }

        public ICollection<SongRequestModel> Songs { get; set; }

    }
}