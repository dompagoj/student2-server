using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student2.DAL.Repositories;

namespace Student2.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/universities")]
    public class UniversityController : Controller
    {
        readonly UniversityRepository _repo;

        public UniversityController(UniversityRepository repo) => _repo = repo;

        [Route("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var university = await _repo.GetUniversity(id);
            if (university == null) return NotFound();

            return Ok(university);
        }
    }
}
