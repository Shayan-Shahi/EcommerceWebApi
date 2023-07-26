using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Entities.Identity;

public class UserToken : IdentityUserToken<int>
{
    public virtual User User { get; set; }
}
