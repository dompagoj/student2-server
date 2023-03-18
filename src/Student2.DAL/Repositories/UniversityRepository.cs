using System.Threading.Tasks;
using Student2.BL.Entities;

namespace LoginModel.Repositories
{
    public class UniversityRepository
    {
        readonly AppDbContext _dbContext;

        public UniversityRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public ValueTask<University?> GetUniversity(int id)
        {
            return _dbContext.University.FindAsync(id);
        }
    }
}
