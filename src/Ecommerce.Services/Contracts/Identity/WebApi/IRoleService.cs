using Ecommerce.Entities.WebApiEntities;

namespace Ecommerce.Services.Contracts.Identity.WebApi;

public interface IRoleService : IGenericService<Role>
{
    List<Role> GetRolesBy(List<string> roles);
}
