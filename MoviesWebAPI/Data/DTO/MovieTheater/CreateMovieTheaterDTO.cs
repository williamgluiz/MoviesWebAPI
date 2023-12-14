using System.ComponentModel.DataAnnotations;

namespace MoviesWebAPI.Data.DTO.MovieTheater
{
    public class CreateMovieTheaterDTO
    {
        [Required(ErrorMessage = "The field name is required.")]
        public string Name { get; set; }
        public int AddressId { get; set; }

    }
}
