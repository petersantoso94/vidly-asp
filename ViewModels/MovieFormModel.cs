using System.Collections.Generic;
using vidly.Models;

namespace vidly.ViewModels
{
    public class MovieFormModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
    }
}