using Microsoft.EntityFrameworkCore;
using PersonManagement.Model;
using PersonManagment.PersistenceDB.MyConfiguration;
using PersonService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagment.PersistenceDB.Context
{
    public class PersonContext:DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> opt):base(opt)
        {

        }

       public DbSet<PersonRebo> Persons { get; set; }

       public DbSet<IdCardRepo> IdCards { get; set; }

        public DbSet<CarRepo> CarRepos { get; set; }

        public DbSet<PhoneRepo> PhoneRepos { get; set; }

        public DbSet<PersonPhone> PersonPhones { get; set; }

       public DbSet<UserRepo> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonContext).Assembly);          
        }
    }


    


}
