using Ecommerce.ViewModels.Users.WebApi;

namespace Ecommerce.Services.Contracts.Identity.WebApi;

public interface ITokenService
{
    string BuildToken(string key, string issuer, UserToBuildJwtTokenViewModel user, bool rememberMe);

    bool IsTokenValid(string key, string issuer, string token);
}
