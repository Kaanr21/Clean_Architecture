using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public AppUser()
        {

            Id = new Guid().ToString();
        }
    }
}
