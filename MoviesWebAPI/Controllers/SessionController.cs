using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Data;
using MoviesWebAPI.Data.DTO.Session;
using MoviesWebAPI.Models;

namespace MoviesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public SessionController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a new session to the database.
        /// </summary>
        /// <param name="sessionDTO"></param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public IActionResult AddSession(CreateSessionDTO sessionDTO)
        {
            Session session = _mapper.Map<Session>(sessionDTO);
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSessionById), new { movieId = session.MovieId, movieTheaterId = session.MovieTheaterId }, session);
        }

        /// <summary>
        /// Returns the list of all sessions.
        /// </summary>
        /// <returns>ReadSessionDTO</returns>
        [HttpGet]
        public IEnumerable<ReadSessionDTO> GetAllSessions()
            => _mapper.Map<List<ReadSessionDTO>>(_context.Sessions.ToList());

        /// <summary>
        /// Returns details of a specific session.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="movieTheaterId"></param>
        /// <returns>IActionResult</returns>
        [HttpGet("{movieId}/{movieTheaterId}")]
        public IActionResult GetSessionById(int movieId, int movieTheaterId)
        {
            Session session = _context.Sessions.FirstOrDefault(session => session.MovieId == movieId && session.MovieTheaterId == movieTheaterId);

            if (session != null)
            {
                ReadSessionDTO sessionDTO = _mapper.Map<ReadSessionDTO>(session);
                return Ok(sessionDTO);
            }

            return NotFound();
        }
    }
}
