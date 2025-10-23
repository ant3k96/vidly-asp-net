using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vidly.Dtos;
using Vidly.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vidly.Controllers.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly VidlyDbContext _context;
        public RentalsController(VidlyDbContext context)
        {
            _context = context;
        }

        // POST api/<RentalsController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = await _context.Customers.FindAsync(rentalDto.CustomerId);
            if (customer == null)
            {
                return BadRequest();
            }

            var movies = _context.Movies.Where(m => rentalDto.MoviesId.Contains(m.Id)).ToList();

            if (movies.Count != rentalDto.MoviesId.Count)
            {
                return BadRequest();
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest();
                }
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    DateOfRent = DateTime.Now,
                    Customer = customer,
                    Movie = movie
                };

                _context.Rentals.Add(rental);

            }
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
