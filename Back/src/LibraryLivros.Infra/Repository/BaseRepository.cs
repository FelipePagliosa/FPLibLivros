using LibraryLivros.Domain;
using LibraryLivros.Domain.Repository;
using LibraryLivros.Infra.Context;

namespace LibraryLivros.Infra.Repository;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    public readonly LibraryLivrosContext _context;

    public BaseRepository(LibraryLivrosContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetEntities()
    {
        return _context.Set<T>()
            .AsQueryable();
    }
    public virtual T GetById(int id)
    {
        return _context.Set<T>().Where(e => e.Id == id).FirstOrDefault();
    }

    public void Add(T entity)
    {
        _context.Add(entity);
    }

    public void AddRange(List<T> entity)
    {
        _context.AddRange(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void UpdateRange(List<T> entity)
    {
        _context.UpdateRange(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public void DeleteRange(List<T> entity)
    {
        _context.RemoveRange(entity);
    }

}
