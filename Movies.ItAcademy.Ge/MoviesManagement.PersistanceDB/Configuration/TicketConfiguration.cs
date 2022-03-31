using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesManagement.Domain.Models;


namespace MoviesManagement.PersistanceDB.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsBooked).IsRequired();
            builder.Property(x => x.IsCanceled).IsRequired();
            builder.Property(x => x.IsAcquired).IsRequired();
        }
    }
}
