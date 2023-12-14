using AutoMapper;
using MoviesWebAPI.Data.DTO.MovieTheater;
using MoviesWebAPI.Models;

namespace MoviesWebAPI.Profiles
{
    public class MovieTheaterProfile : Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<CreateMovieTheaterDTO, MovieTheater>();
            CreateMap<MovieTheater, ReadMovieTheaterDTO>()
                .ForMember(mtDTO => mtDTO.Address, opt => opt.MapFrom(mt => mt.Address))
                .ForMember(mtDTO => mtDTO.Sessions, opt => opt.MapFrom(mt => mt.Sessions));
            CreateMap<UpdateMovieTheaterDTO, MovieTheater>();
        }
    }
}
