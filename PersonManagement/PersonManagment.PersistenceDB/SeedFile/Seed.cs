using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonManagment.PersistenceDB.Context;
using PersonService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagment.PersistenceDB.SeedFile
{
    public static class Seed
    {
        public static void AddSeed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var database = scope.ServiceProvider.GetRequiredService<PersonContext>();


            SeedEverting(database);


            Migrate(database);
        }

        private static void SeedEverting(PersonContext context)
        {
            bool Isseed = false;

            SeedPerson(context, ref Isseed);
            SeedUser(context, ref Isseed);
            if (Isseed == true)
            {
                context.SaveChanges();
            }
        }

        private static void SeedUser(PersonContext context, ref bool isseed)
        {
            var users = new List<User>
            {
                new User(){FirstName="Albert",LastName="Gev",UserName="Abo",Password="1233"},
                new User(){FirstName="Gevo",LastName="Gev",UserName="gebo",Password="1244433"}
            };

            foreach (var user in users)
            {
                if (context.Users.AnyAsync(x => x.UserName == user.UserName).Result) continue;

                context.Add(user);
                isseed = true;
            }
        }

        private static void SeedPerson(PersonContext context, ref bool isseed)
        {
            var persons = new List<Person>
            {
                new Person(){Name="ALbert",BirthDate=DateTime.Now.AddYears(-30),Position="Intern"},
                new Person(){Name="Davit",BirthDate=DateTime.Now.AddYears(-40),Position="Middle"}
            };

            foreach (var person in persons)
            {
                if (context.Persons.AnyAsync(x => x.Name == person.Name).Result) continue;

                context.Add(person);
                isseed = true;
            }
        }

        private static void Migrate(PersonContext context)
        {
            context.Database.Migrate();
        }
    }
}
