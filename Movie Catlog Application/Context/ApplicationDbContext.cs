using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movie_Catlog_Application.Models;
using System.Reflection.Emit;

namespace Movie_Catlog_Application.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Genre>()
                 .HasMany(x => x.MovieGenres)
                 .WithOne(y => y.Genre)
                 .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Movie>()
                 .HasMany(x => x.MovieGenres)
                 .WithOne(y => y.Movie)
                 .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
