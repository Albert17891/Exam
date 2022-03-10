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
    public class PersonConfiguration : IEntityTypeConfiguration<PersonRebo>
    {
        public void Configure(EntityTypeBuilder<PersonRebo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50).IsUnicode();
            builder.Property(x => x.BirthDate).HasColumnType("datetime");
            builder.HasMany(x => x.Cars).WithOne(x => x.Person)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
