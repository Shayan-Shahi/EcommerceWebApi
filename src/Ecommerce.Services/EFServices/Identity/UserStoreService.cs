using Ecommerce.DataLayer.Context;
using Ecommerce.Entities.Identity;
using Ecommerce.Services.Contracts.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Ecommerce.Services.EFServices.Identity;

public class UserStoreService
: UserStore<User, Role, ECommerceDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>,
    IUserStoreService
{
    public UserStoreService(
        IUnitOfWork uow,
        IdentityErrorDescriber describer = null
        )
    : base((ECommerceDbContext)uow, describer)
    {
    }
}
