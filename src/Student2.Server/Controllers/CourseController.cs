using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student2.BL.Entities;
using LoginModel.Extensions;
using LoginModel.Models;
using LoginModel.Repositories;

namespace Student2.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("courses")]
    public class CourseController : Controller
    {
        readonly CourseRepository _repo;

        public CourseController(CourseRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAll()
        {
            var courses = await _repo.GetAll(User.GetUniversityId());

            return Ok(courses);
        }

        [HttpGet("{id}")]
        [Authorize]
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

        [HttpPut("{id}")]
        [Authorize(AppRole.EDITOR)]
        public async Task<ActionResult<Course>> Update(int id, [FromBody] CourseCreateModel form)
        {
            var course = await _repo.Update(id, form);
            if (course == null) return NotFound();

            return Ok(course);
        }

        [HttpDelete("{id}")]
        [Authorize(AppRole.EDITOR)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.Delete(id);
            if (!deleted) return NotFound();

            return Ok();
        }

    }
}
