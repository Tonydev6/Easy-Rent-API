using Microsoft.AspNetCore.Identity;

namespace Easy_Rent_API.Entities.Users
{
    public class User : IdentityUser<long>
    {
        public User() { }
    }
}
