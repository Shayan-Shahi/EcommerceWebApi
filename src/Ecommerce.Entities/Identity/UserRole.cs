using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Entities.Identity;

public class UserRole : IdentityUserRole<int>
{
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}
