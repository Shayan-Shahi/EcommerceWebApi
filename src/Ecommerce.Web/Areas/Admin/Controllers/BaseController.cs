using Ecommerce.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Areas.Admin.Controllers;

[Authorize(Roles = IdentityRoleNames.Admin)]
public class BaseController : Controller
{

}
