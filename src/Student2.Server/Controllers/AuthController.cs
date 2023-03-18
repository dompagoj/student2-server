using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MQTTnet.Extensions.ManagedClient;
using Student2.DAL.Models.Auth;
using Student2.Server.Services;

namespace Student2.Server.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        readonly AuthService _authService;
        readonly IManagedMqttClient _mqtt;

        public AuthController(AuthService authService, IManagedMqttClient mqtt)
        {
            _authService = authService;
            _mqtt = mqtt;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegisterModel form)
        {
            var result = await _authService.CreateUser(form);
            if (result.HasError) return BadRequest(result.Error.Message);
            var (user, token) = result.Value;

            var roles = await _authService.GetUserRoles(user);

            return Ok(new AuthResponse() { Token = token, User = new(user, roles) });
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] DAL.Models.Auth.LoginModel form)
        {
            var result = await _authService.LoginUser(form);
            if (result.HasError) return BadRequest(new { invalidLogin = result.Error.Serialize() });
            var (user, token) = result.Value;

            return Ok(new AuthResponse() { User = user, Token = token });
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserModel>> Me()
        {
            var result = await _authService.GetUser(User);
            if (result == null) return BadRequest();
            var (loggedInUser, roles) = result.Value;

            return Ok(new UserModel(loggedInUser, roles));
        }
    }
}
