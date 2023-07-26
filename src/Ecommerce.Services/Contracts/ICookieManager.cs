using Microsoft.AspNetCore.Http;

namespace Ecommerce.Services.Contracts;

public interface ICookieManager
{
    public void Add(string cookieName, string cookieValue, CookieOptions options = null);
    public string GetValue(string cookieName);
}
