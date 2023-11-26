namespace MoviesWebAPI.Data.DTO.Movie
{
    public class ReadMovieDTO
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public  int Duration { get; set; }
        public DateTime AppointmentTime { get; set; } = DateTime.Now;
    }
}
