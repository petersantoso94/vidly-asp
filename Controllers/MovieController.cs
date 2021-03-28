using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vidly.Data;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    [Authorize]
    [Route("movie")]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MovieController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View("~/Pages/Movie/Index.cshtml");
        }
        [Route("detail/{id:int}")]
        public async Task<IActionResult> Detail(int id)
        {
            var detail = await _context.Movies.Include(c => c.Genre).FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (detail == null) return NotFound();
            return View(detail);
        }
        // can add multiple constraint by adding :
        [Route("{year:regex(\\d{{4}})}/{month:regex(\\d{{2}}):range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Ok($"{year}/{month}");
        }
        [HttpGet(nameof(Add))]
        public async Task<IActionResult> Add()
        {
            var genre = await _context.Genre.ToListAsync();
            var formModel = new MovieFormModel
            {
                Genre = genre,
                Movie = new Movie()
            };
            return View("~/Pages/Movie/Form.cshtml", formModel);
        }

        [HttpPost(nameof(Save))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormModel
                {
                    Movie = movie,
                    Genre = await _context.Genre.ToListAsync()
                };
                return View("~/Pages/Movie/Form.cshtml", viewModel);
            }
            if (movie.Id == 0)
            {
                // create new
                _context.Movies.Add(movie);
            }
            else
            {
                // edit
                _context.Update(movie);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null) return NotFound();
            var formModel = new MovieFormModel
            {
                Movie = movie,
                Genre = await _context.Genre.ToListAsync()
            };
            return View("~/Pages/Movie/Form.cshtml", formModel);
        }
    }
}