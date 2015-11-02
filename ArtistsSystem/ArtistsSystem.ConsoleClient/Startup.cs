namespace ArtistsSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using Data;
    using Models;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var db = new ArtistsSystemDbContext();

            var albums = new List<Album>();
            albums.Add(new Album { Producer = "Hey" });

            var songs = new List<Song>();
            songs.Add(new Song { Title = "One More Time", Genre = new Genre { Name = "Russian" } });
            
            var russia = new Country
            {
                Name = "Russia"
            };
            var artist = new Artist
            {
                Name = "Devushki",
                Country = russia,
                Albums = albums,
                Songs = songs,
                DateOfBirth = DateTime.Now
            };

            db.Artists.Add(artist);
            db.SaveChanges();
            Console.WriteLine(db.Countries.Count());
        }
    }
}
