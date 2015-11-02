namespace ArtistsSystem.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class ArtistRequestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CountryName { get; set; }

        public int CountryId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public ICollection<SongRequestModel> Songs { get; set; }

        public ICollection<AlbumRequestModel> Albums { get; set; }
    }
}