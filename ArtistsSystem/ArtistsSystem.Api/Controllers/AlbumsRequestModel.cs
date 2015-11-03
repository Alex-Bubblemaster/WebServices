namespace ArtistsSystem.Api.Controllers
{
    public class AlbumsRequestModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }
    }
}