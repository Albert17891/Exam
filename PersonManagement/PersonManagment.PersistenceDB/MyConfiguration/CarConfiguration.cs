using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagment.PersistenceDB.MyConfiguration
{
    public class CarConfiguration : IEntityTypeConfiguration<CarRepo>
    {
        public void Configure(EntityTypeBuilder<CarRepo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.CarID).IsUnique();
            builder.Property(x => x.CarID).IsRequired().HasMaxLength(7);
            builder.Property(x => x.Mark).IsRequired().HasMaxLength(35);
        }
    }
}
