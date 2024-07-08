using Caserita_Domain.Entities;

namespace Caserita_Domain.Interfaces
{
    public interface IUserRepo
    {
        Task<User> CreateUser(User user);
    }
}
