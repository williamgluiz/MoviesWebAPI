using MoviesWebAPI.Data.DTO.Address;
using MoviesWebAPI.Data.DTO.Session;
using System.ComponentModel.DataAnnotations;

namespace MoviesWebAPI.Data.DTO.MovieTheater
{
    public class ReadMovieTheaterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ReadAddressDTO Address { get; set; }
        public ICollection<ReadSessionDTO> Sessions { get; set; }
    }
}
