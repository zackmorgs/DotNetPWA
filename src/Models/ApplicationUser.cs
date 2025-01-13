using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add custom properties here, e.g.:
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}