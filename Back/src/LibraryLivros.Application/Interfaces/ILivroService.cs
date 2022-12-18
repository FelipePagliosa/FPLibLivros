using LibraryLivros.Application.Requests.LivroRequests;
using LibraryLivros.Domain.Models;

namespace LibraryLivros.Application.Interfaces;

public interface ILivroService
{
    Task<List<Livro>> GetAll();
    Task Add(LivroInsertRequest request);
    Task Update(LivroUpdateRequest request);
    Task Delete(int livroId);
}
