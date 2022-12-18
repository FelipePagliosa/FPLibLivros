using Microsoft.EntityFrameworkCore;
using LibraryLivros.Domain.Repository;
using LibraryLivros.Infra.Context;
using LibraryLivros.Infra.Repository.Identity;

namespace LibraryLivros.Infra.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryLivrosContext context;


    public UnitOfWork(LibraryLivrosContext context)
    {
        this.context = context;
        this.UserRepository = new UserRepository(context);
        this.LivroRepository = new LivroRepository(context);

    }

    public IUserRepository UserRepository { get; }
    public ILivroRepository LivroRepository { get; }


    public void Iniciar()
    {
        foreach (var entry in this.context.ChangeTracker.Entries().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
            }
        }
    }

    public bool Commitar()
    {
        return (this.context.SaveChanges()) > 0;
    }

    public async Task<bool> CommitarAsync()
    {
        return (await this.context.SaveChangesAsync()) > 0;
    }
}

