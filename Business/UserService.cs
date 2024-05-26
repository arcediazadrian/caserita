using Domain;
using Domain.Interfaces;
namespace Business
{
    public class UserService : IUserService
    {
        private readonly IUserData _userData;
        public UserService(IUserData injectedUserData)
        {
            _userData = injectedUserData;
        }
        public User CreateNewUser()
        {
            return _userData.CreateNewUser();
        }
    }
}
