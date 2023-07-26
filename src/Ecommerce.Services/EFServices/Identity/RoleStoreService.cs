using Ecommerce.DataLayer.Context;
using Ecommerce.Entities.Identity;
using Ecommerce.Services.Contracts.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Ecommerce.Services.EFServices.Identity;

public class RoleStoreService
: RoleStore<Role, ECommerceDbContext, int, UserRole, RoleClaim>,
    IRoleStoreService
{
    public RoleStoreService(
        IUnitOfWork uow, IdentityErrorDescriber describer = null
        )
    : base((ECommerceDbContext)uow, describer)
    {

    }
}
