using Domain;
using Domain.Interfaces;

namespace Data
{
    public class UserData : IUserData
    {
        public User CreateNewUser()
        {
            //Data should connect to some provider to get data, meanwhile creating Hardcoded User
            return new User() { Name = "", Email = ""};
        }
    }
}
