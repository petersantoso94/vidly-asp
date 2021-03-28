using System;
using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class Movie : BaseEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required, Range(1, 20)]
        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; } = 0;



    }
}