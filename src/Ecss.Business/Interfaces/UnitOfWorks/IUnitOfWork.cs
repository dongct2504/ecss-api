using Ecss.Business.Interfaces.Repositories;

namespace Ecss.Business.Interfaces.UnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
    IRepository<T> Repository<T>() where T : class;
    Task SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
