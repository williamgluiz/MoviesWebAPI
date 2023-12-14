using Microsoft.EntityFrameworkCore;
using MoviesWebAPI.Models;

namespace MoviesWebAPI.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }
     
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTheater> MovieTheaters { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Session> Sessions { get; internal set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Session>()
                .HasKey(session => new { session.MovieId, session.MovieTheaterId });

            builder.Entity<Session>()
                .HasOne(session => session.MovieTheater)
                .WithMany(mt => mt.Sessions)
                .HasForeignKey(session => session.MovieTheaterId);

            builder.Entity<Session>()
                .HasOne(session => session.Movie)
                .WithMany(movie => movie.Sessions)
                .HasForeignKey(session => session.MovieId);

            builder.Entity<Address>()
                .HasOne(address => address.MovieTheater)
                .WithOne(mt  => mt.Address)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
