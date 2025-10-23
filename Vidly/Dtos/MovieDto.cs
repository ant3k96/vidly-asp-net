using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = default!;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Value does not fit in the range")]
        public short? NumberInStock { get; set; }

        public short NumberAvailable { get; set; }

        public GenreDto? Genre { get; set; } = default!;
    }
}
