using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebAPI.Data;
using MoviesWebAPI.Data.DTO.MovieTheater;
using MoviesWebAPI.Models;
using System.Collections.Generic;

namespace MoviesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieTheaterController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public MovieTheaterController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a new movie theater to the database.
        /// </summary>
        /// <param name="movieTeatherDTO">Object with the required field to create a new movie theater</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">If the insertion is successful.</response>
        [HttpPost]
        public IActionResult AddMovieTheater([FromBody] CreateMovieTheaterDTO movieTeatherDTO)
        {
            MovieTheater movieTheater = _mapper.Map<MovieTheater>(movieTeatherDTO);
            _context.MovieTheaters.Add(movieTheater);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieTheaterById), new { Id = movieTheater.Id }, movieTeatherDTO);
        }

        /// <summary>
        /// Returns the list of all movies theater optionally can consult by address.
        /// </summary>
        /// <param name="addressId">Unique identifier of address in the database.</param>
        /// <returns>ReadMovieTheaterDTO</returns>
        /// <response code="200">If the request is successful.</response>
        [HttpGet]
        public IEnumerable<ReadMovieTheaterDTO> GetMovieTheaters([FromQuery] int? addressId = null)
        {
            if (addressId == null)
                return _mapper.Map<List<ReadMovieTheaterDTO>>(_context.MovieTheaters.ToList());

            return _mapper.Map<List<ReadMovieTheaterDTO>>(_context.MovieTheaters.FromSqlRaw($"SELECT Id, Name, AddressId FROM movietheaters WHERE movietheaters.AddressId = {addressId}").ToList());
        }

        /// <summary>
        /// Returns details of a specific movie theater.
        /// </summary>
        /// <param name="id">Unique identifier of the movie in the database</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If the request is successful.</response>
        [HttpGet("{id}")]
        public IActionResult GetMovieTheaterById(int id)
        {
            MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault(mt => mt.Id == id);
            if (movieTheater != null)
            {
                ReadMovieTheaterDTO cinemaDto = _mapper.Map<ReadMovieTheaterDTO>(movieTheater);
                return Ok(cinemaDto);
            }

            return NotFound();
        }

        /// <summary>
        /// Updates an existing movie.
        /// </summary>
        /// <param name="id">Unique identifier of the movie theater in the database</param>
        /// <param name="movieTheaterDTO">Object with the required field to update a movie theater</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the update is successful.</response>
        [HttpPut("{id}")]
        public IActionResult UpdateMovieTheater(int id, [FromBody] UpdateMovieTheaterDTO movieTheaterDTO)
        {
            MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault(mt => mt.Id == id);
            if (movieTheater == null)
                return NotFound();

            _mapper.Map(movieTheaterDTO, movieTheater);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Removes a movie theater from the database.
        /// </summary>
        /// <param name="id">Unique identifier of the movie theater in the database</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the update is successful.</response>
        [HttpDelete("{id}")]
        public IActionResult RemoveMovieTheater(int id)
        {
            MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault(mt => mt.Id == id);
            if (movieTheater == null)
                return NotFound();

            _context.Remove(movieTheater);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
