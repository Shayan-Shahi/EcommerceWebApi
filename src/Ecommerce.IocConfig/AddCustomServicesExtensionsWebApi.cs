using Ecommerce.DataLayer.Context;
using Ecommerce.Services.Contracts.Identity.WebApi;
using Ecommerce.Services.EFServices.Identity;
using Ecommerce.Services.EFServices.Identity.WebApi;
using Ecommerce.ViewModels.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Ecommerce.IocConfig;

public static class AddCustomServicesExtensionsWebApi
{
    public static IServiceCollection AddCustomServicesForWebApi(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var connectionStrings = provider.GetRequiredService<IOptionsMonitor<ConnectionStringsModel>>().CurrentValue;
        services.AddDbContext<TicketDbContext>(options =>
        {
            options.UseSqlServer(connectionStrings.TicketDbContextConnection);
        });
        services.AddScoped<IUnitOfWork, TicketDbContext>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IRoleService, RoleService>();
        return services;
    }
}
