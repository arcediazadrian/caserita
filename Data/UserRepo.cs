using Caserita_Domain.Entities;
using Caserita_Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Caserita_Data
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
