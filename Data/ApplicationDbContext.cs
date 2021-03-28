using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vidly.Models;

namespace vidly.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipType { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Customer>().ToTable("Customer");
            model.Entity<Movie>().ToTable("Movie");
            base.OnModelCreating(model);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateCreatedDate();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            UpdateCreatedDate();
            return base.SaveChanges();
        }

        protected void UpdateCreatedDate()
        {
            var entries = ChangeTracker.Entries().Where(entries => entries.Entity is BaseEntity && entries.State == EntityState.Added);
            foreach (var entry in entries)
            {
                ((BaseEntity)entry.Entity).CreatedDate = DateTime.Now;
            }
        }
    }
}
