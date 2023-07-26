using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Entities.Identity;

public class UserLogin : IdentityUserLogin<int>
{
    public virtual User User { get; set; }
}
