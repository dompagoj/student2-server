namespace LoginModel.Repositories
{
    public class UserRepository
    {
        readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
