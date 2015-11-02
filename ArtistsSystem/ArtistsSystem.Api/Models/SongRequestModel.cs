namespace ArtistsSystem.Api.Models
{
    public class SongRequestModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string ArtistName { get; set; }

        public int ArtistId { get; set; }

        public string GenreName { get; set; }

        public string AlbumTitle { get; set; }

    }
}