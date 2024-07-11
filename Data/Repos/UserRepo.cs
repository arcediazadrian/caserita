using Caserita_Domain.Entities;
using Caserita_Domain.Interfaces;

namespace Caserita_Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly CaseritaDbContext _dbContext;

        public UserRepo(CaseritaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
