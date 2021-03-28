using System;
using System.ComponentModel.DataAnnotations;

namespace vidly.Dtos
{
    public class MovieDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;

        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        [Required, Range(1, 20)]
        public int NumberInStock { get; set; } = 0;
    }
}