using AutoMapper;
using vidly.Dtos;
using vidly.Models;

namespace vidly.MappingProfile
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
            CreateMap<Genre, GenreDto>();
        }
    }
}