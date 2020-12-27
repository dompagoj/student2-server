using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student2.BL.Entities;
using Student2.DAL.Extensions;
using Student2.DAL.Models;
using Student2.DAL.Repositories;
using Student2.Server.Services;

namespace Student2.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route(("api"))]
    public class PostController : Controller
    {
        readonly PostRepository _repo;
        readonly MarkdownService _markdown;

        public PostController(PostRepository repo, MarkdownService markdown) => (_repo, _markdown) = (repo, markdown);

        [Route("posts")]

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _repo.GetAll(User.GetUniversityId());

            return Ok(posts);
        }

        [Route("users/{userId}/posts")]
        [HttpGet]
        public async Task<IActionResult> GetUserPosts(int userId)
        {
            var posts = await _repo.GetAllFromUser(User.GetUniversityId(), userId);

            return Ok(posts);
        }

        [Route("posts/{id}")]
        [HttpGet]
        public async Task<ActionResult<Post>> GetOne(int id)
        {
            var post = await _repo.GetOne(id);
            if (post == null) return NotFound();
            if (!PostRepository.CheckAccessPerms(post, User)) return Forbid();

            return Ok(post);
        }

        [Route("posts")]
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost([FromBody] PostCreateModel form)
        {
            var post = await _repo.Create(form, User, _markdown.ToHtml);

            return Ok(post);
        }

        [Route("posts/{id}")]
        [HttpPut]
        public async Task<ActionResult<Post>> UpdatePost(int id, [FromBody] PostUpdateModel form)
        {
            var post = await _repo.GetOne(id);
            if (post == null) return NotFound();
            if (!PostRepository.CheckModifyPerms(post, User)) return Forbid();

            await _repo.UpdatePost(post, form, _markdown.ToHtml);

            return Ok(post);
        }

        [Route("posts/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.Delete(id);
            if (!deleted) return NotFound();

            return Ok();
        }

    }
}
