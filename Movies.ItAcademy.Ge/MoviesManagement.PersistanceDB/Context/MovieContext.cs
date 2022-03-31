using Microsoft.EntityFrameworkCore;
using MoviesManagement.Domain.Models;

namespace MoviesManagement.PersistanceDB.Context
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opt) : base(opt)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieContext).Assembly);
        }
    }
}
