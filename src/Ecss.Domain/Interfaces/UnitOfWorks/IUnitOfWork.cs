using Ecss.Domain.Interfaces.Repositories;

namespace Ecss.Domain.Interfaces.UnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
    IRepository<T> Repository<T>() where T : class;
    Task SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
