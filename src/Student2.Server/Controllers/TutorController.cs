using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student2.BL.Entities;
using Student2.DAL.Extensions;
using Student2.DAL.Models;
using Student2.DAL.Repositories;

namespace Student2.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/tutors")]
    public class TutorController : Controller
    {
        readonly TutorRepository _repo;

        public TutorController(TutorRepository repo) => _repo = repo;

        public async Task<ActionResult<List<Course>>> GetAll()
        {
            var courses = await _repo.GetAll(User.GetUniversityId());

            return Ok(courses);
        }

        [Route("{id}")]
        [Authorize(AppRole.EDITOR)]
        public async Task<ActionResult<Tutor>> GetOne(int id)
        {
            var tutor = await _repo.GetOne(id);
            if (tutor == null) return NotFound();

            return Ok(tutor);
        }

        [HttpPost]
        [Authorize(AppRole.EDITOR)]
        public async Task<ActionResult<Course>> Create([FromBody] TutorCreateModel form)
        {
            var tutor = await _repo.Create(User.GetUniversityId(), form);

            return Ok(tutor);
        }

        [HttpPut]
        [Authorize(AppRole.EDITOR)]
        [Route("{id}")]
        public async Task<ActionResult<Course>> Update(int id, [FromBody] TutorCreateModel form)
        {
            var course = await _repo.Update(id, form);
            if (course == null) return NotFound();

            return Ok(course);
        }

        [HttpDelete]
        [Authorize(AppRole.EDITOR)]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.Delete(id);
            if (!deleted) return NotFound();

            return Ok();
        }

    }
}
