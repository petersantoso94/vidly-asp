using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using vidly.Models;

namespace vidly.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
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

            if (!context.Roles.Any(r => r.Name == CUserRole.MovieManager()))
            {
                roleManager.CreateAsync(new IdentityRole
                {
                    Name = CUserRole.MovieManager(),
                    NormalizedName = CUserRole.NormalizedMovieManager()
                }).Wait();
            }

            if (!context.Roles.Any(r => r.Name == CUserRole.CustomerManager()))
            {
                roleManager.CreateAsync(new IdentityRole
                {
                    Name = CUserRole.CustomerManager(),
                    NormalizedName = CUserRole.NormalizedCustomerManager()
                }).Wait();
            }

            if (!context.Users.Any(r => r.Email == "manager@movie"))
            {
                var user = new IdentityUser { Email = "manager@movie", UserName = "manager@movie", EmailConfirmed = true };
                userManager.CreateAsync(user, "Manager123!").Wait();
                userManager.AddToRoleAsync(user, CUserRole.MovieManager()).Wait();
            }

            if (!context.Users.Any(r => r.Email == "manager@customer"))
            {
                var user = new IdentityUser { Email = "manager@customer", UserName = "manager@customer", EmailConfirmed = true };
                userManager.CreateAsync(user, "Manager123!").Wait();
                userManager.AddToRoleAsync(user, CUserRole.CustomerManager()).Wait();
            }
            return; // db already seeded            
        }
    }
}