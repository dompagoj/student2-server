using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace Student2.Server.Controllers
{
    [ApiController]
    [Route("test")]
    public class Test : Controller
    {
        readonly IConnectionMultiplexer _cache;
        public Test(IConnectionMultiplexer cache)
        {
            _cache = cache;
        }


        [HttpGet("set")]
        public async Task<IActionResult> SetKey(string key, string value)
        {
            await _cache.GetDatabase().StringSetAsync(key, value);

            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetKey(string key)
        {
            var value = await _cache.GetDatabase().StringGetAsync(key);


            return Ok(value.ToString());
        }
    }
}
