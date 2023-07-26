using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Entities.Identity;

public class UserClaim : IdentityUserClaim<int>
{
    public virtual User User { get; set; }
}
