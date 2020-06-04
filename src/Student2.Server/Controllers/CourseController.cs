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
    [Route("api/courses")]
    public class CourseController : Controller
    {
        readonly CourseRepository _repo;

        public CourseController(CourseRepository repo) => _repo = repo;

        public async Task<ActionResult<List<Course>>> GetAll()
        {
            var courses = await _repo.GetAll(User.GetUniversityId());

            return Ok(courses);
        }

        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<Course>> GetOne(int id)
        {
            var course = await _repo.GetOne(id);
            if (course == null) return NotFound();

            return Ok(course);
        }

        [HttpPost]
        [Authorize(AppRole.EDITOR)]
        public async Task<ActionResult<Course>> Create([FromBody] CourseCreateModel form)
        {
            var course = await _repo.Create(User.GetUniversityId(), form);

            return Ok(course);
        }

        [HttpPut]
        [Authorize(AppRole.EDITOR)]
        [Route("{id}")]
        public async Task<ActionResult<Course>> Update(int id, [FromBody] CourseCreateModel form)
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
