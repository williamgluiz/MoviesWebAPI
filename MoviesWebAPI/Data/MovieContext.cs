using Microsoft.EntityFrameworkCore;
using MoviesWebAPI.Models;

namespace MoviesWebAPI.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }
     
        public DbSet<Movie> Movies { get; set; }
    }
}
