using System.ComponentModel.DataAnnotations;

namespace MoviesWebAPI.Data.DTO.Movie
{
    public class CreateMovieDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(50, ErrorMessage = "Max size of genre cannot to exceed 50 characters.")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Duration is required.")]
        [Range(70, 600, ErrorMessage = "Duration must between 70 and 600 minutes.")]
        public int Duration { get; set; }
    }
}
