using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genre
    {
        [Required(ErrorMessage = "Genre type is required")]
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
}
