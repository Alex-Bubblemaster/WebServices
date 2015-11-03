namespace ArtistsSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using ArtistsSystem.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;

    public class SongsController : ApiController
    {
        private readonly ArtistsSystemDbContext db;

        public SongsController()
        {
            this.db = new ArtistsSystemDbContext();
        }

        public IHttpActionResult Get()
        {
            var songs = this.db.Songs
                .AsQueryable()
                .ProjectTo<SongRequestModel>()
                .ToList();

            return this.Ok(songs);
        }

        public IHttpActionResult Get(int id)
        {
            var song = this.db.Songs
                .AsQueryable()
                .ProjectTo<SongRequestModel>()
                .FirstOrDefault(s => s.Id == id);

            if (song == null)
            {
                return this.NotFound();
            }

            return this.Ok(song);
        }

        public IHttpActionResult Post(SongRequestModel songToAdd)
        {
            var song = Mapper.Map<Song>(songToAdd);
            this.db.Songs.Add(song);
            this.db.SaveChanges();

            return this.Ok(string.Format("{0} was added to Songs", song.Title));
        }

        [HttpPut]
        public IHttpActionResult Update(SongRequestModel songToUpdate)
        {
            var targetSong = this.db.Songs
                .FirstOrDefault(s => s.Id == songToUpdate.Id);

            if (targetSong == null)
            {
                return this.NotFound();
            }

            targetSong.Title = songToUpdate.Title;
            targetSong.Year = songToUpdate.Year;
            targetSong.Genre.Name = songToUpdate.GenreName;
            targetSong.Album.Title = songToUpdate.AlbumTitle;
            targetSong.Artist.Name = songToUpdate.ArtistName;

            this.db.SaveChanges();

            return this.Ok("Song has been updated successfully!");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var targetSong = this.db.Songs
                            .FirstOrDefault(s => s.Id == id);

            if (targetSong == null)
            {
                return this.NotFound();
            }

            this.db.Songs.Remove(targetSong);
            this.db.SaveChanges();
            return this.Ok(string.Format("{0} has been deleted", targetSong.Title));
        }
    }
}