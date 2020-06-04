using System.Threading.Tasks;
using Student2.BL.Entities;

namespace Student2.DAL.Repositories
{
    public class UniversityRepository
    {
        readonly AppDbContext _dbContext;

        public UniversityRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public ValueTask<University> GetUniversity(int id)
        {
            return _dbContext.Universities.FindAsync(id);
        }
    }
}
