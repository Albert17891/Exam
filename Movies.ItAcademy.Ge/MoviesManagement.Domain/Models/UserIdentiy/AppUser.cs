using Microsoft.AspNetCore.Identity;

namespace MoviesManagement.Domain.Models.UserIdentiy
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
