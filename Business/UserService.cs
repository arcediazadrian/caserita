using Caserita_Domain.Entities;
using Domain.Interfaces;
namespace Business
{
    public class UserService : IUserService
    {
        private readonly IUserData _userData;
        public UserService(IUserData userData)
        {
            _userData = userData;
        }
        public User CreateNewUser()
        {
            return _userData.CreateNewUser();
        }
    }
}
