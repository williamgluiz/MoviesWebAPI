using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Data;
using MoviesWebAPI.Data.DTO.Movie;
using MoviesWebAPI.Models;

namespace MoviesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public MoviesController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a movie to the database
        /// </summary>
        /// <param name="movieDTO">Object with the required field to create a new movie</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">If the insertion is successful.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddMovies([FromBody] CreateMovieDTO movieDTO)
        {
            Movie movie = _mapper.Map<Movie>(movieDTO);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        /// <summary>
        /// Retrieve a paginated list of movies from the database.
        /// </summary>
        /// <param name="skip">Integer value indicating how many elements will be skipped.</param>
        /// <param name="take">Integer value indicating how many elements will be taken.</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If the request is successful.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ReadMovieDTO> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 50) 
            => _mapper.Map<IEnumerable<ReadMovieDTO>>(_context.Movies.Skip(skip).Take(take));

        /// <summary>
        /// Retrieve a movie by id from the database.
        /// </summary>
        /// <param name="id">Unique identifier of the movie in the database</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If the request is successful.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetMovieById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null) return NotFound();

            var movieDTO = _mapper.Map<ReadMovieDTO>(movie);

            return Ok(movieDTO);
        }

        /// <summary>
        /// Update an existing movie in the database.
        /// </summary>
        /// <param name="id">Unique identifier of the movie in the database</param>
        /// <param name="movieDTO">Object with the required field to update a movie</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the update is successful.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDTO movieDTO)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            
            if (movie == null) return NotFound();

            _mapper.Map(movieDTO, movie);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Partially update an existing movie in the database.
        /// </summary>
        /// <param name="id">Unique identifier of the movie in the database</param>
        /// <param name="patch">Object with the field(s) to update a movie</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the update is successful.</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdatePartialMovie(int id, JsonPatchDocument<UpdateMovieDTO> patch)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

            if (movie == null)
                return NotFound();

            var movieToUpdate = _mapper.Map<UpdateMovieDTO>(movie);
            patch.ApplyTo(movieToUpdate, ModelState);

            if (!TryValidateModel(movieToUpdate))
                return ValidationProblem(ModelState);

            _mapper.Map(movieToUpdate, movie);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Remove an existing movie in the database.
        /// </summary>
        /// <param name="id">Unique identifier of the movie in the database</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the update is successful.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null) 
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
