using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using vidly.Models;

namespace vidly.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Movies.Any())
            {
                var movies = new List<Movie>(){
                    new Movie{ Name = "Shrek", ReleaseDate = new DateTime(2009,12,2),  GenreId = 1},
                    new Movie{ Name = "IronMan", ReleaseDate = new DateTime(2012,1,2),  GenreId = 1},
                    new Movie{ Name = "Hulk", ReleaseDate = new DateTime(2010,8,2), GenreId = 2}
                };

                movies.ForEach(movie =>
                {
                    context.Movies.Add(movie);
                });

                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                var role = new List<IdentityRole>{
                    new IdentityRole{Name="CanManageMovies"}
                };
                context.Roles.AddRange(role);
                context.SaveChanges();
            }
            return; // db already seeded            
        }
    }
}