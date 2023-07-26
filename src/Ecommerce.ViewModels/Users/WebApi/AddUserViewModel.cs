using Microsoft.AspNetCore.Http;

namespace Ecommerce.ViewModels.Users.WebApi;

public class AddUserViewModel
{
    public string UserName { get; set; }

    public string FullName { get; set; }

    public string Password { get; set; }

    public List<string> Roles { get; set; }

    public IFormFile Avatar { get; set; }
}
