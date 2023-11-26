using AutoMapper;
using MoviesWebAPI.Data.DTO.Movie;
using MoviesWebAPI.Models;

namespace MoviesWebAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() {
            CreateMap<CreateMovieDTO, Movie>();
            CreateMap<UpdateMovieDTO, Movie>();
            CreateMap<Movie, UpdateMovieDTO>();
            CreateMap<Movie, ReadMovieDTO>();
        }
    }
}
