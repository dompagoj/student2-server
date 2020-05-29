using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student2.Server.Models;
using Student2.Server.Repositories;

namespace Student2.Server.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : Controller
    {
        readonly AppJwtTokenHandler _tokenHandler;

        public TestController(AppJwtTokenHandler tokenHandler) => _tokenHandler = tokenHandler;

        public IActionResult Get()
        {
            var token = _tokenHandler.CreateSignedToken(AuthPolicies.ADMIN);

            return Ok(token);
        }

        [Authorize(Policy = AuthPolicies.REGULAR)]
        [Route("auth")]
        public IActionResult Test()
        {

            return Ok("Yey");
        }

    }
}
