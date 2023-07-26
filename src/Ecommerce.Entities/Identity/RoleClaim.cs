using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Entities.Identity;

public class RoleClaim : IdentityRoleClaim<int>
{
    public virtual Role Role { get; set; }
}
