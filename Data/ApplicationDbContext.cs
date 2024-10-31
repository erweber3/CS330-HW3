using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fall2024_Assignment3_erweber3.Models;

namespace Fall2024_Assignment3_erweber3.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<Actor> Actor { get; set; } = default!;
        public DbSet<MovieActor> MovieActor { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure other entities here if needed, e.g., Movie, Actor, MovieActor
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Actor>().ToTable("Actor");
            modelBuilder.Entity<MovieActor>().ToTable("MovieActor");
        }
    }
}
