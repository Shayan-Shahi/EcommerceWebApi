using Ecommerce.Services.Contracts.Identity.WebApi;
using Ecommerce.ViewModels.TestWebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Ecommerice.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AccountController(IConfiguration config, IUserService userService, ITokenService tokenService)
        {
            _config = config;
            _userService = userService;
            _tokenService = tokenService;
        }


        /// <summary>
        /// <response code="200"> Everything is OL and you get the JWT token</response>
        /// <response code="400">Check the most OR ```UserName``` OR ```Password``` in incorrect</response>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetUserBy(model);
                if (user != null)
                {
                    var generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(),
                        _config["Jwt:Issuer"].ToString(), user, model.RememberMe);

                    if (generatedToken != null)
                    {
                        return Ok(generatedToken);
                    }
                    else
                    {
                        return BadRequest("something wrong");
                    }
                }

            }

            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpGet("Admin")]
        public IActionResult Admin()
        {
            return Ok();
        }

        [Authorize]
        [HttpGet("Admin2")]
        public IActionResult Admin2()
        {
            return Ok();
        }
        [Authorize(Roles="Admin, Customer")]
        public IActionResult Admin3()
        {
            var claims = User.Claims;
            return Ok();
        }
    }
}
