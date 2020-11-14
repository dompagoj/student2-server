using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student2.BL.Entities;
using Student2.DAL;
using Student2.DAL.Extensions;
using Student2.DAL.Models;

namespace Student2.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/posts/{postId}/comments")]
    public class CommentController : Controller
    {
        AppDbContext _dbContext;
        public CommentController(AppDbContext dbContext) => _dbContext = dbContext;


        [HttpPost]
        public async Task<ActionResult<Comment>> Create(int postId, [FromBody] CreateCommentModel form)
        {
            var comment = new Comment
            {
                Content = form.Content,
                UserId = User.GetUserId(),
                CreatedAt = DateTime.Now,
                PostId = postId,
            };

            await _dbContext.Comment.AddAsync(comment);
            await _dbContext.Entry(comment).Reference(c => c.User).LoadAsync();
            await _dbContext.SaveChangesAsync();

            return Ok(comment);
        }
}
}
