using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student2.BL.Entities;
using Student2.DAL.Extensions;
using Student2.DAL.Models;

namespace Student2.DAL.Repositories
{
    public class PostRepository
    {
        readonly AppDbContext _dbContext;

        public PostRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public Task<List<Post>> GetAll(int universityId)
        {
            return _dbContext.Posts.Where(p => p.UniversityId == universityId).Include(p => p.Course)
                .Include(p => p.Creator).Include(p => p.Comments).OrderByDescending(p => p.Id).ToListAsync();
        }

        public Task<Post> GetOne(int id) => _dbContext.Posts.Where(p => p.Id == id).Include(p => p.Creator)
            .Include(p => p.Comments).ThenInclude(c => c.User)
            .Include(p => p.Course)
            .Include(p => p.University).FirstOrDefaultAsync();

        public Task<List<Post>> GetAllFromUser(int universityId, int userId)
        {
            return _dbContext.Posts.Where(p => p.UniversityId == universityId && p.CreatorId == userId)
                .Include(p => p.Course).ToListAsync();
        }

        public static bool CheckModifyPerms(Post post, ClaimsPrincipal principal) =>
            post.CreatorId == principal.GetUserId() && post.UniversityId == principal.GetUniversityId();

        public static bool CheckAccessPerms(Post post, ClaimsPrincipal principal) =>
            post.UniversityId == principal.GetUniversityId();


        public Task UpdatePost(Post post, PostUpdateModel model, Func<string, string> mdParser)
        {
            post.Update(model);
            post.ContentHtml = model.Content != null ? mdParser(model.Content) : null;

            return _dbContext.SaveChangesAsync();
        }

        public async Task<Post> Create(PostCreateModel model, ClaimsPrincipal principal,
            Func<string, string> mdParser)
        {
            var post = new Post
            {
                Title = model.Title,
                Content = model.Content,
                ContentHtml = model.Content != null ? mdParser(model.Content) : null,
                CourseId = model.CourseId,
                UpVotes = 0,
                CreatedAt = DateTime.Now,
                UniversityId = principal.GetUniversityId(),
                CreatorId = principal.GetUserId(),
            };
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();

            return post;
        }

        public async Task<bool> Delete(int id)
        {
            var post = await _dbContext.Posts.FindAsync(id);
            if (post == null) return false;

            _dbContext.Remove(post);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
