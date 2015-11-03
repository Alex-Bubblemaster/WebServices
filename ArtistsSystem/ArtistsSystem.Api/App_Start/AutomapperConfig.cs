namespace ArtistsSystem.Api
{
    using System.Linq;
    using ArtistsSystem.Models;
    using AutoMapper;
    using Models;

    public class AutomapperConfig
    {
        public static void Initialize()
        {
            Mapper.CreateMap<Country, CountryRequestModel>();
            Mapper.CreateMap<Genre, GenreRequestModel>();
            Mapper.CreateMap<Song, SongRequestModel>()
                .ForMember(s => s.ArtistName, opt => opt.MapFrom(s => s.Artist.Name))
                .ForMember(s => s.GenreName, opt => opt.MapFrom(s => s.Genre.Name))
                .ForMember(s => s.ArtistId, opt => opt.MapFrom(s => s.Artist.Id))
                .ForMember(s => s.AlbumTitle, opt => opt.MapFrom(s => s.Album.Title));

            Mapper.CreateMap<SongRequestModel, Song>()
                    .ForMember(s => s.Artist, opt => opt.MapFrom(
                        s => new Artist
                        {
                            Name = s.ArtistName,
                            Id = s.ArtistId
                        }))
                    .ForMember(s => s.Album, opt => opt.MapFrom(
                        s => new Album
                        {
                            Title = s.AlbumTitle
                        }))
                     .ForMember(s => s.Genre, opt => opt.MapFrom(
                          s => new Genre
                          {
                              Name = s.GenreName
                          }));

            // TODO this does not work properly fix it 
            Mapper.CreateMap<Artist, ArtistRequestModel>()
                .ForMember(a => a.CountryName, opt => opt.MapFrom(a => a.Country.Name))
                .ForMember(a => a.CountryId, opt => opt.MapFrom(a => a.Country.Id))
                .ForMember(a => a.Songs, opt => opt.MapFrom(a => a.Songs.Select(
                     s => new Song
                     {
                         Title = s.Title,
                         Album = s.Album,
                         Genre = s.Genre,
                         Year = s.Year
                     })))
                     .ForMember(a => a.Albums, opt => opt.MapFrom(a => a.Albums.Select(
                           s => new Album
                           {
                               Producer = s.Producer,
                               Title = s.Title,
                               Year = s.Year
                           })));

            Mapper.CreateMap<Album, AlbumRequestModel>().ReverseMap();
        }
    }
}