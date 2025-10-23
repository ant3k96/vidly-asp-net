using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = default!;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Release date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Value does not fit in the range")]
        [Display(Name = "Number in stock")]
        public short? NumberInStock { get; set; }

        public short NumberAvailable { get; set; }

        public Genre? Genre { get; set; }
    }
}
