using Caserita_Domain.Entities;

namespace Caserita_Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
    }
}
