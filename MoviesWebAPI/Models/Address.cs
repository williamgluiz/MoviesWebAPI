using System.ComponentModel.DataAnnotations;

namespace MoviesWebAPI.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string AddressName { get; set; }
        public int Number { get; set; }
        public virtual MovieTheater MovieTheater { get; set; }
    }
}
