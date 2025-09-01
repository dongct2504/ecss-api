using Ecss.Business.Interfaces.Specifications;

namespace Ecss.Business.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false);
    Task<int> GetCountAsync();
    Task<T?> GetAsync(int id);
    Task<T?> GetAsync(long id);
    Task<T?> GetAsync(string id);
    Task<T?> GetAsync(Guid id);
    Task<T?> AnyAsync(Func<T, bool>? predicate = null);

    Task<T?> AddAsync(T entity);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);

    Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec, bool asNoTracking = false);
    Task<T?> GetWithSpecAsync(ISpecification<T> spec, bool asNoTracking = false);
}
