using LibraryLivros.Domain.Repository;

namespace LibraryLivros.Domain.Repository;

public interface IUnitOfWork
{
    public IUserRepository UserRepository { get; }
    public ILivroRepository LivroRepository { get; }
    void Iniciar();
    bool Commitar();
    Task<bool> CommitarAsync();
}
