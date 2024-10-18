using Microsoft.AspNetCore.Identity;

namespace Store.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
