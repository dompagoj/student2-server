using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginModel.Models;
using Microsoft.EntityFrameworkCore;
using Student2.BL.Entities;

namespace LoginModel.Repositories
{
    public class CourseRepository
    {
        readonly AppDbContext _dbContext;

        public CourseRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public Task<List<Course>> GetAll(int universityId)
            => _dbContext.Course.Where(c => c.UniversityId == universityId).Include(c => c.Tutor).ToListAsync();

        public async Task<Course> Create(int universityId, CourseCreateModel form)
        {
            var course = new Course
            {
                Name = form.Name,
                FullName = form.FullName,
                TutorId = form.TutorId,
                UniversityId = universityId,
            };

            await _dbContext.Course.AddAsync(course);
            await _dbContext.SaveChangesAsync();

            return course;
        }

        public async Task<Course?> Update(int id, CourseCreateModel form)
        {
            var course = await _dbContext.Course.FindAsync(id);
            if (course == null) return null;
            course.Update(form);

            await _dbContext.SaveChangesAsync();

            return course;
        }

        public async Task<bool> Delete(int id)
        {
            var course = await _dbContext.Course.FindAsync(id);
            if (course == null) return false;

            await _dbContext.Post.Where(p => p.CourseId == course.Id).LoadAsync();
            _dbContext.Remove(course);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public Task<Course?> GetOne(int id) =>
            _dbContext.Course.Where(c => c.Id == id).Include(c => c.Tutor).FirstOrDefaultAsync();
    }
}
