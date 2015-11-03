namespace ArtistsSystem.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Models;

    public class ArtistsController : ApiController
    {
        private readonly ArtistsSystemDbContext db;

        public ArtistsController()
        {
            this.db = new ArtistsSystemDbContext();
        }

        public IHttpActionResult Get()
        {
            // TODO does not work properly with Mapper so I did it by hand but needs more work
            var artists = db.Artists
                .AsQueryable()
                .ToList();

            var artistModels = new List<ArtistRequestModel>();
            foreach (var artist in artists)
            {
                var albums = new List<AlbumRequestModel>();
                foreach (var album in artist.Albums)
                {
                    var albumModel = new AlbumRequestModel
                    {
                        Producer = album.Producer,
                        Title = album.Title,
                        Year = album.Year
                    };
                    albums.Add(albumModel);
                }

                var songs = new List<SongRequestModel>();
                foreach (var song in artist.Songs)
                {
                    var songToAdd = new SongRequestModel
                    {
                        Title = song.Title,
                        GenreName = song.Genre.Name,
                        Year = song.Year
                    };
                    songs.Add(songToAdd);
                }

                var artistToAdd = new ArtistRequestModel
                {
                    Name = artist.Name,
                    Albums = albums,
                    Songs = songs
                };

                artistModels.Add(artistToAdd);
            }

            return this.Ok(artistModels);
        }
    }
}