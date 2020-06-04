using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student2.BL.Entities;
using Student2.DAL.Models;

namespace Student2.DAL.Repositories
{
    public class TutorRepository
    {
        readonly AppDbContext _dbContext;

        public TutorRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public Task<List<Tutor>> GetAll(int universityId)
        {
            return _dbContext.Tutor.Where(t => t.UniversityId == universityId).ToListAsync();
        }

        public async Task<Tutor> Create(int universityId, TutorCreateModel form)
        {
            var tutor = new Tutor()
            {
                Firstname = form.Firstname,
                Lastname = form.Lastname,
                Email = form.Email,
                UniversityId = universityId,
            };

            await _dbContext.Tutor.AddAsync(tutor);
            await _dbContext.SaveChangesAsync();

            return tutor;
        }

        public async Task<Tutor?> Update(int id, TutorCreateModel form)
        {
            var tutor = await _dbContext.Tutor.FindAsync(id);
            if (tutor == null) return null;
            tutor.Update(form);

            await _dbContext.SaveChangesAsync();

            return tutor;
        }

        public async Task<bool> Delete(int id)
        {
            var tutor = await _dbContext.Tutor.FindAsync(id);
            if (tutor == null) return false;

            _dbContext.Remove(tutor);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public ValueTask<Tutor> GetOne(int id)
            => _dbContext.Tutor.FindAsync(id);
    }
}
