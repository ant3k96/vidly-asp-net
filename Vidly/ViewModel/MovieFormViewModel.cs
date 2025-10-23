using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; } = default!;
        public IEnumerable<Genre> Genres { get; set; } = default!;
    }
}
