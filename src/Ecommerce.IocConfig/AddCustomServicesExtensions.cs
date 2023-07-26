using Ecommerce.Common.Mvc;
using Ecommerce.Common.Security;
using Ecommerce.DataLayer.Context;
using Ecommerce.Entities.Identity;
using Ecommerce.Services;
using Ecommerce.Services.Contracts;
using Ecommerce.Services.Contracts.Identity;
using Ecommerce.Services.Contracts.WebApi;
using Ecommerce.Services.EFServices;
using Ecommerce.Services.EFServices.Identity;
using Ecommerce.Services.EFServices.WebApi;
using Ecommerce.ViewModels.Application;
using Ecommerce.Services.EFServices.Identity;
using Ganss.XSS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Ecommerce.IocConfig;

public static class AddCustomServicesExtensions
{
    public const string EmailConfirmationTokenProviderName = "ConfirmEmail";
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var connectionStrings = provider.GetRequiredService<IOptionsMonitor<ConnectionStringsModel>>().CurrentValue;
        services.AddDbContext<ECommerceDbContext>(options =>
        {
            options.UseSqlServer(connectionStrings.ECommerceDbContextConnection);
        });

        #region RegisterIdentityServices

        services.AddScoped<IUserClaimsPrincipalFactory<User>, UserClaimService>();
        services.AddScoped<UserClaimsPrincipalFactory<User, Role>, UserClaimService>();

        services.AddScoped<IRoleManagerService, RoleManagerService>();
        services.AddScoped<RoleManager<Role>, RoleManagerService>();

        services.AddScoped<IRoleStoreService, RoleStoreService>();
        services.AddScoped<RoleStore<Role, ECommerceDbContext, int, UserRole, RoleClaim>, RoleStoreService>();

        services.AddScoped<IUserManagerService, UserManagerService>();
        services.AddScoped<UserManager<User>, UserManagerService>();

        services.AddScoped<IUserStoreService, UserStoreService>();
        services.AddScoped<UserStore<User, Role, ECommerceDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>,
            UserStoreService>();

        services.AddScoped<ISignInManagerService, SignInManagerService>();
        services.AddScoped<SignInManager<User>, SignInManagerService>();

        #endregion

        services.AddScoped<IUnitOfWork, ECommerceDbContext>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductImageService, ProductImageService>();
        services.AddScoped<ISliderService, SliderService>();
        services.AddScoped<IEmailSenderService, EmailSenderService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<ICartDetailService, CartDetailService>();
        services.AddScoped<IProductTagService, ProductTagService>();
        services.AddScoped<ICookieManager, CookieManager>();
        services.AddScoped<IUserServiceWebApi, UserServiceWebApi>();
        services.AddScoped<IHttpClientService, HttpClientService>();
        services.AddScoped<IRijndaelEncryption, RijndaelEncryption>();

        services.AddConfirmEmailDataProtectorTokenOptions();
        services.AddIdentity<User, Role>(identityOptions =>
        {
            SetPasswordOptions(identityOptions.Password);

            identityOptions.Lockout.AllowedForNewUsers = false;
            identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            identityOptions.Lockout.MaxFailedAccessAttempts = 3;

            identityOptions.SignIn.RequireConfirmedEmail = true;
            identityOptions.SignIn.RequireConfirmedPhoneNumber = false;
            identityOptions.SignIn.RequireConfirmedAccount = true;

            identityOptions.User.RequireUniqueEmail = true;
        })
            .AddUserStore<UserStoreService>()
            .AddUserManager<UserManagerService>()
            .AddRoleStore<RoleStoreService>()
            .AddRoleManager<RoleManagerService>()
            .AddSignInManager<SignInManagerService>()
            .AddErrorDescriber<CustomIdentityErrorDescriber>()
            //.AddEntityFrameworkStores<EShopDbContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<ConfirmEmailDataProtectorTokenProvider<User>>(EmailConfirmationTokenProviderName);
        services.Configure<SecurityStampValidatorOptions>(options =>
        {
            options.ValidationInterval = TimeSpan.Zero;
        });
        services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = "****";
                options.ClientSecret = "****";
            });
        services.AddRazorViewRenderer();

        #region Html sanitizer
        IHtmlSanitizer sanitizer = new HtmlSanitizer();
        //services.AddSingleton<IHtmlSanitizer, HtmlSanitizer>();
        services.AddSingleton(sanitizer);
        #endregion

        return services;
    }

    private static void AddConfirmEmailDataProtectorTokenOptions(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.Tokens.EmailConfirmationTokenProvider = EmailConfirmationTokenProviderName;
        });

        services.Configure<ConfirmEmailDataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromDays(3);
        });
    }

    public static IServiceCollection AddRazorViewRenderer(this IServiceCollection services)
    {
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IViewRendererService, ViewRendererService>();
        return services;
    }

    private static void SetPasswordOptions(PasswordOptions passwordOptions)
    {
        passwordOptions.RequireDigit = false;
        passwordOptions.RequireLowercase = false;
        passwordOptions.RequireUppercase = true;
        passwordOptions.RequireNonAlphanumeric = false;
    }
}
