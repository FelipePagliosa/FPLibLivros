using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryLivros.Domain.Models;
using LibraryLivros.Domain.Repository;
using LibraryLivros.Infra.Context;

namespace LibraryLivros.Infra.Repository.Identity;

public class UserRepository : BaseRepository<User>, IUserRepository
{

    public UserRepository(LibraryLivrosContext context) : base(context) {}

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.User.FindAsync(id);
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<User> GetUserByIdGatewayAsync(int idUserGateway)
    {
        return await _context.User.Where(x => x.Id == idUserGateway).FirstOrDefaultAsync();
    }
}
