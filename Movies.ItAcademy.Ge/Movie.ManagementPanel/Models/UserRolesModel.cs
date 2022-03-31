using System.Collections.Generic;

namespace Movies.ManagementPanel.Models
{
    public class UserRolesModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
