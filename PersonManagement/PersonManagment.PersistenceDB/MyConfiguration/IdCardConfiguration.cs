using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonManagement.Model;
using PersonService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagment.PersistenceDB.MyConfiguration
{
    public class IdCardConfiguration : IEntityTypeConfiguration<IdCardRepo>
    {
        public void Configure(EntityTypeBuilder<IdCardRepo> builder)
        {
            builder.HasKey(x => x.PersonId);
            builder.Property(x => x.IdIdentifaer).IsRequired().HasMaxLength(11);
            builder.HasIndex(x => x.IdIdentifaer).IsUnique();
            builder.Property(x => x.Region).IsRequired().HasMaxLength(50);
            builder.HasOne(x => x.PersonRebo).WithOne(x => x.IdCard).HasForeignKey<IdCardRepo>().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
