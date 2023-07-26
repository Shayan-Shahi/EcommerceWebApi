using Ecommerce.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Web.Pages;

[Authorize(Roles = IdentityRoleNames.Admin)]
public class BasePage : PageModel
{

}
