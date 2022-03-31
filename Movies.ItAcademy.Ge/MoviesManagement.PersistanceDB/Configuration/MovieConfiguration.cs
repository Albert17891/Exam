using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesManagement.Domain.Models;

namespace MoviesManagement.PersistanceDB.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Genre).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Director).IsRequired().HasMaxLength(35);
            builder.Property(x => x.Actors).IsRequired();
            builder.Property(x => x.StartTime).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.Story).IsRequired();
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.HasMany(x => x.Tickets).WithOne(x => x.Movie).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
