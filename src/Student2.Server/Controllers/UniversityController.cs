using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LoginModel.Repositories;
using Student2.BL.Entities;

namespace Student2.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("universities")]
    public class UniversityController : Controller
    {
        readonly UniversityRepository _repo;

        public UniversityController(UniversityRepository repo) => _repo = repo;

        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetOne(int id)
        {
            var university = await _repo.GetUniversity(id);
            if (university == null) return NotFound();

            return Ok(university);
        }
    }
}
