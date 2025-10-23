using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly VidlyDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(VidlyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetMovies(string? term)
        {
            var moviesQuery = _context.Movies.AsQueryable();

            moviesQuery = moviesQuery.Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(term))
            {
                moviesQuery = moviesQuery.Where(m => m.Title.Contains(term));
            }

            var movies = moviesQuery.Include(x => x.Genre).ToList();

            return Ok(movies.Select(_mapper.Map<Movie, MovieDto>));

        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _context.Movies.Include(x => x.Genre).SingleOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return _mapper.Map<MovieDto>(movie);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadHttpRequestException("Bad request");
            }

            var genre = await _context.Genres.FindAsync(movieDto.Genre!.Id);
            var movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                throw new KeyNotFoundException("Movie not found");
            }

            _mapper.Map(movieDto, movie);
            movie.Genre = genre;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        public async Task<ActionResult<MovieDto>> PostMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadHttpRequestException("Bad request");
            }
            var genre = await _context.Genres.FindAsync(movieDto.Genre!.Id);

            var movie = _mapper.Map<Movie>(movieDto);
            movie.Genre = genre;
            movie.NumberAvailable = movie.NumberInStock ?? 0;

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movieDto);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
