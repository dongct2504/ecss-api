using Ecss.DataAccess.Data;
using Ecss.Domain.Interfaces.Repositories;
using Ecss.Domain.Interfaces.UnitOfWorks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Ecss.DataAccess.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly EcssDbContext _dbContext;
    private readonly Dictionary<Type, object> _repositories = [];
    private readonly IServiceProvider _serviceProvider;
    private IDbContextTransaction? dbContextTransaction;

    public UnitOfWork(EcssDbContext dbContext, IServiceProvider serviceProvider)
    {
        _dbContext = dbContext;
        _serviceProvider = serviceProvider;
    }

    public IRepository<T> Repository<T>() where T : class
    {
        if (_repositories.TryGetValue(typeof(T), out var repo))
        {
            return (IRepository<T>)repo;
        }
        var repositoryInstance = _serviceProvider.GetRequiredService<IRepository<T>>();
        _repositories.Add(typeof(T), repositoryInstance);
        return repositoryInstance;
    }

    public async Task BeginTransactionAsync()
    {
        dbContextTransaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (dbContextTransaction == null)
        {
            throw new InvalidOperationException("No transaction started.");
        }
        try
        {
            await _dbContext.SaveChangesAsync();
            await dbContextTransaction.CommitAsync();
        }
        catch
        {
            await dbContextTransaction.RollbackAsync();
            throw;
        }
        finally
        {
            await dbContextTransaction.DisposeAsync();
            dbContextTransaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (dbContextTransaction != null)
        {
            await dbContextTransaction.RollbackAsync();
            await dbContextTransaction.DisposeAsync();
            dbContextTransaction = null;
        }
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if (dbContextTransaction != null)
        {
            await dbContextTransaction.DisposeAsync();
            dbContextTransaction = null;
        }
        await _dbContext.DisposeAsync();
        GC.SuppressFinalize(this);
    }
}
