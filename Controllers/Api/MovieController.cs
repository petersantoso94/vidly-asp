using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vidly.Data;
using vidly.Dtos;
using vidly.Models;

namespace vidly.Controllers.Api
{

    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MovieController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public IActionResult Get()
        {
            return Ok(_context.Movies.Include(x => x.Genre).ToList().Select(_mapper.Map<Movie, MovieDto>));
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null) return NotFound();
            return Ok(_mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IActionResult PostAsync([FromBody] MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return CreatedAtAction("GetMovie", movie.Id, movieDto);
        }

        [HttpPut("{id}")]
        public IActionResult PutAsync(int id, [FromBody] MovieDto movieDto)
        {
            // validate customer
            if (!ModelState.IsValid) return BadRequest();
            var existingMovie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (existingMovie == null) return NotFound();

            // update customer
            _mapper.Map(movieDto, existingMovie);

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingMovie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (existingMovie == null) return NotFound();
            _context.Movies.Remove(existingMovie);
            _context.SaveChanges();
            return Ok();
        }
    }


}