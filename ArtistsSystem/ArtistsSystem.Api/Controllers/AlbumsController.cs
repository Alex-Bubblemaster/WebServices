namespace ArtistsSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using ArtistsSystem.Models;
    using Data;

    public class AlbumsController : ApiController
    {
        private readonly ArtistsSystemDbContext db;

        public AlbumsController()
        {
            this.db = new ArtistsSystemDbContext();
        }

        public IHttpActionResult Get()
        {
            var albums = db.Albums
                .Select(a => new AlbumsRequestModel
                {
                    Id = a.Id,
                    Producer = a.Producer,
                    Title = a.Title,
                    Year = a.Year
                })
                .ToList();

            return this.Ok(albums);
        }

        // GET: api/Albums/5
        public IHttpActionResult Get(int id)
        {
            var album = db.Albums
                .FirstOrDefault(a => a.Id == id);

            var albumToShow = new AlbumsRequestModel
            {
                Id = album.Id,
                Producer = album.Producer,
                Title = album.Title,
                Year = album.Year
            };

            return this.Ok(albumToShow);
        }

        // POST: api/Albums
        public IHttpActionResult Post([FromBody]AlbumsRequestModel value)
        {
            var album = new Album
            {
                Id = value.Id,
                Producer = value.Producer,
                Title = value.Title,
                Year = value.Year
            };
            db.Albums.Add(album);
            db.SaveChanges();

            return this.Ok(string.Format("{0} was added to Albums", album.Title));
        }

        // DELETE: api/Albums/5
        public IHttpActionResult Delete(int id)
        {
            var albumToDelete = db.Albums
                .FirstOrDefault(a => a.Id == id);
            if (albumToDelete == null)
            {
                return this.NotFound();
            }

            db.Albums.Remove(albumToDelete);
            db.SaveChanges();

            return this.Ok(string.Format("{0} was successfully deleted!", albumToDelete.Title));
        }
    }
}