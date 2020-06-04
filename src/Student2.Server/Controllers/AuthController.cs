using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student2.Server.Models.Auth;
using Student2.Server.Services;

namespace Student2.Server.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        readonly AuthService _authService;

        public AuthController(AuthService authService) => _authService = authService;

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterDto form)
        {
            var result = await _authService.CreateUser(form);
            if (result.HasError) return BadRequest(result.Error.Message);
            var (user, token) = result.Value;

            var roles = await _authService.GetUserRoles(user);

            return Ok(new {user = new UserDto(user, roles), token});
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto form)
        {
            var result = await _authService.LoginUser(form);
            if (result.HasError) return BadRequest(result.Error.Serialize());
            var (user, token) = result.Value;

            return Ok(new {user, token});
        }

        [HttpGet]
        [Route("me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var result = await _authService.GetUser(User);
            if (result == null) return BadRequest();
            var (loggedInUser, roles) = result.Value;

            return Ok(new
            {
                user = new UserDto(loggedInUser, roles),
            });
        }
    }
}
