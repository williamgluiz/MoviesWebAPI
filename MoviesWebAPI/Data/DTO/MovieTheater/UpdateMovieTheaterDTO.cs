using System.ComponentModel.DataAnnotations;

namespace MoviesWebAPI.Data.DTO.MovieTheater
{
    public class UpdateMovieTheaterDTO
    {
        [Required(ErrorMessage = "The field name is required.")]
        public string Name { get; set; }
    }
}
