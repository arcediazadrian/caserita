using Caserita_Domain.Entities;
using Caserita_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User?> GetUserById(Guid id)
        {
            return await _dbContext.Users.Include(u => u.Settings).FirstAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbContext.Users.Include(u => u.Settings).ToListAsync();
        }

        public async Task<User?> UpdateUser(User user)
        {
            var userToUpdate = await _dbContext.Users.FindAsync(user.Id);

            if (userToUpdate == null) return null;

            _dbContext.Entry(userToUpdate).CurrentValues.SetValues(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
