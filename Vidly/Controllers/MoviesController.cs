using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly VidlyDbContext _context;
        public MoviesController(VidlyDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            if (User.IsInRole("CanManageMovies"))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = "CanManageMovies")]
        public IActionResult New()
        {
            var genres = _context.Genres.ToList();

            return View("MovieForm", new MovieFormViewModel { Movie = new Movie(), Genres = genres });
        }

        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(p => p.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            var genres = _context.Genres.ToList();

            return View("MovieForm", new MovieFormViewModel { Movie = movie, Genres = genres });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAsync(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var genres = _context.Genres.ToList();

                return View("MovieForm", new MovieFormViewModel { Movie = movie, Genres = genres });
            }
            var genre = await _context.Genres.SingleAsync(s => s.Id == movie.Genre!.Id);
            if (movie!.Id == 0)
            {
                movie.Genre = genre;
                await _context.Movies.AddAsync(movie);
            }
            else
            {
                var moviedb = await _context.Movies.FindAsync(movie.Id);

                if (moviedb == null)
                    return NotFound();

                moviedb.Title = movie.Title;
                moviedb.NumberInStock = movie.NumberInStock;
                moviedb.ReleaseDate = movie.ReleaseDate;
                moviedb.Genre = genre;

            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Movies");
        }

        //[Route("MovieByReleaseDate")]
        [Route("Movies/released/{year:range(2010, 2025)}/{month:regex(\\d{{2}}):range(1, 12)}")]
        public IActionResult ReleasedByDate(int year, int month)
        {
            return Content($"Movie released on {month.ToString()}.{year.ToString()}");
        }
    }
}
