namespace ArtistsSystem.Data
{
    using System;
    using System.Data.Entity;
    using Models;

    public class ArtistsSystemDbContext : DbContext
    {
        public ArtistsSystemDbContext()
            : base("ArtistsSystem")
        {
        }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public static ArtistsSystemDbContext Create()
        {
            return new ArtistsSystemDbContext();
        }
    }
}
