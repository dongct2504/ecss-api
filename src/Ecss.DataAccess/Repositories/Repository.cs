using Ecss.Common.Enums;
using Ecss.DataAccess.Data;
using Ecss.Domain.Interfaces.Repositories;
using Ecss.Domain.Interfaces.Specifications;
using Ecss.Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecss.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly EcssDbContext _context;

    private readonly DbSet<T> _dbSet;

    public Repository(EcssDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false)
    {
        if (asNoTracking)
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        return await _dbSet.ToListAsync();
    }

    public async Task<int> GetCountAsync()
    {
        return await _dbSet.CountAsync();
    }

    public async Task<T?> GetAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> GetAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> GetAsync(string id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> GetAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> AnyAsync(Func<T, bool>? predicate = null)
    {
        if (predicate == null)
        {
            return await _dbSet.FirstOrDefaultAsync();
        }
        return await Task.FromResult(_dbSet.AsEnumerable().FirstOrDefault(predicate));
    }

    public async Task<T?> AddAsync(T entity)
    {
        var addedEntity = await _dbSet.AddAsync(entity);
        return addedEntity.Entity;
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public async Task<IEnumerable<T>> GetAllWithSpecAsync(
        ISpecification<T> spec,
        bool asNoTracking = false,
        int? skip = null,
        int? take = null,
        string? sortBy = null,
        OrderByEnum? orderBy = null)
    {
        IQueryable<T> query = ApplySpec(spec);
        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }
        if (!string.IsNullOrEmpty(sortBy))
        {
            OrderByEnum direction = orderBy ?? OrderByEnum.Asc;
            query = ApplyOrdering(query, sortBy, direction);
        }
        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }
        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }
        return await query.ToListAsync();
    }

    public async Task<T?> GetWithSpecAsync(ISpecification<T> spec, bool asNoTracking = false)
    {
        if (asNoTracking)
        {
            return await ApplySpec(spec).AsNoTracking().FirstOrDefaultAsync();
        }
        return await ApplySpec(spec).FirstOrDefaultAsync();
    }

    private IQueryable<T> ApplySpec(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), spec);
    }

    private static IQueryable<T> ApplyOrdering(IQueryable<T> source, string sortBy, OrderByEnum orderBy)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.PropertyOrField(parameter, sortBy);
        var lambda = Expression.Lambda(property, parameter);

        string methodName = orderBy == OrderByEnum.Desc ? "OrderByDescending" : "OrderBy";

        var result = typeof(Queryable).GetMethods()
            .First(method => method.Name == methodName && method.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(T), property.Type)
            .Invoke(null, [source, lambda]);

        return (IQueryable<T>)result!;
    }
}
