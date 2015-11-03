namespace ArtistsSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<ArtistsSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "ArtistsSystem.Data.ArtistsSystemDbContext";
        }

        protected override void Seed(ArtistsSystemDbContext context)
        {
            var album = new Album
            {
                Producer = "Hey",
                Title = "Under the bridge",
                Year = 2001
            };

            var song = new Song
            {
                Title = "We Will Rock You",
                Year = 1979,
                Artist = new Artist
                {
                    Name = "Queen",
                    DateOfBirth = DateTime.Now,
                    Country = new Country
                    {
                        Name = "USA"
                    }
                },
                Genre = new Genre
                {
                    Name = "RoCk"
                }
            };

            context.Albums.AddOrUpdate(album);
            context.Songs.AddOrUpdate(song);
            context.SaveChanges();
        }
    }
}