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
    public class PhoneConfiguration : IEntityTypeConfiguration<PhoneRepo>
    {
        public void Configure(EntityTypeBuilder<PhoneRepo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Number).IsUnique();
            builder.Property(x => x.Number).IsRequired();
            
        }
    }
}
