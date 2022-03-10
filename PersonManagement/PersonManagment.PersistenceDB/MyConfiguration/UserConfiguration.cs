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
    public class UserConfiguration : IEntityTypeConfiguration<UserRepo>
    {
        public void Configure(EntityTypeBuilder<UserRepo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(35);
            builder.Property(x => x.FirstName).IsRequired();
        }
    }
}
