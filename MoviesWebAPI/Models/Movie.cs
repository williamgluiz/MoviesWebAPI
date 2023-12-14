using System.ComponentModel.DataAnnotations;

namespace MoviesWebAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Genre is required.")]
        [MaxLength(50, ErrorMessage = "Max size of genre cannot to exceed 50 characters.")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Duration is required.")]
        [Range(70, 600, ErrorMessage = "Duration must between 70 and 600 minutes.")]
        public int Duration { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
