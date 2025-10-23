using Vidly.Models;

namespace Vidly.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie? Movie { get; set; }
        public required List<Customer> Customers { get; set; }
    }
}
