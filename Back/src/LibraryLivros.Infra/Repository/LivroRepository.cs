using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryLivros.Domain.Models;
using LibraryLivros.Domain.Repository;
using LibraryLivros.Infra.Context;

namespace LibraryLivros.Infra.Repository.Identity;

public class LivroRepository : BaseRepository<Livro>, ILivroRepository
{

    public LivroRepository(LibraryLivrosContext context) : base(context) {}

    public async Task<Livro> GetLivroByIdAsync(int id)
    {
        return await _context.Livro.FindAsync(id);
    }

    public async Task<List<Livro>> GetLivrosAsync()
    {
        return await _context.Livro.ToListAsync();
    }

    //get one livro by nome
    public async Task<Livro> GetLivroByNomeAsync(string nome)
    {
        return await _context.Livro.Where(x => x.Nome == nome).FirstOrDefaultAsync();
    }
}
