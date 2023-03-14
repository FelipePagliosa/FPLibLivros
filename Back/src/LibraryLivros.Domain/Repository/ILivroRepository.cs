using LibraryLivros.Domain.Models;

namespace LibraryLivros.Domain.Repository;

public interface ILivroRepository : IBaseRepository<Livro>
{
    Task<List<Livro>> GetLivrosAsync();
    Task<Livro> GetLivroByIdAsync(int id);
    Task<Livro> GetLivroByNomeAsync(string nome);
    Task<List<Livro>> GetLivrosByFilterAsync(LivroFilter filtro);
    Task<List<Livro>> GetLivrosByUserAsync(int userId);
}
