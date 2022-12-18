using LibraryLivros.Domain.Models;

namespace LibraryLivros.Domain.Repository;

public interface IUserRepository : IBaseRepository<User>
{
    Task<List<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(int id);
}
