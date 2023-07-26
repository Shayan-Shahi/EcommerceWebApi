using Ecommerce.DataLayer.Context;
using Ecommerce.Services.Contracts.Identity.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerice.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(Roles= "Admin")]
    public class UserController : ControllerBase
    {
        #region Constructor

        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IUnitOfWork _uow;
        public UserController(IConfiguration config, IUserService userService, IRoleService roleService, IUnitOfWork uow)
        {
            _config = config;
            _userService = userService;
            _roleService = roleService;
            _uow = uow;
        }
        #endregion

        [HttpGet]
        public List<string> TestData()
        {
            return new List<string>()
            {
                "Shayan Shahi",
                "Murat Yilmaz",
                "Ali Aslan"
            };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var user = await _userService.FindByIdAsync(id);
            return Ok(user);
        }


      
    }
}
