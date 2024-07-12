using Caserita_Domain.Entities;

namespace Caserita_Domain.Interfaces
{
    public interface IUserRepo
    {
        Task<User> CreateUser(User user);
        Task<User?> GetUserById(Guid id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> UpdateUser(User user);
        Task<bool> DeleteUser(Guid id);
    }
}
