using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Data;
using MoviesWebAPI.Data.DTO.Address;
using MoviesWebAPI.Models;

namespace MoviesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public AddressController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a new address to the database.
        /// </summary>
        /// <param name="addressDTO">Object with the required field to create a new address</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">If the insertion is successful.</response>
        [HttpPost]
        public IActionResult AddAddress([FromBody] CreateAddressDTO addressDTO)
        {
            Address address = _mapper.Map<Address>(addressDTO);
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAddressById), new { Id = address.Id }, address);
        }

        /// <summary>
        /// Returns the list of all address.
        /// </summary>
        /// <returns>ReadAddressDTO</returns>
        /// <response code="200">If the request is successful.</response>
        [HttpGet]
        public IEnumerable<ReadAddressDTO> GetAddresses() 
            => _mapper.Map<List<ReadAddressDTO>>(_context.Addresses);

        /// <summary>
        /// Returns details of a specific address.
        /// </summary>
        /// <param name="id">Unique identifier of the address in the database</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">If the request is successful.</response>
        [HttpGet("{id}")]
        public IActionResult GetAddressById(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address != null)
            {
                ReadAddressDTO addressDTO = _mapper.Map<ReadAddressDTO>(address);

                return Ok(addressDTO);
            }
            return NotFound();
        }

        /// <summary>
        /// Updates an existing address.
        /// </summary>
        /// <param name="id">Unique identifier of the address in the database</param>
        /// <param name="addressDTO">Object with the required field to update a address</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the update is successful.</response>
        [HttpPut("{id}")]
        public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDTO addressDTO)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            _mapper.Map(addressDTO, address);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Removes an address from the database.
        /// </summary>
        /// <param name="id">Unique identifier of the address in the database</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">If the update is successful.</response>
        [HttpDelete("{id}")]
        public IActionResult RemoveAddress(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null)
                return NotFound();
            
            _context.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
