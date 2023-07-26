using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Areas.Admin.Controllers;

[Area(AreaConstants.AdminArea)]
public class HomeController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
