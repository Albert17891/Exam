using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviesManagement.Domain.Models.UserIdentiy;

namespace MoviesManagement.PersistanceDB.IdentityContext
{
    public class UserContext : IdentityDbContext<AppUser>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
    }
}
