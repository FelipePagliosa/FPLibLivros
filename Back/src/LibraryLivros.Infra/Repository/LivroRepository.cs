using System.Linq;
using Microsoft.EntityFrameworkCore;
using LibraryLivros.Domain.Models;
using LibraryLivros.Domain.Repository;
using LibraryLivros.Infra.Context;
using System.Linq.Expressions;

namespace LibraryLivros.Infra.Repository.Identity;

public class LivroRepository : BaseRepository<Livro>, ILivroRepository
{

    public LivroRepository(LibraryLivrosContext context) : base(context) {}

    public async Task<Livro> GetLivroByIdAsync(int id)
    {
        return await _context.Livro.Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == id);
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

    //GET LIVROS BY FILTEREXPRESSION
    public async Task<List<Livro>> GetLivrosByFilterAsync(LivroFilter filtro)
    {
        return await _context.Livro.Where(FilterExpression(filtro)).ToListAsync();
    }

    //GetLivrosByUserAsync
    public async Task<List<Livro>> GetLivrosByUserAsync(int userId)
    {
        return await _context.Livro.Where(x => x.Users.Any(y => y.Id == userId)).ToListAsync();
    }    

    private Expression<Func<Livro, bool>> FilterExpression(LivroFilter filtro)
    {
        return oa =>
            ((String.IsNullOrEmpty(filtro.Nome) || oa.Nome.Contains(filtro.Nome)) &&
            (String.IsNullOrEmpty(filtro.Autor) || oa.Autor.Contains(filtro.Autor)))
        ;
    }
}
