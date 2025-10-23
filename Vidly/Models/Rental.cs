using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime DateOfRent { get; set; }
        public DateTime? DateOfReturn { get; set; }

        [Required]
        public Customer Customer { get; set; } = default!;

        [Required]
        public Movie Movie { get; set; } = default!;
    }
}
