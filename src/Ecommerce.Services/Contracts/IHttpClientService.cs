using System.Net.Mime;

namespace Ecommerce.Services.Contracts;

public interface IHttpClientService
{
    Task<HttpResponseMessage> SendAsync(string url, HttpMethod method, string authorizationToken = null,
        string content = "", string mediaType = MediaTypeNames.Application.Json);
}
