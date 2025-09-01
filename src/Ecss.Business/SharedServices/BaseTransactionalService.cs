using Ecss.Domain.Interfaces.UnitOfWorks;

namespace Ecss.Business.SharedServices;

public abstract class BaseTransactionalService
{
    private readonly IUnitOfWork _unitOfWork;

    protected BaseTransactionalService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    protected async Task ExecuteInTransactionAsync(Func<Task> action)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            await action();
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    protected async Task<TResult> ExecuteInTransactionAsync<TResult>(Func<Task<TResult>> action)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var result = await action();
            await _unitOfWork.CommitTransactionAsync();
            return result;
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}
