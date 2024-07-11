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
    }
}
