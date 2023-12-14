using AutoMapper;
using MoviesWebAPI.Data.DTO.Session;
using MoviesWebAPI.Models;

namespace MoviesWebAPI.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<CreateSessionDTO, Session>();
            CreateMap<Session, ReadSessionDTO>();
        }
    }
}
