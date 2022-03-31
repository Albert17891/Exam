using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Domain.Enum;
using MoviesManagement.Domain.Models.UserIdentiy;
using MoviesManagement.PersistanceDB.IdentityContext;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesManagement.PersistanceDB.Seed
{
    public static class UserSeed
    {
        public static void Migrate(UserContext context)
        {
            context.Database.Migrate();
        }
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(RolesEnum.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RolesEnum.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RolesEnum.User.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RolesEnum.Guest.ToString()));
        }

        public static async Task SeedAdminAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var admin = new AppUser()
            {
                FirstName = "Albert",
                LastName = "Gevorkyan",
                UserName = "Admin",
                Email = "abogevorgian@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != admin.Id))
            {
                var user = await userManager.FindByEmailAsync(admin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(admin, "Aa123456!");
                    await userManager.AddToRoleAsync(admin, RolesEnum.Admin.ToString());
                }
            }
        }

    }
}
