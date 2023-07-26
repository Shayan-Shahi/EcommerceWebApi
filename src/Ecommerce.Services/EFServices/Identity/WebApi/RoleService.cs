using Ecommerce.DataLayer.Context;
using Ecommerce.Entities.WebApiEntities;
using Ecommerce.Services.Contracts.Identity.WebApi;
using Ecommerce.Services.EFServices;

using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.EFServices.Identity.WebApi;

public class RoleService : GenericService<Role>, IRoleService
{
    private readonly DbSet<Role> _roles;
    public RoleService(IUnitOfWork uow) : base(uow)
    {
        _roles = uow.Set<Role>();
    }

    public List<Role> GetRolesBy(List<string> roles)
        => _roles
            .Where(x => roles.Contains(x.Title))
            .ToList();
}
