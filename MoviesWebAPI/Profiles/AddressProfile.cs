using AutoMapper;
using MoviesWebAPI.Data.DTO.Address;
using MoviesWebAPI.Models;

namespace MoviesWebAPI.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressDTO, Address>();
            CreateMap<Address, ReadAddressDTO>();
            CreateMap<UpdateAddressDTO, Address>();
        }
    }
}
