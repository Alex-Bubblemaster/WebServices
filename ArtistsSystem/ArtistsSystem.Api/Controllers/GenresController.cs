namespace ArtistsSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using ArtistsSystem.Models;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;

    public class GenresController : ApiController
    {
        private readonly ArtistsSystemDbContext db;

        public GenresController()
        {
            this.db = new ArtistsSystemDbContext();
        }

        public IHttpActionResult Get()
        {
            var genres = this.db.Genres
                .AsQueryable()
                .ProjectTo<GenreRequestModel>()
                .ToList();

            return this.Ok(genres);
        }

        public IHttpActionResult Get(int id)
        {
            var genre = this.db.Genres
                .ProjectTo<GenreRequestModel>()
                .FirstOrDefault(c => c.Id == id);

            if (genre == null)
            {
                return this.NotFound();
            }

            return this.Ok(genre);
        }

        public IHttpActionResult Post(GenreRequestModel genreToAdd)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var dbGenre = new Genre
            {
                Name = genreToAdd.Name
            };

            this.db.Genres.Add(dbGenre);
            this.db.SaveChanges();

            return this.Ok(string.Format("{0} was added to Genres database!", genreToAdd.Name));
        }

        [HttpPut]
        public IHttpActionResult Update(GenreRequestModel targetGenre)
        {
            var genreToUpdate = this.db.Genres
               .FirstOrDefault(c => c.Id == targetGenre.Id);

            if (genreToUpdate == null)
            {
                return this.NotFound();
            }

            genreToUpdate.Name = targetGenre.Name;
            this.db.SaveChanges();

            return this.Ok(string.Format("The name of the genre with id {0}, was successfully updated to {1}", targetGenre.Id, targetGenre.Name));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var genreToDelete = this.db.Genres
                .FirstOrDefault(c => c.Id == id);

            if (genreToDelete == null)
            {
                return this.NotFound();
            }

            this.db.Genres.Remove(genreToDelete);
            this.db.SaveChanges();
            return this.Ok(string.Format("{0} was deleted!", genreToDelete.Name));
        }
    }
}