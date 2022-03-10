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
    public class PersonPhoneConfiguration : IEntityTypeConfiguration<PersonPhone>
    {
        public void Configure(EntityTypeBuilder<PersonPhone> builder)
        {
            builder.HasKey(x => new { x.PersonId, x.PhoneId });

            builder.HasOne(x => x.Person).WithMany(x => x.PersonPhones)
                .HasForeignKey(x=>x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x=>x.Phone).WithMany(x=>x.PersonPhones)
                .HasForeignKey(x=>x.PhoneId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
