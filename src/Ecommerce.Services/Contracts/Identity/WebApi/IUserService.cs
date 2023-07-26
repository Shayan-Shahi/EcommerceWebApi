using Ecommerce.Entities.WebApiEntities;
using Ecommerce.ViewModels.Account.WebApi;
using Ecommerce.ViewModels.Users.WebApi;

namespace Ecommerce.Services.Contracts.Identity.WebApi;

public interface IUserService : IGenericService<User>
{
    UserToBuildJwtTokenViewModel GetUserBy(LoginViewModel model);
    bool IsExistsByUserNameForAdd(string userName);
    bool IsExistsByUserNameForEdit(string userName, int userId);
    User GetUserToEdit(int userId);
}
