using Caserita_Domain.Entities;
using Caserita_Domain.Interfaces;

namespace Caserita_Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> CreateUser(User user)
        {
            return await _userRepo.CreateUser(user);
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _userRepo.GetUserById(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepo.GetAllUsers();
        }

        public async Task<User?> UpdateUser(User user)
        {
            return await _userRepo.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            return await _userRepo.DeleteUser(id);
        }
    }
}
